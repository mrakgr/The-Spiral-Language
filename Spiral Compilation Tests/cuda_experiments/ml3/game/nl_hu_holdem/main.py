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
__device__ bool player_can_act_39(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5);
__device__ US5 go_next_street_40(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5);
__device__ US5 try_round_38(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5);
struct Tuple13;
__device__ Tuple13 draw_cards_41(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
struct Tuple14;
__device__ Tuple14 draw_cards_42(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ static_array_list<unsigned char,5l,long> get_community_cards_43(US6 v0, static_array<unsigned char,1l> v1);
struct Tuple15;
__device__ long loop_46(static_array<float,8l> v0, float v1, long v2);
__device__ long sample_discrete__45(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1);
__device__ US1 sample_discrete_44(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1);
__device__ void write_48(long v0);
__device__ void write_47(static_array<long,2l> v0);
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
__device__ Tuple0 score_49(static_array<unsigned char,7l> v0);
__device__ US5 play_loop_inner_33(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US5 v4);
__device__ Tuple8 play_loop_32(US4 v0, static_array<US2,2l> v1, US7 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US5 v6);
__device__ void f_51(unsigned char * v0, unsigned long long v1);
__device__ void f_52(unsigned char * v0, long v1);
__device__ void f_54(unsigned char * v0, long v1);
__device__ void f_57(unsigned char * v0, unsigned char v1);
__device__ void f_56(unsigned char * v0, unsigned char v1);
__device__ void f_55(unsigned char * v0, static_array_list<unsigned char,5l,long> v1);
__device__ void f_58(unsigned char * v0, long v1, long v2);
__device__ void f_60(unsigned char * v0, long v1);
__device__ void f_61(unsigned char * v0);
__device__ void f_59(unsigned char * v0, long v1, US1 v2);
__device__ void f_62(unsigned char * v0, long v1, static_array<unsigned char,2l> v2);
__device__ void f_65(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_64(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_63(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3);
__device__ void f_53(unsigned char * v0, US3 v1);
__device__ void f_66(unsigned char * v0, long v1);
__device__ void f_69(unsigned char * v0, static_array<unsigned char,2l> v1);
__device__ void f_70(unsigned char * v0, long v1);
__device__ void f_71(unsigned char * v0, static_array<unsigned char,3l> v1);
__device__ void f_72(unsigned char * v0, static_array<unsigned char,5l> v1);
__device__ void f_73(unsigned char * v0, static_array<unsigned char,4l> v1);
__device__ void f_68(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US6 v6);
__device__ void f_75(unsigned char * v0, long v1);
__device__ void f_74(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US6 v6, US1 v7);
__device__ void f_67(unsigned char * v0, US5 v1);
__device__ void f_76(unsigned char * v0, US2 v1);
__device__ void f_77(unsigned char * v0, long v1);
__device__ void f_50(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US4 v3, static_array<US2,2l> v4, US7 v5);
__device__ void f_79(unsigned char * v0, long v1);
__device__ void f_78(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US7 v3);
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
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case0; // G_Flop
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case1; // G_Fold
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case3; // G_River
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case4; // G_Round
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            US1 v6;
            long v0;
            long v3;
        } case5; // G_Round'
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case6; // G_Showdown
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
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
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
        } case1; // GameOver
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US6 v5;
            long v0;
            long v3;
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
    static_array<static_array<unsigned char,2l>,2l> v1;
    static_array<long,2l> v2;
    static_array<long,2l> v4;
    US6 v5;
    long v0;
    long v3;
    __device__ Tuple6(long t0, static_array<static_array<unsigned char,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US6 t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<unsigned char,2l>,2l> v1;
    static_array<long,2l> v2;
    static_array<long,2l> v4;
    US6 v5;
    US1 v6;
    long v0;
    long v3;
    __device__ Tuple7(long t0, static_array<static_array<unsigned char,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US6 t5, US1 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
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
__device__ US5 US5_0(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_Flop
    US5 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5;
    return x;
}
__device__ US5 US5_1(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_Fold
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US5 US5_2() { // G_Preflop
    US5 x;
    x.tag = 2;
    return x;
}
__device__ US5 US5_3(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_River
    US5 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5;
    return x;
}
__device__ US5 US5_4(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_Round
    US5 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US5 US5_5(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5, US1 v6) { // G_Round'
    US5 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6;
    return x;
}
__device__ US5 US5_6(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_Showdown
    US5 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5;
    return x;
}
__device__ US5 US5_7(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // G_Turn
    US5 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5;
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
__device__ US7 US7_1(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // GameOver
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US7 US7_2(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5) { // WaitingForActionFromPlayerId
    US7 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
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
    v1 = (long *)(v0+28ull);
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
    static_array<static_array<unsigned char,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 2ull;
        unsigned long long v8;
        v8 = 4ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<unsigned char,2l> v10;
        v10 = f_24(v9);
        bool v11;
        v11 = 0l <= v4;
        bool v13;
        if (v11){
            bool v12;
            v12 = v4 < 2l;
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
        v3.v[v4] = v10;
        v4 += 1l ;
    }
    static_array<long,2l> v15;
    long v16;
    v16 = 0l;
    while (while_method_0(v16)){
        unsigned long long v18;
        v18 = (unsigned long long)v16;
        unsigned long long v19;
        v19 = v18 * 4ull;
        unsigned long long v20;
        v20 = 8ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_2(v21);
        bool v23;
        v23 = 0l <= v16;
        bool v25;
        if (v23){
            bool v24;
            v24 = v16 < 2l;
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
        v15.v[v16] = v22;
        v16 += 1l ;
    }
    long * v27;
    v27 = (long *)(v0+16ull);
    long v28;
    v28 = v27[0l];
    static_array<long,2l> v29;
    long v30;
    v30 = 0l;
    while (while_method_0(v30)){
        unsigned long long v32;
        v32 = (unsigned long long)v30;
        unsigned long long v33;
        v33 = v32 * 4ull;
        unsigned long long v34;
        v34 = 20ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_2(v35);
        bool v37;
        v37 = 0l <= v30;
        bool v39;
        if (v37){
            bool v38;
            v38 = v30 < 2l;
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
        v29.v[v30] = v36;
        v30 += 1l ;
    }
    long v41;
    v41 = f_25(v0);
    unsigned char * v42;
    v42 = (unsigned char *)(v0+32ull);
    US6 v51;
    switch (v41) {
        case 0: {
            static_array<unsigned char,3l> v44;
            v44 = f_26(v42);
            v51 = US6_0(v44);
            break;
        }
        case 1: {
            f_4(v42);
            v51 = US6_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v47;
            v47 = f_27(v42);
            v51 = US6_2(v47);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v49;
            v49 = f_28(v42);
            v51 = US6_3(v49);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple6(v2, v3, v15, v28, v29, v51);
}
__device__ long f_30(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+40ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple7 f_29(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<static_array<unsigned char,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 2ull;
        unsigned long long v8;
        v8 = 4ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<unsigned char,2l> v10;
        v10 = f_24(v9);
        bool v11;
        v11 = 0l <= v4;
        bool v13;
        if (v11){
            bool v12;
            v12 = v4 < 2l;
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
        v3.v[v4] = v10;
        v4 += 1l ;
    }
    static_array<long,2l> v15;
    long v16;
    v16 = 0l;
    while (while_method_0(v16)){
        unsigned long long v18;
        v18 = (unsigned long long)v16;
        unsigned long long v19;
        v19 = v18 * 4ull;
        unsigned long long v20;
        v20 = 8ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_2(v21);
        bool v23;
        v23 = 0l <= v16;
        bool v25;
        if (v23){
            bool v24;
            v24 = v16 < 2l;
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
        v15.v[v16] = v22;
        v16 += 1l ;
    }
    long * v27;
    v27 = (long *)(v0+16ull);
    long v28;
    v28 = v27[0l];
    static_array<long,2l> v29;
    long v30;
    v30 = 0l;
    while (while_method_0(v30)){
        unsigned long long v32;
        v32 = (unsigned long long)v30;
        unsigned long long v33;
        v33 = v32 * 4ull;
        unsigned long long v34;
        v34 = 20ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_2(v35);
        bool v37;
        v37 = 0l <= v30;
        bool v39;
        if (v37){
            bool v38;
            v38 = v30 < 2l;
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
        v29.v[v30] = v36;
        v30 += 1l ;
    }
    long v41;
    v41 = f_25(v0);
    unsigned char * v42;
    v42 = (unsigned char *)(v0+32ull);
    US6 v51;
    switch (v41) {
        case 0: {
            static_array<unsigned char,3l> v44;
            v44 = f_26(v42);
            v51 = US6_0(v44);
            break;
        }
        case 1: {
            f_4(v42);
            v51 = US6_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v47;
            v47 = f_27(v42);
            v51 = US6_2(v47);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v49;
            v49 = f_28(v42);
            v51 = US6_3(v49);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v52;
    v52 = f_30(v0);
    unsigned char * v53;
    v53 = (unsigned char *)(v0+44ull);
    US1 v59;
    switch (v52) {
        case 0: {
            f_4(v53);
            v59 = US1_0();
            break;
        }
        case 1: {
            f_4(v53);
            v59 = US1_1();
            break;
        }
        case 2: {
            long v57;
            v57 = f_2(v53);
            v59 = US1_2(v57);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple7(v2, v3, v15, v28, v29, v51, v59);
}
__device__ US5 f_22(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; static_array<static_array<unsigned char,2l>,2l> v5; static_array<long,2l> v6; long v7; static_array<long,2l> v8; US6 v9;
            Tuple6 tmp6 = f_23(v2);
            v4 = tmp6.v0; v5 = tmp6.v1; v6 = tmp6.v2; v7 = tmp6.v3; v8 = tmp6.v4; v9 = tmp6.v5;
            return US5_0(v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: {
            long v11; static_array<static_array<unsigned char,2l>,2l> v12; static_array<long,2l> v13; long v14; static_array<long,2l> v15; US6 v16;
            Tuple6 tmp7 = f_23(v2);
            v11 = tmp7.v0; v12 = tmp7.v1; v13 = tmp7.v2; v14 = tmp7.v3; v15 = tmp7.v4; v16 = tmp7.v5;
            return US5_1(v11, v12, v13, v14, v15, v16);
            break;
        }
        case 2: {
            f_4(v2);
            return US5_2();
            break;
        }
        case 3: {
            long v19; static_array<static_array<unsigned char,2l>,2l> v20; static_array<long,2l> v21; long v22; static_array<long,2l> v23; US6 v24;
            Tuple6 tmp8 = f_23(v2);
            v19 = tmp8.v0; v20 = tmp8.v1; v21 = tmp8.v2; v22 = tmp8.v3; v23 = tmp8.v4; v24 = tmp8.v5;
            return US5_3(v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: {
            long v26; static_array<static_array<unsigned char,2l>,2l> v27; static_array<long,2l> v28; long v29; static_array<long,2l> v30; US6 v31;
            Tuple6 tmp9 = f_23(v2);
            v26 = tmp9.v0; v27 = tmp9.v1; v28 = tmp9.v2; v29 = tmp9.v3; v30 = tmp9.v4; v31 = tmp9.v5;
            return US5_4(v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: {
            long v33; static_array<static_array<unsigned char,2l>,2l> v34; static_array<long,2l> v35; long v36; static_array<long,2l> v37; US6 v38; US1 v39;
            Tuple7 tmp10 = f_29(v2);
            v33 = tmp10.v0; v34 = tmp10.v1; v35 = tmp10.v2; v36 = tmp10.v3; v37 = tmp10.v4; v38 = tmp10.v5; v39 = tmp10.v6;
            return US5_5(v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: {
            long v41; static_array<static_array<unsigned char,2l>,2l> v42; static_array<long,2l> v43; long v44; static_array<long,2l> v45; US6 v46;
            Tuple6 tmp11 = f_23(v2);
            v41 = tmp11.v0; v42 = tmp11.v1; v43 = tmp11.v2; v44 = tmp11.v3; v45 = tmp11.v4; v46 = tmp11.v5;
            return US5_6(v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: {
            long v48; static_array<static_array<unsigned char,2l>,2l> v49; static_array<long,2l> v50; long v51; static_array<long,2l> v52; US6 v53;
            Tuple6 tmp12 = f_23(v2);
            v48 = tmp12.v0; v49 = tmp12.v1; v50 = tmp12.v2; v51 = tmp12.v3; v52 = tmp12.v4; v53 = tmp12.v5;
            return US5_7(v48, v49, v50, v51, v52, v53);
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
    v1 = (long *)(v0+6248ull);
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
        v29 = 6240ull + v28;
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
    v37 = (unsigned char *)(v0+6256ull);
    US7 v54;
    switch (v36) {
        case 0: {
            f_4(v37);
            v54 = US7_0();
            break;
        }
        case 1: {
            long v40; static_array<static_array<unsigned char,2l>,2l> v41; static_array<long,2l> v42; long v43; static_array<long,2l> v44; US6 v45;
            Tuple6 tmp13 = f_23(v37);
            v40 = tmp13.v0; v41 = tmp13.v1; v42 = tmp13.v2; v43 = tmp13.v3; v44 = tmp13.v4; v45 = tmp13.v5;
            v54 = US7_1(v40, v41, v42, v43, v44, v45);
            break;
        }
        case 2: {
            long v47; static_array<static_array<unsigned char,2l>,2l> v48; static_array<long,2l> v49; long v50; static_array<long,2l> v51; US6 v52;
            Tuple6 tmp14 = f_23(v37);
            v47 = tmp14.v0; v48 = tmp14.v1; v49 = tmp14.v2; v50 = tmp14.v3; v51 = tmp14.v4; v52 = tmp14.v5;
            v54 = US7_2(v47, v48, v49, v50, v51, v52);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v1, v2, v23, v24, v54);
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
__device__ bool player_can_act_39(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5){
    long v6;
    v6 = v3 % 2l;
    bool v7;
    v7 = 0l <= v6;
    bool v9;
    if (v7){
        bool v8;
        v8 = v6 < 2l;
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
    long v11;
    v11 = v4.v[v6];
    bool v12;
    v12 = v11 > 0l;
    bool v14;
    if (v7){
        bool v13;
        v13 = v6 < 2l;
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
    long v16;
    v16 = v2.v[v6];
    long v17;
    v17 = v2.v[0l];
    long v18; long v19;
    Tuple2 tmp20 = Tuple2(1l, v17);
    v18 = tmp20.v0; v19 = tmp20.v1;
    while (while_method_0(v18)){
        bool v21;
        v21 = 0l <= v18;
        bool v23;
        if (v21){
            bool v22;
            v22 = v18 < 2l;
            v23 = v22;
        } else {
            v23 = false;
        }
        bool v24;
        v24 = v23 == false;
        if (v24){
            assert("The read index needs to be in range for the static array." && v23);
        } else {
        }
        long v25;
        v25 = v2.v[v18];
        bool v26;
        v26 = v19 >= v25;
        long v27;
        if (v26){
            v27 = v19;
        } else {
            v27 = v25;
        }
        v19 = v27;
        v18 += 1l ;
    }
    bool v28;
    v28 = v16 < v19;
    if (v12){
        if (v28){
            return true;
        } else {
            bool v29;
            v29 = v6 < 2l;
            return v29;
        }
    } else {
        return false;
    }
}
__device__ US5 go_next_street_40(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5){
    switch (v5.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v7 = v5.v.case0.v0;
            return US5_7(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 1: { // Preflop
            return US5_0(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v11 = v5.v.case2.v0;
            return US5_6(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v9 = v5.v.case3.v0;
            return US5_3(v0, v1, v2, v3, v4, v5);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ US5 try_round_38(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US6 v5){
    long v6;
    v6 = v3 + 1l;
    bool v7;
    v7 = player_can_act_39(v0, v1, v2, v3, v4, v5);
    if (v7){
        return US5_4(v0, v1, v2, v3, v4, v5);
    } else {
        bool v9;
        v9 = player_can_act_39(v0, v1, v2, v6, v4, v5);
        if (v9){
            return US5_4(v0, v1, v2, v6, v4, v5);
        } else {
            return go_next_street_40(v0, v1, v2, v3, v4, v5);
        }
    }
}
__device__ Tuple13 draw_cards_41(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,2l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp21 = Tuple11(0l, v1);
    v3 = tmp21.v0; v4 = tmp21.v1;
    while (while_method_0(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple12 tmp22 = draw_card_35(v0, v4);
        v6 = tmp22.v0; v7 = tmp22.v1;
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
__device__ Tuple14 draw_cards_42(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,1l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp25 = Tuple11(0l, v1);
    v3 = tmp25.v0; v4 = tmp25.v1;
    while (while_method_6(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple12 tmp26 = draw_card_35(v0, v4);
        v6 = tmp26.v0; v7 = tmp26.v1;
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
__device__ static_array_list<unsigned char,5l,long> get_community_cards_43(US6 v0, static_array<unsigned char,1l> v1){
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
__device__ long loop_46(static_array<float,8l> v0, float v1, long v2){
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
            return loop_46(v0, v1, v9);
        }
    } else {
        return 7l;
    }
}
__device__ long sample_discrete__45(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1){
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
    return loop_46(v2, v35, v36);
}
__device__ US1 sample_discrete_44(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1){
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
        Tuple15 tmp30 = v0.v[v3];
        v9 = tmp30.v0; v10 = tmp30.v1;
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
    v14 = sample_discrete__45(v2, v1);
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
    Tuple15 tmp31 = v0.v[v14];
    v19 = tmp31.v0; v20 = tmp31.v1;
    return v19;
}
__device__ void write_48(long v0){
    const char * v1;
    v1 = "%d";
    printf(v1,v0);
    return ;
}
__device__ void write_47(static_array<long,2l> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        bool v4;
        v4 = 0l <= v2;
        bool v6;
        if (v4){
            bool v5;
            v5 = v2 < 2l;
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
        long v8;
        v8 = v0.v[v2];
        write_48(v8);
        long v9;
        v9 = v2 + 1l;
        bool v10;
        v10 = v9 < 2l;
        if (v10){
            const char * v11;
            v11 = "; ";
            write_0(v11);
        } else {
        }
        v2 += 1l ;
    }
    const char * v12;
    v12 = "]";
    return write_0(v12);
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
__device__ Tuple0 score_49(static_array<unsigned char,7l> v0){
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
    Tuple16 tmp36 = Tuple16(true, 1l);
    v13 = tmp36.v0; v14 = tmp36.v1;
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
            Tuple17 tmp37 = Tuple17(v16, v20, v16);
            v25 = tmp37.v0; v26 = tmp37.v1; v27 = tmp37.v2;
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
    Tuple18 tmp38 = Tuple18(0l, 0l, 12u);
    v128 = tmp38.v0; v129 = tmp38.v1; v130 = tmp38.v2;
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
    Tuple18 tmp39 = Tuple18(0l, 0l, 12u);
    v213 = tmp39.v0; v214 = tmp39.v1; v215 = tmp39.v2;
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
                    Tuple19 tmp40 = Tuple19(0l, v299);
                    v300 = tmp40.v0; v301 = tmp40.v1;
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
    Tuple18 tmp41 = Tuple18(0l, 0l, 12u);
    v333 = tmp41.v0; v334 = tmp41.v1; v335 = tmp41.v2;
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
                    Tuple19 tmp42 = Tuple19(0l, v419);
                    v420 = tmp42.v0; v421 = tmp42.v1;
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
    Tuple18 tmp43 = Tuple18(0l, 0l, 12u);
    v453 = tmp43.v0; v454 = tmp43.v1; v455 = tmp43.v2;
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
                    Tuple19 tmp44 = Tuple19(0l, v539);
                    v540 = tmp44.v0; v541 = tmp44.v1;
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
            Tuple20 tmp45 = Tuple20(0l, 0l, 0l, 12u);
            v575 = tmp45.v0; v576 = tmp45.v1; v577 = tmp45.v2; v578 = tmp45.v3;
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
                    Tuple20 tmp46 = Tuple20(0l, 0l, 0l, 12u);
                    v663 = tmp46.v0; v664 = tmp46.v1; v665 = tmp46.v2; v666 = tmp46.v3;
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
                            Tuple20 tmp47 = Tuple20(0l, 0l, 0l, 12u);
                            v712 = tmp47.v0; v713 = tmp47.v1; v714 = tmp47.v2; v715 = tmp47.v3;
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
                            Tuple2 tmp48 = Tuple2(0l, 0l);
                            v791 = tmp48.v0; v792 = tmp48.v1;
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
                            Tuple2 tmp49 = Tuple2(0l, 0l);
                            v816 = tmp49.v0; v817 = tmp49.v1;
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
                                            Tuple19 tmp50 = Tuple19(0l, v842);
                                            v843 = tmp50.v0; v844 = tmp50.v1;
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
                            Tuple2 tmp51 = Tuple2(0l, 0l);
                            v876 = tmp51.v0; v877 = tmp51.v1;
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
                                            Tuple19 tmp52 = Tuple19(0l, v902);
                                            v903 = tmp52.v0; v904 = tmp52.v1;
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
                            Tuple2 tmp53 = Tuple2(0l, 0l);
                            v936 = tmp53.v0; v937 = tmp53.v1;
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
                                            Tuple19 tmp54 = Tuple19(0l, v962);
                                            v963 = tmp54.v0; v964 = tmp54.v1;
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
                                    Tuple18 tmp55 = Tuple18(0l, 0l, 12u);
                                    v997 = tmp55.v0; v998 = tmp55.v1; v999 = tmp55.v2;
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
                                            Tuple20 tmp56 = Tuple20(0l, 0l, 0l, 12u);
                                            v1044 = tmp56.v0; v1045 = tmp56.v1; v1046 = tmp56.v2; v1047 = tmp56.v3;
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
                                                    Tuple20 tmp57 = Tuple20(0l, 0l, 0l, 12u);
                                                    v1132 = tmp57.v0; v1133 = tmp57.v1; v1134 = tmp57.v2; v1135 = tmp57.v3;
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
                                                            Tuple20 tmp58 = Tuple20(0l, 0l, 0l, 12u);
                                                            v1181 = tmp58.v0; v1182 = tmp58.v1; v1183 = tmp58.v2; v1184 = tmp58.v3;
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
                                                            Tuple20 tmp59 = Tuple20(0l, 0l, 0l, 12u);
                                                            v1284 = tmp59.v0; v1285 = tmp59.v1; v1286 = tmp59.v2; v1287 = tmp59.v3;
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
        bool v775; US5 v776;
        switch (v8.tag) {
            case 0: { // G_Flop
                long v599 = v8.v.case0.v0; static_array<static_array<unsigned char,2l>,2l> v600 = v8.v.case0.v1; static_array<long,2l> v601 = v8.v.case0.v2; long v602 = v8.v.case0.v3; static_array<long,2l> v603 = v8.v.case0.v4; US6 v604 = v8.v.case0.v5;
                static_array<unsigned char,3l> v605; unsigned long long v606;
                Tuple10 tmp19 = draw_cards_34(v2, v6);
                v605 = tmp19.v0; v606 = tmp19.v1;
                v0 = v606;
                static_array_list<unsigned char,5l,long> v607;
                v607 = get_community_cards_37(v604, v605);
                long v608;
                v608 = v5.length;
                bool v609;
                v609 = v608 < 128l;
                bool v610;
                v610 = v609 == false;
                if (v610){
                    assert("The length has to be less than the maximum length of the array." && v609);
                } else {
                }
                long v611;
                v611 = v608 + 1l;
                v5.length = v611;
                bool v612;
                v612 = 0l <= v608;
                bool v615;
                if (v612){
                    long v613;
                    v613 = v5.length;
                    bool v614;
                    v614 = v608 < v613;
                    v615 = v614;
                } else {
                    v615 = false;
                }
                bool v616;
                v616 = v615 == false;
                if (v616){
                    assert("The set index needs to be in range for the static array list." && v615);
                } else {
                }
                US3 v617;
                v617 = US3_0(v607);
                v5.v[v608] = v617;
                US6 v620;
                switch (v604.tag) {
                    case 1: { // Preflop
                        v620 = US6_0(v605);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in flop.");
                        asm("exit;");
                    }
                }
                long v621;
                v621 = 0l;
                US5 v622;
                v622 = try_round_38(v599, v600, v601, v621, v603, v620);
                v775 = true; v776 = v622;
                break;
            }
            case 1: { // G_Fold
                long v10 = v8.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v11 = v8.v.case1.v1; static_array<long,2l> v12 = v8.v.case1.v2; long v13 = v8.v.case1.v3; static_array<long,2l> v14 = v8.v.case1.v4; US6 v15 = v8.v.case1.v5;
                long v16;
                v16 = v13 % 2l;
                bool v17;
                v17 = 0l <= v16;
                bool v19;
                if (v17){
                    bool v18;
                    v18 = v16 < 2l;
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
                v21 = v12.v[v16];
                long v22;
                v22 = v13 + 1l;
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
                v775 = false; v776 = v8;
                break;
            }
            case 2: { // G_Preflop
                static_array<unsigned char,2l> v719; unsigned long long v720;
                Tuple13 tmp23 = draw_cards_41(v2, v6);
                v719 = tmp23.v0; v720 = tmp23.v1;
                v0 = v720;
                static_array<unsigned char,2l> v721; unsigned long long v722;
                Tuple13 tmp24 = draw_cards_41(v2, v6);
                v721 = tmp24.v0; v722 = tmp24.v1;
                v0 = v722;
                long v723;
                v723 = v5.length;
                bool v724;
                v724 = v723 < 128l;
                bool v725;
                v725 = v724 == false;
                if (v725){
                    assert("The length has to be less than the maximum length of the array." && v724);
                } else {
                }
                long v726;
                v726 = v723 + 1l;
                v5.length = v726;
                bool v727;
                v727 = 0l <= v723;
                bool v730;
                if (v727){
                    long v728;
                    v728 = v5.length;
                    bool v729;
                    v729 = v723 < v728;
                    v730 = v729;
                } else {
                    v730 = false;
                }
                bool v731;
                v731 = v730 == false;
                if (v731){
                    assert("The set index needs to be in range for the static array list." && v730);
                } else {
                }
                US3 v732;
                v732 = US3_3(0l, v719);
                v5.v[v723] = v732;
                long v733;
                v733 = v5.length;
                bool v734;
                v734 = v733 < 128l;
                bool v735;
                v735 = v734 == false;
                if (v735){
                    assert("The length has to be less than the maximum length of the array." && v734);
                } else {
                }
                long v736;
                v736 = v733 + 1l;
                v5.length = v736;
                bool v737;
                v737 = 0l <= v733;
                bool v740;
                if (v737){
                    long v738;
                    v738 = v5.length;
                    bool v739;
                    v739 = v733 < v738;
                    v740 = v739;
                } else {
                    v740 = false;
                }
                bool v741;
                v741 = v740 == false;
                if (v741){
                    assert("The set index needs to be in range for the static array list." && v740);
                } else {
                }
                US3 v742;
                v742 = US3_3(1l, v721);
                v5.v[v733] = v742;
                static_array<static_array<unsigned char,2l>,2l> v743;
                v743.v[0l] = v719;
                v743.v[1l] = v721;
                static_array<long,2l> v744;
                v744.v[0l] = 2l;
                v744.v[1l] = 1l;
                static_array<long,2l> v745;
                long v746;
                v746 = 0l;
                while (while_method_0(v746)){
                    bool v748;
                    v748 = 0l <= v746;
                    bool v750;
                    if (v748){
                        bool v749;
                        v749 = v746 < 2l;
                        v750 = v749;
                    } else {
                        v750 = false;
                    }
                    bool v751;
                    v751 = v750 == false;
                    if (v751){
                        assert("The read index needs to be in range for the static array." && v750);
                    } else {
                    }
                    long v752;
                    v752 = v744.v[v746];
                    long v753;
                    v753 = 100l - v752;
                    bool v755;
                    if (v748){
                        bool v754;
                        v754 = v746 < 2l;
                        v755 = v754;
                    } else {
                        v755 = false;
                    }
                    bool v756;
                    v756 = v755 == false;
                    if (v756){
                        assert("The read index needs to be in range for the static array." && v755);
                    } else {
                    }
                    v745.v[v746] = v753;
                    v746 += 1l ;
                }
                long v757;
                v757 = 2l;
                long v758;
                v758 = 0l;
                US6 v759;
                v759 = US6_1();
                US5 v760;
                v760 = try_round_38(v757, v743, v744, v758, v745, v759);
                v775 = true; v776 = v760;
                break;
            }
            case 3: { // G_River
                long v671 = v8.v.case3.v0; static_array<static_array<unsigned char,2l>,2l> v672 = v8.v.case3.v1; static_array<long,2l> v673 = v8.v.case3.v2; long v674 = v8.v.case3.v3; static_array<long,2l> v675 = v8.v.case3.v4; US6 v676 = v8.v.case3.v5;
                static_array<unsigned char,1l> v677; unsigned long long v678;
                Tuple14 tmp27 = draw_cards_42(v2, v6);
                v677 = tmp27.v0; v678 = tmp27.v1;
                v0 = v678;
                static_array_list<unsigned char,5l,long> v679;
                v679 = get_community_cards_43(v676, v677);
                long v680;
                v680 = v5.length;
                bool v681;
                v681 = v680 < 128l;
                bool v682;
                v682 = v681 == false;
                if (v682){
                    assert("The length has to be less than the maximum length of the array." && v681);
                } else {
                }
                long v683;
                v683 = v680 + 1l;
                v5.length = v683;
                bool v684;
                v684 = 0l <= v680;
                bool v687;
                if (v684){
                    long v685;
                    v685 = v5.length;
                    bool v686;
                    v686 = v680 < v685;
                    v687 = v686;
                } else {
                    v687 = false;
                }
                bool v688;
                v688 = v687 == false;
                if (v688){
                    assert("The set index needs to be in range for the static array list." && v687);
                } else {
                }
                US3 v689;
                v689 = US3_0(v679);
                v5.v[v680] = v689;
                US6 v716;
                switch (v676.tag) {
                    case 3: { // Turn
                        static_array<unsigned char,4l> v690 = v676.v.case3.v0;
                        static_array<unsigned char,5l> v691;
                        long v692;
                        v692 = 0l;
                        while (while_method_4(v692)){
                            bool v694;
                            v694 = 0l <= v692;
                            bool v696;
                            if (v694){
                                bool v695;
                                v695 = v692 < 4l;
                                v696 = v695;
                            } else {
                                v696 = false;
                            }
                            bool v697;
                            v697 = v696 == false;
                            if (v697){
                                assert("The read index needs to be in range for the static array." && v696);
                            } else {
                            }
                            unsigned char v698;
                            v698 = v690.v[v692];
                            bool v700;
                            if (v694){
                                bool v699;
                                v699 = v692 < 5l;
                                v700 = v699;
                            } else {
                                v700 = false;
                            }
                            bool v701;
                            v701 = v700 == false;
                            if (v701){
                                assert("The read index needs to be in range for the static array." && v700);
                            } else {
                            }
                            v691.v[v692] = v698;
                            v692 += 1l ;
                        }
                        long v702;
                        v702 = 0l;
                        while (while_method_6(v702)){
                            bool v704;
                            v704 = 0l <= v702;
                            bool v706;
                            if (v704){
                                bool v705;
                                v705 = v702 < 1l;
                                v706 = v705;
                            } else {
                                v706 = false;
                            }
                            bool v707;
                            v707 = v706 == false;
                            if (v707){
                                assert("The read index needs to be in range for the static array." && v706);
                            } else {
                            }
                            unsigned char v708;
                            v708 = v677.v[v702];
                            long v709;
                            v709 = 4l + v702;
                            bool v710;
                            v710 = 0l <= v709;
                            bool v712;
                            if (v710){
                                bool v711;
                                v711 = v709 < 5l;
                                v712 = v711;
                            } else {
                                v712 = false;
                            }
                            bool v713;
                            v713 = v712 == false;
                            if (v713){
                                assert("The read index needs to be in range for the static array." && v712);
                            } else {
                            }
                            v691.v[v709] = v708;
                            v702 += 1l ;
                        }
                        v716 = US6_2(v691);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in river.");
                        asm("exit;");
                    }
                }
                long v717;
                v717 = 0l;
                US5 v718;
                v718 = try_round_38(v671, v672, v673, v717, v675, v716);
                v775 = true; v776 = v718;
                break;
            }
            case 4: { // G_Round
                long v146 = v8.v.case4.v0; static_array<static_array<unsigned char,2l>,2l> v147 = v8.v.case4.v1; static_array<long,2l> v148 = v8.v.case4.v2; long v149 = v8.v.case4.v3; static_array<long,2l> v150 = v8.v.case4.v4; US6 v151 = v8.v.case4.v5;
                long v152;
                v152 = v149 % 2l;
                bool v153;
                v153 = 0l <= v152;
                bool v155;
                if (v153){
                    bool v154;
                    v154 = v152 < 2l;
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
                v157 = v3.v[v152];
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
                            v165 = v150.v[v159];
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
                            v169 = v148.v[v159];
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
                        v174 = v148.v[0l];
                        long v175; long v176;
                        Tuple2 tmp28 = Tuple2(1l, v174);
                        v175 = tmp28.v0; v176 = tmp28.v1;
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
                            v182 = v148.v[v175];
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
                        bool v186;
                        if (v153){
                            bool v185;
                            v185 = v152 < 2l;
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
                        v188 = v158.v[v152];
                        bool v189;
                        v189 = v176 < v188;
                        long v190;
                        if (v189){
                            v190 = v176;
                        } else {
                            v190 = v188;
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
                            long v198;
                            v198 = v148.v[v192];
                            bool v199;
                            v199 = v152 == v192;
                            long v200;
                            if (v199){
                                v200 = v190;
                            } else {
                                v200 = v198;
                            }
                            bool v202;
                            if (v194){
                                bool v201;
                                v201 = v192 < 2l;
                                v202 = v201;
                            } else {
                                v202 = false;
                            }
                            bool v203;
                            v203 = v202 == false;
                            if (v203){
                                assert("The read index needs to be in range for the static array." && v202);
                            } else {
                            }
                            v191.v[v192] = v200;
                            v192 += 1l ;
                        }
                        static_array<long,2l> v204;
                        long v205;
                        v205 = 0l;
                        while (while_method_0(v205)){
                            bool v207;
                            v207 = 0l <= v205;
                            bool v209;
                            if (v207){
                                bool v208;
                                v208 = v205 < 2l;
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
                            v211 = v158.v[v205];
                            bool v213;
                            if (v207){
                                bool v212;
                                v212 = v205 < 2l;
                                v213 = v212;
                            } else {
                                v213 = false;
                            }
                            bool v214;
                            v214 = v213 == false;
                            if (v214){
                                assert("The read index needs to be in range for the static array." && v213);
                            } else {
                            }
                            long v215;
                            v215 = v191.v[v205];
                            long v216;
                            v216 = v211 - v215;
                            bool v218;
                            if (v207){
                                bool v217;
                                v217 = v205 < 2l;
                                v218 = v217;
                            } else {
                                v218 = false;
                            }
                            bool v219;
                            v219 = v218 == false;
                            if (v219){
                                assert("The read index needs to be in range for the static array." && v218);
                            } else {
                            }
                            v204.v[v205] = v216;
                            v205 += 1l ;
                        }
                        long v220;
                        v220 = v191.v[0l];
                        long v221; long v222;
                        Tuple2 tmp29 = Tuple2(1l, v220);
                        v221 = tmp29.v0; v222 = tmp29.v1;
                        while (while_method_0(v221)){
                            bool v224;
                            v224 = 0l <= v221;
                            bool v226;
                            if (v224){
                                bool v225;
                                v225 = v221 < 2l;
                                v226 = v225;
                            } else {
                                v226 = false;
                            }
                            bool v227;
                            v227 = v226 == false;
                            if (v227){
                                assert("The read index needs to be in range for the static array." && v226);
                            } else {
                            }
                            long v228;
                            v228 = v191.v[v221];
                            long v229;
                            v229 = v222 + v228;
                            v222 = v229;
                            v221 += 1l ;
                        }
                        bool v231;
                        if (v153){
                            bool v230;
                            v230 = v152 < 2l;
                            v231 = v230;
                        } else {
                            v231 = false;
                        }
                        bool v232;
                        v232 = v231 == false;
                        if (v232){
                            assert("The read index needs to be in range for the static array." && v231);
                        } else {
                        }
                        long v233;
                        v233 = v148.v[v152];
                        bool v234;
                        v234 = v233 < v176;
                        float v235;
                        if (v234){
                            v235 = 1.0f;
                        } else {
                            v235 = 0.0f;
                        }
                        long v236;
                        v236 = v222 / 4l;
                        bool v238;
                        if (v153){
                            bool v237;
                            v237 = v152 < 2l;
                            v238 = v237;
                        } else {
                            v238 = false;
                        }
                        bool v239;
                        v239 = v238 == false;
                        if (v239){
                            assert("The read index needs to be in range for the static array." && v238);
                        } else {
                        }
                        long v240;
                        v240 = v204.v[v152];
                        bool v241;
                        v241 = v236 <= v240;
                        float v242;
                        if (v241){
                            v242 = 1.0f;
                        } else {
                            v242 = 0.0f;
                        }
                        long v243;
                        v243 = v222 / 3l;
                        bool v245;
                        if (v153){
                            bool v244;
                            v244 = v152 < 2l;
                            v245 = v244;
                        } else {
                            v245 = false;
                        }
                        bool v246;
                        v246 = v245 == false;
                        if (v246){
                            assert("The read index needs to be in range for the static array." && v245);
                        } else {
                        }
                        long v247;
                        v247 = v204.v[v152];
                        bool v248;
                        v248 = v243 <= v247;
                        float v249;
                        if (v248){
                            v249 = 1.0f;
                        } else {
                            v249 = 0.0f;
                        }
                        long v250;
                        v250 = v222 / 2l;
                        bool v252;
                        if (v153){
                            bool v251;
                            v251 = v152 < 2l;
                            v252 = v251;
                        } else {
                            v252 = false;
                        }
                        bool v253;
                        v253 = v252 == false;
                        if (v253){
                            assert("The read index needs to be in range for the static array." && v252);
                        } else {
                        }
                        long v254;
                        v254 = v204.v[v152];
                        bool v255;
                        v255 = v250 <= v254;
                        float v256;
                        if (v255){
                            v256 = 1.0f;
                        } else {
                            v256 = 0.0f;
                        }
                        bool v258;
                        if (v153){
                            bool v257;
                            v257 = v152 < 2l;
                            v258 = v257;
                        } else {
                            v258 = false;
                        }
                        bool v259;
                        v259 = v258 == false;
                        if (v259){
                            assert("The read index needs to be in range for the static array." && v258);
                        } else {
                        }
                        long v260;
                        v260 = v204.v[v152];
                        bool v261;
                        v261 = v222 <= v260;
                        float v262;
                        if (v261){
                            v262 = 1.0f;
                        } else {
                            v262 = 0.0f;
                        }
                        long v263;
                        v263 = v222 * 3l;
                        long v264;
                        v264 = v263 / 2l;
                        bool v266;
                        if (v153){
                            bool v265;
                            v265 = v152 < 2l;
                            v266 = v265;
                        } else {
                            v266 = false;
                        }
                        bool v267;
                        v267 = v266 == false;
                        if (v267){
                            assert("The read index needs to be in range for the static array." && v266);
                        } else {
                        }
                        long v268;
                        v268 = v204.v[v152];
                        bool v269;
                        v269 = v264 <= v268;
                        float v270;
                        if (v269){
                            v270 = 1.0f;
                        } else {
                            v270 = 0.0f;
                        }
                        bool v272;
                        if (v153){
                            bool v271;
                            v271 = v152 < 2l;
                            v272 = v271;
                        } else {
                            v272 = false;
                        }
                        bool v273;
                        v273 = v272 == false;
                        if (v273){
                            assert("The read index needs to be in range for the static array." && v272);
                        } else {
                        }
                        long v274;
                        v274 = v204.v[v152];
                        bool v276;
                        if (v153){
                            bool v275;
                            v275 = v152 < 2l;
                            v276 = v275;
                        } else {
                            v276 = false;
                        }
                        bool v277;
                        v277 = v276 == false;
                        if (v277){
                            assert("The read index needs to be in range for the static array." && v276);
                        } else {
                        }
                        long v278;
                        v278 = v204.v[v152];
                        bool v279;
                        v279 = v274 <= v278;
                        float v280;
                        if (v279){
                            v280 = 1.0f;
                        } else {
                            v280 = 0.0f;
                        }
                        static_array<Tuple15,8l> v281;
                        US1 v282;
                        v282 = US1_1();
                        v281.v[0l] = Tuple15(v282, v235);
                        US1 v283;
                        v283 = US1_0();
                        v281.v[1l] = Tuple15(v283, 2.0f);
                        US1 v284;
                        v284 = US1_2(v236);
                        v281.v[2l] = Tuple15(v284, v242);
                        US1 v285;
                        v285 = US1_2(v243);
                        v281.v[3l] = Tuple15(v285, v249);
                        US1 v286;
                        v286 = US1_2(v250);
                        v281.v[4l] = Tuple15(v286, v256);
                        US1 v287;
                        v287 = US1_2(v222);
                        v281.v[5l] = Tuple15(v287, v262);
                        US1 v288;
                        v288 = US1_2(v264);
                        v281.v[6l] = Tuple15(v288, v270);
                        US1 v289;
                        v289 = US1_2(v274);
                        v281.v[7l] = Tuple15(v289, v280);
                        US1 v290;
                        v290 = sample_discrete_44(v281, v2);
                        long v291;
                        v291 = v5.length;
                        bool v292;
                        v292 = v291 < 128l;
                        bool v293;
                        v293 = v292 == false;
                        if (v293){
                            assert("The length has to be less than the maximum length of the array." && v292);
                        } else {
                        }
                        long v294;
                        v294 = v291 + 1l;
                        v5.length = v294;
                        bool v295;
                        v295 = 0l <= v291;
                        bool v298;
                        if (v295){
                            long v296;
                            v296 = v5.length;
                            bool v297;
                            v297 = v291 < v296;
                            v298 = v297;
                        } else {
                            v298 = false;
                        }
                        bool v299;
                        v299 = v298 == false;
                        if (v299){
                            assert("The set index needs to be in range for the static array list." && v298);
                        } else {
                        }
                        US3 v300;
                        v300 = US3_2(v152, v290);
                        v5.v[v291] = v300;
                        US5 v437;
                        switch (v290.tag) {
                            case 0: { // A_Call
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
                                    long v309;
                                    v309 = v150.v[v303];
                                    bool v311;
                                    if (v305){
                                        bool v310;
                                        v310 = v303 < 2l;
                                        v311 = v310;
                                    } else {
                                        v311 = false;
                                    }
                                    bool v312;
                                    v312 = v311 == false;
                                    if (v312){
                                        assert("The read index needs to be in range for the static array." && v311);
                                    } else {
                                    }
                                    long v313;
                                    v313 = v148.v[v303];
                                    long v314;
                                    v314 = v309 + v313;
                                    bool v316;
                                    if (v305){
                                        bool v315;
                                        v315 = v303 < 2l;
                                        v316 = v315;
                                    } else {
                                        v316 = false;
                                    }
                                    bool v317;
                                    v317 = v316 == false;
                                    if (v317){
                                        assert("The read index needs to be in range for the static array." && v316);
                                    } else {
                                    }
                                    v302.v[v303] = v314;
                                    v303 += 1l ;
                                }
                                long v318;
                                v318 = v148.v[0l];
                                long v319; long v320;
                                Tuple2 tmp32 = Tuple2(1l, v318);
                                v319 = tmp32.v0; v320 = tmp32.v1;
                                while (while_method_0(v319)){
                                    bool v322;
                                    v322 = 0l <= v319;
                                    bool v324;
                                    if (v322){
                                        bool v323;
                                        v323 = v319 < 2l;
                                        v324 = v323;
                                    } else {
                                        v324 = false;
                                    }
                                    bool v325;
                                    v325 = v324 == false;
                                    if (v325){
                                        assert("The read index needs to be in range for the static array." && v324);
                                    } else {
                                    }
                                    long v326;
                                    v326 = v148.v[v319];
                                    bool v327;
                                    v327 = v320 >= v326;
                                    long v328;
                                    if (v327){
                                        v328 = v320;
                                    } else {
                                        v328 = v326;
                                    }
                                    v320 = v328;
                                    v319 += 1l ;
                                }
                                bool v330;
                                if (v153){
                                    bool v329;
                                    v329 = v152 < 2l;
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
                                long v332;
                                v332 = v302.v[v152];
                                bool v333;
                                v333 = v320 < v332;
                                long v334;
                                if (v333){
                                    v334 = v320;
                                } else {
                                    v334 = v332;
                                }
                                static_array<long,2l> v335;
                                long v336;
                                v336 = 0l;
                                while (while_method_0(v336)){
                                    bool v338;
                                    v338 = 0l <= v336;
                                    bool v340;
                                    if (v338){
                                        bool v339;
                                        v339 = v336 < 2l;
                                        v340 = v339;
                                    } else {
                                        v340 = false;
                                    }
                                    bool v341;
                                    v341 = v340 == false;
                                    if (v341){
                                        assert("The read index needs to be in range for the static array." && v340);
                                    } else {
                                    }
                                    long v342;
                                    v342 = v148.v[v336];
                                    bool v343;
                                    v343 = v152 == v336;
                                    long v344;
                                    if (v343){
                                        v344 = v334;
                                    } else {
                                        v344 = v342;
                                    }
                                    bool v346;
                                    if (v338){
                                        bool v345;
                                        v345 = v336 < 2l;
                                        v346 = v345;
                                    } else {
                                        v346 = false;
                                    }
                                    bool v347;
                                    v347 = v346 == false;
                                    if (v347){
                                        assert("The read index needs to be in range for the static array." && v346);
                                    } else {
                                    }
                                    v335.v[v336] = v344;
                                    v336 += 1l ;
                                }
                                static_array<long,2l> v348;
                                long v349;
                                v349 = 0l;
                                while (while_method_0(v349)){
                                    bool v351;
                                    v351 = 0l <= v349;
                                    bool v353;
                                    if (v351){
                                        bool v352;
                                        v352 = v349 < 2l;
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
                                    long v355;
                                    v355 = v302.v[v349];
                                    bool v357;
                                    if (v351){
                                        bool v356;
                                        v356 = v349 < 2l;
                                        v357 = v356;
                                    } else {
                                        v357 = false;
                                    }
                                    bool v358;
                                    v358 = v357 == false;
                                    if (v358){
                                        assert("The read index needs to be in range for the static array." && v357);
                                    } else {
                                    }
                                    long v359;
                                    v359 = v335.v[v349];
                                    long v360;
                                    v360 = v355 - v359;
                                    bool v362;
                                    if (v351){
                                        bool v361;
                                        v361 = v349 < 2l;
                                        v362 = v361;
                                    } else {
                                        v362 = false;
                                    }
                                    bool v363;
                                    v363 = v362 == false;
                                    if (v363){
                                        assert("The read index needs to be in range for the static array." && v362);
                                    } else {
                                    }
                                    v348.v[v349] = v360;
                                    v349 += 1l ;
                                }
                                bool v364;
                                v364 = v152 < 2l;
                                if (v364){
                                    long v365;
                                    v365 = v149 + 1l;
                                    v437 = try_round_38(v146, v147, v335, v365, v348, v151);
                                } else {
                                    v437 = go_next_street_40(v146, v147, v335, v149, v348, v151);
                                }
                                break;
                            }
                            case 1: { // A_Fold
                                v437 = US5_1(v146, v147, v148, v149, v150, v151);
                                break;
                            }
                            case 2: { // A_Raise
                                long v369 = v290.v.case2.v0;
                                write_47(v148);
                                printf("\n");
                                write_47(v150);
                                printf("\n");
                                static_array<long,2l> v370;
                                long v371;
                                v371 = 0l;
                                while (while_method_0(v371)){
                                    bool v373;
                                    v373 = 0l <= v371;
                                    bool v375;
                                    if (v373){
                                        bool v374;
                                        v374 = v371 < 2l;
                                        v375 = v374;
                                    } else {
                                        v375 = false;
                                    }
                                    bool v376;
                                    v376 = v375 == false;
                                    if (v376){
                                        assert("The read index needs to be in range for the static array." && v375);
                                    } else {
                                    }
                                    long v377;
                                    v377 = v150.v[v371];
                                    bool v379;
                                    if (v373){
                                        bool v378;
                                        v378 = v371 < 2l;
                                        v379 = v378;
                                    } else {
                                        v379 = false;
                                    }
                                    bool v380;
                                    v380 = v379 == false;
                                    if (v380){
                                        assert("The read index needs to be in range for the static array." && v379);
                                    } else {
                                    }
                                    long v381;
                                    v381 = v148.v[v371];
                                    long v382;
                                    v382 = v377 + v381;
                                    bool v384;
                                    if (v373){
                                        bool v383;
                                        v383 = v371 < 2l;
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
                                    v370.v[v371] = v382;
                                    v371 += 1l ;
                                }
                                long v386;
                                v386 = v148.v[0l];
                                long v387; long v388;
                                Tuple2 tmp33 = Tuple2(1l, v386);
                                v387 = tmp33.v0; v388 = tmp33.v1;
                                while (while_method_0(v387)){
                                    bool v390;
                                    v390 = 0l <= v387;
                                    bool v392;
                                    if (v390){
                                        bool v391;
                                        v391 = v387 < 2l;
                                        v392 = v391;
                                    } else {
                                        v392 = false;
                                    }
                                    bool v393;
                                    v393 = v392 == false;
                                    if (v393){
                                        assert("The read index needs to be in range for the static array." && v392);
                                    } else {
                                    }
                                    long v394;
                                    v394 = v148.v[v387];
                                    bool v395;
                                    v395 = v388 >= v394;
                                    long v396;
                                    if (v395){
                                        v396 = v388;
                                    } else {
                                        v396 = v394;
                                    }
                                    v388 = v396;
                                    v387 += 1l ;
                                }
                                long v397;
                                v397 = v388 + v369;
                                bool v399;
                                if (v153){
                                    bool v398;
                                    v398 = v152 < 2l;
                                    v399 = v398;
                                } else {
                                    v399 = false;
                                }
                                bool v400;
                                v400 = v399 == false;
                                if (v400){
                                    assert("The read index needs to be in range for the static array." && v399);
                                } else {
                                }
                                long v401;
                                v401 = v370.v[v152];
                                bool v402;
                                v402 = v397 < v401;
                                long v403;
                                if (v402){
                                    v403 = v397;
                                } else {
                                    v403 = v401;
                                }
                                static_array<long,2l> v404;
                                long v405;
                                v405 = 0l;
                                while (while_method_0(v405)){
                                    bool v407;
                                    v407 = 0l <= v405;
                                    bool v409;
                                    if (v407){
                                        bool v408;
                                        v408 = v405 < 2l;
                                        v409 = v408;
                                    } else {
                                        v409 = false;
                                    }
                                    bool v410;
                                    v410 = v409 == false;
                                    if (v410){
                                        assert("The read index needs to be in range for the static array." && v409);
                                    } else {
                                    }
                                    long v411;
                                    v411 = v148.v[v405];
                                    bool v412;
                                    v412 = v152 == v405;
                                    long v413;
                                    if (v412){
                                        v413 = v403;
                                    } else {
                                        v413 = v411;
                                    }
                                    bool v415;
                                    if (v407){
                                        bool v414;
                                        v414 = v405 < 2l;
                                        v415 = v414;
                                    } else {
                                        v415 = false;
                                    }
                                    bool v416;
                                    v416 = v415 == false;
                                    if (v416){
                                        assert("The read index needs to be in range for the static array." && v415);
                                    } else {
                                    }
                                    v404.v[v405] = v413;
                                    v405 += 1l ;
                                }
                                static_array<long,2l> v417;
                                long v418;
                                v418 = 0l;
                                while (while_method_0(v418)){
                                    bool v420;
                                    v420 = 0l <= v418;
                                    bool v422;
                                    if (v420){
                                        bool v421;
                                        v421 = v418 < 2l;
                                        v422 = v421;
                                    } else {
                                        v422 = false;
                                    }
                                    bool v423;
                                    v423 = v422 == false;
                                    if (v423){
                                        assert("The read index needs to be in range for the static array." && v422);
                                    } else {
                                    }
                                    long v424;
                                    v424 = v370.v[v418];
                                    bool v426;
                                    if (v420){
                                        bool v425;
                                        v425 = v418 < 2l;
                                        v426 = v425;
                                    } else {
                                        v426 = false;
                                    }
                                    bool v427;
                                    v427 = v426 == false;
                                    if (v427){
                                        assert("The read index needs to be in range for the static array." && v426);
                                    } else {
                                    }
                                    long v428;
                                    v428 = v404.v[v418];
                                    long v429;
                                    v429 = v424 - v428;
                                    bool v431;
                                    if (v420){
                                        bool v430;
                                        v430 = v418 < 2l;
                                        v431 = v430;
                                    } else {
                                        v431 = false;
                                    }
                                    bool v432;
                                    v432 = v431 == false;
                                    if (v432){
                                        assert("The read index needs to be in range for the static array." && v431);
                                    } else {
                                    }
                                    v417.v[v418] = v429;
                                    v418 += 1l ;
                                }
                                write_47(v404);
                                printf("\n");
                                long v433;
                                v433 = v149 + 1l;
                                v437 = try_round_38(v146, v147, v404, v433, v417, v151);
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v775 = true; v776 = v437;
                        break;
                    }
                    case 1: { // Human
                        v775 = false; v776 = v8;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 5: { // G_Round'
                long v442 = v8.v.case5.v0; static_array<static_array<unsigned char,2l>,2l> v443 = v8.v.case5.v1; static_array<long,2l> v444 = v8.v.case5.v2; long v445 = v8.v.case5.v3; static_array<long,2l> v446 = v8.v.case5.v4; US6 v447 = v8.v.case5.v5; US1 v448 = v8.v.case5.v6;
                long v449;
                v449 = v445 % 2l;
                long v450;
                v450 = v5.length;
                bool v451;
                v451 = v450 < 128l;
                bool v452;
                v452 = v451 == false;
                if (v452){
                    assert("The length has to be less than the maximum length of the array." && v451);
                } else {
                }
                long v453;
                v453 = v450 + 1l;
                v5.length = v453;
                bool v454;
                v454 = 0l <= v450;
                bool v457;
                if (v454){
                    long v455;
                    v455 = v5.length;
                    bool v456;
                    v456 = v450 < v455;
                    v457 = v456;
                } else {
                    v457 = false;
                }
                bool v458;
                v458 = v457 == false;
                if (v458){
                    assert("The set index needs to be in range for the static array list." && v457);
                } else {
                }
                US3 v459;
                v459 = US3_2(v449, v448);
                v5.v[v450] = v459;
                US5 v598;
                switch (v448.tag) {
                    case 0: { // A_Call
                        static_array<long,2l> v461;
                        long v462;
                        v462 = 0l;
                        while (while_method_0(v462)){
                            bool v464;
                            v464 = 0l <= v462;
                            bool v466;
                            if (v464){
                                bool v465;
                                v465 = v462 < 2l;
                                v466 = v465;
                            } else {
                                v466 = false;
                            }
                            bool v467;
                            v467 = v466 == false;
                            if (v467){
                                assert("The read index needs to be in range for the static array." && v466);
                            } else {
                            }
                            long v468;
                            v468 = v446.v[v462];
                            bool v470;
                            if (v464){
                                bool v469;
                                v469 = v462 < 2l;
                                v470 = v469;
                            } else {
                                v470 = false;
                            }
                            bool v471;
                            v471 = v470 == false;
                            if (v471){
                                assert("The read index needs to be in range for the static array." && v470);
                            } else {
                            }
                            long v472;
                            v472 = v444.v[v462];
                            long v473;
                            v473 = v468 + v472;
                            bool v475;
                            if (v464){
                                bool v474;
                                v474 = v462 < 2l;
                                v475 = v474;
                            } else {
                                v475 = false;
                            }
                            bool v476;
                            v476 = v475 == false;
                            if (v476){
                                assert("The read index needs to be in range for the static array." && v475);
                            } else {
                            }
                            v461.v[v462] = v473;
                            v462 += 1l ;
                        }
                        long v477;
                        v477 = v444.v[0l];
                        long v478; long v479;
                        Tuple2 tmp34 = Tuple2(1l, v477);
                        v478 = tmp34.v0; v479 = tmp34.v1;
                        while (while_method_0(v478)){
                            bool v481;
                            v481 = 0l <= v478;
                            bool v483;
                            if (v481){
                                bool v482;
                                v482 = v478 < 2l;
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
                            v485 = v444.v[v478];
                            bool v486;
                            v486 = v479 >= v485;
                            long v487;
                            if (v486){
                                v487 = v479;
                            } else {
                                v487 = v485;
                            }
                            v479 = v487;
                            v478 += 1l ;
                        }
                        bool v488;
                        v488 = 0l <= v449;
                        bool v490;
                        if (v488){
                            bool v489;
                            v489 = v449 < 2l;
                            v490 = v489;
                        } else {
                            v490 = false;
                        }
                        bool v491;
                        v491 = v490 == false;
                        if (v491){
                            assert("The read index needs to be in range for the static array." && v490);
                        } else {
                        }
                        long v492;
                        v492 = v461.v[v449];
                        bool v493;
                        v493 = v479 < v492;
                        long v494;
                        if (v493){
                            v494 = v479;
                        } else {
                            v494 = v492;
                        }
                        static_array<long,2l> v495;
                        long v496;
                        v496 = 0l;
                        while (while_method_0(v496)){
                            bool v498;
                            v498 = 0l <= v496;
                            bool v500;
                            if (v498){
                                bool v499;
                                v499 = v496 < 2l;
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
                            v502 = v444.v[v496];
                            bool v503;
                            v503 = v449 == v496;
                            long v504;
                            if (v503){
                                v504 = v494;
                            } else {
                                v504 = v502;
                            }
                            bool v506;
                            if (v498){
                                bool v505;
                                v505 = v496 < 2l;
                                v506 = v505;
                            } else {
                                v506 = false;
                            }
                            bool v507;
                            v507 = v506 == false;
                            if (v507){
                                assert("The read index needs to be in range for the static array." && v506);
                            } else {
                            }
                            v495.v[v496] = v504;
                            v496 += 1l ;
                        }
                        static_array<long,2l> v508;
                        long v509;
                        v509 = 0l;
                        while (while_method_0(v509)){
                            bool v511;
                            v511 = 0l <= v509;
                            bool v513;
                            if (v511){
                                bool v512;
                                v512 = v509 < 2l;
                                v513 = v512;
                            } else {
                                v513 = false;
                            }
                            bool v514;
                            v514 = v513 == false;
                            if (v514){
                                assert("The read index needs to be in range for the static array." && v513);
                            } else {
                            }
                            long v515;
                            v515 = v461.v[v509];
                            bool v517;
                            if (v511){
                                bool v516;
                                v516 = v509 < 2l;
                                v517 = v516;
                            } else {
                                v517 = false;
                            }
                            bool v518;
                            v518 = v517 == false;
                            if (v518){
                                assert("The read index needs to be in range for the static array." && v517);
                            } else {
                            }
                            long v519;
                            v519 = v495.v[v509];
                            long v520;
                            v520 = v515 - v519;
                            bool v522;
                            if (v511){
                                bool v521;
                                v521 = v509 < 2l;
                                v522 = v521;
                            } else {
                                v522 = false;
                            }
                            bool v523;
                            v523 = v522 == false;
                            if (v523){
                                assert("The read index needs to be in range for the static array." && v522);
                            } else {
                            }
                            v508.v[v509] = v520;
                            v509 += 1l ;
                        }
                        bool v524;
                        v524 = v449 < 2l;
                        if (v524){
                            long v525;
                            v525 = v445 + 1l;
                            v598 = try_round_38(v442, v443, v495, v525, v508, v447);
                        } else {
                            v598 = go_next_street_40(v442, v443, v495, v445, v508, v447);
                        }
                        break;
                    }
                    case 1: { // A_Fold
                        v598 = US5_1(v442, v443, v444, v445, v446, v447);
                        break;
                    }
                    case 2: { // A_Raise
                        long v529 = v448.v.case2.v0;
                        write_47(v444);
                        printf("\n");
                        write_47(v446);
                        printf("\n");
                        static_array<long,2l> v530;
                        long v531;
                        v531 = 0l;
                        while (while_method_0(v531)){
                            bool v533;
                            v533 = 0l <= v531;
                            bool v535;
                            if (v533){
                                bool v534;
                                v534 = v531 < 2l;
                                v535 = v534;
                            } else {
                                v535 = false;
                            }
                            bool v536;
                            v536 = v535 == false;
                            if (v536){
                                assert("The read index needs to be in range for the static array." && v535);
                            } else {
                            }
                            long v537;
                            v537 = v446.v[v531];
                            bool v539;
                            if (v533){
                                bool v538;
                                v538 = v531 < 2l;
                                v539 = v538;
                            } else {
                                v539 = false;
                            }
                            bool v540;
                            v540 = v539 == false;
                            if (v540){
                                assert("The read index needs to be in range for the static array." && v539);
                            } else {
                            }
                            long v541;
                            v541 = v444.v[v531];
                            long v542;
                            v542 = v537 + v541;
                            bool v544;
                            if (v533){
                                bool v543;
                                v543 = v531 < 2l;
                                v544 = v543;
                            } else {
                                v544 = false;
                            }
                            bool v545;
                            v545 = v544 == false;
                            if (v545){
                                assert("The read index needs to be in range for the static array." && v544);
                            } else {
                            }
                            v530.v[v531] = v542;
                            v531 += 1l ;
                        }
                        long v546;
                        v546 = v444.v[0l];
                        long v547; long v548;
                        Tuple2 tmp35 = Tuple2(1l, v546);
                        v547 = tmp35.v0; v548 = tmp35.v1;
                        while (while_method_0(v547)){
                            bool v550;
                            v550 = 0l <= v547;
                            bool v552;
                            if (v550){
                                bool v551;
                                v551 = v547 < 2l;
                                v552 = v551;
                            } else {
                                v552 = false;
                            }
                            bool v553;
                            v553 = v552 == false;
                            if (v553){
                                assert("The read index needs to be in range for the static array." && v552);
                            } else {
                            }
                            long v554;
                            v554 = v444.v[v547];
                            bool v555;
                            v555 = v548 >= v554;
                            long v556;
                            if (v555){
                                v556 = v548;
                            } else {
                                v556 = v554;
                            }
                            v548 = v556;
                            v547 += 1l ;
                        }
                        long v557;
                        v557 = v548 + v529;
                        bool v558;
                        v558 = 0l <= v449;
                        bool v560;
                        if (v558){
                            bool v559;
                            v559 = v449 < 2l;
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
                        v562 = v530.v[v449];
                        bool v563;
                        v563 = v557 < v562;
                        long v564;
                        if (v563){
                            v564 = v557;
                        } else {
                            v564 = v562;
                        }
                        static_array<long,2l> v565;
                        long v566;
                        v566 = 0l;
                        while (while_method_0(v566)){
                            bool v568;
                            v568 = 0l <= v566;
                            bool v570;
                            if (v568){
                                bool v569;
                                v569 = v566 < 2l;
                                v570 = v569;
                            } else {
                                v570 = false;
                            }
                            bool v571;
                            v571 = v570 == false;
                            if (v571){
                                assert("The read index needs to be in range for the static array." && v570);
                            } else {
                            }
                            long v572;
                            v572 = v444.v[v566];
                            bool v573;
                            v573 = v449 == v566;
                            long v574;
                            if (v573){
                                v574 = v564;
                            } else {
                                v574 = v572;
                            }
                            bool v576;
                            if (v568){
                                bool v575;
                                v575 = v566 < 2l;
                                v576 = v575;
                            } else {
                                v576 = false;
                            }
                            bool v577;
                            v577 = v576 == false;
                            if (v577){
                                assert("The read index needs to be in range for the static array." && v576);
                            } else {
                            }
                            v565.v[v566] = v574;
                            v566 += 1l ;
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
                            v585 = v530.v[v579];
                            bool v587;
                            if (v581){
                                bool v586;
                                v586 = v579 < 2l;
                                v587 = v586;
                            } else {
                                v587 = false;
                            }
                            bool v588;
                            v588 = v587 == false;
                            if (v588){
                                assert("The read index needs to be in range for the static array." && v587);
                            } else {
                            }
                            long v589;
                            v589 = v565.v[v579];
                            long v590;
                            v590 = v585 - v589;
                            bool v592;
                            if (v581){
                                bool v591;
                                v591 = v579 < 2l;
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
                            v578.v[v579] = v590;
                            v579 += 1l ;
                        }
                        write_47(v565);
                        printf("\n");
                        long v594;
                        v594 = v445 + 1l;
                        v598 = try_round_38(v442, v443, v565, v594, v578, v447);
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                v775 = true; v776 = v598;
                break;
            }
            case 6: { // G_Showdown
                long v33 = v8.v.case6.v0; static_array<static_array<unsigned char,2l>,2l> v34 = v8.v.case6.v1; static_array<long,2l> v35 = v8.v.case6.v2; long v36 = v8.v.case6.v3; static_array<long,2l> v37 = v8.v.case6.v4; US6 v38 = v8.v.case6.v5;
                static_array<unsigned char,5l> v41;
                switch (v38.tag) {
                    case 2: { // River
                        static_array<unsigned char,5l> v39 = v38.v.case2.v0;
                        v41 = v39;
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in showdown.");
                        asm("exit;");
                    }
                }
                static_array<unsigned char,2l> v42;
                v42 = v34.v[0l];
                static_array<unsigned char,7l> v43;
                long v44;
                v44 = 0l;
                while (while_method_0(v44)){
                    bool v46;
                    v46 = 0l <= v44;
                    bool v48;
                    if (v46){
                        bool v47;
                        v47 = v44 < 2l;
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
                    unsigned char v50;
                    v50 = v42.v[v44];
                    bool v52;
                    if (v46){
                        bool v51;
                        v51 = v44 < 7l;
                        v52 = v51;
                    } else {
                        v52 = false;
                    }
                    bool v53;
                    v53 = v52 == false;
                    if (v53){
                        assert("The read index needs to be in range for the static array." && v52);
                    } else {
                    }
                    v43.v[v44] = v50;
                    v44 += 1l ;
                }
                long v54;
                v54 = 0l;
                while (while_method_2(v54)){
                    bool v56;
                    v56 = 0l <= v54;
                    bool v58;
                    if (v56){
                        bool v57;
                        v57 = v54 < 5l;
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
                    v60 = v41.v[v54];
                    long v61;
                    v61 = 2l + v54;
                    bool v62;
                    v62 = 0l <= v61;
                    bool v64;
                    if (v62){
                        bool v63;
                        v63 = v61 < 7l;
                        v64 = v63;
                    } else {
                        v64 = false;
                    }
                    bool v65;
                    v65 = v64 == false;
                    if (v65){
                        assert("The read index needs to be in range for the static array." && v64);
                    } else {
                    }
                    v43.v[v61] = v60;
                    v54 += 1l ;
                }
                static_array<unsigned char,5l> v66; char v67;
                Tuple0 tmp60 = score_49(v43);
                v66 = tmp60.v0; v67 = tmp60.v1;
                static_array<unsigned char,2l> v68;
                v68 = v34.v[1l];
                static_array<unsigned char,7l> v69;
                long v70;
                v70 = 0l;
                while (while_method_0(v70)){
                    bool v72;
                    v72 = 0l <= v70;
                    bool v74;
                    if (v72){
                        bool v73;
                        v73 = v70 < 2l;
                        v74 = v73;
                    } else {
                        v74 = false;
                    }
                    bool v75;
                    v75 = v74 == false;
                    if (v75){
                        assert("The read index needs to be in range for the static array." && v74);
                    } else {
                    }
                    unsigned char v76;
                    v76 = v68.v[v70];
                    bool v78;
                    if (v72){
                        bool v77;
                        v77 = v70 < 7l;
                        v78 = v77;
                    } else {
                        v78 = false;
                    }
                    bool v79;
                    v79 = v78 == false;
                    if (v79){
                        assert("The read index needs to be in range for the static array." && v78);
                    } else {
                    }
                    v69.v[v70] = v76;
                    v70 += 1l ;
                }
                long v80;
                v80 = 0l;
                while (while_method_2(v80)){
                    bool v82;
                    v82 = 0l <= v80;
                    bool v84;
                    if (v82){
                        bool v83;
                        v83 = v80 < 5l;
                        v84 = v83;
                    } else {
                        v84 = false;
                    }
                    bool v85;
                    v85 = v84 == false;
                    if (v85){
                        assert("The read index needs to be in range for the static array." && v84);
                    } else {
                    }
                    unsigned char v86;
                    v86 = v41.v[v80];
                    long v87;
                    v87 = 2l + v80;
                    bool v88;
                    v88 = 0l <= v87;
                    bool v90;
                    if (v88){
                        bool v89;
                        v89 = v87 < 7l;
                        v90 = v89;
                    } else {
                        v90 = false;
                    }
                    bool v91;
                    v91 = v90 == false;
                    if (v91){
                        assert("The read index needs to be in range for the static array." && v90);
                    } else {
                    }
                    v69.v[v87] = v86;
                    v80 += 1l ;
                }
                static_array<unsigned char,5l> v92; char v93;
                Tuple0 tmp61 = score_49(v69);
                v92 = tmp61.v0; v93 = tmp61.v1;
                long v94;
                v94 = v36 % 2l;
                bool v95;
                v95 = 0l <= v94;
                bool v97;
                if (v95){
                    bool v96;
                    v96 = v94 < 2l;
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
                v99 = v35.v[v94];
                bool v100;
                v100 = v67 < v93;
                US8 v106;
                if (v100){
                    v106 = US8_2();
                } else {
                    bool v102;
                    v102 = v67 > v93;
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
                            v114 = v66.v[v108];
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
                            v118 = v92.v[v108];
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
                v135.v[0l] = Tuple0(v66, v67);
                v135.v[1l] = Tuple0(v92, v93);
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
                v775 = false; v776 = v8;
                break;
            }
            case 7: { // G_Turn
                long v623 = v8.v.case7.v0; static_array<static_array<unsigned char,2l>,2l> v624 = v8.v.case7.v1; static_array<long,2l> v625 = v8.v.case7.v2; long v626 = v8.v.case7.v3; static_array<long,2l> v627 = v8.v.case7.v4; US6 v628 = v8.v.case7.v5;
                static_array<unsigned char,1l> v629; unsigned long long v630;
                Tuple14 tmp62 = draw_cards_42(v2, v6);
                v629 = tmp62.v0; v630 = tmp62.v1;
                v0 = v630;
                static_array_list<unsigned char,5l,long> v631;
                v631 = get_community_cards_43(v628, v629);
                long v632;
                v632 = v5.length;
                bool v633;
                v633 = v632 < 128l;
                bool v634;
                v634 = v633 == false;
                if (v634){
                    assert("The length has to be less than the maximum length of the array." && v633);
                } else {
                }
                long v635;
                v635 = v632 + 1l;
                v5.length = v635;
                bool v636;
                v636 = 0l <= v632;
                bool v639;
                if (v636){
                    long v637;
                    v637 = v5.length;
                    bool v638;
                    v638 = v632 < v637;
                    v639 = v638;
                } else {
                    v639 = false;
                }
                bool v640;
                v640 = v639 == false;
                if (v640){
                    assert("The set index needs to be in range for the static array list." && v639);
                } else {
                }
                US3 v641;
                v641 = US3_0(v631);
                v5.v[v632] = v641;
                US6 v668;
                switch (v628.tag) {
                    case 0: { // Flop
                        static_array<unsigned char,3l> v642 = v628.v.case0.v0;
                        static_array<unsigned char,4l> v643;
                        long v644;
                        v644 = 0l;
                        while (while_method_3(v644)){
                            bool v646;
                            v646 = 0l <= v644;
                            bool v648;
                            if (v646){
                                bool v647;
                                v647 = v644 < 3l;
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
                            v650 = v642.v[v644];
                            bool v652;
                            if (v646){
                                bool v651;
                                v651 = v644 < 4l;
                                v652 = v651;
                            } else {
                                v652 = false;
                            }
                            bool v653;
                            v653 = v652 == false;
                            if (v653){
                                assert("The read index needs to be in range for the static array." && v652);
                            } else {
                            }
                            v643.v[v644] = v650;
                            v644 += 1l ;
                        }
                        long v654;
                        v654 = 0l;
                        while (while_method_6(v654)){
                            bool v656;
                            v656 = 0l <= v654;
                            bool v658;
                            if (v656){
                                bool v657;
                                v657 = v654 < 1l;
                                v658 = v657;
                            } else {
                                v658 = false;
                            }
                            bool v659;
                            v659 = v658 == false;
                            if (v659){
                                assert("The read index needs to be in range for the static array." && v658);
                            } else {
                            }
                            unsigned char v660;
                            v660 = v629.v[v654];
                            long v661;
                            v661 = 3l + v654;
                            bool v662;
                            v662 = 0l <= v661;
                            bool v664;
                            if (v662){
                                bool v663;
                                v663 = v661 < 4l;
                                v664 = v663;
                            } else {
                                v664 = false;
                            }
                            bool v665;
                            v665 = v664 == false;
                            if (v665){
                                assert("The read index needs to be in range for the static array." && v664);
                            } else {
                            }
                            v643.v[v661] = v660;
                            v654 += 1l ;
                        }
                        v668 = US6_3(v643);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in turn.");
                        asm("exit;");
                    }
                }
                long v669;
                v669 = 0l;
                US5 v670;
                v670 = try_round_38(v623, v624, v625, v669, v627, v668);
                v775 = true; v776 = v670;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v7 = v775;
        v8 = v776;
    }
    return v8;
}
__device__ Tuple8 play_loop_32(US4 v0, static_array<US2,2l> v1, US7 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US5 v6){
    US5 v7;
    v7 = play_loop_inner_33(v3, v4, v5, v1, v6);
    switch (v7.tag) {
        case 1: { // G_Fold
            long v24 = v7.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v25 = v7.v.case1.v1; static_array<long,2l> v26 = v7.v.case1.v2; long v27 = v7.v.case1.v3; static_array<long,2l> v28 = v7.v.case1.v4; US6 v29 = v7.v.case1.v5;
            US4 v30;
            v30 = US4_0();
            US7 v31;
            v31 = US7_1(v24, v25, v26, v27, v28, v29);
            return Tuple8(v30, v1, v31);
            break;
        }
        case 4: { // G_Round
            long v8 = v7.v.case4.v0; static_array<static_array<unsigned char,2l>,2l> v9 = v7.v.case4.v1; static_array<long,2l> v10 = v7.v.case4.v2; long v11 = v7.v.case4.v3; static_array<long,2l> v12 = v7.v.case4.v4; US6 v13 = v7.v.case4.v5;
            US4 v14;
            v14 = US4_1(v7);
            US7 v15;
            v15 = US7_2(v8, v9, v10, v11, v12, v13);
            return Tuple8(v14, v1, v15);
            break;
        }
        case 6: { // G_Showdown
            long v16 = v7.v.case6.v0; static_array<static_array<unsigned char,2l>,2l> v17 = v7.v.case6.v1; static_array<long,2l> v18 = v7.v.case6.v2; long v19 = v7.v.case6.v3; static_array<long,2l> v20 = v7.v.case6.v4; US6 v21 = v7.v.case6.v5;
            US4 v22;
            v22 = US4_0();
            US7 v23;
            v23 = US7_1(v16, v17, v18, v19, v20, v21);
            return Tuple8(v22, v1, v23);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
__device__ void f_51(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_52(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_54(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_57(unsigned char * v0, unsigned char v1){
    unsigned char * v2;
    v2 = (unsigned char *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_56(unsigned char * v0, unsigned char v1){
    return f_57(v0, v1);
}
__device__ void f_55(unsigned char * v0, static_array_list<unsigned char,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_54(v0, v2);
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
        f_56(v8, v14);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_58(unsigned char * v0, long v1, long v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long * v4;
    v4 = (long *)(v0+4ull);
    v4[0l] = v2;
    return ;
}
__device__ void f_60(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_61(unsigned char * v0){
    return ;
}
__device__ void f_59(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_60(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_Call
            return f_61(v5);
            break;
        }
        case 1: { // A_Fold
            return f_61(v5);
            break;
        }
        case 2: { // A_Raise
            long v6 = v2.v.case2.v0;
            return f_54(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_62(unsigned char * v0, long v1, static_array<unsigned char,2l> v2){
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
        f_56(v8, v13);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_65(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
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
        f_56(v6, v11);
        v3 += 1l ;
    }
    char * v12;
    v12 = (char *)(v0+5ull);
    v12[0l] = v2;
    return ;
}
__device__ void f_64(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
    return f_65(v0, v1, v2);
}
__device__ void f_63(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3){
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
        Tuple0 tmp65 = v2.v[v5];
        v15 = tmp65.v0; v16 = tmp65.v1;
        f_64(v10, v15, v16);
        v5 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+24ull);
    v17[0l] = v3;
    return ;
}
__device__ void f_53(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_54(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<unsigned char,5l,long> v4 = v1.v.case0.v0;
            return f_55(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_58(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US1 v8 = v1.v.case2.v1;
            return f_59(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<unsigned char,2l> v10 = v1.v.case3.v1;
            return f_62(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<Tuple0,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_63(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_66(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6160ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_69(unsigned char * v0, static_array<unsigned char,2l> v1){
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
        f_56(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_70(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+28ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_71(unsigned char * v0, static_array<unsigned char,3l> v1){
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
        f_56(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_72(unsigned char * v0, static_array<unsigned char,5l> v1){
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
        f_56(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_73(unsigned char * v0, static_array<unsigned char,4l> v1){
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
        f_56(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_68(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US6 v6){
    long * v7;
    v7 = (long *)(v0+0ull);
    v7[0l] = v1;
    long v8;
    v8 = 0l;
    while (while_method_0(v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 2ull;
        unsigned long long v12;
        v12 = 4ull + v11;
        unsigned char * v13;
        v13 = (unsigned char *)(v0+v12);
        bool v14;
        v14 = 0l <= v8;
        bool v16;
        if (v14){
            bool v15;
            v15 = v8 < 2l;
            v16 = v15;
        } else {
            v16 = false;
        }
        bool v17;
        v17 = v16 == false;
        if (v17){
            assert("The read index needs to be in range for the static array." && v16);
        } else {
        }
        static_array<unsigned char,2l> v18;
        v18 = v2.v[v8];
        f_69(v13, v18);
        v8 += 1l ;
    }
    long v19;
    v19 = 0l;
    while (while_method_0(v19)){
        unsigned long long v21;
        v21 = (unsigned long long)v19;
        unsigned long long v22;
        v22 = v21 * 4ull;
        unsigned long long v23;
        v23 = 8ull + v22;
        unsigned char * v24;
        v24 = (unsigned char *)(v0+v23);
        bool v25;
        v25 = 0l <= v19;
        bool v27;
        if (v25){
            bool v26;
            v26 = v19 < 2l;
            v27 = v26;
        } else {
            v27 = false;
        }
        bool v28;
        v28 = v27 == false;
        if (v28){
            assert("The read index needs to be in range for the static array." && v27);
        } else {
        }
        long v29;
        v29 = v3.v[v19];
        f_54(v24, v29);
        v19 += 1l ;
    }
    long * v30;
    v30 = (long *)(v0+16ull);
    v30[0l] = v4;
    long v31;
    v31 = 0l;
    while (while_method_0(v31)){
        unsigned long long v33;
        v33 = (unsigned long long)v31;
        unsigned long long v34;
        v34 = v33 * 4ull;
        unsigned long long v35;
        v35 = 20ull + v34;
        unsigned char * v36;
        v36 = (unsigned char *)(v0+v35);
        bool v37;
        v37 = 0l <= v31;
        bool v39;
        if (v37){
            bool v38;
            v38 = v31 < 2l;
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
        long v41;
        v41 = v5.v[v31];
        f_54(v36, v41);
        v31 += 1l ;
    }
    long v42;
    v42 = v6.tag;
    f_70(v0, v42);
    unsigned char * v43;
    v43 = (unsigned char *)(v0+32ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v44 = v6.v.case0.v0;
            return f_71(v43, v44);
            break;
        }
        case 1: { // Preflop
            return f_61(v43);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v45 = v6.v.case2.v0;
            return f_72(v43, v45);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v46 = v6.v.case3.v0;
            return f_73(v43, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_75(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+40ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_74(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US6 v6, US1 v7){
    long * v8;
    v8 = (long *)(v0+0ull);
    v8[0l] = v1;
    long v9;
    v9 = 0l;
    while (while_method_0(v9)){
        unsigned long long v11;
        v11 = (unsigned long long)v9;
        unsigned long long v12;
        v12 = v11 * 2ull;
        unsigned long long v13;
        v13 = 4ull + v12;
        unsigned char * v14;
        v14 = (unsigned char *)(v0+v13);
        bool v15;
        v15 = 0l <= v9;
        bool v17;
        if (v15){
            bool v16;
            v16 = v9 < 2l;
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
        static_array<unsigned char,2l> v19;
        v19 = v2.v[v9];
        f_69(v14, v19);
        v9 += 1l ;
    }
    long v20;
    v20 = 0l;
    while (while_method_0(v20)){
        unsigned long long v22;
        v22 = (unsigned long long)v20;
        unsigned long long v23;
        v23 = v22 * 4ull;
        unsigned long long v24;
        v24 = 8ull + v23;
        unsigned char * v25;
        v25 = (unsigned char *)(v0+v24);
        bool v26;
        v26 = 0l <= v20;
        bool v28;
        if (v26){
            bool v27;
            v27 = v20 < 2l;
            v28 = v27;
        } else {
            v28 = false;
        }
        bool v29;
        v29 = v28 == false;
        if (v29){
            assert("The read index needs to be in range for the static array." && v28);
        } else {
        }
        long v30;
        v30 = v3.v[v20];
        f_54(v25, v30);
        v20 += 1l ;
    }
    long * v31;
    v31 = (long *)(v0+16ull);
    v31[0l] = v4;
    long v32;
    v32 = 0l;
    while (while_method_0(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 20ull + v35;
        unsigned char * v37;
        v37 = (unsigned char *)(v0+v36);
        bool v38;
        v38 = 0l <= v32;
        bool v40;
        if (v38){
            bool v39;
            v39 = v32 < 2l;
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
        v42 = v5.v[v32];
        f_54(v37, v42);
        v32 += 1l ;
    }
    long v43;
    v43 = v6.tag;
    f_70(v0, v43);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+32ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v45 = v6.v.case0.v0;
            f_71(v44, v45);
            break;
        }
        case 1: { // Preflop
            f_61(v44);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v46 = v6.v.case2.v0;
            f_72(v44, v46);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v47 = v6.v.case3.v0;
            f_73(v44, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v48;
    v48 = v7.tag;
    f_75(v0, v48);
    unsigned char * v49;
    v49 = (unsigned char *)(v0+44ull);
    switch (v7.tag) {
        case 0: { // A_Call
            return f_61(v49);
            break;
        }
        case 1: { // A_Fold
            return f_61(v49);
            break;
        }
        case 2: { // A_Raise
            long v50 = v7.v.case2.v0;
            return f_54(v49, v50);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_67(unsigned char * v0, US5 v1){
    long v2;
    v2 = v1.tag;
    f_54(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; static_array<static_array<unsigned char,2l>,2l> v5 = v1.v.case0.v1; static_array<long,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; US6 v9 = v1.v.case0.v5;
            return f_68(v3, v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: { // G_Fold
            long v10 = v1.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v11 = v1.v.case1.v1; static_array<long,2l> v12 = v1.v.case1.v2; long v13 = v1.v.case1.v3; static_array<long,2l> v14 = v1.v.case1.v4; US6 v15 = v1.v.case1.v5;
            return f_68(v3, v10, v11, v12, v13, v14, v15);
            break;
        }
        case 2: { // G_Preflop
            return f_61(v3);
            break;
        }
        case 3: { // G_River
            long v16 = v1.v.case3.v0; static_array<static_array<unsigned char,2l>,2l> v17 = v1.v.case3.v1; static_array<long,2l> v18 = v1.v.case3.v2; long v19 = v1.v.case3.v3; static_array<long,2l> v20 = v1.v.case3.v4; US6 v21 = v1.v.case3.v5;
            return f_68(v3, v16, v17, v18, v19, v20, v21);
            break;
        }
        case 4: { // G_Round
            long v22 = v1.v.case4.v0; static_array<static_array<unsigned char,2l>,2l> v23 = v1.v.case4.v1; static_array<long,2l> v24 = v1.v.case4.v2; long v25 = v1.v.case4.v3; static_array<long,2l> v26 = v1.v.case4.v4; US6 v27 = v1.v.case4.v5;
            return f_68(v3, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 5: { // G_Round'
            long v28 = v1.v.case5.v0; static_array<static_array<unsigned char,2l>,2l> v29 = v1.v.case5.v1; static_array<long,2l> v30 = v1.v.case5.v2; long v31 = v1.v.case5.v3; static_array<long,2l> v32 = v1.v.case5.v4; US6 v33 = v1.v.case5.v5; US1 v34 = v1.v.case5.v6;
            return f_74(v3, v28, v29, v30, v31, v32, v33, v34);
            break;
        }
        case 6: { // G_Showdown
            long v35 = v1.v.case6.v0; static_array<static_array<unsigned char,2l>,2l> v36 = v1.v.case6.v1; static_array<long,2l> v37 = v1.v.case6.v2; long v38 = v1.v.case6.v3; static_array<long,2l> v39 = v1.v.case6.v4; US6 v40 = v1.v.case6.v5;
            return f_68(v3, v35, v36, v37, v38, v39, v40);
            break;
        }
        case 7: { // G_Turn
            long v41 = v1.v.case7.v0; static_array<static_array<unsigned char,2l>,2l> v42 = v1.v.case7.v1; static_array<long,2l> v43 = v1.v.case7.v2; long v44 = v1.v.case7.v3; static_array<long,2l> v45 = v1.v.case7.v4; US6 v46 = v1.v.case7.v5;
            return f_68(v3, v41, v42, v43, v44, v45, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_76(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_54(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_61(v3);
            break;
        }
        case 1: { // Human
            return f_61(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_77(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6248ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_50(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US4 v3, static_array<US2,2l> v4, US7 v5){
    f_51(v0, v1);
    long v6;
    v6 = v2.length;
    f_52(v0, v6);
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
        f_53(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_66(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // None
            f_61(v21);
            break;
        }
        case 1: { // Some
            US5 v22 = v3.v.case1.v0;
            f_67(v21, v22);
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
        v27 = 6240ull + v26;
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
        f_76(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_77(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+6256ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_61(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v37 = v5.v.case1.v1; static_array<long,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; US6 v41 = v5.v.case1.v5;
            return f_68(v35, v36, v37, v38, v39, v40, v41);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v42 = v5.v.case2.v0; static_array<static_array<unsigned char,2l>,2l> v43 = v5.v.case2.v1; static_array<long,2l> v44 = v5.v.case2.v2; long v45 = v5.v.case2.v3; static_array<long,2l> v46 = v5.v.case2.v4; US6 v47 = v5.v.case2.v5;
            return f_68(v35, v42, v43, v44, v45, v46, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_79(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6168ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_78(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US7 v3){
    long v4;
    v4 = v1.length;
    f_54(v0, v4);
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
        f_53(v11, v17);
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
        f_76(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_79(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_61(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v32 = v3.v.case1.v1; static_array<long,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; US6 v36 = v3.v.case1.v5;
            return f_68(v30, v31, v32, v33, v34, v35, v36);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v37 = v3.v.case2.v0; static_array<static_array<unsigned char,2l>,2l> v38 = v3.v.case2.v1; static_array<long,2l> v39 = v3.v.case2.v2; long v40 = v3.v.case2.v3; static_array<long,2l> v41 = v3.v.case2.v4; US6 v42 = v3.v.case2.v5;
            return f_68(v30, v37, v38, v39, v40, v41, v42);
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
        US4 v65; static_array<US2,2l> v66; US7 v67;
        switch (v9.tag) {
            case 0: { // ActionSelected
                US1 v35 = v9.v.case0.v0;
                switch (v12.tag) {
                    case 0: { // None
                        v65 = v12; v66 = v13; v67 = v14;
                        break;
                    }
                    case 1: { // Some
                        US5 v36 = v12.v.case1.v0;
                        switch (v36.tag) {
                            case 4: { // G_Round
                                long v37 = v36.v.case4.v0; static_array<static_array<unsigned char,2l>,2l> v38 = v36.v.case4.v1; static_array<long,2l> v39 = v36.v.case4.v2; long v40 = v36.v.case4.v3; static_array<long,2l> v41 = v36.v.case4.v4; US6 v42 = v36.v.case4.v5;
                                US5 v43;
                                v43 = US5_5(v37, v38, v39, v40, v41, v42, v35);
                                Tuple8 tmp63 = play_loop_32(v12, v13, v14, v15, v16, v23, v43);
                                v65 = tmp63.v0; v66 = tmp63.v1; v67 = tmp63.v2;
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
                v65 = v12; v66 = v34; v67 = v14;
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
                Tuple8 tmp64 = play_loop_32(v28, v24, v29, v15, v16, v23, v30);
                v65 = tmp64.v0; v66 = tmp64.v1; v67 = tmp64.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        f_50(v0, v10, v11, v65, v66, v67);
        return f_78(v2, v11, v66, v67);
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
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 0
class US4_1(NamedTuple): # G_Fold
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 1
class US4_2(NamedTuple): # G_Preflop
    tag = 2
class US4_3(NamedTuple): # G_River
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 3
class US4_4(NamedTuple): # G_Round
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 4
class US4_5(NamedTuple): # G_Round'
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    v6 : US1
    tag = 5
class US4_6(NamedTuple): # G_Showdown
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 6
class US4_7(NamedTuple): # G_Turn
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
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
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
    tag = 1
class US6_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    v1 : static_array
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : US5
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
        v3 = cp.empty(6304,dtype=cp.uint8)
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
        method41(v2, v6)
        del v6
        method48(v3, v7, v8, v9, v10, v11)
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
        v16, v17, v18, v19, v20 = method76(v3)
        del v3
        v21, v22, v23 = method104(v4)
        del v4
        return method106(v16, v17, v18, v19, v20, v21, v22, v23)
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
        return method145(v4, v3, v5, v0, v6)
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
def method34(v0 : object) -> static_array:
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
def method37(v0 : object) -> static_array:
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
def method38(v0 : object) -> static_array:
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
def method36(v0 : object) -> US5:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Flop" == v1
    if v4:
        del v1, v4
        v5 = method37(v2)
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
                    v16 = method38(v2)
                    del v2
                    return US5_3(v16)
                else:
                    del v2, v15
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method32(v0 : object) -> Tuple[i32, static_array, static_array, i32, static_array, US5]:
    v1 = v0["config"] # type: ignore
    v2 = method33(v1)
    del v1
    v3 = v0["pl_card"] # type: ignore
    v4 = method34(v3)
    del v3
    v5 = v0["pot"] # type: ignore
    v6 = method35(v5)
    del v5
    v7 = v0["round_turn"] # type: ignore
    v8 = method5(v7)
    del v7
    v9 = v0["stack"] # type: ignore
    v10 = method35(v9)
    del v9
    v11 = v0["street"] # type: ignore
    del v0
    v12 = method36(v11)
    del v11
    return v2, v4, v6, v8, v10, v12
def method39(v0 : object) -> Tuple[i32, static_array, static_array, i32, static_array, US5, US1]:
    v1 = v0[0] # type: ignore
    v2, v3, v4, v5, v6, v7 = method32(v1)
    del v1
    v8 = v0[1] # type: ignore
    del v0
    v9 = method3(v8)
    del v8
    return v2, v3, v4, v5, v6, v7, v9
def method31(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "G_Flop" == v1
    if v4:
        del v1, v4
        v5, v6, v7, v8, v9, v10 = method32(v2)
        del v2
        return US4_0(v5, v6, v7, v8, v9, v10)
    else:
        del v4
        v13 = "G_Fold" == v1
        if v13:
            del v1, v13
            v14, v15, v16, v17, v18, v19 = method32(v2)
            del v2
            return US4_1(v14, v15, v16, v17, v18, v19)
        else:
            del v13
            v22 = "G_Preflop" == v1
            if v22:
                del v1, v22
                method4(v2)
                del v2
                return US4_2()
            else:
                del v22
                v25 = "G_River" == v1
                if v25:
                    del v1, v25
                    v26, v27, v28, v29, v30, v31 = method32(v2)
                    del v2
                    return US4_3(v26, v27, v28, v29, v30, v31)
                else:
                    del v25
                    v34 = "G_Round" == v1
                    if v34:
                        del v1, v34
                        v35, v36, v37, v38, v39, v40 = method32(v2)
                        del v2
                        return US4_4(v35, v36, v37, v38, v39, v40)
                    else:
                        del v34
                        v43 = "G_Round'" == v1
                        if v43:
                            del v1, v43
                            v44, v45, v46, v47, v48, v49, v50 = method39(v2)
                            del v2
                            return US4_5(v44, v45, v46, v47, v48, v49, v50)
                        else:
                            del v43
                            v53 = "G_Showdown" == v1
                            if v53:
                                del v1, v53
                                v54, v55, v56, v57, v58, v59 = method32(v2)
                                del v2
                                return US4_6(v54, v55, v56, v57, v58, v59)
                            else:
                                del v53
                                v62 = "G_Turn" == v1
                                if v62:
                                    del v1, v62
                                    v63, v64, v65, v66, v67, v68 = method32(v2)
                                    del v2
                                    return US4_7(v63, v64, v65, v66, v67, v68)
                                else:
                                    del v2, v62
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
def method40(v0 : object) -> US6:
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
            v8, v9, v10, v11, v12, v13 = method32(v2)
            del v2
            return US6_1(v8, v9, v10, v11, v12, v13)
        else:
            del v7
            v16 = "WaitingForActionFromPlayerId" == v1
            if v16:
                del v1, v16
                v17, v18, v19, v20, v21, v22 = method32(v2)
                del v2
                return US6_2(v17, v18, v19, v20, v21, v22)
            else:
                del v2, v16
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
    v6 = method40(v5)
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
def method42(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[0:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method44(v0 : cp.ndarray) -> None:
    del v0
    return 
def method43(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US1_0(): # A_Call
            del v1
            return method44(v3)
        case US1_1(): # A_Fold
            del v1
            return method44(v3)
        case US1_2(v4): # A_Raise
            del v1
            return method42(v3, v4)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method46(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method47(v0 : cp.ndarray, v1 : US2) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US2_0(): # Computer
            del v1
            return method44(v3)
        case US2_1(): # Human
            del v1
            return method44(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method45(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method46(v2):
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
        method47(v6, v12)
        del v6, v12
        v2 += 1 
    del v0, v1, v2
    return 
def method41(v0 : cp.ndarray, v1 : US0) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[8:].view(cp.uint8)
    del v0
    match v1:
        case US0_0(v4): # ActionSelected
            del v1
            return method43(v3, v4)
        case US0_1(v5): # PlayerChanged
            del v1
            return method45(v3, v5)
        case US0_2(): # StartGame
            del v1
            return method44(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method49(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[0:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method50(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method54(v0 : cp.ndarray, v1 : u8) -> None:
    v2 = v0[0:].view(cp.uint8)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method53(v0 : cp.ndarray, v1 : u8) -> None:
    return method54(v0, v1)
def method52(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method42(v0, v2)
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
        method53(v8, v15)
        del v8, v15
        v4 += 1 
    del v0, v1, v3, v4
    return 
def method55(v0 : cp.ndarray, v1 : i32, v2 : i32) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v0[4:].view(cp.int32)
    del v0
    v4[0] = v2
    del v2, v4
    return 
def method57(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method56(v0 : cp.ndarray, v1 : i32, v2 : US1) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method57(v0, v4)
    del v4
    v5 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US1_0(): # A_Call
            del v2
            return method44(v5)
        case US1_1(): # A_Fold
            del v2
            return method44(v5)
        case US1_2(v6): # A_Raise
            del v2
            return method42(v5, v6)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method58(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method46(v4):
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
        method53(v8, v14)
        del v8, v14
        v4 += 1 
    del v0, v2, v4
    return 
def method62(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method61(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    v3 = 0
    while method62(v3):
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
        method53(v6, v12)
        del v6, v12
        v3 += 1 
    del v1, v3
    v13 = v0[5:].view(cp.int8)
    del v0
    v13[0] = v2
    del v2, v13
    return 
def method60(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    return method61(v0, v1, v2)
def method59(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
    v4 = v0[0:].view(cp.int32)
    v4[0] = v1
    del v1, v4
    v5 = 0
    while method46(v5):
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
        method60(v10, v16, v17)
        del v10, v16, v17
        v5 += 1 
    del v2, v5
    v18 = v0[24:].view(cp.int32)
    del v0
    v18[0] = v3
    del v3, v18
    return 
def method51(v0 : cp.ndarray, v1 : US7) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US7_0(v4): # CommunityCardsAre
            del v1
            return method52(v3, v4)
        case US7_1(v5, v6): # Fold
            del v1
            return method55(v3, v5, v6)
        case US7_2(v7, v8): # PlayerAction
            del v1
            return method56(v3, v7, v8)
        case US7_3(v9, v10): # PlayerGotCards
            del v1
            return method58(v3, v9, v10)
        case US7_4(v11, v12, v13): # Showdown
            del v1
            return method59(v3, v11, v12, v13)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method63(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6160:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method66(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method46(v2):
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
        method53(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method67(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[28:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method69(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method68(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method69(v2):
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
        method53(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method70(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method62(v2):
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
        method53(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method72(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method71(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method72(v2):
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
        method53(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method65(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5) -> None:
    v7 = v0[0:].view(cp.int32)
    v7[0] = v1
    del v1, v7
    v8 = 0
    while method46(v8):
        v10 = u64(v8)
        v11 = v10 * 2
        del v10
        v12 = 4 + v11
        del v11
        v13 = v0[v12:].view(cp.uint8)
        del v12
        v14 = 0 <= v8
        if v14:
            v15 = v8 < 2
            v16 = v15
        else:
            v16 = False
        del v14
        v17 = v16 == False
        if v17:
            v18 = "The read index needs to be in range for the static array."
            assert v16, v18
            del v18
        else:
            pass
        del v16, v17
        v19 = v2[v8]
        method66(v13, v19)
        del v13, v19
        v8 += 1 
    del v2, v8
    v20 = 0
    while method46(v20):
        v22 = u64(v20)
        v23 = v22 * 4
        del v22
        v24 = 8 + v23
        del v23
        v25 = v0[v24:].view(cp.uint8)
        del v24
        v26 = 0 <= v20
        if v26:
            v27 = v20 < 2
            v28 = v27
        else:
            v28 = False
        del v26
        v29 = v28 == False
        if v29:
            v30 = "The read index needs to be in range for the static array."
            assert v28, v30
            del v30
        else:
            pass
        del v28, v29
        v31 = v3[v20]
        method42(v25, v31)
        del v25, v31
        v20 += 1 
    del v3, v20
    v32 = v0[16:].view(cp.int32)
    v32[0] = v4
    del v4, v32
    v33 = 0
    while method46(v33):
        v35 = u64(v33)
        v36 = v35 * 4
        del v35
        v37 = 20 + v36
        del v36
        v38 = v0[v37:].view(cp.uint8)
        del v37
        v39 = 0 <= v33
        if v39:
            v40 = v33 < 2
            v41 = v40
        else:
            v41 = False
        del v39
        v42 = v41 == False
        if v42:
            v43 = "The read index needs to be in range for the static array."
            assert v41, v43
            del v43
        else:
            pass
        del v41, v42
        v44 = v5[v33]
        method42(v38, v44)
        del v38, v44
        v33 += 1 
    del v5, v33
    v45 = v6.tag
    method67(v0, v45)
    del v45
    v46 = v0[32:].view(cp.uint8)
    del v0
    match v6:
        case US5_0(v47): # Flop
            del v6
            return method68(v46, v47)
        case US5_1(): # Preflop
            del v6
            return method44(v46)
        case US5_2(v48): # River
            del v6
            return method70(v46, v48)
        case US5_3(v49): # Turn
            del v6
            return method71(v46, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method74(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[40:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method73(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5, v7 : US1) -> None:
    v8 = v0[0:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = 0
    while method46(v9):
        v11 = u64(v9)
        v12 = v11 * 2
        del v11
        v13 = 4 + v12
        del v12
        v14 = v0[v13:].view(cp.uint8)
        del v13
        v15 = 0 <= v9
        if v15:
            v16 = v9 < 2
            v17 = v16
        else:
            v17 = False
        del v15
        v18 = v17 == False
        if v18:
            v19 = "The read index needs to be in range for the static array."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        v20 = v2[v9]
        method66(v14, v20)
        del v14, v20
        v9 += 1 
    del v2, v9
    v21 = 0
    while method46(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 8 + v24
        del v24
        v26 = v0[v25:].view(cp.uint8)
        del v25
        v27 = 0 <= v21
        if v27:
            v28 = v21 < 2
            v29 = v28
        else:
            v29 = False
        del v27
        v30 = v29 == False
        if v30:
            v31 = "The read index needs to be in range for the static array."
            assert v29, v31
            del v31
        else:
            pass
        del v29, v30
        v32 = v3[v21]
        method42(v26, v32)
        del v26, v32
        v21 += 1 
    del v3, v21
    v33 = v0[16:].view(cp.int32)
    v33[0] = v4
    del v4, v33
    v34 = 0
    while method46(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 20 + v37
        del v37
        v39 = v0[v38:].view(cp.uint8)
        del v38
        v40 = 0 <= v34
        if v40:
            v41 = v34 < 2
            v42 = v41
        else:
            v42 = False
        del v40
        v43 = v42 == False
        if v43:
            v44 = "The read index needs to be in range for the static array."
            assert v42, v44
            del v44
        else:
            pass
        del v42, v43
        v45 = v5[v34]
        method42(v39, v45)
        del v39, v45
        v34 += 1 
    del v5, v34
    v46 = v6.tag
    method67(v0, v46)
    del v46
    v47 = v0[32:].view(cp.uint8)
    match v6:
        case US5_0(v48): # Flop
            method68(v47, v48)
        case US5_1(): # Preflop
            method44(v47)
        case US5_2(v49): # River
            method70(v47, v49)
        case US5_3(v50): # Turn
            method71(v47, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v6, v47
    v51 = v7.tag
    method74(v0, v51)
    del v51
    v52 = v0[44:].view(cp.uint8)
    del v0
    match v7:
        case US1_0(): # A_Call
            del v7
            return method44(v52)
        case US1_1(): # A_Fold
            del v7
            return method44(v52)
        case US1_2(v53): # A_Raise
            del v7
            return method42(v52, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method64(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method65(v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v1
            return method65(v3, v10, v11, v12, v13, v14, v15)
        case US4_2(): # G_Preflop
            del v1
            return method44(v3)
        case US4_3(v16, v17, v18, v19, v20, v21): # G_River
            del v1
            return method65(v3, v16, v17, v18, v19, v20, v21)
        case US4_4(v22, v23, v24, v25, v26, v27): # G_Round
            del v1
            return method65(v3, v22, v23, v24, v25, v26, v27)
        case US4_5(v28, v29, v30, v31, v32, v33, v34): # G_Round'
            del v1
            return method73(v3, v28, v29, v30, v31, v32, v33, v34)
        case US4_6(v35, v36, v37, v38, v39, v40): # G_Showdown
            del v1
            return method65(v3, v35, v36, v37, v38, v39, v40)
        case US4_7(v41, v42, v43, v44, v45, v46): # G_Turn
            del v1
            return method65(v3, v41, v42, v43, v44, v45, v46)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method75(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6248:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method48(v0 : cp.ndarray, v1 : u64, v2 : static_array_list, v3 : US3, v4 : static_array, v5 : US6) -> None:
    method49(v0, v1)
    del v1
    v6 = v2.length
    method50(v0, v6)
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
        method51(v13, v20)
        del v13, v20
        v8 += 1 
    del v2, v7, v8
    v21 = v3.tag
    method63(v0, v21)
    del v21
    v22 = v0[6176:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method44(v22)
        case US3_1(v23): # Some
            method64(v22, v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v22
    v24 = 0
    while method46(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 6240 + v27
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
        method47(v29, v35)
        del v29, v35
        v24 += 1 
    del v4, v24
    v36 = v5.tag
    method75(v0, v36)
    del v36
    v37 = v0[6256:].view(cp.uint8)
    del v0
    match v5:
        case US6_0(): # GameNotStarted
            del v5
            return method44(v37)
        case US6_1(v38, v39, v40, v41, v42, v43): # GameOver
            del v5
            return method65(v37, v38, v39, v40, v41, v42, v43)
        case US6_2(v44, v45, v46, v47, v48, v49): # WaitingForActionFromPlayerId
            del v5
            return method65(v37, v44, v45, v46, v47, v48, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method77(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method78(v0 : cp.ndarray) -> i32:
    v1 = v0[8:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method80(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method83(v0 : cp.ndarray) -> u8:
    v1 = v0[0:].view(cp.uint8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method82(v0 : cp.ndarray) -> u8:
    v1 = method83(v0)
    del v0
    return v1
def method81(v0 : cp.ndarray) -> static_array_list:
    v1 = static_array_list(5)
    v2 = method80(v0)
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
        v9 = method82(v8)
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
def method84(v0 : cp.ndarray) -> Tuple[i32, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.int32)
    del v0
    v4 = v3[0].item()
    del v3
    return v2, v4
def method86(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method87(v0 : cp.ndarray) -> None:
    del v0
    return 
def method85(v0 : cp.ndarray) -> Tuple[i32, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method86(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method87(v4)
        v10 = US1_0()
    elif v3 == 1:
        method87(v4)
        v10 = US1_1()
    elif v3 == 2:
        v8 = method80(v4)
        v10 = US1_2(v8)
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v10
def method88(v0 : cp.ndarray) -> Tuple[i32, static_array]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method46(v4):
        v6 = u64(v4)
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = method82(v8)
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
def method91(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1 = static_array(5)
    v2 = 0
    while method62(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method82(v5)
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
def method90(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1, v2 = method91(v0)
    del v0
    return v1, v2
def method89(v0 : cp.ndarray) -> Tuple[i32, static_array, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method46(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method90(v9)
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
def method79(v0 : cp.ndarray) -> US7:
    v1 = method80(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method81(v2)
        del v2
        return US7_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method84(v2)
        del v2
        return US7_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method85(v2)
        del v2
        return US7_2(v9, v10)
    elif v1 == 3:
        del v1
        v12, v13 = method88(v2)
        del v2
        return US7_3(v12, v13)
    elif v1 == 4:
        del v1
        v15, v16, v17 = method89(v2)
        del v2
        return US7_4(v15, v16, v17)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method92(v0 : cp.ndarray) -> i32:
    v1 = v0[6160:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method95(v0 : cp.ndarray) -> static_array:
    v1 = static_array(2)
    v2 = 0
    while method46(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method82(v5)
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
def method96(v0 : cp.ndarray) -> i32:
    v1 = v0[28:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method97(v0 : cp.ndarray) -> static_array:
    v1 = static_array(3)
    v2 = 0
    while method69(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method82(v5)
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
def method98(v0 : cp.ndarray) -> static_array:
    v1 = static_array(5)
    v2 = 0
    while method62(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method82(v5)
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
def method99(v0 : cp.ndarray) -> static_array:
    v1 = static_array(4)
    v2 = 0
    while method72(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method82(v5)
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
def method94(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method46(v4):
        v6 = u64(v4)
        v7 = v6 * 2
        del v6
        v8 = 4 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method95(v9)
        del v9
        v11 = 0 <= v4
        if v11:
            v12 = v4 < 2
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
        v3[v4] = v10
        del v10
        v4 += 1 
    del v4
    v16 = static_array(2)
    v17 = 0
    while method46(v17):
        v19 = u64(v17)
        v20 = v19 * 4
        del v19
        v21 = 8 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method80(v22)
        del v22
        v24 = 0 <= v17
        if v24:
            v25 = v17 < 2
            v26 = v25
        else:
            v26 = False
        del v24
        v27 = v26 == False
        if v27:
            v28 = "The read index needs to be in range for the static array."
            assert v26, v28
            del v28
        else:
            pass
        del v26, v27
        v16[v17] = v23
        del v23
        v17 += 1 
    del v17
    v29 = v0[16:].view(cp.int32)
    v30 = v29[0].item()
    del v29
    v31 = static_array(2)
    v32 = 0
    while method46(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 20 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method80(v37)
        del v37
        v39 = 0 <= v32
        if v39:
            v40 = v32 < 2
            v41 = v40
        else:
            v41 = False
        del v39
        v42 = v41 == False
        if v42:
            v43 = "The read index needs to be in range for the static array."
            assert v41, v43
            del v43
        else:
            pass
        del v41, v42
        v31[v32] = v38
        del v38
        v32 += 1 
    del v32
    v44 = method96(v0)
    v45 = v0[32:].view(cp.uint8)
    del v0
    if v44 == 0:
        v47 = method97(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method87(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method98(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method99(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    return v2, v3, v16, v30, v31, v54
def method101(v0 : cp.ndarray) -> i32:
    v1 = v0[40:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method100(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method46(v4):
        v6 = u64(v4)
        v7 = v6 * 2
        del v6
        v8 = 4 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method95(v9)
        del v9
        v11 = 0 <= v4
        if v11:
            v12 = v4 < 2
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
        v3[v4] = v10
        del v10
        v4 += 1 
    del v4
    v16 = static_array(2)
    v17 = 0
    while method46(v17):
        v19 = u64(v17)
        v20 = v19 * 4
        del v19
        v21 = 8 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method80(v22)
        del v22
        v24 = 0 <= v17
        if v24:
            v25 = v17 < 2
            v26 = v25
        else:
            v26 = False
        del v24
        v27 = v26 == False
        if v27:
            v28 = "The read index needs to be in range for the static array."
            assert v26, v28
            del v28
        else:
            pass
        del v26, v27
        v16[v17] = v23
        del v23
        v17 += 1 
    del v17
    v29 = v0[16:].view(cp.int32)
    v30 = v29[0].item()
    del v29
    v31 = static_array(2)
    v32 = 0
    while method46(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 20 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method80(v37)
        del v37
        v39 = 0 <= v32
        if v39:
            v40 = v32 < 2
            v41 = v40
        else:
            v41 = False
        del v39
        v42 = v41 == False
        if v42:
            v43 = "The read index needs to be in range for the static array."
            assert v41, v43
            del v43
        else:
            pass
        del v41, v42
        v31[v32] = v38
        del v38
        v32 += 1 
    del v32
    v44 = method96(v0)
    v45 = v0[32:].view(cp.uint8)
    if v44 == 0:
        v47 = method97(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method87(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method98(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method99(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    v55 = method101(v0)
    v56 = v0[44:].view(cp.uint8)
    del v0
    if v55 == 0:
        method87(v56)
        v62 = US1_0()
    elif v55 == 1:
        method87(v56)
        v62 = US1_1()
    elif v55 == 2:
        v60 = method80(v56)
        v62 = US1_2(v60)
    else:
        raise Exception("Invalid tag.")
    del v55, v56
    return v2, v3, v16, v30, v31, v54, v62
def method93(v0 : cp.ndarray) -> US4:
    v1 = method80(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9 = method94(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9)
    elif v1 == 1:
        del v1
        v11, v12, v13, v14, v15, v16 = method94(v2)
        del v2
        return US4_1(v11, v12, v13, v14, v15, v16)
    elif v1 == 2:
        del v1
        method87(v2)
        del v2
        return US4_2()
    elif v1 == 3:
        del v1
        v19, v20, v21, v22, v23, v24 = method94(v2)
        del v2
        return US4_3(v19, v20, v21, v22, v23, v24)
    elif v1 == 4:
        del v1
        v26, v27, v28, v29, v30, v31 = method94(v2)
        del v2
        return US4_4(v26, v27, v28, v29, v30, v31)
    elif v1 == 5:
        del v1
        v33, v34, v35, v36, v37, v38, v39 = method100(v2)
        del v2
        return US4_5(v33, v34, v35, v36, v37, v38, v39)
    elif v1 == 6:
        del v1
        v41, v42, v43, v44, v45, v46 = method94(v2)
        del v2
        return US4_6(v41, v42, v43, v44, v45, v46)
    elif v1 == 7:
        del v1
        v48, v49, v50, v51, v52, v53 = method94(v2)
        del v2
        return US4_7(v48, v49, v50, v51, v52, v53)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method102(v0 : cp.ndarray) -> US2:
    v1 = method80(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method87(v2)
        del v2
        return US2_0()
    elif v1 == 1:
        del v1
        method87(v2)
        del v2
        return US2_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method103(v0 : cp.ndarray) -> i32:
    v1 = v0[6248:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method76(v0 : cp.ndarray) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = method77(v0)
    v2 = static_array_list(128)
    v3 = method78(v0)
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
        v11 = method79(v10)
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
    v18 = method92(v0)
    v19 = v0[6176:].view(cp.uint8)
    if v18 == 0:
        method87(v19)
        v24 = US3_0()
    elif v18 == 1:
        v22 = method93(v19)
        v24 = US3_1(v22)
    else:
        raise Exception("Invalid tag.")
    del v18, v19
    v25 = static_array(2)
    v26 = 0
    while method46(v26):
        v28 = u64(v26)
        v29 = v28 * 4
        del v28
        v30 = 6240 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method102(v31)
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
    v38 = method103(v0)
    v39 = v0[6256:].view(cp.uint8)
    del v0
    if v38 == 0:
        method87(v39)
        v56 = US6_0()
    elif v38 == 1:
        v42, v43, v44, v45, v46, v47 = method94(v39)
        v56 = US6_1(v42, v43, v44, v45, v46, v47)
    elif v38 == 2:
        v49, v50, v51, v52, v53, v54 = method94(v39)
        v56 = US6_2(v49, v50, v51, v52, v53, v54)
    else:
        raise Exception("Invalid tag.")
    del v38, v39
    return v1, v2, v24, v25, v56
def method105(v0 : cp.ndarray) -> i32:
    v1 = v0[6168:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method104(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US6]:
    v1 = static_array_list(128)
    v2 = method80(v0)
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
        v10 = method79(v9)
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
    while method46(v18):
        v20 = u64(v18)
        v21 = v20 * 4
        del v20
        v22 = 6160 + v21
        del v21
        v23 = v0[v22:].view(cp.uint8)
        del v22
        v24 = method102(v23)
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
    v30 = method105(v0)
    v31 = v0[6176:].view(cp.uint8)
    del v0
    if v30 == 0:
        method87(v31)
        v48 = US6_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39 = method94(v31)
        v48 = US6_1(v34, v35, v36, v37, v38, v39)
    elif v30 == 2:
        v41, v42, v43, v44, v45, v46 = method94(v31)
        v48 = US6_2(v41, v42, v43, v44, v45, v46)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v48
def method111(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method110(v0 : u64) -> object:
    return method111(v0)
def method116(v0 : u8) -> object:
    v1 = v0
    del v0
    return v1
def method115(v0 : u8) -> object:
    return method116(v0)
def method114(v0 : static_array_list) -> object:
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
        v12 = method115(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method118(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method117(v0 : i32, v1 : i32) -> object:
    v2 = method118(v0)
    del v0
    v3 = method118(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method121() -> object:
    v0 = []
    return v0
def method120(v0 : US1) -> object:
    match v0:
        case US1_0(): # A_Call
            del v0
            v1 = method121()
            v2 = "A_Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # A_Fold
            del v0
            v4 = method121()
            v5 = "A_Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(v7): # A_Raise
            del v0
            v8 = method118(v7)
            del v7
            v9 = "A_Raise"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method119(v0 : i32, v1 : US1) -> object:
    v2 = []
    v3 = method118(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method120(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method123(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method46(v2):
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
        v10 = method115(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method122(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method118(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method123(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method128(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method62(v2):
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
        v10 = method115(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method129(v0 : i8) -> object:
    v1 = v0
    del v0
    return v1
def method127(v0 : static_array, v1 : i8) -> object:
    v2 = method128(v0)
    del v0
    v3 = method129(v1)
    del v1
    v4 = {'hand': v2, 'score': v3}
    del v2, v3
    return v4
def method126(v0 : static_array, v1 : i8) -> object:
    return method127(v0, v1)
def method125(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method46(v2):
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
        v11 = method126(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method124(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method118(v0)
    del v0
    v4 = method125(v1)
    del v1
    v5 = method118(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method113(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method114(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method117(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method119(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method122(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method124(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method112(v0 : static_array_list) -> object:
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
        v12 = method113(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method109(v0 : u64, v1 : static_array_list) -> object:
    v2 = method110(v0)
    del v0
    v3 = method112(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method134(v0 : i32) -> object:
    v1 = method118(v0)
    del v0
    v2 = {'min_raise': v1}
    del v1
    return v2
def method135(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method46(v2):
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
        v10 = method123(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method136(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method46(v2):
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
        v10 = method118(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method138(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method69(v2):
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
        v10 = method115(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method139(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method72(v2):
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
        v10 = method115(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method137(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method138(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method121()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method128(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method139(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method133(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5) -> object:
    v6 = method134(v0)
    del v0
    v7 = method135(v1)
    del v1
    v8 = method136(v2)
    del v2
    v9 = method118(v3)
    del v3
    v10 = method136(v4)
    del v4
    v11 = method137(v5)
    del v5
    v12 = {'config': v6, 'pl_card': v7, 'pot': v8, 'round_turn': v9, 'stack': v10, 'street': v11}
    del v6, v7, v8, v9, v10, v11
    return v12
def method140(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5, v6 : US1) -> object:
    v7 = []
    v8 = method133(v0, v1, v2, v3, v4, v5)
    del v0, v1, v2, v3, v4, v5
    v7.append(v8)
    del v8
    v9 = method120(v6)
    del v6
    v7.append(v9)
    del v9
    v10 = v7
    del v7
    return v10
def method132(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # G_Flop
            del v0
            v7 = method133(v1, v2, v3, v4, v5, v6)
            del v1, v2, v3, v4, v5, v6
            v8 = "G_Flop"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v0
            v16 = method133(v10, v11, v12, v13, v14, v15)
            del v10, v11, v12, v13, v14, v15
            v17 = "G_Fold"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US4_2(): # G_Preflop
            del v0
            v19 = method121()
            v20 = "G_Preflop"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US4_3(v22, v23, v24, v25, v26, v27): # G_River
            del v0
            v28 = method133(v22, v23, v24, v25, v26, v27)
            del v22, v23, v24, v25, v26, v27
            v29 = "G_River"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US4_4(v31, v32, v33, v34, v35, v36): # G_Round
            del v0
            v37 = method133(v31, v32, v33, v34, v35, v36)
            del v31, v32, v33, v34, v35, v36
            v38 = "G_Round"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case US4_5(v40, v41, v42, v43, v44, v45, v46): # G_Round'
            del v0
            v47 = method140(v40, v41, v42, v43, v44, v45, v46)
            del v40, v41, v42, v43, v44, v45, v46
            v48 = "G_Round'"
            v49 = [v48,v47]
            del v47, v48
            return v49
        case US4_6(v50, v51, v52, v53, v54, v55): # G_Showdown
            del v0
            v56 = method133(v50, v51, v52, v53, v54, v55)
            del v50, v51, v52, v53, v54, v55
            v57 = "G_Showdown"
            v58 = [v57,v56]
            del v56, v57
            return v58
        case US4_7(v59, v60, v61, v62, v63, v64): # G_Turn
            del v0
            v65 = method133(v59, v60, v61, v62, v63, v64)
            del v59, v60, v61, v62, v63, v64
            v66 = "G_Turn"
            v67 = [v66,v65]
            del v65, v66
            return v67
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method131(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method121()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method132(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method142(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = method121()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = method121()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method141(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method46(v2):
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
        v10 = method142(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method143(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method121()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method133(v4, v5, v6, v7, v8, v9)
            del v4, v5, v6, v7, v8, v9
            v11 = "GameOver"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US6_2(v13, v14, v15, v16, v17, v18): # WaitingForActionFromPlayerId
            del v0
            v19 = method133(v13, v14, v15, v16, v17, v18)
            del v13, v14, v15, v16, v17, v18
            v20 = "WaitingForActionFromPlayerId"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method130(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method131(v0)
    del v0
    v4 = method141(v1)
    del v1
    v5 = method143(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method108(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method109(v0, v1)
    del v0, v1
    v6 = method130(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method144(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method112(v0)
    del v0
    v4 = method141(v1)
    del v1
    v5 = method143(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method107(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method108(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method144(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method106(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method107(v0, v1, v2, v3, v4, v5, v6, v7)
    del v0, v1, v2, v3, v4, v5, v6, v7
    return v8
def method146(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method108(v0, v1, v2, v3, v4)
    del v0, v2
    v6 = method144(v1, v3, v4)
    del v1, v3, v4
    v7 = {'game_state': v5, 'ui_state': v6}
    del v5, v6
    return v7
def method145(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method146(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("HU_Holdem_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
