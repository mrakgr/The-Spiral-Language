# Takes 37s for me.

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
struct US4;
struct US5;
struct Tuple0;
struct Tuple1;
struct US3;
struct US8;
struct US7;
struct US6;
struct US9;
struct Tuple2;
__device__ unsigned long long f_7(unsigned char * v0);
__device__ long f_8(unsigned char * v0);
__device__ long f_12(unsigned char * v0);
__device__ Tuple0 f_11(unsigned char * v0);
__device__ static_array_list<Tuple0,5l,long> f_10(unsigned char * v0);
struct Tuple3;
__device__ Tuple3 f_13(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_14(unsigned char * v0);
struct Tuple5;
__device__ Tuple5 f_15(unsigned char * v0);
struct Tuple6;
__device__ unsigned char f_20(unsigned char * v0);
__device__ unsigned char f_19(unsigned char * v0);
__device__ Tuple1 f_18(unsigned char * v0);
__device__ Tuple1 f_17(unsigned char * v0);
__device__ Tuple6 f_16(unsigned char * v0);
__device__ US3 f_9(unsigned char * v0);
__device__ long f_21(unsigned char * v0);
struct Tuple7;
__device__ static_array<Tuple0,2l> f_24(unsigned char * v0);
__device__ long f_25(unsigned char * v0);
__device__ static_array<Tuple0,3l> f_26(unsigned char * v0);
__device__ static_array<Tuple0,5l> f_27(unsigned char * v0);
__device__ static_array<Tuple0,4l> f_28(unsigned char * v0);
__device__ Tuple7 f_23(unsigned char * v0);
struct Tuple8;
__device__ long f_30(unsigned char * v0);
__device__ Tuple8 f_29(unsigned char * v0);
__device__ US7 f_22(unsigned char * v0);
__device__ long f_31(unsigned char * v0);
__device__ Tuple2 f_6(unsigned char * v0);
struct Tuple9;
struct Tuple10;
struct Tuple11;
struct Tuple12;
struct Tuple13;
__device__ unsigned long loop_36(unsigned long v0, curandStatePhilox4_32_10_t & v1);
__device__ Tuple13 draw_card_35(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ Tuple11 draw_cards_34(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ US4 card_rank_untag_38(unsigned char v0);
__device__ US5 card_suit_untag_39(unsigned char v0);
__device__ Tuple0 card_from_lib_card_37(unsigned char v0);
__device__ static_array_list<Tuple0,5l,long> get_community_cards_40(US8 v0, static_array<Tuple0,3l> v1);
__device__ bool player_can_act_42(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5);
__device__ US7 go_next_street_43(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5);
__device__ US7 try_round_41(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5);
struct Tuple14;
__device__ Tuple14 draw_cards_44(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
struct Tuple15;
__device__ Tuple15 draw_cards_45(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ static_array_list<Tuple0,5l,long> get_community_cards_46(US8 v0, static_array<Tuple0,1l> v1);
struct Tuple16;
__device__ long loop_49(static_array<float,6l> v0, float v1, long v2);
__device__ long sample_discrete__48(static_array<float,6l> v0, curandStatePhilox4_32_10_t & v1);
__device__ US1 sample_discrete_47(static_array<Tuple16,6l> v0, curandStatePhilox4_32_10_t & v1);
__device__ unsigned char card_rank_tag_51(US4 v0);
__device__ unsigned char card_suit_tag_52(US5 v0);
__device__ unsigned char lib_card_from_card_50(US5 v0, US4 v1);
struct Tuple17;
struct Tuple18;
struct US10;
struct Tuple19;
struct US11;
struct Tuple20;
struct Tuple21;
struct US12;
struct US13;
struct US14;
struct US15;
struct US16;
__device__ Tuple1 score_53(static_array<unsigned char,7l> v0);
__device__ US7 play_loop_inner_33(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US7 v4);
__device__ Tuple9 play_loop_32(US6 v0, static_array<US2,2l> v1, US9 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US7 v6);
__device__ void f_55(unsigned char * v0, unsigned long long v1);
__device__ void f_56(unsigned char * v0, long v1);
__device__ void f_58(unsigned char * v0, long v1);
__device__ void f_61(unsigned char * v0);
__device__ void f_62(unsigned char * v0, long v1);
__device__ void f_60(unsigned char * v0, US4 v1, US5 v2);
__device__ void f_59(unsigned char * v0, static_array_list<Tuple0,5l,long> v1);
__device__ void f_63(unsigned char * v0, long v1, long v2);
__device__ void f_64(unsigned char * v0, long v1, US1 v2);
__device__ void f_65(unsigned char * v0, long v1, static_array<Tuple0,2l> v2);
__device__ void f_70(unsigned char * v0, unsigned char v1);
__device__ void f_69(unsigned char * v0, unsigned char v1);
__device__ void f_68(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_67(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_66(unsigned char * v0, long v1, static_array<Tuple1,2l> v2, long v3);
__device__ void f_57(unsigned char * v0, US3 v1);
__device__ void f_71(unsigned char * v0, long v1);
__device__ void f_74(unsigned char * v0, static_array<Tuple0,2l> v1);
__device__ void f_75(unsigned char * v0, long v1);
__device__ void f_76(unsigned char * v0, static_array<Tuple0,3l> v1);
__device__ void f_77(unsigned char * v0, static_array<Tuple0,5l> v1);
__device__ void f_78(unsigned char * v0, static_array<Tuple0,4l> v1);
__device__ void f_73(unsigned char * v0, long v1, static_array<static_array<Tuple0,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US8 v6);
__device__ void f_80(unsigned char * v0, long v1);
__device__ void f_79(unsigned char * v0, long v1, static_array<static_array<Tuple0,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US8 v6, US1 v7);
__device__ void f_72(unsigned char * v0, US7 v1);
__device__ void f_81(unsigned char * v0, US2 v1);
__device__ void f_82(unsigned char * v0, long v1);
__device__ void f_54(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US6 v3, static_array<US2,2l> v4, US9 v5);
__device__ void f_84(unsigned char * v0, long v1);
__device__ void f_83(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US9 v3);
struct US1 {
    union {
        struct {
            long v0;
        } case3; // A_Raise
    } v;
    unsigned char tag;
};
struct US2 {
    union {
    } v;
    unsigned char tag;
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
    unsigned char tag;
};
struct US4 {
    union {
    } v;
    unsigned char tag;
};
struct US5 {
    union {
    } v;
    unsigned char tag;
};
struct Tuple0 {
    US4 v0;
    US5 v1;
    __device__ Tuple0(US4 t0, US5 t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    static_array<unsigned char,5l> v0;
    char v1;
    __device__ Tuple1(static_array<unsigned char,5l> t0, char t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct US3 {
    union {
        struct {
            static_array_list<Tuple0,5l,long> v0;
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
            static_array<Tuple0,2l> v1;
            long v0;
        } case3; // PlayerGotCards
        struct {
            static_array<Tuple1,2l> v1;
            long v0;
            long v2;
        } case4; // Showdown
    } v;
    unsigned char tag;
};
struct US8 {
    union {
        struct {
            static_array<Tuple0,3l> v0;
        } case0; // Flop
        struct {
            static_array<Tuple0,5l> v0;
        } case2; // River
        struct {
            static_array<Tuple0,4l> v0;
        } case3; // Turn
    } v;
    unsigned char tag;
};
struct US7 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case0; // G_Flop
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case1; // G_Fold
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case3; // G_River
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case4; // G_Round
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            US1 v6;
            long v0;
            long v3;
        } case5; // G_Round'
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case6; // G_Showdown
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case7; // G_Turn
    } v;
    unsigned char tag;
};
struct US6 {
    union {
        struct {
            US7 v0;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct US9 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case1; // GameOver
        struct {
            static_array<static_array<Tuple0,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US8 v5;
            long v0;
            long v3;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned char tag;
};
struct Tuple2 {
    unsigned long long v0;
    static_array_list<US3,128l,long> v1;
    US6 v2;
    static_array<US2,2l> v3;
    US9 v4;
    __device__ Tuple2(unsigned long long t0, static_array_list<US3,128l,long> t1, US6 t2, static_array<US2,2l> t3, US9 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    long v0;
    long v1;
    __device__ Tuple3(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    US1 v1;
    long v0;
    __device__ Tuple4(long t0, US1 t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    static_array<Tuple0,2l> v1;
    long v0;
    __device__ Tuple5(long t0, static_array<Tuple0,2l> t1) : v0(t0), v1(t1) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    static_array<Tuple1,2l> v1;
    long v0;
    long v2;
    __device__ Tuple6(long t0, static_array<Tuple1,2l> t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<Tuple0,2l>,2l> v1;
    static_array<long,2l> v2;
    static_array<long,2l> v4;
    US8 v5;
    long v0;
    long v3;
    __device__ Tuple7(long t0, static_array<static_array<Tuple0,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US8 t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    __device__ Tuple7() = default;
};
struct Tuple8 {
    static_array<static_array<Tuple0,2l>,2l> v1;
    static_array<long,2l> v2;
    static_array<long,2l> v4;
    US8 v5;
    US1 v6;
    long v0;
    long v3;
    __device__ Tuple8(long t0, static_array<static_array<Tuple0,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US8 t5, US1 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple8() = default;
};
struct Tuple9 {
    US6 v0;
    static_array<US2,2l> v1;
    US9 v2;
    __device__ Tuple9(US6 t0, static_array<US2,2l> t1, US9 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple9() = default;
};
struct Tuple10 {
    US7 v1;
    bool v0;
    __device__ Tuple10(bool t0, US7 t1) : v0(t0), v1(t1) {}
    __device__ Tuple10() = default;
};
struct Tuple11 {
    static_array<unsigned char,3l> v0;
    unsigned long long v1;
    __device__ Tuple11(static_array<unsigned char,3l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple11() = default;
};
struct Tuple12 {
    unsigned long long v1;
    long v0;
    __device__ Tuple12(long t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple12() = default;
};
struct Tuple13 {
    unsigned long long v1;
    unsigned char v0;
    __device__ Tuple13(unsigned char t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple13() = default;
};
struct Tuple14 {
    static_array<unsigned char,2l> v0;
    unsigned long long v1;
    __device__ Tuple14(static_array<unsigned char,2l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple14() = default;
};
struct Tuple15 {
    static_array<unsigned char,1l> v0;
    unsigned long long v1;
    __device__ Tuple15(static_array<unsigned char,1l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple15() = default;
};
struct Tuple16 {
    US1 v0;
    float v1;
    __device__ Tuple16(US1 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple16() = default;
};
struct Tuple17 {
    long v1;
    bool v0;
    __device__ Tuple17(bool t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple17() = default;
};
struct Tuple18 {
    long v0;
    long v1;
    long v2;
    __device__ Tuple18(long t0, long t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple18() = default;
};
struct US10 {
    union {
    } v;
    unsigned char tag;
};
struct Tuple19 {
    long v0;
    long v1;
    unsigned char v2;
    __device__ Tuple19(long t0, long t1, unsigned char t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple19() = default;
};
struct US11 {
    union {
        struct {
            static_array<unsigned char,5l> v0;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct Tuple20 {
    US10 v1;
    long v0;
    __device__ Tuple20(long t0, US10 t1) : v0(t0), v1(t1) {}
    __device__ Tuple20() = default;
};
struct Tuple21 {
    long v0;
    long v1;
    long v2;
    unsigned char v3;
    __device__ Tuple21(long t0, long t1, long t2, unsigned char t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple21() = default;
};
struct US12 {
    union {
        struct {
            static_array<unsigned char,4l> v0;
            static_array<unsigned char,3l> v1;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct US13 {
    union {
        struct {
            static_array<unsigned char,3l> v0;
            static_array<unsigned char,4l> v1;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct US14 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,2l> v1;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct US15 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,5l> v1;
        } case1; // Some
    } v;
    unsigned char tag;
};
struct US16 {
    union {
        struct {
            static_array<unsigned char,2l> v0;
            static_array<unsigned char,3l> v1;
        } case1; // Some
    } v;
    unsigned char tag;
};
__device__ US1 US1_0() { // A_All_In
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // A_Call
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2() { // A_Fold
    US1 x;
    x.tag = 2;
    return x;
}
__device__ US1 US1_3(long v0) { // A_Raise
    US1 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
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
        case 3: {
            long v7;
            v7 = f_1(v2);
            return US1_3(v7);
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
__device__ US4 US4_0() { // Ace
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1() { // Eight
    US4 x;
    x.tag = 1;
    return x;
}
__device__ US4 US4_2() { // Five
    US4 x;
    x.tag = 2;
    return x;
}
__device__ US4 US4_3() { // Four
    US4 x;
    x.tag = 3;
    return x;
}
__device__ US4 US4_4() { // Jack
    US4 x;
    x.tag = 4;
    return x;
}
__device__ US4 US4_5() { // King
    US4 x;
    x.tag = 5;
    return x;
}
__device__ US4 US4_6() { // Nine
    US4 x;
    x.tag = 6;
    return x;
}
__device__ US4 US4_7() { // Queen
    US4 x;
    x.tag = 7;
    return x;
}
__device__ US4 US4_8() { // Seven
    US4 x;
    x.tag = 8;
    return x;
}
__device__ US4 US4_9() { // Six
    US4 x;
    x.tag = 9;
    return x;
}
__device__ US4 US4_10() { // Ten
    US4 x;
    x.tag = 10;
    return x;
}
__device__ US4 US4_11() { // Three
    US4 x;
    x.tag = 11;
    return x;
}
__device__ US4 US4_12() { // Two
    US4 x;
    x.tag = 12;
    return x;
}
__device__ US5 US5_0() { // Clubs
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1() { // Diamonds
    US5 x;
    x.tag = 1;
    return x;
}
__device__ US5 US5_2() { // Hearts
    US5 x;
    x.tag = 2;
    return x;
}
__device__ US5 US5_3() { // Spades
    US5 x;
    x.tag = 3;
    return x;
}
__device__ US3 US3_0(static_array_list<Tuple0,5l,long> v0) { // CommunityCardsAre
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
__device__ US3 US3_3(long v0, static_array<Tuple0,2l> v1) { // PlayerGotCards
    US3 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1;
    return x;
}
__device__ US3 US3_4(long v0, static_array<Tuple1,2l> v1, long v2) { // Showdown
    US3 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2;
    return x;
}
__device__ US8 US8_0(static_array<Tuple0,3l> v0) { // Flop
    US8 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US8 US8_1() { // Preflop
    US8 x;
    x.tag = 1;
    return x;
}
__device__ US8 US8_2(static_array<Tuple0,5l> v0) { // River
    US8 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US8 US8_3(static_array<Tuple0,4l> v0) { // Turn
    US8 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US7 US7_0(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_Flop
    US7 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5;
    return x;
}
__device__ US7 US7_1(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_Fold
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US7 US7_2() { // G_Preflop
    US7 x;
    x.tag = 2;
    return x;
}
__device__ US7 US7_3(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_River
    US7 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5;
    return x;
}
__device__ US7 US7_4(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_Round
    US7 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US7 US7_5(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5, US1 v6) { // G_Round'
    US7 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6;
    return x;
}
__device__ US7 US7_6(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_Showdown
    US7 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5;
    return x;
}
__device__ US7 US7_7(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // G_Turn
    US7 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5;
    return x;
}
__device__ US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
__device__ US6 US6_1(US7 v0) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US9 US9_0() { // GameNotStarted
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // GameOver
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US9 US9_2(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5) { // WaitingForActionFromPlayerId
    US9 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ unsigned long long f_7(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+0ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_8(unsigned char * v0){
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
__device__ long f_12(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple0 f_11(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    US4 v17;
    switch (v1) {
        case 0: {
            f_3(v2);
            v17 = US4_0();
            break;
        }
        case 1: {
            f_3(v2);
            v17 = US4_1();
            break;
        }
        case 2: {
            f_3(v2);
            v17 = US4_2();
            break;
        }
        case 3: {
            f_3(v2);
            v17 = US4_3();
            break;
        }
        case 4: {
            f_3(v2);
            v17 = US4_4();
            break;
        }
        case 5: {
            f_3(v2);
            v17 = US4_5();
            break;
        }
        case 6: {
            f_3(v2);
            v17 = US4_6();
            break;
        }
        case 7: {
            f_3(v2);
            v17 = US4_7();
            break;
        }
        case 8: {
            f_3(v2);
            v17 = US4_8();
            break;
        }
        case 9: {
            f_3(v2);
            v17 = US4_9();
            break;
        }
        case 10: {
            f_3(v2);
            v17 = US4_10();
            break;
        }
        case 11: {
            f_3(v2);
            v17 = US4_11();
            break;
        }
        case 12: {
            f_3(v2);
            v17 = US4_12();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v18;
    v18 = f_12(v0);
    unsigned char * v19;
    v19 = (unsigned char *)(v0+8ull);
    US5 v25;
    switch (v18) {
        case 0: {
            f_3(v19);
            v25 = US5_0();
            break;
        }
        case 1: {
            f_3(v19);
            v25 = US5_1();
            break;
        }
        case 2: {
            f_3(v19);
            v25 = US5_2();
            break;
        }
        case 3: {
            f_3(v19);
            v25 = US5_3();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple0(v17, v25);
}
__device__ static_array_list<Tuple0,5l,long> f_10(unsigned char * v0){
    static_array_list<Tuple0,5l,long> v1;
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
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US4 v10; US5 v11;
        Tuple0 tmp0 = f_11(v9);
        v10 = tmp0.v0; v11 = tmp0.v1;
        bool v12;
        v12 = 0l <= v4;
        bool v15;
        if (v12){
            long v13;
            v13 = v1.length;
            bool v14;
            v14 = v4 < v13;
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
        v1.v[v4] = Tuple0(v10, v11);
        v4 += 1l ;
    }
    return v1;
}
__device__ Tuple3 f_13(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long * v3;
    v3 = (long *)(v0+4ull);
    long v4;
    v4 = v3[0l];
    return Tuple3(v2, v4);
}
__device__ Tuple4 f_14(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_12(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US1 v11;
    switch (v3) {
        case 0: {
            f_3(v4);
            v11 = US1_0();
            break;
        }
        case 1: {
            f_3(v4);
            v11 = US1_1();
            break;
        }
        case 2: {
            f_3(v4);
            v11 = US1_2();
            break;
        }
        case 3: {
            long v9;
            v9 = f_1(v4);
            v11 = US1_3(v9);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple4(v2, v11);
}
__device__ Tuple5 f_15(unsigned char * v0){
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
        US4 v10; US5 v11;
        Tuple0 tmp3 = f_11(v9);
        v10 = tmp3.v0; v11 = tmp3.v1;
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
    return Tuple5(v2, v3);
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
__device__ unsigned char f_20(unsigned char * v0){
    unsigned char * v1;
    v1 = (unsigned char *)(v0+0ull);
    unsigned char v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned char f_19(unsigned char * v0){
    unsigned char v1;
    v1 = f_20(v0);
    return v1;
}
__device__ Tuple1 f_18(unsigned char * v0){
    static_array<unsigned char,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_19(v5);
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
    return Tuple1(v1, v12);
}
__device__ Tuple1 f_17(unsigned char * v0){
    static_array<unsigned char,5l> v1; char v2;
    Tuple1 tmp5 = f_18(v0);
    v1 = tmp5.v0; v2 = tmp5.v1;
    return Tuple1(v1, v2);
}
__device__ Tuple6 f_16(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<Tuple1,2l> v3;
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
        Tuple1 tmp6 = f_17(v9);
        v10 = tmp6.v0; v11 = tmp6.v1;
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
        v3.v[v4] = Tuple1(v10, v11);
        v4 += 1l ;
    }
    long * v16;
    v16 = (long *)(v0+24ull);
    long v17;
    v17 = v16[0l];
    return Tuple6(v2, v3, v17);
}
__device__ US3 f_9(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array_list<Tuple0,5l,long> v4;
            v4 = f_10(v2);
            return US3_0(v4);
            break;
        }
        case 1: {
            long v6; long v7;
            Tuple3 tmp1 = f_13(v2);
            v6 = tmp1.v0; v7 = tmp1.v1;
            return US3_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US1 v10;
            Tuple4 tmp2 = f_14(v2);
            v9 = tmp2.v0; v10 = tmp2.v1;
            return US3_2(v9, v10);
            break;
        }
        case 3: {
            long v12; static_array<Tuple0,2l> v13;
            Tuple5 tmp4 = f_15(v2);
            v12 = tmp4.v0; v13 = tmp4.v1;
            return US3_3(v12, v13);
            break;
        }
        case 4: {
            long v15; static_array<Tuple1,2l> v16; long v17;
            Tuple6 tmp7 = f_16(v2);
            v15 = tmp7.v0; v16 = tmp7.v1; v17 = tmp7.v2;
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
    v1 = (long *)(v0+8208ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ static_array<Tuple0,2l> f_24(unsigned char * v0){
    static_array<Tuple0,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US4 v7; US5 v8;
        Tuple0 tmp8 = f_11(v6);
        v7 = tmp8.v0; v8 = tmp8.v1;
        bool v9;
        v9 = 0l <= v2;
        bool v11;
        if (v9){
            bool v10;
            v10 = v2 < 2l;
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
        v1.v[v2] = Tuple0(v7, v8);
        v2 += 1l ;
    }
    return v1;
}
__device__ long f_25(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+68ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ inline bool while_method_3(long v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ static_array<Tuple0,3l> f_26(unsigned char * v0){
    static_array<Tuple0,3l> v1;
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US4 v7; US5 v8;
        Tuple0 tmp9 = f_11(v6);
        v7 = tmp9.v0; v8 = tmp9.v1;
        bool v9;
        v9 = 0l <= v2;
        bool v11;
        if (v9){
            bool v10;
            v10 = v2 < 3l;
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
        v1.v[v2] = Tuple0(v7, v8);
        v2 += 1l ;
    }
    return v1;
}
__device__ static_array<Tuple0,5l> f_27(unsigned char * v0){
    static_array<Tuple0,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US4 v7; US5 v8;
        Tuple0 tmp10 = f_11(v6);
        v7 = tmp10.v0; v8 = tmp10.v1;
        bool v9;
        v9 = 0l <= v2;
        bool v11;
        if (v9){
            bool v10;
            v10 = v2 < 5l;
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
        v1.v[v2] = Tuple0(v7, v8);
        v2 += 1l ;
    }
    return v1;
}
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ static_array<Tuple0,4l> f_28(unsigned char * v0){
    static_array<Tuple0,4l> v1;
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US4 v7; US5 v8;
        Tuple0 tmp11 = f_11(v6);
        v7 = tmp11.v0; v8 = tmp11.v1;
        bool v9;
        v9 = 0l <= v2;
        bool v11;
        if (v9){
            bool v10;
            v10 = v2 < 4l;
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
        v1.v[v2] = Tuple0(v7, v8);
        v2 += 1l ;
    }
    return v1;
}
__device__ Tuple7 f_23(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<static_array<Tuple0,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 16ull;
        unsigned long long v8;
        v8 = 16ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<Tuple0,2l> v10;
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
        v20 = 48ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_1(v21);
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
    v27 = (long *)(v0+56ull);
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
        v34 = 60ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_1(v35);
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
    v42 = (unsigned char *)(v0+80ull);
    US8 v51;
    switch (v41) {
        case 0: {
            static_array<Tuple0,3l> v44;
            v44 = f_26(v42);
            v51 = US8_0(v44);
            break;
        }
        case 1: {
            f_3(v42);
            v51 = US8_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v47;
            v47 = f_27(v42);
            v51 = US8_2(v47);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v49;
            v49 = f_28(v42);
            v51 = US8_3(v49);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple7(v2, v3, v15, v28, v29, v51);
}
__device__ long f_30(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+128ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple8 f_29(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<static_array<Tuple0,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 16ull;
        unsigned long long v8;
        v8 = 16ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<Tuple0,2l> v10;
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
        v20 = 48ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_1(v21);
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
    v27 = (long *)(v0+56ull);
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
        v34 = 60ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_1(v35);
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
    v42 = (unsigned char *)(v0+80ull);
    US8 v51;
    switch (v41) {
        case 0: {
            static_array<Tuple0,3l> v44;
            v44 = f_26(v42);
            v51 = US8_0(v44);
            break;
        }
        case 1: {
            f_3(v42);
            v51 = US8_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v47;
            v47 = f_27(v42);
            v51 = US8_2(v47);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v49;
            v49 = f_28(v42);
            v51 = US8_3(v49);
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
    v53 = (unsigned char *)(v0+132ull);
    US1 v60;
    switch (v52) {
        case 0: {
            f_3(v53);
            v60 = US1_0();
            break;
        }
        case 1: {
            f_3(v53);
            v60 = US1_1();
            break;
        }
        case 2: {
            f_3(v53);
            v60 = US1_2();
            break;
        }
        case 3: {
            long v58;
            v58 = f_1(v53);
            v60 = US1_3(v58);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple8(v2, v3, v15, v28, v29, v51, v60);
}
__device__ US7 f_22(unsigned char * v0){
    long v1;
    v1 = f_1(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; static_array<static_array<Tuple0,2l>,2l> v5; static_array<long,2l> v6; long v7; static_array<long,2l> v8; US8 v9;
            Tuple7 tmp12 = f_23(v2);
            v4 = tmp12.v0; v5 = tmp12.v1; v6 = tmp12.v2; v7 = tmp12.v3; v8 = tmp12.v4; v9 = tmp12.v5;
            return US7_0(v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: {
            long v11; static_array<static_array<Tuple0,2l>,2l> v12; static_array<long,2l> v13; long v14; static_array<long,2l> v15; US8 v16;
            Tuple7 tmp13 = f_23(v2);
            v11 = tmp13.v0; v12 = tmp13.v1; v13 = tmp13.v2; v14 = tmp13.v3; v15 = tmp13.v4; v16 = tmp13.v5;
            return US7_1(v11, v12, v13, v14, v15, v16);
            break;
        }
        case 2: {
            f_3(v2);
            return US7_2();
            break;
        }
        case 3: {
            long v19; static_array<static_array<Tuple0,2l>,2l> v20; static_array<long,2l> v21; long v22; static_array<long,2l> v23; US8 v24;
            Tuple7 tmp14 = f_23(v2);
            v19 = tmp14.v0; v20 = tmp14.v1; v21 = tmp14.v2; v22 = tmp14.v3; v23 = tmp14.v4; v24 = tmp14.v5;
            return US7_3(v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: {
            long v26; static_array<static_array<Tuple0,2l>,2l> v27; static_array<long,2l> v28; long v29; static_array<long,2l> v30; US8 v31;
            Tuple7 tmp15 = f_23(v2);
            v26 = tmp15.v0; v27 = tmp15.v1; v28 = tmp15.v2; v29 = tmp15.v3; v30 = tmp15.v4; v31 = tmp15.v5;
            return US7_4(v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: {
            long v33; static_array<static_array<Tuple0,2l>,2l> v34; static_array<long,2l> v35; long v36; static_array<long,2l> v37; US8 v38; US1 v39;
            Tuple8 tmp16 = f_29(v2);
            v33 = tmp16.v0; v34 = tmp16.v1; v35 = tmp16.v2; v36 = tmp16.v3; v37 = tmp16.v4; v38 = tmp16.v5; v39 = tmp16.v6;
            return US7_5(v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: {
            long v41; static_array<static_array<Tuple0,2l>,2l> v42; static_array<long,2l> v43; long v44; static_array<long,2l> v45; US8 v46;
            Tuple7 tmp17 = f_23(v2);
            v41 = tmp17.v0; v42 = tmp17.v1; v43 = tmp17.v2; v44 = tmp17.v3; v45 = tmp17.v4; v46 = tmp17.v5;
            return US7_6(v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: {
            long v48; static_array<static_array<Tuple0,2l>,2l> v49; static_array<long,2l> v50; long v51; static_array<long,2l> v52; US8 v53;
            Tuple7 tmp18 = f_23(v2);
            v48 = tmp18.v0; v49 = tmp18.v1; v50 = tmp18.v2; v51 = tmp18.v3; v52 = tmp18.v4; v53 = tmp18.v5;
            return US7_7(v48, v49, v50, v51, v52, v53);
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
    v1 = (long *)(v0+8392ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple2 f_6(unsigned char * v0){
    unsigned long long v1;
    v1 = f_7(v0);
    static_array_list<US3,128l,long> v2;
    v2.length = 0;
    long v3;
    v3 = f_8(v0);
    v2.length = v3;
    long v4;
    v4 = v2.length;
    long v5;
    v5 = 0l;
    while (while_method_1(v4, v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 64ull;
        unsigned long long v9;
        v9 = 16ull + v8;
        unsigned char * v10;
        v10 = (unsigned char *)(v0+v9);
        US3 v11;
        v11 = f_9(v10);
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
    v18 = (unsigned char *)(v0+8224ull);
    US6 v23;
    switch (v17) {
        case 0: {
            f_3(v18);
            v23 = US6_0();
            break;
        }
        case 1: {
            US7 v21;
            v21 = f_22(v18);
            v23 = US6_1(v21);
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
        v29 = 8384ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        US2 v31;
        v31 = f_5(v30);
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
    v37 = (unsigned char *)(v0+8400ull);
    US9 v54;
    switch (v36) {
        case 0: {
            f_3(v37);
            v54 = US9_0();
            break;
        }
        case 1: {
            long v40; static_array<static_array<Tuple0,2l>,2l> v41; static_array<long,2l> v42; long v43; static_array<long,2l> v44; US8 v45;
            Tuple7 tmp19 = f_23(v37);
            v40 = tmp19.v0; v41 = tmp19.v1; v42 = tmp19.v2; v43 = tmp19.v3; v44 = tmp19.v4; v45 = tmp19.v5;
            v54 = US9_1(v40, v41, v42, v43, v44, v45);
            break;
        }
        case 2: {
            long v47; static_array<static_array<Tuple0,2l>,2l> v48; static_array<long,2l> v49; long v50; static_array<long,2l> v51; US8 v52;
            Tuple7 tmp20 = f_23(v37);
            v47 = tmp20.v0; v48 = tmp20.v1; v49 = tmp20.v2; v50 = tmp20.v3; v51 = tmp20.v4; v52 = tmp20.v5;
            v54 = US9_2(v47, v48, v49, v50, v51, v52);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple2(v1, v2, v23, v24, v54);
}
__device__ inline bool while_method_5(bool v0, US7 v1){
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
__device__ Tuple13 draw_card_35(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
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
    long v19;
    v19 = (long)v17;
    unsigned long long v20;
    v20 = 1ull << v19;
    unsigned long long v21;
    v21 = v1 ^ v20;
    return Tuple13(v18, v21);
}
__device__ Tuple11 draw_cards_34(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,3l> v2;
    long v3; unsigned long long v4;
    Tuple12 tmp23 = Tuple12(0l, v1);
    v3 = tmp23.v0; v4 = tmp23.v1;
    while (while_method_3(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple13 tmp24 = draw_card_35(v0, v4);
        v6 = tmp24.v0; v7 = tmp24.v1;
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
    return Tuple11(v2, v4);
}
__device__ US4 card_rank_untag_38(unsigned char v0){
    bool v1;
    v1 = 12u == v0;
    if (v1){
        return US4_0();
    } else {
        bool v3;
        v3 = 11u == v0;
        if (v3){
            return US4_5();
        } else {
            bool v5;
            v5 = 10u == v0;
            if (v5){
                return US4_7();
            } else {
                bool v7;
                v7 = 9u == v0;
                if (v7){
                    return US4_4();
                } else {
                    bool v9;
                    v9 = 8u == v0;
                    if (v9){
                        return US4_10();
                    } else {
                        bool v11;
                        v11 = 7u == v0;
                        if (v11){
                            return US4_6();
                        } else {
                            bool v13;
                            v13 = 6u == v0;
                            if (v13){
                                return US4_1();
                            } else {
                                bool v15;
                                v15 = 5u == v0;
                                if (v15){
                                    return US4_8();
                                } else {
                                    bool v17;
                                    v17 = 4u == v0;
                                    if (v17){
                                        return US4_9();
                                    } else {
                                        bool v19;
                                        v19 = 3u == v0;
                                        if (v19){
                                            return US4_2();
                                        } else {
                                            bool v21;
                                            v21 = 2u == v0;
                                            if (v21){
                                                return US4_3();
                                            } else {
                                                bool v23;
                                                v23 = 1u == v0;
                                                if (v23){
                                                    return US4_11();
                                                } else {
                                                    bool v25;
                                                    v25 = 0u == v0;
                                                    if (v25){
                                                        return US4_12();
                                                    } else {
                                                        printf("%s\n", "Invalid tag in card_rank_untag");
                                                        asm("exit;");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
__device__ US5 card_suit_untag_39(unsigned char v0){
    bool v1;
    v1 = 3u == v0;
    if (v1){
        return US5_2();
    } else {
        bool v3;
        v3 = 2u == v0;
        if (v3){
            return US5_3();
        } else {
            bool v5;
            v5 = 1u == v0;
            if (v5){
                return US5_0();
            } else {
                bool v7;
                v7 = 0u == v0;
                if (v7){
                    return US5_1();
                } else {
                    printf("%s\n", "Invalid tag in card_suit_untag");
                    asm("exit;");
                }
            }
        }
    }
}
__device__ Tuple0 card_from_lib_card_37(unsigned char v0){
    unsigned char v1;
    v1 = v0 / 4u;
    US4 v2;
    v2 = card_rank_untag_38(v1);
    unsigned char v3;
    v3 = v0 % 4u;
    US5 v4;
    v4 = card_suit_untag_39(v3);
    return Tuple0(v2, v4);
}
__device__ static_array_list<Tuple0,5l,long> get_community_cards_40(US8 v0, static_array<Tuple0,3l> v1){
    static_array_list<Tuple0,5l,long> v2;
    v2.length = 0;
    switch (v0.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v3 = v0.v.case0.v0;
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
                US4 v10; US5 v11;
                Tuple0 tmp27 = v3.v[v4];
                v10 = tmp27.v0; v11 = tmp27.v1;
                long v12;
                v12 = v2.length;
                bool v13;
                v13 = v12 < 5l;
                bool v14;
                v14 = v13 == false;
                if (v14){
                    assert("The length has to be less than the maximum length of the array." && v13);
                } else {
                }
                long v15;
                v15 = v12 + 1l;
                v2.length = v15;
                bool v16;
                v16 = 0l <= v12;
                bool v19;
                if (v16){
                    long v17;
                    v17 = v2.length;
                    bool v18;
                    v18 = v12 < v17;
                    v19 = v18;
                } else {
                    v19 = false;
                }
                bool v20;
                v20 = v19 == false;
                if (v20){
                    assert("The set index needs to be in range for the static array list." && v19);
                } else {
                }
                v2.v[v12] = Tuple0(v10, v11);
                v4 += 1l ;
            }
            break;
        }
        case 1: { // Preflop
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v39 = v0.v.case2.v0;
            long v40;
            v40 = 0l;
            while (while_method_2(v40)){
                bool v42;
                v42 = 0l <= v40;
                bool v44;
                if (v42){
                    bool v43;
                    v43 = v40 < 5l;
                    v44 = v43;
                } else {
                    v44 = false;
                }
                bool v45;
                v45 = v44 == false;
                if (v45){
                    assert("The read index needs to be in range for the static array." && v44);
                } else {
                }
                US4 v46; US5 v47;
                Tuple0 tmp28 = v39.v[v40];
                v46 = tmp28.v0; v47 = tmp28.v1;
                long v48;
                v48 = v2.length;
                bool v49;
                v49 = v48 < 5l;
                bool v50;
                v50 = v49 == false;
                if (v50){
                    assert("The length has to be less than the maximum length of the array." && v49);
                } else {
                }
                long v51;
                v51 = v48 + 1l;
                v2.length = v51;
                bool v52;
                v52 = 0l <= v48;
                bool v55;
                if (v52){
                    long v53;
                    v53 = v2.length;
                    bool v54;
                    v54 = v48 < v53;
                    v55 = v54;
                } else {
                    v55 = false;
                }
                bool v56;
                v56 = v55 == false;
                if (v56){
                    assert("The set index needs to be in range for the static array list." && v55);
                } else {
                }
                v2.v[v48] = Tuple0(v46, v47);
                v40 += 1l ;
            }
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v21 = v0.v.case3.v0;
            long v22;
            v22 = 0l;
            while (while_method_4(v22)){
                bool v24;
                v24 = 0l <= v22;
                bool v26;
                if (v24){
                    bool v25;
                    v25 = v22 < 4l;
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
                US4 v28; US5 v29;
                Tuple0 tmp29 = v21.v[v22];
                v28 = tmp29.v0; v29 = tmp29.v1;
                long v30;
                v30 = v2.length;
                bool v31;
                v31 = v30 < 5l;
                bool v32;
                v32 = v31 == false;
                if (v32){
                    assert("The length has to be less than the maximum length of the array." && v31);
                } else {
                }
                long v33;
                v33 = v30 + 1l;
                v2.length = v33;
                bool v34;
                v34 = 0l <= v30;
                bool v37;
                if (v34){
                    long v35;
                    v35 = v2.length;
                    bool v36;
                    v36 = v30 < v35;
                    v37 = v36;
                } else {
                    v37 = false;
                }
                bool v38;
                v38 = v37 == false;
                if (v38){
                    assert("The set index needs to be in range for the static array list." && v37);
                } else {
                }
                v2.v[v30] = Tuple0(v28, v29);
                v22 += 1l ;
            }
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v57;
    v57 = 0l;
    while (while_method_3(v57)){
        bool v59;
        v59 = 0l <= v57;
        bool v61;
        if (v59){
            bool v60;
            v60 = v57 < 3l;
            v61 = v60;
        } else {
            v61 = false;
        }
        bool v62;
        v62 = v61 == false;
        if (v62){
            assert("The read index needs to be in range for the static array." && v61);
        } else {
        }
        US4 v63; US5 v64;
        Tuple0 tmp30 = v1.v[v57];
        v63 = tmp30.v0; v64 = tmp30.v1;
        long v65;
        v65 = v2.length;
        bool v66;
        v66 = v65 < 5l;
        bool v67;
        v67 = v66 == false;
        if (v67){
            assert("The length has to be less than the maximum length of the array." && v66);
        } else {
        }
        long v68;
        v68 = v65 + 1l;
        v2.length = v68;
        bool v69;
        v69 = 0l <= v65;
        bool v72;
        if (v69){
            long v70;
            v70 = v2.length;
            bool v71;
            v71 = v65 < v70;
            v72 = v71;
        } else {
            v72 = false;
        }
        bool v73;
        v73 = v72 == false;
        if (v73){
            assert("The set index needs to be in range for the static array list." && v72);
        } else {
        }
        v2.v[v65] = Tuple0(v63, v64);
        v57 += 1l ;
    }
    return v2;
}
__device__ bool player_can_act_42(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5){
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
    Tuple3 tmp31 = Tuple3(1l, v17);
    v18 = tmp31.v0; v19 = tmp31.v1;
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
    long v29; long v30;
    Tuple3 tmp32 = Tuple3(0l, 0l);
    v29 = tmp32.v0; v30 = tmp32.v1;
    while (while_method_0(v29)){
        bool v32;
        v32 = 0l <= v29;
        bool v34;
        if (v32){
            bool v33;
            v33 = v29 < 2l;
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
        long v36;
        v36 = v4.v[v29];
        bool v37;
        v37 = 0l < v36;
        long v38;
        if (v37){
            v38 = 1l;
        } else {
            v38 = 0l;
        }
        long v39;
        v39 = v30 + v38;
        v30 = v39;
        v29 += 1l ;
    }
    if (v12){
        if (v28){
            return true;
        } else {
            bool v40;
            v40 = v3 < 2l;
            if (v40){
                bool v41;
                v41 = 0l < v30;
                return v41;
            } else {
                return false;
            }
        }
    } else {
        return false;
    }
}
__device__ US7 go_next_street_43(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5){
    switch (v5.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v7 = v5.v.case0.v0;
            return US7_7(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 1: { // Preflop
            return US7_0(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v11 = v5.v.case2.v0;
            return US7_6(v0, v1, v2, v3, v4, v5);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v9 = v5.v.case3.v0;
            return US7_3(v0, v1, v2, v3, v4, v5);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ US7 try_round_41(long v0, static_array<static_array<Tuple0,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US8 v5){
    long v6;
    v6 = v3 + 1l;
    bool v7;
    v7 = player_can_act_42(v0, v1, v2, v3, v4, v5);
    if (v7){
        return US7_4(v0, v1, v2, v3, v4, v5);
    } else {
        bool v9;
        v9 = player_can_act_42(v0, v1, v2, v6, v4, v5);
        if (v9){
            return US7_4(v0, v1, v2, v6, v4, v5);
        } else {
            return go_next_street_43(v0, v1, v2, v3, v4, v5);
        }
    }
}
__device__ Tuple14 draw_cards_44(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,2l> v2;
    long v3; unsigned long long v4;
    Tuple12 tmp33 = Tuple12(0l, v1);
    v3 = tmp33.v0; v4 = tmp33.v1;
    while (while_method_0(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple13 tmp34 = draw_card_35(v0, v4);
        v6 = tmp34.v0; v7 = tmp34.v1;
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
    return Tuple14(v2, v4);
}
__device__ inline bool while_method_6(long v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
__device__ Tuple15 draw_cards_45(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<unsigned char,1l> v2;
    long v3; unsigned long long v4;
    Tuple12 tmp39 = Tuple12(0l, v1);
    v3 = tmp39.v0; v4 = tmp39.v1;
    while (while_method_6(v3)){
        unsigned char v6; unsigned long long v7;
        Tuple13 tmp40 = draw_card_35(v0, v4);
        v6 = tmp40.v0; v7 = tmp40.v1;
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
    return Tuple15(v2, v4);
}
__device__ static_array_list<Tuple0,5l,long> get_community_cards_46(US8 v0, static_array<Tuple0,1l> v1){
    static_array_list<Tuple0,5l,long> v2;
    v2.length = 0;
    switch (v0.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v3 = v0.v.case0.v0;
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
                US4 v10; US5 v11;
                Tuple0 tmp43 = v3.v[v4];
                v10 = tmp43.v0; v11 = tmp43.v1;
                long v12;
                v12 = v2.length;
                bool v13;
                v13 = v12 < 5l;
                bool v14;
                v14 = v13 == false;
                if (v14){
                    assert("The length has to be less than the maximum length of the array." && v13);
                } else {
                }
                long v15;
                v15 = v12 + 1l;
                v2.length = v15;
                bool v16;
                v16 = 0l <= v12;
                bool v19;
                if (v16){
                    long v17;
                    v17 = v2.length;
                    bool v18;
                    v18 = v12 < v17;
                    v19 = v18;
                } else {
                    v19 = false;
                }
                bool v20;
                v20 = v19 == false;
                if (v20){
                    assert("The set index needs to be in range for the static array list." && v19);
                } else {
                }
                v2.v[v12] = Tuple0(v10, v11);
                v4 += 1l ;
            }
            break;
        }
        case 1: { // Preflop
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v39 = v0.v.case2.v0;
            long v40;
            v40 = 0l;
            while (while_method_2(v40)){
                bool v42;
                v42 = 0l <= v40;
                bool v44;
                if (v42){
                    bool v43;
                    v43 = v40 < 5l;
                    v44 = v43;
                } else {
                    v44 = false;
                }
                bool v45;
                v45 = v44 == false;
                if (v45){
                    assert("The read index needs to be in range for the static array." && v44);
                } else {
                }
                US4 v46; US5 v47;
                Tuple0 tmp44 = v39.v[v40];
                v46 = tmp44.v0; v47 = tmp44.v1;
                long v48;
                v48 = v2.length;
                bool v49;
                v49 = v48 < 5l;
                bool v50;
                v50 = v49 == false;
                if (v50){
                    assert("The length has to be less than the maximum length of the array." && v49);
                } else {
                }
                long v51;
                v51 = v48 + 1l;
                v2.length = v51;
                bool v52;
                v52 = 0l <= v48;
                bool v55;
                if (v52){
                    long v53;
                    v53 = v2.length;
                    bool v54;
                    v54 = v48 < v53;
                    v55 = v54;
                } else {
                    v55 = false;
                }
                bool v56;
                v56 = v55 == false;
                if (v56){
                    assert("The set index needs to be in range for the static array list." && v55);
                } else {
                }
                v2.v[v48] = Tuple0(v46, v47);
                v40 += 1l ;
            }
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v21 = v0.v.case3.v0;
            long v22;
            v22 = 0l;
            while (while_method_4(v22)){
                bool v24;
                v24 = 0l <= v22;
                bool v26;
                if (v24){
                    bool v25;
                    v25 = v22 < 4l;
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
                US4 v28; US5 v29;
                Tuple0 tmp45 = v21.v[v22];
                v28 = tmp45.v0; v29 = tmp45.v1;
                long v30;
                v30 = v2.length;
                bool v31;
                v31 = v30 < 5l;
                bool v32;
                v32 = v31 == false;
                if (v32){
                    assert("The length has to be less than the maximum length of the array." && v31);
                } else {
                }
                long v33;
                v33 = v30 + 1l;
                v2.length = v33;
                bool v34;
                v34 = 0l <= v30;
                bool v37;
                if (v34){
                    long v35;
                    v35 = v2.length;
                    bool v36;
                    v36 = v30 < v35;
                    v37 = v36;
                } else {
                    v37 = false;
                }
                bool v38;
                v38 = v37 == false;
                if (v38){
                    assert("The set index needs to be in range for the static array list." && v37);
                } else {
                }
                v2.v[v30] = Tuple0(v28, v29);
                v22 += 1l ;
            }
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v57;
    v57 = 0l;
    while (while_method_6(v57)){
        bool v59;
        v59 = 0l <= v57;
        bool v61;
        if (v59){
            bool v60;
            v60 = v57 < 1l;
            v61 = v60;
        } else {
            v61 = false;
        }
        bool v62;
        v62 = v61 == false;
        if (v62){
            assert("The read index needs to be in range for the static array." && v61);
        } else {
        }
        US4 v63; US5 v64;
        Tuple0 tmp46 = v1.v[v57];
        v63 = tmp46.v0; v64 = tmp46.v1;
        long v65;
        v65 = v2.length;
        bool v66;
        v66 = v65 < 5l;
        bool v67;
        v67 = v66 == false;
        if (v67){
            assert("The length has to be less than the maximum length of the array." && v66);
        } else {
        }
        long v68;
        v68 = v65 + 1l;
        v2.length = v68;
        bool v69;
        v69 = 0l <= v65;
        bool v72;
        if (v69){
            long v70;
            v70 = v2.length;
            bool v71;
            v71 = v65 < v70;
            v72 = v71;
        } else {
            v72 = false;
        }
        bool v73;
        v73 = v72 == false;
        if (v73){
            assert("The set index needs to be in range for the static array list." && v72);
        } else {
        }
        v2.v[v65] = Tuple0(v63, v64);
        v57 += 1l ;
    }
    return v2;
}
__device__ inline bool while_method_7(long v0){
    bool v1;
    v1 = v0 < 6l;
    return v1;
}
__device__ inline bool while_method_8(static_array<float,6l> v0, long v1){
    bool v2;
    v2 = v1 < 6l;
    return v2;
}
__device__ inline bool while_method_9(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
__device__ long loop_49(static_array<float,6l> v0, float v1, long v2){
    bool v3;
    v3 = v2 < 6l;
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
            return loop_49(v0, v1, v9);
        }
    } else {
        return 5l;
    }
}
__device__ long sample_discrete__48(static_array<float,6l> v0, curandStatePhilox4_32_10_t & v1){
    static_array<float,6l> v2;
    long v3;
    v3 = 0l;
    while (while_method_7(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 6l;
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
            v10 = v3 < 6l;
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
        v15 = 6l;
        while (while_method_9(v13, v15)){
            v15 -= 1l ;
            long v17;
            v17 = v15 - v13;
            bool v18;
            v18 = 0l <= v17;
            bool v20;
            if (v18){
                bool v19;
                v19 = v17 < 6l;
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
                v24 = v15 < 6l;
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
                v29 = v15 < 6l;
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
    v33 = v2.v[5l];
    float v34;
    v34 = curand_uniform(&v1);
    float v35;
    v35 = v34 * v33;
    long v36;
    v36 = 0l;
    return loop_49(v2, v35, v36);
}
__device__ US1 sample_discrete_47(static_array<Tuple16,6l> v0, curandStatePhilox4_32_10_t & v1){
    static_array<float,6l> v2;
    long v3;
    v3 = 0l;
    while (while_method_7(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 6l;
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
        Tuple16 tmp51 = v0.v[v3];
        v9 = tmp51.v0; v10 = tmp51.v1;
        bool v12;
        if (v5){
            bool v11;
            v11 = v3 < 6l;
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
    v14 = sample_discrete__48(v2, v1);
    bool v15;
    v15 = 0l <= v14;
    bool v17;
    if (v15){
        bool v16;
        v16 = v14 < 6l;
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
    Tuple16 tmp52 = v0.v[v14];
    v19 = tmp52.v0; v20 = tmp52.v1;
    return v19;
}
__device__ inline bool while_method_10(long v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ unsigned char card_rank_tag_51(US4 v0){
    switch (v0.tag) {
        case 0: { // Ace
            return 12u;
            break;
        }
        case 1: { // Eight
            return 6u;
            break;
        }
        case 2: { // Five
            return 3u;
            break;
        }
        case 3: { // Four
            return 2u;
            break;
        }
        case 4: { // Jack
            return 9u;
            break;
        }
        case 5: { // King
            return 11u;
            break;
        }
        case 6: { // Nine
            return 7u;
            break;
        }
        case 7: { // Queen
            return 10u;
            break;
        }
        case 8: { // Seven
            return 5u;
            break;
        }
        case 9: { // Six
            return 4u;
            break;
        }
        case 10: { // Ten
            return 8u;
            break;
        }
        case 11: { // Three
            return 1u;
            break;
        }
        case 12: { // Two
            return 0u;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ unsigned char card_suit_tag_52(US5 v0){
    switch (v0.tag) {
        case 0: { // Clubs
            return 1u;
            break;
        }
        case 1: { // Diamonds
            return 0u;
            break;
        }
        case 2: { // Hearts
            return 3u;
            break;
        }
        case 3: { // Spades
            return 2u;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ unsigned char lib_card_from_card_50(US5 v0, US4 v1){
    unsigned char v2;
    v2 = card_rank_tag_51(v1);
    unsigned char v3;
    v3 = v2 * 4u;
    unsigned char v4;
    v4 = card_suit_tag_52(v0);
    unsigned char v5;
    v5 = v3 + v4;
    return v5;
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
__device__ US10 US10_0() { // Eq
    US10 x;
    x.tag = 0;
    return x;
}
__device__ US10 US10_1() { // Gt
    US10 x;
    x.tag = 1;
    return x;
}
__device__ US10 US10_2() { // Lt
    US10 x;
    x.tag = 2;
    return x;
}
__device__ US11 US11_0() { // None
    US11 x;
    x.tag = 0;
    return x;
}
__device__ US11 US11_1(static_array<unsigned char,5l> v0) { // Some
    US11 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US12 US12_0() { // None
    US12 x;
    x.tag = 0;
    return x;
}
__device__ US12 US12_1(static_array<unsigned char,4l> v0, static_array<unsigned char,3l> v1) { // Some
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
__device__ US13 US13_1(static_array<unsigned char,3l> v0, static_array<unsigned char,4l> v1) { // Some
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
__device__ US14 US14_1(static_array<unsigned char,2l> v0, static_array<unsigned char,2l> v1) { // Some
    US14 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US15 US15_0() { // None
    US15 x;
    x.tag = 0;
    return x;
}
__device__ US15 US15_1(static_array<unsigned char,2l> v0, static_array<unsigned char,5l> v1) { // Some
    US15 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US16 US16_0() { // None
    US16 x;
    x.tag = 0;
    return x;
}
__device__ US16 US16_1(static_array<unsigned char,2l> v0, static_array<unsigned char,3l> v1) { // Some
    US16 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple1 score_53(static_array<unsigned char,7l> v0){
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
    Tuple17 tmp62 = Tuple17(true, 1l);
    v13 = tmp62.v0; v14 = tmp62.v1;
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
            Tuple18 tmp63 = Tuple18(v16, v20, v16);
            v25 = tmp63.v0; v26 = tmp63.v1; v27 = tmp63.v2;
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
                unsigned char v105; long v106; long v107;
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
                    v54 = v53 / 4u;
                    unsigned char v55;
                    v55 = v42 / 4u;
                    bool v56;
                    v56 = v54 < v55;
                    US10 v62;
                    if (v56){
                        v62 = US10_2();
                    } else {
                        bool v58;
                        v58 = v54 > v55;
                        if (v58){
                            v62 = US10_1();
                        } else {
                            v62 = US10_0();
                        }
                    }
                    US10 v72;
                    switch (v62.tag) {
                        case 0: { // Eq
                            unsigned char v63;
                            v63 = v42 % 4u;
                            unsigned char v64;
                            v64 = v53 % 4u;
                            bool v65;
                            v65 = v63 < v64;
                            if (v65){
                                v72 = US10_2();
                            } else {
                                bool v67;
                                v67 = v63 > v64;
                                if (v67){
                                    v72 = US10_1();
                                } else {
                                    v72 = US10_0();
                                }
                            }
                            break;
                        }
                        default: {
                            v72 = v62;
                        }
                    }
                    switch (v72.tag) {
                        case 1: { // Gt
                            long v73;
                            v73 = v26 + 1l;
                            v105 = v53; v106 = v25; v107 = v73;
                            break;
                        }
                        default: {
                            long v74;
                            v74 = v25 + 1l;
                            v105 = v42; v106 = v74; v107 = v26;
                        }
                    }
                } else {
                    if (v29){
                        unsigned char v88;
                        if (v13){
                            bool v78;
                            v78 = 0l <= v25;
                            bool v80;
                            if (v78){
                                bool v79;
                                v79 = v25 < 7l;
                                v80 = v79;
                            } else {
                                v80 = false;
                            }
                            bool v81;
                            v81 = v80 == false;
                            if (v81){
                                assert("The read index needs to be in range for the static array." && v80);
                            } else {
                            }
                            unsigned char v82;
                            v82 = v1.v[v25];
                            v88 = v82;
                        } else {
                            bool v83;
                            v83 = 0l <= v25;
                            bool v85;
                            if (v83){
                                bool v84;
                                v84 = v25 < 7l;
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
                            v87 = v12.v[v25];
                            v88 = v87;
                        }
                        long v89;
                        v89 = v25 + 1l;
                        v105 = v88; v106 = v89; v107 = v26;
                    } else {
                        unsigned char v100;
                        if (v13){
                            bool v90;
                            v90 = 0l <= v26;
                            bool v92;
                            if (v90){
                                bool v91;
                                v91 = v26 < 7l;
                                v92 = v91;
                            } else {
                                v92 = false;
                            }
                            bool v93;
                            v93 = v92 == false;
                            if (v93){
                                assert("The read index needs to be in range for the static array." && v92);
                            } else {
                            }
                            unsigned char v94;
                            v94 = v1.v[v26];
                            v100 = v94;
                        } else {
                            bool v95;
                            v95 = 0l <= v26;
                            bool v97;
                            if (v95){
                                bool v96;
                                v96 = v26 < 7l;
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
                            unsigned char v99;
                            v99 = v12.v[v26];
                            v100 = v99;
                        }
                        long v101;
                        v101 = v26 + 1l;
                        v105 = v100; v106 = v25; v107 = v101;
                    }
                }
                if (v13){
                    bool v108;
                    v108 = 0l <= v27;
                    bool v110;
                    if (v108){
                        bool v109;
                        v109 = v27 < 7l;
                        v110 = v109;
                    } else {
                        v110 = false;
                    }
                    bool v111;
                    v111 = v110 == false;
                    if (v111){
                        assert("The read index needs to be in range for the static array." && v110);
                    } else {
                    }
                    v12.v[v27] = v105;
                } else {
                    bool v112;
                    v112 = 0l <= v27;
                    bool v114;
                    if (v112){
                        bool v113;
                        v113 = v27 < 7l;
                        v114 = v113;
                    } else {
                        v114 = false;
                    }
                    bool v115;
                    v115 = v114 == false;
                    if (v115){
                        assert("The read index needs to be in range for the static array." && v114);
                    } else {
                    }
                    v1.v[v27] = v105;
                }
                long v116;
                v116 = v27 + 1l;
                v25 = v106;
                v26 = v107;
                v27 = v116;
            }
            v16 = v22;
        }
        bool v117;
        v117 = v13 == false;
        long v118;
        v118 = v14 * 2l;
        v13 = v117;
        v14 = v118;
    }
    bool v119;
    v119 = v13 == false;
    static_array<unsigned char,7l> v120;
    if (v119){
        v120 = v12;
    } else {
        v120 = v1;
    }
    static_array<unsigned char,5l> v121;
    long v122; long v123; unsigned char v124;
    Tuple19 tmp64 = Tuple19(0l, 0l, 12u);
    v122 = tmp64.v0; v123 = tmp64.v1; v124 = tmp64.v2;
    while (while_method_10(v122)){
        bool v126;
        v126 = 0l <= v122;
        bool v128;
        if (v126){
            bool v127;
            v127 = v122 < 7l;
            v128 = v127;
        } else {
            v128 = false;
        }
        bool v129;
        v129 = v128 == false;
        if (v129){
            assert("The read index needs to be in range for the static array." && v128);
        } else {
        }
        unsigned char v130;
        v130 = v120.v[v122];
        bool v131;
        v131 = v123 < 5l;
        long v147; unsigned char v148;
        if (v131){
            unsigned char v132;
            v132 = v130 % 4u;
            bool v133;
            v133 = 0u == v132;
            if (v133){
                unsigned char v134;
                v134 = v130 / 4u;
                bool v135;
                v135 = v124 == v134;
                long v136;
                if (v135){
                    v136 = v123;
                } else {
                    v136 = 0l;
                }
                bool v137;
                v137 = 0l <= v136;
                bool v139;
                if (v137){
                    bool v138;
                    v138 = v136 < 5l;
                    v139 = v138;
                } else {
                    v139 = false;
                }
                bool v140;
                v140 = v139 == false;
                if (v140){
                    assert("The read index needs to be in range for the static array." && v139);
                } else {
                }
                v121.v[v136] = v130;
                long v141;
                v141 = v136 + 1l;
                unsigned char v142;
                v142 = v134 - 1u;
                v147 = v141; v148 = v142;
            } else {
                v147 = v123; v148 = v124;
            }
        } else {
            break;
        }
        v123 = v147;
        v124 = v148;
        v122 += 1l ;
    }
    bool v149;
    v149 = v123 == 4l;
    bool v184;
    if (v149){
        unsigned char v150;
        v150 = v124 + 1u;
        bool v151;
        v151 = v150 == 0u;
        if (v151){
            unsigned char v152;
            v152 = v120.v[0l];
            unsigned char v153;
            v153 = v152 % 4u;
            bool v154;
            v154 = 0u == v153;
            bool v158;
            if (v154){
                unsigned char v155;
                v155 = v152 / 4u;
                bool v156;
                v156 = v155 == 12u;
                if (v156){
                    v121.v[4l] = v152;
                    v158 = true;
                } else {
                    v158 = false;
                }
            } else {
                v158 = false;
            }
            if (v158){
                v184 = true;
            } else {
                unsigned char v159;
                v159 = v120.v[1l];
                unsigned char v160;
                v160 = v159 % 4u;
                bool v161;
                v161 = 0u == v160;
                bool v165;
                if (v161){
                    unsigned char v162;
                    v162 = v159 / 4u;
                    bool v163;
                    v163 = v162 == 12u;
                    if (v163){
                        v121.v[4l] = v159;
                        v165 = true;
                    } else {
                        v165 = false;
                    }
                } else {
                    v165 = false;
                }
                if (v165){
                    v184 = true;
                } else {
                    unsigned char v166;
                    v166 = v120.v[2l];
                    unsigned char v167;
                    v167 = v166 % 4u;
                    bool v168;
                    v168 = 0u == v167;
                    bool v172;
                    if (v168){
                        unsigned char v169;
                        v169 = v166 / 4u;
                        bool v170;
                        v170 = v169 == 12u;
                        if (v170){
                            v121.v[4l] = v166;
                            v172 = true;
                        } else {
                            v172 = false;
                        }
                    } else {
                        v172 = false;
                    }
                    if (v172){
                        v184 = true;
                    } else {
                        unsigned char v173;
                        v173 = v120.v[3l];
                        unsigned char v174;
                        v174 = v173 % 4u;
                        bool v175;
                        v175 = 0u == v174;
                        if (v175){
                            unsigned char v176;
                            v176 = v173 / 4u;
                            bool v177;
                            v177 = v176 == 12u;
                            if (v177){
                                v121.v[4l] = v173;
                                v184 = true;
                            } else {
                                v184 = false;
                            }
                        } else {
                            v184 = false;
                        }
                    }
                }
            }
        } else {
            v184 = false;
        }
    } else {
        v184 = false;
    }
    US11 v190;
    if (v184){
        v190 = US11_1(v121);
    } else {
        bool v186;
        v186 = v123 == 5l;
        if (v186){
            v190 = US11_1(v121);
        } else {
            v190 = US11_0();
        }
    }
    static_array<unsigned char,5l> v191;
    long v192; long v193; unsigned char v194;
    Tuple19 tmp65 = Tuple19(0l, 0l, 12u);
    v192 = tmp65.v0; v193 = tmp65.v1; v194 = tmp65.v2;
    while (while_method_10(v192)){
        bool v196;
        v196 = 0l <= v192;
        bool v198;
        if (v196){
            bool v197;
            v197 = v192 < 7l;
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
        unsigned char v200;
        v200 = v120.v[v192];
        bool v201;
        v201 = v193 < 5l;
        long v217; unsigned char v218;
        if (v201){
            unsigned char v202;
            v202 = v200 % 4u;
            bool v203;
            v203 = 1u == v202;
            if (v203){
                unsigned char v204;
                v204 = v200 / 4u;
                bool v205;
                v205 = v194 == v204;
                long v206;
                if (v205){
                    v206 = v193;
                } else {
                    v206 = 0l;
                }
                bool v207;
                v207 = 0l <= v206;
                bool v209;
                if (v207){
                    bool v208;
                    v208 = v206 < 5l;
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
                v191.v[v206] = v200;
                long v211;
                v211 = v206 + 1l;
                unsigned char v212;
                v212 = v204 - 1u;
                v217 = v211; v218 = v212;
            } else {
                v217 = v193; v218 = v194;
            }
        } else {
            break;
        }
        v193 = v217;
        v194 = v218;
        v192 += 1l ;
    }
    bool v219;
    v219 = v193 == 4l;
    bool v254;
    if (v219){
        unsigned char v220;
        v220 = v194 + 1u;
        bool v221;
        v221 = v220 == 0u;
        if (v221){
            unsigned char v222;
            v222 = v120.v[0l];
            unsigned char v223;
            v223 = v222 % 4u;
            bool v224;
            v224 = 1u == v223;
            bool v228;
            if (v224){
                unsigned char v225;
                v225 = v222 / 4u;
                bool v226;
                v226 = v225 == 12u;
                if (v226){
                    v191.v[4l] = v222;
                    v228 = true;
                } else {
                    v228 = false;
                }
            } else {
                v228 = false;
            }
            if (v228){
                v254 = true;
            } else {
                unsigned char v229;
                v229 = v120.v[1l];
                unsigned char v230;
                v230 = v229 % 4u;
                bool v231;
                v231 = 1u == v230;
                bool v235;
                if (v231){
                    unsigned char v232;
                    v232 = v229 / 4u;
                    bool v233;
                    v233 = v232 == 12u;
                    if (v233){
                        v191.v[4l] = v229;
                        v235 = true;
                    } else {
                        v235 = false;
                    }
                } else {
                    v235 = false;
                }
                if (v235){
                    v254 = true;
                } else {
                    unsigned char v236;
                    v236 = v120.v[2l];
                    unsigned char v237;
                    v237 = v236 % 4u;
                    bool v238;
                    v238 = 1u == v237;
                    bool v242;
                    if (v238){
                        unsigned char v239;
                        v239 = v236 / 4u;
                        bool v240;
                        v240 = v239 == 12u;
                        if (v240){
                            v191.v[4l] = v236;
                            v242 = true;
                        } else {
                            v242 = false;
                        }
                    } else {
                        v242 = false;
                    }
                    if (v242){
                        v254 = true;
                    } else {
                        unsigned char v243;
                        v243 = v120.v[3l];
                        unsigned char v244;
                        v244 = v243 % 4u;
                        bool v245;
                        v245 = 1u == v244;
                        if (v245){
                            unsigned char v246;
                            v246 = v243 / 4u;
                            bool v247;
                            v247 = v246 == 12u;
                            if (v247){
                                v191.v[4l] = v243;
                                v254 = true;
                            } else {
                                v254 = false;
                            }
                        } else {
                            v254 = false;
                        }
                    }
                }
            }
        } else {
            v254 = false;
        }
    } else {
        v254 = false;
    }
    US11 v260;
    if (v254){
        v260 = US11_1(v191);
    } else {
        bool v256;
        v256 = v193 == 5l;
        if (v256){
            v260 = US11_1(v191);
        } else {
            v260 = US11_0();
        }
    }
    US11 v293;
    switch (v190.tag) {
        case 0: { // None
            v293 = v260;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v261 = v190.v.case1.v0;
            switch (v260.tag) {
                case 0: { // None
                    v293 = v190;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v262 = v260.v.case1.v0;
                    US10 v263;
                    v263 = US10_0();
                    long v264; US10 v265;
                    Tuple20 tmp66 = Tuple20(0l, v263);
                    v264 = tmp66.v0; v265 = tmp66.v1;
                    while (while_method_2(v264)){
                        bool v267;
                        v267 = 0l <= v264;
                        bool v269;
                        if (v267){
                            bool v268;
                            v268 = v264 < 5l;
                            v269 = v268;
                        } else {
                            v269 = false;
                        }
                        bool v270;
                        v270 = v269 == false;
                        if (v270){
                            assert("The read index needs to be in range for the static array." && v269);
                        } else {
                        }
                        unsigned char v271;
                        v271 = v261.v[v264];
                        bool v273;
                        if (v267){
                            bool v272;
                            v272 = v264 < 5l;
                            v273 = v272;
                        } else {
                            v273 = false;
                        }
                        bool v274;
                        v274 = v273 == false;
                        if (v274){
                            assert("The read index needs to be in range for the static array." && v273);
                        } else {
                        }
                        unsigned char v275;
                        v275 = v262.v[v264];
                        US10 v286;
                        switch (v265.tag) {
                            case 0: { // Eq
                                unsigned char v276;
                                v276 = v271 / 4u;
                                unsigned char v277;
                                v277 = v275 / 4u;
                                bool v278;
                                v278 = v276 < v277;
                                if (v278){
                                    v286 = US10_2();
                                } else {
                                    bool v280;
                                    v280 = v276 > v277;
                                    if (v280){
                                        v286 = US10_1();
                                    } else {
                                        v286 = US10_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v265 = v286;
                        v264 += 1l ;
                    }
                    bool v287;
                    switch (v265.tag) {
                        case 1: { // Gt
                            v287 = true;
                            break;
                        }
                        default: {
                            v287 = false;
                        }
                    }
                    static_array<unsigned char,5l> v288;
                    if (v287){
                        v288 = v261;
                    } else {
                        v288 = v262;
                    }
                    v293 = US11_1(v288);
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
    static_array<unsigned char,5l> v294;
    long v295; long v296; unsigned char v297;
    Tuple19 tmp67 = Tuple19(0l, 0l, 12u);
    v295 = tmp67.v0; v296 = tmp67.v1; v297 = tmp67.v2;
    while (while_method_10(v295)){
        bool v299;
        v299 = 0l <= v295;
        bool v301;
        if (v299){
            bool v300;
            v300 = v295 < 7l;
            v301 = v300;
        } else {
            v301 = false;
        }
        bool v302;
        v302 = v301 == false;
        if (v302){
            assert("The read index needs to be in range for the static array." && v301);
        } else {
        }
        unsigned char v303;
        v303 = v120.v[v295];
        bool v304;
        v304 = v296 < 5l;
        long v320; unsigned char v321;
        if (v304){
            unsigned char v305;
            v305 = v303 % 4u;
            bool v306;
            v306 = 2u == v305;
            if (v306){
                unsigned char v307;
                v307 = v303 / 4u;
                bool v308;
                v308 = v297 == v307;
                long v309;
                if (v308){
                    v309 = v296;
                } else {
                    v309 = 0l;
                }
                bool v310;
                v310 = 0l <= v309;
                bool v312;
                if (v310){
                    bool v311;
                    v311 = v309 < 5l;
                    v312 = v311;
                } else {
                    v312 = false;
                }
                bool v313;
                v313 = v312 == false;
                if (v313){
                    assert("The read index needs to be in range for the static array." && v312);
                } else {
                }
                v294.v[v309] = v303;
                long v314;
                v314 = v309 + 1l;
                unsigned char v315;
                v315 = v307 - 1u;
                v320 = v314; v321 = v315;
            } else {
                v320 = v296; v321 = v297;
            }
        } else {
            break;
        }
        v296 = v320;
        v297 = v321;
        v295 += 1l ;
    }
    bool v322;
    v322 = v296 == 4l;
    bool v357;
    if (v322){
        unsigned char v323;
        v323 = v297 + 1u;
        bool v324;
        v324 = v323 == 0u;
        if (v324){
            unsigned char v325;
            v325 = v120.v[0l];
            unsigned char v326;
            v326 = v325 % 4u;
            bool v327;
            v327 = 2u == v326;
            bool v331;
            if (v327){
                unsigned char v328;
                v328 = v325 / 4u;
                bool v329;
                v329 = v328 == 12u;
                if (v329){
                    v294.v[4l] = v325;
                    v331 = true;
                } else {
                    v331 = false;
                }
            } else {
                v331 = false;
            }
            if (v331){
                v357 = true;
            } else {
                unsigned char v332;
                v332 = v120.v[1l];
                unsigned char v333;
                v333 = v332 % 4u;
                bool v334;
                v334 = 2u == v333;
                bool v338;
                if (v334){
                    unsigned char v335;
                    v335 = v332 / 4u;
                    bool v336;
                    v336 = v335 == 12u;
                    if (v336){
                        v294.v[4l] = v332;
                        v338 = true;
                    } else {
                        v338 = false;
                    }
                } else {
                    v338 = false;
                }
                if (v338){
                    v357 = true;
                } else {
                    unsigned char v339;
                    v339 = v120.v[2l];
                    unsigned char v340;
                    v340 = v339 % 4u;
                    bool v341;
                    v341 = 2u == v340;
                    bool v345;
                    if (v341){
                        unsigned char v342;
                        v342 = v339 / 4u;
                        bool v343;
                        v343 = v342 == 12u;
                        if (v343){
                            v294.v[4l] = v339;
                            v345 = true;
                        } else {
                            v345 = false;
                        }
                    } else {
                        v345 = false;
                    }
                    if (v345){
                        v357 = true;
                    } else {
                        unsigned char v346;
                        v346 = v120.v[3l];
                        unsigned char v347;
                        v347 = v346 % 4u;
                        bool v348;
                        v348 = 2u == v347;
                        if (v348){
                            unsigned char v349;
                            v349 = v346 / 4u;
                            bool v350;
                            v350 = v349 == 12u;
                            if (v350){
                                v294.v[4l] = v346;
                                v357 = true;
                            } else {
                                v357 = false;
                            }
                        } else {
                            v357 = false;
                        }
                    }
                }
            }
        } else {
            v357 = false;
        }
    } else {
        v357 = false;
    }
    US11 v363;
    if (v357){
        v363 = US11_1(v294);
    } else {
        bool v359;
        v359 = v296 == 5l;
        if (v359){
            v363 = US11_1(v294);
        } else {
            v363 = US11_0();
        }
    }
    US11 v396;
    switch (v293.tag) {
        case 0: { // None
            v396 = v363;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v364 = v293.v.case1.v0;
            switch (v363.tag) {
                case 0: { // None
                    v396 = v293;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v365 = v363.v.case1.v0;
                    US10 v366;
                    v366 = US10_0();
                    long v367; US10 v368;
                    Tuple20 tmp68 = Tuple20(0l, v366);
                    v367 = tmp68.v0; v368 = tmp68.v1;
                    while (while_method_2(v367)){
                        bool v370;
                        v370 = 0l <= v367;
                        bool v372;
                        if (v370){
                            bool v371;
                            v371 = v367 < 5l;
                            v372 = v371;
                        } else {
                            v372 = false;
                        }
                        bool v373;
                        v373 = v372 == false;
                        if (v373){
                            assert("The read index needs to be in range for the static array." && v372);
                        } else {
                        }
                        unsigned char v374;
                        v374 = v364.v[v367];
                        bool v376;
                        if (v370){
                            bool v375;
                            v375 = v367 < 5l;
                            v376 = v375;
                        } else {
                            v376 = false;
                        }
                        bool v377;
                        v377 = v376 == false;
                        if (v377){
                            assert("The read index needs to be in range for the static array." && v376);
                        } else {
                        }
                        unsigned char v378;
                        v378 = v365.v[v367];
                        US10 v389;
                        switch (v368.tag) {
                            case 0: { // Eq
                                unsigned char v379;
                                v379 = v374 / 4u;
                                unsigned char v380;
                                v380 = v378 / 4u;
                                bool v381;
                                v381 = v379 < v380;
                                if (v381){
                                    v389 = US10_2();
                                } else {
                                    bool v383;
                                    v383 = v379 > v380;
                                    if (v383){
                                        v389 = US10_1();
                                    } else {
                                        v389 = US10_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v368 = v389;
                        v367 += 1l ;
                    }
                    bool v390;
                    switch (v368.tag) {
                        case 1: { // Gt
                            v390 = true;
                            break;
                        }
                        default: {
                            v390 = false;
                        }
                    }
                    static_array<unsigned char,5l> v391;
                    if (v390){
                        v391 = v364;
                    } else {
                        v391 = v365;
                    }
                    v396 = US11_1(v391);
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
    static_array<unsigned char,5l> v397;
    long v398; long v399; unsigned char v400;
    Tuple19 tmp69 = Tuple19(0l, 0l, 12u);
    v398 = tmp69.v0; v399 = tmp69.v1; v400 = tmp69.v2;
    while (while_method_10(v398)){
        bool v402;
        v402 = 0l <= v398;
        bool v404;
        if (v402){
            bool v403;
            v403 = v398 < 7l;
            v404 = v403;
        } else {
            v404 = false;
        }
        bool v405;
        v405 = v404 == false;
        if (v405){
            assert("The read index needs to be in range for the static array." && v404);
        } else {
        }
        unsigned char v406;
        v406 = v120.v[v398];
        bool v407;
        v407 = v399 < 5l;
        long v423; unsigned char v424;
        if (v407){
            unsigned char v408;
            v408 = v406 % 4u;
            bool v409;
            v409 = 3u == v408;
            if (v409){
                unsigned char v410;
                v410 = v406 / 4u;
                bool v411;
                v411 = v400 == v410;
                long v412;
                if (v411){
                    v412 = v399;
                } else {
                    v412 = 0l;
                }
                bool v413;
                v413 = 0l <= v412;
                bool v415;
                if (v413){
                    bool v414;
                    v414 = v412 < 5l;
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
                v397.v[v412] = v406;
                long v417;
                v417 = v412 + 1l;
                unsigned char v418;
                v418 = v410 - 1u;
                v423 = v417; v424 = v418;
            } else {
                v423 = v399; v424 = v400;
            }
        } else {
            break;
        }
        v399 = v423;
        v400 = v424;
        v398 += 1l ;
    }
    bool v425;
    v425 = v399 == 4l;
    bool v460;
    if (v425){
        unsigned char v426;
        v426 = v400 + 1u;
        bool v427;
        v427 = v426 == 0u;
        if (v427){
            unsigned char v428;
            v428 = v120.v[0l];
            unsigned char v429;
            v429 = v428 % 4u;
            bool v430;
            v430 = 3u == v429;
            bool v434;
            if (v430){
                unsigned char v431;
                v431 = v428 / 4u;
                bool v432;
                v432 = v431 == 12u;
                if (v432){
                    v397.v[4l] = v428;
                    v434 = true;
                } else {
                    v434 = false;
                }
            } else {
                v434 = false;
            }
            if (v434){
                v460 = true;
            } else {
                unsigned char v435;
                v435 = v120.v[1l];
                unsigned char v436;
                v436 = v435 % 4u;
                bool v437;
                v437 = 3u == v436;
                bool v441;
                if (v437){
                    unsigned char v438;
                    v438 = v435 / 4u;
                    bool v439;
                    v439 = v438 == 12u;
                    if (v439){
                        v397.v[4l] = v435;
                        v441 = true;
                    } else {
                        v441 = false;
                    }
                } else {
                    v441 = false;
                }
                if (v441){
                    v460 = true;
                } else {
                    unsigned char v442;
                    v442 = v120.v[2l];
                    unsigned char v443;
                    v443 = v442 % 4u;
                    bool v444;
                    v444 = 3u == v443;
                    bool v448;
                    if (v444){
                        unsigned char v445;
                        v445 = v442 / 4u;
                        bool v446;
                        v446 = v445 == 12u;
                        if (v446){
                            v397.v[4l] = v442;
                            v448 = true;
                        } else {
                            v448 = false;
                        }
                    } else {
                        v448 = false;
                    }
                    if (v448){
                        v460 = true;
                    } else {
                        unsigned char v449;
                        v449 = v120.v[3l];
                        unsigned char v450;
                        v450 = v449 % 4u;
                        bool v451;
                        v451 = 3u == v450;
                        if (v451){
                            unsigned char v452;
                            v452 = v449 / 4u;
                            bool v453;
                            v453 = v452 == 12u;
                            if (v453){
                                v397.v[4l] = v449;
                                v460 = true;
                            } else {
                                v460 = false;
                            }
                        } else {
                            v460 = false;
                        }
                    }
                }
            }
        } else {
            v460 = false;
        }
    } else {
        v460 = false;
    }
    US11 v466;
    if (v460){
        v466 = US11_1(v397);
    } else {
        bool v462;
        v462 = v399 == 5l;
        if (v462){
            v466 = US11_1(v397);
        } else {
            v466 = US11_0();
        }
    }
    US11 v499;
    switch (v396.tag) {
        case 0: { // None
            v499 = v466;
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v467 = v396.v.case1.v0;
            switch (v466.tag) {
                case 0: { // None
                    v499 = v396;
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v468 = v466.v.case1.v0;
                    US10 v469;
                    v469 = US10_0();
                    long v470; US10 v471;
                    Tuple20 tmp70 = Tuple20(0l, v469);
                    v470 = tmp70.v0; v471 = tmp70.v1;
                    while (while_method_2(v470)){
                        bool v473;
                        v473 = 0l <= v470;
                        bool v475;
                        if (v473){
                            bool v474;
                            v474 = v470 < 5l;
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
                        unsigned char v477;
                        v477 = v467.v[v470];
                        bool v479;
                        if (v473){
                            bool v478;
                            v478 = v470 < 5l;
                            v479 = v478;
                        } else {
                            v479 = false;
                        }
                        bool v480;
                        v480 = v479 == false;
                        if (v480){
                            assert("The read index needs to be in range for the static array." && v479);
                        } else {
                        }
                        unsigned char v481;
                        v481 = v468.v[v470];
                        US10 v492;
                        switch (v471.tag) {
                            case 0: { // Eq
                                unsigned char v482;
                                v482 = v477 / 4u;
                                unsigned char v483;
                                v483 = v481 / 4u;
                                bool v484;
                                v484 = v482 < v483;
                                if (v484){
                                    v492 = US10_2();
                                } else {
                                    bool v486;
                                    v486 = v482 > v483;
                                    if (v486){
                                        v492 = US10_1();
                                    } else {
                                        v492 = US10_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v471 = v492;
                        v470 += 1l ;
                    }
                    bool v493;
                    switch (v471.tag) {
                        case 1: { // Gt
                            v493 = true;
                            break;
                        }
                        default: {
                            v493 = false;
                        }
                    }
                    static_array<unsigned char,5l> v494;
                    if (v493){
                        v494 = v467;
                    } else {
                        v494 = v468;
                    }
                    v499 = US11_1(v494);
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
    static_array<unsigned char,5l> v1316; char v1317;
    switch (v499.tag) {
        case 0: { // None
            static_array<unsigned char,4l> v501;
            static_array<unsigned char,3l> v502;
            long v503; long v504; long v505; unsigned char v506;
            Tuple21 tmp71 = Tuple21(0l, 0l, 0l, 12u);
            v503 = tmp71.v0; v504 = tmp71.v1; v505 = tmp71.v2; v506 = tmp71.v3;
            while (while_method_10(v503)){
                bool v508;
                v508 = 0l <= v503;
                bool v510;
                if (v508){
                    bool v509;
                    v509 = v503 < 7l;
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
                unsigned char v512;
                v512 = v120.v[v503];
                bool v513;
                v513 = v505 < 4l;
                long v525; long v526; unsigned char v527;
                if (v513){
                    unsigned char v514;
                    v514 = v512 / 4u;
                    bool v515;
                    v515 = v506 == v514;
                    long v516;
                    if (v515){
                        v516 = v505;
                    } else {
                        v516 = 0l;
                    }
                    bool v517;
                    v517 = 0l <= v516;
                    bool v519;
                    if (v517){
                        bool v518;
                        v518 = v516 < 4l;
                        v519 = v518;
                    } else {
                        v519 = false;
                    }
                    bool v520;
                    v520 = v519 == false;
                    if (v520){
                        assert("The read index needs to be in range for the static array." && v519);
                    } else {
                    }
                    v501.v[v516] = v512;
                    long v521;
                    v521 = v516 + 1l;
                    v525 = v503; v526 = v521; v527 = v514;
                } else {
                    break;
                }
                v504 = v525;
                v505 = v526;
                v506 = v527;
                v503 += 1l ;
            }
            bool v528;
            v528 = v505 == 4l;
            US12 v546;
            if (v528){
                long v529;
                v529 = 0l;
                while (while_method_3(v529)){
                    long v531;
                    v531 = v504 + -3l;
                    bool v532;
                    v532 = v529 < v531;
                    long v533;
                    if (v532){
                        v533 = 0l;
                    } else {
                        v533 = 4l;
                    }
                    long v534;
                    v534 = v533 + v529;
                    bool v535;
                    v535 = 0l <= v534;
                    bool v537;
                    if (v535){
                        bool v536;
                        v536 = v534 < 7l;
                        v537 = v536;
                    } else {
                        v537 = false;
                    }
                    bool v538;
                    v538 = v537 == false;
                    if (v538){
                        assert("The read index needs to be in range for the static array." && v537);
                    } else {
                    }
                    unsigned char v539;
                    v539 = v120.v[v534];
                    bool v540;
                    v540 = 0l <= v529;
                    bool v542;
                    if (v540){
                        bool v541;
                        v541 = v529 < 3l;
                        v542 = v541;
                    } else {
                        v542 = false;
                    }
                    bool v543;
                    v543 = v542 == false;
                    if (v543){
                        assert("The read index needs to be in range for the static array." && v542);
                    } else {
                    }
                    v502.v[v529] = v539;
                    v529 += 1l ;
                }
                v546 = US12_1(v501, v502);
            } else {
                v546 = US12_0();
            }
            US11 v586;
            switch (v546.tag) {
                case 0: { // None
                    v586 = US11_0();
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,4l> v547 = v546.v.case1.v0; static_array<unsigned char,3l> v548 = v546.v.case1.v1;
                    static_array<unsigned char,1l> v549;
                    long v550;
                    v550 = 0l;
                    while (while_method_6(v550)){
                        bool v552;
                        v552 = 0l <= v550;
                        bool v554;
                        if (v552){
                            bool v553;
                            v553 = v550 < 3l;
                            v554 = v553;
                        } else {
                            v554 = false;
                        }
                        bool v555;
                        v555 = v554 == false;
                        if (v555){
                            assert("The read index needs to be in range for the static array." && v554);
                        } else {
                        }
                        unsigned char v556;
                        v556 = v548.v[v550];
                        bool v558;
                        if (v552){
                            bool v557;
                            v557 = v550 < 1l;
                            v558 = v557;
                        } else {
                            v558 = false;
                        }
                        bool v559;
                        v559 = v558 == false;
                        if (v559){
                            assert("The read index needs to be in range for the static array." && v558);
                        } else {
                        }
                        v549.v[v550] = v556;
                        v550 += 1l ;
                    }
                    static_array<unsigned char,5l> v560;
                    long v561;
                    v561 = 0l;
                    while (while_method_4(v561)){
                        bool v563;
                        v563 = 0l <= v561;
                        bool v565;
                        if (v563){
                            bool v564;
                            v564 = v561 < 4l;
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
                        unsigned char v567;
                        v567 = v547.v[v561];
                        bool v569;
                        if (v563){
                            bool v568;
                            v568 = v561 < 5l;
                            v569 = v568;
                        } else {
                            v569 = false;
                        }
                        bool v570;
                        v570 = v569 == false;
                        if (v570){
                            assert("The read index needs to be in range for the static array." && v569);
                        } else {
                        }
                        v560.v[v561] = v567;
                        v561 += 1l ;
                    }
                    long v571;
                    v571 = 0l;
                    while (while_method_6(v571)){
                        bool v573;
                        v573 = 0l <= v571;
                        bool v575;
                        if (v573){
                            bool v574;
                            v574 = v571 < 1l;
                            v575 = v574;
                        } else {
                            v575 = false;
                        }
                        bool v576;
                        v576 = v575 == false;
                        if (v576){
                            assert("The read index needs to be in range for the static array." && v575);
                        } else {
                        }
                        unsigned char v577;
                        v577 = v549.v[v571];
                        long v578;
                        v578 = 4l + v571;
                        bool v579;
                        v579 = 0l <= v578;
                        bool v581;
                        if (v579){
                            bool v580;
                            v580 = v578 < 5l;
                            v581 = v580;
                        } else {
                            v581 = false;
                        }
                        bool v582;
                        v582 = v581 == false;
                        if (v582){
                            assert("The read index needs to be in range for the static array." && v581);
                        } else {
                        }
                        v560.v[v578] = v577;
                        v571 += 1l ;
                    }
                    v586 = US11_1(v560);
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            switch (v586.tag) {
                case 0: { // None
                    static_array<unsigned char,3l> v588;
                    static_array<unsigned char,4l> v589;
                    long v590; long v591; long v592; unsigned char v593;
                    Tuple21 tmp72 = Tuple21(0l, 0l, 0l, 12u);
                    v590 = tmp72.v0; v591 = tmp72.v1; v592 = tmp72.v2; v593 = tmp72.v3;
                    while (while_method_10(v590)){
                        bool v595;
                        v595 = 0l <= v590;
                        bool v597;
                        if (v595){
                            bool v596;
                            v596 = v590 < 7l;
                            v597 = v596;
                        } else {
                            v597 = false;
                        }
                        bool v598;
                        v598 = v597 == false;
                        if (v598){
                            assert("The read index needs to be in range for the static array." && v597);
                        } else {
                        }
                        unsigned char v599;
                        v599 = v120.v[v590];
                        bool v600;
                        v600 = v592 < 3l;
                        long v612; long v613; unsigned char v614;
                        if (v600){
                            unsigned char v601;
                            v601 = v599 / 4u;
                            bool v602;
                            v602 = v593 == v601;
                            long v603;
                            if (v602){
                                v603 = v592;
                            } else {
                                v603 = 0l;
                            }
                            bool v604;
                            v604 = 0l <= v603;
                            bool v606;
                            if (v604){
                                bool v605;
                                v605 = v603 < 3l;
                                v606 = v605;
                            } else {
                                v606 = false;
                            }
                            bool v607;
                            v607 = v606 == false;
                            if (v607){
                                assert("The read index needs to be in range for the static array." && v606);
                            } else {
                            }
                            v588.v[v603] = v599;
                            long v608;
                            v608 = v603 + 1l;
                            v612 = v590; v613 = v608; v614 = v601;
                        } else {
                            break;
                        }
                        v591 = v612;
                        v592 = v613;
                        v593 = v614;
                        v590 += 1l ;
                    }
                    bool v615;
                    v615 = v592 == 3l;
                    US13 v633;
                    if (v615){
                        long v616;
                        v616 = 0l;
                        while (while_method_4(v616)){
                            long v618;
                            v618 = v591 + -2l;
                            bool v619;
                            v619 = v616 < v618;
                            long v620;
                            if (v619){
                                v620 = 0l;
                            } else {
                                v620 = 3l;
                            }
                            long v621;
                            v621 = v620 + v616;
                            bool v622;
                            v622 = 0l <= v621;
                            bool v624;
                            if (v622){
                                bool v623;
                                v623 = v621 < 7l;
                                v624 = v623;
                            } else {
                                v624 = false;
                            }
                            bool v625;
                            v625 = v624 == false;
                            if (v625){
                                assert("The read index needs to be in range for the static array." && v624);
                            } else {
                            }
                            unsigned char v626;
                            v626 = v120.v[v621];
                            bool v627;
                            v627 = 0l <= v616;
                            bool v629;
                            if (v627){
                                bool v628;
                                v628 = v616 < 4l;
                                v629 = v628;
                            } else {
                                v629 = false;
                            }
                            bool v630;
                            v630 = v629 == false;
                            if (v630){
                                assert("The read index needs to be in range for the static array." && v629);
                            } else {
                            }
                            v589.v[v616] = v626;
                            v616 += 1l ;
                        }
                        v633 = US13_1(v588, v589);
                    } else {
                        v633 = US13_0();
                    }
                    US11 v713;
                    switch (v633.tag) {
                        case 0: { // None
                            v713 = US11_0();
                            break;
                        }
                        case 1: { // Some
                            static_array<unsigned char,3l> v634 = v633.v.case1.v0; static_array<unsigned char,4l> v635 = v633.v.case1.v1;
                            static_array<unsigned char,2l> v636;
                            static_array<unsigned char,2l> v637;
                            long v638; long v639; long v640; unsigned char v641;
                            Tuple21 tmp73 = Tuple21(0l, 0l, 0l, 12u);
                            v638 = tmp73.v0; v639 = tmp73.v1; v640 = tmp73.v2; v641 = tmp73.v3;
                            while (while_method_4(v638)){
                                bool v643;
                                v643 = 0l <= v638;
                                bool v645;
                                if (v643){
                                    bool v644;
                                    v644 = v638 < 4l;
                                    v645 = v644;
                                } else {
                                    v645 = false;
                                }
                                bool v646;
                                v646 = v645 == false;
                                if (v646){
                                    assert("The read index needs to be in range for the static array." && v645);
                                } else {
                                }
                                unsigned char v647;
                                v647 = v635.v[v638];
                                bool v648;
                                v648 = v640 < 2l;
                                long v660; long v661; unsigned char v662;
                                if (v648){
                                    unsigned char v649;
                                    v649 = v647 / 4u;
                                    bool v650;
                                    v650 = v641 == v649;
                                    long v651;
                                    if (v650){
                                        v651 = v640;
                                    } else {
                                        v651 = 0l;
                                    }
                                    bool v652;
                                    v652 = 0l <= v651;
                                    bool v654;
                                    if (v652){
                                        bool v653;
                                        v653 = v651 < 2l;
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
                                    v636.v[v651] = v647;
                                    long v656;
                                    v656 = v651 + 1l;
                                    v660 = v638; v661 = v656; v662 = v649;
                                } else {
                                    break;
                                }
                                v639 = v660;
                                v640 = v661;
                                v641 = v662;
                                v638 += 1l ;
                            }
                            bool v663;
                            v663 = v640 == 2l;
                            US14 v681;
                            if (v663){
                                long v664;
                                v664 = 0l;
                                while (while_method_0(v664)){
                                    long v666;
                                    v666 = v639 + -1l;
                                    bool v667;
                                    v667 = v664 < v666;
                                    long v668;
                                    if (v667){
                                        v668 = 0l;
                                    } else {
                                        v668 = 2l;
                                    }
                                    long v669;
                                    v669 = v668 + v664;
                                    bool v670;
                                    v670 = 0l <= v669;
                                    bool v672;
                                    if (v670){
                                        bool v671;
                                        v671 = v669 < 4l;
                                        v672 = v671;
                                    } else {
                                        v672 = false;
                                    }
                                    bool v673;
                                    v673 = v672 == false;
                                    if (v673){
                                        assert("The read index needs to be in range for the static array." && v672);
                                    } else {
                                    }
                                    unsigned char v674;
                                    v674 = v635.v[v669];
                                    bool v675;
                                    v675 = 0l <= v664;
                                    bool v677;
                                    if (v675){
                                        bool v676;
                                        v676 = v664 < 2l;
                                        v677 = v676;
                                    } else {
                                        v677 = false;
                                    }
                                    bool v678;
                                    v678 = v677 == false;
                                    if (v678){
                                        assert("The read index needs to be in range for the static array." && v677);
                                    } else {
                                    }
                                    v637.v[v664] = v674;
                                    v664 += 1l ;
                                }
                                v681 = US14_1(v636, v637);
                            } else {
                                v681 = US14_0();
                            }
                            switch (v681.tag) {
                                case 0: { // None
                                    v713 = US11_0();
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,2l> v682 = v681.v.case1.v0; static_array<unsigned char,2l> v683 = v681.v.case1.v1;
                                    static_array<unsigned char,5l> v684;
                                    long v685;
                                    v685 = 0l;
                                    while (while_method_3(v685)){
                                        bool v687;
                                        v687 = 0l <= v685;
                                        bool v689;
                                        if (v687){
                                            bool v688;
                                            v688 = v685 < 3l;
                                            v689 = v688;
                                        } else {
                                            v689 = false;
                                        }
                                        bool v690;
                                        v690 = v689 == false;
                                        if (v690){
                                            assert("The read index needs to be in range for the static array." && v689);
                                        } else {
                                        }
                                        unsigned char v691;
                                        v691 = v634.v[v685];
                                        bool v693;
                                        if (v687){
                                            bool v692;
                                            v692 = v685 < 5l;
                                            v693 = v692;
                                        } else {
                                            v693 = false;
                                        }
                                        bool v694;
                                        v694 = v693 == false;
                                        if (v694){
                                            assert("The read index needs to be in range for the static array." && v693);
                                        } else {
                                        }
                                        v684.v[v685] = v691;
                                        v685 += 1l ;
                                    }
                                    long v695;
                                    v695 = 0l;
                                    while (while_method_0(v695)){
                                        bool v697;
                                        v697 = 0l <= v695;
                                        bool v699;
                                        if (v697){
                                            bool v698;
                                            v698 = v695 < 2l;
                                            v699 = v698;
                                        } else {
                                            v699 = false;
                                        }
                                        bool v700;
                                        v700 = v699 == false;
                                        if (v700){
                                            assert("The read index needs to be in range for the static array." && v699);
                                        } else {
                                        }
                                        unsigned char v701;
                                        v701 = v682.v[v695];
                                        long v702;
                                        v702 = 3l + v695;
                                        bool v703;
                                        v703 = 0l <= v702;
                                        bool v705;
                                        if (v703){
                                            bool v704;
                                            v704 = v702 < 5l;
                                            v705 = v704;
                                        } else {
                                            v705 = false;
                                        }
                                        bool v706;
                                        v706 = v705 == false;
                                        if (v706){
                                            assert("The read index needs to be in range for the static array." && v705);
                                        } else {
                                        }
                                        v684.v[v702] = v701;
                                        v695 += 1l ;
                                    }
                                    v713 = US11_1(v684);
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
                    switch (v713.tag) {
                        case 0: { // None
                            static_array<unsigned char,5l> v715;
                            long v716; long v717;
                            Tuple3 tmp74 = Tuple3(0l, 0l);
                            v716 = tmp74.v0; v717 = tmp74.v1;
                            while (while_method_10(v716)){
                                bool v719;
                                v719 = 0l <= v716;
                                bool v721;
                                if (v719){
                                    bool v720;
                                    v720 = v716 < 7l;
                                    v721 = v720;
                                } else {
                                    v721 = false;
                                }
                                bool v722;
                                v722 = v721 == false;
                                if (v722){
                                    assert("The read index needs to be in range for the static array." && v721);
                                } else {
                                }
                                unsigned char v723;
                                v723 = v120.v[v716];
                                unsigned char v724;
                                v724 = v723 % 4u;
                                bool v725;
                                v725 = v724 == 0u;
                                bool v727;
                                if (v725){
                                    bool v726;
                                    v726 = v717 < 5l;
                                    v727 = v726;
                                } else {
                                    v727 = false;
                                }
                                long v733;
                                if (v727){
                                    bool v728;
                                    v728 = 0l <= v717;
                                    bool v730;
                                    if (v728){
                                        bool v729;
                                        v729 = v717 < 5l;
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
                                    v715.v[v717] = v723;
                                    long v732;
                                    v732 = v717 + 1l;
                                    v733 = v732;
                                } else {
                                    v733 = v717;
                                }
                                v717 = v733;
                                v716 += 1l ;
                            }
                            bool v734;
                            v734 = v717 == 5l;
                            US11 v737;
                            if (v734){
                                v737 = US11_1(v715);
                            } else {
                                v737 = US11_0();
                            }
                            static_array<unsigned char,5l> v738;
                            long v739; long v740;
                            Tuple3 tmp75 = Tuple3(0l, 0l);
                            v739 = tmp75.v0; v740 = tmp75.v1;
                            while (while_method_10(v739)){
                                bool v742;
                                v742 = 0l <= v739;
                                bool v744;
                                if (v742){
                                    bool v743;
                                    v743 = v739 < 7l;
                                    v744 = v743;
                                } else {
                                    v744 = false;
                                }
                                bool v745;
                                v745 = v744 == false;
                                if (v745){
                                    assert("The read index needs to be in range for the static array." && v744);
                                } else {
                                }
                                unsigned char v746;
                                v746 = v120.v[v739];
                                unsigned char v747;
                                v747 = v746 % 4u;
                                bool v748;
                                v748 = v747 == 1u;
                                bool v750;
                                if (v748){
                                    bool v749;
                                    v749 = v740 < 5l;
                                    v750 = v749;
                                } else {
                                    v750 = false;
                                }
                                long v756;
                                if (v750){
                                    bool v751;
                                    v751 = 0l <= v740;
                                    bool v753;
                                    if (v751){
                                        bool v752;
                                        v752 = v740 < 5l;
                                        v753 = v752;
                                    } else {
                                        v753 = false;
                                    }
                                    bool v754;
                                    v754 = v753 == false;
                                    if (v754){
                                        assert("The read index needs to be in range for the static array." && v753);
                                    } else {
                                    }
                                    v738.v[v740] = v746;
                                    long v755;
                                    v755 = v740 + 1l;
                                    v756 = v755;
                                } else {
                                    v756 = v740;
                                }
                                v740 = v756;
                                v739 += 1l ;
                            }
                            bool v757;
                            v757 = v740 == 5l;
                            US11 v760;
                            if (v757){
                                v760 = US11_1(v738);
                            } else {
                                v760 = US11_0();
                            }
                            US11 v793;
                            switch (v737.tag) {
                                case 0: { // None
                                    v793 = v760;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v761 = v737.v.case1.v0;
                                    switch (v760.tag) {
                                        case 0: { // None
                                            v793 = v737;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v762 = v760.v.case1.v0;
                                            US10 v763;
                                            v763 = US10_0();
                                            long v764; US10 v765;
                                            Tuple20 tmp76 = Tuple20(0l, v763);
                                            v764 = tmp76.v0; v765 = tmp76.v1;
                                            while (while_method_2(v764)){
                                                bool v767;
                                                v767 = 0l <= v764;
                                                bool v769;
                                                if (v767){
                                                    bool v768;
                                                    v768 = v764 < 5l;
                                                    v769 = v768;
                                                } else {
                                                    v769 = false;
                                                }
                                                bool v770;
                                                v770 = v769 == false;
                                                if (v770){
                                                    assert("The read index needs to be in range for the static array." && v769);
                                                } else {
                                                }
                                                unsigned char v771;
                                                v771 = v761.v[v764];
                                                bool v773;
                                                if (v767){
                                                    bool v772;
                                                    v772 = v764 < 5l;
                                                    v773 = v772;
                                                } else {
                                                    v773 = false;
                                                }
                                                bool v774;
                                                v774 = v773 == false;
                                                if (v774){
                                                    assert("The read index needs to be in range for the static array." && v773);
                                                } else {
                                                }
                                                unsigned char v775;
                                                v775 = v762.v[v764];
                                                US10 v786;
                                                switch (v765.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v776;
                                                        v776 = v771 / 4u;
                                                        unsigned char v777;
                                                        v777 = v775 / 4u;
                                                        bool v778;
                                                        v778 = v776 < v777;
                                                        if (v778){
                                                            v786 = US10_2();
                                                        } else {
                                                            bool v780;
                                                            v780 = v776 > v777;
                                                            if (v780){
                                                                v786 = US10_1();
                                                            } else {
                                                                v786 = US10_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v765 = v786;
                                                v764 += 1l ;
                                            }
                                            bool v787;
                                            switch (v765.tag) {
                                                case 1: { // Gt
                                                    v787 = true;
                                                    break;
                                                }
                                                default: {
                                                    v787 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v788;
                                            if (v787){
                                                v788 = v761;
                                            } else {
                                                v788 = v762;
                                            }
                                            v793 = US11_1(v788);
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
                            static_array<unsigned char,5l> v794;
                            long v795; long v796;
                            Tuple3 tmp77 = Tuple3(0l, 0l);
                            v795 = tmp77.v0; v796 = tmp77.v1;
                            while (while_method_10(v795)){
                                bool v798;
                                v798 = 0l <= v795;
                                bool v800;
                                if (v798){
                                    bool v799;
                                    v799 = v795 < 7l;
                                    v800 = v799;
                                } else {
                                    v800 = false;
                                }
                                bool v801;
                                v801 = v800 == false;
                                if (v801){
                                    assert("The read index needs to be in range for the static array." && v800);
                                } else {
                                }
                                unsigned char v802;
                                v802 = v120.v[v795];
                                unsigned char v803;
                                v803 = v802 % 4u;
                                bool v804;
                                v804 = v803 == 2u;
                                bool v806;
                                if (v804){
                                    bool v805;
                                    v805 = v796 < 5l;
                                    v806 = v805;
                                } else {
                                    v806 = false;
                                }
                                long v812;
                                if (v806){
                                    bool v807;
                                    v807 = 0l <= v796;
                                    bool v809;
                                    if (v807){
                                        bool v808;
                                        v808 = v796 < 5l;
                                        v809 = v808;
                                    } else {
                                        v809 = false;
                                    }
                                    bool v810;
                                    v810 = v809 == false;
                                    if (v810){
                                        assert("The read index needs to be in range for the static array." && v809);
                                    } else {
                                    }
                                    v794.v[v796] = v802;
                                    long v811;
                                    v811 = v796 + 1l;
                                    v812 = v811;
                                } else {
                                    v812 = v796;
                                }
                                v796 = v812;
                                v795 += 1l ;
                            }
                            bool v813;
                            v813 = v796 == 5l;
                            US11 v816;
                            if (v813){
                                v816 = US11_1(v794);
                            } else {
                                v816 = US11_0();
                            }
                            US11 v849;
                            switch (v793.tag) {
                                case 0: { // None
                                    v849 = v816;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v817 = v793.v.case1.v0;
                                    switch (v816.tag) {
                                        case 0: { // None
                                            v849 = v793;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v818 = v816.v.case1.v0;
                                            US10 v819;
                                            v819 = US10_0();
                                            long v820; US10 v821;
                                            Tuple20 tmp78 = Tuple20(0l, v819);
                                            v820 = tmp78.v0; v821 = tmp78.v1;
                                            while (while_method_2(v820)){
                                                bool v823;
                                                v823 = 0l <= v820;
                                                bool v825;
                                                if (v823){
                                                    bool v824;
                                                    v824 = v820 < 5l;
                                                    v825 = v824;
                                                } else {
                                                    v825 = false;
                                                }
                                                bool v826;
                                                v826 = v825 == false;
                                                if (v826){
                                                    assert("The read index needs to be in range for the static array." && v825);
                                                } else {
                                                }
                                                unsigned char v827;
                                                v827 = v817.v[v820];
                                                bool v829;
                                                if (v823){
                                                    bool v828;
                                                    v828 = v820 < 5l;
                                                    v829 = v828;
                                                } else {
                                                    v829 = false;
                                                }
                                                bool v830;
                                                v830 = v829 == false;
                                                if (v830){
                                                    assert("The read index needs to be in range for the static array." && v829);
                                                } else {
                                                }
                                                unsigned char v831;
                                                v831 = v818.v[v820];
                                                US10 v842;
                                                switch (v821.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v832;
                                                        v832 = v827 / 4u;
                                                        unsigned char v833;
                                                        v833 = v831 / 4u;
                                                        bool v834;
                                                        v834 = v832 < v833;
                                                        if (v834){
                                                            v842 = US10_2();
                                                        } else {
                                                            bool v836;
                                                            v836 = v832 > v833;
                                                            if (v836){
                                                                v842 = US10_1();
                                                            } else {
                                                                v842 = US10_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v821 = v842;
                                                v820 += 1l ;
                                            }
                                            bool v843;
                                            switch (v821.tag) {
                                                case 1: { // Gt
                                                    v843 = true;
                                                    break;
                                                }
                                                default: {
                                                    v843 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v844;
                                            if (v843){
                                                v844 = v817;
                                            } else {
                                                v844 = v818;
                                            }
                                            v849 = US11_1(v844);
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
                            static_array<unsigned char,5l> v850;
                            long v851; long v852;
                            Tuple3 tmp79 = Tuple3(0l, 0l);
                            v851 = tmp79.v0; v852 = tmp79.v1;
                            while (while_method_10(v851)){
                                bool v854;
                                v854 = 0l <= v851;
                                bool v856;
                                if (v854){
                                    bool v855;
                                    v855 = v851 < 7l;
                                    v856 = v855;
                                } else {
                                    v856 = false;
                                }
                                bool v857;
                                v857 = v856 == false;
                                if (v857){
                                    assert("The read index needs to be in range for the static array." && v856);
                                } else {
                                }
                                unsigned char v858;
                                v858 = v120.v[v851];
                                unsigned char v859;
                                v859 = v858 % 4u;
                                bool v860;
                                v860 = v859 == 3u;
                                bool v862;
                                if (v860){
                                    bool v861;
                                    v861 = v852 < 5l;
                                    v862 = v861;
                                } else {
                                    v862 = false;
                                }
                                long v868;
                                if (v862){
                                    bool v863;
                                    v863 = 0l <= v852;
                                    bool v865;
                                    if (v863){
                                        bool v864;
                                        v864 = v852 < 5l;
                                        v865 = v864;
                                    } else {
                                        v865 = false;
                                    }
                                    bool v866;
                                    v866 = v865 == false;
                                    if (v866){
                                        assert("The read index needs to be in range for the static array." && v865);
                                    } else {
                                    }
                                    v850.v[v852] = v858;
                                    long v867;
                                    v867 = v852 + 1l;
                                    v868 = v867;
                                } else {
                                    v868 = v852;
                                }
                                v852 = v868;
                                v851 += 1l ;
                            }
                            bool v869;
                            v869 = v852 == 5l;
                            US11 v872;
                            if (v869){
                                v872 = US11_1(v850);
                            } else {
                                v872 = US11_0();
                            }
                            US11 v905;
                            switch (v849.tag) {
                                case 0: { // None
                                    v905 = v872;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v873 = v849.v.case1.v0;
                                    switch (v872.tag) {
                                        case 0: { // None
                                            v905 = v849;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v874 = v872.v.case1.v0;
                                            US10 v875;
                                            v875 = US10_0();
                                            long v876; US10 v877;
                                            Tuple20 tmp80 = Tuple20(0l, v875);
                                            v876 = tmp80.v0; v877 = tmp80.v1;
                                            while (while_method_2(v876)){
                                                bool v879;
                                                v879 = 0l <= v876;
                                                bool v881;
                                                if (v879){
                                                    bool v880;
                                                    v880 = v876 < 5l;
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
                                                v883 = v873.v[v876];
                                                bool v885;
                                                if (v879){
                                                    bool v884;
                                                    v884 = v876 < 5l;
                                                    v885 = v884;
                                                } else {
                                                    v885 = false;
                                                }
                                                bool v886;
                                                v886 = v885 == false;
                                                if (v886){
                                                    assert("The read index needs to be in range for the static array." && v885);
                                                } else {
                                                }
                                                unsigned char v887;
                                                v887 = v874.v[v876];
                                                US10 v898;
                                                switch (v877.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v888;
                                                        v888 = v883 / 4u;
                                                        unsigned char v889;
                                                        v889 = v887 / 4u;
                                                        bool v890;
                                                        v890 = v888 < v889;
                                                        if (v890){
                                                            v898 = US10_2();
                                                        } else {
                                                            bool v892;
                                                            v892 = v888 > v889;
                                                            if (v892){
                                                                v898 = US10_1();
                                                            } else {
                                                                v898 = US10_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v877 = v898;
                                                v876 += 1l ;
                                            }
                                            bool v899;
                                            switch (v877.tag) {
                                                case 1: { // Gt
                                                    v899 = true;
                                                    break;
                                                }
                                                default: {
                                                    v899 = false;
                                                }
                                            }
                                            static_array<unsigned char,5l> v900;
                                            if (v899){
                                                v900 = v873;
                                            } else {
                                                v900 = v874;
                                            }
                                            v905 = US11_1(v900);
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
                            switch (v905.tag) {
                                case 0: { // None
                                    static_array<unsigned char,5l> v907;
                                    long v908; long v909; unsigned char v910;
                                    Tuple19 tmp81 = Tuple19(0l, 0l, 12u);
                                    v908 = tmp81.v0; v909 = tmp81.v1; v910 = tmp81.v2;
                                    while (while_method_10(v908)){
                                        bool v912;
                                        v912 = 0l <= v908;
                                        bool v914;
                                        if (v912){
                                            bool v913;
                                            v913 = v908 < 7l;
                                            v914 = v913;
                                        } else {
                                            v914 = false;
                                        }
                                        bool v915;
                                        v915 = v914 == false;
                                        if (v915){
                                            assert("The read index needs to be in range for the static array." && v914);
                                        } else {
                                        }
                                        unsigned char v916;
                                        v916 = v120.v[v908];
                                        bool v917;
                                        v917 = v909 < 5l;
                                        long v933; unsigned char v934;
                                        if (v917){
                                            unsigned char v918;
                                            v918 = v916 / 4u;
                                            unsigned char v919;
                                            v919 = v918 - 1u;
                                            bool v920;
                                            v920 = v910 == v919;
                                            bool v921;
                                            v921 = v920 != true;
                                            if (v921){
                                                bool v922;
                                                v922 = v910 == v918;
                                                long v923;
                                                if (v922){
                                                    v923 = v909;
                                                } else {
                                                    v923 = 0l;
                                                }
                                                bool v924;
                                                v924 = 0l <= v923;
                                                bool v926;
                                                if (v924){
                                                    bool v925;
                                                    v925 = v923 < 5l;
                                                    v926 = v925;
                                                } else {
                                                    v926 = false;
                                                }
                                                bool v927;
                                                v927 = v926 == false;
                                                if (v927){
                                                    assert("The read index needs to be in range for the static array." && v926);
                                                } else {
                                                }
                                                v907.v[v923] = v916;
                                                long v928;
                                                v928 = v923 + 1l;
                                                v933 = v928; v934 = v919;
                                            } else {
                                                v933 = v909; v934 = v910;
                                            }
                                        } else {
                                            break;
                                        }
                                        v909 = v933;
                                        v910 = v934;
                                        v908 += 1l ;
                                    }
                                    bool v935;
                                    v935 = v909 == 4l;
                                    bool v943;
                                    if (v935){
                                        unsigned char v936;
                                        v936 = v910 + 1u;
                                        bool v937;
                                        v937 = v936 == 0u;
                                        if (v937){
                                            unsigned char v938;
                                            v938 = v120.v[0l];
                                            unsigned char v939;
                                            v939 = v938 / 4u;
                                            bool v940;
                                            v940 = v939 == 12u;
                                            if (v940){
                                                v907.v[4l] = v938;
                                                v943 = true;
                                            } else {
                                                v943 = false;
                                            }
                                        } else {
                                            v943 = false;
                                        }
                                    } else {
                                        v943 = false;
                                    }
                                    US11 v949;
                                    if (v943){
                                        v949 = US11_1(v907);
                                    } else {
                                        bool v945;
                                        v945 = v909 == 5l;
                                        if (v945){
                                            v949 = US11_1(v907);
                                        } else {
                                            v949 = US11_0();
                                        }
                                    }
                                    switch (v949.tag) {
                                        case 0: { // None
                                            static_array<unsigned char,3l> v951;
                                            static_array<unsigned char,4l> v952;
                                            long v953; long v954; long v955; unsigned char v956;
                                            Tuple21 tmp82 = Tuple21(0l, 0l, 0l, 12u);
                                            v953 = tmp82.v0; v954 = tmp82.v1; v955 = tmp82.v2; v956 = tmp82.v3;
                                            while (while_method_10(v953)){
                                                bool v958;
                                                v958 = 0l <= v953;
                                                bool v960;
                                                if (v958){
                                                    bool v959;
                                                    v959 = v953 < 7l;
                                                    v960 = v959;
                                                } else {
                                                    v960 = false;
                                                }
                                                bool v961;
                                                v961 = v960 == false;
                                                if (v961){
                                                    assert("The read index needs to be in range for the static array." && v960);
                                                } else {
                                                }
                                                unsigned char v962;
                                                v962 = v120.v[v953];
                                                bool v963;
                                                v963 = v955 < 3l;
                                                long v975; long v976; unsigned char v977;
                                                if (v963){
                                                    unsigned char v964;
                                                    v964 = v962 / 4u;
                                                    bool v965;
                                                    v965 = v956 == v964;
                                                    long v966;
                                                    if (v965){
                                                        v966 = v955;
                                                    } else {
                                                        v966 = 0l;
                                                    }
                                                    bool v967;
                                                    v967 = 0l <= v966;
                                                    bool v969;
                                                    if (v967){
                                                        bool v968;
                                                        v968 = v966 < 3l;
                                                        v969 = v968;
                                                    } else {
                                                        v969 = false;
                                                    }
                                                    bool v970;
                                                    v970 = v969 == false;
                                                    if (v970){
                                                        assert("The read index needs to be in range for the static array." && v969);
                                                    } else {
                                                    }
                                                    v951.v[v966] = v962;
                                                    long v971;
                                                    v971 = v966 + 1l;
                                                    v975 = v953; v976 = v971; v977 = v964;
                                                } else {
                                                    break;
                                                }
                                                v954 = v975;
                                                v955 = v976;
                                                v956 = v977;
                                                v953 += 1l ;
                                            }
                                            bool v978;
                                            v978 = v955 == 3l;
                                            US13 v996;
                                            if (v978){
                                                long v979;
                                                v979 = 0l;
                                                while (while_method_4(v979)){
                                                    long v981;
                                                    v981 = v954 + -2l;
                                                    bool v982;
                                                    v982 = v979 < v981;
                                                    long v983;
                                                    if (v982){
                                                        v983 = 0l;
                                                    } else {
                                                        v983 = 3l;
                                                    }
                                                    long v984;
                                                    v984 = v983 + v979;
                                                    bool v985;
                                                    v985 = 0l <= v984;
                                                    bool v987;
                                                    if (v985){
                                                        bool v986;
                                                        v986 = v984 < 7l;
                                                        v987 = v986;
                                                    } else {
                                                        v987 = false;
                                                    }
                                                    bool v988;
                                                    v988 = v987 == false;
                                                    if (v988){
                                                        assert("The read index needs to be in range for the static array." && v987);
                                                    } else {
                                                    }
                                                    unsigned char v989;
                                                    v989 = v120.v[v984];
                                                    bool v990;
                                                    v990 = 0l <= v979;
                                                    bool v992;
                                                    if (v990){
                                                        bool v991;
                                                        v991 = v979 < 4l;
                                                        v992 = v991;
                                                    } else {
                                                        v992 = false;
                                                    }
                                                    bool v993;
                                                    v993 = v992 == false;
                                                    if (v993){
                                                        assert("The read index needs to be in range for the static array." && v992);
                                                    } else {
                                                    }
                                                    v952.v[v979] = v989;
                                                    v979 += 1l ;
                                                }
                                                v996 = US13_1(v951, v952);
                                            } else {
                                                v996 = US13_0();
                                            }
                                            US11 v1036;
                                            switch (v996.tag) {
                                                case 0: { // None
                                                    v1036 = US11_0();
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<unsigned char,3l> v997 = v996.v.case1.v0; static_array<unsigned char,4l> v998 = v996.v.case1.v1;
                                                    static_array<unsigned char,2l> v999;
                                                    long v1000;
                                                    v1000 = 0l;
                                                    while (while_method_0(v1000)){
                                                        bool v1002;
                                                        v1002 = 0l <= v1000;
                                                        bool v1004;
                                                        if (v1002){
                                                            bool v1003;
                                                            v1003 = v1000 < 4l;
                                                            v1004 = v1003;
                                                        } else {
                                                            v1004 = false;
                                                        }
                                                        bool v1005;
                                                        v1005 = v1004 == false;
                                                        if (v1005){
                                                            assert("The read index needs to be in range for the static array." && v1004);
                                                        } else {
                                                        }
                                                        unsigned char v1006;
                                                        v1006 = v998.v[v1000];
                                                        bool v1008;
                                                        if (v1002){
                                                            bool v1007;
                                                            v1007 = v1000 < 2l;
                                                            v1008 = v1007;
                                                        } else {
                                                            v1008 = false;
                                                        }
                                                        bool v1009;
                                                        v1009 = v1008 == false;
                                                        if (v1009){
                                                            assert("The read index needs to be in range for the static array." && v1008);
                                                        } else {
                                                        }
                                                        v999.v[v1000] = v1006;
                                                        v1000 += 1l ;
                                                    }
                                                    static_array<unsigned char,5l> v1010;
                                                    long v1011;
                                                    v1011 = 0l;
                                                    while (while_method_3(v1011)){
                                                        bool v1013;
                                                        v1013 = 0l <= v1011;
                                                        bool v1015;
                                                        if (v1013){
                                                            bool v1014;
                                                            v1014 = v1011 < 3l;
                                                            v1015 = v1014;
                                                        } else {
                                                            v1015 = false;
                                                        }
                                                        bool v1016;
                                                        v1016 = v1015 == false;
                                                        if (v1016){
                                                            assert("The read index needs to be in range for the static array." && v1015);
                                                        } else {
                                                        }
                                                        unsigned char v1017;
                                                        v1017 = v997.v[v1011];
                                                        bool v1019;
                                                        if (v1013){
                                                            bool v1018;
                                                            v1018 = v1011 < 5l;
                                                            v1019 = v1018;
                                                        } else {
                                                            v1019 = false;
                                                        }
                                                        bool v1020;
                                                        v1020 = v1019 == false;
                                                        if (v1020){
                                                            assert("The read index needs to be in range for the static array." && v1019);
                                                        } else {
                                                        }
                                                        v1010.v[v1011] = v1017;
                                                        v1011 += 1l ;
                                                    }
                                                    long v1021;
                                                    v1021 = 0l;
                                                    while (while_method_0(v1021)){
                                                        bool v1023;
                                                        v1023 = 0l <= v1021;
                                                        bool v1025;
                                                        if (v1023){
                                                            bool v1024;
                                                            v1024 = v1021 < 2l;
                                                            v1025 = v1024;
                                                        } else {
                                                            v1025 = false;
                                                        }
                                                        bool v1026;
                                                        v1026 = v1025 == false;
                                                        if (v1026){
                                                            assert("The read index needs to be in range for the static array." && v1025);
                                                        } else {
                                                        }
                                                        unsigned char v1027;
                                                        v1027 = v999.v[v1021];
                                                        long v1028;
                                                        v1028 = 3l + v1021;
                                                        bool v1029;
                                                        v1029 = 0l <= v1028;
                                                        bool v1031;
                                                        if (v1029){
                                                            bool v1030;
                                                            v1030 = v1028 < 5l;
                                                            v1031 = v1030;
                                                        } else {
                                                            v1031 = false;
                                                        }
                                                        bool v1032;
                                                        v1032 = v1031 == false;
                                                        if (v1032){
                                                            assert("The read index needs to be in range for the static array." && v1031);
                                                        } else {
                                                        }
                                                        v1010.v[v1028] = v1027;
                                                        v1021 += 1l ;
                                                    }
                                                    v1036 = US11_1(v1010);
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            switch (v1036.tag) {
                                                case 0: { // None
                                                    static_array<unsigned char,2l> v1038;
                                                    static_array<unsigned char,5l> v1039;
                                                    long v1040; long v1041; long v1042; unsigned char v1043;
                                                    Tuple21 tmp83 = Tuple21(0l, 0l, 0l, 12u);
                                                    v1040 = tmp83.v0; v1041 = tmp83.v1; v1042 = tmp83.v2; v1043 = tmp83.v3;
                                                    while (while_method_10(v1040)){
                                                        bool v1045;
                                                        v1045 = 0l <= v1040;
                                                        bool v1047;
                                                        if (v1045){
                                                            bool v1046;
                                                            v1046 = v1040 < 7l;
                                                            v1047 = v1046;
                                                        } else {
                                                            v1047 = false;
                                                        }
                                                        bool v1048;
                                                        v1048 = v1047 == false;
                                                        if (v1048){
                                                            assert("The read index needs to be in range for the static array." && v1047);
                                                        } else {
                                                        }
                                                        unsigned char v1049;
                                                        v1049 = v120.v[v1040];
                                                        bool v1050;
                                                        v1050 = v1042 < 2l;
                                                        long v1062; long v1063; unsigned char v1064;
                                                        if (v1050){
                                                            unsigned char v1051;
                                                            v1051 = v1049 / 4u;
                                                            bool v1052;
                                                            v1052 = v1043 == v1051;
                                                            long v1053;
                                                            if (v1052){
                                                                v1053 = v1042;
                                                            } else {
                                                                v1053 = 0l;
                                                            }
                                                            bool v1054;
                                                            v1054 = 0l <= v1053;
                                                            bool v1056;
                                                            if (v1054){
                                                                bool v1055;
                                                                v1055 = v1053 < 2l;
                                                                v1056 = v1055;
                                                            } else {
                                                                v1056 = false;
                                                            }
                                                            bool v1057;
                                                            v1057 = v1056 == false;
                                                            if (v1057){
                                                                assert("The read index needs to be in range for the static array." && v1056);
                                                            } else {
                                                            }
                                                            v1038.v[v1053] = v1049;
                                                            long v1058;
                                                            v1058 = v1053 + 1l;
                                                            v1062 = v1040; v1063 = v1058; v1064 = v1051;
                                                        } else {
                                                            break;
                                                        }
                                                        v1041 = v1062;
                                                        v1042 = v1063;
                                                        v1043 = v1064;
                                                        v1040 += 1l ;
                                                    }
                                                    bool v1065;
                                                    v1065 = v1042 == 2l;
                                                    US15 v1083;
                                                    if (v1065){
                                                        long v1066;
                                                        v1066 = 0l;
                                                        while (while_method_2(v1066)){
                                                            long v1068;
                                                            v1068 = v1041 + -1l;
                                                            bool v1069;
                                                            v1069 = v1066 < v1068;
                                                            long v1070;
                                                            if (v1069){
                                                                v1070 = 0l;
                                                            } else {
                                                                v1070 = 2l;
                                                            }
                                                            long v1071;
                                                            v1071 = v1070 + v1066;
                                                            bool v1072;
                                                            v1072 = 0l <= v1071;
                                                            bool v1074;
                                                            if (v1072){
                                                                bool v1073;
                                                                v1073 = v1071 < 7l;
                                                                v1074 = v1073;
                                                            } else {
                                                                v1074 = false;
                                                            }
                                                            bool v1075;
                                                            v1075 = v1074 == false;
                                                            if (v1075){
                                                                assert("The read index needs to be in range for the static array." && v1074);
                                                            } else {
                                                            }
                                                            unsigned char v1076;
                                                            v1076 = v120.v[v1071];
                                                            bool v1077;
                                                            v1077 = 0l <= v1066;
                                                            bool v1079;
                                                            if (v1077){
                                                                bool v1078;
                                                                v1078 = v1066 < 5l;
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
                                                            v1039.v[v1066] = v1076;
                                                            v1066 += 1l ;
                                                        }
                                                        v1083 = US15_1(v1038, v1039);
                                                    } else {
                                                        v1083 = US15_0();
                                                    }
                                                    US11 v1186;
                                                    switch (v1083.tag) {
                                                        case 0: { // None
                                                            v1186 = US11_0();
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<unsigned char,2l> v1084 = v1083.v.case1.v0; static_array<unsigned char,5l> v1085 = v1083.v.case1.v1;
                                                            static_array<unsigned char,2l> v1086;
                                                            static_array<unsigned char,3l> v1087;
                                                            long v1088; long v1089; long v1090; unsigned char v1091;
                                                            Tuple21 tmp84 = Tuple21(0l, 0l, 0l, 12u);
                                                            v1088 = tmp84.v0; v1089 = tmp84.v1; v1090 = tmp84.v2; v1091 = tmp84.v3;
                                                            while (while_method_2(v1088)){
                                                                bool v1093;
                                                                v1093 = 0l <= v1088;
                                                                bool v1095;
                                                                if (v1093){
                                                                    bool v1094;
                                                                    v1094 = v1088 < 5l;
                                                                    v1095 = v1094;
                                                                } else {
                                                                    v1095 = false;
                                                                }
                                                                bool v1096;
                                                                v1096 = v1095 == false;
                                                                if (v1096){
                                                                    assert("The read index needs to be in range for the static array." && v1095);
                                                                } else {
                                                                }
                                                                unsigned char v1097;
                                                                v1097 = v1085.v[v1088];
                                                                bool v1098;
                                                                v1098 = v1090 < 2l;
                                                                long v1110; long v1111; unsigned char v1112;
                                                                if (v1098){
                                                                    unsigned char v1099;
                                                                    v1099 = v1097 / 4u;
                                                                    bool v1100;
                                                                    v1100 = v1091 == v1099;
                                                                    long v1101;
                                                                    if (v1100){
                                                                        v1101 = v1090;
                                                                    } else {
                                                                        v1101 = 0l;
                                                                    }
                                                                    bool v1102;
                                                                    v1102 = 0l <= v1101;
                                                                    bool v1104;
                                                                    if (v1102){
                                                                        bool v1103;
                                                                        v1103 = v1101 < 2l;
                                                                        v1104 = v1103;
                                                                    } else {
                                                                        v1104 = false;
                                                                    }
                                                                    bool v1105;
                                                                    v1105 = v1104 == false;
                                                                    if (v1105){
                                                                        assert("The read index needs to be in range for the static array." && v1104);
                                                                    } else {
                                                                    }
                                                                    v1086.v[v1101] = v1097;
                                                                    long v1106;
                                                                    v1106 = v1101 + 1l;
                                                                    v1110 = v1088; v1111 = v1106; v1112 = v1099;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1089 = v1110;
                                                                v1090 = v1111;
                                                                v1091 = v1112;
                                                                v1088 += 1l ;
                                                            }
                                                            bool v1113;
                                                            v1113 = v1090 == 2l;
                                                            US16 v1131;
                                                            if (v1113){
                                                                long v1114;
                                                                v1114 = 0l;
                                                                while (while_method_3(v1114)){
                                                                    long v1116;
                                                                    v1116 = v1089 + -1l;
                                                                    bool v1117;
                                                                    v1117 = v1114 < v1116;
                                                                    long v1118;
                                                                    if (v1117){
                                                                        v1118 = 0l;
                                                                    } else {
                                                                        v1118 = 2l;
                                                                    }
                                                                    long v1119;
                                                                    v1119 = v1118 + v1114;
                                                                    bool v1120;
                                                                    v1120 = 0l <= v1119;
                                                                    bool v1122;
                                                                    if (v1120){
                                                                        bool v1121;
                                                                        v1121 = v1119 < 5l;
                                                                        v1122 = v1121;
                                                                    } else {
                                                                        v1122 = false;
                                                                    }
                                                                    bool v1123;
                                                                    v1123 = v1122 == false;
                                                                    if (v1123){
                                                                        assert("The read index needs to be in range for the static array." && v1122);
                                                                    } else {
                                                                    }
                                                                    unsigned char v1124;
                                                                    v1124 = v1085.v[v1119];
                                                                    bool v1125;
                                                                    v1125 = 0l <= v1114;
                                                                    bool v1127;
                                                                    if (v1125){
                                                                        bool v1126;
                                                                        v1126 = v1114 < 3l;
                                                                        v1127 = v1126;
                                                                    } else {
                                                                        v1127 = false;
                                                                    }
                                                                    bool v1128;
                                                                    v1128 = v1127 == false;
                                                                    if (v1128){
                                                                        assert("The read index needs to be in range for the static array." && v1127);
                                                                    } else {
                                                                    }
                                                                    v1087.v[v1114] = v1124;
                                                                    v1114 += 1l ;
                                                                }
                                                                v1131 = US16_1(v1086, v1087);
                                                            } else {
                                                                v1131 = US16_0();
                                                            }
                                                            switch (v1131.tag) {
                                                                case 0: { // None
                                                                    v1186 = US11_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,2l> v1132 = v1131.v.case1.v0; static_array<unsigned char,3l> v1133 = v1131.v.case1.v1;
                                                                    static_array<unsigned char,1l> v1134;
                                                                    long v1135;
                                                                    v1135 = 0l;
                                                                    while (while_method_6(v1135)){
                                                                        bool v1137;
                                                                        v1137 = 0l <= v1135;
                                                                        bool v1139;
                                                                        if (v1137){
                                                                            bool v1138;
                                                                            v1138 = v1135 < 3l;
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
                                                                        v1141 = v1133.v[v1135];
                                                                        bool v1143;
                                                                        if (v1137){
                                                                            bool v1142;
                                                                            v1142 = v1135 < 1l;
                                                                            v1143 = v1142;
                                                                        } else {
                                                                            v1143 = false;
                                                                        }
                                                                        bool v1144;
                                                                        v1144 = v1143 == false;
                                                                        if (v1144){
                                                                            assert("The read index needs to be in range for the static array." && v1143);
                                                                        } else {
                                                                        }
                                                                        v1134.v[v1135] = v1141;
                                                                        v1135 += 1l ;
                                                                    }
                                                                    static_array<unsigned char,5l> v1145;
                                                                    long v1146;
                                                                    v1146 = 0l;
                                                                    while (while_method_0(v1146)){
                                                                        bool v1148;
                                                                        v1148 = 0l <= v1146;
                                                                        bool v1150;
                                                                        if (v1148){
                                                                            bool v1149;
                                                                            v1149 = v1146 < 2l;
                                                                            v1150 = v1149;
                                                                        } else {
                                                                            v1150 = false;
                                                                        }
                                                                        bool v1151;
                                                                        v1151 = v1150 == false;
                                                                        if (v1151){
                                                                            assert("The read index needs to be in range for the static array." && v1150);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1152;
                                                                        v1152 = v1084.v[v1146];
                                                                        bool v1154;
                                                                        if (v1148){
                                                                            bool v1153;
                                                                            v1153 = v1146 < 5l;
                                                                            v1154 = v1153;
                                                                        } else {
                                                                            v1154 = false;
                                                                        }
                                                                        bool v1155;
                                                                        v1155 = v1154 == false;
                                                                        if (v1155){
                                                                            assert("The read index needs to be in range for the static array." && v1154);
                                                                        } else {
                                                                        }
                                                                        v1145.v[v1146] = v1152;
                                                                        v1146 += 1l ;
                                                                    }
                                                                    long v1156;
                                                                    v1156 = 0l;
                                                                    while (while_method_0(v1156)){
                                                                        bool v1158;
                                                                        v1158 = 0l <= v1156;
                                                                        bool v1160;
                                                                        if (v1158){
                                                                            bool v1159;
                                                                            v1159 = v1156 < 2l;
                                                                            v1160 = v1159;
                                                                        } else {
                                                                            v1160 = false;
                                                                        }
                                                                        bool v1161;
                                                                        v1161 = v1160 == false;
                                                                        if (v1161){
                                                                            assert("The read index needs to be in range for the static array." && v1160);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1162;
                                                                        v1162 = v1132.v[v1156];
                                                                        long v1163;
                                                                        v1163 = 2l + v1156;
                                                                        bool v1164;
                                                                        v1164 = 0l <= v1163;
                                                                        bool v1166;
                                                                        if (v1164){
                                                                            bool v1165;
                                                                            v1165 = v1163 < 5l;
                                                                            v1166 = v1165;
                                                                        } else {
                                                                            v1166 = false;
                                                                        }
                                                                        bool v1167;
                                                                        v1167 = v1166 == false;
                                                                        if (v1167){
                                                                            assert("The read index needs to be in range for the static array." && v1166);
                                                                        } else {
                                                                        }
                                                                        v1145.v[v1163] = v1162;
                                                                        v1156 += 1l ;
                                                                    }
                                                                    long v1168;
                                                                    v1168 = 0l;
                                                                    while (while_method_6(v1168)){
                                                                        bool v1170;
                                                                        v1170 = 0l <= v1168;
                                                                        bool v1172;
                                                                        if (v1170){
                                                                            bool v1171;
                                                                            v1171 = v1168 < 1l;
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
                                                                        unsigned char v1174;
                                                                        v1174 = v1134.v[v1168];
                                                                        long v1175;
                                                                        v1175 = 4l + v1168;
                                                                        bool v1176;
                                                                        v1176 = 0l <= v1175;
                                                                        bool v1178;
                                                                        if (v1176){
                                                                            bool v1177;
                                                                            v1177 = v1175 < 5l;
                                                                            v1178 = v1177;
                                                                        } else {
                                                                            v1178 = false;
                                                                        }
                                                                        bool v1179;
                                                                        v1179 = v1178 == false;
                                                                        if (v1179){
                                                                            assert("The read index needs to be in range for the static array." && v1178);
                                                                        } else {
                                                                        }
                                                                        v1145.v[v1175] = v1174;
                                                                        v1168 += 1l ;
                                                                    }
                                                                    v1186 = US11_1(v1145);
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
                                                    switch (v1186.tag) {
                                                        case 0: { // None
                                                            static_array<unsigned char,2l> v1188;
                                                            static_array<unsigned char,5l> v1189;
                                                            long v1190; long v1191; long v1192; unsigned char v1193;
                                                            Tuple21 tmp85 = Tuple21(0l, 0l, 0l, 12u);
                                                            v1190 = tmp85.v0; v1191 = tmp85.v1; v1192 = tmp85.v2; v1193 = tmp85.v3;
                                                            while (while_method_10(v1190)){
                                                                bool v1195;
                                                                v1195 = 0l <= v1190;
                                                                bool v1197;
                                                                if (v1195){
                                                                    bool v1196;
                                                                    v1196 = v1190 < 7l;
                                                                    v1197 = v1196;
                                                                } else {
                                                                    v1197 = false;
                                                                }
                                                                bool v1198;
                                                                v1198 = v1197 == false;
                                                                if (v1198){
                                                                    assert("The read index needs to be in range for the static array." && v1197);
                                                                } else {
                                                                }
                                                                unsigned char v1199;
                                                                v1199 = v120.v[v1190];
                                                                bool v1200;
                                                                v1200 = v1192 < 2l;
                                                                long v1212; long v1213; unsigned char v1214;
                                                                if (v1200){
                                                                    unsigned char v1201;
                                                                    v1201 = v1199 / 4u;
                                                                    bool v1202;
                                                                    v1202 = v1193 == v1201;
                                                                    long v1203;
                                                                    if (v1202){
                                                                        v1203 = v1192;
                                                                    } else {
                                                                        v1203 = 0l;
                                                                    }
                                                                    bool v1204;
                                                                    v1204 = 0l <= v1203;
                                                                    bool v1206;
                                                                    if (v1204){
                                                                        bool v1205;
                                                                        v1205 = v1203 < 2l;
                                                                        v1206 = v1205;
                                                                    } else {
                                                                        v1206 = false;
                                                                    }
                                                                    bool v1207;
                                                                    v1207 = v1206 == false;
                                                                    if (v1207){
                                                                        assert("The read index needs to be in range for the static array." && v1206);
                                                                    } else {
                                                                    }
                                                                    v1188.v[v1203] = v1199;
                                                                    long v1208;
                                                                    v1208 = v1203 + 1l;
                                                                    v1212 = v1190; v1213 = v1208; v1214 = v1201;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1191 = v1212;
                                                                v1192 = v1213;
                                                                v1193 = v1214;
                                                                v1190 += 1l ;
                                                            }
                                                            bool v1215;
                                                            v1215 = v1192 == 2l;
                                                            US15 v1233;
                                                            if (v1215){
                                                                long v1216;
                                                                v1216 = 0l;
                                                                while (while_method_2(v1216)){
                                                                    long v1218;
                                                                    v1218 = v1191 + -1l;
                                                                    bool v1219;
                                                                    v1219 = v1216 < v1218;
                                                                    long v1220;
                                                                    if (v1219){
                                                                        v1220 = 0l;
                                                                    } else {
                                                                        v1220 = 2l;
                                                                    }
                                                                    long v1221;
                                                                    v1221 = v1220 + v1216;
                                                                    bool v1222;
                                                                    v1222 = 0l <= v1221;
                                                                    bool v1224;
                                                                    if (v1222){
                                                                        bool v1223;
                                                                        v1223 = v1221 < 7l;
                                                                        v1224 = v1223;
                                                                    } else {
                                                                        v1224 = false;
                                                                    }
                                                                    bool v1225;
                                                                    v1225 = v1224 == false;
                                                                    if (v1225){
                                                                        assert("The read index needs to be in range for the static array." && v1224);
                                                                    } else {
                                                                    }
                                                                    unsigned char v1226;
                                                                    v1226 = v120.v[v1221];
                                                                    bool v1227;
                                                                    v1227 = 0l <= v1216;
                                                                    bool v1229;
                                                                    if (v1227){
                                                                        bool v1228;
                                                                        v1228 = v1216 < 5l;
                                                                        v1229 = v1228;
                                                                    } else {
                                                                        v1229 = false;
                                                                    }
                                                                    bool v1230;
                                                                    v1230 = v1229 == false;
                                                                    if (v1230){
                                                                        assert("The read index needs to be in range for the static array." && v1229);
                                                                    } else {
                                                                    }
                                                                    v1189.v[v1216] = v1226;
                                                                    v1216 += 1l ;
                                                                }
                                                                v1233 = US15_1(v1188, v1189);
                                                            } else {
                                                                v1233 = US15_0();
                                                            }
                                                            US11 v1273;
                                                            switch (v1233.tag) {
                                                                case 0: { // None
                                                                    v1273 = US11_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,2l> v1234 = v1233.v.case1.v0; static_array<unsigned char,5l> v1235 = v1233.v.case1.v1;
                                                                    static_array<unsigned char,3l> v1236;
                                                                    long v1237;
                                                                    v1237 = 0l;
                                                                    while (while_method_3(v1237)){
                                                                        bool v1239;
                                                                        v1239 = 0l <= v1237;
                                                                        bool v1241;
                                                                        if (v1239){
                                                                            bool v1240;
                                                                            v1240 = v1237 < 5l;
                                                                            v1241 = v1240;
                                                                        } else {
                                                                            v1241 = false;
                                                                        }
                                                                        bool v1242;
                                                                        v1242 = v1241 == false;
                                                                        if (v1242){
                                                                            assert("The read index needs to be in range for the static array." && v1241);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1243;
                                                                        v1243 = v1235.v[v1237];
                                                                        bool v1245;
                                                                        if (v1239){
                                                                            bool v1244;
                                                                            v1244 = v1237 < 3l;
                                                                            v1245 = v1244;
                                                                        } else {
                                                                            v1245 = false;
                                                                        }
                                                                        bool v1246;
                                                                        v1246 = v1245 == false;
                                                                        if (v1246){
                                                                            assert("The read index needs to be in range for the static array." && v1245);
                                                                        } else {
                                                                        }
                                                                        v1236.v[v1237] = v1243;
                                                                        v1237 += 1l ;
                                                                    }
                                                                    static_array<unsigned char,5l> v1247;
                                                                    long v1248;
                                                                    v1248 = 0l;
                                                                    while (while_method_0(v1248)){
                                                                        bool v1250;
                                                                        v1250 = 0l <= v1248;
                                                                        bool v1252;
                                                                        if (v1250){
                                                                            bool v1251;
                                                                            v1251 = v1248 < 2l;
                                                                            v1252 = v1251;
                                                                        } else {
                                                                            v1252 = false;
                                                                        }
                                                                        bool v1253;
                                                                        v1253 = v1252 == false;
                                                                        if (v1253){
                                                                            assert("The read index needs to be in range for the static array." && v1252);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1254;
                                                                        v1254 = v1234.v[v1248];
                                                                        bool v1256;
                                                                        if (v1250){
                                                                            bool v1255;
                                                                            v1255 = v1248 < 5l;
                                                                            v1256 = v1255;
                                                                        } else {
                                                                            v1256 = false;
                                                                        }
                                                                        bool v1257;
                                                                        v1257 = v1256 == false;
                                                                        if (v1257){
                                                                            assert("The read index needs to be in range for the static array." && v1256);
                                                                        } else {
                                                                        }
                                                                        v1247.v[v1248] = v1254;
                                                                        v1248 += 1l ;
                                                                    }
                                                                    long v1258;
                                                                    v1258 = 0l;
                                                                    while (while_method_3(v1258)){
                                                                        bool v1260;
                                                                        v1260 = 0l <= v1258;
                                                                        bool v1262;
                                                                        if (v1260){
                                                                            bool v1261;
                                                                            v1261 = v1258 < 3l;
                                                                            v1262 = v1261;
                                                                        } else {
                                                                            v1262 = false;
                                                                        }
                                                                        bool v1263;
                                                                        v1263 = v1262 == false;
                                                                        if (v1263){
                                                                            assert("The read index needs to be in range for the static array." && v1262);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1264;
                                                                        v1264 = v1236.v[v1258];
                                                                        long v1265;
                                                                        v1265 = 2l + v1258;
                                                                        bool v1266;
                                                                        v1266 = 0l <= v1265;
                                                                        bool v1268;
                                                                        if (v1266){
                                                                            bool v1267;
                                                                            v1267 = v1265 < 5l;
                                                                            v1268 = v1267;
                                                                        } else {
                                                                            v1268 = false;
                                                                        }
                                                                        bool v1269;
                                                                        v1269 = v1268 == false;
                                                                        if (v1269){
                                                                            assert("The read index needs to be in range for the static array." && v1268);
                                                                        } else {
                                                                        }
                                                                        v1247.v[v1265] = v1264;
                                                                        v1258 += 1l ;
                                                                    }
                                                                    v1273 = US11_1(v1247);
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            switch (v1273.tag) {
                                                                case 0: { // None
                                                                    static_array<unsigned char,5l> v1275;
                                                                    long v1276;
                                                                    v1276 = 0l;
                                                                    while (while_method_2(v1276)){
                                                                        bool v1278;
                                                                        v1278 = 0l <= v1276;
                                                                        bool v1280;
                                                                        if (v1278){
                                                                            bool v1279;
                                                                            v1279 = v1276 < 7l;
                                                                            v1280 = v1279;
                                                                        } else {
                                                                            v1280 = false;
                                                                        }
                                                                        bool v1281;
                                                                        v1281 = v1280 == false;
                                                                        if (v1281){
                                                                            assert("The read index needs to be in range for the static array." && v1280);
                                                                        } else {
                                                                        }
                                                                        unsigned char v1282;
                                                                        v1282 = v120.v[v1276];
                                                                        bool v1284;
                                                                        if (v1278){
                                                                            bool v1283;
                                                                            v1283 = v1276 < 5l;
                                                                            v1284 = v1283;
                                                                        } else {
                                                                            v1284 = false;
                                                                        }
                                                                        bool v1285;
                                                                        v1285 = v1284 == false;
                                                                        if (v1285){
                                                                            assert("The read index needs to be in range for the static array." && v1284);
                                                                        } else {
                                                                        }
                                                                        v1275.v[v1276] = v1282;
                                                                        v1276 += 1l ;
                                                                    }
                                                                    v1316 = v1275; v1317 = 0;
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<unsigned char,5l> v1274 = v1273.v.case1.v0;
                                                                    v1316 = v1274; v1317 = 1;
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<unsigned char,5l> v1187 = v1186.v.case1.v0;
                                                            v1316 = v1187; v1317 = 2;
                                                            break;
                                                        }
                                                        default: {
                                                            assert("Invalid tag." && false);
                                                        }
                                                    }
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<unsigned char,5l> v1037 = v1036.v.case1.v0;
                                                    v1316 = v1037; v1317 = 3;
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<unsigned char,5l> v950 = v949.v.case1.v0;
                                            v1316 = v950; v1317 = 4;
                                            break;
                                        }
                                        default: {
                                            assert("Invalid tag." && false);
                                        }
                                    }
                                    break;
                                }
                                case 1: { // Some
                                    static_array<unsigned char,5l> v906 = v905.v.case1.v0;
                                    v1316 = v906; v1317 = 5;
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            break;
                        }
                        case 1: { // Some
                            static_array<unsigned char,5l> v714 = v713.v.case1.v0;
                            v1316 = v714; v1317 = 6;
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 1: { // Some
                    static_array<unsigned char,5l> v587 = v586.v.case1.v0;
                    v1316 = v587; v1317 = 7;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            break;
        }
        case 1: { // Some
            static_array<unsigned char,5l> v500 = v499.v.case1.v0;
            v1316 = v500; v1317 = 8;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    return Tuple1(v1316, v1317);
}
__device__ US7 play_loop_inner_33(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US7 v4){
    static_array_list<US3,128l,long> & v5 = v1;
    unsigned long long & v6 = v0;
    bool v7; US7 v8;
    Tuple10 tmp22 = Tuple10(true, v4);
    v7 = tmp22.v0; v8 = tmp22.v1;
    while (while_method_5(v7, v8)){
        bool v1158; US7 v1159;
        switch (v8.tag) {
            case 0: { // G_Flop
                long v910 = v8.v.case0.v0; static_array<static_array<Tuple0,2l>,2l> v911 = v8.v.case0.v1; static_array<long,2l> v912 = v8.v.case0.v2; long v913 = v8.v.case0.v3; static_array<long,2l> v914 = v8.v.case0.v4; US8 v915 = v8.v.case0.v5;
                static_array<unsigned char,3l> v916; unsigned long long v917;
                Tuple11 tmp25 = draw_cards_34(v2, v6);
                v916 = tmp25.v0; v917 = tmp25.v1;
                v0 = v917;
                static_array<Tuple0,3l> v918;
                long v919;
                v919 = 0l;
                while (while_method_3(v919)){
                    bool v921;
                    v921 = 0l <= v919;
                    bool v923;
                    if (v921){
                        bool v922;
                        v922 = v919 < 3l;
                        v923 = v922;
                    } else {
                        v923 = false;
                    }
                    bool v924;
                    v924 = v923 == false;
                    if (v924){
                        assert("The read index needs to be in range for the static array." && v923);
                    } else {
                    }
                    unsigned char v925;
                    v925 = v916.v[v919];
                    US4 v926; US5 v927;
                    Tuple0 tmp26 = card_from_lib_card_37(v925);
                    v926 = tmp26.v0; v927 = tmp26.v1;
                    bool v929;
                    if (v921){
                        bool v928;
                        v928 = v919 < 3l;
                        v929 = v928;
                    } else {
                        v929 = false;
                    }
                    bool v930;
                    v930 = v929 == false;
                    if (v930){
                        assert("The read index needs to be in range for the static array." && v929);
                    } else {
                    }
                    v918.v[v919] = Tuple0(v926, v927);
                    v919 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v931;
                v931 = get_community_cards_40(v915, v918);
                long v932;
                v932 = v5.length;
                bool v933;
                v933 = v932 < 128l;
                bool v934;
                v934 = v933 == false;
                if (v934){
                    assert("The length has to be less than the maximum length of the array." && v933);
                } else {
                }
                long v935;
                v935 = v932 + 1l;
                v5.length = v935;
                bool v936;
                v936 = 0l <= v932;
                bool v939;
                if (v936){
                    long v937;
                    v937 = v5.length;
                    bool v938;
                    v938 = v932 < v937;
                    v939 = v938;
                } else {
                    v939 = false;
                }
                bool v940;
                v940 = v939 == false;
                if (v940){
                    assert("The set index needs to be in range for the static array list." && v939);
                } else {
                }
                US3 v941;
                v941 = US3_0(v931);
                v5.v[v932] = v941;
                US8 v944;
                switch (v915.tag) {
                    case 1: { // Preflop
                        v944 = US8_0(v918);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in flop.");
                        asm("exit;");
                    }
                }
                long v945;
                v945 = 2l;
                long v946;
                v946 = 0l;
                US7 v947;
                v947 = try_round_41(v945, v911, v912, v946, v914, v944);
                v1158 = true; v1159 = v947;
                break;
            }
            case 1: { // G_Fold
                long v10 = v8.v.case1.v0; static_array<static_array<Tuple0,2l>,2l> v11 = v8.v.case1.v1; static_array<long,2l> v12 = v8.v.case1.v2; long v13 = v8.v.case1.v3; static_array<long,2l> v14 = v8.v.case1.v4; US8 v15 = v8.v.case1.v5;
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
                v23 = v22 % 2l;
                long v24;
                v24 = v5.length;
                bool v25;
                v25 = v24 < 128l;
                bool v26;
                v26 = v25 == false;
                if (v26){
                    assert("The length has to be less than the maximum length of the array." && v25);
                } else {
                }
                long v27;
                v27 = v24 + 1l;
                v5.length = v27;
                bool v28;
                v28 = 0l <= v24;
                bool v31;
                if (v28){
                    long v29;
                    v29 = v5.length;
                    bool v30;
                    v30 = v24 < v29;
                    v31 = v30;
                } else {
                    v31 = false;
                }
                bool v32;
                v32 = v31 == false;
                if (v32){
                    assert("The set index needs to be in range for the static array list." && v31);
                } else {
                }
                US3 v33;
                v33 = US3_1(v21, v23);
                v5.v[v24] = v33;
                v1158 = false; v1159 = v8;
                break;
            }
            case 2: { // G_Preflop
                static_array<unsigned char,2l> v1076; unsigned long long v1077;
                Tuple14 tmp35 = draw_cards_44(v2, v6);
                v1076 = tmp35.v0; v1077 = tmp35.v1;
                v0 = v1077;
                static_array<Tuple0,2l> v1078;
                long v1079;
                v1079 = 0l;
                while (while_method_0(v1079)){
                    bool v1081;
                    v1081 = 0l <= v1079;
                    bool v1083;
                    if (v1081){
                        bool v1082;
                        v1082 = v1079 < 2l;
                        v1083 = v1082;
                    } else {
                        v1083 = false;
                    }
                    bool v1084;
                    v1084 = v1083 == false;
                    if (v1084){
                        assert("The read index needs to be in range for the static array." && v1083);
                    } else {
                    }
                    unsigned char v1085;
                    v1085 = v1076.v[v1079];
                    US4 v1086; US5 v1087;
                    Tuple0 tmp36 = card_from_lib_card_37(v1085);
                    v1086 = tmp36.v0; v1087 = tmp36.v1;
                    bool v1089;
                    if (v1081){
                        bool v1088;
                        v1088 = v1079 < 2l;
                        v1089 = v1088;
                    } else {
                        v1089 = false;
                    }
                    bool v1090;
                    v1090 = v1089 == false;
                    if (v1090){
                        assert("The read index needs to be in range for the static array." && v1089);
                    } else {
                    }
                    v1078.v[v1079] = Tuple0(v1086, v1087);
                    v1079 += 1l ;
                }
                static_array<unsigned char,2l> v1091; unsigned long long v1092;
                Tuple14 tmp37 = draw_cards_44(v2, v6);
                v1091 = tmp37.v0; v1092 = tmp37.v1;
                v0 = v1092;
                static_array<Tuple0,2l> v1093;
                long v1094;
                v1094 = 0l;
                while (while_method_0(v1094)){
                    bool v1096;
                    v1096 = 0l <= v1094;
                    bool v1098;
                    if (v1096){
                        bool v1097;
                        v1097 = v1094 < 2l;
                        v1098 = v1097;
                    } else {
                        v1098 = false;
                    }
                    bool v1099;
                    v1099 = v1098 == false;
                    if (v1099){
                        assert("The read index needs to be in range for the static array." && v1098);
                    } else {
                    }
                    unsigned char v1100;
                    v1100 = v1091.v[v1094];
                    US4 v1101; US5 v1102;
                    Tuple0 tmp38 = card_from_lib_card_37(v1100);
                    v1101 = tmp38.v0; v1102 = tmp38.v1;
                    bool v1104;
                    if (v1096){
                        bool v1103;
                        v1103 = v1094 < 2l;
                        v1104 = v1103;
                    } else {
                        v1104 = false;
                    }
                    bool v1105;
                    v1105 = v1104 == false;
                    if (v1105){
                        assert("The read index needs to be in range for the static array." && v1104);
                    } else {
                    }
                    v1093.v[v1094] = Tuple0(v1101, v1102);
                    v1094 += 1l ;
                }
                long v1106;
                v1106 = v5.length;
                bool v1107;
                v1107 = v1106 < 128l;
                bool v1108;
                v1108 = v1107 == false;
                if (v1108){
                    assert("The length has to be less than the maximum length of the array." && v1107);
                } else {
                }
                long v1109;
                v1109 = v1106 + 1l;
                v5.length = v1109;
                bool v1110;
                v1110 = 0l <= v1106;
                bool v1113;
                if (v1110){
                    long v1111;
                    v1111 = v5.length;
                    bool v1112;
                    v1112 = v1106 < v1111;
                    v1113 = v1112;
                } else {
                    v1113 = false;
                }
                bool v1114;
                v1114 = v1113 == false;
                if (v1114){
                    assert("The set index needs to be in range for the static array list." && v1113);
                } else {
                }
                US3 v1115;
                v1115 = US3_3(0l, v1078);
                v5.v[v1106] = v1115;
                long v1116;
                v1116 = v5.length;
                bool v1117;
                v1117 = v1116 < 128l;
                bool v1118;
                v1118 = v1117 == false;
                if (v1118){
                    assert("The length has to be less than the maximum length of the array." && v1117);
                } else {
                }
                long v1119;
                v1119 = v1116 + 1l;
                v5.length = v1119;
                bool v1120;
                v1120 = 0l <= v1116;
                bool v1123;
                if (v1120){
                    long v1121;
                    v1121 = v5.length;
                    bool v1122;
                    v1122 = v1116 < v1121;
                    v1123 = v1122;
                } else {
                    v1123 = false;
                }
                bool v1124;
                v1124 = v1123 == false;
                if (v1124){
                    assert("The set index needs to be in range for the static array list." && v1123);
                } else {
                }
                US3 v1125;
                v1125 = US3_3(1l, v1093);
                v5.v[v1116] = v1125;
                static_array<static_array<Tuple0,2l>,2l> v1126;
                v1126.v[0l] = v1078;
                v1126.v[1l] = v1093;
                static_array<long,2l> v1127;
                v1127.v[0l] = 2l;
                v1127.v[1l] = 1l;
                static_array<long,2l> v1128;
                long v1129;
                v1129 = 0l;
                while (while_method_0(v1129)){
                    bool v1131;
                    v1131 = 0l <= v1129;
                    bool v1133;
                    if (v1131){
                        bool v1132;
                        v1132 = v1129 < 2l;
                        v1133 = v1132;
                    } else {
                        v1133 = false;
                    }
                    bool v1134;
                    v1134 = v1133 == false;
                    if (v1134){
                        assert("The read index needs to be in range for the static array." && v1133);
                    } else {
                    }
                    long v1135;
                    v1135 = v1127.v[v1129];
                    long v1136;
                    v1136 = 100l - v1135;
                    bool v1138;
                    if (v1131){
                        bool v1137;
                        v1137 = v1129 < 2l;
                        v1138 = v1137;
                    } else {
                        v1138 = false;
                    }
                    bool v1139;
                    v1139 = v1138 == false;
                    if (v1139){
                        assert("The read index needs to be in range for the static array." && v1138);
                    } else {
                    }
                    v1128.v[v1129] = v1136;
                    v1129 += 1l ;
                }
                long v1140;
                v1140 = 2l;
                long v1141;
                v1141 = 0l;
                US8 v1142;
                v1142 = US8_1();
                US7 v1143;
                v1143 = try_round_41(v1140, v1126, v1127, v1141, v1128, v1142);
                v1158 = true; v1159 = v1143;
                break;
            }
            case 3: { // G_River
                long v1012 = v8.v.case3.v0; static_array<static_array<Tuple0,2l>,2l> v1013 = v8.v.case3.v1; static_array<long,2l> v1014 = v8.v.case3.v2; long v1015 = v8.v.case3.v3; static_array<long,2l> v1016 = v8.v.case3.v4; US8 v1017 = v8.v.case3.v5;
                static_array<unsigned char,1l> v1018; unsigned long long v1019;
                Tuple15 tmp41 = draw_cards_45(v2, v6);
                v1018 = tmp41.v0; v1019 = tmp41.v1;
                v0 = v1019;
                static_array<Tuple0,1l> v1020;
                long v1021;
                v1021 = 0l;
                while (while_method_6(v1021)){
                    bool v1023;
                    v1023 = 0l <= v1021;
                    bool v1025;
                    if (v1023){
                        bool v1024;
                        v1024 = v1021 < 1l;
                        v1025 = v1024;
                    } else {
                        v1025 = false;
                    }
                    bool v1026;
                    v1026 = v1025 == false;
                    if (v1026){
                        assert("The read index needs to be in range for the static array." && v1025);
                    } else {
                    }
                    unsigned char v1027;
                    v1027 = v1018.v[v1021];
                    US4 v1028; US5 v1029;
                    Tuple0 tmp42 = card_from_lib_card_37(v1027);
                    v1028 = tmp42.v0; v1029 = tmp42.v1;
                    bool v1031;
                    if (v1023){
                        bool v1030;
                        v1030 = v1021 < 1l;
                        v1031 = v1030;
                    } else {
                        v1031 = false;
                    }
                    bool v1032;
                    v1032 = v1031 == false;
                    if (v1032){
                        assert("The read index needs to be in range for the static array." && v1031);
                    } else {
                    }
                    v1020.v[v1021] = Tuple0(v1028, v1029);
                    v1021 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v1033;
                v1033 = get_community_cards_46(v1017, v1020);
                long v1034;
                v1034 = v5.length;
                bool v1035;
                v1035 = v1034 < 128l;
                bool v1036;
                v1036 = v1035 == false;
                if (v1036){
                    assert("The length has to be less than the maximum length of the array." && v1035);
                } else {
                }
                long v1037;
                v1037 = v1034 + 1l;
                v5.length = v1037;
                bool v1038;
                v1038 = 0l <= v1034;
                bool v1041;
                if (v1038){
                    long v1039;
                    v1039 = v5.length;
                    bool v1040;
                    v1040 = v1034 < v1039;
                    v1041 = v1040;
                } else {
                    v1041 = false;
                }
                bool v1042;
                v1042 = v1041 == false;
                if (v1042){
                    assert("The set index needs to be in range for the static array list." && v1041);
                } else {
                }
                US3 v1043;
                v1043 = US3_0(v1033);
                v5.v[v1034] = v1043;
                US8 v1072;
                switch (v1017.tag) {
                    case 3: { // Turn
                        static_array<Tuple0,4l> v1044 = v1017.v.case3.v0;
                        static_array<Tuple0,5l> v1045;
                        long v1046;
                        v1046 = 0l;
                        while (while_method_4(v1046)){
                            bool v1048;
                            v1048 = 0l <= v1046;
                            bool v1050;
                            if (v1048){
                                bool v1049;
                                v1049 = v1046 < 4l;
                                v1050 = v1049;
                            } else {
                                v1050 = false;
                            }
                            bool v1051;
                            v1051 = v1050 == false;
                            if (v1051){
                                assert("The read index needs to be in range for the static array." && v1050);
                            } else {
                            }
                            US4 v1052; US5 v1053;
                            Tuple0 tmp47 = v1044.v[v1046];
                            v1052 = tmp47.v0; v1053 = tmp47.v1;
                            bool v1055;
                            if (v1048){
                                bool v1054;
                                v1054 = v1046 < 5l;
                                v1055 = v1054;
                            } else {
                                v1055 = false;
                            }
                            bool v1056;
                            v1056 = v1055 == false;
                            if (v1056){
                                assert("The read index needs to be in range for the static array." && v1055);
                            } else {
                            }
                            v1045.v[v1046] = Tuple0(v1052, v1053);
                            v1046 += 1l ;
                        }
                        long v1057;
                        v1057 = 0l;
                        while (while_method_6(v1057)){
                            bool v1059;
                            v1059 = 0l <= v1057;
                            bool v1061;
                            if (v1059){
                                bool v1060;
                                v1060 = v1057 < 1l;
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
                            US4 v1063; US5 v1064;
                            Tuple0 tmp48 = v1020.v[v1057];
                            v1063 = tmp48.v0; v1064 = tmp48.v1;
                            long v1065;
                            v1065 = 4l + v1057;
                            bool v1066;
                            v1066 = 0l <= v1065;
                            bool v1068;
                            if (v1066){
                                bool v1067;
                                v1067 = v1065 < 5l;
                                v1068 = v1067;
                            } else {
                                v1068 = false;
                            }
                            bool v1069;
                            v1069 = v1068 == false;
                            if (v1069){
                                assert("The read index needs to be in range for the static array." && v1068);
                            } else {
                            }
                            v1045.v[v1065] = Tuple0(v1063, v1064);
                            v1057 += 1l ;
                        }
                        v1072 = US8_2(v1045);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in river.");
                        asm("exit;");
                    }
                }
                long v1073;
                v1073 = 2l;
                long v1074;
                v1074 = 0l;
                US7 v1075;
                v1075 = try_round_41(v1073, v1013, v1014, v1074, v1016, v1072);
                v1158 = true; v1159 = v1075;
                break;
            }
            case 4: { // G_Round
                long v177 = v8.v.case4.v0; static_array<static_array<Tuple0,2l>,2l> v178 = v8.v.case4.v1; static_array<long,2l> v179 = v8.v.case4.v2; long v180 = v8.v.case4.v3; static_array<long,2l> v181 = v8.v.case4.v4; US8 v182 = v8.v.case4.v5;
                long v183;
                v183 = v180 % 2l;
                bool v184;
                v184 = 0l <= v183;
                bool v186;
                if (v184){
                    bool v185;
                    v185 = v183 < 2l;
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
                US2 v188;
                v188 = v3.v[v183];
                switch (v188.tag) {
                    case 0: { // Computer
                        static_array<long,2l> v189;
                        long v190;
                        v190 = 0l;
                        while (while_method_0(v190)){
                            bool v192;
                            v192 = 0l <= v190;
                            bool v194;
                            if (v192){
                                bool v193;
                                v193 = v190 < 2l;
                                v194 = v193;
                            } else {
                                v194 = false;
                            }
                            bool v195;
                            v195 = v194 == false;
                            if (v195){
                                assert("The read index needs to be in range for the static array." && v194);
                            } else {
                            }
                            long v196;
                            v196 = v181.v[v190];
                            bool v198;
                            if (v192){
                                bool v197;
                                v197 = v190 < 2l;
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
                            long v200;
                            v200 = v179.v[v190];
                            long v201;
                            v201 = v196 + v200;
                            bool v203;
                            if (v192){
                                bool v202;
                                v202 = v190 < 2l;
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
                            v189.v[v190] = v201;
                            v190 += 1l ;
                        }
                        long v205;
                        v205 = v179.v[0l];
                        long v206; long v207;
                        Tuple3 tmp49 = Tuple3(1l, v205);
                        v206 = tmp49.v0; v207 = tmp49.v1;
                        while (while_method_0(v206)){
                            bool v209;
                            v209 = 0l <= v206;
                            bool v211;
                            if (v209){
                                bool v210;
                                v210 = v206 < 2l;
                                v211 = v210;
                            } else {
                                v211 = false;
                            }
                            bool v212;
                            v212 = v211 == false;
                            if (v212){
                                assert("The read index needs to be in range for the static array." && v211);
                            } else {
                            }
                            long v213;
                            v213 = v179.v[v206];
                            bool v214;
                            v214 = v207 >= v213;
                            long v215;
                            if (v214){
                                v215 = v207;
                            } else {
                                v215 = v213;
                            }
                            v207 = v215;
                            v206 += 1l ;
                        }
                        bool v217;
                        if (v184){
                            bool v216;
                            v216 = v183 < 2l;
                            v217 = v216;
                        } else {
                            v217 = false;
                        }
                        bool v218;
                        v218 = v217 == false;
                        if (v218){
                            assert("The read index needs to be in range for the static array." && v217);
                        } else {
                        }
                        long v219;
                        v219 = v189.v[v183];
                        bool v220;
                        v220 = v207 < v219;
                        long v221;
                        if (v220){
                            v221 = v207;
                        } else {
                            v221 = v219;
                        }
                        static_array<long,2l> v222;
                        long v223;
                        v223 = 0l;
                        while (while_method_0(v223)){
                            bool v225;
                            v225 = 0l <= v223;
                            bool v227;
                            if (v225){
                                bool v226;
                                v226 = v223 < 2l;
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
                            v229 = v179.v[v223];
                            bool v230;
                            v230 = v183 == v223;
                            long v231;
                            if (v230){
                                v231 = v221;
                            } else {
                                v231 = v229;
                            }
                            bool v233;
                            if (v225){
                                bool v232;
                                v232 = v223 < 2l;
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
                            v222.v[v223] = v231;
                            v223 += 1l ;
                        }
                        static_array<long,2l> v235;
                        long v236;
                        v236 = 0l;
                        while (while_method_0(v236)){
                            bool v238;
                            v238 = 0l <= v236;
                            bool v240;
                            if (v238){
                                bool v239;
                                v239 = v236 < 2l;
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
                            v242 = v189.v[v236];
                            bool v244;
                            if (v238){
                                bool v243;
                                v243 = v236 < 2l;
                                v244 = v243;
                            } else {
                                v244 = false;
                            }
                            bool v245;
                            v245 = v244 == false;
                            if (v245){
                                assert("The read index needs to be in range for the static array." && v244);
                            } else {
                            }
                            long v246;
                            v246 = v222.v[v236];
                            long v247;
                            v247 = v242 - v246;
                            bool v249;
                            if (v238){
                                bool v248;
                                v248 = v236 < 2l;
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
                            v235.v[v236] = v247;
                            v236 += 1l ;
                        }
                        long v251;
                        v251 = v222.v[0l];
                        long v252; long v253;
                        Tuple3 tmp50 = Tuple3(1l, v251);
                        v252 = tmp50.v0; v253 = tmp50.v1;
                        while (while_method_0(v252)){
                            bool v255;
                            v255 = 0l <= v252;
                            bool v257;
                            if (v255){
                                bool v256;
                                v256 = v252 < 2l;
                                v257 = v256;
                            } else {
                                v257 = false;
                            }
                            bool v258;
                            v258 = v257 == false;
                            if (v258){
                                assert("The read index needs to be in range for the static array." && v257);
                            } else {
                            }
                            long v259;
                            v259 = v222.v[v252];
                            long v260;
                            v260 = v253 + v259;
                            v253 = v260;
                            v252 += 1l ;
                        }
                        bool v262;
                        if (v184){
                            bool v261;
                            v261 = v183 < 2l;
                            v262 = v261;
                        } else {
                            v262 = false;
                        }
                        bool v263;
                        v263 = v262 == false;
                        if (v263){
                            assert("The read index needs to be in range for the static array." && v262);
                        } else {
                        }
                        long v264;
                        v264 = v179.v[v183];
                        bool v265;
                        v265 = v264 < v207;
                        float v266;
                        if (v265){
                            v266 = 1.0f;
                        } else {
                            v266 = 0.0f;
                        }
                        long v267;
                        v267 = v253 / 3l;
                        bool v268;
                        v268 = v177 <= v267;
                        bool v274;
                        if (v268){
                            bool v270;
                            if (v184){
                                bool v269;
                                v269 = v183 < 2l;
                                v270 = v269;
                            } else {
                                v270 = false;
                            }
                            bool v271;
                            v271 = v270 == false;
                            if (v271){
                                assert("The read index needs to be in range for the static array." && v270);
                            } else {
                            }
                            long v272;
                            v272 = v235.v[v183];
                            bool v273;
                            v273 = v267 < v272;
                            v274 = v273;
                        } else {
                            v274 = false;
                        }
                        float v275;
                        if (v274){
                            v275 = 1.0f;
                        } else {
                            v275 = 0.0f;
                        }
                        long v276;
                        v276 = v253 / 2l;
                        bool v277;
                        v277 = v177 <= v276;
                        bool v283;
                        if (v277){
                            bool v279;
                            if (v184){
                                bool v278;
                                v278 = v183 < 2l;
                                v279 = v278;
                            } else {
                                v279 = false;
                            }
                            bool v280;
                            v280 = v279 == false;
                            if (v280){
                                assert("The read index needs to be in range for the static array." && v279);
                            } else {
                            }
                            long v281;
                            v281 = v235.v[v183];
                            bool v282;
                            v282 = v276 < v281;
                            v283 = v282;
                        } else {
                            v283 = false;
                        }
                        float v284;
                        if (v283){
                            v284 = 1.0f;
                        } else {
                            v284 = 0.0f;
                        }
                        bool v285;
                        v285 = v177 <= v253;
                        bool v291;
                        if (v285){
                            bool v287;
                            if (v184){
                                bool v286;
                                v286 = v183 < 2l;
                                v287 = v286;
                            } else {
                                v287 = false;
                            }
                            bool v288;
                            v288 = v287 == false;
                            if (v288){
                                assert("The read index needs to be in range for the static array." && v287);
                            } else {
                            }
                            long v289;
                            v289 = v235.v[v183];
                            bool v290;
                            v290 = v253 < v289;
                            v291 = v290;
                        } else {
                            v291 = false;
                        }
                        float v292;
                        if (v291){
                            v292 = 1.0f;
                        } else {
                            v292 = 0.0f;
                        }
                        static_array<Tuple16,6l> v293;
                        US1 v294;
                        v294 = US1_2();
                        v293.v[0l] = Tuple16(v294, v266);
                        US1 v295;
                        v295 = US1_1();
                        v293.v[1l] = Tuple16(v295, 4.0f);
                        US1 v296;
                        v296 = US1_3(v267);
                        v293.v[2l] = Tuple16(v296, v275);
                        US1 v297;
                        v297 = US1_3(v276);
                        v293.v[3l] = Tuple16(v297, v284);
                        US1 v298;
                        v298 = US1_3(v253);
                        v293.v[4l] = Tuple16(v298, v292);
                        US1 v299;
                        v299 = US1_0();
                        v293.v[5l] = Tuple16(v299, 1.0f);
                        US1 v300;
                        v300 = sample_discrete_47(v293, v2);
                        long v301;
                        v301 = v5.length;
                        bool v302;
                        v302 = v301 < 128l;
                        bool v303;
                        v303 = v302 == false;
                        if (v303){
                            assert("The length has to be less than the maximum length of the array." && v302);
                        } else {
                        }
                        long v304;
                        v304 = v301 + 1l;
                        v5.length = v304;
                        bool v305;
                        v305 = 0l <= v301;
                        bool v308;
                        if (v305){
                            long v306;
                            v306 = v5.length;
                            bool v307;
                            v307 = v301 < v306;
                            v308 = v307;
                        } else {
                            v308 = false;
                        }
                        bool v309;
                        v309 = v308 == false;
                        if (v309){
                            assert("The set index needs to be in range for the static array list." && v308);
                        } else {
                        }
                        US3 v310;
                        v310 = US3_2(v183, v300);
                        v5.v[v301] = v310;
                        US7 v597;
                        switch (v300.tag) {
                            case 0: { // A_All_In
                                static_array<long,2l> v488;
                                long v489;
                                v489 = 0l;
                                while (while_method_0(v489)){
                                    bool v491;
                                    v491 = 0l <= v489;
                                    bool v493;
                                    if (v491){
                                        bool v492;
                                        v492 = v489 < 2l;
                                        v493 = v492;
                                    } else {
                                        v493 = false;
                                    }
                                    bool v494;
                                    v494 = v493 == false;
                                    if (v494){
                                        assert("The read index needs to be in range for the static array." && v493);
                                    } else {
                                    }
                                    long v495;
                                    v495 = v181.v[v489];
                                    bool v497;
                                    if (v491){
                                        bool v496;
                                        v496 = v489 < 2l;
                                        v497 = v496;
                                    } else {
                                        v497 = false;
                                    }
                                    bool v498;
                                    v498 = v497 == false;
                                    if (v498){
                                        assert("The read index needs to be in range for the static array." && v497);
                                    } else {
                                    }
                                    long v499;
                                    v499 = v179.v[v489];
                                    long v500;
                                    v500 = v495 + v499;
                                    bool v502;
                                    if (v491){
                                        bool v501;
                                        v501 = v489 < 2l;
                                        v502 = v501;
                                    } else {
                                        v502 = false;
                                    }
                                    bool v503;
                                    v503 = v502 == false;
                                    if (v503){
                                        assert("The read index needs to be in range for the static array." && v502);
                                    } else {
                                    }
                                    v488.v[v489] = v500;
                                    v489 += 1l ;
                                }
                                long v504;
                                v504 = v179.v[0l];
                                long v505; long v506;
                                Tuple3 tmp53 = Tuple3(1l, v504);
                                v505 = tmp53.v0; v506 = tmp53.v1;
                                while (while_method_0(v505)){
                                    bool v508;
                                    v508 = 0l <= v505;
                                    bool v510;
                                    if (v508){
                                        bool v509;
                                        v509 = v505 < 2l;
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
                                    v512 = v179.v[v505];
                                    bool v513;
                                    v513 = v506 >= v512;
                                    long v514;
                                    if (v513){
                                        v514 = v506;
                                    } else {
                                        v514 = v512;
                                    }
                                    v506 = v514;
                                    v505 += 1l ;
                                }
                                bool v516;
                                if (v184){
                                    bool v515;
                                    v515 = v183 < 2l;
                                    v516 = v515;
                                } else {
                                    v516 = false;
                                }
                                bool v517;
                                v517 = v516 == false;
                                if (v517){
                                    assert("The read index needs to be in range for the static array." && v516);
                                } else {
                                }
                                long v518;
                                v518 = v488.v[v183];
                                bool v519;
                                v519 = v506 < v518;
                                long v520;
                                if (v519){
                                    v520 = v506;
                                } else {
                                    v520 = v518;
                                }
                                static_array<long,2l> v521;
                                long v522;
                                v522 = 0l;
                                while (while_method_0(v522)){
                                    bool v524;
                                    v524 = 0l <= v522;
                                    bool v526;
                                    if (v524){
                                        bool v525;
                                        v525 = v522 < 2l;
                                        v526 = v525;
                                    } else {
                                        v526 = false;
                                    }
                                    bool v527;
                                    v527 = v526 == false;
                                    if (v527){
                                        assert("The read index needs to be in range for the static array." && v526);
                                    } else {
                                    }
                                    long v528;
                                    v528 = v179.v[v522];
                                    bool v529;
                                    v529 = v183 == v522;
                                    long v530;
                                    if (v529){
                                        v530 = v520;
                                    } else {
                                        v530 = v528;
                                    }
                                    bool v532;
                                    if (v524){
                                        bool v531;
                                        v531 = v522 < 2l;
                                        v532 = v531;
                                    } else {
                                        v532 = false;
                                    }
                                    bool v533;
                                    v533 = v532 == false;
                                    if (v533){
                                        assert("The read index needs to be in range for the static array." && v532);
                                    } else {
                                    }
                                    v521.v[v522] = v530;
                                    v522 += 1l ;
                                }
                                static_array<long,2l> v534;
                                long v535;
                                v535 = 0l;
                                while (while_method_0(v535)){
                                    bool v537;
                                    v537 = 0l <= v535;
                                    bool v539;
                                    if (v537){
                                        bool v538;
                                        v538 = v535 < 2l;
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
                                    v541 = v488.v[v535];
                                    bool v543;
                                    if (v537){
                                        bool v542;
                                        v542 = v535 < 2l;
                                        v543 = v542;
                                    } else {
                                        v543 = false;
                                    }
                                    bool v544;
                                    v544 = v543 == false;
                                    if (v544){
                                        assert("The read index needs to be in range for the static array." && v543);
                                    } else {
                                    }
                                    long v545;
                                    v545 = v521.v[v535];
                                    long v546;
                                    v546 = v541 - v545;
                                    bool v548;
                                    if (v537){
                                        bool v547;
                                        v547 = v535 < 2l;
                                        v548 = v547;
                                    } else {
                                        v548 = false;
                                    }
                                    bool v549;
                                    v549 = v548 == false;
                                    if (v549){
                                        assert("The read index needs to be in range for the static array." && v548);
                                    } else {
                                    }
                                    v534.v[v535] = v546;
                                    v535 += 1l ;
                                }
                                bool v551;
                                if (v184){
                                    bool v550;
                                    v550 = v183 < 2l;
                                    v551 = v550;
                                } else {
                                    v551 = false;
                                }
                                bool v552;
                                v552 = v551 == false;
                                if (v552){
                                    assert("The read index needs to be in range for the static array." && v551);
                                } else {
                                }
                                long v553;
                                v553 = v534.v[v183];
                                long v554;
                                v554 = v506 + v553;
                                bool v556;
                                if (v184){
                                    bool v555;
                                    v555 = v183 < 2l;
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
                                v558 = v488.v[v183];
                                bool v559;
                                v559 = v554 < v558;
                                long v560;
                                if (v559){
                                    v560 = v554;
                                } else {
                                    v560 = v558;
                                }
                                static_array<long,2l> v561;
                                long v562;
                                v562 = 0l;
                                while (while_method_0(v562)){
                                    bool v564;
                                    v564 = 0l <= v562;
                                    bool v566;
                                    if (v564){
                                        bool v565;
                                        v565 = v562 < 2l;
                                        v566 = v565;
                                    } else {
                                        v566 = false;
                                    }
                                    bool v567;
                                    v567 = v566 == false;
                                    if (v567){
                                        assert("The read index needs to be in range for the static array." && v566);
                                    } else {
                                    }
                                    long v568;
                                    v568 = v179.v[v562];
                                    bool v569;
                                    v569 = v183 == v562;
                                    long v570;
                                    if (v569){
                                        v570 = v560;
                                    } else {
                                        v570 = v568;
                                    }
                                    bool v572;
                                    if (v564){
                                        bool v571;
                                        v571 = v562 < 2l;
                                        v572 = v571;
                                    } else {
                                        v572 = false;
                                    }
                                    bool v573;
                                    v573 = v572 == false;
                                    if (v573){
                                        assert("The read index needs to be in range for the static array." && v572);
                                    } else {
                                    }
                                    v561.v[v562] = v570;
                                    v562 += 1l ;
                                }
                                static_array<long,2l> v574;
                                long v575;
                                v575 = 0l;
                                while (while_method_0(v575)){
                                    bool v577;
                                    v577 = 0l <= v575;
                                    bool v579;
                                    if (v577){
                                        bool v578;
                                        v578 = v575 < 2l;
                                        v579 = v578;
                                    } else {
                                        v579 = false;
                                    }
                                    bool v580;
                                    v580 = v579 == false;
                                    if (v580){
                                        assert("The read index needs to be in range for the static array." && v579);
                                    } else {
                                    }
                                    long v581;
                                    v581 = v488.v[v575];
                                    bool v583;
                                    if (v577){
                                        bool v582;
                                        v582 = v575 < 2l;
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
                                    v585 = v561.v[v575];
                                    long v586;
                                    v586 = v581 - v585;
                                    bool v588;
                                    if (v577){
                                        bool v587;
                                        v587 = v575 < 2l;
                                        v588 = v587;
                                    } else {
                                        v588 = false;
                                    }
                                    bool v589;
                                    v589 = v588 == false;
                                    if (v589){
                                        assert("The read index needs to be in range for the static array." && v588);
                                    } else {
                                    }
                                    v574.v[v575] = v586;
                                    v575 += 1l ;
                                }
                                bool v590;
                                v590 = v553 >= v177;
                                long v591;
                                if (v590){
                                    v591 = v553;
                                } else {
                                    v591 = v177;
                                }
                                long v592;
                                v592 = v180 + 1l;
                                v597 = try_round_41(v591, v178, v561, v592, v574, v182);
                                break;
                            }
                            case 1: { // A_Call
                                static_array<long,2l> v312;
                                long v313;
                                v313 = 0l;
                                while (while_method_0(v313)){
                                    bool v315;
                                    v315 = 0l <= v313;
                                    bool v317;
                                    if (v315){
                                        bool v316;
                                        v316 = v313 < 2l;
                                        v317 = v316;
                                    } else {
                                        v317 = false;
                                    }
                                    bool v318;
                                    v318 = v317 == false;
                                    if (v318){
                                        assert("The read index needs to be in range for the static array." && v317);
                                    } else {
                                    }
                                    long v319;
                                    v319 = v181.v[v313];
                                    bool v321;
                                    if (v315){
                                        bool v320;
                                        v320 = v313 < 2l;
                                        v321 = v320;
                                    } else {
                                        v321 = false;
                                    }
                                    bool v322;
                                    v322 = v321 == false;
                                    if (v322){
                                        assert("The read index needs to be in range for the static array." && v321);
                                    } else {
                                    }
                                    long v323;
                                    v323 = v179.v[v313];
                                    long v324;
                                    v324 = v319 + v323;
                                    bool v326;
                                    if (v315){
                                        bool v325;
                                        v325 = v313 < 2l;
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
                                    v312.v[v313] = v324;
                                    v313 += 1l ;
                                }
                                long v328;
                                v328 = v179.v[0l];
                                long v329; long v330;
                                Tuple3 tmp54 = Tuple3(1l, v328);
                                v329 = tmp54.v0; v330 = tmp54.v1;
                                while (while_method_0(v329)){
                                    bool v332;
                                    v332 = 0l <= v329;
                                    bool v334;
                                    if (v332){
                                        bool v333;
                                        v333 = v329 < 2l;
                                        v334 = v333;
                                    } else {
                                        v334 = false;
                                    }
                                    bool v335;
                                    v335 = v334 == false;
                                    if (v335){
                                        assert("The read index needs to be in range for the static array." && v334);
                                    } else {
                                    }
                                    long v336;
                                    v336 = v179.v[v329];
                                    bool v337;
                                    v337 = v330 >= v336;
                                    long v338;
                                    if (v337){
                                        v338 = v330;
                                    } else {
                                        v338 = v336;
                                    }
                                    v330 = v338;
                                    v329 += 1l ;
                                }
                                bool v340;
                                if (v184){
                                    bool v339;
                                    v339 = v183 < 2l;
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
                                v342 = v312.v[v183];
                                bool v343;
                                v343 = v330 < v342;
                                long v344;
                                if (v343){
                                    v344 = v330;
                                } else {
                                    v344 = v342;
                                }
                                static_array<long,2l> v345;
                                long v346;
                                v346 = 0l;
                                while (while_method_0(v346)){
                                    bool v348;
                                    v348 = 0l <= v346;
                                    bool v350;
                                    if (v348){
                                        bool v349;
                                        v349 = v346 < 2l;
                                        v350 = v349;
                                    } else {
                                        v350 = false;
                                    }
                                    bool v351;
                                    v351 = v350 == false;
                                    if (v351){
                                        assert("The read index needs to be in range for the static array." && v350);
                                    } else {
                                    }
                                    long v352;
                                    v352 = v179.v[v346];
                                    bool v353;
                                    v353 = v183 == v346;
                                    long v354;
                                    if (v353){
                                        v354 = v344;
                                    } else {
                                        v354 = v352;
                                    }
                                    bool v356;
                                    if (v348){
                                        bool v355;
                                        v355 = v346 < 2l;
                                        v356 = v355;
                                    } else {
                                        v356 = false;
                                    }
                                    bool v357;
                                    v357 = v356 == false;
                                    if (v357){
                                        assert("The read index needs to be in range for the static array." && v356);
                                    } else {
                                    }
                                    v345.v[v346] = v354;
                                    v346 += 1l ;
                                }
                                static_array<long,2l> v358;
                                long v359;
                                v359 = 0l;
                                while (while_method_0(v359)){
                                    bool v361;
                                    v361 = 0l <= v359;
                                    bool v363;
                                    if (v361){
                                        bool v362;
                                        v362 = v359 < 2l;
                                        v363 = v362;
                                    } else {
                                        v363 = false;
                                    }
                                    bool v364;
                                    v364 = v363 == false;
                                    if (v364){
                                        assert("The read index needs to be in range for the static array." && v363);
                                    } else {
                                    }
                                    long v365;
                                    v365 = v312.v[v359];
                                    bool v367;
                                    if (v361){
                                        bool v366;
                                        v366 = v359 < 2l;
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
                                    v369 = v345.v[v359];
                                    long v370;
                                    v370 = v365 - v369;
                                    bool v372;
                                    if (v361){
                                        bool v371;
                                        v371 = v359 < 2l;
                                        v372 = v371;
                                    } else {
                                        v372 = false;
                                    }
                                    bool v373;
                                    v373 = v372 == false;
                                    if (v373){
                                        assert("The read index needs to be in range for the static array." && v372);
                                    } else {
                                    }
                                    v358.v[v359] = v370;
                                    v359 += 1l ;
                                }
                                bool v374;
                                v374 = v183 < 2l;
                                if (v374){
                                    long v375;
                                    v375 = v180 + 1l;
                                    v597 = try_round_41(v177, v178, v345, v375, v358, v182);
                                } else {
                                    v597 = go_next_street_43(v177, v178, v345, v180, v358, v182);
                                }
                                break;
                            }
                            case 2: { // A_Fold
                                v597 = US7_1(v177, v178, v179, v180, v181, v182);
                                break;
                            }
                            case 3: { // A_Raise
                                long v379 = v300.v.case3.v0;
                                bool v380;
                                v380 = v177 <= v379;
                                bool v381;
                                v381 = v380 == false;
                                if (v381){
                                    assert("The raise amount must match the minimum." && v380);
                                } else {
                                }
                                static_array<long,2l> v382;
                                long v383;
                                v383 = 0l;
                                while (while_method_0(v383)){
                                    bool v385;
                                    v385 = 0l <= v383;
                                    bool v387;
                                    if (v385){
                                        bool v386;
                                        v386 = v383 < 2l;
                                        v387 = v386;
                                    } else {
                                        v387 = false;
                                    }
                                    bool v388;
                                    v388 = v387 == false;
                                    if (v388){
                                        assert("The read index needs to be in range for the static array." && v387);
                                    } else {
                                    }
                                    long v389;
                                    v389 = v181.v[v383];
                                    bool v391;
                                    if (v385){
                                        bool v390;
                                        v390 = v383 < 2l;
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
                                    long v393;
                                    v393 = v179.v[v383];
                                    long v394;
                                    v394 = v389 + v393;
                                    bool v396;
                                    if (v385){
                                        bool v395;
                                        v395 = v383 < 2l;
                                        v396 = v395;
                                    } else {
                                        v396 = false;
                                    }
                                    bool v397;
                                    v397 = v396 == false;
                                    if (v397){
                                        assert("The read index needs to be in range for the static array." && v396);
                                    } else {
                                    }
                                    v382.v[v383] = v394;
                                    v383 += 1l ;
                                }
                                long v398;
                                v398 = v179.v[0l];
                                long v399; long v400;
                                Tuple3 tmp55 = Tuple3(1l, v398);
                                v399 = tmp55.v0; v400 = tmp55.v1;
                                while (while_method_0(v399)){
                                    bool v402;
                                    v402 = 0l <= v399;
                                    bool v404;
                                    if (v402){
                                        bool v403;
                                        v403 = v399 < 2l;
                                        v404 = v403;
                                    } else {
                                        v404 = false;
                                    }
                                    bool v405;
                                    v405 = v404 == false;
                                    if (v405){
                                        assert("The read index needs to be in range for the static array." && v404);
                                    } else {
                                    }
                                    long v406;
                                    v406 = v179.v[v399];
                                    bool v407;
                                    v407 = v400 >= v406;
                                    long v408;
                                    if (v407){
                                        v408 = v400;
                                    } else {
                                        v408 = v406;
                                    }
                                    v400 = v408;
                                    v399 += 1l ;
                                }
                                bool v410;
                                if (v184){
                                    bool v409;
                                    v409 = v183 < 2l;
                                    v410 = v409;
                                } else {
                                    v410 = false;
                                }
                                bool v411;
                                v411 = v410 == false;
                                if (v411){
                                    assert("The read index needs to be in range for the static array." && v410);
                                } else {
                                }
                                long v412;
                                v412 = v382.v[v183];
                                bool v413;
                                v413 = v400 < v412;
                                long v414;
                                if (v413){
                                    v414 = v400;
                                } else {
                                    v414 = v412;
                                }
                                static_array<long,2l> v415;
                                long v416;
                                v416 = 0l;
                                while (while_method_0(v416)){
                                    bool v418;
                                    v418 = 0l <= v416;
                                    bool v420;
                                    if (v418){
                                        bool v419;
                                        v419 = v416 < 2l;
                                        v420 = v419;
                                    } else {
                                        v420 = false;
                                    }
                                    bool v421;
                                    v421 = v420 == false;
                                    if (v421){
                                        assert("The read index needs to be in range for the static array." && v420);
                                    } else {
                                    }
                                    long v422;
                                    v422 = v179.v[v416];
                                    bool v423;
                                    v423 = v183 == v416;
                                    long v424;
                                    if (v423){
                                        v424 = v414;
                                    } else {
                                        v424 = v422;
                                    }
                                    bool v426;
                                    if (v418){
                                        bool v425;
                                        v425 = v416 < 2l;
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
                                    v415.v[v416] = v424;
                                    v416 += 1l ;
                                }
                                static_array<long,2l> v428;
                                long v429;
                                v429 = 0l;
                                while (while_method_0(v429)){
                                    bool v431;
                                    v431 = 0l <= v429;
                                    bool v433;
                                    if (v431){
                                        bool v432;
                                        v432 = v429 < 2l;
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
                                    v435 = v382.v[v429];
                                    bool v437;
                                    if (v431){
                                        bool v436;
                                        v436 = v429 < 2l;
                                        v437 = v436;
                                    } else {
                                        v437 = false;
                                    }
                                    bool v438;
                                    v438 = v437 == false;
                                    if (v438){
                                        assert("The read index needs to be in range for the static array." && v437);
                                    } else {
                                    }
                                    long v439;
                                    v439 = v415.v[v429];
                                    long v440;
                                    v440 = v435 - v439;
                                    bool v442;
                                    if (v431){
                                        bool v441;
                                        v441 = v429 < 2l;
                                        v442 = v441;
                                    } else {
                                        v442 = false;
                                    }
                                    bool v443;
                                    v443 = v442 == false;
                                    if (v443){
                                        assert("The read index needs to be in range for the static array." && v442);
                                    } else {
                                    }
                                    v428.v[v429] = v440;
                                    v429 += 1l ;
                                }
                                bool v445;
                                if (v184){
                                    bool v444;
                                    v444 = v183 < 2l;
                                    v445 = v444;
                                } else {
                                    v445 = false;
                                }
                                bool v446;
                                v446 = v445 == false;
                                if (v446){
                                    assert("The read index needs to be in range for the static array." && v445);
                                } else {
                                }
                                long v447;
                                v447 = v428.v[v183];
                                bool v448;
                                v448 = v379 < v447;
                                bool v449;
                                v449 = v448 == false;
                                if (v449){
                                    assert("The raise amount must be less than the stack size after calling." && v448);
                                } else {
                                }
                                long v450;
                                v450 = v400 + v379;
                                bool v452;
                                if (v184){
                                    bool v451;
                                    v451 = v183 < 2l;
                                    v452 = v451;
                                } else {
                                    v452 = false;
                                }
                                bool v453;
                                v453 = v452 == false;
                                if (v453){
                                    assert("The read index needs to be in range for the static array." && v452);
                                } else {
                                }
                                long v454;
                                v454 = v382.v[v183];
                                bool v455;
                                v455 = v450 < v454;
                                long v456;
                                if (v455){
                                    v456 = v450;
                                } else {
                                    v456 = v454;
                                }
                                static_array<long,2l> v457;
                                long v458;
                                v458 = 0l;
                                while (while_method_0(v458)){
                                    bool v460;
                                    v460 = 0l <= v458;
                                    bool v462;
                                    if (v460){
                                        bool v461;
                                        v461 = v458 < 2l;
                                        v462 = v461;
                                    } else {
                                        v462 = false;
                                    }
                                    bool v463;
                                    v463 = v462 == false;
                                    if (v463){
                                        assert("The read index needs to be in range for the static array." && v462);
                                    } else {
                                    }
                                    long v464;
                                    v464 = v179.v[v458];
                                    bool v465;
                                    v465 = v183 == v458;
                                    long v466;
                                    if (v465){
                                        v466 = v456;
                                    } else {
                                        v466 = v464;
                                    }
                                    bool v468;
                                    if (v460){
                                        bool v467;
                                        v467 = v458 < 2l;
                                        v468 = v467;
                                    } else {
                                        v468 = false;
                                    }
                                    bool v469;
                                    v469 = v468 == false;
                                    if (v469){
                                        assert("The read index needs to be in range for the static array." && v468);
                                    } else {
                                    }
                                    v457.v[v458] = v466;
                                    v458 += 1l ;
                                }
                                static_array<long,2l> v470;
                                long v471;
                                v471 = 0l;
                                while (while_method_0(v471)){
                                    bool v473;
                                    v473 = 0l <= v471;
                                    bool v475;
                                    if (v473){
                                        bool v474;
                                        v474 = v471 < 2l;
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
                                    long v477;
                                    v477 = v382.v[v471];
                                    bool v479;
                                    if (v473){
                                        bool v478;
                                        v478 = v471 < 2l;
                                        v479 = v478;
                                    } else {
                                        v479 = false;
                                    }
                                    bool v480;
                                    v480 = v479 == false;
                                    if (v480){
                                        assert("The read index needs to be in range for the static array." && v479);
                                    } else {
                                    }
                                    long v481;
                                    v481 = v457.v[v471];
                                    long v482;
                                    v482 = v477 - v481;
                                    bool v484;
                                    if (v473){
                                        bool v483;
                                        v483 = v471 < 2l;
                                        v484 = v483;
                                    } else {
                                        v484 = false;
                                    }
                                    bool v485;
                                    v485 = v484 == false;
                                    if (v485){
                                        assert("The read index needs to be in range for the static array." && v484);
                                    } else {
                                    }
                                    v470.v[v471] = v482;
                                    v471 += 1l ;
                                }
                                long v486;
                                v486 = v180 + 1l;
                                v597 = try_round_41(v379, v178, v457, v486, v470, v182);
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v1158 = true; v1159 = v597;
                        break;
                    }
                    case 1: { // Human
                        v1158 = false; v1159 = v8;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 5: { // G_Round'
                long v602 = v8.v.case5.v0; static_array<static_array<Tuple0,2l>,2l> v603 = v8.v.case5.v1; static_array<long,2l> v604 = v8.v.case5.v2; long v605 = v8.v.case5.v3; static_array<long,2l> v606 = v8.v.case5.v4; US8 v607 = v8.v.case5.v5; US1 v608 = v8.v.case5.v6;
                long v609;
                v609 = v605 % 2l;
                long v610;
                v610 = v5.length;
                bool v611;
                v611 = v610 < 128l;
                bool v612;
                v612 = v611 == false;
                if (v612){
                    assert("The length has to be less than the maximum length of the array." && v611);
                } else {
                }
                long v613;
                v613 = v610 + 1l;
                v5.length = v613;
                bool v614;
                v614 = 0l <= v610;
                bool v617;
                if (v614){
                    long v615;
                    v615 = v5.length;
                    bool v616;
                    v616 = v610 < v615;
                    v617 = v616;
                } else {
                    v617 = false;
                }
                bool v618;
                v618 = v617 == false;
                if (v618){
                    assert("The set index needs to be in range for the static array list." && v617);
                } else {
                }
                US3 v619;
                v619 = US3_2(v609, v608);
                v5.v[v610] = v619;
                US7 v909;
                switch (v608.tag) {
                    case 0: { // A_All_In
                        static_array<long,2l> v799;
                        long v800;
                        v800 = 0l;
                        while (while_method_0(v800)){
                            bool v802;
                            v802 = 0l <= v800;
                            bool v804;
                            if (v802){
                                bool v803;
                                v803 = v800 < 2l;
                                v804 = v803;
                            } else {
                                v804 = false;
                            }
                            bool v805;
                            v805 = v804 == false;
                            if (v805){
                                assert("The read index needs to be in range for the static array." && v804);
                            } else {
                            }
                            long v806;
                            v806 = v606.v[v800];
                            bool v808;
                            if (v802){
                                bool v807;
                                v807 = v800 < 2l;
                                v808 = v807;
                            } else {
                                v808 = false;
                            }
                            bool v809;
                            v809 = v808 == false;
                            if (v809){
                                assert("The read index needs to be in range for the static array." && v808);
                            } else {
                            }
                            long v810;
                            v810 = v604.v[v800];
                            long v811;
                            v811 = v806 + v810;
                            bool v813;
                            if (v802){
                                bool v812;
                                v812 = v800 < 2l;
                                v813 = v812;
                            } else {
                                v813 = false;
                            }
                            bool v814;
                            v814 = v813 == false;
                            if (v814){
                                assert("The read index needs to be in range for the static array." && v813);
                            } else {
                            }
                            v799.v[v800] = v811;
                            v800 += 1l ;
                        }
                        long v815;
                        v815 = v604.v[0l];
                        long v816; long v817;
                        Tuple3 tmp56 = Tuple3(1l, v815);
                        v816 = tmp56.v0; v817 = tmp56.v1;
                        while (while_method_0(v816)){
                            bool v819;
                            v819 = 0l <= v816;
                            bool v821;
                            if (v819){
                                bool v820;
                                v820 = v816 < 2l;
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
                            long v823;
                            v823 = v604.v[v816];
                            bool v824;
                            v824 = v817 >= v823;
                            long v825;
                            if (v824){
                                v825 = v817;
                            } else {
                                v825 = v823;
                            }
                            v817 = v825;
                            v816 += 1l ;
                        }
                        bool v826;
                        v826 = 0l <= v609;
                        bool v828;
                        if (v826){
                            bool v827;
                            v827 = v609 < 2l;
                            v828 = v827;
                        } else {
                            v828 = false;
                        }
                        bool v829;
                        v829 = v828 == false;
                        if (v829){
                            assert("The read index needs to be in range for the static array." && v828);
                        } else {
                        }
                        long v830;
                        v830 = v799.v[v609];
                        bool v831;
                        v831 = v817 < v830;
                        long v832;
                        if (v831){
                            v832 = v817;
                        } else {
                            v832 = v830;
                        }
                        static_array<long,2l> v833;
                        long v834;
                        v834 = 0l;
                        while (while_method_0(v834)){
                            bool v836;
                            v836 = 0l <= v834;
                            bool v838;
                            if (v836){
                                bool v837;
                                v837 = v834 < 2l;
                                v838 = v837;
                            } else {
                                v838 = false;
                            }
                            bool v839;
                            v839 = v838 == false;
                            if (v839){
                                assert("The read index needs to be in range for the static array." && v838);
                            } else {
                            }
                            long v840;
                            v840 = v604.v[v834];
                            bool v841;
                            v841 = v609 == v834;
                            long v842;
                            if (v841){
                                v842 = v832;
                            } else {
                                v842 = v840;
                            }
                            bool v844;
                            if (v836){
                                bool v843;
                                v843 = v834 < 2l;
                                v844 = v843;
                            } else {
                                v844 = false;
                            }
                            bool v845;
                            v845 = v844 == false;
                            if (v845){
                                assert("The read index needs to be in range for the static array." && v844);
                            } else {
                            }
                            v833.v[v834] = v842;
                            v834 += 1l ;
                        }
                        static_array<long,2l> v846;
                        long v847;
                        v847 = 0l;
                        while (while_method_0(v847)){
                            bool v849;
                            v849 = 0l <= v847;
                            bool v851;
                            if (v849){
                                bool v850;
                                v850 = v847 < 2l;
                                v851 = v850;
                            } else {
                                v851 = false;
                            }
                            bool v852;
                            v852 = v851 == false;
                            if (v852){
                                assert("The read index needs to be in range for the static array." && v851);
                            } else {
                            }
                            long v853;
                            v853 = v799.v[v847];
                            bool v855;
                            if (v849){
                                bool v854;
                                v854 = v847 < 2l;
                                v855 = v854;
                            } else {
                                v855 = false;
                            }
                            bool v856;
                            v856 = v855 == false;
                            if (v856){
                                assert("The read index needs to be in range for the static array." && v855);
                            } else {
                            }
                            long v857;
                            v857 = v833.v[v847];
                            long v858;
                            v858 = v853 - v857;
                            bool v860;
                            if (v849){
                                bool v859;
                                v859 = v847 < 2l;
                                v860 = v859;
                            } else {
                                v860 = false;
                            }
                            bool v861;
                            v861 = v860 == false;
                            if (v861){
                                assert("The read index needs to be in range for the static array." && v860);
                            } else {
                            }
                            v846.v[v847] = v858;
                            v847 += 1l ;
                        }
                        bool v863;
                        if (v826){
                            bool v862;
                            v862 = v609 < 2l;
                            v863 = v862;
                        } else {
                            v863 = false;
                        }
                        bool v864;
                        v864 = v863 == false;
                        if (v864){
                            assert("The read index needs to be in range for the static array." && v863);
                        } else {
                        }
                        long v865;
                        v865 = v846.v[v609];
                        long v866;
                        v866 = v817 + v865;
                        bool v868;
                        if (v826){
                            bool v867;
                            v867 = v609 < 2l;
                            v868 = v867;
                        } else {
                            v868 = false;
                        }
                        bool v869;
                        v869 = v868 == false;
                        if (v869){
                            assert("The read index needs to be in range for the static array." && v868);
                        } else {
                        }
                        long v870;
                        v870 = v799.v[v609];
                        bool v871;
                        v871 = v866 < v870;
                        long v872;
                        if (v871){
                            v872 = v866;
                        } else {
                            v872 = v870;
                        }
                        static_array<long,2l> v873;
                        long v874;
                        v874 = 0l;
                        while (while_method_0(v874)){
                            bool v876;
                            v876 = 0l <= v874;
                            bool v878;
                            if (v876){
                                bool v877;
                                v877 = v874 < 2l;
                                v878 = v877;
                            } else {
                                v878 = false;
                            }
                            bool v879;
                            v879 = v878 == false;
                            if (v879){
                                assert("The read index needs to be in range for the static array." && v878);
                            } else {
                            }
                            long v880;
                            v880 = v604.v[v874];
                            bool v881;
                            v881 = v609 == v874;
                            long v882;
                            if (v881){
                                v882 = v872;
                            } else {
                                v882 = v880;
                            }
                            bool v884;
                            if (v876){
                                bool v883;
                                v883 = v874 < 2l;
                                v884 = v883;
                            } else {
                                v884 = false;
                            }
                            bool v885;
                            v885 = v884 == false;
                            if (v885){
                                assert("The read index needs to be in range for the static array." && v884);
                            } else {
                            }
                            v873.v[v874] = v882;
                            v874 += 1l ;
                        }
                        static_array<long,2l> v886;
                        long v887;
                        v887 = 0l;
                        while (while_method_0(v887)){
                            bool v889;
                            v889 = 0l <= v887;
                            bool v891;
                            if (v889){
                                bool v890;
                                v890 = v887 < 2l;
                                v891 = v890;
                            } else {
                                v891 = false;
                            }
                            bool v892;
                            v892 = v891 == false;
                            if (v892){
                                assert("The read index needs to be in range for the static array." && v891);
                            } else {
                            }
                            long v893;
                            v893 = v799.v[v887];
                            bool v895;
                            if (v889){
                                bool v894;
                                v894 = v887 < 2l;
                                v895 = v894;
                            } else {
                                v895 = false;
                            }
                            bool v896;
                            v896 = v895 == false;
                            if (v896){
                                assert("The read index needs to be in range for the static array." && v895);
                            } else {
                            }
                            long v897;
                            v897 = v873.v[v887];
                            long v898;
                            v898 = v893 - v897;
                            bool v900;
                            if (v889){
                                bool v899;
                                v899 = v887 < 2l;
                                v900 = v899;
                            } else {
                                v900 = false;
                            }
                            bool v901;
                            v901 = v900 == false;
                            if (v901){
                                assert("The read index needs to be in range for the static array." && v900);
                            } else {
                            }
                            v886.v[v887] = v898;
                            v887 += 1l ;
                        }
                        bool v902;
                        v902 = v865 >= v602;
                        long v903;
                        if (v902){
                            v903 = v865;
                        } else {
                            v903 = v602;
                        }
                        long v904;
                        v904 = v605 + 1l;
                        v909 = try_round_41(v903, v603, v873, v904, v886, v607);
                        break;
                    }
                    case 1: { // A_Call
                        static_array<long,2l> v621;
                        long v622;
                        v622 = 0l;
                        while (while_method_0(v622)){
                            bool v624;
                            v624 = 0l <= v622;
                            bool v626;
                            if (v624){
                                bool v625;
                                v625 = v622 < 2l;
                                v626 = v625;
                            } else {
                                v626 = false;
                            }
                            bool v627;
                            v627 = v626 == false;
                            if (v627){
                                assert("The read index needs to be in range for the static array." && v626);
                            } else {
                            }
                            long v628;
                            v628 = v606.v[v622];
                            bool v630;
                            if (v624){
                                bool v629;
                                v629 = v622 < 2l;
                                v630 = v629;
                            } else {
                                v630 = false;
                            }
                            bool v631;
                            v631 = v630 == false;
                            if (v631){
                                assert("The read index needs to be in range for the static array." && v630);
                            } else {
                            }
                            long v632;
                            v632 = v604.v[v622];
                            long v633;
                            v633 = v628 + v632;
                            bool v635;
                            if (v624){
                                bool v634;
                                v634 = v622 < 2l;
                                v635 = v634;
                            } else {
                                v635 = false;
                            }
                            bool v636;
                            v636 = v635 == false;
                            if (v636){
                                assert("The read index needs to be in range for the static array." && v635);
                            } else {
                            }
                            v621.v[v622] = v633;
                            v622 += 1l ;
                        }
                        long v637;
                        v637 = v604.v[0l];
                        long v638; long v639;
                        Tuple3 tmp57 = Tuple3(1l, v637);
                        v638 = tmp57.v0; v639 = tmp57.v1;
                        while (while_method_0(v638)){
                            bool v641;
                            v641 = 0l <= v638;
                            bool v643;
                            if (v641){
                                bool v642;
                                v642 = v638 < 2l;
                                v643 = v642;
                            } else {
                                v643 = false;
                            }
                            bool v644;
                            v644 = v643 == false;
                            if (v644){
                                assert("The read index needs to be in range for the static array." && v643);
                            } else {
                            }
                            long v645;
                            v645 = v604.v[v638];
                            bool v646;
                            v646 = v639 >= v645;
                            long v647;
                            if (v646){
                                v647 = v639;
                            } else {
                                v647 = v645;
                            }
                            v639 = v647;
                            v638 += 1l ;
                        }
                        bool v648;
                        v648 = 0l <= v609;
                        bool v650;
                        if (v648){
                            bool v649;
                            v649 = v609 < 2l;
                            v650 = v649;
                        } else {
                            v650 = false;
                        }
                        bool v651;
                        v651 = v650 == false;
                        if (v651){
                            assert("The read index needs to be in range for the static array." && v650);
                        } else {
                        }
                        long v652;
                        v652 = v621.v[v609];
                        bool v653;
                        v653 = v639 < v652;
                        long v654;
                        if (v653){
                            v654 = v639;
                        } else {
                            v654 = v652;
                        }
                        static_array<long,2l> v655;
                        long v656;
                        v656 = 0l;
                        while (while_method_0(v656)){
                            bool v658;
                            v658 = 0l <= v656;
                            bool v660;
                            if (v658){
                                bool v659;
                                v659 = v656 < 2l;
                                v660 = v659;
                            } else {
                                v660 = false;
                            }
                            bool v661;
                            v661 = v660 == false;
                            if (v661){
                                assert("The read index needs to be in range for the static array." && v660);
                            } else {
                            }
                            long v662;
                            v662 = v604.v[v656];
                            bool v663;
                            v663 = v609 == v656;
                            long v664;
                            if (v663){
                                v664 = v654;
                            } else {
                                v664 = v662;
                            }
                            bool v666;
                            if (v658){
                                bool v665;
                                v665 = v656 < 2l;
                                v666 = v665;
                            } else {
                                v666 = false;
                            }
                            bool v667;
                            v667 = v666 == false;
                            if (v667){
                                assert("The read index needs to be in range for the static array." && v666);
                            } else {
                            }
                            v655.v[v656] = v664;
                            v656 += 1l ;
                        }
                        static_array<long,2l> v668;
                        long v669;
                        v669 = 0l;
                        while (while_method_0(v669)){
                            bool v671;
                            v671 = 0l <= v669;
                            bool v673;
                            if (v671){
                                bool v672;
                                v672 = v669 < 2l;
                                v673 = v672;
                            } else {
                                v673 = false;
                            }
                            bool v674;
                            v674 = v673 == false;
                            if (v674){
                                assert("The read index needs to be in range for the static array." && v673);
                            } else {
                            }
                            long v675;
                            v675 = v621.v[v669];
                            bool v677;
                            if (v671){
                                bool v676;
                                v676 = v669 < 2l;
                                v677 = v676;
                            } else {
                                v677 = false;
                            }
                            bool v678;
                            v678 = v677 == false;
                            if (v678){
                                assert("The read index needs to be in range for the static array." && v677);
                            } else {
                            }
                            long v679;
                            v679 = v655.v[v669];
                            long v680;
                            v680 = v675 - v679;
                            bool v682;
                            if (v671){
                                bool v681;
                                v681 = v669 < 2l;
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
                            v668.v[v669] = v680;
                            v669 += 1l ;
                        }
                        bool v684;
                        v684 = v609 < 2l;
                        if (v684){
                            long v685;
                            v685 = v605 + 1l;
                            v909 = try_round_41(v602, v603, v655, v685, v668, v607);
                        } else {
                            v909 = go_next_street_43(v602, v603, v655, v605, v668, v607);
                        }
                        break;
                    }
                    case 2: { // A_Fold
                        v909 = US7_1(v602, v603, v604, v605, v606, v607);
                        break;
                    }
                    case 3: { // A_Raise
                        long v689 = v608.v.case3.v0;
                        bool v690;
                        v690 = v602 <= v689;
                        bool v691;
                        v691 = v690 == false;
                        if (v691){
                            assert("The raise amount must match the minimum." && v690);
                        } else {
                        }
                        static_array<long,2l> v692;
                        long v693;
                        v693 = 0l;
                        while (while_method_0(v693)){
                            bool v695;
                            v695 = 0l <= v693;
                            bool v697;
                            if (v695){
                                bool v696;
                                v696 = v693 < 2l;
                                v697 = v696;
                            } else {
                                v697 = false;
                            }
                            bool v698;
                            v698 = v697 == false;
                            if (v698){
                                assert("The read index needs to be in range for the static array." && v697);
                            } else {
                            }
                            long v699;
                            v699 = v606.v[v693];
                            bool v701;
                            if (v695){
                                bool v700;
                                v700 = v693 < 2l;
                                v701 = v700;
                            } else {
                                v701 = false;
                            }
                            bool v702;
                            v702 = v701 == false;
                            if (v702){
                                assert("The read index needs to be in range for the static array." && v701);
                            } else {
                            }
                            long v703;
                            v703 = v604.v[v693];
                            long v704;
                            v704 = v699 + v703;
                            bool v706;
                            if (v695){
                                bool v705;
                                v705 = v693 < 2l;
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
                            v692.v[v693] = v704;
                            v693 += 1l ;
                        }
                        long v708;
                        v708 = v604.v[0l];
                        long v709; long v710;
                        Tuple3 tmp58 = Tuple3(1l, v708);
                        v709 = tmp58.v0; v710 = tmp58.v1;
                        while (while_method_0(v709)){
                            bool v712;
                            v712 = 0l <= v709;
                            bool v714;
                            if (v712){
                                bool v713;
                                v713 = v709 < 2l;
                                v714 = v713;
                            } else {
                                v714 = false;
                            }
                            bool v715;
                            v715 = v714 == false;
                            if (v715){
                                assert("The read index needs to be in range for the static array." && v714);
                            } else {
                            }
                            long v716;
                            v716 = v604.v[v709];
                            bool v717;
                            v717 = v710 >= v716;
                            long v718;
                            if (v717){
                                v718 = v710;
                            } else {
                                v718 = v716;
                            }
                            v710 = v718;
                            v709 += 1l ;
                        }
                        bool v719;
                        v719 = 0l <= v609;
                        bool v721;
                        if (v719){
                            bool v720;
                            v720 = v609 < 2l;
                            v721 = v720;
                        } else {
                            v721 = false;
                        }
                        bool v722;
                        v722 = v721 == false;
                        if (v722){
                            assert("The read index needs to be in range for the static array." && v721);
                        } else {
                        }
                        long v723;
                        v723 = v692.v[v609];
                        bool v724;
                        v724 = v710 < v723;
                        long v725;
                        if (v724){
                            v725 = v710;
                        } else {
                            v725 = v723;
                        }
                        static_array<long,2l> v726;
                        long v727;
                        v727 = 0l;
                        while (while_method_0(v727)){
                            bool v729;
                            v729 = 0l <= v727;
                            bool v731;
                            if (v729){
                                bool v730;
                                v730 = v727 < 2l;
                                v731 = v730;
                            } else {
                                v731 = false;
                            }
                            bool v732;
                            v732 = v731 == false;
                            if (v732){
                                assert("The read index needs to be in range for the static array." && v731);
                            } else {
                            }
                            long v733;
                            v733 = v604.v[v727];
                            bool v734;
                            v734 = v609 == v727;
                            long v735;
                            if (v734){
                                v735 = v725;
                            } else {
                                v735 = v733;
                            }
                            bool v737;
                            if (v729){
                                bool v736;
                                v736 = v727 < 2l;
                                v737 = v736;
                            } else {
                                v737 = false;
                            }
                            bool v738;
                            v738 = v737 == false;
                            if (v738){
                                assert("The read index needs to be in range for the static array." && v737);
                            } else {
                            }
                            v726.v[v727] = v735;
                            v727 += 1l ;
                        }
                        static_array<long,2l> v739;
                        long v740;
                        v740 = 0l;
                        while (while_method_0(v740)){
                            bool v742;
                            v742 = 0l <= v740;
                            bool v744;
                            if (v742){
                                bool v743;
                                v743 = v740 < 2l;
                                v744 = v743;
                            } else {
                                v744 = false;
                            }
                            bool v745;
                            v745 = v744 == false;
                            if (v745){
                                assert("The read index needs to be in range for the static array." && v744);
                            } else {
                            }
                            long v746;
                            v746 = v692.v[v740];
                            bool v748;
                            if (v742){
                                bool v747;
                                v747 = v740 < 2l;
                                v748 = v747;
                            } else {
                                v748 = false;
                            }
                            bool v749;
                            v749 = v748 == false;
                            if (v749){
                                assert("The read index needs to be in range for the static array." && v748);
                            } else {
                            }
                            long v750;
                            v750 = v726.v[v740];
                            long v751;
                            v751 = v746 - v750;
                            bool v753;
                            if (v742){
                                bool v752;
                                v752 = v740 < 2l;
                                v753 = v752;
                            } else {
                                v753 = false;
                            }
                            bool v754;
                            v754 = v753 == false;
                            if (v754){
                                assert("The read index needs to be in range for the static array." && v753);
                            } else {
                            }
                            v739.v[v740] = v751;
                            v740 += 1l ;
                        }
                        bool v756;
                        if (v719){
                            bool v755;
                            v755 = v609 < 2l;
                            v756 = v755;
                        } else {
                            v756 = false;
                        }
                        bool v757;
                        v757 = v756 == false;
                        if (v757){
                            assert("The read index needs to be in range for the static array." && v756);
                        } else {
                        }
                        long v758;
                        v758 = v739.v[v609];
                        bool v759;
                        v759 = v689 < v758;
                        bool v760;
                        v760 = v759 == false;
                        if (v760){
                            assert("The raise amount must be less than the stack size after calling." && v759);
                        } else {
                        }
                        long v761;
                        v761 = v710 + v689;
                        bool v763;
                        if (v719){
                            bool v762;
                            v762 = v609 < 2l;
                            v763 = v762;
                        } else {
                            v763 = false;
                        }
                        bool v764;
                        v764 = v763 == false;
                        if (v764){
                            assert("The read index needs to be in range for the static array." && v763);
                        } else {
                        }
                        long v765;
                        v765 = v692.v[v609];
                        bool v766;
                        v766 = v761 < v765;
                        long v767;
                        if (v766){
                            v767 = v761;
                        } else {
                            v767 = v765;
                        }
                        static_array<long,2l> v768;
                        long v769;
                        v769 = 0l;
                        while (while_method_0(v769)){
                            bool v771;
                            v771 = 0l <= v769;
                            bool v773;
                            if (v771){
                                bool v772;
                                v772 = v769 < 2l;
                                v773 = v772;
                            } else {
                                v773 = false;
                            }
                            bool v774;
                            v774 = v773 == false;
                            if (v774){
                                assert("The read index needs to be in range for the static array." && v773);
                            } else {
                            }
                            long v775;
                            v775 = v604.v[v769];
                            bool v776;
                            v776 = v609 == v769;
                            long v777;
                            if (v776){
                                v777 = v767;
                            } else {
                                v777 = v775;
                            }
                            bool v779;
                            if (v771){
                                bool v778;
                                v778 = v769 < 2l;
                                v779 = v778;
                            } else {
                                v779 = false;
                            }
                            bool v780;
                            v780 = v779 == false;
                            if (v780){
                                assert("The read index needs to be in range for the static array." && v779);
                            } else {
                            }
                            v768.v[v769] = v777;
                            v769 += 1l ;
                        }
                        static_array<long,2l> v781;
                        long v782;
                        v782 = 0l;
                        while (while_method_0(v782)){
                            bool v784;
                            v784 = 0l <= v782;
                            bool v786;
                            if (v784){
                                bool v785;
                                v785 = v782 < 2l;
                                v786 = v785;
                            } else {
                                v786 = false;
                            }
                            bool v787;
                            v787 = v786 == false;
                            if (v787){
                                assert("The read index needs to be in range for the static array." && v786);
                            } else {
                            }
                            long v788;
                            v788 = v692.v[v782];
                            bool v790;
                            if (v784){
                                bool v789;
                                v789 = v782 < 2l;
                                v790 = v789;
                            } else {
                                v790 = false;
                            }
                            bool v791;
                            v791 = v790 == false;
                            if (v791){
                                assert("The read index needs to be in range for the static array." && v790);
                            } else {
                            }
                            long v792;
                            v792 = v768.v[v782];
                            long v793;
                            v793 = v788 - v792;
                            bool v795;
                            if (v784){
                                bool v794;
                                v794 = v782 < 2l;
                                v795 = v794;
                            } else {
                                v795 = false;
                            }
                            bool v796;
                            v796 = v795 == false;
                            if (v796){
                                assert("The read index needs to be in range for the static array." && v795);
                            } else {
                            }
                            v781.v[v782] = v793;
                            v782 += 1l ;
                        }
                        long v797;
                        v797 = v605 + 1l;
                        v909 = try_round_41(v689, v603, v768, v797, v781, v607);
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                v1158 = true; v1159 = v909;
                break;
            }
            case 6: { // G_Showdown
                long v34 = v8.v.case6.v0; static_array<static_array<Tuple0,2l>,2l> v35 = v8.v.case6.v1; static_array<long,2l> v36 = v8.v.case6.v2; long v37 = v8.v.case6.v3; static_array<long,2l> v38 = v8.v.case6.v4; US8 v39 = v8.v.case6.v5;
                static_array<Tuple0,5l> v42;
                switch (v39.tag) {
                    case 2: { // River
                        static_array<Tuple0,5l> v40 = v39.v.case2.v0;
                        v42 = v40;
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in showdown.");
                        asm("exit;");
                    }
                }
                static_array<Tuple0,2l> v43;
                v43 = v35.v[0l];
                static_array<Tuple0,7l> v44;
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
                    US4 v51; US5 v52;
                    Tuple0 tmp59 = v43.v[v45];
                    v51 = tmp59.v0; v52 = tmp59.v1;
                    bool v54;
                    if (v47){
                        bool v53;
                        v53 = v45 < 7l;
                        v54 = v53;
                    } else {
                        v54 = false;
                    }
                    bool v55;
                    v55 = v54 == false;
                    if (v55){
                        assert("The read index needs to be in range for the static array." && v54);
                    } else {
                    }
                    v44.v[v45] = Tuple0(v51, v52);
                    v45 += 1l ;
                }
                long v56;
                v56 = 0l;
                while (while_method_2(v56)){
                    bool v58;
                    v58 = 0l <= v56;
                    bool v60;
                    if (v58){
                        bool v59;
                        v59 = v56 < 5l;
                        v60 = v59;
                    } else {
                        v60 = false;
                    }
                    bool v61;
                    v61 = v60 == false;
                    if (v61){
                        assert("The read index needs to be in range for the static array." && v60);
                    } else {
                    }
                    US4 v62; US5 v63;
                    Tuple0 tmp60 = v42.v[v56];
                    v62 = tmp60.v0; v63 = tmp60.v1;
                    long v64;
                    v64 = 2l + v56;
                    bool v65;
                    v65 = 0l <= v64;
                    bool v67;
                    if (v65){
                        bool v66;
                        v66 = v64 < 7l;
                        v67 = v66;
                    } else {
                        v67 = false;
                    }
                    bool v68;
                    v68 = v67 == false;
                    if (v68){
                        assert("The read index needs to be in range for the static array." && v67);
                    } else {
                    }
                    v44.v[v64] = Tuple0(v62, v63);
                    v56 += 1l ;
                }
                static_array<unsigned char,7l> v69;
                long v70;
                v70 = 0l;
                while (while_method_10(v70)){
                    bool v72;
                    v72 = 0l <= v70;
                    bool v74;
                    if (v72){
                        bool v73;
                        v73 = v70 < 7l;
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
                    US4 v76; US5 v77;
                    Tuple0 tmp61 = v44.v[v70];
                    v76 = tmp61.v0; v77 = tmp61.v1;
                    unsigned char v78;
                    v78 = lib_card_from_card_50(v77, v76);
                    bool v80;
                    if (v72){
                        bool v79;
                        v79 = v70 < 7l;
                        v80 = v79;
                    } else {
                        v80 = false;
                    }
                    bool v81;
                    v81 = v80 == false;
                    if (v81){
                        assert("The read index needs to be in range for the static array." && v80);
                    } else {
                    }
                    v69.v[v70] = v78;
                    v70 += 1l ;
                }
                static_array<unsigned char,5l> v82; char v83;
                Tuple1 tmp86 = score_53(v69);
                v82 = tmp86.v0; v83 = tmp86.v1;
                static_array<Tuple0,2l> v84;
                v84 = v35.v[1l];
                static_array<Tuple0,7l> v85;
                long v86;
                v86 = 0l;
                while (while_method_0(v86)){
                    bool v88;
                    v88 = 0l <= v86;
                    bool v90;
                    if (v88){
                        bool v89;
                        v89 = v86 < 2l;
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
                    US4 v92; US5 v93;
                    Tuple0 tmp87 = v84.v[v86];
                    v92 = tmp87.v0; v93 = tmp87.v1;
                    bool v95;
                    if (v88){
                        bool v94;
                        v94 = v86 < 7l;
                        v95 = v94;
                    } else {
                        v95 = false;
                    }
                    bool v96;
                    v96 = v95 == false;
                    if (v96){
                        assert("The read index needs to be in range for the static array." && v95);
                    } else {
                    }
                    v85.v[v86] = Tuple0(v92, v93);
                    v86 += 1l ;
                }
                long v97;
                v97 = 0l;
                while (while_method_2(v97)){
                    bool v99;
                    v99 = 0l <= v97;
                    bool v101;
                    if (v99){
                        bool v100;
                        v100 = v97 < 5l;
                        v101 = v100;
                    } else {
                        v101 = false;
                    }
                    bool v102;
                    v102 = v101 == false;
                    if (v102){
                        assert("The read index needs to be in range for the static array." && v101);
                    } else {
                    }
                    US4 v103; US5 v104;
                    Tuple0 tmp88 = v42.v[v97];
                    v103 = tmp88.v0; v104 = tmp88.v1;
                    long v105;
                    v105 = 2l + v97;
                    bool v106;
                    v106 = 0l <= v105;
                    bool v108;
                    if (v106){
                        bool v107;
                        v107 = v105 < 7l;
                        v108 = v107;
                    } else {
                        v108 = false;
                    }
                    bool v109;
                    v109 = v108 == false;
                    if (v109){
                        assert("The read index needs to be in range for the static array." && v108);
                    } else {
                    }
                    v85.v[v105] = Tuple0(v103, v104);
                    v97 += 1l ;
                }
                static_array<unsigned char,7l> v110;
                long v111;
                v111 = 0l;
                while (while_method_10(v111)){
                    bool v113;
                    v113 = 0l <= v111;
                    bool v115;
                    if (v113){
                        bool v114;
                        v114 = v111 < 7l;
                        v115 = v114;
                    } else {
                        v115 = false;
                    }
                    bool v116;
                    v116 = v115 == false;
                    if (v116){
                        assert("The read index needs to be in range for the static array." && v115);
                    } else {
                    }
                    US4 v117; US5 v118;
                    Tuple0 tmp89 = v85.v[v111];
                    v117 = tmp89.v0; v118 = tmp89.v1;
                    unsigned char v119;
                    v119 = lib_card_from_card_50(v118, v117);
                    bool v121;
                    if (v113){
                        bool v120;
                        v120 = v111 < 7l;
                        v121 = v120;
                    } else {
                        v121 = false;
                    }
                    bool v122;
                    v122 = v121 == false;
                    if (v122){
                        assert("The read index needs to be in range for the static array." && v121);
                    } else {
                    }
                    v110.v[v111] = v119;
                    v111 += 1l ;
                }
                static_array<unsigned char,5l> v123; char v124;
                Tuple1 tmp90 = score_53(v110);
                v123 = tmp90.v0; v124 = tmp90.v1;
                long v125;
                v125 = v37 % 2l;
                bool v126;
                v126 = 0l <= v125;
                bool v128;
                if (v126){
                    bool v127;
                    v127 = v125 < 2l;
                    v128 = v127;
                } else {
                    v128 = false;
                }
                bool v129;
                v129 = v128 == false;
                if (v129){
                    assert("The read index needs to be in range for the static array." && v128);
                } else {
                }
                long v130;
                v130 = v36.v[v125];
                bool v131;
                v131 = v83 < v124;
                US10 v137;
                if (v131){
                    v137 = US10_2();
                } else {
                    bool v133;
                    v133 = v83 > v124;
                    if (v133){
                        v137 = US10_1();
                    } else {
                        v137 = US10_0();
                    }
                }
                US10 v159;
                switch (v137.tag) {
                    case 0: { // Eq
                        US10 v138;
                        v138 = US10_0();
                        long v139;
                        v139 = 0l;
                        while (while_method_2(v139)){
                            bool v141;
                            v141 = 0l <= v139;
                            bool v143;
                            if (v141){
                                bool v142;
                                v142 = v139 < 5l;
                                v143 = v142;
                            } else {
                                v143 = false;
                            }
                            bool v144;
                            v144 = v143 == false;
                            if (v144){
                                assert("The read index needs to be in range for the static array." && v143);
                            } else {
                            }
                            unsigned char v145;
                            v145 = v82.v[v139];
                            bool v147;
                            if (v141){
                                bool v146;
                                v146 = v139 < 5l;
                                v147 = v146;
                            } else {
                                v147 = false;
                            }
                            bool v148;
                            v148 = v147 == false;
                            if (v148){
                                assert("The read index needs to be in range for the static array." && v147);
                            } else {
                            }
                            unsigned char v149;
                            v149 = v123.v[v139];
                            bool v150;
                            v150 = v145 < v149;
                            US10 v156;
                            if (v150){
                                v156 = US10_2();
                            } else {
                                bool v152;
                                v152 = v145 > v149;
                                if (v152){
                                    v156 = US10_1();
                                } else {
                                    v156 = US10_0();
                                }
                            }
                            bool v157;
                            switch (v156.tag) {
                                case 0: { // Eq
                                    v157 = true;
                                    break;
                                }
                                default: {
                                    v157 = false;
                                }
                            }
                            bool v158;
                            v158 = v157 == false;
                            if (v158){
                                v138 = v156;
                                break;
                            } else {
                            }
                            v139 += 1l ;
                        }
                        v159 = v138;
                        break;
                    }
                    default: {
                        v159 = v137;
                    }
                }
                long v164; long v165;
                switch (v159.tag) {
                    case 0: { // Eq
                        v164 = 0l; v165 = -1l;
                        break;
                    }
                    case 1: { // Gt
                        v164 = v130; v165 = 0l;
                        break;
                    }
                    case 2: { // Lt
                        v164 = v130; v165 = 1l;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                static_array<Tuple1,2l> v166;
                v166.v[0l] = Tuple1(v82, v83);
                v166.v[1l] = Tuple1(v123, v124);
                long v167;
                v167 = v5.length;
                bool v168;
                v168 = v167 < 128l;
                bool v169;
                v169 = v168 == false;
                if (v169){
                    assert("The length has to be less than the maximum length of the array." && v168);
                } else {
                }
                long v170;
                v170 = v167 + 1l;
                v5.length = v170;
                bool v171;
                v171 = 0l <= v167;
                bool v174;
                if (v171){
                    long v172;
                    v172 = v5.length;
                    bool v173;
                    v173 = v167 < v172;
                    v174 = v173;
                } else {
                    v174 = false;
                }
                bool v175;
                v175 = v174 == false;
                if (v175){
                    assert("The set index needs to be in range for the static array list." && v174);
                } else {
                }
                US3 v176;
                v176 = US3_4(v164, v166, v165);
                v5.v[v167] = v176;
                v1158 = false; v1159 = v8;
                break;
            }
            case 7: { // G_Turn
                long v948 = v8.v.case7.v0; static_array<static_array<Tuple0,2l>,2l> v949 = v8.v.case7.v1; static_array<long,2l> v950 = v8.v.case7.v2; long v951 = v8.v.case7.v3; static_array<long,2l> v952 = v8.v.case7.v4; US8 v953 = v8.v.case7.v5;
                static_array<unsigned char,1l> v954; unsigned long long v955;
                Tuple15 tmp91 = draw_cards_45(v2, v6);
                v954 = tmp91.v0; v955 = tmp91.v1;
                v0 = v955;
                static_array<Tuple0,1l> v956;
                long v957;
                v957 = 0l;
                while (while_method_6(v957)){
                    bool v959;
                    v959 = 0l <= v957;
                    bool v961;
                    if (v959){
                        bool v960;
                        v960 = v957 < 1l;
                        v961 = v960;
                    } else {
                        v961 = false;
                    }
                    bool v962;
                    v962 = v961 == false;
                    if (v962){
                        assert("The read index needs to be in range for the static array." && v961);
                    } else {
                    }
                    unsigned char v963;
                    v963 = v954.v[v957];
                    US4 v964; US5 v965;
                    Tuple0 tmp92 = card_from_lib_card_37(v963);
                    v964 = tmp92.v0; v965 = tmp92.v1;
                    bool v967;
                    if (v959){
                        bool v966;
                        v966 = v957 < 1l;
                        v967 = v966;
                    } else {
                        v967 = false;
                    }
                    bool v968;
                    v968 = v967 == false;
                    if (v968){
                        assert("The read index needs to be in range for the static array." && v967);
                    } else {
                    }
                    v956.v[v957] = Tuple0(v964, v965);
                    v957 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v969;
                v969 = get_community_cards_46(v953, v956);
                long v970;
                v970 = v5.length;
                bool v971;
                v971 = v970 < 128l;
                bool v972;
                v972 = v971 == false;
                if (v972){
                    assert("The length has to be less than the maximum length of the array." && v971);
                } else {
                }
                long v973;
                v973 = v970 + 1l;
                v5.length = v973;
                bool v974;
                v974 = 0l <= v970;
                bool v977;
                if (v974){
                    long v975;
                    v975 = v5.length;
                    bool v976;
                    v976 = v970 < v975;
                    v977 = v976;
                } else {
                    v977 = false;
                }
                bool v978;
                v978 = v977 == false;
                if (v978){
                    assert("The set index needs to be in range for the static array list." && v977);
                } else {
                }
                US3 v979;
                v979 = US3_0(v969);
                v5.v[v970] = v979;
                US8 v1008;
                switch (v953.tag) {
                    case 0: { // Flop
                        static_array<Tuple0,3l> v980 = v953.v.case0.v0;
                        static_array<Tuple0,4l> v981;
                        long v982;
                        v982 = 0l;
                        while (while_method_3(v982)){
                            bool v984;
                            v984 = 0l <= v982;
                            bool v986;
                            if (v984){
                                bool v985;
                                v985 = v982 < 3l;
                                v986 = v985;
                            } else {
                                v986 = false;
                            }
                            bool v987;
                            v987 = v986 == false;
                            if (v987){
                                assert("The read index needs to be in range for the static array." && v986);
                            } else {
                            }
                            US4 v988; US5 v989;
                            Tuple0 tmp93 = v980.v[v982];
                            v988 = tmp93.v0; v989 = tmp93.v1;
                            bool v991;
                            if (v984){
                                bool v990;
                                v990 = v982 < 4l;
                                v991 = v990;
                            } else {
                                v991 = false;
                            }
                            bool v992;
                            v992 = v991 == false;
                            if (v992){
                                assert("The read index needs to be in range for the static array." && v991);
                            } else {
                            }
                            v981.v[v982] = Tuple0(v988, v989);
                            v982 += 1l ;
                        }
                        long v993;
                        v993 = 0l;
                        while (while_method_6(v993)){
                            bool v995;
                            v995 = 0l <= v993;
                            bool v997;
                            if (v995){
                                bool v996;
                                v996 = v993 < 1l;
                                v997 = v996;
                            } else {
                                v997 = false;
                            }
                            bool v998;
                            v998 = v997 == false;
                            if (v998){
                                assert("The read index needs to be in range for the static array." && v997);
                            } else {
                            }
                            US4 v999; US5 v1000;
                            Tuple0 tmp94 = v956.v[v993];
                            v999 = tmp94.v0; v1000 = tmp94.v1;
                            long v1001;
                            v1001 = 3l + v993;
                            bool v1002;
                            v1002 = 0l <= v1001;
                            bool v1004;
                            if (v1002){
                                bool v1003;
                                v1003 = v1001 < 4l;
                                v1004 = v1003;
                            } else {
                                v1004 = false;
                            }
                            bool v1005;
                            v1005 = v1004 == false;
                            if (v1005){
                                assert("The read index needs to be in range for the static array." && v1004);
                            } else {
                            }
                            v981.v[v1001] = Tuple0(v999, v1000);
                            v993 += 1l ;
                        }
                        v1008 = US8_3(v981);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in turn.");
                        asm("exit;");
                    }
                }
                long v1009;
                v1009 = 2l;
                long v1010;
                v1010 = 0l;
                US7 v1011;
                v1011 = try_round_41(v1009, v949, v950, v1010, v952, v1008);
                v1158 = true; v1159 = v1011;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v7 = v1158;
        v8 = v1159;
    }
    return v8;
}
__device__ Tuple9 play_loop_32(US6 v0, static_array<US2,2l> v1, US9 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US7 v6){
    US7 v7;
    v7 = play_loop_inner_33(v3, v4, v5, v1, v6);
    switch (v7.tag) {
        case 1: { // G_Fold
            long v24 = v7.v.case1.v0; static_array<static_array<Tuple0,2l>,2l> v25 = v7.v.case1.v1; static_array<long,2l> v26 = v7.v.case1.v2; long v27 = v7.v.case1.v3; static_array<long,2l> v28 = v7.v.case1.v4; US8 v29 = v7.v.case1.v5;
            US6 v30;
            v30 = US6_0();
            US9 v31;
            v31 = US9_1(v24, v25, v26, v27, v28, v29);
            return Tuple9(v30, v1, v31);
            break;
        }
        case 4: { // G_Round
            long v8 = v7.v.case4.v0; static_array<static_array<Tuple0,2l>,2l> v9 = v7.v.case4.v1; static_array<long,2l> v10 = v7.v.case4.v2; long v11 = v7.v.case4.v3; static_array<long,2l> v12 = v7.v.case4.v4; US8 v13 = v7.v.case4.v5;
            US6 v14;
            v14 = US6_1(v7);
            US9 v15;
            v15 = US9_2(v8, v9, v10, v11, v12, v13);
            return Tuple9(v14, v1, v15);
            break;
        }
        case 6: { // G_Showdown
            long v16 = v7.v.case6.v0; static_array<static_array<Tuple0,2l>,2l> v17 = v7.v.case6.v1; static_array<long,2l> v18 = v7.v.case6.v2; long v19 = v7.v.case6.v3; static_array<long,2l> v20 = v7.v.case6.v4; US8 v21 = v7.v.case6.v5;
            US6 v22;
            v22 = US6_0();
            US9 v23;
            v23 = US9_1(v16, v17, v18, v19, v20, v21);
            return Tuple9(v22, v1, v23);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
__device__ void f_55(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_56(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_58(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_61(unsigned char * v0){
    return ;
}
__device__ void f_62(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_60(unsigned char * v0, US4 v1, US5 v2){
    long v3;
    v3 = v1.tag;
    f_58(v0, v3);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Ace
            f_61(v4);
            break;
        }
        case 1: { // Eight
            f_61(v4);
            break;
        }
        case 2: { // Five
            f_61(v4);
            break;
        }
        case 3: { // Four
            f_61(v4);
            break;
        }
        case 4: { // Jack
            f_61(v4);
            break;
        }
        case 5: { // King
            f_61(v4);
            break;
        }
        case 6: { // Nine
            f_61(v4);
            break;
        }
        case 7: { // Queen
            f_61(v4);
            break;
        }
        case 8: { // Seven
            f_61(v4);
            break;
        }
        case 9: { // Six
            f_61(v4);
            break;
        }
        case 10: { // Ten
            f_61(v4);
            break;
        }
        case 11: { // Three
            f_61(v4);
            break;
        }
        case 12: { // Two
            f_61(v4);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v5;
    v5 = v2.tag;
    f_62(v0, v5);
    unsigned char * v6;
    v6 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // Clubs
            return f_61(v6);
            break;
        }
        case 1: { // Diamonds
            return f_61(v6);
            break;
        }
        case 2: { // Hearts
            return f_61(v6);
            break;
        }
        case 3: { // Spades
            return f_61(v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_59(unsigned char * v0, static_array_list<Tuple0,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_58(v0, v2);
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_1(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
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
            assert("The read index needs to be in range for the static array list." && v13);
        } else {
        }
        US4 v15; US5 v16;
        Tuple0 tmp97 = v1.v[v4];
        v15 = tmp97.v0; v16 = tmp97.v1;
        f_60(v9, v15, v16);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_63(unsigned char * v0, long v1, long v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long * v4;
    v4 = (long *)(v0+4ull);
    v4[0l] = v2;
    return ;
}
__device__ void f_64(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_62(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_All_In
            return f_61(v5);
            break;
        }
        case 1: { // A_Call
            return f_61(v5);
            break;
        }
        case 2: { // A_Fold
            return f_61(v5);
            break;
        }
        case 3: { // A_Raise
            long v6 = v2.v.case3.v0;
            return f_58(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_65(unsigned char * v0, long v1, static_array<Tuple0,2l> v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
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
        US4 v14; US5 v15;
        Tuple0 tmp98 = v2.v[v4];
        v14 = tmp98.v0; v15 = tmp98.v1;
        f_60(v9, v14, v15);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_70(unsigned char * v0, unsigned char v1){
    unsigned char * v2;
    v2 = (unsigned char *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_69(unsigned char * v0, unsigned char v1){
    return f_70(v0, v1);
}
__device__ void f_68(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
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
        f_69(v6, v11);
        v3 += 1l ;
    }
    char * v12;
    v12 = (char *)(v0+5ull);
    v12[0l] = v2;
    return ;
}
__device__ void f_67(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
    return f_68(v0, v1, v2);
}
__device__ void f_66(unsigned char * v0, long v1, static_array<Tuple1,2l> v2, long v3){
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
        Tuple1 tmp99 = v2.v[v5];
        v15 = tmp99.v0; v16 = tmp99.v1;
        f_67(v10, v15, v16);
        v5 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+24ull);
    v17[0l] = v3;
    return ;
}
__device__ void f_57(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_58(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<Tuple0,5l,long> v4 = v1.v.case0.v0;
            return f_59(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_63(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US1 v8 = v1.v.case2.v1;
            return f_64(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<Tuple0,2l> v10 = v1.v.case3.v1;
            return f_65(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<Tuple1,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_66(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_71(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8208ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_74(unsigned char * v0, static_array<Tuple0,2l> v1){
    long v2;
    v2 = 0l;
    while (while_method_0(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
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
        US4 v11; US5 v12;
        Tuple0 tmp100 = v1.v[v2];
        v11 = tmp100.v0; v12 = tmp100.v1;
        f_60(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_75(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+68ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_76(unsigned char * v0, static_array<Tuple0,3l> v1){
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
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
        US4 v11; US5 v12;
        Tuple0 tmp101 = v1.v[v2];
        v11 = tmp101.v0; v12 = tmp101.v1;
        f_60(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_77(unsigned char * v0, static_array<Tuple0,5l> v1){
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
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
        US4 v11; US5 v12;
        Tuple0 tmp102 = v1.v[v2];
        v11 = tmp102.v0; v12 = tmp102.v1;
        f_60(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_78(unsigned char * v0, static_array<Tuple0,4l> v1){
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
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
        US4 v11; US5 v12;
        Tuple0 tmp103 = v1.v[v2];
        v11 = tmp103.v0; v12 = tmp103.v1;
        f_60(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_73(unsigned char * v0, long v1, static_array<static_array<Tuple0,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US8 v6){
    long * v7;
    v7 = (long *)(v0+0ull);
    v7[0l] = v1;
    long v8;
    v8 = 0l;
    while (while_method_0(v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 16ull;
        unsigned long long v12;
        v12 = 16ull + v11;
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
        static_array<Tuple0,2l> v18;
        v18 = v2.v[v8];
        f_74(v13, v18);
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
        v23 = 48ull + v22;
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
        f_58(v24, v29);
        v19 += 1l ;
    }
    long * v30;
    v30 = (long *)(v0+56ull);
    v30[0l] = v4;
    long v31;
    v31 = 0l;
    while (while_method_0(v31)){
        unsigned long long v33;
        v33 = (unsigned long long)v31;
        unsigned long long v34;
        v34 = v33 * 4ull;
        unsigned long long v35;
        v35 = 60ull + v34;
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
        f_58(v36, v41);
        v31 += 1l ;
    }
    long v42;
    v42 = v6.tag;
    f_75(v0, v42);
    unsigned char * v43;
    v43 = (unsigned char *)(v0+80ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v44 = v6.v.case0.v0;
            return f_76(v43, v44);
            break;
        }
        case 1: { // Preflop
            return f_61(v43);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v45 = v6.v.case2.v0;
            return f_77(v43, v45);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v46 = v6.v.case3.v0;
            return f_78(v43, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_80(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+128ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_79(unsigned char * v0, long v1, static_array<static_array<Tuple0,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US8 v6, US1 v7){
    long * v8;
    v8 = (long *)(v0+0ull);
    v8[0l] = v1;
    long v9;
    v9 = 0l;
    while (while_method_0(v9)){
        unsigned long long v11;
        v11 = (unsigned long long)v9;
        unsigned long long v12;
        v12 = v11 * 16ull;
        unsigned long long v13;
        v13 = 16ull + v12;
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
        static_array<Tuple0,2l> v19;
        v19 = v2.v[v9];
        f_74(v14, v19);
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
        v24 = 48ull + v23;
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
        f_58(v25, v30);
        v20 += 1l ;
    }
    long * v31;
    v31 = (long *)(v0+56ull);
    v31[0l] = v4;
    long v32;
    v32 = 0l;
    while (while_method_0(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 60ull + v35;
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
        f_58(v37, v42);
        v32 += 1l ;
    }
    long v43;
    v43 = v6.tag;
    f_75(v0, v43);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+80ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v45 = v6.v.case0.v0;
            f_76(v44, v45);
            break;
        }
        case 1: { // Preflop
            f_61(v44);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v46 = v6.v.case2.v0;
            f_77(v44, v46);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v47 = v6.v.case3.v0;
            f_78(v44, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v48;
    v48 = v7.tag;
    f_80(v0, v48);
    unsigned char * v49;
    v49 = (unsigned char *)(v0+132ull);
    switch (v7.tag) {
        case 0: { // A_All_In
            return f_61(v49);
            break;
        }
        case 1: { // A_Call
            return f_61(v49);
            break;
        }
        case 2: { // A_Fold
            return f_61(v49);
            break;
        }
        case 3: { // A_Raise
            long v50 = v7.v.case3.v0;
            return f_58(v49, v50);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_72(unsigned char * v0, US7 v1){
    long v2;
    v2 = v1.tag;
    f_58(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; static_array<static_array<Tuple0,2l>,2l> v5 = v1.v.case0.v1; static_array<long,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; US8 v9 = v1.v.case0.v5;
            return f_73(v3, v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: { // G_Fold
            long v10 = v1.v.case1.v0; static_array<static_array<Tuple0,2l>,2l> v11 = v1.v.case1.v1; static_array<long,2l> v12 = v1.v.case1.v2; long v13 = v1.v.case1.v3; static_array<long,2l> v14 = v1.v.case1.v4; US8 v15 = v1.v.case1.v5;
            return f_73(v3, v10, v11, v12, v13, v14, v15);
            break;
        }
        case 2: { // G_Preflop
            return f_61(v3);
            break;
        }
        case 3: { // G_River
            long v16 = v1.v.case3.v0; static_array<static_array<Tuple0,2l>,2l> v17 = v1.v.case3.v1; static_array<long,2l> v18 = v1.v.case3.v2; long v19 = v1.v.case3.v3; static_array<long,2l> v20 = v1.v.case3.v4; US8 v21 = v1.v.case3.v5;
            return f_73(v3, v16, v17, v18, v19, v20, v21);
            break;
        }
        case 4: { // G_Round
            long v22 = v1.v.case4.v0; static_array<static_array<Tuple0,2l>,2l> v23 = v1.v.case4.v1; static_array<long,2l> v24 = v1.v.case4.v2; long v25 = v1.v.case4.v3; static_array<long,2l> v26 = v1.v.case4.v4; US8 v27 = v1.v.case4.v5;
            return f_73(v3, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 5: { // G_Round'
            long v28 = v1.v.case5.v0; static_array<static_array<Tuple0,2l>,2l> v29 = v1.v.case5.v1; static_array<long,2l> v30 = v1.v.case5.v2; long v31 = v1.v.case5.v3; static_array<long,2l> v32 = v1.v.case5.v4; US8 v33 = v1.v.case5.v5; US1 v34 = v1.v.case5.v6;
            return f_79(v3, v28, v29, v30, v31, v32, v33, v34);
            break;
        }
        case 6: { // G_Showdown
            long v35 = v1.v.case6.v0; static_array<static_array<Tuple0,2l>,2l> v36 = v1.v.case6.v1; static_array<long,2l> v37 = v1.v.case6.v2; long v38 = v1.v.case6.v3; static_array<long,2l> v39 = v1.v.case6.v4; US8 v40 = v1.v.case6.v5;
            return f_73(v3, v35, v36, v37, v38, v39, v40);
            break;
        }
        case 7: { // G_Turn
            long v41 = v1.v.case7.v0; static_array<static_array<Tuple0,2l>,2l> v42 = v1.v.case7.v1; static_array<long,2l> v43 = v1.v.case7.v2; long v44 = v1.v.case7.v3; static_array<long,2l> v45 = v1.v.case7.v4; US8 v46 = v1.v.case7.v5;
            return f_73(v3, v41, v42, v43, v44, v45, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_81(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_58(v0, v2);
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
__device__ void f_82(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8392ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_54(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US6 v3, static_array<US2,2l> v4, US9 v5){
    f_55(v0, v1);
    long v6;
    v6 = v2.length;
    f_56(v0, v6);
    long v7;
    v7 = v2.length;
    long v8;
    v8 = 0l;
    while (while_method_1(v7, v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 64ull;
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
        f_57(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_71(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+8224ull);
    switch (v3.tag) {
        case 0: { // None
            f_61(v21);
            break;
        }
        case 1: { // Some
            US7 v22 = v3.v.case1.v0;
            f_72(v21, v22);
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
        v27 = 8384ull + v26;
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
        f_81(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_82(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+8400ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_61(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; static_array<static_array<Tuple0,2l>,2l> v37 = v5.v.case1.v1; static_array<long,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; US8 v41 = v5.v.case1.v5;
            return f_73(v35, v36, v37, v38, v39, v40, v41);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v42 = v5.v.case2.v0; static_array<static_array<Tuple0,2l>,2l> v43 = v5.v.case2.v1; static_array<long,2l> v44 = v5.v.case2.v2; long v45 = v5.v.case2.v3; static_array<long,2l> v46 = v5.v.case2.v4; US8 v47 = v5.v.case2.v5;
            return f_73(v35, v42, v43, v44, v45, v46, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_84(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8216ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_83(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US9 v3){
    long v4;
    v4 = v1.length;
    f_58(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_1(v5, v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 64ull;
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
        f_57(v11, v17);
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
        v22 = 8208ull + v21;
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
        f_81(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_84(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+8224ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_61(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; static_array<static_array<Tuple0,2l>,2l> v32 = v3.v.case1.v1; static_array<long,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; US8 v36 = v3.v.case1.v5;
            return f_73(v30, v31, v32, v33, v34, v35, v36);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v37 = v3.v.case2.v0; static_array<static_array<Tuple0,2l>,2l> v38 = v3.v.case2.v1; static_array<long,2l> v39 = v3.v.case2.v2; long v40 = v3.v.case2.v3; static_array<long,2l> v41 = v3.v.case2.v4; US8 v42 = v3.v.case2.v5;
            return f_73(v30, v37, v38, v39, v40, v41, v42);
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
        unsigned long long v9; static_array_list<US3,128l,long> v10; US6 v11; static_array<US2,2l> v12; US9 v13;
        Tuple2 tmp21 = f_6(v0);
        v9 = tmp21.v0; v10 = tmp21.v1; v11 = tmp21.v2; v12 = tmp21.v3; v13 = tmp21.v4;
        unsigned long long & v14 = v9;
        static_array_list<US3,128l,long> & v15 = v10;
        unsigned long long v16;
        v16 = clock64();
        long v17;
        v17 = threadIdx.x;
        long v18;
        v18 = blockIdx.x;
        long v19;
        v19 = v18 * 512l;
        long v20;
        v20 = v17 + v19;
        unsigned long long v21;
        v21 = (unsigned long long)v20;
        curandStatePhilox4_32_10_t v22;
        curand_init(v16,v21,0ull,&v22);
        US6 v64; static_array<US2,2l> v65; US9 v66;
        switch (v8.tag) {
            case 0: { // ActionSelected
                US1 v34 = v8.v.case0.v0;
                switch (v11.tag) {
                    case 0: { // None
                        v64 = v11; v65 = v12; v66 = v13;
                        break;
                    }
                    case 1: { // Some
                        US7 v35 = v11.v.case1.v0;
                        switch (v35.tag) {
                            case 4: { // G_Round
                                long v36 = v35.v.case4.v0; static_array<static_array<Tuple0,2l>,2l> v37 = v35.v.case4.v1; static_array<long,2l> v38 = v35.v.case4.v2; long v39 = v35.v.case4.v3; static_array<long,2l> v40 = v35.v.case4.v4; US8 v41 = v35.v.case4.v5;
                                US7 v42;
                                v42 = US7_5(v36, v37, v38, v39, v40, v41, v34);
                                Tuple9 tmp95 = play_loop_32(v11, v12, v13, v14, v15, v22, v42);
                                v64 = tmp95.v0; v65 = tmp95.v1; v66 = tmp95.v2;
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
                static_array<US2,2l> v33 = v8.v.case1.v0;
                v64 = v11; v65 = v33; v66 = v13;
                break;
            }
            case 2: { // StartGame
                static_array<US2,2l> v23;
                US2 v24;
                v24 = US2_0();
                v23.v[0l] = v24;
                US2 v25;
                v25 = US2_1();
                v23.v[1l] = v25;
                static_array_list<US3,128l,long> v26;
                v26.length = 0;
                v14 = 4503599627370495ull;
                v15 = v26;
                US6 v27;
                v27 = US6_0();
                US9 v28;
                v28 = US9_0();
                US7 v29;
                v29 = US7_2();
                Tuple9 tmp96 = play_loop_32(v27, v23, v28, v14, v15, v22, v29);
                v64 = tmp96.v0; v65 = tmp96.v1; v66 = tmp96.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        f_54(v0, v9, v10, v64, v65, v66);
        return f_83(v2, v10, v65, v66);
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

import time
options = []
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
class US0_0(NamedTuple): # Computer
    tag = 0
class US0_1(NamedTuple): # Human
    tag = 1
US0 = Union[US0_0, US0_1]
class US2_0(NamedTuple): # A_All_In
    tag = 0
class US2_1(NamedTuple): # A_Call
    tag = 1
class US2_2(NamedTuple): # A_Fold
    tag = 2
class US2_3(NamedTuple): # A_Raise
    v0 : i32
    tag = 3
US2 = Union[US2_0, US2_1, US2_2, US2_3]
class US1_0(NamedTuple): # ActionSelected
    v0 : US2
    tag = 0
class US1_1(NamedTuple): # PlayerChanged
    v0 : static_array
    tag = 1
class US1_2(NamedTuple): # StartGame
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
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
    v6 : US2
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
    v1 : US2
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
class US8_0(NamedTuple): # Ace
    tag = 0
class US8_1(NamedTuple): # Eight
    tag = 1
class US8_2(NamedTuple): # Five
    tag = 2
class US8_3(NamedTuple): # Four
    tag = 3
class US8_4(NamedTuple): # Jack
    tag = 4
class US8_5(NamedTuple): # King
    tag = 5
class US8_6(NamedTuple): # Nine
    tag = 6
class US8_7(NamedTuple): # Queen
    tag = 7
class US8_8(NamedTuple): # Seven
    tag = 8
class US8_9(NamedTuple): # Six
    tag = 9
class US8_10(NamedTuple): # Ten
    tag = 10
class US8_11(NamedTuple): # Three
    tag = 11
class US8_12(NamedTuple): # Two
    tag = 12
US8 = Union[US8_0, US8_1, US8_2, US8_3, US8_4, US8_5, US8_6, US8_7, US8_8, US8_9, US8_10, US8_11, US8_12]
class US9_0(NamedTuple): # Clubs
    tag = 0
class US9_1(NamedTuple): # Diamonds
    tag = 1
class US9_2(NamedTuple): # Hearts
    tag = 2
class US9_3(NamedTuple): # Spades
    tag = 3
US9 = Union[US9_0, US9_1, US9_2, US9_3]
def method1(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[0:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method3(v0 : cp.ndarray) -> None:
    del v0
    return 
def method2(v0 : cp.ndarray, v1 : US2) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US2_0(): # A_All_In
            del v1
            return method3(v3)
        case US2_1(): # A_Call
            del v1
            return method3(v3)
        case US2_2(): # A_Fold
            del v1
            return method3(v3)
        case US2_3(v4): # A_Raise
            del v1
            return method1(v3, v4)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method5(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method6(v0 : cp.ndarray, v1 : US0) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[4:].view(cp.uint8)
    del v0
    match v1:
        case US0_0(): # Computer
            del v1
            return method3(v3)
        case US0_1(): # Human
            del v1
            return method3(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method4(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method5(v2):
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
        method6(v6, v12)
        del v6, v12
        v2 += 1 
    del v0, v1, v2
    return 
def method0(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[8:].view(cp.uint8)
    del v0
    match v1:
        case US1_0(v4): # ActionSelected
            del v1
            return method2(v3, v4)
        case US1_1(v5): # PlayerChanged
            del v1
            return method4(v3, v5)
        case US1_2(): # StartGame
            del v1
            return method3(v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method8(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[0:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method9(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method10(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method14(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method13(v0 : cp.ndarray, v1 : US8, v2 : US9) -> None:
    v3 = v1.tag
    method1(v0, v3)
    del v3
    v4 = v0[4:].view(cp.uint8)
    match v1:
        case US8_0(): # Ace
            method3(v4)
        case US8_1(): # Eight
            method3(v4)
        case US8_2(): # Five
            method3(v4)
        case US8_3(): # Four
            method3(v4)
        case US8_4(): # Jack
            method3(v4)
        case US8_5(): # King
            method3(v4)
        case US8_6(): # Nine
            method3(v4)
        case US8_7(): # Queen
            method3(v4)
        case US8_8(): # Seven
            method3(v4)
        case US8_9(): # Six
            method3(v4)
        case US8_10(): # Ten
            method3(v4)
        case US8_11(): # Three
            method3(v4)
        case US8_12(): # Two
            method3(v4)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1, v4
    v5 = v2.tag
    method14(v0, v5)
    del v5
    v6 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US9_0(): # Clubs
            del v2
            return method3(v6)
        case US9_1(): # Diamonds
            del v2
            return method3(v6)
        case US9_2(): # Hearts
            del v2
            return method3(v6)
        case US9_3(): # Spades
            del v2
            return method3(v6)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method12(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method1(v0, v2)
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
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
            v15 = "The read index needs to be in range for the static array list."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v16, v17 = v1[v4]
        method13(v9, v16, v17)
        del v9, v16, v17
        v4 += 1 
    del v0, v1, v3, v4
    return 
def method15(v0 : cp.ndarray, v1 : i32, v2 : i32) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v0[4:].view(cp.int32)
    del v0
    v4[0] = v2
    del v2, v4
    return 
def method16(v0 : cp.ndarray, v1 : i32, v2 : US2) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method14(v0, v4)
    del v4
    v5 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US2_0(): # A_All_In
            del v2
            return method3(v5)
        case US2_1(): # A_Call
            del v2
            return method3(v5)
        case US2_2(): # A_Fold
            del v2
            return method3(v5)
        case US2_3(v6): # A_Raise
            del v2
            return method1(v5, v6)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method17(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
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
        v15, v16 = v2[v4]
        method13(v9, v15, v16)
        del v9, v15, v16
        v4 += 1 
    del v0, v2, v4
    return 
def method21(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method23(v0 : cp.ndarray, v1 : u8) -> None:
    v2 = v0[0:].view(cp.uint8)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method22(v0 : cp.ndarray, v1 : u8) -> None:
    return method23(v0, v1)
def method20(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    v3 = 0
    while method21(v3):
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
        method22(v6, v12)
        del v6, v12
        v3 += 1 
    del v1, v3
    v13 = v0[5:].view(cp.int8)
    del v0
    v13[0] = v2
    del v2, v13
    return 
def method19(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    return method20(v0, v1, v2)
def method18(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
    v4 = v0[0:].view(cp.int32)
    v4[0] = v1
    del v1, v4
    v5 = 0
    while method5(v5):
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
        method19(v10, v16, v17)
        del v10, v16, v17
        v5 += 1 
    del v2, v5
    v18 = v0[24:].view(cp.int32)
    del v0
    v18[0] = v3
    del v3, v18
    return 
def method11(v0 : cp.ndarray, v1 : US7) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US7_0(v4): # CommunityCardsAre
            del v1
            return method12(v3, v4)
        case US7_1(v5, v6): # Fold
            del v1
            return method15(v3, v5, v6)
        case US7_2(v7, v8): # PlayerAction
            del v1
            return method16(v3, v7, v8)
        case US7_3(v9, v10): # PlayerGotCards
            del v1
            return method17(v3, v9, v10)
        case US7_4(v11, v12, v13): # Showdown
            del v1
            return method18(v3, v11, v12, v13)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method24(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8208:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method27(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method5(v2):
        v4 = u64(v2)
        v5 = v4 * 8
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
        v12, v13 = v1[v2]
        method13(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method28(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[68:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method30(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method29(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method30(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
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
        v12, v13 = v1[v2]
        method13(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method31(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method21(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
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
        v12, v13 = v1[v2]
        method13(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method33(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method32(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method33(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
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
        v12, v13 = v1[v2]
        method13(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method26(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5) -> None:
    v7 = v0[0:].view(cp.int32)
    v7[0] = v1
    del v1, v7
    v8 = 0
    while method5(v8):
        v10 = u64(v8)
        v11 = v10 * 16
        del v10
        v12 = 16 + v11
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
        method27(v13, v19)
        del v13, v19
        v8 += 1 
    del v2, v8
    v20 = 0
    while method5(v20):
        v22 = u64(v20)
        v23 = v22 * 4
        del v22
        v24 = 48 + v23
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
        method1(v25, v31)
        del v25, v31
        v20 += 1 
    del v3, v20
    v32 = v0[56:].view(cp.int32)
    v32[0] = v4
    del v4, v32
    v33 = 0
    while method5(v33):
        v35 = u64(v33)
        v36 = v35 * 4
        del v35
        v37 = 60 + v36
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
        method1(v38, v44)
        del v38, v44
        v33 += 1 
    del v5, v33
    v45 = v6.tag
    method28(v0, v45)
    del v45
    v46 = v0[80:].view(cp.uint8)
    del v0
    match v6:
        case US5_0(v47): # Flop
            del v6
            return method29(v46, v47)
        case US5_1(): # Preflop
            del v6
            return method3(v46)
        case US5_2(v48): # River
            del v6
            return method31(v46, v48)
        case US5_3(v49): # Turn
            del v6
            return method32(v46, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method35(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[128:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method34(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5, v7 : US2) -> None:
    v8 = v0[0:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = 0
    while method5(v9):
        v11 = u64(v9)
        v12 = v11 * 16
        del v11
        v13 = 16 + v12
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
        method27(v14, v20)
        del v14, v20
        v9 += 1 
    del v2, v9
    v21 = 0
    while method5(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 48 + v24
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
        method1(v26, v32)
        del v26, v32
        v21 += 1 
    del v3, v21
    v33 = v0[56:].view(cp.int32)
    v33[0] = v4
    del v4, v33
    v34 = 0
    while method5(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 60 + v37
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
        method1(v39, v45)
        del v39, v45
        v34 += 1 
    del v5, v34
    v46 = v6.tag
    method28(v0, v46)
    del v46
    v47 = v0[80:].view(cp.uint8)
    match v6:
        case US5_0(v48): # Flop
            method29(v47, v48)
        case US5_1(): # Preflop
            method3(v47)
        case US5_2(v49): # River
            method31(v47, v49)
        case US5_3(v50): # Turn
            method32(v47, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v6, v47
    v51 = v7.tag
    method35(v0, v51)
    del v51
    v52 = v0[132:].view(cp.uint8)
    del v0
    match v7:
        case US2_0(): # A_All_In
            del v7
            return method3(v52)
        case US2_1(): # A_Call
            del v7
            return method3(v52)
        case US2_2(): # A_Fold
            del v7
            return method3(v52)
        case US2_3(v53): # A_Raise
            del v7
            return method1(v52, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method25(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method26(v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v1
            return method26(v3, v10, v11, v12, v13, v14, v15)
        case US4_2(): # G_Preflop
            del v1
            return method3(v3)
        case US4_3(v16, v17, v18, v19, v20, v21): # G_River
            del v1
            return method26(v3, v16, v17, v18, v19, v20, v21)
        case US4_4(v22, v23, v24, v25, v26, v27): # G_Round
            del v1
            return method26(v3, v22, v23, v24, v25, v26, v27)
        case US4_5(v28, v29, v30, v31, v32, v33, v34): # G_Round'
            del v1
            return method34(v3, v28, v29, v30, v31, v32, v33, v34)
        case US4_6(v35, v36, v37, v38, v39, v40): # G_Showdown
            del v1
            return method26(v3, v35, v36, v37, v38, v39, v40)
        case US4_7(v41, v42, v43, v44, v45, v46): # G_Turn
            del v1
            return method26(v3, v41, v42, v43, v44, v45, v46)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method36(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8392:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method7(v0 : cp.ndarray, v1 : u64, v2 : static_array_list, v3 : US3, v4 : static_array, v5 : US6) -> None:
    method8(v0, v1)
    del v1
    v6 = v2.length
    method9(v0, v6)
    del v6
    v7 = v2.length
    v8 = 0
    while method10(v7, v8):
        v10 = u64(v8)
        v11 = v10 * 64
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
        method11(v13, v20)
        del v13, v20
        v8 += 1 
    del v2, v7, v8
    v21 = v3.tag
    method24(v0, v21)
    del v21
    v22 = v0[8224:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method3(v22)
        case US3_1(v23): # Some
            method25(v22, v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v22
    v24 = 0
    while method5(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 8384 + v27
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
        method6(v29, v35)
        del v29, v35
        v24 += 1 
    del v4, v24
    v36 = v5.tag
    method36(v0, v36)
    del v36
    v37 = v0[8400:].view(cp.uint8)
    del v0
    match v5:
        case US6_0(): # GameNotStarted
            del v5
            return method3(v37)
        case US6_1(v38, v39, v40, v41, v42, v43): # GameOver
            del v5
            return method26(v37, v38, v39, v40, v41, v42, v43)
        case US6_2(v44, v45, v46, v47, v48, v49): # WaitingForActionFromPlayerId
            del v5
            return method26(v37, v44, v45, v46, v47, v48, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method37(v0 : string) -> None:
    print(v0, end="")
    del v0
    return 
def method38(v0 : f64) -> None:
    print("{:.6f}".format(v0), end="")
    del v0
    return 
def method40(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method41(v0 : cp.ndarray) -> i32:
    v1 = v0[8:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method43(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method46(v0 : cp.ndarray) -> None:
    del v0
    return 
def method47(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method45(v0 : cp.ndarray) -> Tuple[US8, US9]:
    v1 = method43(v0)
    v2 = v0[4:].view(cp.uint8)
    if v1 == 0:
        method46(v2)
        v17 = US8_0()
    elif v1 == 1:
        method46(v2)
        v17 = US8_1()
    elif v1 == 2:
        method46(v2)
        v17 = US8_2()
    elif v1 == 3:
        method46(v2)
        v17 = US8_3()
    elif v1 == 4:
        method46(v2)
        v17 = US8_4()
    elif v1 == 5:
        method46(v2)
        v17 = US8_5()
    elif v1 == 6:
        method46(v2)
        v17 = US8_6()
    elif v1 == 7:
        method46(v2)
        v17 = US8_7()
    elif v1 == 8:
        method46(v2)
        v17 = US8_8()
    elif v1 == 9:
        method46(v2)
        v17 = US8_9()
    elif v1 == 10:
        method46(v2)
        v17 = US8_10()
    elif v1 == 11:
        method46(v2)
        v17 = US8_11()
    elif v1 == 12:
        method46(v2)
        v17 = US8_12()
    else:
        raise Exception("Invalid tag.")
    del v1, v2
    v18 = method47(v0)
    v19 = v0[8:].view(cp.uint8)
    del v0
    if v18 == 0:
        method46(v19)
        v25 = US9_0()
    elif v18 == 1:
        method46(v19)
        v25 = US9_1()
    elif v18 == 2:
        method46(v19)
        v25 = US9_2()
    elif v18 == 3:
        method46(v19)
        v25 = US9_3()
    else:
        raise Exception("Invalid tag.")
    del v18, v19
    return v17, v25
def method44(v0 : cp.ndarray) -> static_array_list:
    v1 = static_array_list(5)
    v2 = method43(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method45(v9)
        del v9
        v12 = 0 <= v4
        if v12:
            v13 = v1.length
            v14 = v4 < v13
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
        v1[v4] = (v10, v11)
        del v10, v11
        v4 += 1 
    del v0, v3, v4
    return v1
def method48(v0 : cp.ndarray) -> Tuple[i32, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.int32)
    del v0
    v4 = v3[0].item()
    del v3
    return v2, v4
def method49(v0 : cp.ndarray) -> Tuple[i32, US2]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method47(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method46(v4)
        v11 = US2_0()
    elif v3 == 1:
        method46(v4)
        v11 = US2_1()
    elif v3 == 2:
        method46(v4)
        v11 = US2_2()
    elif v3 == 3:
        v9 = method43(v4)
        v11 = US2_3(v9)
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v11
def method50(v0 : cp.ndarray) -> Tuple[i32, static_array]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method45(v9)
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
    del v0, v4
    return v2, v3
def method55(v0 : cp.ndarray) -> u8:
    v1 = v0[0:].view(cp.uint8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method54(v0 : cp.ndarray) -> u8:
    v1 = method55(v0)
    del v0
    return v1
def method53(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1 = static_array(5)
    v2 = 0
    while method21(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method54(v5)
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
def method52(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1, v2 = method53(v0)
    del v0
    return v1, v2
def method51(v0 : cp.ndarray) -> Tuple[i32, static_array, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method52(v9)
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
def method42(v0 : cp.ndarray) -> US7:
    v1 = method43(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method44(v2)
        del v2
        return US7_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method48(v2)
        del v2
        return US7_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method49(v2)
        del v2
        return US7_2(v9, v10)
    elif v1 == 3:
        del v1
        v12, v13 = method50(v2)
        del v2
        return US7_3(v12, v13)
    elif v1 == 4:
        del v1
        v15, v16, v17 = method51(v2)
        del v2
        return US7_4(v15, v16, v17)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method56(v0 : cp.ndarray) -> i32:
    v1 = v0[8208:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method59(v0 : cp.ndarray) -> static_array:
    v1 = static_array(2)
    v2 = 0
    while method5(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method45(v6)
        del v6
        v9 = 0 <= v2
        if v9:
            v10 = v2 < 2
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
        v1[v2] = (v7, v8)
        del v7, v8
        v2 += 1 
    del v0, v2
    return v1
def method60(v0 : cp.ndarray) -> i32:
    v1 = v0[68:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method61(v0 : cp.ndarray) -> static_array:
    v1 = static_array(3)
    v2 = 0
    while method30(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method45(v6)
        del v6
        v9 = 0 <= v2
        if v9:
            v10 = v2 < 3
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
        v1[v2] = (v7, v8)
        del v7, v8
        v2 += 1 
    del v0, v2
    return v1
def method62(v0 : cp.ndarray) -> static_array:
    v1 = static_array(5)
    v2 = 0
    while method21(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method45(v6)
        del v6
        v9 = 0 <= v2
        if v9:
            v10 = v2 < 5
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
        v1[v2] = (v7, v8)
        del v7, v8
        v2 += 1 
    del v0, v2
    return v1
def method63(v0 : cp.ndarray) -> static_array:
    v1 = static_array(4)
    v2 = 0
    while method33(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method45(v6)
        del v6
        v9 = 0 <= v2
        if v9:
            v10 = v2 < 4
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
        v1[v2] = (v7, v8)
        del v7, v8
        v2 += 1 
    del v0, v2
    return v1
def method58(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 16
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method59(v9)
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
    while method5(v17):
        v19 = u64(v17)
        v20 = v19 * 4
        del v19
        v21 = 48 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method43(v22)
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
    v29 = v0[56:].view(cp.int32)
    v30 = v29[0].item()
    del v29
    v31 = static_array(2)
    v32 = 0
    while method5(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 60 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method43(v37)
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
    v44 = method60(v0)
    v45 = v0[80:].view(cp.uint8)
    del v0
    if v44 == 0:
        v47 = method61(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method46(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method62(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method63(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    return v2, v3, v16, v30, v31, v54
def method65(v0 : cp.ndarray) -> i32:
    v1 = v0[128:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method64(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5, US2]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 16
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method59(v9)
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
    while method5(v17):
        v19 = u64(v17)
        v20 = v19 * 4
        del v19
        v21 = 48 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method43(v22)
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
    v29 = v0[56:].view(cp.int32)
    v30 = v29[0].item()
    del v29
    v31 = static_array(2)
    v32 = 0
    while method5(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 60 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method43(v37)
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
    v44 = method60(v0)
    v45 = v0[80:].view(cp.uint8)
    if v44 == 0:
        v47 = method61(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method46(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method62(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method63(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    v55 = method65(v0)
    v56 = v0[132:].view(cp.uint8)
    del v0
    if v55 == 0:
        method46(v56)
        v63 = US2_0()
    elif v55 == 1:
        method46(v56)
        v63 = US2_1()
    elif v55 == 2:
        method46(v56)
        v63 = US2_2()
    elif v55 == 3:
        v61 = method43(v56)
        v63 = US2_3(v61)
    else:
        raise Exception("Invalid tag.")
    del v55, v56
    return v2, v3, v16, v30, v31, v54, v63
def method57(v0 : cp.ndarray) -> US4:
    v1 = method43(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9 = method58(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9)
    elif v1 == 1:
        del v1
        v11, v12, v13, v14, v15, v16 = method58(v2)
        del v2
        return US4_1(v11, v12, v13, v14, v15, v16)
    elif v1 == 2:
        del v1
        method46(v2)
        del v2
        return US4_2()
    elif v1 == 3:
        del v1
        v19, v20, v21, v22, v23, v24 = method58(v2)
        del v2
        return US4_3(v19, v20, v21, v22, v23, v24)
    elif v1 == 4:
        del v1
        v26, v27, v28, v29, v30, v31 = method58(v2)
        del v2
        return US4_4(v26, v27, v28, v29, v30, v31)
    elif v1 == 5:
        del v1
        v33, v34, v35, v36, v37, v38, v39 = method64(v2)
        del v2
        return US4_5(v33, v34, v35, v36, v37, v38, v39)
    elif v1 == 6:
        del v1
        v41, v42, v43, v44, v45, v46 = method58(v2)
        del v2
        return US4_6(v41, v42, v43, v44, v45, v46)
    elif v1 == 7:
        del v1
        v48, v49, v50, v51, v52, v53 = method58(v2)
        del v2
        return US4_7(v48, v49, v50, v51, v52, v53)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method66(v0 : cp.ndarray) -> US0:
    v1 = method43(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method46(v2)
        del v2
        return US0_0()
    elif v1 == 1:
        del v1
        method46(v2)
        del v2
        return US0_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method67(v0 : cp.ndarray) -> i32:
    v1 = v0[8392:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method39(v0 : cp.ndarray) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = method40(v0)
    v2 = static_array_list(128)
    v3 = method41(v0)
    v2.length = v3
    del v3
    v4 = v2.length
    v5 = 0
    while method10(v4, v5):
        v7 = u64(v5)
        v8 = v7 * 64
        del v7
        v9 = 16 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = method42(v10)
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
    v18 = method56(v0)
    v19 = v0[8224:].view(cp.uint8)
    if v18 == 0:
        method46(v19)
        v24 = US3_0()
    elif v18 == 1:
        v22 = method57(v19)
        v24 = US3_1(v22)
    else:
        raise Exception("Invalid tag.")
    del v18, v19
    v25 = static_array(2)
    v26 = 0
    while method5(v26):
        v28 = u64(v26)
        v29 = v28 * 4
        del v28
        v30 = 8384 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method66(v31)
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
    v38 = method67(v0)
    v39 = v0[8400:].view(cp.uint8)
    del v0
    if v38 == 0:
        method46(v39)
        v56 = US6_0()
    elif v38 == 1:
        v42, v43, v44, v45, v46, v47 = method58(v39)
        v56 = US6_1(v42, v43, v44, v45, v46, v47)
    elif v38 == 2:
        v49, v50, v51, v52, v53, v54 = method58(v39)
        v56 = US6_2(v49, v50, v51, v52, v53, v54)
    else:
        raise Exception("Invalid tag.")
    del v38, v39
    return v1, v2, v24, v25, v56
def method69(v0 : cp.ndarray) -> i32:
    v1 = v0[8216:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method68(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US6]:
    v1 = static_array_list(128)
    v2 = method43(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 64
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method42(v9)
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
    while method5(v18):
        v20 = u64(v18)
        v21 = v20 * 4
        del v20
        v22 = 8208 + v21
        del v21
        v23 = v0[v22:].view(cp.uint8)
        del v22
        v24 = method66(v23)
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
    v30 = method69(v0)
    v31 = v0[8224:].view(cp.uint8)
    del v0
    if v30 == 0:
        method46(v31)
        v48 = US6_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39 = method58(v31)
        v48 = US6_1(v34, v35, v36, v37, v38, v39)
    elif v30 == 2:
        v41, v42, v43, v44, v45, v46 = method58(v31)
        v48 = US6_2(v41, v42, v43, v44, v45, v46)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v48
def method75(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method74(v0 : u64) -> object:
    return method75(v0)
def method81() -> object:
    v0 = []
    return v0
def method80(v0 : US8) -> object:
    match v0:
        case US8_0(): # Ace
            del v0
            v1 = method81()
            v2 = "Ace"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US8_1(): # Eight
            del v0
            v4 = method81()
            v5 = "Eight"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US8_2(): # Five
            del v0
            v7 = method81()
            v8 = "Five"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US8_3(): # Four
            del v0
            v10 = method81()
            v11 = "Four"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US8_4(): # Jack
            del v0
            v13 = method81()
            v14 = "Jack"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case US8_5(): # King
            del v0
            v16 = method81()
            v17 = "King"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US8_6(): # Nine
            del v0
            v19 = method81()
            v20 = "Nine"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US8_7(): # Queen
            del v0
            v22 = method81()
            v23 = "Queen"
            v24 = [v23,v22]
            del v22, v23
            return v24
        case US8_8(): # Seven
            del v0
            v25 = method81()
            v26 = "Seven"
            v27 = [v26,v25]
            del v25, v26
            return v27
        case US8_9(): # Six
            del v0
            v28 = method81()
            v29 = "Six"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US8_10(): # Ten
            del v0
            v31 = method81()
            v32 = "Ten"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US8_11(): # Three
            del v0
            v34 = method81()
            v35 = "Three"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US8_12(): # Two
            del v0
            v37 = method81()
            v38 = "Two"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method82(v0 : US9) -> object:
    match v0:
        case US9_0(): # Clubs
            del v0
            v1 = method81()
            v2 = "Clubs"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US9_1(): # Diamonds
            del v0
            v4 = method81()
            v5 = "Diamonds"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US9_2(): # Hearts
            del v0
            v7 = method81()
            v8 = "Hearts"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US9_3(): # Spades
            del v0
            v10 = method81()
            v11 = "Spades"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method79(v0 : US8, v1 : US9) -> object:
    v2 = []
    v3 = method80(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method82(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method78(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method10(v2, v3):
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
        v11, v12 = v0[v3]
        v13 = method79(v11, v12)
        del v11, v12
        v1.append(v13)
        del v13
        v3 += 1 
    del v0, v2, v3
    return v1
def method84(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method83(v0 : i32, v1 : i32) -> object:
    v2 = method84(v0)
    del v0
    v3 = method84(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method86(v0 : US2) -> object:
    match v0:
        case US2_0(): # A_All_In
            del v0
            v1 = method81()
            v2 = "A_All_In"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # A_Call
            del v0
            v4 = method81()
            v5 = "A_Call"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US2_2(): # A_Fold
            del v0
            v7 = method81()
            v8 = "A_Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US2_3(v10): # A_Raise
            del v0
            v11 = method84(v10)
            del v10
            v12 = "A_Raise"
            v13 = [v12,v11]
            del v11, v12
            return v13
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method85(v0 : i32, v1 : US2) -> object:
    v2 = []
    v3 = method84(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method86(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method88(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method5(v2):
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
        v11 = method79(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method87(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method84(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method88(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method95(v0 : u8) -> object:
    v1 = v0
    del v0
    return v1
def method94(v0 : u8) -> object:
    return method95(v0)
def method93(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method21(v2):
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
        v10 = method94(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method96(v0 : i8) -> object:
    v1 = v0
    del v0
    return v1
def method92(v0 : static_array, v1 : i8) -> object:
    v2 = method93(v0)
    del v0
    v3 = method96(v1)
    del v1
    v4 = {'hand': v2, 'score': v3}
    del v2, v3
    return v4
def method91(v0 : static_array, v1 : i8) -> object:
    return method92(v0, v1)
def method90(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method5(v2):
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
        v11 = method91(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method89(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method84(v0)
    del v0
    v4 = method90(v1)
    del v1
    v5 = method84(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method77(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method78(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method83(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method85(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method87(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method89(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method76(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method10(v2, v3):
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
        v12 = method77(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method73(v0 : u64, v1 : static_array_list) -> object:
    v2 = method74(v0)
    del v0
    v3 = method76(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method101(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method5(v2):
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
        v10 = method88(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method102(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method5(v2):
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
        v10 = method84(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method104(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method30(v2):
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
        v9, v10 = v0[v2]
        v11 = method79(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method105(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method21(v2):
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
        v9, v10 = v0[v2]
        v11 = method79(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method106(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method33(v2):
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
        v9, v10 = v0[v2]
        v11 = method79(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method103(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method104(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method81()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method105(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method106(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method100(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5) -> object:
    v6 = method84(v0)
    del v0
    v7 = method101(v1)
    del v1
    v8 = method102(v2)
    del v2
    v9 = method84(v3)
    del v3
    v10 = method102(v4)
    del v4
    v11 = method103(v5)
    del v5
    v12 = {'min_raise': v6, 'pl_card': v7, 'pot': v8, 'round_turn': v9, 'stack': v10, 'street': v11}
    del v6, v7, v8, v9, v10, v11
    return v12
def method107(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5, v6 : US2) -> object:
    v7 = []
    v8 = method100(v0, v1, v2, v3, v4, v5)
    del v0, v1, v2, v3, v4, v5
    v7.append(v8)
    del v8
    v9 = method86(v6)
    del v6
    v7.append(v9)
    del v9
    v10 = v7
    del v7
    return v10
def method99(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # G_Flop
            del v0
            v7 = method100(v1, v2, v3, v4, v5, v6)
            del v1, v2, v3, v4, v5, v6
            v8 = "G_Flop"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v0
            v16 = method100(v10, v11, v12, v13, v14, v15)
            del v10, v11, v12, v13, v14, v15
            v17 = "G_Fold"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US4_2(): # G_Preflop
            del v0
            v19 = method81()
            v20 = "G_Preflop"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US4_3(v22, v23, v24, v25, v26, v27): # G_River
            del v0
            v28 = method100(v22, v23, v24, v25, v26, v27)
            del v22, v23, v24, v25, v26, v27
            v29 = "G_River"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US4_4(v31, v32, v33, v34, v35, v36): # G_Round
            del v0
            v37 = method100(v31, v32, v33, v34, v35, v36)
            del v31, v32, v33, v34, v35, v36
            v38 = "G_Round"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case US4_5(v40, v41, v42, v43, v44, v45, v46): # G_Round'
            del v0
            v47 = method107(v40, v41, v42, v43, v44, v45, v46)
            del v40, v41, v42, v43, v44, v45, v46
            v48 = "G_Round'"
            v49 = [v48,v47]
            del v47, v48
            return v49
        case US4_6(v50, v51, v52, v53, v54, v55): # G_Showdown
            del v0
            v56 = method100(v50, v51, v52, v53, v54, v55)
            del v50, v51, v52, v53, v54, v55
            v57 = "G_Showdown"
            v58 = [v57,v56]
            del v56, v57
            return v58
        case US4_7(v59, v60, v61, v62, v63, v64): # G_Turn
            del v0
            v65 = method100(v59, v60, v61, v62, v63, v64)
            del v59, v60, v61, v62, v63, v64
            v66 = "G_Turn"
            v67 = [v66,v65]
            del v65, v66
            return v67
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method98(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method81()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method99(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method109(v0 : US0) -> object:
    match v0:
        case US0_0(): # Computer
            del v0
            v1 = method81()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US0_1(): # Human
            del v0
            v4 = method81()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method108(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method5(v2):
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
        v10 = method109(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method110(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method81()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method100(v4, v5, v6, v7, v8, v9)
            del v4, v5, v6, v7, v8, v9
            v11 = "GameOver"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US6_2(v13, v14, v15, v16, v17, v18): # WaitingForActionFromPlayerId
            del v0
            v19 = method100(v13, v14, v15, v16, v17, v18)
            del v13, v14, v15, v16, v17, v18
            v20 = "WaitingForActionFromPlayerId"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method97(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method98(v0)
    del v0
    v4 = method108(v1)
    del v1
    v5 = method110(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method72(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method73(v0, v1)
    del v0, v1
    v6 = method97(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method111(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method76(v0)
    del v0
    v4 = method108(v1)
    del v1
    v5 = method110(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method71(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method72(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method111(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method70(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method71(v0, v1, v2, v3, v4, v5, v6, v7)
    del v0, v1, v2, v3, v4, v5, v6, v7
    return v8
def main():
    v0 = static_array(2)
    v1 = US0_0()
    v0[0] = v1
    del v1
    v2 = US0_1()
    v0[1] = v2
    del v2
    v3 = static_array_list(128)
    v4 = US1_2()
    v5 = 4503599627370495
    v6 = US3_0()
    v7 = US6_0()
    v8 = cp.empty(16,dtype=cp.uint8)
    v9 = cp.empty(8528,dtype=cp.uint8)
    v10 = cp.empty(8352,dtype=cp.uint8)
    method0(v8, v4)
    del v4
    method7(v9, v5, v3, v6, v0, v7)
    del v0, v3, v5, v6, v7
    v11 = "Going to run the kernel."
    method37(v11)
    del v11
    print()
    v12 = time.perf_counter()
    v13 = 0
    v14 = raw_module.get_function(f"entry{v13}")
    del v13
    v14.max_dynamic_shared_size_bytes = 0 
    v14((1,),(512,),(v9, v8, v10),shared_mem=0)
    del v8, v14
    v15 = time.perf_counter()
    v16 = "The time it took to run the kernel (in seconds) is: "
    method37(v16)
    del v16
    v17 = v15 - v12
    del v12, v15
    method38(v17)
    del v17
    print()
    v18, v19, v20, v21, v22 = method39(v9)
    del v9
    v23, v24, v25 = method68(v10)
    del v10
    return method70(v18, v19, v20, v21, v22, v23, v24, v25)

if __name__ == '__main__': print(main())
