kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <curand_kernel.h>
struct Card { unsigned char rank : 4; unsigned char suit : 2; };
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
struct US4;
struct US5;
struct Tuple0;
struct US6;
struct US3;
struct US9;
struct US8;
struct US7;
struct US10;
struct Tuple1;
__device__ unsigned long long f_8(unsigned char * v0);
__device__ long f_9(unsigned char * v0);
__device__ long f_13(unsigned char * v0);
__device__ Tuple0 f_12(unsigned char * v0);
__device__ static_array_list<Tuple0,5l,long> f_11(unsigned char * v0);
struct Tuple2;
__device__ Tuple2 f_14(unsigned char * v0);
struct Tuple3;
__device__ Tuple3 f_15(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_16(unsigned char * v0);
struct Tuple5;
__device__ static_array<Tuple0,5l> f_19(unsigned char * v0);
__device__ US6 f_18(unsigned char * v0);
__device__ Tuple5 f_17(unsigned char * v0);
__device__ US3 f_10(unsigned char * v0);
__device__ long f_20(unsigned char * v0);
struct Tuple6;
__device__ static_array<Tuple0,2l> f_23(unsigned char * v0);
__device__ long f_24(unsigned char * v0);
__device__ static_array<Tuple0,3l> f_25(unsigned char * v0);
__device__ static_array<Tuple0,4l> f_26(unsigned char * v0);
__device__ Tuple6 f_22(unsigned char * v0);
struct Tuple7;
__device__ long f_28(unsigned char * v0);
__device__ Tuple7 f_27(unsigned char * v0);
__device__ US8 f_21(unsigned char * v0);
__device__ long f_29(unsigned char * v0);
__device__ Tuple1 f_7(unsigned char * v0);
struct Tuple8;
struct Tuple9;
struct Tuple10;
struct Tuple11;
struct Tuple12;
__device__ unsigned long loop_34(unsigned long v0, curandStatePhilox4_32_10_t & v1);
__device__ Tuple12 draw_card_33(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ Tuple10 draw_cards_32(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ US4 card_rank_untag_36(unsigned char v0);
__device__ US5 card_suit_untag_37(unsigned char v0);
__device__ Tuple0 card_from_lib_card_35(Card v0);
__device__ static_array_list<Tuple0,5l,long> get_community_cards_38(US9 v0, static_array<Tuple0,3l> v1);
struct Tuple13;
__device__ Tuple13 draw_cards_39(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
struct Tuple14;
__device__ Tuple14 draw_cards_40(curandStatePhilox4_32_10_t & v0, unsigned long long v1);
__device__ static_array_list<Tuple0,5l,long> get_community_cards_41(US9 v0, static_array<Tuple0,1l> v1);
struct Tuple15;
__device__ long loop_44(static_array<float,8l> v0, float v1, long v2);
__device__ long sample_discrete__43(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1);
__device__ US1 sample_discrete_42(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1);
__device__ unsigned char card_rank_tag_45(US4 v0);
__device__ unsigned char card_suit_tag_46(US5 v0);
struct Tuple16;
struct Tuple17;
struct Tuple18;
struct US11;
struct Tuple19;
struct US12;
struct Tuple20;
struct Tuple21;
struct US13;
struct US14;
struct US15;
struct US16;
struct US17;
__device__ Tuple16 score_47(static_array<Card,7l> v0);
__device__ US6 hand_from_lib_hand_score_48(static_array<Card,5l> v0, char v1);
__device__ US8 play_loop_inner_31(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US8 v4);
__device__ Tuple8 play_loop_30(US7 v0, static_array<US2,2l> v1, US10 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US8 v6);
__device__ void write_50(char v0);
__device__ void write_51();
__device__ void write_54(unsigned long long v0);
__device__ void write_53(unsigned long long v0);
__device__ void write_57();
__device__ void write_61();
__device__ void write_62();
__device__ void write_63();
__device__ void write_64();
__device__ void write_65();
__device__ void write_66();
__device__ void write_67();
__device__ void write_68();
__device__ void write_69();
__device__ void write_70();
__device__ void write_71();
__device__ void write_72();
__device__ void write_73();
__device__ void write_60(US4 v0);
__device__ void write_75();
__device__ void write_76();
__device__ void write_77();
__device__ void write_78();
__device__ void write_74(US5 v0);
__device__ void write_59(US4 v0, US5 v1);
__device__ void write_58(static_array_list<Tuple0,5l,long> v0);
__device__ void write_79();
__device__ void write_81(long v0);
__device__ void write_80(long v0, long v1);
__device__ void write_82();
__device__ void write_85();
__device__ void write_86();
__device__ void write_87();
__device__ void write_84(US1 v0);
__device__ void write_83(long v0, US1 v1);
__device__ void write_88();
__device__ void write_90(static_array<Tuple0,2l> v0);
__device__ void write_89(long v0, static_array<Tuple0,2l> v1);
__device__ void write_91();
__device__ void write_95();
__device__ void write_96(static_array<Tuple0,5l> v0);
__device__ void write_97();
__device__ void write_98();
__device__ void write_99();
__device__ void write_100();
__device__ void write_101();
__device__ void write_102();
__device__ void write_103();
__device__ void write_104();
__device__ void write_94(US6 v0);
__device__ void write_93(static_array<US6,2l> v0);
__device__ void write_92(long v0, static_array<US6,2l> v1, long v2);
__device__ void write_56(US3 v0);
__device__ void write_55(static_array_list<US3,128l,long> v0);
__device__ void write_52(unsigned long long v0, static_array_list<US3,128l,long> v1);
__device__ void write_107();
__device__ void write_108();
__device__ void write_110();
__device__ void write_112(long v0);
__device__ void write_113(bool v0);
__device__ void write_114(static_array<static_array<Tuple0,2l>,2l> v0);
__device__ void write_115(static_array<long,2l> v0);
__device__ void write_117();
__device__ void write_118(static_array<Tuple0,3l> v0);
__device__ void write_119();
__device__ void write_120();
__device__ void write_121();
__device__ void write_122(static_array<Tuple0,4l> v0);
__device__ void write_116(US9 v0);
__device__ void write_111(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6);
__device__ void write_123();
__device__ void write_124();
__device__ void write_125();
__device__ void write_126();
__device__ void write_127();
__device__ void write_128(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6, US1 v7);
__device__ void write_129();
__device__ void write_130();
__device__ void write_109(US8 v0);
__device__ void write_106(US7 v0);
__device__ void write_133();
__device__ void write_134();
__device__ void write_132(US2 v0);
__device__ void write_131(static_array<US2,2l> v0);
__device__ void write_136();
__device__ void write_137();
__device__ void write_138();
__device__ void write_135(US10 v0);
__device__ void write_105(US7 v0, static_array<US2,2l> v1, US10 v2);
__device__ void write_49(unsigned long long v0, static_array_list<US3,128l,long> v1, US7 v2, static_array<US2,2l> v3, US10 v4);
__device__ void f_140(unsigned char * v0, unsigned long long v1);
__device__ void f_141(unsigned char * v0, long v1);
__device__ void f_143(unsigned char * v0, long v1);
__device__ void f_146(unsigned char * v0);
__device__ void f_147(unsigned char * v0, long v1);
__device__ void f_145(unsigned char * v0, US4 v1, US5 v2);
__device__ void f_144(unsigned char * v0, static_array_list<Tuple0,5l,long> v1);
__device__ void f_148(unsigned char * v0, long v1, long v2);
__device__ void f_149(unsigned char * v0, long v1, US1 v2);
__device__ void f_150(unsigned char * v0, long v1, static_array<Tuple0,2l> v2);
__device__ void f_153(unsigned char * v0, static_array<Tuple0,5l> v1);
__device__ void f_152(unsigned char * v0, US6 v1);
__device__ void f_151(unsigned char * v0, long v1, static_array<US6,2l> v2, long v3);
__device__ void f_142(unsigned char * v0, US3 v1);
__device__ void f_154(unsigned char * v0, long v1);
__device__ void f_157(unsigned char * v0, static_array<Tuple0,2l> v1);
__device__ void f_158(unsigned char * v0, long v1);
__device__ void f_159(unsigned char * v0, static_array<Tuple0,3l> v1);
__device__ void f_160(unsigned char * v0, static_array<Tuple0,4l> v1);
__device__ void f_156(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US9 v7);
__device__ void f_162(unsigned char * v0, long v1);
__device__ void f_161(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US9 v7, US1 v8);
__device__ void f_155(unsigned char * v0, US8 v1);
__device__ void f_163(unsigned char * v0, US2 v1);
__device__ void f_164(unsigned char * v0, long v1);
__device__ void f_139(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US7 v3, static_array<US2,2l> v4, US10 v5);
__device__ void f_166(unsigned char * v0, long v1);
__device__ void f_165(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US10 v3);
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
struct US4 {
    union {
    } v;
    unsigned long tag : 4;
};
struct US5 {
    union {
    } v;
    unsigned long tag : 3;
};
struct Tuple0 {
    US4 v0;
    US5 v1;
    __device__ Tuple0(US4 t0, US5 t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct US6 {
    union {
        struct {
            static_array<Tuple0,5l> v0;
        } case0; // Flush
        struct {
            static_array<Tuple0,5l> v0;
        } case1; // Full_House
        struct {
            static_array<Tuple0,5l> v0;
        } case2; // High_Card
        struct {
            static_array<Tuple0,5l> v0;
        } case3; // Pair
        struct {
            static_array<Tuple0,5l> v0;
        } case4; // Quads
        struct {
            static_array<Tuple0,5l> v0;
        } case5; // Straight
        struct {
            static_array<Tuple0,5l> v0;
        } case6; // Straight_Flush
        struct {
            static_array<Tuple0,5l> v0;
        } case7; // Triple
        struct {
            static_array<Tuple0,5l> v0;
        } case8; // Two_Pair
    } v;
    unsigned long tag : 4;
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
            static_array<US6,2l> v1;
            long v0;
            long v2;
        } case4; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US9 {
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
    unsigned long tag : 3;
};
struct US8 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case0; // G_Flop
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // G_Fold
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case3; // G_River
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case4; // G_Round
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            US1 v7;
            long v0;
            long v3;
            bool v1;
        } case5; // G_Round'
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case6; // G_Showdown
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case7; // G_Turn
    } v;
    unsigned long tag : 4;
};
struct US7 {
    union {
        struct {
            US8 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US10 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // GameOver
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US9 v6;
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
    US7 v2;
    static_array<US2,2l> v3;
    US10 v4;
    __device__ Tuple1(unsigned long long t0, static_array_list<US3,128l,long> t1, US7 t2, static_array<US2,2l> t3, US10 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
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
    static_array<Tuple0,2l> v1;
    long v0;
    __device__ Tuple4(long t0, static_array<Tuple0,2l> t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    static_array<US6,2l> v1;
    long v0;
    long v2;
    __device__ Tuple5(long t0, static_array<US6,2l> t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    static_array<static_array<Tuple0,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US9 v6;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple6(long t0, bool t1, static_array<static_array<Tuple0,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US9 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<Tuple0,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US9 v6;
    US1 v7;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple7(long t0, bool t1, static_array<static_array<Tuple0,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US9 t6, US1 t7) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6), v7(t7) {}
    __device__ Tuple7() = default;
};
struct Tuple8 {
    US7 v0;
    static_array<US2,2l> v1;
    US10 v2;
    __device__ Tuple8(US7 t0, static_array<US2,2l> t1, US10 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple8() = default;
};
struct Tuple9 {
    US8 v1;
    bool v0;
    __device__ Tuple9(bool t0, US8 t1) : v0(t0), v1(t1) {}
    __device__ Tuple9() = default;
};
struct Tuple10 {
    static_array<Card,3l> v0;
    unsigned long long v1;
    __device__ Tuple10(static_array<Card,3l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple10() = default;
};
struct Tuple11 {
    unsigned long long v1;
    long v0;
    __device__ Tuple11(long t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple11() = default;
};
struct Tuple12 {
    Card v0;
    unsigned long long v1;
    __device__ Tuple12(Card t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple12() = default;
};
struct Tuple13 {
    static_array<Card,2l> v0;
    unsigned long long v1;
    __device__ Tuple13(static_array<Card,2l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple13() = default;
};
struct Tuple14 {
    static_array<Card,1l> v0;
    unsigned long long v1;
    __device__ Tuple14(static_array<Card,1l> t0, unsigned long long t1) : v0(t0), v1(t1) {}
    __device__ Tuple14() = default;
};
struct Tuple15 {
    US1 v0;
    float v1;
    __device__ Tuple15(US1 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple15() = default;
};
struct Tuple16 {
    static_array<Card,5l> v0;
    char v1;
    __device__ Tuple16(static_array<Card,5l> t0, char t1) : v0(t0), v1(t1) {}
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
struct US11 {
    union {
    } v;
    unsigned long tag : 2;
};
struct Tuple19 {
    long v0;
    long v1;
    unsigned char v2;
    __device__ Tuple19(long t0, long t1, unsigned char t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple19() = default;
};
struct US12 {
    union {
        struct {
            static_array<Card,5l> v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple20 {
    US11 v1;
    long v0;
    __device__ Tuple20(long t0, US11 t1) : v0(t0), v1(t1) {}
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
struct US13 {
    union {
        struct {
            static_array<Card,4l> v0;
            static_array<Card,3l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US14 {
    union {
        struct {
            static_array<Card,3l> v0;
            static_array<Card,4l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US15 {
    union {
        struct {
            static_array<Card,2l> v0;
            static_array<Card,2l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US16 {
    union {
        struct {
            static_array<Card,2l> v0;
            static_array<Card,5l> v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US17 {
    union {
        struct {
            static_array<Card,2l> v0;
            static_array<Card,3l> v1;
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
__device__ US6 US6_0(static_array<Tuple0,5l> v0) { // Flush
    US6 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US6 US6_1(static_array<Tuple0,5l> v0) { // Full_House
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US6 US6_2(static_array<Tuple0,5l> v0) { // High_Card
    US6 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US6 US6_3(static_array<Tuple0,5l> v0) { // Pair
    US6 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US6 US6_4(static_array<Tuple0,5l> v0) { // Quads
    US6 x;
    x.tag = 4;
    x.v.case4.v0 = v0;
    return x;
}
__device__ US6 US6_5(static_array<Tuple0,5l> v0) { // Straight
    US6 x;
    x.tag = 5;
    x.v.case5.v0 = v0;
    return x;
}
__device__ US6 US6_6(static_array<Tuple0,5l> v0) { // Straight_Flush
    US6 x;
    x.tag = 6;
    x.v.case6.v0 = v0;
    return x;
}
__device__ US6 US6_7(static_array<Tuple0,5l> v0) { // Triple
    US6 x;
    x.tag = 7;
    x.v.case7.v0 = v0;
    return x;
}
__device__ US6 US6_8(static_array<Tuple0,5l> v0) { // Two_Pair
    US6 x;
    x.tag = 8;
    x.v.case8.v0 = v0;
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
__device__ US3 US3_4(long v0, static_array<US6,2l> v1, long v2) { // Showdown
    US3 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2;
    return x;
}
__device__ US9 US9_0(static_array<Tuple0,3l> v0) { // Flop
    US9 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US9 US9_1() { // Preflop
    US9 x;
    x.tag = 1;
    return x;
}
__device__ US9 US9_2(static_array<Tuple0,5l> v0) { // River
    US9 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US9 US9_3(static_array<Tuple0,4l> v0) { // Turn
    US9 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US8 US8_0(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_Flop
    US8 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5; x.v.case0.v6 = v6;
    return x;
}
__device__ US8 US8_1(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_Fold
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US8 US8_2() { // G_Preflop
    US8 x;
    x.tag = 2;
    return x;
}
__device__ US8 US8_3(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_River
    US8 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US8 US8_4(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_Round
    US8 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5; x.v.case4.v6 = v6;
    return x;
}
__device__ US8 US8_5(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6, US1 v7) { // G_Round'
    US8 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6; x.v.case5.v7 = v7;
    return x;
}
__device__ US8 US8_6(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_Showdown
    US8 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5; x.v.case6.v6 = v6;
    return x;
}
__device__ US8 US8_7(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // G_Turn
    US8 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5; x.v.case7.v6 = v6;
    return x;
}
__device__ US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
__device__ US7 US7_1(US8 v0) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US10 US10_0() { // GameNotStarted
    US10 x;
    x.tag = 0;
    return x;
}
__device__ US10 US10_1(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // GameOver
    US10 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US10 US10_2(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6) { // WaitingForActionFromPlayerId
    US10 x;
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
__device__ long f_13(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple0 f_12(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    US4 v17;
    switch (v1) {
        case 0: {
            f_4(v2);
            v17 = US4_0();
            break;
        }
        case 1: {
            f_4(v2);
            v17 = US4_1();
            break;
        }
        case 2: {
            f_4(v2);
            v17 = US4_2();
            break;
        }
        case 3: {
            f_4(v2);
            v17 = US4_3();
            break;
        }
        case 4: {
            f_4(v2);
            v17 = US4_4();
            break;
        }
        case 5: {
            f_4(v2);
            v17 = US4_5();
            break;
        }
        case 6: {
            f_4(v2);
            v17 = US4_6();
            break;
        }
        case 7: {
            f_4(v2);
            v17 = US4_7();
            break;
        }
        case 8: {
            f_4(v2);
            v17 = US4_8();
            break;
        }
        case 9: {
            f_4(v2);
            v17 = US4_9();
            break;
        }
        case 10: {
            f_4(v2);
            v17 = US4_10();
            break;
        }
        case 11: {
            f_4(v2);
            v17 = US4_11();
            break;
        }
        case 12: {
            f_4(v2);
            v17 = US4_12();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v18;
    v18 = f_13(v0);
    unsigned char * v19;
    v19 = (unsigned char *)(v0+8ull);
    US5 v25;
    switch (v18) {
        case 0: {
            f_4(v19);
            v25 = US5_0();
            break;
        }
        case 1: {
            f_4(v19);
            v25 = US5_1();
            break;
        }
        case 2: {
            f_4(v19);
            v25 = US5_2();
            break;
        }
        case 3: {
            f_4(v19);
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
__device__ static_array_list<Tuple0,5l,long> f_11(unsigned char * v0){
    static_array_list<Tuple0,5l,long> v1;
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
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US4 v10; US5 v11;
        Tuple0 tmp0 = f_12(v9);
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
__device__ Tuple3 f_15(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_13(v0);
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
__device__ Tuple4 f_16(unsigned char * v0){
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
        Tuple0 tmp3 = f_12(v9);
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
    return Tuple4(v2, v3);
}
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
__device__ static_array<Tuple0,5l> f_19(unsigned char * v0){
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
        Tuple0 tmp5 = f_12(v6);
        v7 = tmp5.v0; v8 = tmp5.v1;
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
__device__ US6 f_18(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array<Tuple0,5l> v4;
            v4 = f_19(v2);
            return US6_0(v4);
            break;
        }
        case 1: {
            static_array<Tuple0,5l> v6;
            v6 = f_19(v2);
            return US6_1(v6);
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v8;
            v8 = f_19(v2);
            return US6_2(v8);
            break;
        }
        case 3: {
            static_array<Tuple0,5l> v10;
            v10 = f_19(v2);
            return US6_3(v10);
            break;
        }
        case 4: {
            static_array<Tuple0,5l> v12;
            v12 = f_19(v2);
            return US6_4(v12);
            break;
        }
        case 5: {
            static_array<Tuple0,5l> v14;
            v14 = f_19(v2);
            return US6_5(v14);
            break;
        }
        case 6: {
            static_array<Tuple0,5l> v16;
            v16 = f_19(v2);
            return US6_6(v16);
            break;
        }
        case 7: {
            static_array<Tuple0,5l> v18;
            v18 = f_19(v2);
            return US6_7(v18);
            break;
        }
        case 8: {
            static_array<Tuple0,5l> v20;
            v20 = f_19(v2);
            return US6_8(v20);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ Tuple5 f_17(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<US6,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_0(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 64ull;
        unsigned long long v8;
        v8 = 16ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US6 v10;
        v10 = f_18(v9);
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
    long * v15;
    v15 = (long *)(v0+144ull);
    long v16;
    v16 = v15[0l];
    return Tuple5(v2, v3, v16);
}
__device__ US3 f_10(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array_list<Tuple0,5l,long> v4;
            v4 = f_11(v2);
            return US3_0(v4);
            break;
        }
        case 1: {
            long v6; long v7;
            Tuple2 tmp1 = f_14(v2);
            v6 = tmp1.v0; v7 = tmp1.v1;
            return US3_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US1 v10;
            Tuple3 tmp2 = f_15(v2);
            v9 = tmp2.v0; v10 = tmp2.v1;
            return US3_2(v9, v10);
            break;
        }
        case 3: {
            long v12; static_array<Tuple0,2l> v13;
            Tuple4 tmp4 = f_16(v2);
            v12 = tmp4.v0; v13 = tmp4.v1;
            return US3_3(v12, v13);
            break;
        }
        case 4: {
            long v15; static_array<US6,2l> v16; long v17;
            Tuple5 tmp6 = f_17(v2);
            v15 = tmp6.v0; v16 = tmp6.v1; v17 = tmp6.v2;
            return US3_4(v15, v16, v17);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_20(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+22544ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ static_array<Tuple0,2l> f_23(unsigned char * v0){
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
        Tuple0 tmp7 = f_12(v6);
        v7 = tmp7.v0; v8 = tmp7.v1;
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
__device__ long f_24(unsigned char * v0){
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
__device__ static_array<Tuple0,3l> f_25(unsigned char * v0){
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
        Tuple0 tmp8 = f_12(v6);
        v7 = tmp8.v0; v8 = tmp8.v1;
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
__device__ inline bool while_method_4(long v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ static_array<Tuple0,4l> f_26(unsigned char * v0){
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
        Tuple0 tmp9 = f_12(v6);
        v7 = tmp9.v0; v8 = tmp9.v1;
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
__device__ Tuple6 f_22(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    bool * v3;
    v3 = (bool *)(v0+4ull);
    bool v4;
    v4 = v3[0l];
    static_array<static_array<Tuple0,2l>,2l> v5;
    long v6;
    v6 = 0l;
    while (while_method_0(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 16ull;
        unsigned long long v10;
        v10 = 16ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<Tuple0,2l> v12;
        v12 = f_23(v11);
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
    v17 = (long *)(v0+48ull);
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
        v24 = 52ull + v23;
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
        v36 = 60ull + v35;
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
    v43 = f_24(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+80ull);
    US9 v53;
    switch (v43) {
        case 0: {
            static_array<Tuple0,3l> v46;
            v46 = f_25(v44);
            v53 = US9_0(v46);
            break;
        }
        case 1: {
            f_4(v44);
            v53 = US9_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v49;
            v49 = f_19(v44);
            v53 = US9_2(v49);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v51;
            v51 = f_26(v44);
            v53 = US9_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple6(v2, v4, v5, v18, v19, v31, v53);
}
__device__ long f_28(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+128ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple7 f_27(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    bool * v3;
    v3 = (bool *)(v0+4ull);
    bool v4;
    v4 = v3[0l];
    static_array<static_array<Tuple0,2l>,2l> v5;
    long v6;
    v6 = 0l;
    while (while_method_0(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 16ull;
        unsigned long long v10;
        v10 = 16ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<Tuple0,2l> v12;
        v12 = f_23(v11);
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
    v17 = (long *)(v0+48ull);
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
        v24 = 52ull + v23;
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
        v36 = 60ull + v35;
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
    v43 = f_24(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+80ull);
    US9 v53;
    switch (v43) {
        case 0: {
            static_array<Tuple0,3l> v46;
            v46 = f_25(v44);
            v53 = US9_0(v46);
            break;
        }
        case 1: {
            f_4(v44);
            v53 = US9_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v49;
            v49 = f_19(v44);
            v53 = US9_2(v49);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v51;
            v51 = f_26(v44);
            v53 = US9_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v54;
    v54 = f_28(v0);
    unsigned char * v55;
    v55 = (unsigned char *)(v0+132ull);
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
__device__ US8 f_21(unsigned char * v0){
    long v1;
    v1 = f_2(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; bool v5; static_array<static_array<Tuple0,2l>,2l> v6; long v7; static_array<long,2l> v8; static_array<long,2l> v9; US9 v10;
            Tuple6 tmp10 = f_22(v2);
            v4 = tmp10.v0; v5 = tmp10.v1; v6 = tmp10.v2; v7 = tmp10.v3; v8 = tmp10.v4; v9 = tmp10.v5; v10 = tmp10.v6;
            return US8_0(v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: {
            long v12; bool v13; static_array<static_array<Tuple0,2l>,2l> v14; long v15; static_array<long,2l> v16; static_array<long,2l> v17; US9 v18;
            Tuple6 tmp11 = f_22(v2);
            v12 = tmp11.v0; v13 = tmp11.v1; v14 = tmp11.v2; v15 = tmp11.v3; v16 = tmp11.v4; v17 = tmp11.v5; v18 = tmp11.v6;
            return US8_1(v12, v13, v14, v15, v16, v17, v18);
            break;
        }
        case 2: {
            f_4(v2);
            return US8_2();
            break;
        }
        case 3: {
            long v21; bool v22; static_array<static_array<Tuple0,2l>,2l> v23; long v24; static_array<long,2l> v25; static_array<long,2l> v26; US9 v27;
            Tuple6 tmp12 = f_22(v2);
            v21 = tmp12.v0; v22 = tmp12.v1; v23 = tmp12.v2; v24 = tmp12.v3; v25 = tmp12.v4; v26 = tmp12.v5; v27 = tmp12.v6;
            return US8_3(v21, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 4: {
            long v29; bool v30; static_array<static_array<Tuple0,2l>,2l> v31; long v32; static_array<long,2l> v33; static_array<long,2l> v34; US9 v35;
            Tuple6 tmp13 = f_22(v2);
            v29 = tmp13.v0; v30 = tmp13.v1; v31 = tmp13.v2; v32 = tmp13.v3; v33 = tmp13.v4; v34 = tmp13.v5; v35 = tmp13.v6;
            return US8_4(v29, v30, v31, v32, v33, v34, v35);
            break;
        }
        case 5: {
            long v37; bool v38; static_array<static_array<Tuple0,2l>,2l> v39; long v40; static_array<long,2l> v41; static_array<long,2l> v42; US9 v43; US1 v44;
            Tuple7 tmp14 = f_27(v2);
            v37 = tmp14.v0; v38 = tmp14.v1; v39 = tmp14.v2; v40 = tmp14.v3; v41 = tmp14.v4; v42 = tmp14.v5; v43 = tmp14.v6; v44 = tmp14.v7;
            return US8_5(v37, v38, v39, v40, v41, v42, v43, v44);
            break;
        }
        case 6: {
            long v46; bool v47; static_array<static_array<Tuple0,2l>,2l> v48; long v49; static_array<long,2l> v50; static_array<long,2l> v51; US9 v52;
            Tuple6 tmp15 = f_22(v2);
            v46 = tmp15.v0; v47 = tmp15.v1; v48 = tmp15.v2; v49 = tmp15.v3; v50 = tmp15.v4; v51 = tmp15.v5; v52 = tmp15.v6;
            return US8_6(v46, v47, v48, v49, v50, v51, v52);
            break;
        }
        case 7: {
            long v54; bool v55; static_array<static_array<Tuple0,2l>,2l> v56; long v57; static_array<long,2l> v58; static_array<long,2l> v59; US9 v60;
            Tuple6 tmp16 = f_22(v2);
            v54 = tmp16.v0; v55 = tmp16.v1; v56 = tmp16.v2; v57 = tmp16.v3; v58 = tmp16.v4; v59 = tmp16.v5; v60 = tmp16.v6;
            return US8_7(v54, v55, v56, v57, v58, v59, v60);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_29(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+22728ull);
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
        v8 = v7 * 176ull;
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
    v17 = f_20(v0);
    unsigned char * v18;
    v18 = (unsigned char *)(v0+22560ull);
    US7 v23;
    switch (v17) {
        case 0: {
            f_4(v18);
            v23 = US7_0();
            break;
        }
        case 1: {
            US8 v21;
            v21 = f_21(v18);
            v23 = US7_1(v21);
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
        v29 = 22720ull + v28;
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
    v36 = f_29(v0);
    unsigned char * v37;
    v37 = (unsigned char *)(v0+22736ull);
    US10 v56;
    switch (v36) {
        case 0: {
            f_4(v37);
            v56 = US10_0();
            break;
        }
        case 1: {
            long v40; bool v41; static_array<static_array<Tuple0,2l>,2l> v42; long v43; static_array<long,2l> v44; static_array<long,2l> v45; US9 v46;
            Tuple6 tmp17 = f_22(v37);
            v40 = tmp17.v0; v41 = tmp17.v1; v42 = tmp17.v2; v43 = tmp17.v3; v44 = tmp17.v4; v45 = tmp17.v5; v46 = tmp17.v6;
            v56 = US10_1(v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 2: {
            long v48; bool v49; static_array<static_array<Tuple0,2l>,2l> v50; long v51; static_array<long,2l> v52; static_array<long,2l> v53; US9 v54;
            Tuple6 tmp18 = f_22(v37);
            v48 = tmp18.v0; v49 = tmp18.v1; v50 = tmp18.v2; v51 = tmp18.v3; v52 = tmp18.v4; v53 = tmp18.v5; v54 = tmp18.v6;
            v56 = US10_2(v48, v49, v50, v51, v52, v53, v54);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v1, v2, v23, v24, v56);
}
__device__ inline bool while_method_5(bool v0, US8 v1){
    return v0;
}
__device__ unsigned long loop_34(unsigned long v0, curandStatePhilox4_32_10_t & v1){
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
        return loop_34(v0, v1);
    }
}
__device__ Tuple12 draw_card_33(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    long v2;
    v2 = __popcll(v1);
    unsigned long v3;
    v3 = (unsigned long)v2;
    unsigned long v4;
    v4 = loop_34(v3, v0);
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
    Card v21;
    v21 = {v20, v19};
    long v22;
    v22 = (long)v17;
    unsigned long long v23;
    v23 = 1ull << v22;
    unsigned long long v24;
    v24 = v1 ^ v23;
    return Tuple12(v21, v24);
}
__device__ Tuple10 draw_cards_32(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<Card,3l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp21 = Tuple11(0l, v1);
    v3 = tmp21.v0; v4 = tmp21.v1;
    while (while_method_3(v3)){
        Card v6; unsigned long long v7;
        Tuple12 tmp22 = draw_card_33(v0, v4);
        v6 = tmp22.v0; v7 = tmp22.v1;
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
__device__ US4 card_rank_untag_36(unsigned char v0){
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
__device__ US5 card_suit_untag_37(unsigned char v0){
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
__device__ Tuple0 card_from_lib_card_35(Card v0){
    unsigned char v1;
    v1 = v0.rank;
    US4 v2;
    v2 = card_rank_untag_36(v1);
    unsigned char v3;
    v3 = v0.suit;
    US5 v4;
    v4 = card_suit_untag_37(v3);
    return Tuple0(v2, v4);
}
__device__ static_array_list<Tuple0,5l,long> get_community_cards_38(US9 v0, static_array<Tuple0,3l> v1){
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
                Tuple0 tmp25 = v3.v[v4];
                v10 = tmp25.v0; v11 = tmp25.v1;
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
                Tuple0 tmp26 = v39.v[v40];
                v46 = tmp26.v0; v47 = tmp26.v1;
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
                Tuple0 tmp27 = v21.v[v22];
                v28 = tmp27.v0; v29 = tmp27.v1;
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
        Tuple0 tmp28 = v1.v[v57];
        v63 = tmp28.v0; v64 = tmp28.v1;
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
__device__ Tuple13 draw_cards_39(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<Card,2l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp29 = Tuple11(0l, v1);
    v3 = tmp29.v0; v4 = tmp29.v1;
    while (while_method_0(v3)){
        Card v6; unsigned long long v7;
        Tuple12 tmp30 = draw_card_33(v0, v4);
        v6 = tmp30.v0; v7 = tmp30.v1;
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
__device__ Tuple14 draw_cards_40(curandStatePhilox4_32_10_t & v0, unsigned long long v1){
    static_array<Card,1l> v2;
    long v3; unsigned long long v4;
    Tuple11 tmp35 = Tuple11(0l, v1);
    v3 = tmp35.v0; v4 = tmp35.v1;
    while (while_method_6(v3)){
        Card v6; unsigned long long v7;
        Tuple12 tmp36 = draw_card_33(v0, v4);
        v6 = tmp36.v0; v7 = tmp36.v1;
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
__device__ static_array_list<Tuple0,5l,long> get_community_cards_41(US9 v0, static_array<Tuple0,1l> v1){
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
                Tuple0 tmp39 = v3.v[v4];
                v10 = tmp39.v0; v11 = tmp39.v1;
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
                Tuple0 tmp40 = v39.v[v40];
                v46 = tmp40.v0; v47 = tmp40.v1;
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
                Tuple0 tmp41 = v21.v[v22];
                v28 = tmp41.v0; v29 = tmp41.v1;
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
        Tuple0 tmp42 = v1.v[v57];
        v63 = tmp42.v0; v64 = tmp42.v1;
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
__device__ long loop_44(static_array<float,8l> v0, float v1, long v2){
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
            return loop_44(v0, v1, v9);
        }
    } else {
        return 7l;
    }
}
__device__ long sample_discrete__43(static_array<float,8l> v0, curandStatePhilox4_32_10_t & v1){
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
    return loop_44(v2, v35, v36);
}
__device__ US1 sample_discrete_42(static_array<Tuple15,8l> v0, curandStatePhilox4_32_10_t & v1){
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
        Tuple15 tmp47 = v0.v[v3];
        v9 = tmp47.v0; v10 = tmp47.v1;
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
    v14 = sample_discrete__43(v2, v1);
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
    Tuple15 tmp48 = v0.v[v14];
    v19 = tmp48.v0; v20 = tmp48.v1;
    return v19;
}
__device__ unsigned char card_rank_tag_45(US4 v0){
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
__device__ unsigned char card_suit_tag_46(US5 v0){
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
__device__ inline bool while_method_10(long v0){
    bool v1;
    v1 = v0 < 7l;
    return v1;
}
__device__ inline bool while_method_11(static_array<Card,7l> v0, bool v1, long v2){
    bool v3;
    v3 = v2 < 7l;
    return v3;
}
__device__ inline bool while_method_12(static_array<Card,7l> v0, long v1){
    bool v2;
    v2 = v1 < 7l;
    return v2;
}
__device__ inline bool while_method_13(long v0, long v1, long v2, long v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
__device__ US11 US11_0() { // Eq
    US11 x;
    x.tag = 0;
    return x;
}
__device__ US11 US11_1() { // Gt
    US11 x;
    x.tag = 1;
    return x;
}
__device__ US11 US11_2() { // Lt
    US11 x;
    x.tag = 2;
    return x;
}
__device__ US12 US12_0() { // None
    US12 x;
    x.tag = 0;
    return x;
}
__device__ US12 US12_1(static_array<Card,5l> v0) { // Some
    US12 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US13 US13_0() { // None
    US13 x;
    x.tag = 0;
    return x;
}
__device__ US13 US13_1(static_array<Card,4l> v0, static_array<Card,3l> v1) { // Some
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
__device__ US14 US14_1(static_array<Card,3l> v0, static_array<Card,4l> v1) { // Some
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
__device__ US15 US15_1(static_array<Card,2l> v0, static_array<Card,2l> v1) { // Some
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
__device__ US16 US16_1(static_array<Card,2l> v0, static_array<Card,5l> v1) { // Some
    US16 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US17 US17_0() { // None
    US17 x;
    x.tag = 0;
    return x;
}
__device__ US17 US17_1(static_array<Card,2l> v0, static_array<Card,3l> v1) { // Some
    US17 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ Tuple16 score_47(static_array<Card,7l> v0){
    static_array<Card,7l> v1;
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
        Card v8;
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
    static_array<Card,7l> v12;
    bool v13; long v14;
    Tuple17 tmp55 = Tuple17(true, 1l);
    v13 = tmp55.v0; v14 = tmp55.v1;
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
            Tuple18 tmp56 = Tuple18(v16, v20, v16);
            v25 = tmp56.v0; v26 = tmp56.v1; v27 = tmp56.v2;
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
                Card v105; long v106; long v107;
                if (v31){
                    Card v42;
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
                        Card v36;
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
                        Card v41;
                        v41 = v12.v[v25];
                        v42 = v41;
                    }
                    Card v53;
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
                        Card v47;
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
                        Card v52;
                        v52 = v12.v[v26];
                        v53 = v52;
                    }
                    unsigned char v54;
                    v54 = v53.rank;
                    unsigned char v55;
                    v55 = v42.rank;
                    bool v56;
                    v56 = v54 < v55;
                    US11 v62;
                    if (v56){
                        v62 = US11_2();
                    } else {
                        bool v58;
                        v58 = v54 > v55;
                        if (v58){
                            v62 = US11_1();
                        } else {
                            v62 = US11_0();
                        }
                    }
                    US11 v72;
                    switch (v62.tag) {
                        case 0: { // Eq
                            unsigned char v63;
                            v63 = v42.suit;
                            unsigned char v64;
                            v64 = v53.suit;
                            bool v65;
                            v65 = v63 < v64;
                            if (v65){
                                v72 = US11_2();
                            } else {
                                bool v67;
                                v67 = v63 > v64;
                                if (v67){
                                    v72 = US11_1();
                                } else {
                                    v72 = US11_0();
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
                        Card v88;
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
                            Card v82;
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
                            Card v87;
                            v87 = v12.v[v25];
                            v88 = v87;
                        }
                        long v89;
                        v89 = v25 + 1l;
                        v105 = v88; v106 = v89; v107 = v26;
                    } else {
                        Card v100;
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
                            Card v94;
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
                            Card v99;
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
    static_array<Card,7l> v120;
    if (v119){
        v120 = v12;
    } else {
        v120 = v1;
    }
    static_array<Card,5l> v121;
    long v122; long v123; unsigned char v124;
    Tuple19 tmp57 = Tuple19(0l, 0l, 12u);
    v122 = tmp57.v0; v123 = tmp57.v1; v124 = tmp57.v2;
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
        Card v130;
        v130 = v120.v[v122];
        bool v131;
        v131 = v123 < 5l;
        long v148; unsigned char v149;
        if (v131){
            unsigned char v132;
            v132 = v130.suit;
            bool v133;
            v133 = 0u == v132;
            if (v133){
                unsigned char v134;
                v134 = v130.rank;
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
                v142 = v130.rank;
                unsigned char v143;
                v143 = v142 - 1u;
                v148 = v141; v149 = v143;
            } else {
                v148 = v123; v149 = v124;
            }
        } else {
            break;
        }
        v123 = v148;
        v124 = v149;
        v122 += 1l ;
    }
    bool v150;
    v150 = v123 == 4l;
    bool v185;
    if (v150){
        unsigned char v151;
        v151 = v124 + 1u;
        bool v152;
        v152 = v151 == 0u;
        if (v152){
            Card v153;
            v153 = v120.v[0l];
            unsigned char v154;
            v154 = v153.suit;
            bool v155;
            v155 = 0u == v154;
            bool v159;
            if (v155){
                unsigned char v156;
                v156 = v153.rank;
                bool v157;
                v157 = v156 == 12u;
                if (v157){
                    v121.v[4l] = v153;
                    v159 = true;
                } else {
                    v159 = false;
                }
            } else {
                v159 = false;
            }
            if (v159){
                v185 = true;
            } else {
                Card v160;
                v160 = v120.v[1l];
                unsigned char v161;
                v161 = v160.suit;
                bool v162;
                v162 = 0u == v161;
                bool v166;
                if (v162){
                    unsigned char v163;
                    v163 = v160.rank;
                    bool v164;
                    v164 = v163 == 12u;
                    if (v164){
                        v121.v[4l] = v160;
                        v166 = true;
                    } else {
                        v166 = false;
                    }
                } else {
                    v166 = false;
                }
                if (v166){
                    v185 = true;
                } else {
                    Card v167;
                    v167 = v120.v[2l];
                    unsigned char v168;
                    v168 = v167.suit;
                    bool v169;
                    v169 = 0u == v168;
                    bool v173;
                    if (v169){
                        unsigned char v170;
                        v170 = v167.rank;
                        bool v171;
                        v171 = v170 == 12u;
                        if (v171){
                            v121.v[4l] = v167;
                            v173 = true;
                        } else {
                            v173 = false;
                        }
                    } else {
                        v173 = false;
                    }
                    if (v173){
                        v185 = true;
                    } else {
                        Card v174;
                        v174 = v120.v[3l];
                        unsigned char v175;
                        v175 = v174.suit;
                        bool v176;
                        v176 = 0u == v175;
                        if (v176){
                            unsigned char v177;
                            v177 = v174.rank;
                            bool v178;
                            v178 = v177 == 12u;
                            if (v178){
                                v121.v[4l] = v174;
                                v185 = true;
                            } else {
                                v185 = false;
                            }
                        } else {
                            v185 = false;
                        }
                    }
                }
            }
        } else {
            v185 = false;
        }
    } else {
        v185 = false;
    }
    US12 v191;
    if (v185){
        v191 = US12_1(v121);
    } else {
        bool v187;
        v187 = v123 == 5l;
        if (v187){
            v191 = US12_1(v121);
        } else {
            v191 = US12_0();
        }
    }
    static_array<Card,5l> v192;
    long v193; long v194; unsigned char v195;
    Tuple19 tmp58 = Tuple19(0l, 0l, 12u);
    v193 = tmp58.v0; v194 = tmp58.v1; v195 = tmp58.v2;
    while (while_method_10(v193)){
        bool v197;
        v197 = 0l <= v193;
        bool v199;
        if (v197){
            bool v198;
            v198 = v193 < 7l;
            v199 = v198;
        } else {
            v199 = false;
        }
        bool v200;
        v200 = v199 == false;
        if (v200){
            assert("The read index needs to be in range for the static array." && v199);
        } else {
        }
        Card v201;
        v201 = v120.v[v193];
        bool v202;
        v202 = v194 < 5l;
        long v219; unsigned char v220;
        if (v202){
            unsigned char v203;
            v203 = v201.suit;
            bool v204;
            v204 = 1u == v203;
            if (v204){
                unsigned char v205;
                v205 = v201.rank;
                bool v206;
                v206 = v195 == v205;
                long v207;
                if (v206){
                    v207 = v194;
                } else {
                    v207 = 0l;
                }
                bool v208;
                v208 = 0l <= v207;
                bool v210;
                if (v208){
                    bool v209;
                    v209 = v207 < 5l;
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
                v192.v[v207] = v201;
                long v212;
                v212 = v207 + 1l;
                unsigned char v213;
                v213 = v201.rank;
                unsigned char v214;
                v214 = v213 - 1u;
                v219 = v212; v220 = v214;
            } else {
                v219 = v194; v220 = v195;
            }
        } else {
            break;
        }
        v194 = v219;
        v195 = v220;
        v193 += 1l ;
    }
    bool v221;
    v221 = v194 == 4l;
    bool v256;
    if (v221){
        unsigned char v222;
        v222 = v195 + 1u;
        bool v223;
        v223 = v222 == 0u;
        if (v223){
            Card v224;
            v224 = v120.v[0l];
            unsigned char v225;
            v225 = v224.suit;
            bool v226;
            v226 = 1u == v225;
            bool v230;
            if (v226){
                unsigned char v227;
                v227 = v224.rank;
                bool v228;
                v228 = v227 == 12u;
                if (v228){
                    v192.v[4l] = v224;
                    v230 = true;
                } else {
                    v230 = false;
                }
            } else {
                v230 = false;
            }
            if (v230){
                v256 = true;
            } else {
                Card v231;
                v231 = v120.v[1l];
                unsigned char v232;
                v232 = v231.suit;
                bool v233;
                v233 = 1u == v232;
                bool v237;
                if (v233){
                    unsigned char v234;
                    v234 = v231.rank;
                    bool v235;
                    v235 = v234 == 12u;
                    if (v235){
                        v192.v[4l] = v231;
                        v237 = true;
                    } else {
                        v237 = false;
                    }
                } else {
                    v237 = false;
                }
                if (v237){
                    v256 = true;
                } else {
                    Card v238;
                    v238 = v120.v[2l];
                    unsigned char v239;
                    v239 = v238.suit;
                    bool v240;
                    v240 = 1u == v239;
                    bool v244;
                    if (v240){
                        unsigned char v241;
                        v241 = v238.rank;
                        bool v242;
                        v242 = v241 == 12u;
                        if (v242){
                            v192.v[4l] = v238;
                            v244 = true;
                        } else {
                            v244 = false;
                        }
                    } else {
                        v244 = false;
                    }
                    if (v244){
                        v256 = true;
                    } else {
                        Card v245;
                        v245 = v120.v[3l];
                        unsigned char v246;
                        v246 = v245.suit;
                        bool v247;
                        v247 = 1u == v246;
                        if (v247){
                            unsigned char v248;
                            v248 = v245.rank;
                            bool v249;
                            v249 = v248 == 12u;
                            if (v249){
                                v192.v[4l] = v245;
                                v256 = true;
                            } else {
                                v256 = false;
                            }
                        } else {
                            v256 = false;
                        }
                    }
                }
            }
        } else {
            v256 = false;
        }
    } else {
        v256 = false;
    }
    US12 v262;
    if (v256){
        v262 = US12_1(v192);
    } else {
        bool v258;
        v258 = v194 == 5l;
        if (v258){
            v262 = US12_1(v192);
        } else {
            v262 = US12_0();
        }
    }
    US12 v295;
    switch (v191.tag) {
        case 0: { // None
            v295 = v262;
            break;
        }
        case 1: { // Some
            static_array<Card,5l> v263 = v191.v.case1.v0;
            switch (v262.tag) {
                case 0: { // None
                    v295 = v191;
                    break;
                }
                case 1: { // Some
                    static_array<Card,5l> v264 = v262.v.case1.v0;
                    US11 v265;
                    v265 = US11_0();
                    long v266; US11 v267;
                    Tuple20 tmp59 = Tuple20(0l, v265);
                    v266 = tmp59.v0; v267 = tmp59.v1;
                    while (while_method_2(v266)){
                        bool v269;
                        v269 = 0l <= v266;
                        bool v271;
                        if (v269){
                            bool v270;
                            v270 = v266 < 5l;
                            v271 = v270;
                        } else {
                            v271 = false;
                        }
                        bool v272;
                        v272 = v271 == false;
                        if (v272){
                            assert("The read index needs to be in range for the static array." && v271);
                        } else {
                        }
                        Card v273;
                        v273 = v263.v[v266];
                        bool v275;
                        if (v269){
                            bool v274;
                            v274 = v266 < 5l;
                            v275 = v274;
                        } else {
                            v275 = false;
                        }
                        bool v276;
                        v276 = v275 == false;
                        if (v276){
                            assert("The read index needs to be in range for the static array." && v275);
                        } else {
                        }
                        Card v277;
                        v277 = v264.v[v266];
                        US11 v288;
                        switch (v267.tag) {
                            case 0: { // Eq
                                unsigned char v278;
                                v278 = v273.rank;
                                unsigned char v279;
                                v279 = v277.rank;
                                bool v280;
                                v280 = v278 < v279;
                                if (v280){
                                    v288 = US11_2();
                                } else {
                                    bool v282;
                                    v282 = v278 > v279;
                                    if (v282){
                                        v288 = US11_1();
                                    } else {
                                        v288 = US11_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v267 = v288;
                        v266 += 1l ;
                    }
                    bool v289;
                    switch (v267.tag) {
                        case 1: { // Gt
                            v289 = true;
                            break;
                        }
                        default: {
                            v289 = false;
                        }
                    }
                    static_array<Card,5l> v290;
                    if (v289){
                        v290 = v263;
                    } else {
                        v290 = v264;
                    }
                    v295 = US12_1(v290);
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
    static_array<Card,5l> v296;
    long v297; long v298; unsigned char v299;
    Tuple19 tmp60 = Tuple19(0l, 0l, 12u);
    v297 = tmp60.v0; v298 = tmp60.v1; v299 = tmp60.v2;
    while (while_method_10(v297)){
        bool v301;
        v301 = 0l <= v297;
        bool v303;
        if (v301){
            bool v302;
            v302 = v297 < 7l;
            v303 = v302;
        } else {
            v303 = false;
        }
        bool v304;
        v304 = v303 == false;
        if (v304){
            assert("The read index needs to be in range for the static array." && v303);
        } else {
        }
        Card v305;
        v305 = v120.v[v297];
        bool v306;
        v306 = v298 < 5l;
        long v323; unsigned char v324;
        if (v306){
            unsigned char v307;
            v307 = v305.suit;
            bool v308;
            v308 = 2u == v307;
            if (v308){
                unsigned char v309;
                v309 = v305.rank;
                bool v310;
                v310 = v299 == v309;
                long v311;
                if (v310){
                    v311 = v298;
                } else {
                    v311 = 0l;
                }
                bool v312;
                v312 = 0l <= v311;
                bool v314;
                if (v312){
                    bool v313;
                    v313 = v311 < 5l;
                    v314 = v313;
                } else {
                    v314 = false;
                }
                bool v315;
                v315 = v314 == false;
                if (v315){
                    assert("The read index needs to be in range for the static array." && v314);
                } else {
                }
                v296.v[v311] = v305;
                long v316;
                v316 = v311 + 1l;
                unsigned char v317;
                v317 = v305.rank;
                unsigned char v318;
                v318 = v317 - 1u;
                v323 = v316; v324 = v318;
            } else {
                v323 = v298; v324 = v299;
            }
        } else {
            break;
        }
        v298 = v323;
        v299 = v324;
        v297 += 1l ;
    }
    bool v325;
    v325 = v298 == 4l;
    bool v360;
    if (v325){
        unsigned char v326;
        v326 = v299 + 1u;
        bool v327;
        v327 = v326 == 0u;
        if (v327){
            Card v328;
            v328 = v120.v[0l];
            unsigned char v329;
            v329 = v328.suit;
            bool v330;
            v330 = 2u == v329;
            bool v334;
            if (v330){
                unsigned char v331;
                v331 = v328.rank;
                bool v332;
                v332 = v331 == 12u;
                if (v332){
                    v296.v[4l] = v328;
                    v334 = true;
                } else {
                    v334 = false;
                }
            } else {
                v334 = false;
            }
            if (v334){
                v360 = true;
            } else {
                Card v335;
                v335 = v120.v[1l];
                unsigned char v336;
                v336 = v335.suit;
                bool v337;
                v337 = 2u == v336;
                bool v341;
                if (v337){
                    unsigned char v338;
                    v338 = v335.rank;
                    bool v339;
                    v339 = v338 == 12u;
                    if (v339){
                        v296.v[4l] = v335;
                        v341 = true;
                    } else {
                        v341 = false;
                    }
                } else {
                    v341 = false;
                }
                if (v341){
                    v360 = true;
                } else {
                    Card v342;
                    v342 = v120.v[2l];
                    unsigned char v343;
                    v343 = v342.suit;
                    bool v344;
                    v344 = 2u == v343;
                    bool v348;
                    if (v344){
                        unsigned char v345;
                        v345 = v342.rank;
                        bool v346;
                        v346 = v345 == 12u;
                        if (v346){
                            v296.v[4l] = v342;
                            v348 = true;
                        } else {
                            v348 = false;
                        }
                    } else {
                        v348 = false;
                    }
                    if (v348){
                        v360 = true;
                    } else {
                        Card v349;
                        v349 = v120.v[3l];
                        unsigned char v350;
                        v350 = v349.suit;
                        bool v351;
                        v351 = 2u == v350;
                        if (v351){
                            unsigned char v352;
                            v352 = v349.rank;
                            bool v353;
                            v353 = v352 == 12u;
                            if (v353){
                                v296.v[4l] = v349;
                                v360 = true;
                            } else {
                                v360 = false;
                            }
                        } else {
                            v360 = false;
                        }
                    }
                }
            }
        } else {
            v360 = false;
        }
    } else {
        v360 = false;
    }
    US12 v366;
    if (v360){
        v366 = US12_1(v296);
    } else {
        bool v362;
        v362 = v298 == 5l;
        if (v362){
            v366 = US12_1(v296);
        } else {
            v366 = US12_0();
        }
    }
    US12 v399;
    switch (v295.tag) {
        case 0: { // None
            v399 = v366;
            break;
        }
        case 1: { // Some
            static_array<Card,5l> v367 = v295.v.case1.v0;
            switch (v366.tag) {
                case 0: { // None
                    v399 = v295;
                    break;
                }
                case 1: { // Some
                    static_array<Card,5l> v368 = v366.v.case1.v0;
                    US11 v369;
                    v369 = US11_0();
                    long v370; US11 v371;
                    Tuple20 tmp61 = Tuple20(0l, v369);
                    v370 = tmp61.v0; v371 = tmp61.v1;
                    while (while_method_2(v370)){
                        bool v373;
                        v373 = 0l <= v370;
                        bool v375;
                        if (v373){
                            bool v374;
                            v374 = v370 < 5l;
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
                        Card v377;
                        v377 = v367.v[v370];
                        bool v379;
                        if (v373){
                            bool v378;
                            v378 = v370 < 5l;
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
                        Card v381;
                        v381 = v368.v[v370];
                        US11 v392;
                        switch (v371.tag) {
                            case 0: { // Eq
                                unsigned char v382;
                                v382 = v377.rank;
                                unsigned char v383;
                                v383 = v381.rank;
                                bool v384;
                                v384 = v382 < v383;
                                if (v384){
                                    v392 = US11_2();
                                } else {
                                    bool v386;
                                    v386 = v382 > v383;
                                    if (v386){
                                        v392 = US11_1();
                                    } else {
                                        v392 = US11_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v371 = v392;
                        v370 += 1l ;
                    }
                    bool v393;
                    switch (v371.tag) {
                        case 1: { // Gt
                            v393 = true;
                            break;
                        }
                        default: {
                            v393 = false;
                        }
                    }
                    static_array<Card,5l> v394;
                    if (v393){
                        v394 = v367;
                    } else {
                        v394 = v368;
                    }
                    v399 = US12_1(v394);
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
    static_array<Card,5l> v400;
    long v401; long v402; unsigned char v403;
    Tuple19 tmp62 = Tuple19(0l, 0l, 12u);
    v401 = tmp62.v0; v402 = tmp62.v1; v403 = tmp62.v2;
    while (while_method_10(v401)){
        bool v405;
        v405 = 0l <= v401;
        bool v407;
        if (v405){
            bool v406;
            v406 = v401 < 7l;
            v407 = v406;
        } else {
            v407 = false;
        }
        bool v408;
        v408 = v407 == false;
        if (v408){
            assert("The read index needs to be in range for the static array." && v407);
        } else {
        }
        Card v409;
        v409 = v120.v[v401];
        bool v410;
        v410 = v402 < 5l;
        long v427; unsigned char v428;
        if (v410){
            unsigned char v411;
            v411 = v409.suit;
            bool v412;
            v412 = 3u == v411;
            if (v412){
                unsigned char v413;
                v413 = v409.rank;
                bool v414;
                v414 = v403 == v413;
                long v415;
                if (v414){
                    v415 = v402;
                } else {
                    v415 = 0l;
                }
                bool v416;
                v416 = 0l <= v415;
                bool v418;
                if (v416){
                    bool v417;
                    v417 = v415 < 5l;
                    v418 = v417;
                } else {
                    v418 = false;
                }
                bool v419;
                v419 = v418 == false;
                if (v419){
                    assert("The read index needs to be in range for the static array." && v418);
                } else {
                }
                v400.v[v415] = v409;
                long v420;
                v420 = v415 + 1l;
                unsigned char v421;
                v421 = v409.rank;
                unsigned char v422;
                v422 = v421 - 1u;
                v427 = v420; v428 = v422;
            } else {
                v427 = v402; v428 = v403;
            }
        } else {
            break;
        }
        v402 = v427;
        v403 = v428;
        v401 += 1l ;
    }
    bool v429;
    v429 = v402 == 4l;
    bool v464;
    if (v429){
        unsigned char v430;
        v430 = v403 + 1u;
        bool v431;
        v431 = v430 == 0u;
        if (v431){
            Card v432;
            v432 = v120.v[0l];
            unsigned char v433;
            v433 = v432.suit;
            bool v434;
            v434 = 3u == v433;
            bool v438;
            if (v434){
                unsigned char v435;
                v435 = v432.rank;
                bool v436;
                v436 = v435 == 12u;
                if (v436){
                    v400.v[4l] = v432;
                    v438 = true;
                } else {
                    v438 = false;
                }
            } else {
                v438 = false;
            }
            if (v438){
                v464 = true;
            } else {
                Card v439;
                v439 = v120.v[1l];
                unsigned char v440;
                v440 = v439.suit;
                bool v441;
                v441 = 3u == v440;
                bool v445;
                if (v441){
                    unsigned char v442;
                    v442 = v439.rank;
                    bool v443;
                    v443 = v442 == 12u;
                    if (v443){
                        v400.v[4l] = v439;
                        v445 = true;
                    } else {
                        v445 = false;
                    }
                } else {
                    v445 = false;
                }
                if (v445){
                    v464 = true;
                } else {
                    Card v446;
                    v446 = v120.v[2l];
                    unsigned char v447;
                    v447 = v446.suit;
                    bool v448;
                    v448 = 3u == v447;
                    bool v452;
                    if (v448){
                        unsigned char v449;
                        v449 = v446.rank;
                        bool v450;
                        v450 = v449 == 12u;
                        if (v450){
                            v400.v[4l] = v446;
                            v452 = true;
                        } else {
                            v452 = false;
                        }
                    } else {
                        v452 = false;
                    }
                    if (v452){
                        v464 = true;
                    } else {
                        Card v453;
                        v453 = v120.v[3l];
                        unsigned char v454;
                        v454 = v453.suit;
                        bool v455;
                        v455 = 3u == v454;
                        if (v455){
                            unsigned char v456;
                            v456 = v453.rank;
                            bool v457;
                            v457 = v456 == 12u;
                            if (v457){
                                v400.v[4l] = v453;
                                v464 = true;
                            } else {
                                v464 = false;
                            }
                        } else {
                            v464 = false;
                        }
                    }
                }
            }
        } else {
            v464 = false;
        }
    } else {
        v464 = false;
    }
    US12 v470;
    if (v464){
        v470 = US12_1(v400);
    } else {
        bool v466;
        v466 = v402 == 5l;
        if (v466){
            v470 = US12_1(v400);
        } else {
            v470 = US12_0();
        }
    }
    US12 v503;
    switch (v399.tag) {
        case 0: { // None
            v503 = v470;
            break;
        }
        case 1: { // Some
            static_array<Card,5l> v471 = v399.v.case1.v0;
            switch (v470.tag) {
                case 0: { // None
                    v503 = v399;
                    break;
                }
                case 1: { // Some
                    static_array<Card,5l> v472 = v470.v.case1.v0;
                    US11 v473;
                    v473 = US11_0();
                    long v474; US11 v475;
                    Tuple20 tmp63 = Tuple20(0l, v473);
                    v474 = tmp63.v0; v475 = tmp63.v1;
                    while (while_method_2(v474)){
                        bool v477;
                        v477 = 0l <= v474;
                        bool v479;
                        if (v477){
                            bool v478;
                            v478 = v474 < 5l;
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
                        Card v481;
                        v481 = v471.v[v474];
                        bool v483;
                        if (v477){
                            bool v482;
                            v482 = v474 < 5l;
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
                        Card v485;
                        v485 = v472.v[v474];
                        US11 v496;
                        switch (v475.tag) {
                            case 0: { // Eq
                                unsigned char v486;
                                v486 = v481.rank;
                                unsigned char v487;
                                v487 = v485.rank;
                                bool v488;
                                v488 = v486 < v487;
                                if (v488){
                                    v496 = US11_2();
                                } else {
                                    bool v490;
                                    v490 = v486 > v487;
                                    if (v490){
                                        v496 = US11_1();
                                    } else {
                                        v496 = US11_0();
                                    }
                                }
                                break;
                            }
                            default: {
                                break;
                            }
                        }
                        v475 = v496;
                        v474 += 1l ;
                    }
                    bool v497;
                    switch (v475.tag) {
                        case 1: { // Gt
                            v497 = true;
                            break;
                        }
                        default: {
                            v497 = false;
                        }
                    }
                    static_array<Card,5l> v498;
                    if (v497){
                        v498 = v471;
                    } else {
                        v498 = v472;
                    }
                    v503 = US12_1(v498);
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
    static_array<Card,5l> v1330; char v1331;
    switch (v503.tag) {
        case 0: { // None
            static_array<Card,4l> v505;
            static_array<Card,3l> v506;
            long v507; long v508; long v509; unsigned char v510;
            Tuple21 tmp64 = Tuple21(0l, 0l, 0l, 12u);
            v507 = tmp64.v0; v508 = tmp64.v1; v509 = tmp64.v2; v510 = tmp64.v3;
            while (while_method_10(v507)){
                bool v512;
                v512 = 0l <= v507;
                bool v514;
                if (v512){
                    bool v513;
                    v513 = v507 < 7l;
                    v514 = v513;
                } else {
                    v514 = false;
                }
                bool v515;
                v515 = v514 == false;
                if (v515){
                    assert("The read index needs to be in range for the static array." && v514);
                } else {
                }
                Card v516;
                v516 = v120.v[v507];
                bool v517;
                v517 = v509 < 4l;
                long v530; long v531; unsigned char v532;
                if (v517){
                    unsigned char v518;
                    v518 = v516.rank;
                    bool v519;
                    v519 = v510 == v518;
                    long v520;
                    if (v519){
                        v520 = v509;
                    } else {
                        v520 = 0l;
                    }
                    bool v521;
                    v521 = 0l <= v520;
                    bool v523;
                    if (v521){
                        bool v522;
                        v522 = v520 < 4l;
                        v523 = v522;
                    } else {
                        v523 = false;
                    }
                    bool v524;
                    v524 = v523 == false;
                    if (v524){
                        assert("The read index needs to be in range for the static array." && v523);
                    } else {
                    }
                    v505.v[v520] = v516;
                    long v525;
                    v525 = v520 + 1l;
                    unsigned char v526;
                    v526 = v516.rank;
                    v530 = v507; v531 = v525; v532 = v526;
                } else {
                    break;
                }
                v508 = v530;
                v509 = v531;
                v510 = v532;
                v507 += 1l ;
            }
            bool v533;
            v533 = v509 == 4l;
            US13 v551;
            if (v533){
                long v534;
                v534 = 0l;
                while (while_method_3(v534)){
                    long v536;
                    v536 = v508 + -3l;
                    bool v537;
                    v537 = v534 < v536;
                    long v538;
                    if (v537){
                        v538 = 0l;
                    } else {
                        v538 = 4l;
                    }
                    long v539;
                    v539 = v538 + v534;
                    bool v540;
                    v540 = 0l <= v539;
                    bool v542;
                    if (v540){
                        bool v541;
                        v541 = v539 < 7l;
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
                    Card v544;
                    v544 = v120.v[v539];
                    bool v545;
                    v545 = 0l <= v534;
                    bool v547;
                    if (v545){
                        bool v546;
                        v546 = v534 < 3l;
                        v547 = v546;
                    } else {
                        v547 = false;
                    }
                    bool v548;
                    v548 = v547 == false;
                    if (v548){
                        assert("The read index needs to be in range for the static array." && v547);
                    } else {
                    }
                    v506.v[v534] = v544;
                    v534 += 1l ;
                }
                v551 = US13_1(v505, v506);
            } else {
                v551 = US13_0();
            }
            US12 v591;
            switch (v551.tag) {
                case 0: { // None
                    v591 = US12_0();
                    break;
                }
                case 1: { // Some
                    static_array<Card,4l> v552 = v551.v.case1.v0; static_array<Card,3l> v553 = v551.v.case1.v1;
                    static_array<Card,1l> v554;
                    long v555;
                    v555 = 0l;
                    while (while_method_6(v555)){
                        bool v557;
                        v557 = 0l <= v555;
                        bool v559;
                        if (v557){
                            bool v558;
                            v558 = v555 < 3l;
                            v559 = v558;
                        } else {
                            v559 = false;
                        }
                        bool v560;
                        v560 = v559 == false;
                        if (v560){
                            assert("The read index needs to be in range for the static array." && v559);
                        } else {
                        }
                        Card v561;
                        v561 = v553.v[v555];
                        bool v563;
                        if (v557){
                            bool v562;
                            v562 = v555 < 1l;
                            v563 = v562;
                        } else {
                            v563 = false;
                        }
                        bool v564;
                        v564 = v563 == false;
                        if (v564){
                            assert("The read index needs to be in range for the static array." && v563);
                        } else {
                        }
                        v554.v[v555] = v561;
                        v555 += 1l ;
                    }
                    static_array<Card,5l> v565;
                    long v566;
                    v566 = 0l;
                    while (while_method_4(v566)){
                        bool v568;
                        v568 = 0l <= v566;
                        bool v570;
                        if (v568){
                            bool v569;
                            v569 = v566 < 4l;
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
                        Card v572;
                        v572 = v552.v[v566];
                        bool v574;
                        if (v568){
                            bool v573;
                            v573 = v566 < 5l;
                            v574 = v573;
                        } else {
                            v574 = false;
                        }
                        bool v575;
                        v575 = v574 == false;
                        if (v575){
                            assert("The read index needs to be in range for the static array." && v574);
                        } else {
                        }
                        v565.v[v566] = v572;
                        v566 += 1l ;
                    }
                    long v576;
                    v576 = 0l;
                    while (while_method_6(v576)){
                        bool v578;
                        v578 = 0l <= v576;
                        bool v580;
                        if (v578){
                            bool v579;
                            v579 = v576 < 1l;
                            v580 = v579;
                        } else {
                            v580 = false;
                        }
                        bool v581;
                        v581 = v580 == false;
                        if (v581){
                            assert("The read index needs to be in range for the static array." && v580);
                        } else {
                        }
                        Card v582;
                        v582 = v554.v[v576];
                        long v583;
                        v583 = 4l + v576;
                        bool v584;
                        v584 = 0l <= v583;
                        bool v586;
                        if (v584){
                            bool v585;
                            v585 = v583 < 5l;
                            v586 = v585;
                        } else {
                            v586 = false;
                        }
                        bool v587;
                        v587 = v586 == false;
                        if (v587){
                            assert("The read index needs to be in range for the static array." && v586);
                        } else {
                        }
                        v565.v[v583] = v582;
                        v576 += 1l ;
                    }
                    v591 = US12_1(v565);
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            switch (v591.tag) {
                case 0: { // None
                    static_array<Card,3l> v593;
                    static_array<Card,4l> v594;
                    long v595; long v596; long v597; unsigned char v598;
                    Tuple21 tmp65 = Tuple21(0l, 0l, 0l, 12u);
                    v595 = tmp65.v0; v596 = tmp65.v1; v597 = tmp65.v2; v598 = tmp65.v3;
                    while (while_method_10(v595)){
                        bool v600;
                        v600 = 0l <= v595;
                        bool v602;
                        if (v600){
                            bool v601;
                            v601 = v595 < 7l;
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
                        Card v604;
                        v604 = v120.v[v595];
                        bool v605;
                        v605 = v597 < 3l;
                        long v618; long v619; unsigned char v620;
                        if (v605){
                            unsigned char v606;
                            v606 = v604.rank;
                            bool v607;
                            v607 = v598 == v606;
                            long v608;
                            if (v607){
                                v608 = v597;
                            } else {
                                v608 = 0l;
                            }
                            bool v609;
                            v609 = 0l <= v608;
                            bool v611;
                            if (v609){
                                bool v610;
                                v610 = v608 < 3l;
                                v611 = v610;
                            } else {
                                v611 = false;
                            }
                            bool v612;
                            v612 = v611 == false;
                            if (v612){
                                assert("The read index needs to be in range for the static array." && v611);
                            } else {
                            }
                            v593.v[v608] = v604;
                            long v613;
                            v613 = v608 + 1l;
                            unsigned char v614;
                            v614 = v604.rank;
                            v618 = v595; v619 = v613; v620 = v614;
                        } else {
                            break;
                        }
                        v596 = v618;
                        v597 = v619;
                        v598 = v620;
                        v595 += 1l ;
                    }
                    bool v621;
                    v621 = v597 == 3l;
                    US14 v639;
                    if (v621){
                        long v622;
                        v622 = 0l;
                        while (while_method_4(v622)){
                            long v624;
                            v624 = v596 + -2l;
                            bool v625;
                            v625 = v622 < v624;
                            long v626;
                            if (v625){
                                v626 = 0l;
                            } else {
                                v626 = 3l;
                            }
                            long v627;
                            v627 = v626 + v622;
                            bool v628;
                            v628 = 0l <= v627;
                            bool v630;
                            if (v628){
                                bool v629;
                                v629 = v627 < 7l;
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
                            Card v632;
                            v632 = v120.v[v627];
                            bool v633;
                            v633 = 0l <= v622;
                            bool v635;
                            if (v633){
                                bool v634;
                                v634 = v622 < 4l;
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
                            v594.v[v622] = v632;
                            v622 += 1l ;
                        }
                        v639 = US14_1(v593, v594);
                    } else {
                        v639 = US14_0();
                    }
                    US12 v720;
                    switch (v639.tag) {
                        case 0: { // None
                            v720 = US12_0();
                            break;
                        }
                        case 1: { // Some
                            static_array<Card,3l> v640 = v639.v.case1.v0; static_array<Card,4l> v641 = v639.v.case1.v1;
                            static_array<Card,2l> v642;
                            static_array<Card,2l> v643;
                            long v644; long v645; long v646; unsigned char v647;
                            Tuple21 tmp66 = Tuple21(0l, 0l, 0l, 12u);
                            v644 = tmp66.v0; v645 = tmp66.v1; v646 = tmp66.v2; v647 = tmp66.v3;
                            while (while_method_4(v644)){
                                bool v649;
                                v649 = 0l <= v644;
                                bool v651;
                                if (v649){
                                    bool v650;
                                    v650 = v644 < 4l;
                                    v651 = v650;
                                } else {
                                    v651 = false;
                                }
                                bool v652;
                                v652 = v651 == false;
                                if (v652){
                                    assert("The read index needs to be in range for the static array." && v651);
                                } else {
                                }
                                Card v653;
                                v653 = v641.v[v644];
                                bool v654;
                                v654 = v646 < 2l;
                                long v667; long v668; unsigned char v669;
                                if (v654){
                                    unsigned char v655;
                                    v655 = v653.rank;
                                    bool v656;
                                    v656 = v647 == v655;
                                    long v657;
                                    if (v656){
                                        v657 = v646;
                                    } else {
                                        v657 = 0l;
                                    }
                                    bool v658;
                                    v658 = 0l <= v657;
                                    bool v660;
                                    if (v658){
                                        bool v659;
                                        v659 = v657 < 2l;
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
                                    v642.v[v657] = v653;
                                    long v662;
                                    v662 = v657 + 1l;
                                    unsigned char v663;
                                    v663 = v653.rank;
                                    v667 = v644; v668 = v662; v669 = v663;
                                } else {
                                    break;
                                }
                                v645 = v667;
                                v646 = v668;
                                v647 = v669;
                                v644 += 1l ;
                            }
                            bool v670;
                            v670 = v646 == 2l;
                            US15 v688;
                            if (v670){
                                long v671;
                                v671 = 0l;
                                while (while_method_0(v671)){
                                    long v673;
                                    v673 = v645 + -1l;
                                    bool v674;
                                    v674 = v671 < v673;
                                    long v675;
                                    if (v674){
                                        v675 = 0l;
                                    } else {
                                        v675 = 2l;
                                    }
                                    long v676;
                                    v676 = v675 + v671;
                                    bool v677;
                                    v677 = 0l <= v676;
                                    bool v679;
                                    if (v677){
                                        bool v678;
                                        v678 = v676 < 4l;
                                        v679 = v678;
                                    } else {
                                        v679 = false;
                                    }
                                    bool v680;
                                    v680 = v679 == false;
                                    if (v680){
                                        assert("The read index needs to be in range for the static array." && v679);
                                    } else {
                                    }
                                    Card v681;
                                    v681 = v641.v[v676];
                                    bool v682;
                                    v682 = 0l <= v671;
                                    bool v684;
                                    if (v682){
                                        bool v683;
                                        v683 = v671 < 2l;
                                        v684 = v683;
                                    } else {
                                        v684 = false;
                                    }
                                    bool v685;
                                    v685 = v684 == false;
                                    if (v685){
                                        assert("The read index needs to be in range for the static array." && v684);
                                    } else {
                                    }
                                    v643.v[v671] = v681;
                                    v671 += 1l ;
                                }
                                v688 = US15_1(v642, v643);
                            } else {
                                v688 = US15_0();
                            }
                            switch (v688.tag) {
                                case 0: { // None
                                    v720 = US12_0();
                                    break;
                                }
                                case 1: { // Some
                                    static_array<Card,2l> v689 = v688.v.case1.v0; static_array<Card,2l> v690 = v688.v.case1.v1;
                                    static_array<Card,5l> v691;
                                    long v692;
                                    v692 = 0l;
                                    while (while_method_3(v692)){
                                        bool v694;
                                        v694 = 0l <= v692;
                                        bool v696;
                                        if (v694){
                                            bool v695;
                                            v695 = v692 < 3l;
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
                                        Card v698;
                                        v698 = v640.v[v692];
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
                                    while (while_method_0(v702)){
                                        bool v704;
                                        v704 = 0l <= v702;
                                        bool v706;
                                        if (v704){
                                            bool v705;
                                            v705 = v702 < 2l;
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
                                        Card v708;
                                        v708 = v689.v[v702];
                                        long v709;
                                        v709 = 3l + v702;
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
                                    v720 = US12_1(v691);
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
                    switch (v720.tag) {
                        case 0: { // None
                            static_array<Card,5l> v722;
                            long v723; long v724;
                            Tuple2 tmp67 = Tuple2(0l, 0l);
                            v723 = tmp67.v0; v724 = tmp67.v1;
                            while (while_method_10(v723)){
                                bool v726;
                                v726 = 0l <= v723;
                                bool v728;
                                if (v726){
                                    bool v727;
                                    v727 = v723 < 7l;
                                    v728 = v727;
                                } else {
                                    v728 = false;
                                }
                                bool v729;
                                v729 = v728 == false;
                                if (v729){
                                    assert("The read index needs to be in range for the static array." && v728);
                                } else {
                                }
                                Card v730;
                                v730 = v120.v[v723];
                                unsigned char v731;
                                v731 = v730.suit;
                                bool v732;
                                v732 = v731 == 0u;
                                bool v734;
                                if (v732){
                                    bool v733;
                                    v733 = v724 < 5l;
                                    v734 = v733;
                                } else {
                                    v734 = false;
                                }
                                long v740;
                                if (v734){
                                    bool v735;
                                    v735 = 0l <= v724;
                                    bool v737;
                                    if (v735){
                                        bool v736;
                                        v736 = v724 < 5l;
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
                                    v722.v[v724] = v730;
                                    long v739;
                                    v739 = v724 + 1l;
                                    v740 = v739;
                                } else {
                                    v740 = v724;
                                }
                                v724 = v740;
                                v723 += 1l ;
                            }
                            bool v741;
                            v741 = v724 == 5l;
                            US12 v744;
                            if (v741){
                                v744 = US12_1(v722);
                            } else {
                                v744 = US12_0();
                            }
                            static_array<Card,5l> v745;
                            long v746; long v747;
                            Tuple2 tmp68 = Tuple2(0l, 0l);
                            v746 = tmp68.v0; v747 = tmp68.v1;
                            while (while_method_10(v746)){
                                bool v749;
                                v749 = 0l <= v746;
                                bool v751;
                                if (v749){
                                    bool v750;
                                    v750 = v746 < 7l;
                                    v751 = v750;
                                } else {
                                    v751 = false;
                                }
                                bool v752;
                                v752 = v751 == false;
                                if (v752){
                                    assert("The read index needs to be in range for the static array." && v751);
                                } else {
                                }
                                Card v753;
                                v753 = v120.v[v746];
                                unsigned char v754;
                                v754 = v753.suit;
                                bool v755;
                                v755 = v754 == 1u;
                                bool v757;
                                if (v755){
                                    bool v756;
                                    v756 = v747 < 5l;
                                    v757 = v756;
                                } else {
                                    v757 = false;
                                }
                                long v763;
                                if (v757){
                                    bool v758;
                                    v758 = 0l <= v747;
                                    bool v760;
                                    if (v758){
                                        bool v759;
                                        v759 = v747 < 5l;
                                        v760 = v759;
                                    } else {
                                        v760 = false;
                                    }
                                    bool v761;
                                    v761 = v760 == false;
                                    if (v761){
                                        assert("The read index needs to be in range for the static array." && v760);
                                    } else {
                                    }
                                    v745.v[v747] = v753;
                                    long v762;
                                    v762 = v747 + 1l;
                                    v763 = v762;
                                } else {
                                    v763 = v747;
                                }
                                v747 = v763;
                                v746 += 1l ;
                            }
                            bool v764;
                            v764 = v747 == 5l;
                            US12 v767;
                            if (v764){
                                v767 = US12_1(v745);
                            } else {
                                v767 = US12_0();
                            }
                            US12 v800;
                            switch (v744.tag) {
                                case 0: { // None
                                    v800 = v767;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<Card,5l> v768 = v744.v.case1.v0;
                                    switch (v767.tag) {
                                        case 0: { // None
                                            v800 = v744;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<Card,5l> v769 = v767.v.case1.v0;
                                            US11 v770;
                                            v770 = US11_0();
                                            long v771; US11 v772;
                                            Tuple20 tmp69 = Tuple20(0l, v770);
                                            v771 = tmp69.v0; v772 = tmp69.v1;
                                            while (while_method_2(v771)){
                                                bool v774;
                                                v774 = 0l <= v771;
                                                bool v776;
                                                if (v774){
                                                    bool v775;
                                                    v775 = v771 < 5l;
                                                    v776 = v775;
                                                } else {
                                                    v776 = false;
                                                }
                                                bool v777;
                                                v777 = v776 == false;
                                                if (v777){
                                                    assert("The read index needs to be in range for the static array." && v776);
                                                } else {
                                                }
                                                Card v778;
                                                v778 = v768.v[v771];
                                                bool v780;
                                                if (v774){
                                                    bool v779;
                                                    v779 = v771 < 5l;
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
                                                Card v782;
                                                v782 = v769.v[v771];
                                                US11 v793;
                                                switch (v772.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v783;
                                                        v783 = v778.rank;
                                                        unsigned char v784;
                                                        v784 = v782.rank;
                                                        bool v785;
                                                        v785 = v783 < v784;
                                                        if (v785){
                                                            v793 = US11_2();
                                                        } else {
                                                            bool v787;
                                                            v787 = v783 > v784;
                                                            if (v787){
                                                                v793 = US11_1();
                                                            } else {
                                                                v793 = US11_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v772 = v793;
                                                v771 += 1l ;
                                            }
                                            bool v794;
                                            switch (v772.tag) {
                                                case 1: { // Gt
                                                    v794 = true;
                                                    break;
                                                }
                                                default: {
                                                    v794 = false;
                                                }
                                            }
                                            static_array<Card,5l> v795;
                                            if (v794){
                                                v795 = v768;
                                            } else {
                                                v795 = v769;
                                            }
                                            v800 = US12_1(v795);
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
                            static_array<Card,5l> v801;
                            long v802; long v803;
                            Tuple2 tmp70 = Tuple2(0l, 0l);
                            v802 = tmp70.v0; v803 = tmp70.v1;
                            while (while_method_10(v802)){
                                bool v805;
                                v805 = 0l <= v802;
                                bool v807;
                                if (v805){
                                    bool v806;
                                    v806 = v802 < 7l;
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
                                Card v809;
                                v809 = v120.v[v802];
                                unsigned char v810;
                                v810 = v809.suit;
                                bool v811;
                                v811 = v810 == 2u;
                                bool v813;
                                if (v811){
                                    bool v812;
                                    v812 = v803 < 5l;
                                    v813 = v812;
                                } else {
                                    v813 = false;
                                }
                                long v819;
                                if (v813){
                                    bool v814;
                                    v814 = 0l <= v803;
                                    bool v816;
                                    if (v814){
                                        bool v815;
                                        v815 = v803 < 5l;
                                        v816 = v815;
                                    } else {
                                        v816 = false;
                                    }
                                    bool v817;
                                    v817 = v816 == false;
                                    if (v817){
                                        assert("The read index needs to be in range for the static array." && v816);
                                    } else {
                                    }
                                    v801.v[v803] = v809;
                                    long v818;
                                    v818 = v803 + 1l;
                                    v819 = v818;
                                } else {
                                    v819 = v803;
                                }
                                v803 = v819;
                                v802 += 1l ;
                            }
                            bool v820;
                            v820 = v803 == 5l;
                            US12 v823;
                            if (v820){
                                v823 = US12_1(v801);
                            } else {
                                v823 = US12_0();
                            }
                            US12 v856;
                            switch (v800.tag) {
                                case 0: { // None
                                    v856 = v823;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<Card,5l> v824 = v800.v.case1.v0;
                                    switch (v823.tag) {
                                        case 0: { // None
                                            v856 = v800;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<Card,5l> v825 = v823.v.case1.v0;
                                            US11 v826;
                                            v826 = US11_0();
                                            long v827; US11 v828;
                                            Tuple20 tmp71 = Tuple20(0l, v826);
                                            v827 = tmp71.v0; v828 = tmp71.v1;
                                            while (while_method_2(v827)){
                                                bool v830;
                                                v830 = 0l <= v827;
                                                bool v832;
                                                if (v830){
                                                    bool v831;
                                                    v831 = v827 < 5l;
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
                                                Card v834;
                                                v834 = v824.v[v827];
                                                bool v836;
                                                if (v830){
                                                    bool v835;
                                                    v835 = v827 < 5l;
                                                    v836 = v835;
                                                } else {
                                                    v836 = false;
                                                }
                                                bool v837;
                                                v837 = v836 == false;
                                                if (v837){
                                                    assert("The read index needs to be in range for the static array." && v836);
                                                } else {
                                                }
                                                Card v838;
                                                v838 = v825.v[v827];
                                                US11 v849;
                                                switch (v828.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v839;
                                                        v839 = v834.rank;
                                                        unsigned char v840;
                                                        v840 = v838.rank;
                                                        bool v841;
                                                        v841 = v839 < v840;
                                                        if (v841){
                                                            v849 = US11_2();
                                                        } else {
                                                            bool v843;
                                                            v843 = v839 > v840;
                                                            if (v843){
                                                                v849 = US11_1();
                                                            } else {
                                                                v849 = US11_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v828 = v849;
                                                v827 += 1l ;
                                            }
                                            bool v850;
                                            switch (v828.tag) {
                                                case 1: { // Gt
                                                    v850 = true;
                                                    break;
                                                }
                                                default: {
                                                    v850 = false;
                                                }
                                            }
                                            static_array<Card,5l> v851;
                                            if (v850){
                                                v851 = v824;
                                            } else {
                                                v851 = v825;
                                            }
                                            v856 = US12_1(v851);
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
                            static_array<Card,5l> v857;
                            long v858; long v859;
                            Tuple2 tmp72 = Tuple2(0l, 0l);
                            v858 = tmp72.v0; v859 = tmp72.v1;
                            while (while_method_10(v858)){
                                bool v861;
                                v861 = 0l <= v858;
                                bool v863;
                                if (v861){
                                    bool v862;
                                    v862 = v858 < 7l;
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
                                Card v865;
                                v865 = v120.v[v858];
                                unsigned char v866;
                                v866 = v865.suit;
                                bool v867;
                                v867 = v866 == 3u;
                                bool v869;
                                if (v867){
                                    bool v868;
                                    v868 = v859 < 5l;
                                    v869 = v868;
                                } else {
                                    v869 = false;
                                }
                                long v875;
                                if (v869){
                                    bool v870;
                                    v870 = 0l <= v859;
                                    bool v872;
                                    if (v870){
                                        bool v871;
                                        v871 = v859 < 5l;
                                        v872 = v871;
                                    } else {
                                        v872 = false;
                                    }
                                    bool v873;
                                    v873 = v872 == false;
                                    if (v873){
                                        assert("The read index needs to be in range for the static array." && v872);
                                    } else {
                                    }
                                    v857.v[v859] = v865;
                                    long v874;
                                    v874 = v859 + 1l;
                                    v875 = v874;
                                } else {
                                    v875 = v859;
                                }
                                v859 = v875;
                                v858 += 1l ;
                            }
                            bool v876;
                            v876 = v859 == 5l;
                            US12 v879;
                            if (v876){
                                v879 = US12_1(v857);
                            } else {
                                v879 = US12_0();
                            }
                            US12 v912;
                            switch (v856.tag) {
                                case 0: { // None
                                    v912 = v879;
                                    break;
                                }
                                case 1: { // Some
                                    static_array<Card,5l> v880 = v856.v.case1.v0;
                                    switch (v879.tag) {
                                        case 0: { // None
                                            v912 = v856;
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<Card,5l> v881 = v879.v.case1.v0;
                                            US11 v882;
                                            v882 = US11_0();
                                            long v883; US11 v884;
                                            Tuple20 tmp73 = Tuple20(0l, v882);
                                            v883 = tmp73.v0; v884 = tmp73.v1;
                                            while (while_method_2(v883)){
                                                bool v886;
                                                v886 = 0l <= v883;
                                                bool v888;
                                                if (v886){
                                                    bool v887;
                                                    v887 = v883 < 5l;
                                                    v888 = v887;
                                                } else {
                                                    v888 = false;
                                                }
                                                bool v889;
                                                v889 = v888 == false;
                                                if (v889){
                                                    assert("The read index needs to be in range for the static array." && v888);
                                                } else {
                                                }
                                                Card v890;
                                                v890 = v880.v[v883];
                                                bool v892;
                                                if (v886){
                                                    bool v891;
                                                    v891 = v883 < 5l;
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
                                                Card v894;
                                                v894 = v881.v[v883];
                                                US11 v905;
                                                switch (v884.tag) {
                                                    case 0: { // Eq
                                                        unsigned char v895;
                                                        v895 = v890.rank;
                                                        unsigned char v896;
                                                        v896 = v894.rank;
                                                        bool v897;
                                                        v897 = v895 < v896;
                                                        if (v897){
                                                            v905 = US11_2();
                                                        } else {
                                                            bool v899;
                                                            v899 = v895 > v896;
                                                            if (v899){
                                                                v905 = US11_1();
                                                            } else {
                                                                v905 = US11_0();
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    default: {
                                                        break;
                                                    }
                                                }
                                                v884 = v905;
                                                v883 += 1l ;
                                            }
                                            bool v906;
                                            switch (v884.tag) {
                                                case 1: { // Gt
                                                    v906 = true;
                                                    break;
                                                }
                                                default: {
                                                    v906 = false;
                                                }
                                            }
                                            static_array<Card,5l> v907;
                                            if (v906){
                                                v907 = v880;
                                            } else {
                                                v907 = v881;
                                            }
                                            v912 = US12_1(v907);
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
                            switch (v912.tag) {
                                case 0: { // None
                                    static_array<Card,5l> v914;
                                    long v915; long v916; unsigned char v917;
                                    Tuple19 tmp74 = Tuple19(0l, 0l, 12u);
                                    v915 = tmp74.v0; v916 = tmp74.v1; v917 = tmp74.v2;
                                    while (while_method_10(v915)){
                                        bool v919;
                                        v919 = 0l <= v915;
                                        bool v921;
                                        if (v919){
                                            bool v920;
                                            v920 = v915 < 7l;
                                            v921 = v920;
                                        } else {
                                            v921 = false;
                                        }
                                        bool v922;
                                        v922 = v921 == false;
                                        if (v922){
                                            assert("The read index needs to be in range for the static array." && v921);
                                        } else {
                                        }
                                        Card v923;
                                        v923 = v120.v[v915];
                                        bool v924;
                                        v924 = v916 < 5l;
                                        long v943; unsigned char v944;
                                        if (v924){
                                            unsigned char v925;
                                            v925 = v923.rank;
                                            unsigned char v926;
                                            v926 = v925 - 1u;
                                            bool v927;
                                            v927 = v917 == v926;
                                            bool v928;
                                            v928 = v927 != true;
                                            if (v928){
                                                unsigned char v929;
                                                v929 = v923.rank;
                                                bool v930;
                                                v930 = v917 == v929;
                                                long v931;
                                                if (v930){
                                                    v931 = v916;
                                                } else {
                                                    v931 = 0l;
                                                }
                                                bool v932;
                                                v932 = 0l <= v931;
                                                bool v934;
                                                if (v932){
                                                    bool v933;
                                                    v933 = v931 < 5l;
                                                    v934 = v933;
                                                } else {
                                                    v934 = false;
                                                }
                                                bool v935;
                                                v935 = v934 == false;
                                                if (v935){
                                                    assert("The read index needs to be in range for the static array." && v934);
                                                } else {
                                                }
                                                v914.v[v931] = v923;
                                                long v936;
                                                v936 = v931 + 1l;
                                                unsigned char v937;
                                                v937 = v923.rank;
                                                unsigned char v938;
                                                v938 = v937 - 1u;
                                                v943 = v936; v944 = v938;
                                            } else {
                                                v943 = v916; v944 = v917;
                                            }
                                        } else {
                                            break;
                                        }
                                        v916 = v943;
                                        v917 = v944;
                                        v915 += 1l ;
                                    }
                                    bool v945;
                                    v945 = v916 == 4l;
                                    bool v953;
                                    if (v945){
                                        unsigned char v946;
                                        v946 = v917 + 1u;
                                        bool v947;
                                        v947 = v946 == 0u;
                                        if (v947){
                                            Card v948;
                                            v948 = v120.v[0l];
                                            unsigned char v949;
                                            v949 = v948.rank;
                                            bool v950;
                                            v950 = v949 == 12u;
                                            if (v950){
                                                v914.v[4l] = v948;
                                                v953 = true;
                                            } else {
                                                v953 = false;
                                            }
                                        } else {
                                            v953 = false;
                                        }
                                    } else {
                                        v953 = false;
                                    }
                                    US12 v959;
                                    if (v953){
                                        v959 = US12_1(v914);
                                    } else {
                                        bool v955;
                                        v955 = v916 == 5l;
                                        if (v955){
                                            v959 = US12_1(v914);
                                        } else {
                                            v959 = US12_0();
                                        }
                                    }
                                    switch (v959.tag) {
                                        case 0: { // None
                                            static_array<Card,3l> v961;
                                            static_array<Card,4l> v962;
                                            long v963; long v964; long v965; unsigned char v966;
                                            Tuple21 tmp75 = Tuple21(0l, 0l, 0l, 12u);
                                            v963 = tmp75.v0; v964 = tmp75.v1; v965 = tmp75.v2; v966 = tmp75.v3;
                                            while (while_method_10(v963)){
                                                bool v968;
                                                v968 = 0l <= v963;
                                                bool v970;
                                                if (v968){
                                                    bool v969;
                                                    v969 = v963 < 7l;
                                                    v970 = v969;
                                                } else {
                                                    v970 = false;
                                                }
                                                bool v971;
                                                v971 = v970 == false;
                                                if (v971){
                                                    assert("The read index needs to be in range for the static array." && v970);
                                                } else {
                                                }
                                                Card v972;
                                                v972 = v120.v[v963];
                                                bool v973;
                                                v973 = v965 < 3l;
                                                long v986; long v987; unsigned char v988;
                                                if (v973){
                                                    unsigned char v974;
                                                    v974 = v972.rank;
                                                    bool v975;
                                                    v975 = v966 == v974;
                                                    long v976;
                                                    if (v975){
                                                        v976 = v965;
                                                    } else {
                                                        v976 = 0l;
                                                    }
                                                    bool v977;
                                                    v977 = 0l <= v976;
                                                    bool v979;
                                                    if (v977){
                                                        bool v978;
                                                        v978 = v976 < 3l;
                                                        v979 = v978;
                                                    } else {
                                                        v979 = false;
                                                    }
                                                    bool v980;
                                                    v980 = v979 == false;
                                                    if (v980){
                                                        assert("The read index needs to be in range for the static array." && v979);
                                                    } else {
                                                    }
                                                    v961.v[v976] = v972;
                                                    long v981;
                                                    v981 = v976 + 1l;
                                                    unsigned char v982;
                                                    v982 = v972.rank;
                                                    v986 = v963; v987 = v981; v988 = v982;
                                                } else {
                                                    break;
                                                }
                                                v964 = v986;
                                                v965 = v987;
                                                v966 = v988;
                                                v963 += 1l ;
                                            }
                                            bool v989;
                                            v989 = v965 == 3l;
                                            US14 v1007;
                                            if (v989){
                                                long v990;
                                                v990 = 0l;
                                                while (while_method_4(v990)){
                                                    long v992;
                                                    v992 = v964 + -2l;
                                                    bool v993;
                                                    v993 = v990 < v992;
                                                    long v994;
                                                    if (v993){
                                                        v994 = 0l;
                                                    } else {
                                                        v994 = 3l;
                                                    }
                                                    long v995;
                                                    v995 = v994 + v990;
                                                    bool v996;
                                                    v996 = 0l <= v995;
                                                    bool v998;
                                                    if (v996){
                                                        bool v997;
                                                        v997 = v995 < 7l;
                                                        v998 = v997;
                                                    } else {
                                                        v998 = false;
                                                    }
                                                    bool v999;
                                                    v999 = v998 == false;
                                                    if (v999){
                                                        assert("The read index needs to be in range for the static array." && v998);
                                                    } else {
                                                    }
                                                    Card v1000;
                                                    v1000 = v120.v[v995];
                                                    bool v1001;
                                                    v1001 = 0l <= v990;
                                                    bool v1003;
                                                    if (v1001){
                                                        bool v1002;
                                                        v1002 = v990 < 4l;
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
                                                    v962.v[v990] = v1000;
                                                    v990 += 1l ;
                                                }
                                                v1007 = US14_1(v961, v962);
                                            } else {
                                                v1007 = US14_0();
                                            }
                                            US12 v1047;
                                            switch (v1007.tag) {
                                                case 0: { // None
                                                    v1047 = US12_0();
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<Card,3l> v1008 = v1007.v.case1.v0; static_array<Card,4l> v1009 = v1007.v.case1.v1;
                                                    static_array<Card,2l> v1010;
                                                    long v1011;
                                                    v1011 = 0l;
                                                    while (while_method_0(v1011)){
                                                        bool v1013;
                                                        v1013 = 0l <= v1011;
                                                        bool v1015;
                                                        if (v1013){
                                                            bool v1014;
                                                            v1014 = v1011 < 4l;
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
                                                        Card v1017;
                                                        v1017 = v1009.v[v1011];
                                                        bool v1019;
                                                        if (v1013){
                                                            bool v1018;
                                                            v1018 = v1011 < 2l;
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
                                                    static_array<Card,5l> v1021;
                                                    long v1022;
                                                    v1022 = 0l;
                                                    while (while_method_3(v1022)){
                                                        bool v1024;
                                                        v1024 = 0l <= v1022;
                                                        bool v1026;
                                                        if (v1024){
                                                            bool v1025;
                                                            v1025 = v1022 < 3l;
                                                            v1026 = v1025;
                                                        } else {
                                                            v1026 = false;
                                                        }
                                                        bool v1027;
                                                        v1027 = v1026 == false;
                                                        if (v1027){
                                                            assert("The read index needs to be in range for the static array." && v1026);
                                                        } else {
                                                        }
                                                        Card v1028;
                                                        v1028 = v1008.v[v1022];
                                                        bool v1030;
                                                        if (v1024){
                                                            bool v1029;
                                                            v1029 = v1022 < 5l;
                                                            v1030 = v1029;
                                                        } else {
                                                            v1030 = false;
                                                        }
                                                        bool v1031;
                                                        v1031 = v1030 == false;
                                                        if (v1031){
                                                            assert("The read index needs to be in range for the static array." && v1030);
                                                        } else {
                                                        }
                                                        v1021.v[v1022] = v1028;
                                                        v1022 += 1l ;
                                                    }
                                                    long v1032;
                                                    v1032 = 0l;
                                                    while (while_method_0(v1032)){
                                                        bool v1034;
                                                        v1034 = 0l <= v1032;
                                                        bool v1036;
                                                        if (v1034){
                                                            bool v1035;
                                                            v1035 = v1032 < 2l;
                                                            v1036 = v1035;
                                                        } else {
                                                            v1036 = false;
                                                        }
                                                        bool v1037;
                                                        v1037 = v1036 == false;
                                                        if (v1037){
                                                            assert("The read index needs to be in range for the static array." && v1036);
                                                        } else {
                                                        }
                                                        Card v1038;
                                                        v1038 = v1010.v[v1032];
                                                        long v1039;
                                                        v1039 = 3l + v1032;
                                                        bool v1040;
                                                        v1040 = 0l <= v1039;
                                                        bool v1042;
                                                        if (v1040){
                                                            bool v1041;
                                                            v1041 = v1039 < 5l;
                                                            v1042 = v1041;
                                                        } else {
                                                            v1042 = false;
                                                        }
                                                        bool v1043;
                                                        v1043 = v1042 == false;
                                                        if (v1043){
                                                            assert("The read index needs to be in range for the static array." && v1042);
                                                        } else {
                                                        }
                                                        v1021.v[v1039] = v1038;
                                                        v1032 += 1l ;
                                                    }
                                                    v1047 = US12_1(v1021);
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            switch (v1047.tag) {
                                                case 0: { // None
                                                    static_array<Card,2l> v1049;
                                                    static_array<Card,5l> v1050;
                                                    long v1051; long v1052; long v1053; unsigned char v1054;
                                                    Tuple21 tmp76 = Tuple21(0l, 0l, 0l, 12u);
                                                    v1051 = tmp76.v0; v1052 = tmp76.v1; v1053 = tmp76.v2; v1054 = tmp76.v3;
                                                    while (while_method_10(v1051)){
                                                        bool v1056;
                                                        v1056 = 0l <= v1051;
                                                        bool v1058;
                                                        if (v1056){
                                                            bool v1057;
                                                            v1057 = v1051 < 7l;
                                                            v1058 = v1057;
                                                        } else {
                                                            v1058 = false;
                                                        }
                                                        bool v1059;
                                                        v1059 = v1058 == false;
                                                        if (v1059){
                                                            assert("The read index needs to be in range for the static array." && v1058);
                                                        } else {
                                                        }
                                                        Card v1060;
                                                        v1060 = v120.v[v1051];
                                                        bool v1061;
                                                        v1061 = v1053 < 2l;
                                                        long v1074; long v1075; unsigned char v1076;
                                                        if (v1061){
                                                            unsigned char v1062;
                                                            v1062 = v1060.rank;
                                                            bool v1063;
                                                            v1063 = v1054 == v1062;
                                                            long v1064;
                                                            if (v1063){
                                                                v1064 = v1053;
                                                            } else {
                                                                v1064 = 0l;
                                                            }
                                                            bool v1065;
                                                            v1065 = 0l <= v1064;
                                                            bool v1067;
                                                            if (v1065){
                                                                bool v1066;
                                                                v1066 = v1064 < 2l;
                                                                v1067 = v1066;
                                                            } else {
                                                                v1067 = false;
                                                            }
                                                            bool v1068;
                                                            v1068 = v1067 == false;
                                                            if (v1068){
                                                                assert("The read index needs to be in range for the static array." && v1067);
                                                            } else {
                                                            }
                                                            v1049.v[v1064] = v1060;
                                                            long v1069;
                                                            v1069 = v1064 + 1l;
                                                            unsigned char v1070;
                                                            v1070 = v1060.rank;
                                                            v1074 = v1051; v1075 = v1069; v1076 = v1070;
                                                        } else {
                                                            break;
                                                        }
                                                        v1052 = v1074;
                                                        v1053 = v1075;
                                                        v1054 = v1076;
                                                        v1051 += 1l ;
                                                    }
                                                    bool v1077;
                                                    v1077 = v1053 == 2l;
                                                    US16 v1095;
                                                    if (v1077){
                                                        long v1078;
                                                        v1078 = 0l;
                                                        while (while_method_2(v1078)){
                                                            long v1080;
                                                            v1080 = v1052 + -1l;
                                                            bool v1081;
                                                            v1081 = v1078 < v1080;
                                                            long v1082;
                                                            if (v1081){
                                                                v1082 = 0l;
                                                            } else {
                                                                v1082 = 2l;
                                                            }
                                                            long v1083;
                                                            v1083 = v1082 + v1078;
                                                            bool v1084;
                                                            v1084 = 0l <= v1083;
                                                            bool v1086;
                                                            if (v1084){
                                                                bool v1085;
                                                                v1085 = v1083 < 7l;
                                                                v1086 = v1085;
                                                            } else {
                                                                v1086 = false;
                                                            }
                                                            bool v1087;
                                                            v1087 = v1086 == false;
                                                            if (v1087){
                                                                assert("The read index needs to be in range for the static array." && v1086);
                                                            } else {
                                                            }
                                                            Card v1088;
                                                            v1088 = v120.v[v1083];
                                                            bool v1089;
                                                            v1089 = 0l <= v1078;
                                                            bool v1091;
                                                            if (v1089){
                                                                bool v1090;
                                                                v1090 = v1078 < 5l;
                                                                v1091 = v1090;
                                                            } else {
                                                                v1091 = false;
                                                            }
                                                            bool v1092;
                                                            v1092 = v1091 == false;
                                                            if (v1092){
                                                                assert("The read index needs to be in range for the static array." && v1091);
                                                            } else {
                                                            }
                                                            v1050.v[v1078] = v1088;
                                                            v1078 += 1l ;
                                                        }
                                                        v1095 = US16_1(v1049, v1050);
                                                    } else {
                                                        v1095 = US16_0();
                                                    }
                                                    US12 v1199;
                                                    switch (v1095.tag) {
                                                        case 0: { // None
                                                            v1199 = US12_0();
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<Card,2l> v1096 = v1095.v.case1.v0; static_array<Card,5l> v1097 = v1095.v.case1.v1;
                                                            static_array<Card,2l> v1098;
                                                            static_array<Card,3l> v1099;
                                                            long v1100; long v1101; long v1102; unsigned char v1103;
                                                            Tuple21 tmp77 = Tuple21(0l, 0l, 0l, 12u);
                                                            v1100 = tmp77.v0; v1101 = tmp77.v1; v1102 = tmp77.v2; v1103 = tmp77.v3;
                                                            while (while_method_2(v1100)){
                                                                bool v1105;
                                                                v1105 = 0l <= v1100;
                                                                bool v1107;
                                                                if (v1105){
                                                                    bool v1106;
                                                                    v1106 = v1100 < 5l;
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
                                                                Card v1109;
                                                                v1109 = v1097.v[v1100];
                                                                bool v1110;
                                                                v1110 = v1102 < 2l;
                                                                long v1123; long v1124; unsigned char v1125;
                                                                if (v1110){
                                                                    unsigned char v1111;
                                                                    v1111 = v1109.rank;
                                                                    bool v1112;
                                                                    v1112 = v1103 == v1111;
                                                                    long v1113;
                                                                    if (v1112){
                                                                        v1113 = v1102;
                                                                    } else {
                                                                        v1113 = 0l;
                                                                    }
                                                                    bool v1114;
                                                                    v1114 = 0l <= v1113;
                                                                    bool v1116;
                                                                    if (v1114){
                                                                        bool v1115;
                                                                        v1115 = v1113 < 2l;
                                                                        v1116 = v1115;
                                                                    } else {
                                                                        v1116 = false;
                                                                    }
                                                                    bool v1117;
                                                                    v1117 = v1116 == false;
                                                                    if (v1117){
                                                                        assert("The read index needs to be in range for the static array." && v1116);
                                                                    } else {
                                                                    }
                                                                    v1098.v[v1113] = v1109;
                                                                    long v1118;
                                                                    v1118 = v1113 + 1l;
                                                                    unsigned char v1119;
                                                                    v1119 = v1109.rank;
                                                                    v1123 = v1100; v1124 = v1118; v1125 = v1119;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1101 = v1123;
                                                                v1102 = v1124;
                                                                v1103 = v1125;
                                                                v1100 += 1l ;
                                                            }
                                                            bool v1126;
                                                            v1126 = v1102 == 2l;
                                                            US17 v1144;
                                                            if (v1126){
                                                                long v1127;
                                                                v1127 = 0l;
                                                                while (while_method_3(v1127)){
                                                                    long v1129;
                                                                    v1129 = v1101 + -1l;
                                                                    bool v1130;
                                                                    v1130 = v1127 < v1129;
                                                                    long v1131;
                                                                    if (v1130){
                                                                        v1131 = 0l;
                                                                    } else {
                                                                        v1131 = 2l;
                                                                    }
                                                                    long v1132;
                                                                    v1132 = v1131 + v1127;
                                                                    bool v1133;
                                                                    v1133 = 0l <= v1132;
                                                                    bool v1135;
                                                                    if (v1133){
                                                                        bool v1134;
                                                                        v1134 = v1132 < 5l;
                                                                        v1135 = v1134;
                                                                    } else {
                                                                        v1135 = false;
                                                                    }
                                                                    bool v1136;
                                                                    v1136 = v1135 == false;
                                                                    if (v1136){
                                                                        assert("The read index needs to be in range for the static array." && v1135);
                                                                    } else {
                                                                    }
                                                                    Card v1137;
                                                                    v1137 = v1097.v[v1132];
                                                                    bool v1138;
                                                                    v1138 = 0l <= v1127;
                                                                    bool v1140;
                                                                    if (v1138){
                                                                        bool v1139;
                                                                        v1139 = v1127 < 3l;
                                                                        v1140 = v1139;
                                                                    } else {
                                                                        v1140 = false;
                                                                    }
                                                                    bool v1141;
                                                                    v1141 = v1140 == false;
                                                                    if (v1141){
                                                                        assert("The read index needs to be in range for the static array." && v1140);
                                                                    } else {
                                                                    }
                                                                    v1099.v[v1127] = v1137;
                                                                    v1127 += 1l ;
                                                                }
                                                                v1144 = US17_1(v1098, v1099);
                                                            } else {
                                                                v1144 = US17_0();
                                                            }
                                                            switch (v1144.tag) {
                                                                case 0: { // None
                                                                    v1199 = US12_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<Card,2l> v1145 = v1144.v.case1.v0; static_array<Card,3l> v1146 = v1144.v.case1.v1;
                                                                    static_array<Card,1l> v1147;
                                                                    long v1148;
                                                                    v1148 = 0l;
                                                                    while (while_method_6(v1148)){
                                                                        bool v1150;
                                                                        v1150 = 0l <= v1148;
                                                                        bool v1152;
                                                                        if (v1150){
                                                                            bool v1151;
                                                                            v1151 = v1148 < 3l;
                                                                            v1152 = v1151;
                                                                        } else {
                                                                            v1152 = false;
                                                                        }
                                                                        bool v1153;
                                                                        v1153 = v1152 == false;
                                                                        if (v1153){
                                                                            assert("The read index needs to be in range for the static array." && v1152);
                                                                        } else {
                                                                        }
                                                                        Card v1154;
                                                                        v1154 = v1146.v[v1148];
                                                                        bool v1156;
                                                                        if (v1150){
                                                                            bool v1155;
                                                                            v1155 = v1148 < 1l;
                                                                            v1156 = v1155;
                                                                        } else {
                                                                            v1156 = false;
                                                                        }
                                                                        bool v1157;
                                                                        v1157 = v1156 == false;
                                                                        if (v1157){
                                                                            assert("The read index needs to be in range for the static array." && v1156);
                                                                        } else {
                                                                        }
                                                                        v1147.v[v1148] = v1154;
                                                                        v1148 += 1l ;
                                                                    }
                                                                    static_array<Card,5l> v1158;
                                                                    long v1159;
                                                                    v1159 = 0l;
                                                                    while (while_method_0(v1159)){
                                                                        bool v1161;
                                                                        v1161 = 0l <= v1159;
                                                                        bool v1163;
                                                                        if (v1161){
                                                                            bool v1162;
                                                                            v1162 = v1159 < 2l;
                                                                            v1163 = v1162;
                                                                        } else {
                                                                            v1163 = false;
                                                                        }
                                                                        bool v1164;
                                                                        v1164 = v1163 == false;
                                                                        if (v1164){
                                                                            assert("The read index needs to be in range for the static array." && v1163);
                                                                        } else {
                                                                        }
                                                                        Card v1165;
                                                                        v1165 = v1096.v[v1159];
                                                                        bool v1167;
                                                                        if (v1161){
                                                                            bool v1166;
                                                                            v1166 = v1159 < 5l;
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
                                                                        v1158.v[v1159] = v1165;
                                                                        v1159 += 1l ;
                                                                    }
                                                                    long v1169;
                                                                    v1169 = 0l;
                                                                    while (while_method_0(v1169)){
                                                                        bool v1171;
                                                                        v1171 = 0l <= v1169;
                                                                        bool v1173;
                                                                        if (v1171){
                                                                            bool v1172;
                                                                            v1172 = v1169 < 2l;
                                                                            v1173 = v1172;
                                                                        } else {
                                                                            v1173 = false;
                                                                        }
                                                                        bool v1174;
                                                                        v1174 = v1173 == false;
                                                                        if (v1174){
                                                                            assert("The read index needs to be in range for the static array." && v1173);
                                                                        } else {
                                                                        }
                                                                        Card v1175;
                                                                        v1175 = v1145.v[v1169];
                                                                        long v1176;
                                                                        v1176 = 2l + v1169;
                                                                        bool v1177;
                                                                        v1177 = 0l <= v1176;
                                                                        bool v1179;
                                                                        if (v1177){
                                                                            bool v1178;
                                                                            v1178 = v1176 < 5l;
                                                                            v1179 = v1178;
                                                                        } else {
                                                                            v1179 = false;
                                                                        }
                                                                        bool v1180;
                                                                        v1180 = v1179 == false;
                                                                        if (v1180){
                                                                            assert("The read index needs to be in range for the static array." && v1179);
                                                                        } else {
                                                                        }
                                                                        v1158.v[v1176] = v1175;
                                                                        v1169 += 1l ;
                                                                    }
                                                                    long v1181;
                                                                    v1181 = 0l;
                                                                    while (while_method_6(v1181)){
                                                                        bool v1183;
                                                                        v1183 = 0l <= v1181;
                                                                        bool v1185;
                                                                        if (v1183){
                                                                            bool v1184;
                                                                            v1184 = v1181 < 1l;
                                                                            v1185 = v1184;
                                                                        } else {
                                                                            v1185 = false;
                                                                        }
                                                                        bool v1186;
                                                                        v1186 = v1185 == false;
                                                                        if (v1186){
                                                                            assert("The read index needs to be in range for the static array." && v1185);
                                                                        } else {
                                                                        }
                                                                        Card v1187;
                                                                        v1187 = v1147.v[v1181];
                                                                        long v1188;
                                                                        v1188 = 4l + v1181;
                                                                        bool v1189;
                                                                        v1189 = 0l <= v1188;
                                                                        bool v1191;
                                                                        if (v1189){
                                                                            bool v1190;
                                                                            v1190 = v1188 < 5l;
                                                                            v1191 = v1190;
                                                                        } else {
                                                                            v1191 = false;
                                                                        }
                                                                        bool v1192;
                                                                        v1192 = v1191 == false;
                                                                        if (v1192){
                                                                            assert("The read index needs to be in range for the static array." && v1191);
                                                                        } else {
                                                                        }
                                                                        v1158.v[v1188] = v1187;
                                                                        v1181 += 1l ;
                                                                    }
                                                                    v1199 = US12_1(v1158);
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
                                                    switch (v1199.tag) {
                                                        case 0: { // None
                                                            static_array<Card,2l> v1201;
                                                            static_array<Card,5l> v1202;
                                                            long v1203; long v1204; long v1205; unsigned char v1206;
                                                            Tuple21 tmp78 = Tuple21(0l, 0l, 0l, 12u);
                                                            v1203 = tmp78.v0; v1204 = tmp78.v1; v1205 = tmp78.v2; v1206 = tmp78.v3;
                                                            while (while_method_10(v1203)){
                                                                bool v1208;
                                                                v1208 = 0l <= v1203;
                                                                bool v1210;
                                                                if (v1208){
                                                                    bool v1209;
                                                                    v1209 = v1203 < 7l;
                                                                    v1210 = v1209;
                                                                } else {
                                                                    v1210 = false;
                                                                }
                                                                bool v1211;
                                                                v1211 = v1210 == false;
                                                                if (v1211){
                                                                    assert("The read index needs to be in range for the static array." && v1210);
                                                                } else {
                                                                }
                                                                Card v1212;
                                                                v1212 = v120.v[v1203];
                                                                bool v1213;
                                                                v1213 = v1205 < 2l;
                                                                long v1226; long v1227; unsigned char v1228;
                                                                if (v1213){
                                                                    unsigned char v1214;
                                                                    v1214 = v1212.rank;
                                                                    bool v1215;
                                                                    v1215 = v1206 == v1214;
                                                                    long v1216;
                                                                    if (v1215){
                                                                        v1216 = v1205;
                                                                    } else {
                                                                        v1216 = 0l;
                                                                    }
                                                                    bool v1217;
                                                                    v1217 = 0l <= v1216;
                                                                    bool v1219;
                                                                    if (v1217){
                                                                        bool v1218;
                                                                        v1218 = v1216 < 2l;
                                                                        v1219 = v1218;
                                                                    } else {
                                                                        v1219 = false;
                                                                    }
                                                                    bool v1220;
                                                                    v1220 = v1219 == false;
                                                                    if (v1220){
                                                                        assert("The read index needs to be in range for the static array." && v1219);
                                                                    } else {
                                                                    }
                                                                    v1201.v[v1216] = v1212;
                                                                    long v1221;
                                                                    v1221 = v1216 + 1l;
                                                                    unsigned char v1222;
                                                                    v1222 = v1212.rank;
                                                                    v1226 = v1203; v1227 = v1221; v1228 = v1222;
                                                                } else {
                                                                    break;
                                                                }
                                                                v1204 = v1226;
                                                                v1205 = v1227;
                                                                v1206 = v1228;
                                                                v1203 += 1l ;
                                                            }
                                                            bool v1229;
                                                            v1229 = v1205 == 2l;
                                                            US16 v1247;
                                                            if (v1229){
                                                                long v1230;
                                                                v1230 = 0l;
                                                                while (while_method_2(v1230)){
                                                                    long v1232;
                                                                    v1232 = v1204 + -1l;
                                                                    bool v1233;
                                                                    v1233 = v1230 < v1232;
                                                                    long v1234;
                                                                    if (v1233){
                                                                        v1234 = 0l;
                                                                    } else {
                                                                        v1234 = 2l;
                                                                    }
                                                                    long v1235;
                                                                    v1235 = v1234 + v1230;
                                                                    bool v1236;
                                                                    v1236 = 0l <= v1235;
                                                                    bool v1238;
                                                                    if (v1236){
                                                                        bool v1237;
                                                                        v1237 = v1235 < 7l;
                                                                        v1238 = v1237;
                                                                    } else {
                                                                        v1238 = false;
                                                                    }
                                                                    bool v1239;
                                                                    v1239 = v1238 == false;
                                                                    if (v1239){
                                                                        assert("The read index needs to be in range for the static array." && v1238);
                                                                    } else {
                                                                    }
                                                                    Card v1240;
                                                                    v1240 = v120.v[v1235];
                                                                    bool v1241;
                                                                    v1241 = 0l <= v1230;
                                                                    bool v1243;
                                                                    if (v1241){
                                                                        bool v1242;
                                                                        v1242 = v1230 < 5l;
                                                                        v1243 = v1242;
                                                                    } else {
                                                                        v1243 = false;
                                                                    }
                                                                    bool v1244;
                                                                    v1244 = v1243 == false;
                                                                    if (v1244){
                                                                        assert("The read index needs to be in range for the static array." && v1243);
                                                                    } else {
                                                                    }
                                                                    v1202.v[v1230] = v1240;
                                                                    v1230 += 1l ;
                                                                }
                                                                v1247 = US16_1(v1201, v1202);
                                                            } else {
                                                                v1247 = US16_0();
                                                            }
                                                            US12 v1287;
                                                            switch (v1247.tag) {
                                                                case 0: { // None
                                                                    v1287 = US12_0();
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<Card,2l> v1248 = v1247.v.case1.v0; static_array<Card,5l> v1249 = v1247.v.case1.v1;
                                                                    static_array<Card,3l> v1250;
                                                                    long v1251;
                                                                    v1251 = 0l;
                                                                    while (while_method_3(v1251)){
                                                                        bool v1253;
                                                                        v1253 = 0l <= v1251;
                                                                        bool v1255;
                                                                        if (v1253){
                                                                            bool v1254;
                                                                            v1254 = v1251 < 5l;
                                                                            v1255 = v1254;
                                                                        } else {
                                                                            v1255 = false;
                                                                        }
                                                                        bool v1256;
                                                                        v1256 = v1255 == false;
                                                                        if (v1256){
                                                                            assert("The read index needs to be in range for the static array." && v1255);
                                                                        } else {
                                                                        }
                                                                        Card v1257;
                                                                        v1257 = v1249.v[v1251];
                                                                        bool v1259;
                                                                        if (v1253){
                                                                            bool v1258;
                                                                            v1258 = v1251 < 3l;
                                                                            v1259 = v1258;
                                                                        } else {
                                                                            v1259 = false;
                                                                        }
                                                                        bool v1260;
                                                                        v1260 = v1259 == false;
                                                                        if (v1260){
                                                                            assert("The read index needs to be in range for the static array." && v1259);
                                                                        } else {
                                                                        }
                                                                        v1250.v[v1251] = v1257;
                                                                        v1251 += 1l ;
                                                                    }
                                                                    static_array<Card,5l> v1261;
                                                                    long v1262;
                                                                    v1262 = 0l;
                                                                    while (while_method_0(v1262)){
                                                                        bool v1264;
                                                                        v1264 = 0l <= v1262;
                                                                        bool v1266;
                                                                        if (v1264){
                                                                            bool v1265;
                                                                            v1265 = v1262 < 2l;
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
                                                                        Card v1268;
                                                                        v1268 = v1248.v[v1262];
                                                                        bool v1270;
                                                                        if (v1264){
                                                                            bool v1269;
                                                                            v1269 = v1262 < 5l;
                                                                            v1270 = v1269;
                                                                        } else {
                                                                            v1270 = false;
                                                                        }
                                                                        bool v1271;
                                                                        v1271 = v1270 == false;
                                                                        if (v1271){
                                                                            assert("The read index needs to be in range for the static array." && v1270);
                                                                        } else {
                                                                        }
                                                                        v1261.v[v1262] = v1268;
                                                                        v1262 += 1l ;
                                                                    }
                                                                    long v1272;
                                                                    v1272 = 0l;
                                                                    while (while_method_3(v1272)){
                                                                        bool v1274;
                                                                        v1274 = 0l <= v1272;
                                                                        bool v1276;
                                                                        if (v1274){
                                                                            bool v1275;
                                                                            v1275 = v1272 < 3l;
                                                                            v1276 = v1275;
                                                                        } else {
                                                                            v1276 = false;
                                                                        }
                                                                        bool v1277;
                                                                        v1277 = v1276 == false;
                                                                        if (v1277){
                                                                            assert("The read index needs to be in range for the static array." && v1276);
                                                                        } else {
                                                                        }
                                                                        Card v1278;
                                                                        v1278 = v1250.v[v1272];
                                                                        long v1279;
                                                                        v1279 = 2l + v1272;
                                                                        bool v1280;
                                                                        v1280 = 0l <= v1279;
                                                                        bool v1282;
                                                                        if (v1280){
                                                                            bool v1281;
                                                                            v1281 = v1279 < 5l;
                                                                            v1282 = v1281;
                                                                        } else {
                                                                            v1282 = false;
                                                                        }
                                                                        bool v1283;
                                                                        v1283 = v1282 == false;
                                                                        if (v1283){
                                                                            assert("The read index needs to be in range for the static array." && v1282);
                                                                        } else {
                                                                        }
                                                                        v1261.v[v1279] = v1278;
                                                                        v1272 += 1l ;
                                                                    }
                                                                    v1287 = US12_1(v1261);
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            switch (v1287.tag) {
                                                                case 0: { // None
                                                                    static_array<Card,5l> v1289;
                                                                    long v1290;
                                                                    v1290 = 0l;
                                                                    while (while_method_2(v1290)){
                                                                        bool v1292;
                                                                        v1292 = 0l <= v1290;
                                                                        bool v1294;
                                                                        if (v1292){
                                                                            bool v1293;
                                                                            v1293 = v1290 < 7l;
                                                                            v1294 = v1293;
                                                                        } else {
                                                                            v1294 = false;
                                                                        }
                                                                        bool v1295;
                                                                        v1295 = v1294 == false;
                                                                        if (v1295){
                                                                            assert("The read index needs to be in range for the static array." && v1294);
                                                                        } else {
                                                                        }
                                                                        Card v1296;
                                                                        v1296 = v120.v[v1290];
                                                                        bool v1298;
                                                                        if (v1292){
                                                                            bool v1297;
                                                                            v1297 = v1290 < 5l;
                                                                            v1298 = v1297;
                                                                        } else {
                                                                            v1298 = false;
                                                                        }
                                                                        bool v1299;
                                                                        v1299 = v1298 == false;
                                                                        if (v1299){
                                                                            assert("The read index needs to be in range for the static array." && v1298);
                                                                        } else {
                                                                        }
                                                                        v1289.v[v1290] = v1296;
                                                                        v1290 += 1l ;
                                                                    }
                                                                    v1330 = v1289; v1331 = 0;
                                                                    break;
                                                                }
                                                                case 1: { // Some
                                                                    static_array<Card,5l> v1288 = v1287.v.case1.v0;
                                                                    v1330 = v1288; v1331 = 1;
                                                                    break;
                                                                }
                                                                default: {
                                                                    assert("Invalid tag." && false);
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        case 1: { // Some
                                                            static_array<Card,5l> v1200 = v1199.v.case1.v0;
                                                            v1330 = v1200; v1331 = 2;
                                                            break;
                                                        }
                                                        default: {
                                                            assert("Invalid tag." && false);
                                                        }
                                                    }
                                                    break;
                                                }
                                                case 1: { // Some
                                                    static_array<Card,5l> v1048 = v1047.v.case1.v0;
                                                    v1330 = v1048; v1331 = 3;
                                                    break;
                                                }
                                                default: {
                                                    assert("Invalid tag." && false);
                                                }
                                            }
                                            break;
                                        }
                                        case 1: { // Some
                                            static_array<Card,5l> v960 = v959.v.case1.v0;
                                            v1330 = v960; v1331 = 4;
                                            break;
                                        }
                                        default: {
                                            assert("Invalid tag." && false);
                                        }
                                    }
                                    break;
                                }
                                case 1: { // Some
                                    static_array<Card,5l> v913 = v912.v.case1.v0;
                                    v1330 = v913; v1331 = 5;
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            break;
                        }
                        case 1: { // Some
                            static_array<Card,5l> v721 = v720.v.case1.v0;
                            v1330 = v721; v1331 = 6;
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 1: { // Some
                    static_array<Card,5l> v592 = v591.v.case1.v0;
                    v1330 = v592; v1331 = 7;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            break;
        }
        case 1: { // Some
            static_array<Card,5l> v504 = v503.v.case1.v0;
            v1330 = v504; v1331 = 8;
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    return Tuple16(v1330, v1331);
}
__device__ US6 hand_from_lib_hand_score_48(static_array<Card,5l> v0, char v1){
    static_array<Tuple0,5l> v2;
    long v3;
    v3 = 0l;
    while (while_method_2(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 5l;
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
        Card v9;
        v9 = v0.v[v3];
        US4 v10; US5 v11;
        Tuple0 tmp82 = card_from_lib_card_35(v9);
        v10 = tmp82.v0; v11 = tmp82.v1;
        bool v13;
        if (v5){
            bool v12;
            v12 = v3 < 5l;
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
        v2.v[v3] = Tuple0(v10, v11);
        v3 += 1l ;
    }
    bool v15;
    v15 = 8 == v1;
    if (v15){
        return US6_6(v2);
    } else {
        bool v17;
        v17 = 7 == v1;
        if (v17){
            return US6_4(v2);
        } else {
            bool v19;
            v19 = 6 == v1;
            if (v19){
                return US6_1(v2);
            } else {
                bool v21;
                v21 = 5 == v1;
                if (v21){
                    return US6_0(v2);
                } else {
                    bool v23;
                    v23 = 4 == v1;
                    if (v23){
                        return US6_5(v2);
                    } else {
                        bool v25;
                        v25 = 3 == v1;
                        if (v25){
                            return US6_7(v2);
                        } else {
                            bool v27;
                            v27 = 2 == v1;
                            if (v27){
                                return US6_8(v2);
                            } else {
                                bool v29;
                                v29 = 1 == v1;
                                if (v29){
                                    return US6_3(v2);
                                } else {
                                    bool v31;
                                    v31 = 0 == v1;
                                    if (v31){
                                        return US6_2(v2);
                                    } else {
                                        printf("%s\n", "Invalid tag in hand_from_lib_hand_score");
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
__device__ US8 play_loop_inner_31(unsigned long long & v0, static_array_list<US3,128l,long> & v1, curandStatePhilox4_32_10_t & v2, static_array<US2,2l> v3, US8 v4){
    static_array_list<US3,128l,long> & v5 = v1;
    unsigned long long & v6 = v0;
    bool v7; US8 v8;
    Tuple9 tmp20 = Tuple9(true, v4);
    v7 = tmp20.v0; v8 = tmp20.v1;
    while (while_method_5(v7, v8)){
        bool v924; US8 v925;
        switch (v8.tag) {
            case 0: { // G_Flop
                long v681 = v8.v.case0.v0; bool v682 = v8.v.case0.v1; static_array<static_array<Tuple0,2l>,2l> v683 = v8.v.case0.v2; long v684 = v8.v.case0.v3; static_array<long,2l> v685 = v8.v.case0.v4; static_array<long,2l> v686 = v8.v.case0.v5; US9 v687 = v8.v.case0.v6;
                static_array<Card,3l> v688; unsigned long long v689;
                Tuple10 tmp23 = draw_cards_32(v2, v6);
                v688 = tmp23.v0; v689 = tmp23.v1;
                v0 = v689;
                static_array<Tuple0,3l> v690;
                long v691;
                v691 = 0l;
                while (while_method_3(v691)){
                    bool v693;
                    v693 = 0l <= v691;
                    bool v695;
                    if (v693){
                        bool v694;
                        v694 = v691 < 3l;
                        v695 = v694;
                    } else {
                        v695 = false;
                    }
                    bool v696;
                    v696 = v695 == false;
                    if (v696){
                        assert("The read index needs to be in range for the static array." && v695);
                    } else {
                    }
                    Card v697;
                    v697 = v688.v[v691];
                    US4 v698; US5 v699;
                    Tuple0 tmp24 = card_from_lib_card_35(v697);
                    v698 = tmp24.v0; v699 = tmp24.v1;
                    bool v701;
                    if (v693){
                        bool v700;
                        v700 = v691 < 3l;
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
                    v690.v[v691] = Tuple0(v698, v699);
                    v691 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v703;
                v703 = get_community_cards_38(v687, v690);
                long v704;
                v704 = v5.length;
                bool v705;
                v705 = v704 < 128l;
                bool v706;
                v706 = v705 == false;
                if (v706){
                    assert("The length has to be less than the maximum length of the array." && v705);
                } else {
                }
                long v707;
                v707 = v704 + 1l;
                v5.length = v707;
                bool v708;
                v708 = 0l <= v704;
                bool v711;
                if (v708){
                    long v709;
                    v709 = v5.length;
                    bool v710;
                    v710 = v704 < v709;
                    v711 = v710;
                } else {
                    v711 = false;
                }
                bool v712;
                v712 = v711 == false;
                if (v712){
                    assert("The set index needs to be in range for the static array list." && v711);
                } else {
                }
                US3 v713;
                v713 = US3_0(v703);
                v5.v[v704] = v713;
                US9 v716;
                switch (v687.tag) {
                    case 1: { // Preflop
                        v716 = US9_0(v690);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in flop.");
                        asm("exit;");
                    }
                }
                US8 v717;
                v717 = US8_4(v681, true, v683, 0l, v685, v686, v716);
                v924 = true; v925 = v717;
                break;
            }
            case 1: { // G_Fold
                long v10 = v8.v.case1.v0; bool v11 = v8.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v12 = v8.v.case1.v2; long v13 = v8.v.case1.v3; static_array<long,2l> v14 = v8.v.case1.v4; static_array<long,2l> v15 = v8.v.case1.v5; US9 v16 = v8.v.case1.v6;
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
                v924 = false; v925 = v8;
                break;
            }
            case 2: { // G_Preflop
                static_array<Card,2l> v844; unsigned long long v845;
                Tuple13 tmp31 = draw_cards_39(v2, v6);
                v844 = tmp31.v0; v845 = tmp31.v1;
                v0 = v845;
                static_array<Tuple0,2l> v846;
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
                    Card v853;
                    v853 = v844.v[v847];
                    US4 v854; US5 v855;
                    Tuple0 tmp32 = card_from_lib_card_35(v853);
                    v854 = tmp32.v0; v855 = tmp32.v1;
                    bool v857;
                    if (v849){
                        bool v856;
                        v856 = v847 < 2l;
                        v857 = v856;
                    } else {
                        v857 = false;
                    }
                    bool v858;
                    v858 = v857 == false;
                    if (v858){
                        assert("The read index needs to be in range for the static array." && v857);
                    } else {
                    }
                    v846.v[v847] = Tuple0(v854, v855);
                    v847 += 1l ;
                }
                static_array<Card,2l> v859; unsigned long long v860;
                Tuple13 tmp33 = draw_cards_39(v2, v6);
                v859 = tmp33.v0; v860 = tmp33.v1;
                v0 = v860;
                static_array<Tuple0,2l> v861;
                long v862;
                v862 = 0l;
                while (while_method_0(v862)){
                    bool v864;
                    v864 = 0l <= v862;
                    bool v866;
                    if (v864){
                        bool v865;
                        v865 = v862 < 2l;
                        v866 = v865;
                    } else {
                        v866 = false;
                    }
                    bool v867;
                    v867 = v866 == false;
                    if (v867){
                        assert("The read index needs to be in range for the static array." && v866);
                    } else {
                    }
                    Card v868;
                    v868 = v859.v[v862];
                    US4 v869; US5 v870;
                    Tuple0 tmp34 = card_from_lib_card_35(v868);
                    v869 = tmp34.v0; v870 = tmp34.v1;
                    bool v872;
                    if (v864){
                        bool v871;
                        v871 = v862 < 2l;
                        v872 = v871;
                    } else {
                        v872 = false;
                    }
                    bool v873;
                    v873 = v872 == false;
                    if (v873){
                        assert("The read index needs to be in range for the static array." && v872);
                    } else {
                    }
                    v861.v[v862] = Tuple0(v869, v870);
                    v862 += 1l ;
                }
                long v874;
                v874 = v5.length;
                bool v875;
                v875 = v874 < 128l;
                bool v876;
                v876 = v875 == false;
                if (v876){
                    assert("The length has to be less than the maximum length of the array." && v875);
                } else {
                }
                long v877;
                v877 = v874 + 1l;
                v5.length = v877;
                bool v878;
                v878 = 0l <= v874;
                bool v881;
                if (v878){
                    long v879;
                    v879 = v5.length;
                    bool v880;
                    v880 = v874 < v879;
                    v881 = v880;
                } else {
                    v881 = false;
                }
                bool v882;
                v882 = v881 == false;
                if (v882){
                    assert("The set index needs to be in range for the static array list." && v881);
                } else {
                }
                US3 v883;
                v883 = US3_3(0l, v846);
                v5.v[v874] = v883;
                long v884;
                v884 = v5.length;
                bool v885;
                v885 = v884 < 128l;
                bool v886;
                v886 = v885 == false;
                if (v886){
                    assert("The length has to be less than the maximum length of the array." && v885);
                } else {
                }
                long v887;
                v887 = v884 + 1l;
                v5.length = v887;
                bool v888;
                v888 = 0l <= v884;
                bool v891;
                if (v888){
                    long v889;
                    v889 = v5.length;
                    bool v890;
                    v890 = v884 < v889;
                    v891 = v890;
                } else {
                    v891 = false;
                }
                bool v892;
                v892 = v891 == false;
                if (v892){
                    assert("The set index needs to be in range for the static array list." && v891);
                } else {
                }
                US3 v893;
                v893 = US3_3(1l, v861);
                v5.v[v884] = v893;
                static_array<static_array<Tuple0,2l>,2l> v894;
                v894.v[0l] = v846;
                v894.v[1l] = v861;
                static_array<long,2l> v895;
                v895.v[0l] = 2l;
                v895.v[1l] = 1l;
                static_array<long,2l> v896;
                long v897;
                v897 = 0l;
                while (while_method_0(v897)){
                    bool v899;
                    v899 = 0l <= v897;
                    bool v901;
                    if (v899){
                        bool v900;
                        v900 = v897 < 2l;
                        v901 = v900;
                    } else {
                        v901 = false;
                    }
                    bool v902;
                    v902 = v901 == false;
                    if (v902){
                        assert("The read index needs to be in range for the static array." && v901);
                    } else {
                    }
                    long v903;
                    v903 = v895.v[v897];
                    long v904;
                    v904 = 100l - v903;
                    bool v906;
                    if (v899){
                        bool v905;
                        v905 = v897 < 2l;
                        v906 = v905;
                    } else {
                        v906 = false;
                    }
                    bool v907;
                    v907 = v906 == false;
                    if (v907){
                        assert("The read index needs to be in range for the static array." && v906);
                    } else {
                    }
                    v896.v[v897] = v904;
                    v897 += 1l ;
                }
                US9 v908;
                v908 = US9_1();
                US8 v909;
                v909 = US8_4(2l, true, v894, 0l, v895, v896, v908);
                v924 = true; v925 = v909;
                break;
            }
            case 3: { // G_River
                long v781 = v8.v.case3.v0; bool v782 = v8.v.case3.v1; static_array<static_array<Tuple0,2l>,2l> v783 = v8.v.case3.v2; long v784 = v8.v.case3.v3; static_array<long,2l> v785 = v8.v.case3.v4; static_array<long,2l> v786 = v8.v.case3.v5; US9 v787 = v8.v.case3.v6;
                static_array<Card,1l> v788; unsigned long long v789;
                Tuple14 tmp37 = draw_cards_40(v2, v6);
                v788 = tmp37.v0; v789 = tmp37.v1;
                v0 = v789;
                static_array<Tuple0,1l> v790;
                long v791;
                v791 = 0l;
                while (while_method_6(v791)){
                    bool v793;
                    v793 = 0l <= v791;
                    bool v795;
                    if (v793){
                        bool v794;
                        v794 = v791 < 1l;
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
                    Card v797;
                    v797 = v788.v[v791];
                    US4 v798; US5 v799;
                    Tuple0 tmp38 = card_from_lib_card_35(v797);
                    v798 = tmp38.v0; v799 = tmp38.v1;
                    bool v801;
                    if (v793){
                        bool v800;
                        v800 = v791 < 1l;
                        v801 = v800;
                    } else {
                        v801 = false;
                    }
                    bool v802;
                    v802 = v801 == false;
                    if (v802){
                        assert("The read index needs to be in range for the static array." && v801);
                    } else {
                    }
                    v790.v[v791] = Tuple0(v798, v799);
                    v791 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v803;
                v803 = get_community_cards_41(v787, v790);
                long v804;
                v804 = v5.length;
                bool v805;
                v805 = v804 < 128l;
                bool v806;
                v806 = v805 == false;
                if (v806){
                    assert("The length has to be less than the maximum length of the array." && v805);
                } else {
                }
                long v807;
                v807 = v804 + 1l;
                v5.length = v807;
                bool v808;
                v808 = 0l <= v804;
                bool v811;
                if (v808){
                    long v809;
                    v809 = v5.length;
                    bool v810;
                    v810 = v804 < v809;
                    v811 = v810;
                } else {
                    v811 = false;
                }
                bool v812;
                v812 = v811 == false;
                if (v812){
                    assert("The set index needs to be in range for the static array list." && v811);
                } else {
                }
                US3 v813;
                v813 = US3_0(v803);
                v5.v[v804] = v813;
                US9 v842;
                switch (v787.tag) {
                    case 3: { // Turn
                        static_array<Tuple0,4l> v814 = v787.v.case3.v0;
                        static_array<Tuple0,5l> v815;
                        long v816;
                        v816 = 0l;
                        while (while_method_4(v816)){
                            bool v818;
                            v818 = 0l <= v816;
                            bool v820;
                            if (v818){
                                bool v819;
                                v819 = v816 < 4l;
                                v820 = v819;
                            } else {
                                v820 = false;
                            }
                            bool v821;
                            v821 = v820 == false;
                            if (v821){
                                assert("The read index needs to be in range for the static array." && v820);
                            } else {
                            }
                            US4 v822; US5 v823;
                            Tuple0 tmp43 = v814.v[v816];
                            v822 = tmp43.v0; v823 = tmp43.v1;
                            bool v825;
                            if (v818){
                                bool v824;
                                v824 = v816 < 5l;
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
                            v815.v[v816] = Tuple0(v822, v823);
                            v816 += 1l ;
                        }
                        long v827;
                        v827 = 0l;
                        while (while_method_6(v827)){
                            bool v829;
                            v829 = 0l <= v827;
                            bool v831;
                            if (v829){
                                bool v830;
                                v830 = v827 < 1l;
                                v831 = v830;
                            } else {
                                v831 = false;
                            }
                            bool v832;
                            v832 = v831 == false;
                            if (v832){
                                assert("The read index needs to be in range for the static array." && v831);
                            } else {
                            }
                            US4 v833; US5 v834;
                            Tuple0 tmp44 = v790.v[v827];
                            v833 = tmp44.v0; v834 = tmp44.v1;
                            long v835;
                            v835 = 4l + v827;
                            bool v836;
                            v836 = 0l <= v835;
                            bool v838;
                            if (v836){
                                bool v837;
                                v837 = v835 < 5l;
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
                            v815.v[v835] = Tuple0(v833, v834);
                            v827 += 1l ;
                        }
                        v842 = US9_2(v815);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in river.");
                        asm("exit;");
                    }
                }
                US8 v843;
                v843 = US8_4(v781, true, v783, 0l, v785, v786, v842);
                v924 = true; v925 = v843;
                break;
            }
            case 4: { // G_Round
                long v195 = v8.v.case4.v0; bool v196 = v8.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v197 = v8.v.case4.v2; long v198 = v8.v.case4.v3; static_array<long,2l> v199 = v8.v.case4.v4; static_array<long,2l> v200 = v8.v.case4.v5; US9 v201 = v8.v.case4.v6;
                bool v202;
                v202 = 0l <= v198;
                bool v204;
                if (v202){
                    bool v203;
                    v203 = v198 < 2l;
                    v204 = v203;
                } else {
                    v204 = false;
                }
                bool v205;
                v205 = v204 == false;
                if (v205){
                    assert("The read index needs to be in range for the static array." && v204);
                } else {
                }
                US2 v206;
                v206 = v3.v[v198];
                switch (v206.tag) {
                    case 0: { // Computer
                        static_array<long,2l> v207;
                        long v208;
                        v208 = 0l;
                        while (while_method_0(v208)){
                            bool v210;
                            v210 = 0l <= v208;
                            bool v212;
                            if (v210){
                                bool v211;
                                v211 = v208 < 2l;
                                v212 = v211;
                            } else {
                                v212 = false;
                            }
                            bool v213;
                            v213 = v212 == false;
                            if (v213){
                                assert("The read index needs to be in range for the static array." && v212);
                            } else {
                            }
                            long v214;
                            v214 = v200.v[v208];
                            bool v216;
                            if (v210){
                                bool v215;
                                v215 = v208 < 2l;
                                v216 = v215;
                            } else {
                                v216 = false;
                            }
                            bool v217;
                            v217 = v216 == false;
                            if (v217){
                                assert("The read index needs to be in range for the static array." && v216);
                            } else {
                            }
                            long v218;
                            v218 = v199.v[v208];
                            long v219;
                            v219 = v214 + v218;
                            bool v221;
                            if (v210){
                                bool v220;
                                v220 = v208 < 2l;
                                v221 = v220;
                            } else {
                                v221 = false;
                            }
                            bool v222;
                            v222 = v221 == false;
                            if (v222){
                                assert("The read index needs to be in range for the static array." && v221);
                            } else {
                            }
                            v207.v[v208] = v219;
                            v208 += 1l ;
                        }
                        long v223;
                        v223 = v199.v[0l];
                        long v224; long v225;
                        Tuple2 tmp45 = Tuple2(1l, v223);
                        v224 = tmp45.v0; v225 = tmp45.v1;
                        while (while_method_0(v224)){
                            bool v227;
                            v227 = 0l <= v224;
                            bool v229;
                            if (v227){
                                bool v228;
                                v228 = v224 < 2l;
                                v229 = v228;
                            } else {
                                v229 = false;
                            }
                            bool v230;
                            v230 = v229 == false;
                            if (v230){
                                assert("The read index needs to be in range for the static array." && v229);
                            } else {
                            }
                            long v231;
                            v231 = v199.v[v224];
                            bool v232;
                            v232 = v225 >= v231;
                            long v233;
                            if (v232){
                                v233 = v225;
                            } else {
                                v233 = v231;
                            }
                            v225 = v233;
                            v224 += 1l ;
                        }
                        static_array<long,2l> v234;
                        long v235;
                        v235 = 0l;
                        while (while_method_0(v235)){
                            bool v237;
                            v237 = 0l <= v235;
                            bool v239;
                            if (v237){
                                bool v238;
                                v238 = v235 < 2l;
                                v239 = v238;
                            } else {
                                v239 = false;
                            }
                            bool v240;
                            v240 = v239 == false;
                            if (v240){
                                assert("The read index needs to be in range for the static array." && v239);
                            } else {
                            }
                            long v241;
                            v241 = v207.v[v235];
                            bool v242;
                            v242 = v198 == v235;
                            long v245;
                            if (v242){
                                bool v243;
                                v243 = v225 < v241;
                                if (v243){
                                    v245 = v225;
                                } else {
                                    v245 = v241;
                                }
                            } else {
                                v245 = v241;
                            }
                            bool v247;
                            if (v237){
                                bool v246;
                                v246 = v235 < 2l;
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
                            v234.v[v235] = v245;
                            v235 += 1l ;
                        }
                        static_array<long,2l> v249;
                        long v250;
                        v250 = 0l;
                        while (while_method_0(v250)){
                            bool v252;
                            v252 = 0l <= v250;
                            bool v254;
                            if (v252){
                                bool v253;
                                v253 = v250 < 2l;
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
                            v256 = v207.v[v250];
                            bool v258;
                            if (v252){
                                bool v257;
                                v257 = v250 < 2l;
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
                            v260 = v234.v[v250];
                            long v261;
                            v261 = v256 - v260;
                            bool v263;
                            if (v252){
                                bool v262;
                                v262 = v250 < 2l;
                                v263 = v262;
                            } else {
                                v263 = false;
                            }
                            bool v264;
                            v264 = v263 == false;
                            if (v264){
                                assert("The read index needs to be in range for the static array." && v263);
                            } else {
                            }
                            v249.v[v250] = v261;
                            v250 += 1l ;
                        }
                        long v265;
                        v265 = v234.v[0l];
                        long v266; long v267;
                        Tuple2 tmp46 = Tuple2(1l, v265);
                        v266 = tmp46.v0; v267 = tmp46.v1;
                        while (while_method_0(v266)){
                            bool v269;
                            v269 = 0l <= v266;
                            bool v271;
                            if (v269){
                                bool v270;
                                v270 = v266 < 2l;
                                v271 = v270;
                            } else {
                                v271 = false;
                            }
                            bool v272;
                            v272 = v271 == false;
                            if (v272){
                                assert("The read index needs to be in range for the static array." && v271);
                            } else {
                            }
                            long v273;
                            v273 = v234.v[v266];
                            long v274;
                            v274 = v267 + v273;
                            v267 = v274;
                            v266 += 1l ;
                        }
                        bool v276;
                        if (v202){
                            bool v275;
                            v275 = v198 < 2l;
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
                        v278 = v199.v[v198];
                        long v279;
                        v279 = v198 ^ 1l;
                        bool v280;
                        v280 = 0l <= v279;
                        bool v282;
                        if (v280){
                            bool v281;
                            v281 = v279 < 2l;
                            v282 = v281;
                        } else {
                            v282 = false;
                        }
                        bool v283;
                        v283 = v282 == false;
                        if (v283){
                            assert("The read index needs to be in range for the static array." && v282);
                        } else {
                        }
                        long v284;
                        v284 = v199.v[v279];
                        bool v285;
                        v285 = v278 < v284;
                        float v286;
                        if (v285){
                            v286 = 1.0f;
                        } else {
                            v286 = 0.0f;
                        }
                        long v287;
                        v287 = v267 / 4l;
                        bool v289;
                        if (v202){
                            bool v288;
                            v288 = v198 < 2l;
                            v289 = v288;
                        } else {
                            v289 = false;
                        }
                        bool v290;
                        v290 = v289 == false;
                        if (v290){
                            assert("The read index needs to be in range for the static array." && v289);
                        } else {
                        }
                        long v291;
                        v291 = v249.v[v198];
                        bool v292;
                        v292 = v287 <= v291;
                        float v293;
                        if (v292){
                            v293 = 1.0f;
                        } else {
                            v293 = 0.0f;
                        }
                        long v294;
                        v294 = v267 / 3l;
                        bool v296;
                        if (v202){
                            bool v295;
                            v295 = v198 < 2l;
                            v296 = v295;
                        } else {
                            v296 = false;
                        }
                        bool v297;
                        v297 = v296 == false;
                        if (v297){
                            assert("The read index needs to be in range for the static array." && v296);
                        } else {
                        }
                        long v298;
                        v298 = v249.v[v198];
                        bool v299;
                        v299 = v294 <= v298;
                        float v300;
                        if (v299){
                            v300 = 1.0f;
                        } else {
                            v300 = 0.0f;
                        }
                        long v301;
                        v301 = v267 / 2l;
                        bool v303;
                        if (v202){
                            bool v302;
                            v302 = v198 < 2l;
                            v303 = v302;
                        } else {
                            v303 = false;
                        }
                        bool v304;
                        v304 = v303 == false;
                        if (v304){
                            assert("The read index needs to be in range for the static array." && v303);
                        } else {
                        }
                        long v305;
                        v305 = v249.v[v198];
                        bool v306;
                        v306 = v301 <= v305;
                        float v307;
                        if (v306){
                            v307 = 1.0f;
                        } else {
                            v307 = 0.0f;
                        }
                        bool v309;
                        if (v202){
                            bool v308;
                            v308 = v198 < 2l;
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
                        v311 = v249.v[v198];
                        bool v312;
                        v312 = v267 <= v311;
                        float v313;
                        if (v312){
                            v313 = 1.0f;
                        } else {
                            v313 = 0.0f;
                        }
                        long v314;
                        v314 = v267 * 3l;
                        long v315;
                        v315 = v314 / 2l;
                        bool v317;
                        if (v202){
                            bool v316;
                            v316 = v198 < 2l;
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
                        v319 = v249.v[v198];
                        bool v320;
                        v320 = v315 <= v319;
                        float v321;
                        if (v320){
                            v321 = 1.0f;
                        } else {
                            v321 = 0.0f;
                        }
                        bool v323;
                        if (v202){
                            bool v322;
                            v322 = v198 < 2l;
                            v323 = v322;
                        } else {
                            v323 = false;
                        }
                        bool v324;
                        v324 = v323 == false;
                        if (v324){
                            assert("The read index needs to be in range for the static array." && v323);
                        } else {
                        }
                        long v325;
                        v325 = v249.v[v198];
                        bool v327;
                        if (v202){
                            bool v326;
                            v326 = v198 < 2l;
                            v327 = v326;
                        } else {
                            v327 = false;
                        }
                        bool v328;
                        v328 = v327 == false;
                        if (v328){
                            assert("The read index needs to be in range for the static array." && v327);
                        } else {
                        }
                        long v329;
                        v329 = v249.v[v198];
                        bool v330;
                        v330 = v325 <= v329;
                        float v331;
                        if (v330){
                            v331 = 1.0f;
                        } else {
                            v331 = 0.0f;
                        }
                        static_array<Tuple15,8l> v332;
                        US1 v333;
                        v333 = US1_1();
                        v332.v[0l] = Tuple15(v333, v286);
                        US1 v334;
                        v334 = US1_0();
                        v332.v[1l] = Tuple15(v334, 2.0f);
                        US1 v335;
                        v335 = US1_2(v287);
                        v332.v[2l] = Tuple15(v335, v293);
                        US1 v336;
                        v336 = US1_2(v294);
                        v332.v[3l] = Tuple15(v336, v300);
                        US1 v337;
                        v337 = US1_2(v301);
                        v332.v[4l] = Tuple15(v337, v307);
                        US1 v338;
                        v338 = US1_2(v267);
                        v332.v[5l] = Tuple15(v338, v313);
                        US1 v339;
                        v339 = US1_2(v315);
                        v332.v[6l] = Tuple15(v339, v321);
                        US1 v340;
                        v340 = US1_2(v325);
                        v332.v[7l] = Tuple15(v340, v331);
                        US1 v341;
                        v341 = sample_discrete_42(v332, v2);
                        long v342;
                        v342 = v5.length;
                        bool v343;
                        v343 = v342 < 128l;
                        bool v344;
                        v344 = v343 == false;
                        if (v344){
                            assert("The length has to be less than the maximum length of the array." && v343);
                        } else {
                        }
                        long v345;
                        v345 = v342 + 1l;
                        v5.length = v345;
                        bool v346;
                        v346 = 0l <= v342;
                        bool v349;
                        if (v346){
                            long v347;
                            v347 = v5.length;
                            bool v348;
                            v348 = v342 < v347;
                            v349 = v348;
                        } else {
                            v349 = false;
                        }
                        bool v350;
                        v350 = v349 == false;
                        if (v350){
                            assert("The set index needs to be in range for the static array list." && v349);
                        } else {
                        }
                        US3 v351;
                        v351 = US3_2(v198, v341);
                        v5.v[v342] = v351;
                        US8 v503;
                        switch (v341.tag) {
                            case 0: { // A_Call
                                static_array<long,2l> v353;
                                long v354;
                                v354 = 0l;
                                while (while_method_0(v354)){
                                    bool v356;
                                    v356 = 0l <= v354;
                                    bool v358;
                                    if (v356){
                                        bool v357;
                                        v357 = v354 < 2l;
                                        v358 = v357;
                                    } else {
                                        v358 = false;
                                    }
                                    bool v359;
                                    v359 = v358 == false;
                                    if (v359){
                                        assert("The read index needs to be in range for the static array." && v358);
                                    } else {
                                    }
                                    long v360;
                                    v360 = v200.v[v354];
                                    bool v362;
                                    if (v356){
                                        bool v361;
                                        v361 = v354 < 2l;
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
                                    long v364;
                                    v364 = v199.v[v354];
                                    long v365;
                                    v365 = v360 + v364;
                                    bool v367;
                                    if (v356){
                                        bool v366;
                                        v366 = v354 < 2l;
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
                                    v353.v[v354] = v365;
                                    v354 += 1l ;
                                }
                                long v369;
                                v369 = v199.v[0l];
                                long v370; long v371;
                                Tuple2 tmp49 = Tuple2(1l, v369);
                                v370 = tmp49.v0; v371 = tmp49.v1;
                                while (while_method_0(v370)){
                                    bool v373;
                                    v373 = 0l <= v370;
                                    bool v375;
                                    if (v373){
                                        bool v374;
                                        v374 = v370 < 2l;
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
                                    v377 = v199.v[v370];
                                    bool v378;
                                    v378 = v371 >= v377;
                                    long v379;
                                    if (v378){
                                        v379 = v371;
                                    } else {
                                        v379 = v377;
                                    }
                                    v371 = v379;
                                    v370 += 1l ;
                                }
                                static_array<long,2l> v380;
                                long v381;
                                v381 = 0l;
                                while (while_method_0(v381)){
                                    bool v383;
                                    v383 = 0l <= v381;
                                    bool v385;
                                    if (v383){
                                        bool v384;
                                        v384 = v381 < 2l;
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
                                    v387 = v353.v[v381];
                                    bool v388;
                                    v388 = v198 == v381;
                                    long v391;
                                    if (v388){
                                        bool v389;
                                        v389 = v371 < v387;
                                        if (v389){
                                            v391 = v371;
                                        } else {
                                            v391 = v387;
                                        }
                                    } else {
                                        v391 = v387;
                                    }
                                    bool v393;
                                    if (v383){
                                        bool v392;
                                        v392 = v381 < 2l;
                                        v393 = v392;
                                    } else {
                                        v393 = false;
                                    }
                                    bool v394;
                                    v394 = v393 == false;
                                    if (v394){
                                        assert("The read index needs to be in range for the static array." && v393);
                                    } else {
                                    }
                                    v380.v[v381] = v391;
                                    v381 += 1l ;
                                }
                                static_array<long,2l> v395;
                                long v396;
                                v396 = 0l;
                                while (while_method_0(v396)){
                                    bool v398;
                                    v398 = 0l <= v396;
                                    bool v400;
                                    if (v398){
                                        bool v399;
                                        v399 = v396 < 2l;
                                        v400 = v399;
                                    } else {
                                        v400 = false;
                                    }
                                    bool v401;
                                    v401 = v400 == false;
                                    if (v401){
                                        assert("The read index needs to be in range for the static array." && v400);
                                    } else {
                                    }
                                    long v402;
                                    v402 = v353.v[v396];
                                    bool v404;
                                    if (v398){
                                        bool v403;
                                        v403 = v396 < 2l;
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
                                    v406 = v380.v[v396];
                                    long v407;
                                    v407 = v402 - v406;
                                    bool v409;
                                    if (v398){
                                        bool v408;
                                        v408 = v396 < 2l;
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
                                    v395.v[v396] = v407;
                                    v396 += 1l ;
                                }
                                if (v196){
                                    v503 = US8_4(v195, false, v197, v279, v380, v395, v201);
                                } else {
                                    switch (v201.tag) {
                                        case 0: { // Flop
                                            static_array<Tuple0,3l> v413 = v201.v.case0.v0;
                                            v503 = US8_7(v195, v196, v197, v198, v380, v395, v201);
                                            break;
                                        }
                                        case 1: { // Preflop
                                            v503 = US8_0(v195, v196, v197, v198, v380, v395, v201);
                                            break;
                                        }
                                        case 2: { // River
                                            static_array<Tuple0,5l> v417 = v201.v.case2.v0;
                                            v503 = US8_6(v195, v196, v197, v198, v380, v395, v201);
                                            break;
                                        }
                                        case 3: { // Turn
                                            static_array<Tuple0,4l> v415 = v201.v.case3.v0;
                                            v503 = US8_3(v195, v196, v197, v198, v380, v395, v201);
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
                                v503 = US8_1(v195, v196, v197, v198, v199, v200, v201);
                                break;
                            }
                            case 2: { // A_Raise
                                long v424 = v341.v.case2.v0;
                                static_array<long,2l> v425;
                                long v426;
                                v426 = 0l;
                                while (while_method_0(v426)){
                                    bool v428;
                                    v428 = 0l <= v426;
                                    bool v430;
                                    if (v428){
                                        bool v429;
                                        v429 = v426 < 2l;
                                        v430 = v429;
                                    } else {
                                        v430 = false;
                                    }
                                    bool v431;
                                    v431 = v430 == false;
                                    if (v431){
                                        assert("The read index needs to be in range for the static array." && v430);
                                    } else {
                                    }
                                    long v432;
                                    v432 = v200.v[v426];
                                    bool v434;
                                    if (v428){
                                        bool v433;
                                        v433 = v426 < 2l;
                                        v434 = v433;
                                    } else {
                                        v434 = false;
                                    }
                                    bool v435;
                                    v435 = v434 == false;
                                    if (v435){
                                        assert("The read index needs to be in range for the static array." && v434);
                                    } else {
                                    }
                                    long v436;
                                    v436 = v199.v[v426];
                                    long v437;
                                    v437 = v432 + v436;
                                    bool v439;
                                    if (v428){
                                        bool v438;
                                        v438 = v426 < 2l;
                                        v439 = v438;
                                    } else {
                                        v439 = false;
                                    }
                                    bool v440;
                                    v440 = v439 == false;
                                    if (v440){
                                        assert("The read index needs to be in range for the static array." && v439);
                                    } else {
                                    }
                                    v425.v[v426] = v437;
                                    v426 += 1l ;
                                }
                                long v441;
                                v441 = v199.v[0l];
                                long v442; long v443;
                                Tuple2 tmp50 = Tuple2(1l, v441);
                                v442 = tmp50.v0; v443 = tmp50.v1;
                                while (while_method_0(v442)){
                                    bool v445;
                                    v445 = 0l <= v442;
                                    bool v447;
                                    if (v445){
                                        bool v446;
                                        v446 = v442 < 2l;
                                        v447 = v446;
                                    } else {
                                        v447 = false;
                                    }
                                    bool v448;
                                    v448 = v447 == false;
                                    if (v448){
                                        assert("The read index needs to be in range for the static array." && v447);
                                    } else {
                                    }
                                    long v449;
                                    v449 = v199.v[v442];
                                    bool v450;
                                    v450 = v443 >= v449;
                                    long v451;
                                    if (v450){
                                        v451 = v443;
                                    } else {
                                        v451 = v449;
                                    }
                                    v443 = v451;
                                    v442 += 1l ;
                                }
                                static_array<long,2l> v452;
                                long v453;
                                v453 = 0l;
                                while (while_method_0(v453)){
                                    bool v455;
                                    v455 = 0l <= v453;
                                    bool v457;
                                    if (v455){
                                        bool v456;
                                        v456 = v453 < 2l;
                                        v457 = v456;
                                    } else {
                                        v457 = false;
                                    }
                                    bool v458;
                                    v458 = v457 == false;
                                    if (v458){
                                        assert("The read index needs to be in range for the static array." && v457);
                                    } else {
                                    }
                                    long v459;
                                    v459 = v425.v[v453];
                                    bool v460;
                                    v460 = v198 == v453;
                                    long v463;
                                    if (v460){
                                        bool v461;
                                        v461 = v443 < v459;
                                        if (v461){
                                            v463 = v443;
                                        } else {
                                            v463 = v459;
                                        }
                                    } else {
                                        v463 = v459;
                                    }
                                    bool v465;
                                    if (v455){
                                        bool v464;
                                        v464 = v453 < 2l;
                                        v465 = v464;
                                    } else {
                                        v465 = false;
                                    }
                                    bool v466;
                                    v466 = v465 == false;
                                    if (v466){
                                        assert("The read index needs to be in range for the static array." && v465);
                                    } else {
                                    }
                                    v452.v[v453] = v463;
                                    v453 += 1l ;
                                }
                                static_array<long,2l> v467;
                                long v468;
                                v468 = 0l;
                                while (while_method_0(v468)){
                                    bool v470;
                                    v470 = 0l <= v468;
                                    bool v472;
                                    if (v470){
                                        bool v471;
                                        v471 = v468 < 2l;
                                        v472 = v471;
                                    } else {
                                        v472 = false;
                                    }
                                    bool v473;
                                    v473 = v472 == false;
                                    if (v473){
                                        assert("The read index needs to be in range for the static array." && v472);
                                    } else {
                                    }
                                    long v474;
                                    v474 = v425.v[v468];
                                    bool v476;
                                    if (v470){
                                        bool v475;
                                        v475 = v468 < 2l;
                                        v476 = v475;
                                    } else {
                                        v476 = false;
                                    }
                                    bool v477;
                                    v477 = v476 == false;
                                    if (v477){
                                        assert("The read index needs to be in range for the static array." && v476);
                                    } else {
                                    }
                                    long v478;
                                    v478 = v452.v[v468];
                                    long v479;
                                    v479 = v474 - v478;
                                    bool v481;
                                    if (v470){
                                        bool v480;
                                        v480 = v468 < 2l;
                                        v481 = v480;
                                    } else {
                                        v481 = false;
                                    }
                                    bool v482;
                                    v482 = v481 == false;
                                    if (v482){
                                        assert("The read index needs to be in range for the static array." && v481);
                                    } else {
                                    }
                                    v467.v[v468] = v479;
                                    v468 += 1l ;
                                }
                                bool v484;
                                if (v280){
                                    bool v483;
                                    v483 = v279 < 2l;
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
                                long v486;
                                v486 = v467.v[v279];
                                bool v487;
                                v487 = v486 > 0l;
                                if (v487){
                                    v503 = US8_4(v195, false, v197, v279, v452, v467, v201);
                                } else {
                                    switch (v201.tag) {
                                        case 0: { // Flop
                                            static_array<Tuple0,3l> v490 = v201.v.case0.v0;
                                            v503 = US8_7(v195, v196, v197, v198, v452, v467, v201);
                                            break;
                                        }
                                        case 1: { // Preflop
                                            v503 = US8_0(v195, v196, v197, v198, v452, v467, v201);
                                            break;
                                        }
                                        case 2: { // River
                                            static_array<Tuple0,5l> v494 = v201.v.case2.v0;
                                            v503 = US8_6(v195, v196, v197, v198, v452, v467, v201);
                                            break;
                                        }
                                        case 3: { // Turn
                                            static_array<Tuple0,4l> v492 = v201.v.case3.v0;
                                            v503 = US8_3(v195, v196, v197, v198, v452, v467, v201);
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
                        v924 = true; v925 = v503;
                        break;
                    }
                    case 1: { // Human
                        v924 = false; v925 = v8;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 5: { // G_Round'
                long v508 = v8.v.case5.v0; bool v509 = v8.v.case5.v1; static_array<static_array<Tuple0,2l>,2l> v510 = v8.v.case5.v2; long v511 = v8.v.case5.v3; static_array<long,2l> v512 = v8.v.case5.v4; static_array<long,2l> v513 = v8.v.case5.v5; US9 v514 = v8.v.case5.v6; US1 v515 = v8.v.case5.v7;
                long v516;
                v516 = v5.length;
                bool v517;
                v517 = v516 < 128l;
                bool v518;
                v518 = v517 == false;
                if (v518){
                    assert("The length has to be less than the maximum length of the array." && v517);
                } else {
                }
                long v519;
                v519 = v516 + 1l;
                v5.length = v519;
                bool v520;
                v520 = 0l <= v516;
                bool v523;
                if (v520){
                    long v521;
                    v521 = v5.length;
                    bool v522;
                    v522 = v516 < v521;
                    v523 = v522;
                } else {
                    v523 = false;
                }
                bool v524;
                v524 = v523 == false;
                if (v524){
                    assert("The set index needs to be in range for the static array list." && v523);
                } else {
                }
                US3 v525;
                v525 = US3_2(v511, v515);
                v5.v[v516] = v525;
                US8 v680;
                switch (v515.tag) {
                    case 0: { // A_Call
                        static_array<long,2l> v527;
                        long v528;
                        v528 = 0l;
                        while (while_method_0(v528)){
                            bool v530;
                            v530 = 0l <= v528;
                            bool v532;
                            if (v530){
                                bool v531;
                                v531 = v528 < 2l;
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
                            long v534;
                            v534 = v513.v[v528];
                            bool v536;
                            if (v530){
                                bool v535;
                                v535 = v528 < 2l;
                                v536 = v535;
                            } else {
                                v536 = false;
                            }
                            bool v537;
                            v537 = v536 == false;
                            if (v537){
                                assert("The read index needs to be in range for the static array." && v536);
                            } else {
                            }
                            long v538;
                            v538 = v512.v[v528];
                            long v539;
                            v539 = v534 + v538;
                            bool v541;
                            if (v530){
                                bool v540;
                                v540 = v528 < 2l;
                                v541 = v540;
                            } else {
                                v541 = false;
                            }
                            bool v542;
                            v542 = v541 == false;
                            if (v542){
                                assert("The read index needs to be in range for the static array." && v541);
                            } else {
                            }
                            v527.v[v528] = v539;
                            v528 += 1l ;
                        }
                        long v543;
                        v543 = v512.v[0l];
                        long v544; long v545;
                        Tuple2 tmp51 = Tuple2(1l, v543);
                        v544 = tmp51.v0; v545 = tmp51.v1;
                        while (while_method_0(v544)){
                            bool v547;
                            v547 = 0l <= v544;
                            bool v549;
                            if (v547){
                                bool v548;
                                v548 = v544 < 2l;
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
                            long v551;
                            v551 = v512.v[v544];
                            bool v552;
                            v552 = v545 >= v551;
                            long v553;
                            if (v552){
                                v553 = v545;
                            } else {
                                v553 = v551;
                            }
                            v545 = v553;
                            v544 += 1l ;
                        }
                        static_array<long,2l> v554;
                        long v555;
                        v555 = 0l;
                        while (while_method_0(v555)){
                            bool v557;
                            v557 = 0l <= v555;
                            bool v559;
                            if (v557){
                                bool v558;
                                v558 = v555 < 2l;
                                v559 = v558;
                            } else {
                                v559 = false;
                            }
                            bool v560;
                            v560 = v559 == false;
                            if (v560){
                                assert("The read index needs to be in range for the static array." && v559);
                            } else {
                            }
                            long v561;
                            v561 = v527.v[v555];
                            bool v562;
                            v562 = v511 == v555;
                            long v565;
                            if (v562){
                                bool v563;
                                v563 = v545 < v561;
                                if (v563){
                                    v565 = v545;
                                } else {
                                    v565 = v561;
                                }
                            } else {
                                v565 = v561;
                            }
                            bool v567;
                            if (v557){
                                bool v566;
                                v566 = v555 < 2l;
                                v567 = v566;
                            } else {
                                v567 = false;
                            }
                            bool v568;
                            v568 = v567 == false;
                            if (v568){
                                assert("The read index needs to be in range for the static array." && v567);
                            } else {
                            }
                            v554.v[v555] = v565;
                            v555 += 1l ;
                        }
                        static_array<long,2l> v569;
                        long v570;
                        v570 = 0l;
                        while (while_method_0(v570)){
                            bool v572;
                            v572 = 0l <= v570;
                            bool v574;
                            if (v572){
                                bool v573;
                                v573 = v570 < 2l;
                                v574 = v573;
                            } else {
                                v574 = false;
                            }
                            bool v575;
                            v575 = v574 == false;
                            if (v575){
                                assert("The read index needs to be in range for the static array." && v574);
                            } else {
                            }
                            long v576;
                            v576 = v527.v[v570];
                            bool v578;
                            if (v572){
                                bool v577;
                                v577 = v570 < 2l;
                                v578 = v577;
                            } else {
                                v578 = false;
                            }
                            bool v579;
                            v579 = v578 == false;
                            if (v579){
                                assert("The read index needs to be in range for the static array." && v578);
                            } else {
                            }
                            long v580;
                            v580 = v554.v[v570];
                            long v581;
                            v581 = v576 - v580;
                            bool v583;
                            if (v572){
                                bool v582;
                                v582 = v570 < 2l;
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
                            v569.v[v570] = v581;
                            v570 += 1l ;
                        }
                        if (v509){
                            long v585;
                            v585 = v511 ^ 1l;
                            v680 = US8_4(v508, false, v510, v585, v554, v569, v514);
                        } else {
                            switch (v514.tag) {
                                case 0: { // Flop
                                    static_array<Tuple0,3l> v588 = v514.v.case0.v0;
                                    v680 = US8_7(v508, v509, v510, v511, v554, v569, v514);
                                    break;
                                }
                                case 1: { // Preflop
                                    v680 = US8_0(v508, v509, v510, v511, v554, v569, v514);
                                    break;
                                }
                                case 2: { // River
                                    static_array<Tuple0,5l> v592 = v514.v.case2.v0;
                                    v680 = US8_6(v508, v509, v510, v511, v554, v569, v514);
                                    break;
                                }
                                case 3: { // Turn
                                    static_array<Tuple0,4l> v590 = v514.v.case3.v0;
                                    v680 = US8_3(v508, v509, v510, v511, v554, v569, v514);
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
                        v680 = US8_1(v508, v509, v510, v511, v512, v513, v514);
                        break;
                    }
                    case 2: { // A_Raise
                        long v599 = v515.v.case2.v0;
                        static_array<long,2l> v600;
                        long v601;
                        v601 = 0l;
                        while (while_method_0(v601)){
                            bool v603;
                            v603 = 0l <= v601;
                            bool v605;
                            if (v603){
                                bool v604;
                                v604 = v601 < 2l;
                                v605 = v604;
                            } else {
                                v605 = false;
                            }
                            bool v606;
                            v606 = v605 == false;
                            if (v606){
                                assert("The read index needs to be in range for the static array." && v605);
                            } else {
                            }
                            long v607;
                            v607 = v513.v[v601];
                            bool v609;
                            if (v603){
                                bool v608;
                                v608 = v601 < 2l;
                                v609 = v608;
                            } else {
                                v609 = false;
                            }
                            bool v610;
                            v610 = v609 == false;
                            if (v610){
                                assert("The read index needs to be in range for the static array." && v609);
                            } else {
                            }
                            long v611;
                            v611 = v512.v[v601];
                            long v612;
                            v612 = v607 + v611;
                            bool v614;
                            if (v603){
                                bool v613;
                                v613 = v601 < 2l;
                                v614 = v613;
                            } else {
                                v614 = false;
                            }
                            bool v615;
                            v615 = v614 == false;
                            if (v615){
                                assert("The read index needs to be in range for the static array." && v614);
                            } else {
                            }
                            v600.v[v601] = v612;
                            v601 += 1l ;
                        }
                        long v616;
                        v616 = v512.v[0l];
                        long v617; long v618;
                        Tuple2 tmp52 = Tuple2(1l, v616);
                        v617 = tmp52.v0; v618 = tmp52.v1;
                        while (while_method_0(v617)){
                            bool v620;
                            v620 = 0l <= v617;
                            bool v622;
                            if (v620){
                                bool v621;
                                v621 = v617 < 2l;
                                v622 = v621;
                            } else {
                                v622 = false;
                            }
                            bool v623;
                            v623 = v622 == false;
                            if (v623){
                                assert("The read index needs to be in range for the static array." && v622);
                            } else {
                            }
                            long v624;
                            v624 = v512.v[v617];
                            bool v625;
                            v625 = v618 >= v624;
                            long v626;
                            if (v625){
                                v626 = v618;
                            } else {
                                v626 = v624;
                            }
                            v618 = v626;
                            v617 += 1l ;
                        }
                        static_array<long,2l> v627;
                        long v628;
                        v628 = 0l;
                        while (while_method_0(v628)){
                            bool v630;
                            v630 = 0l <= v628;
                            bool v632;
                            if (v630){
                                bool v631;
                                v631 = v628 < 2l;
                                v632 = v631;
                            } else {
                                v632 = false;
                            }
                            bool v633;
                            v633 = v632 == false;
                            if (v633){
                                assert("The read index needs to be in range for the static array." && v632);
                            } else {
                            }
                            long v634;
                            v634 = v600.v[v628];
                            bool v635;
                            v635 = v511 == v628;
                            long v638;
                            if (v635){
                                bool v636;
                                v636 = v618 < v634;
                                if (v636){
                                    v638 = v618;
                                } else {
                                    v638 = v634;
                                }
                            } else {
                                v638 = v634;
                            }
                            bool v640;
                            if (v630){
                                bool v639;
                                v639 = v628 < 2l;
                                v640 = v639;
                            } else {
                                v640 = false;
                            }
                            bool v641;
                            v641 = v640 == false;
                            if (v641){
                                assert("The read index needs to be in range for the static array." && v640);
                            } else {
                            }
                            v627.v[v628] = v638;
                            v628 += 1l ;
                        }
                        static_array<long,2l> v642;
                        long v643;
                        v643 = 0l;
                        while (while_method_0(v643)){
                            bool v645;
                            v645 = 0l <= v643;
                            bool v647;
                            if (v645){
                                bool v646;
                                v646 = v643 < 2l;
                                v647 = v646;
                            } else {
                                v647 = false;
                            }
                            bool v648;
                            v648 = v647 == false;
                            if (v648){
                                assert("The read index needs to be in range for the static array." && v647);
                            } else {
                            }
                            long v649;
                            v649 = v600.v[v643];
                            bool v651;
                            if (v645){
                                bool v650;
                                v650 = v643 < 2l;
                                v651 = v650;
                            } else {
                                v651 = false;
                            }
                            bool v652;
                            v652 = v651 == false;
                            if (v652){
                                assert("The read index needs to be in range for the static array." && v651);
                            } else {
                            }
                            long v653;
                            v653 = v627.v[v643];
                            long v654;
                            v654 = v649 - v653;
                            bool v656;
                            if (v645){
                                bool v655;
                                v655 = v643 < 2l;
                                v656 = v655;
                            } else {
                                v656 = false;
                            }
                            bool v657;
                            v657 = v656 == false;
                            if (v657){
                                assert("The read index needs to be in range for the static array." && v656);
                            } else {
                            }
                            v642.v[v643] = v654;
                            v643 += 1l ;
                        }
                        long v658;
                        v658 = v511 ^ 1l;
                        bool v659;
                        v659 = 0l <= v658;
                        bool v661;
                        if (v659){
                            bool v660;
                            v660 = v658 < 2l;
                            v661 = v660;
                        } else {
                            v661 = false;
                        }
                        bool v662;
                        v662 = v661 == false;
                        if (v662){
                            assert("The read index needs to be in range for the static array." && v661);
                        } else {
                        }
                        long v663;
                        v663 = v642.v[v658];
                        bool v664;
                        v664 = v663 > 0l;
                        if (v664){
                            v680 = US8_4(v508, false, v510, v658, v627, v642, v514);
                        } else {
                            switch (v514.tag) {
                                case 0: { // Flop
                                    static_array<Tuple0,3l> v667 = v514.v.case0.v0;
                                    v680 = US8_7(v508, v509, v510, v511, v627, v642, v514);
                                    break;
                                }
                                case 1: { // Preflop
                                    v680 = US8_0(v508, v509, v510, v511, v627, v642, v514);
                                    break;
                                }
                                case 2: { // River
                                    static_array<Tuple0,5l> v671 = v514.v.case2.v0;
                                    v680 = US8_6(v508, v509, v510, v511, v627, v642, v514);
                                    break;
                                }
                                case 3: { // Turn
                                    static_array<Tuple0,4l> v669 = v514.v.case3.v0;
                                    v680 = US8_3(v508, v509, v510, v511, v627, v642, v514);
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
                v924 = true; v925 = v680;
                break;
            }
            case 6: { // G_Showdown
                long v33 = v8.v.case6.v0; bool v34 = v8.v.case6.v1; static_array<static_array<Tuple0,2l>,2l> v35 = v8.v.case6.v2; long v36 = v8.v.case6.v3; static_array<long,2l> v37 = v8.v.case6.v4; static_array<long,2l> v38 = v8.v.case6.v5; US9 v39 = v8.v.case6.v6;
                static_array<Card,5l> v57;
                switch (v39.tag) {
                    case 2: { // River
                        static_array<Tuple0,5l> v40 = v39.v.case2.v0;
                        static_array<Card,5l> v41;
                        long v42;
                        v42 = 0l;
                        while (while_method_2(v42)){
                            bool v44;
                            v44 = 0l <= v42;
                            bool v46;
                            if (v44){
                                bool v45;
                                v45 = v42 < 5l;
                                v46 = v45;
                            } else {
                                v46 = false;
                            }
                            bool v47;
                            v47 = v46 == false;
                            if (v47){
                                assert("The read index needs to be in range for the static array." && v46);
                            } else {
                            }
                            US4 v48; US5 v49;
                            Tuple0 tmp53 = v40.v[v42];
                            v48 = tmp53.v0; v49 = tmp53.v1;
                            unsigned char v50;
                            v50 = card_rank_tag_45(v48);
                            unsigned char v51;
                            v51 = card_suit_tag_46(v49);
                            Card v52;
                            v52 = {v50, v51};
                            bool v54;
                            if (v44){
                                bool v53;
                                v53 = v42 < 5l;
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
                            v41.v[v42] = v52;
                            v42 += 1l ;
                        }
                        v57 = v41;
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in showdown.");
                        asm("exit;");
                    }
                }
                static_array<Tuple0,2l> v58;
                v58 = v35.v[0l];
                static_array<Card,2l> v59;
                long v60;
                v60 = 0l;
                while (while_method_0(v60)){
                    bool v62;
                    v62 = 0l <= v60;
                    bool v64;
                    if (v62){
                        bool v63;
                        v63 = v60 < 2l;
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
                    US4 v66; US5 v67;
                    Tuple0 tmp54 = v58.v[v60];
                    v66 = tmp54.v0; v67 = tmp54.v1;
                    unsigned char v68;
                    v68 = card_rank_tag_45(v66);
                    unsigned char v69;
                    v69 = card_suit_tag_46(v67);
                    Card v70;
                    v70 = {v68, v69};
                    bool v72;
                    if (v62){
                        bool v71;
                        v71 = v60 < 2l;
                        v72 = v71;
                    } else {
                        v72 = false;
                    }
                    bool v73;
                    v73 = v72 == false;
                    if (v73){
                        assert("The read index needs to be in range for the static array." && v72);
                    } else {
                    }
                    v59.v[v60] = v70;
                    v60 += 1l ;
                }
                static_array<Card,7l> v74;
                long v75;
                v75 = 0l;
                while (while_method_0(v75)){
                    bool v77;
                    v77 = 0l <= v75;
                    bool v79;
                    if (v77){
                        bool v78;
                        v78 = v75 < 2l;
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
                    Card v81;
                    v81 = v59.v[v75];
                    bool v83;
                    if (v77){
                        bool v82;
                        v82 = v75 < 7l;
                        v83 = v82;
                    } else {
                        v83 = false;
                    }
                    bool v84;
                    v84 = v83 == false;
                    if (v84){
                        assert("The read index needs to be in range for the static array." && v83);
                    } else {
                    }
                    v74.v[v75] = v81;
                    v75 += 1l ;
                }
                long v85;
                v85 = 0l;
                while (while_method_2(v85)){
                    bool v87;
                    v87 = 0l <= v85;
                    bool v89;
                    if (v87){
                        bool v88;
                        v88 = v85 < 5l;
                        v89 = v88;
                    } else {
                        v89 = false;
                    }
                    bool v90;
                    v90 = v89 == false;
                    if (v90){
                        assert("The read index needs to be in range for the static array." && v89);
                    } else {
                    }
                    Card v91;
                    v91 = v57.v[v85];
                    long v92;
                    v92 = 2l + v85;
                    bool v93;
                    v93 = 0l <= v92;
                    bool v95;
                    if (v93){
                        bool v94;
                        v94 = v92 < 7l;
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
                    v74.v[v92] = v91;
                    v85 += 1l ;
                }
                static_array<Card,5l> v97; char v98;
                Tuple16 tmp79 = score_47(v74);
                v97 = tmp79.v0; v98 = tmp79.v1;
                static_array<Tuple0,2l> v99;
                v99 = v35.v[1l];
                static_array<Card,2l> v100;
                long v101;
                v101 = 0l;
                while (while_method_0(v101)){
                    bool v103;
                    v103 = 0l <= v101;
                    bool v105;
                    if (v103){
                        bool v104;
                        v104 = v101 < 2l;
                        v105 = v104;
                    } else {
                        v105 = false;
                    }
                    bool v106;
                    v106 = v105 == false;
                    if (v106){
                        assert("The read index needs to be in range for the static array." && v105);
                    } else {
                    }
                    US4 v107; US5 v108;
                    Tuple0 tmp80 = v99.v[v101];
                    v107 = tmp80.v0; v108 = tmp80.v1;
                    unsigned char v109;
                    v109 = card_rank_tag_45(v107);
                    unsigned char v110;
                    v110 = card_suit_tag_46(v108);
                    Card v111;
                    v111 = {v109, v110};
                    bool v113;
                    if (v103){
                        bool v112;
                        v112 = v101 < 2l;
                        v113 = v112;
                    } else {
                        v113 = false;
                    }
                    bool v114;
                    v114 = v113 == false;
                    if (v114){
                        assert("The read index needs to be in range for the static array." && v113);
                    } else {
                    }
                    v100.v[v101] = v111;
                    v101 += 1l ;
                }
                static_array<Card,7l> v115;
                long v116;
                v116 = 0l;
                while (while_method_0(v116)){
                    bool v118;
                    v118 = 0l <= v116;
                    bool v120;
                    if (v118){
                        bool v119;
                        v119 = v116 < 2l;
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
                    Card v122;
                    v122 = v100.v[v116];
                    bool v124;
                    if (v118){
                        bool v123;
                        v123 = v116 < 7l;
                        v124 = v123;
                    } else {
                        v124 = false;
                    }
                    bool v125;
                    v125 = v124 == false;
                    if (v125){
                        assert("The read index needs to be in range for the static array." && v124);
                    } else {
                    }
                    v115.v[v116] = v122;
                    v116 += 1l ;
                }
                long v126;
                v126 = 0l;
                while (while_method_2(v126)){
                    bool v128;
                    v128 = 0l <= v126;
                    bool v130;
                    if (v128){
                        bool v129;
                        v129 = v126 < 5l;
                        v130 = v129;
                    } else {
                        v130 = false;
                    }
                    bool v131;
                    v131 = v130 == false;
                    if (v131){
                        assert("The read index needs to be in range for the static array." && v130);
                    } else {
                    }
                    Card v132;
                    v132 = v57.v[v126];
                    long v133;
                    v133 = 2l + v126;
                    bool v134;
                    v134 = 0l <= v133;
                    bool v136;
                    if (v134){
                        bool v135;
                        v135 = v133 < 7l;
                        v136 = v135;
                    } else {
                        v136 = false;
                    }
                    bool v137;
                    v137 = v136 == false;
                    if (v137){
                        assert("The read index needs to be in range for the static array." && v136);
                    } else {
                    }
                    v115.v[v133] = v132;
                    v126 += 1l ;
                }
                static_array<Card,5l> v138; char v139;
                Tuple16 tmp81 = score_47(v115);
                v138 = tmp81.v0; v139 = tmp81.v1;
                bool v140;
                v140 = 0l <= v36;
                bool v142;
                if (v140){
                    bool v141;
                    v141 = v36 < 2l;
                    v142 = v141;
                } else {
                    v142 = false;
                }
                bool v143;
                v143 = v142 == false;
                if (v143){
                    assert("The read index needs to be in range for the static array." && v142);
                } else {
                }
                long v144;
                v144 = v37.v[v36];
                bool v145;
                v145 = v98 < v139;
                US11 v151;
                if (v145){
                    v151 = US11_2();
                } else {
                    bool v147;
                    v147 = v98 > v139;
                    if (v147){
                        v151 = US11_1();
                    } else {
                        v151 = US11_0();
                    }
                }
                US11 v175;
                switch (v151.tag) {
                    case 0: { // Eq
                        US11 v152;
                        v152 = US11_0();
                        long v153;
                        v153 = 0l;
                        while (while_method_2(v153)){
                            bool v155;
                            v155 = 0l <= v153;
                            bool v157;
                            if (v155){
                                bool v156;
                                v156 = v153 < 5l;
                                v157 = v156;
                            } else {
                                v157 = false;
                            }
                            bool v158;
                            v158 = v157 == false;
                            if (v158){
                                assert("The read index needs to be in range for the static array." && v157);
                            } else {
                            }
                            Card v159;
                            v159 = v97.v[v153];
                            bool v161;
                            if (v155){
                                bool v160;
                                v160 = v153 < 5l;
                                v161 = v160;
                            } else {
                                v161 = false;
                            }
                            bool v162;
                            v162 = v161 == false;
                            if (v162){
                                assert("The read index needs to be in range for the static array." && v161);
                            } else {
                            }
                            Card v163;
                            v163 = v138.v[v153];
                            unsigned char v164;
                            v164 = v159.suit * 13 + v159.rank;
                            unsigned char v165;
                            v165 = v163.suit * 13 + v163.rank;
                            bool v166;
                            v166 = v164 < v165;
                            US11 v172;
                            if (v166){
                                v172 = US11_2();
                            } else {
                                bool v168;
                                v168 = v164 > v165;
                                if (v168){
                                    v172 = US11_1();
                                } else {
                                    v172 = US11_0();
                                }
                            }
                            bool v173;
                            switch (v172.tag) {
                                case 0: { // Eq
                                    v173 = true;
                                    break;
                                }
                                default: {
                                    v173 = false;
                                }
                            }
                            bool v174;
                            v174 = v173 == false;
                            if (v174){
                                v152 = v172;
                                break;
                            } else {
                            }
                            v153 += 1l ;
                        }
                        v175 = v152;
                        break;
                    }
                    default: {
                        v175 = v151;
                    }
                }
                long v180; long v181;
                switch (v175.tag) {
                    case 0: { // Eq
                        v180 = 0l; v181 = -1l;
                        break;
                    }
                    case 1: { // Gt
                        v180 = v144; v181 = 0l;
                        break;
                    }
                    case 2: { // Lt
                        v180 = v144; v181 = 1l;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                US6 v182;
                v182 = hand_from_lib_hand_score_48(v97, v98);
                US6 v183;
                v183 = hand_from_lib_hand_score_48(v138, v139);
                static_array<US6,2l> v184;
                v184.v[0l] = v182;
                v184.v[1l] = v183;
                long v185;
                v185 = v5.length;
                bool v186;
                v186 = v185 < 128l;
                bool v187;
                v187 = v186 == false;
                if (v187){
                    assert("The length has to be less than the maximum length of the array." && v186);
                } else {
                }
                long v188;
                v188 = v185 + 1l;
                v5.length = v188;
                bool v189;
                v189 = 0l <= v185;
                bool v192;
                if (v189){
                    long v190;
                    v190 = v5.length;
                    bool v191;
                    v191 = v185 < v190;
                    v192 = v191;
                } else {
                    v192 = false;
                }
                bool v193;
                v193 = v192 == false;
                if (v193){
                    assert("The set index needs to be in range for the static array list." && v192);
                } else {
                }
                US3 v194;
                v194 = US3_4(v180, v184, v181);
                v5.v[v185] = v194;
                v924 = false; v925 = v8;
                break;
            }
            case 7: { // G_Turn
                long v718 = v8.v.case7.v0; bool v719 = v8.v.case7.v1; static_array<static_array<Tuple0,2l>,2l> v720 = v8.v.case7.v2; long v721 = v8.v.case7.v3; static_array<long,2l> v722 = v8.v.case7.v4; static_array<long,2l> v723 = v8.v.case7.v5; US9 v724 = v8.v.case7.v6;
                static_array<Card,1l> v725; unsigned long long v726;
                Tuple14 tmp83 = draw_cards_40(v2, v6);
                v725 = tmp83.v0; v726 = tmp83.v1;
                v0 = v726;
                static_array<Tuple0,1l> v727;
                long v728;
                v728 = 0l;
                while (while_method_6(v728)){
                    bool v730;
                    v730 = 0l <= v728;
                    bool v732;
                    if (v730){
                        bool v731;
                        v731 = v728 < 1l;
                        v732 = v731;
                    } else {
                        v732 = false;
                    }
                    bool v733;
                    v733 = v732 == false;
                    if (v733){
                        assert("The read index needs to be in range for the static array." && v732);
                    } else {
                    }
                    Card v734;
                    v734 = v725.v[v728];
                    US4 v735; US5 v736;
                    Tuple0 tmp84 = card_from_lib_card_35(v734);
                    v735 = tmp84.v0; v736 = tmp84.v1;
                    bool v738;
                    if (v730){
                        bool v737;
                        v737 = v728 < 1l;
                        v738 = v737;
                    } else {
                        v738 = false;
                    }
                    bool v739;
                    v739 = v738 == false;
                    if (v739){
                        assert("The read index needs to be in range for the static array." && v738);
                    } else {
                    }
                    v727.v[v728] = Tuple0(v735, v736);
                    v728 += 1l ;
                }
                static_array_list<Tuple0,5l,long> v740;
                v740 = get_community_cards_41(v724, v727);
                long v741;
                v741 = v5.length;
                bool v742;
                v742 = v741 < 128l;
                bool v743;
                v743 = v742 == false;
                if (v743){
                    assert("The length has to be less than the maximum length of the array." && v742);
                } else {
                }
                long v744;
                v744 = v741 + 1l;
                v5.length = v744;
                bool v745;
                v745 = 0l <= v741;
                bool v748;
                if (v745){
                    long v746;
                    v746 = v5.length;
                    bool v747;
                    v747 = v741 < v746;
                    v748 = v747;
                } else {
                    v748 = false;
                }
                bool v749;
                v749 = v748 == false;
                if (v749){
                    assert("The set index needs to be in range for the static array list." && v748);
                } else {
                }
                US3 v750;
                v750 = US3_0(v740);
                v5.v[v741] = v750;
                US9 v779;
                switch (v724.tag) {
                    case 0: { // Flop
                        static_array<Tuple0,3l> v751 = v724.v.case0.v0;
                        static_array<Tuple0,4l> v752;
                        long v753;
                        v753 = 0l;
                        while (while_method_3(v753)){
                            bool v755;
                            v755 = 0l <= v753;
                            bool v757;
                            if (v755){
                                bool v756;
                                v756 = v753 < 3l;
                                v757 = v756;
                            } else {
                                v757 = false;
                            }
                            bool v758;
                            v758 = v757 == false;
                            if (v758){
                                assert("The read index needs to be in range for the static array." && v757);
                            } else {
                            }
                            US4 v759; US5 v760;
                            Tuple0 tmp85 = v751.v[v753];
                            v759 = tmp85.v0; v760 = tmp85.v1;
                            bool v762;
                            if (v755){
                                bool v761;
                                v761 = v753 < 4l;
                                v762 = v761;
                            } else {
                                v762 = false;
                            }
                            bool v763;
                            v763 = v762 == false;
                            if (v763){
                                assert("The read index needs to be in range for the static array." && v762);
                            } else {
                            }
                            v752.v[v753] = Tuple0(v759, v760);
                            v753 += 1l ;
                        }
                        long v764;
                        v764 = 0l;
                        while (while_method_6(v764)){
                            bool v766;
                            v766 = 0l <= v764;
                            bool v768;
                            if (v766){
                                bool v767;
                                v767 = v764 < 1l;
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
                            US4 v770; US5 v771;
                            Tuple0 tmp86 = v727.v[v764];
                            v770 = tmp86.v0; v771 = tmp86.v1;
                            long v772;
                            v772 = 3l + v764;
                            bool v773;
                            v773 = 0l <= v772;
                            bool v775;
                            if (v773){
                                bool v774;
                                v774 = v772 < 4l;
                                v775 = v774;
                            } else {
                                v775 = false;
                            }
                            bool v776;
                            v776 = v775 == false;
                            if (v776){
                                assert("The read index needs to be in range for the static array." && v775);
                            } else {
                            }
                            v752.v[v772] = Tuple0(v770, v771);
                            v764 += 1l ;
                        }
                        v779 = US9_3(v752);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid street in turn.");
                        asm("exit;");
                    }
                }
                US8 v780;
                v780 = US8_4(v718, true, v720, 0l, v722, v723, v779);
                v924 = true; v925 = v780;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v7 = v924;
        v8 = v925;
    }
    return v8;
}
__device__ Tuple8 play_loop_30(US7 v0, static_array<US2,2l> v1, US10 v2, unsigned long long & v3, static_array_list<US3,128l,long> & v4, curandStatePhilox4_32_10_t & v5, US8 v6){
    US8 v7;
    v7 = play_loop_inner_31(v3, v4, v5, v1, v6);
    switch (v7.tag) {
        case 1: { // G_Fold
            long v26 = v7.v.case1.v0; bool v27 = v7.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v28 = v7.v.case1.v2; long v29 = v7.v.case1.v3; static_array<long,2l> v30 = v7.v.case1.v4; static_array<long,2l> v31 = v7.v.case1.v5; US9 v32 = v7.v.case1.v6;
            US7 v33;
            v33 = US7_0();
            US10 v34;
            v34 = US10_1(v26, v27, v28, v29, v30, v31, v32);
            return Tuple8(v33, v1, v34);
            break;
        }
        case 4: { // G_Round
            long v8 = v7.v.case4.v0; bool v9 = v7.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v10 = v7.v.case4.v2; long v11 = v7.v.case4.v3; static_array<long,2l> v12 = v7.v.case4.v4; static_array<long,2l> v13 = v7.v.case4.v5; US9 v14 = v7.v.case4.v6;
            US7 v15;
            v15 = US7_1(v7);
            US10 v16;
            v16 = US10_2(v8, v9, v10, v11, v12, v13, v14);
            return Tuple8(v15, v1, v16);
            break;
        }
        case 6: { // G_Showdown
            long v17 = v7.v.case6.v0; bool v18 = v7.v.case6.v1; static_array<static_array<Tuple0,2l>,2l> v19 = v7.v.case6.v2; long v20 = v7.v.case6.v3; static_array<long,2l> v21 = v7.v.case6.v4; static_array<long,2l> v22 = v7.v.case6.v5; US9 v23 = v7.v.case6.v6;
            US7 v24;
            v24 = US7_0();
            US10 v25;
            v25 = US10_1(v17, v18, v19, v20, v21, v22, v23);
            return Tuple8(v24, v1, v25);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
__device__ void write_50(char v0){
    const char * v1;
    v1 = "%c";
    printf(v1,v0);
    return ;
}
__device__ void write_51(){
    return ;
}
__device__ void write_54(unsigned long long v0){
    const char * v1;
    v1 = "%u";
    printf(v1,v0);
    return ;
}
__device__ void write_53(unsigned long long v0){
    return write_54(v0);
}
__device__ void write_57(){
    const char * v0;
    v0 = "CommunityCardsAre";
    return write_0(v0);
}
__device__ void write_61(){
    const char * v0;
    v0 = "Ace";
    return write_0(v0);
}
__device__ void write_62(){
    const char * v0;
    v0 = "Eight";
    return write_0(v0);
}
__device__ void write_63(){
    const char * v0;
    v0 = "Five";
    return write_0(v0);
}
__device__ void write_64(){
    const char * v0;
    v0 = "Four";
    return write_0(v0);
}
__device__ void write_65(){
    const char * v0;
    v0 = "Jack";
    return write_0(v0);
}
__device__ void write_66(){
    const char * v0;
    v0 = "King";
    return write_0(v0);
}
__device__ void write_67(){
    const char * v0;
    v0 = "Nine";
    return write_0(v0);
}
__device__ void write_68(){
    const char * v0;
    v0 = "Queen";
    return write_0(v0);
}
__device__ void write_69(){
    const char * v0;
    v0 = "Seven";
    return write_0(v0);
}
__device__ void write_70(){
    const char * v0;
    v0 = "Six";
    return write_0(v0);
}
__device__ void write_71(){
    const char * v0;
    v0 = "Ten";
    return write_0(v0);
}
__device__ void write_72(){
    const char * v0;
    v0 = "Three";
    return write_0(v0);
}
__device__ void write_73(){
    const char * v0;
    v0 = "Two";
    return write_0(v0);
}
__device__ void write_60(US4 v0){
    switch (v0.tag) {
        case 0: { // Ace
            return write_61();
            break;
        }
        case 1: { // Eight
            return write_62();
            break;
        }
        case 2: { // Five
            return write_63();
            break;
        }
        case 3: { // Four
            return write_64();
            break;
        }
        case 4: { // Jack
            return write_65();
            break;
        }
        case 5: { // King
            return write_66();
            break;
        }
        case 6: { // Nine
            return write_67();
            break;
        }
        case 7: { // Queen
            return write_68();
            break;
        }
        case 8: { // Seven
            return write_69();
            break;
        }
        case 9: { // Six
            return write_70();
            break;
        }
        case 10: { // Ten
            return write_71();
            break;
        }
        case 11: { // Three
            return write_72();
            break;
        }
        case 12: { // Two
            return write_73();
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_75(){
    const char * v0;
    v0 = "Clubs";
    return write_0(v0);
}
__device__ void write_76(){
    const char * v0;
    v0 = "Diamonds";
    return write_0(v0);
}
__device__ void write_77(){
    const char * v0;
    v0 = "Hearts";
    return write_0(v0);
}
__device__ void write_78(){
    const char * v0;
    v0 = "Spades";
    return write_0(v0);
}
__device__ void write_74(US5 v0){
    switch (v0.tag) {
        case 0: { // Clubs
            return write_75();
            break;
        }
        case 1: { // Diamonds
            return write_76();
            break;
        }
        case 2: { // Hearts
            return write_77();
            break;
        }
        case 3: { // Spades
            return write_78();
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_59(US4 v0, US5 v1){
    write_60(v0);
    const char * v2;
    v2 = ", ";
    write_0(v2);
    return write_74(v1);
}
__device__ void write_58(static_array_list<Tuple0,5l,long> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = v0.length;
    bool v3;
    v3 = 100l < v2;
    long v4;
    if (v3){
        v4 = 100l;
    } else {
        v4 = v2;
    }
    long v5;
    v5 = 0l;
    while (while_method_1(v4, v5)){
        bool v7;
        v7 = 0l <= v5;
        bool v10;
        if (v7){
            long v8;
            v8 = v0.length;
            bool v9;
            v9 = v5 < v8;
            v10 = v9;
        } else {
            v10 = false;
        }
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The read index needs to be in range for the static array list." && v10);
        } else {
        }
        US4 v12; US5 v13;
        Tuple0 tmp89 = v0.v[v5];
        v12 = tmp89.v0; v13 = tmp89.v1;
        write_59(v12, v13);
        long v14;
        v14 = v5 + 1l;
        long v15;
        v15 = v0.length;
        bool v16;
        v16 = v14 < v15;
        if (v16){
            const char * v17;
            v17 = "; ";
            write_0(v17);
        } else {
        }
        v5 += 1l ;
    }
    long v18;
    v18 = v0.length;
    bool v19;
    v19 = v18 > 100l;
    if (v19){
        const char * v20;
        v20 = "; ...";
        write_0(v20);
    } else {
    }
    const char * v21;
    v21 = "]";
    return write_0(v21);
}
__device__ void write_79(){
    const char * v0;
    v0 = "Fold";
    return write_0(v0);
}
__device__ void write_81(long v0){
    const char * v1;
    v1 = "%d";
    printf(v1,v0);
    return ;
}
__device__ void write_80(long v0, long v1){
    char v2;
    v2 = '{';
    write_50(v2);
    write_51();
    const char * v3;
    v3 = "chips_won";
    write_0(v3);
    const char * v4;
    v4 = " = ";
    write_0(v4);
    write_81(v0);
    const char * v5;
    v5 = "; ";
    write_0(v5);
    const char * v6;
    v6 = "winner_id";
    write_0(v6);
    write_0(v4);
    write_81(v1);
    char v7;
    v7 = '}';
    return write_50(v7);
}
__device__ void write_82(){
    const char * v0;
    v0 = "PlayerAction";
    return write_0(v0);
}
__device__ void write_85(){
    const char * v0;
    v0 = "A_Call";
    return write_0(v0);
}
__device__ void write_86(){
    const char * v0;
    v0 = "A_Fold";
    return write_0(v0);
}
__device__ void write_87(){
    const char * v0;
    v0 = "A_Raise";
    return write_0(v0);
}
__device__ void write_84(US1 v0){
    switch (v0.tag) {
        case 0: { // A_Call
            return write_85();
            break;
        }
        case 1: { // A_Fold
            return write_86();
            break;
        }
        case 2: { // A_Raise
            long v1 = v0.v.case2.v0;
            write_87();
            const char * v2;
            v2 = "(";
            write_0(v2);
            write_81(v1);
            const char * v3;
            v3 = ")";
            return write_0(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_83(long v0, US1 v1){
    write_81(v0);
    const char * v2;
    v2 = ", ";
    write_0(v2);
    return write_84(v1);
}
__device__ void write_88(){
    const char * v0;
    v0 = "PlayerGotCards";
    return write_0(v0);
}
__device__ void write_90(static_array<Tuple0,2l> v0){
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
        US4 v8; US5 v9;
        Tuple0 tmp90 = v0.v[v2];
        v8 = tmp90.v0; v9 = tmp90.v1;
        write_59(v8, v9);
        long v10;
        v10 = v2 + 1l;
        bool v11;
        v11 = v10 < 2l;
        if (v11){
            const char * v12;
            v12 = "; ";
            write_0(v12);
        } else {
        }
        v2 += 1l ;
    }
    const char * v13;
    v13 = "]";
    return write_0(v13);
}
__device__ void write_89(long v0, static_array<Tuple0,2l> v1){
    write_81(v0);
    const char * v2;
    v2 = ", ";
    write_0(v2);
    return write_90(v1);
}
__device__ void write_91(){
    const char * v0;
    v0 = "Showdown";
    return write_0(v0);
}
__device__ void write_95(){
    const char * v0;
    v0 = "Flush";
    return write_0(v0);
}
__device__ void write_96(static_array<Tuple0,5l> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        bool v4;
        v4 = 0l <= v2;
        bool v6;
        if (v4){
            bool v5;
            v5 = v2 < 5l;
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
        US4 v8; US5 v9;
        Tuple0 tmp91 = v0.v[v2];
        v8 = tmp91.v0; v9 = tmp91.v1;
        write_59(v8, v9);
        long v10;
        v10 = v2 + 1l;
        bool v11;
        v11 = v10 < 5l;
        if (v11){
            const char * v12;
            v12 = "; ";
            write_0(v12);
        } else {
        }
        v2 += 1l ;
    }
    const char * v13;
    v13 = "]";
    return write_0(v13);
}
__device__ void write_97(){
    const char * v0;
    v0 = "Full_House";
    return write_0(v0);
}
__device__ void write_98(){
    const char * v0;
    v0 = "High_Card";
    return write_0(v0);
}
__device__ void write_99(){
    const char * v0;
    v0 = "Pair";
    return write_0(v0);
}
__device__ void write_100(){
    const char * v0;
    v0 = "Quads";
    return write_0(v0);
}
__device__ void write_101(){
    const char * v0;
    v0 = "Straight";
    return write_0(v0);
}
__device__ void write_102(){
    const char * v0;
    v0 = "Straight_Flush";
    return write_0(v0);
}
__device__ void write_103(){
    const char * v0;
    v0 = "Triple";
    return write_0(v0);
}
__device__ void write_104(){
    const char * v0;
    v0 = "Two_Pair";
    return write_0(v0);
}
__device__ void write_94(US6 v0){
    switch (v0.tag) {
        case 0: { // Flush
            static_array<Tuple0,5l> v1 = v0.v.case0.v0;
            write_95();
            const char * v2;
            v2 = "(";
            write_0(v2);
            write_96(v1);
            const char * v3;
            v3 = ")";
            return write_0(v3);
            break;
        }
        case 1: { // Full_House
            static_array<Tuple0,5l> v4 = v0.v.case1.v0;
            write_97();
            const char * v5;
            v5 = "(";
            write_0(v5);
            write_96(v4);
            const char * v6;
            v6 = ")";
            return write_0(v6);
            break;
        }
        case 2: { // High_Card
            static_array<Tuple0,5l> v7 = v0.v.case2.v0;
            write_98();
            const char * v8;
            v8 = "(";
            write_0(v8);
            write_96(v7);
            const char * v9;
            v9 = ")";
            return write_0(v9);
            break;
        }
        case 3: { // Pair
            static_array<Tuple0,5l> v10 = v0.v.case3.v0;
            write_99();
            const char * v11;
            v11 = "(";
            write_0(v11);
            write_96(v10);
            const char * v12;
            v12 = ")";
            return write_0(v12);
            break;
        }
        case 4: { // Quads
            static_array<Tuple0,5l> v13 = v0.v.case4.v0;
            write_100();
            const char * v14;
            v14 = "(";
            write_0(v14);
            write_96(v13);
            const char * v15;
            v15 = ")";
            return write_0(v15);
            break;
        }
        case 5: { // Straight
            static_array<Tuple0,5l> v16 = v0.v.case5.v0;
            write_101();
            const char * v17;
            v17 = "(";
            write_0(v17);
            write_96(v16);
            const char * v18;
            v18 = ")";
            return write_0(v18);
            break;
        }
        case 6: { // Straight_Flush
            static_array<Tuple0,5l> v19 = v0.v.case6.v0;
            write_102();
            const char * v20;
            v20 = "(";
            write_0(v20);
            write_96(v19);
            const char * v21;
            v21 = ")";
            return write_0(v21);
            break;
        }
        case 7: { // Triple
            static_array<Tuple0,5l> v22 = v0.v.case7.v0;
            write_103();
            const char * v23;
            v23 = "(";
            write_0(v23);
            write_96(v22);
            const char * v24;
            v24 = ")";
            return write_0(v24);
            break;
        }
        case 8: { // Two_Pair
            static_array<Tuple0,5l> v25 = v0.v.case8.v0;
            write_104();
            const char * v26;
            v26 = "(";
            write_0(v26);
            write_96(v25);
            const char * v27;
            v27 = ")";
            return write_0(v27);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_93(static_array<US6,2l> v0){
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
        US6 v8;
        v8 = v0.v[v2];
        write_94(v8);
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
__device__ void write_92(long v0, static_array<US6,2l> v1, long v2){
    char v3;
    v3 = '{';
    write_50(v3);
    write_51();
    const char * v4;
    v4 = "chips_won";
    write_0(v4);
    const char * v5;
    v5 = " = ";
    write_0(v5);
    write_81(v0);
    const char * v6;
    v6 = "; ";
    write_0(v6);
    const char * v7;
    v7 = "hands_shown";
    write_0(v7);
    write_0(v5);
    write_93(v1);
    write_0(v6);
    const char * v8;
    v8 = "winner_id";
    write_0(v8);
    write_0(v5);
    write_81(v2);
    char v9;
    v9 = '}';
    return write_50(v9);
}
__device__ void write_56(US3 v0){
    switch (v0.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<Tuple0,5l,long> v1 = v0.v.case0.v0;
            write_57();
            const char * v2;
            v2 = "(";
            write_0(v2);
            write_58(v1);
            const char * v3;
            v3 = ")";
            return write_0(v3);
            break;
        }
        case 1: { // Fold
            long v4 = v0.v.case1.v0; long v5 = v0.v.case1.v1;
            write_79();
            const char * v6;
            v6 = "(";
            write_0(v6);
            write_80(v4, v5);
            const char * v7;
            v7 = ")";
            return write_0(v7);
            break;
        }
        case 2: { // PlayerAction
            long v8 = v0.v.case2.v0; US1 v9 = v0.v.case2.v1;
            write_82();
            const char * v10;
            v10 = "(";
            write_0(v10);
            write_83(v8, v9);
            const char * v11;
            v11 = ")";
            return write_0(v11);
            break;
        }
        case 3: { // PlayerGotCards
            long v12 = v0.v.case3.v0; static_array<Tuple0,2l> v13 = v0.v.case3.v1;
            write_88();
            const char * v14;
            v14 = "(";
            write_0(v14);
            write_89(v12, v13);
            const char * v15;
            v15 = ")";
            return write_0(v15);
            break;
        }
        case 4: { // Showdown
            long v16 = v0.v.case4.v0; static_array<US6,2l> v17 = v0.v.case4.v1; long v18 = v0.v.case4.v2;
            write_91();
            const char * v19;
            v19 = "(";
            write_0(v19);
            write_92(v16, v17, v18);
            const char * v20;
            v20 = ")";
            return write_0(v20);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_55(static_array_list<US3,128l,long> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = v0.length;
    bool v3;
    v3 = 100l < v2;
    long v4;
    if (v3){
        v4 = 100l;
    } else {
        v4 = v2;
    }
    long v5;
    v5 = 0l;
    while (while_method_1(v4, v5)){
        bool v7;
        v7 = 0l <= v5;
        bool v10;
        if (v7){
            long v8;
            v8 = v0.length;
            bool v9;
            v9 = v5 < v8;
            v10 = v9;
        } else {
            v10 = false;
        }
        bool v11;
        v11 = v10 == false;
        if (v11){
            assert("The read index needs to be in range for the static array list." && v10);
        } else {
        }
        US3 v12;
        v12 = v0.v[v5];
        write_56(v12);
        long v13;
        v13 = v5 + 1l;
        long v14;
        v14 = v0.length;
        bool v15;
        v15 = v13 < v14;
        if (v15){
            const char * v16;
            v16 = "; ";
            write_0(v16);
        } else {
        }
        v5 += 1l ;
    }
    long v17;
    v17 = v0.length;
    bool v18;
    v18 = v17 > 100l;
    if (v18){
        const char * v19;
        v19 = "; ...";
        write_0(v19);
    } else {
    }
    const char * v20;
    v20 = "]";
    return write_0(v20);
}
__device__ void write_52(unsigned long long v0, static_array_list<US3,128l,long> v1){
    char v2;
    v2 = '{';
    write_50(v2);
    write_51();
    const char * v3;
    v3 = "deck";
    write_0(v3);
    const char * v4;
    v4 = " = ";
    write_0(v4);
    write_53(v0);
    const char * v5;
    v5 = "; ";
    write_0(v5);
    const char * v6;
    v6 = "messages";
    write_0(v6);
    write_0(v4);
    write_55(v1);
    char v7;
    v7 = '}';
    return write_50(v7);
}
__device__ void write_107(){
    const char * v0;
    v0 = "None";
    return write_0(v0);
}
__device__ void write_108(){
    const char * v0;
    v0 = "Some";
    return write_0(v0);
}
__device__ void write_110(){
    const char * v0;
    v0 = "G_Flop";
    return write_0(v0);
}
__device__ void write_112(long v0){
    char v1;
    v1 = '{';
    write_50(v1);
    write_51();
    const char * v2;
    v2 = "min_raise";
    write_0(v2);
    const char * v3;
    v3 = " = ";
    write_0(v3);
    write_81(v0);
    char v4;
    v4 = '}';
    return write_50(v4);
}
__device__ void write_113(bool v0){
    const char * v3;
    if (v0){
        const char * v1;
        v1 = "true";
        v3 = v1;
    } else {
        const char * v2;
        v2 = "false";
        v3 = v2;
    }
    const char * v4;
    v4 = "%s";
    printf(v4,v3);
    return ;
}
__device__ void write_114(static_array<static_array<Tuple0,2l>,2l> v0){
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
        static_array<Tuple0,2l> v8;
        v8 = v0.v[v2];
        write_90(v8);
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
__device__ void write_115(static_array<long,2l> v0){
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
        write_81(v8);
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
__device__ void write_117(){
    const char * v0;
    v0 = "Flop";
    return write_0(v0);
}
__device__ void write_118(static_array<Tuple0,3l> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        bool v4;
        v4 = 0l <= v2;
        bool v6;
        if (v4){
            bool v5;
            v5 = v2 < 3l;
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
        US4 v8; US5 v9;
        Tuple0 tmp92 = v0.v[v2];
        v8 = tmp92.v0; v9 = tmp92.v1;
        write_59(v8, v9);
        long v10;
        v10 = v2 + 1l;
        bool v11;
        v11 = v10 < 3l;
        if (v11){
            const char * v12;
            v12 = "; ";
            write_0(v12);
        } else {
        }
        v2 += 1l ;
    }
    const char * v13;
    v13 = "]";
    return write_0(v13);
}
__device__ void write_119(){
    const char * v0;
    v0 = "Preflop";
    return write_0(v0);
}
__device__ void write_120(){
    const char * v0;
    v0 = "River";
    return write_0(v0);
}
__device__ void write_121(){
    const char * v0;
    v0 = "Turn";
    return write_0(v0);
}
__device__ void write_122(static_array<Tuple0,4l> v0){
    const char * v1;
    v1 = "[";
    write_0(v1);
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        bool v4;
        v4 = 0l <= v2;
        bool v6;
        if (v4){
            bool v5;
            v5 = v2 < 4l;
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
        US4 v8; US5 v9;
        Tuple0 tmp93 = v0.v[v2];
        v8 = tmp93.v0; v9 = tmp93.v1;
        write_59(v8, v9);
        long v10;
        v10 = v2 + 1l;
        bool v11;
        v11 = v10 < 4l;
        if (v11){
            const char * v12;
            v12 = "; ";
            write_0(v12);
        } else {
        }
        v2 += 1l ;
    }
    const char * v13;
    v13 = "]";
    return write_0(v13);
}
__device__ void write_116(US9 v0){
    switch (v0.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v1 = v0.v.case0.v0;
            write_117();
            const char * v2;
            v2 = "(";
            write_0(v2);
            write_118(v1);
            const char * v3;
            v3 = ")";
            return write_0(v3);
            break;
        }
        case 1: { // Preflop
            return write_119();
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v4 = v0.v.case2.v0;
            write_120();
            const char * v5;
            v5 = "(";
            write_0(v5);
            write_96(v4);
            const char * v6;
            v6 = ")";
            return write_0(v6);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v7 = v0.v.case3.v0;
            write_121();
            const char * v8;
            v8 = "(";
            write_0(v8);
            write_122(v7);
            const char * v9;
            v9 = ")";
            return write_0(v9);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_111(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6){
    char v7;
    v7 = '{';
    write_50(v7);
    write_51();
    const char * v8;
    v8 = "config";
    write_0(v8);
    const char * v9;
    v9 = " = ";
    write_0(v9);
    write_112(v0);
    const char * v10;
    v10 = "; ";
    write_0(v10);
    const char * v11;
    v11 = "is_button_s_first_move";
    write_0(v11);
    write_0(v9);
    write_113(v1);
    write_0(v10);
    const char * v12;
    v12 = "pl_card";
    write_0(v12);
    write_0(v9);
    write_114(v2);
    write_0(v10);
    const char * v13;
    v13 = "player_turn";
    write_0(v13);
    write_0(v9);
    write_81(v3);
    write_0(v10);
    const char * v14;
    v14 = "pot";
    write_0(v14);
    write_0(v9);
    write_115(v4);
    write_0(v10);
    const char * v15;
    v15 = "stack";
    write_0(v15);
    write_0(v9);
    write_115(v5);
    write_0(v10);
    const char * v16;
    v16 = "street";
    write_0(v16);
    write_0(v9);
    write_116(v6);
    char v17;
    v17 = '}';
    return write_50(v17);
}
__device__ void write_123(){
    const char * v0;
    v0 = "G_Fold";
    return write_0(v0);
}
__device__ void write_124(){
    const char * v0;
    v0 = "G_Preflop";
    return write_0(v0);
}
__device__ void write_125(){
    const char * v0;
    v0 = "G_River";
    return write_0(v0);
}
__device__ void write_126(){
    const char * v0;
    v0 = "G_Round";
    return write_0(v0);
}
__device__ void write_127(){
    const char * v0;
    v0 = "G_Round'";
    return write_0(v0);
}
__device__ void write_128(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US9 v6, US1 v7){
    write_111(v0, v1, v2, v3, v4, v5, v6);
    const char * v8;
    v8 = ", ";
    write_0(v8);
    return write_84(v7);
}
__device__ void write_129(){
    const char * v0;
    v0 = "G_Showdown";
    return write_0(v0);
}
__device__ void write_130(){
    const char * v0;
    v0 = "G_Turn";
    return write_0(v0);
}
__device__ void write_109(US8 v0){
    switch (v0.tag) {
        case 0: { // G_Flop
            long v1 = v0.v.case0.v0; bool v2 = v0.v.case0.v1; static_array<static_array<Tuple0,2l>,2l> v3 = v0.v.case0.v2; long v4 = v0.v.case0.v3; static_array<long,2l> v5 = v0.v.case0.v4; static_array<long,2l> v6 = v0.v.case0.v5; US9 v7 = v0.v.case0.v6;
            write_110();
            const char * v8;
            v8 = "(";
            write_0(v8);
            write_111(v1, v2, v3, v4, v5, v6, v7);
            const char * v9;
            v9 = ")";
            return write_0(v9);
            break;
        }
        case 1: { // G_Fold
            long v10 = v0.v.case1.v0; bool v11 = v0.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v12 = v0.v.case1.v2; long v13 = v0.v.case1.v3; static_array<long,2l> v14 = v0.v.case1.v4; static_array<long,2l> v15 = v0.v.case1.v5; US9 v16 = v0.v.case1.v6;
            write_123();
            const char * v17;
            v17 = "(";
            write_0(v17);
            write_111(v10, v11, v12, v13, v14, v15, v16);
            const char * v18;
            v18 = ")";
            return write_0(v18);
            break;
        }
        case 2: { // G_Preflop
            return write_124();
            break;
        }
        case 3: { // G_River
            long v19 = v0.v.case3.v0; bool v20 = v0.v.case3.v1; static_array<static_array<Tuple0,2l>,2l> v21 = v0.v.case3.v2; long v22 = v0.v.case3.v3; static_array<long,2l> v23 = v0.v.case3.v4; static_array<long,2l> v24 = v0.v.case3.v5; US9 v25 = v0.v.case3.v6;
            write_125();
            const char * v26;
            v26 = "(";
            write_0(v26);
            write_111(v19, v20, v21, v22, v23, v24, v25);
            const char * v27;
            v27 = ")";
            return write_0(v27);
            break;
        }
        case 4: { // G_Round
            long v28 = v0.v.case4.v0; bool v29 = v0.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v30 = v0.v.case4.v2; long v31 = v0.v.case4.v3; static_array<long,2l> v32 = v0.v.case4.v4; static_array<long,2l> v33 = v0.v.case4.v5; US9 v34 = v0.v.case4.v6;
            write_126();
            const char * v35;
            v35 = "(";
            write_0(v35);
            write_111(v28, v29, v30, v31, v32, v33, v34);
            const char * v36;
            v36 = ")";
            return write_0(v36);
            break;
        }
        case 5: { // G_Round'
            long v37 = v0.v.case5.v0; bool v38 = v0.v.case5.v1; static_array<static_array<Tuple0,2l>,2l> v39 = v0.v.case5.v2; long v40 = v0.v.case5.v3; static_array<long,2l> v41 = v0.v.case5.v4; static_array<long,2l> v42 = v0.v.case5.v5; US9 v43 = v0.v.case5.v6; US1 v44 = v0.v.case5.v7;
            write_127();
            const char * v45;
            v45 = "(";
            write_0(v45);
            write_128(v37, v38, v39, v40, v41, v42, v43, v44);
            const char * v46;
            v46 = ")";
            return write_0(v46);
            break;
        }
        case 6: { // G_Showdown
            long v47 = v0.v.case6.v0; bool v48 = v0.v.case6.v1; static_array<static_array<Tuple0,2l>,2l> v49 = v0.v.case6.v2; long v50 = v0.v.case6.v3; static_array<long,2l> v51 = v0.v.case6.v4; static_array<long,2l> v52 = v0.v.case6.v5; US9 v53 = v0.v.case6.v6;
            write_129();
            const char * v54;
            v54 = "(";
            write_0(v54);
            write_111(v47, v48, v49, v50, v51, v52, v53);
            const char * v55;
            v55 = ")";
            return write_0(v55);
            break;
        }
        case 7: { // G_Turn
            long v56 = v0.v.case7.v0; bool v57 = v0.v.case7.v1; static_array<static_array<Tuple0,2l>,2l> v58 = v0.v.case7.v2; long v59 = v0.v.case7.v3; static_array<long,2l> v60 = v0.v.case7.v4; static_array<long,2l> v61 = v0.v.case7.v5; US9 v62 = v0.v.case7.v6;
            write_130();
            const char * v63;
            v63 = "(";
            write_0(v63);
            write_111(v56, v57, v58, v59, v60, v61, v62);
            const char * v64;
            v64 = ")";
            return write_0(v64);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_106(US7 v0){
    switch (v0.tag) {
        case 0: { // None
            return write_107();
            break;
        }
        case 1: { // Some
            US8 v1 = v0.v.case1.v0;
            write_108();
            const char * v2;
            v2 = "(";
            write_0(v2);
            write_109(v1);
            const char * v3;
            v3 = ")";
            return write_0(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_133(){
    const char * v0;
    v0 = "Computer";
    return write_0(v0);
}
__device__ void write_134(){
    const char * v0;
    v0 = "Human";
    return write_0(v0);
}
__device__ void write_132(US2 v0){
    switch (v0.tag) {
        case 0: { // Computer
            return write_133();
            break;
        }
        case 1: { // Human
            return write_134();
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_131(static_array<US2,2l> v0){
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
        US2 v8;
        v8 = v0.v[v2];
        write_132(v8);
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
__device__ void write_136(){
    const char * v0;
    v0 = "GameNotStarted";
    return write_0(v0);
}
__device__ void write_137(){
    const char * v0;
    v0 = "GameOver";
    return write_0(v0);
}
__device__ void write_138(){
    const char * v0;
    v0 = "WaitingForActionFromPlayerId";
    return write_0(v0);
}
__device__ void write_135(US10 v0){
    switch (v0.tag) {
        case 0: { // GameNotStarted
            return write_136();
            break;
        }
        case 1: { // GameOver
            long v1 = v0.v.case1.v0; bool v2 = v0.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v3 = v0.v.case1.v2; long v4 = v0.v.case1.v3; static_array<long,2l> v5 = v0.v.case1.v4; static_array<long,2l> v6 = v0.v.case1.v5; US9 v7 = v0.v.case1.v6;
            write_137();
            const char * v8;
            v8 = "(";
            write_0(v8);
            write_111(v1, v2, v3, v4, v5, v6, v7);
            const char * v9;
            v9 = ")";
            return write_0(v9);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v10 = v0.v.case2.v0; bool v11 = v0.v.case2.v1; static_array<static_array<Tuple0,2l>,2l> v12 = v0.v.case2.v2; long v13 = v0.v.case2.v3; static_array<long,2l> v14 = v0.v.case2.v4; static_array<long,2l> v15 = v0.v.case2.v5; US9 v16 = v0.v.case2.v6;
            write_138();
            const char * v17;
            v17 = "(";
            write_0(v17);
            write_111(v10, v11, v12, v13, v14, v15, v16);
            const char * v18;
            v18 = ")";
            return write_0(v18);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void write_105(US7 v0, static_array<US2,2l> v1, US10 v2){
    char v3;
    v3 = '{';
    write_50(v3);
    write_51();
    const char * v4;
    v4 = "game";
    write_0(v4);
    const char * v5;
    v5 = " = ";
    write_0(v5);
    write_106(v0);
    const char * v6;
    v6 = "; ";
    write_0(v6);
    const char * v7;
    v7 = "pl_type";
    write_0(v7);
    write_0(v5);
    write_131(v1);
    write_0(v6);
    const char * v8;
    v8 = "ui_game_state";
    write_0(v8);
    write_0(v5);
    write_135(v2);
    char v9;
    v9 = '}';
    return write_50(v9);
}
__device__ void write_49(unsigned long long v0, static_array_list<US3,128l,long> v1, US7 v2, static_array<US2,2l> v3, US10 v4){
    char v5;
    v5 = '{';
    write_50(v5);
    write_51();
    const char * v6;
    v6 = "large";
    write_0(v6);
    const char * v7;
    v7 = " = ";
    write_0(v7);
    write_52(v0, v1);
    const char * v8;
    v8 = "; ";
    write_0(v8);
    const char * v9;
    v9 = "small";
    write_0(v9);
    write_0(v7);
    write_105(v2, v3, v4);
    char v10;
    v10 = '}';
    return write_50(v10);
}
__device__ void f_140(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_141(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_143(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_146(unsigned char * v0){
    return ;
}
__device__ void f_147(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_145(unsigned char * v0, US4 v1, US5 v2){
    long v3;
    v3 = v1.tag;
    f_143(v0, v3);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Ace
            f_146(v4);
            break;
        }
        case 1: { // Eight
            f_146(v4);
            break;
        }
        case 2: { // Five
            f_146(v4);
            break;
        }
        case 3: { // Four
            f_146(v4);
            break;
        }
        case 4: { // Jack
            f_146(v4);
            break;
        }
        case 5: { // King
            f_146(v4);
            break;
        }
        case 6: { // Nine
            f_146(v4);
            break;
        }
        case 7: { // Queen
            f_146(v4);
            break;
        }
        case 8: { // Seven
            f_146(v4);
            break;
        }
        case 9: { // Six
            f_146(v4);
            break;
        }
        case 10: { // Ten
            f_146(v4);
            break;
        }
        case 11: { // Three
            f_146(v4);
            break;
        }
        case 12: { // Two
            f_146(v4);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v5;
    v5 = v2.tag;
    f_147(v0, v5);
    unsigned char * v6;
    v6 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // Clubs
            return f_146(v6);
            break;
        }
        case 1: { // Diamonds
            return f_146(v6);
            break;
        }
        case 2: { // Hearts
            return f_146(v6);
            break;
        }
        case 3: { // Spades
            return f_146(v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_144(unsigned char * v0, static_array_list<Tuple0,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_143(v0, v2);
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
        Tuple0 tmp94 = v1.v[v4];
        v15 = tmp94.v0; v16 = tmp94.v1;
        f_145(v9, v15, v16);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_148(unsigned char * v0, long v1, long v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long * v4;
    v4 = (long *)(v0+4ull);
    v4[0l] = v2;
    return ;
}
__device__ void f_149(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_147(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_Call
            return f_146(v5);
            break;
        }
        case 1: { // A_Fold
            return f_146(v5);
            break;
        }
        case 2: { // A_Raise
            long v6 = v2.v.case2.v0;
            return f_143(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_150(unsigned char * v0, long v1, static_array<Tuple0,2l> v2){
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
        Tuple0 tmp95 = v2.v[v4];
        v14 = tmp95.v0; v15 = tmp95.v1;
        f_145(v9, v14, v15);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_153(unsigned char * v0, static_array<Tuple0,5l> v1){
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
        Tuple0 tmp96 = v1.v[v2];
        v11 = tmp96.v0; v12 = tmp96.v1;
        f_145(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_152(unsigned char * v0, US6 v1){
    long v2;
    v2 = v1.tag;
    f_143(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // Flush
            static_array<Tuple0,5l> v4 = v1.v.case0.v0;
            return f_153(v3, v4);
            break;
        }
        case 1: { // Full_House
            static_array<Tuple0,5l> v5 = v1.v.case1.v0;
            return f_153(v3, v5);
            break;
        }
        case 2: { // High_Card
            static_array<Tuple0,5l> v6 = v1.v.case2.v0;
            return f_153(v3, v6);
            break;
        }
        case 3: { // Pair
            static_array<Tuple0,5l> v7 = v1.v.case3.v0;
            return f_153(v3, v7);
            break;
        }
        case 4: { // Quads
            static_array<Tuple0,5l> v8 = v1.v.case4.v0;
            return f_153(v3, v8);
            break;
        }
        case 5: { // Straight
            static_array<Tuple0,5l> v9 = v1.v.case5.v0;
            return f_153(v3, v9);
            break;
        }
        case 6: { // Straight_Flush
            static_array<Tuple0,5l> v10 = v1.v.case6.v0;
            return f_153(v3, v10);
            break;
        }
        case 7: { // Triple
            static_array<Tuple0,5l> v11 = v1.v.case7.v0;
            return f_153(v3, v11);
            break;
        }
        case 8: { // Two_Pair
            static_array<Tuple0,5l> v12 = v1.v.case8.v0;
            return f_153(v3, v12);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_151(unsigned char * v0, long v1, static_array<US6,2l> v2, long v3){
    long * v4;
    v4 = (long *)(v0+0ull);
    v4[0l] = v1;
    long v5;
    v5 = 0l;
    while (while_method_0(v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 64ull;
        unsigned long long v9;
        v9 = 16ull + v8;
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
        US6 v15;
        v15 = v2.v[v5];
        f_152(v10, v15);
        v5 += 1l ;
    }
    long * v16;
    v16 = (long *)(v0+144ull);
    v16[0l] = v3;
    return ;
}
__device__ void f_142(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_143(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<Tuple0,5l,long> v4 = v1.v.case0.v0;
            return f_144(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_148(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US1 v8 = v1.v.case2.v1;
            return f_149(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<Tuple0,2l> v10 = v1.v.case3.v1;
            return f_150(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<US6,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_151(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_154(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22544ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_157(unsigned char * v0, static_array<Tuple0,2l> v1){
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
        Tuple0 tmp97 = v1.v[v2];
        v11 = tmp97.v0; v12 = tmp97.v1;
        f_145(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_158(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+68ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_159(unsigned char * v0, static_array<Tuple0,3l> v1){
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
        Tuple0 tmp98 = v1.v[v2];
        v11 = tmp98.v0; v12 = tmp98.v1;
        f_145(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_160(unsigned char * v0, static_array<Tuple0,4l> v1){
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
        Tuple0 tmp99 = v1.v[v2];
        v11 = tmp99.v0; v12 = tmp99.v1;
        f_145(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_156(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US9 v7){
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
        v13 = v12 * 16ull;
        unsigned long long v14;
        v14 = 16ull + v13;
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
        static_array<Tuple0,2l> v20;
        v20 = v3.v[v10];
        f_157(v15, v20);
        v10 += 1l ;
    }
    long * v21;
    v21 = (long *)(v0+48ull);
    v21[0l] = v4;
    long v22;
    v22 = 0l;
    while (while_method_0(v22)){
        unsigned long long v24;
        v24 = (unsigned long long)v22;
        unsigned long long v25;
        v25 = v24 * 4ull;
        unsigned long long v26;
        v26 = 52ull + v25;
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
        f_143(v27, v32);
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
        v37 = 60ull + v36;
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
        f_143(v38, v43);
        v33 += 1l ;
    }
    long v44;
    v44 = v7.tag;
    f_158(v0, v44);
    unsigned char * v45;
    v45 = (unsigned char *)(v0+80ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v46 = v7.v.case0.v0;
            return f_159(v45, v46);
            break;
        }
        case 1: { // Preflop
            return f_146(v45);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v47 = v7.v.case2.v0;
            return f_153(v45, v47);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v48 = v7.v.case3.v0;
            return f_160(v45, v48);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_162(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+128ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_161(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US9 v7, US1 v8){
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
        v14 = v13 * 16ull;
        unsigned long long v15;
        v15 = 16ull + v14;
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
        static_array<Tuple0,2l> v21;
        v21 = v3.v[v11];
        f_157(v16, v21);
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+48ull);
    v22[0l] = v4;
    long v23;
    v23 = 0l;
    while (while_method_0(v23)){
        unsigned long long v25;
        v25 = (unsigned long long)v23;
        unsigned long long v26;
        v26 = v25 * 4ull;
        unsigned long long v27;
        v27 = 52ull + v26;
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
        f_143(v28, v33);
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
        v38 = 60ull + v37;
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
        f_143(v39, v44);
        v34 += 1l ;
    }
    long v45;
    v45 = v7.tag;
    f_158(v0, v45);
    unsigned char * v46;
    v46 = (unsigned char *)(v0+80ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v47 = v7.v.case0.v0;
            f_159(v46, v47);
            break;
        }
        case 1: { // Preflop
            f_146(v46);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v48 = v7.v.case2.v0;
            f_153(v46, v48);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v49 = v7.v.case3.v0;
            f_160(v46, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v50;
    v50 = v8.tag;
    f_162(v0, v50);
    unsigned char * v51;
    v51 = (unsigned char *)(v0+132ull);
    switch (v8.tag) {
        case 0: { // A_Call
            return f_146(v51);
            break;
        }
        case 1: { // A_Fold
            return f_146(v51);
            break;
        }
        case 2: { // A_Raise
            long v52 = v8.v.case2.v0;
            return f_143(v51, v52);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_155(unsigned char * v0, US8 v1){
    long v2;
    v2 = v1.tag;
    f_143(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; bool v5 = v1.v.case0.v1; static_array<static_array<Tuple0,2l>,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; static_array<long,2l> v9 = v1.v.case0.v5; US9 v10 = v1.v.case0.v6;
            return f_156(v3, v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: { // G_Fold
            long v11 = v1.v.case1.v0; bool v12 = v1.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v13 = v1.v.case1.v2; long v14 = v1.v.case1.v3; static_array<long,2l> v15 = v1.v.case1.v4; static_array<long,2l> v16 = v1.v.case1.v5; US9 v17 = v1.v.case1.v6;
            return f_156(v3, v11, v12, v13, v14, v15, v16, v17);
            break;
        }
        case 2: { // G_Preflop
            return f_146(v3);
            break;
        }
        case 3: { // G_River
            long v18 = v1.v.case3.v0; bool v19 = v1.v.case3.v1; static_array<static_array<Tuple0,2l>,2l> v20 = v1.v.case3.v2; long v21 = v1.v.case3.v3; static_array<long,2l> v22 = v1.v.case3.v4; static_array<long,2l> v23 = v1.v.case3.v5; US9 v24 = v1.v.case3.v6;
            return f_156(v3, v18, v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: { // G_Round
            long v25 = v1.v.case4.v0; bool v26 = v1.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v27 = v1.v.case4.v2; long v28 = v1.v.case4.v3; static_array<long,2l> v29 = v1.v.case4.v4; static_array<long,2l> v30 = v1.v.case4.v5; US9 v31 = v1.v.case4.v6;
            return f_156(v3, v25, v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: { // G_Round'
            long v32 = v1.v.case5.v0; bool v33 = v1.v.case5.v1; static_array<static_array<Tuple0,2l>,2l> v34 = v1.v.case5.v2; long v35 = v1.v.case5.v3; static_array<long,2l> v36 = v1.v.case5.v4; static_array<long,2l> v37 = v1.v.case5.v5; US9 v38 = v1.v.case5.v6; US1 v39 = v1.v.case5.v7;
            return f_161(v3, v32, v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: { // G_Showdown
            long v40 = v1.v.case6.v0; bool v41 = v1.v.case6.v1; static_array<static_array<Tuple0,2l>,2l> v42 = v1.v.case6.v2; long v43 = v1.v.case6.v3; static_array<long,2l> v44 = v1.v.case6.v4; static_array<long,2l> v45 = v1.v.case6.v5; US9 v46 = v1.v.case6.v6;
            return f_156(v3, v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: { // G_Turn
            long v47 = v1.v.case7.v0; bool v48 = v1.v.case7.v1; static_array<static_array<Tuple0,2l>,2l> v49 = v1.v.case7.v2; long v50 = v1.v.case7.v3; static_array<long,2l> v51 = v1.v.case7.v4; static_array<long,2l> v52 = v1.v.case7.v5; US9 v53 = v1.v.case7.v6;
            return f_156(v3, v47, v48, v49, v50, v51, v52, v53);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_163(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_143(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_146(v3);
            break;
        }
        case 1: { // Human
            return f_146(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_164(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22728ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_139(unsigned char * v0, unsigned long long v1, static_array_list<US3,128l,long> v2, US7 v3, static_array<US2,2l> v4, US10 v5){
    f_140(v0, v1);
    long v6;
    v6 = v2.length;
    f_141(v0, v6);
    long v7;
    v7 = v2.length;
    long v8;
    v8 = 0l;
    while (while_method_1(v7, v8)){
        unsigned long long v10;
        v10 = (unsigned long long)v8;
        unsigned long long v11;
        v11 = v10 * 176ull;
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
        f_142(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_154(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+22560ull);
    switch (v3.tag) {
        case 0: { // None
            f_146(v21);
            break;
        }
        case 1: { // Some
            US8 v22 = v3.v.case1.v0;
            f_155(v21, v22);
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
        v27 = 22720ull + v26;
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
        f_163(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_164(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+22736ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_146(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; bool v37 = v5.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; static_array<long,2l> v41 = v5.v.case1.v5; US9 v42 = v5.v.case1.v6;
            return f_156(v35, v36, v37, v38, v39, v40, v41, v42);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v43 = v5.v.case2.v0; bool v44 = v5.v.case2.v1; static_array<static_array<Tuple0,2l>,2l> v45 = v5.v.case2.v2; long v46 = v5.v.case2.v3; static_array<long,2l> v47 = v5.v.case2.v4; static_array<long,2l> v48 = v5.v.case2.v5; US9 v49 = v5.v.case2.v6;
            return f_156(v35, v43, v44, v45, v46, v47, v48, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_166(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22552ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_165(unsigned char * v0, static_array_list<US3,128l,long> v1, static_array<US2,2l> v2, US10 v3){
    long v4;
    v4 = v1.length;
    f_143(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_1(v5, v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 176ull;
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
        f_142(v11, v17);
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
        v22 = 22544ull + v21;
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
        f_163(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_166(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+22560ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_146(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; bool v32 = v3.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; static_array<long,2l> v36 = v3.v.case1.v5; US9 v37 = v3.v.case1.v6;
            return f_156(v30, v31, v32, v33, v34, v35, v36, v37);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v38 = v3.v.case2.v0; bool v39 = v3.v.case2.v1; static_array<static_array<Tuple0,2l>,2l> v40 = v3.v.case2.v2; long v41 = v3.v.case2.v3; static_array<long,2l> v42 = v3.v.case2.v4; static_array<long,2l> v43 = v3.v.case2.v5; US9 v44 = v3.v.case2.v6;
            return f_156(v30, v38, v39, v40, v41, v42, v43, v44);
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
        unsigned long long v10; static_array_list<US3,128l,long> v11; US7 v12; static_array<US2,2l> v13; US10 v14;
        Tuple1 tmp19 = f_7(v0);
        v10 = tmp19.v0; v11 = tmp19.v1; v12 = tmp19.v2; v13 = tmp19.v3; v14 = tmp19.v4;
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
        US7 v66; static_array<US2,2l> v67; US10 v68;
        switch (v9.tag) {
            case 0: { // ActionSelected
                US1 v35 = v9.v.case0.v0;
                switch (v12.tag) {
                    case 0: { // None
                        v66 = v12; v67 = v13; v68 = v14;
                        break;
                    }
                    case 1: { // Some
                        US8 v36 = v12.v.case1.v0;
                        switch (v36.tag) {
                            case 4: { // G_Round
                                long v37 = v36.v.case4.v0; bool v38 = v36.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v39 = v36.v.case4.v2; long v40 = v36.v.case4.v3; static_array<long,2l> v41 = v36.v.case4.v4; static_array<long,2l> v42 = v36.v.case4.v5; US9 v43 = v36.v.case4.v6;
                                US8 v44;
                                v44 = US8_5(v37, v38, v39, v40, v41, v42, v43, v35);
                                Tuple8 tmp87 = play_loop_30(v12, v13, v14, v15, v16, v23, v44);
                                v66 = tmp87.v0; v67 = tmp87.v1; v68 = tmp87.v2;
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
                US7 v28;
                v28 = US7_0();
                US10 v29;
                v29 = US10_0();
                US8 v30;
                v30 = US8_2();
                Tuple8 tmp88 = play_loop_30(v28, v24, v29, v15, v16, v23, v30);
                v66 = tmp88.v0; v67 = tmp88.v1; v68 = tmp88.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        write_49(v10, v11, v66, v67, v68);
        printf("\n");
        f_139(v0, v10, v11, v66, v67, v68);
        return f_165(v2, v11, v67, v68);
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
class US10_0(NamedTuple): # Flush
    v0 : static_array
    tag = 0
class US10_1(NamedTuple): # Full_House
    v0 : static_array
    tag = 1
class US10_2(NamedTuple): # High_Card
    v0 : static_array
    tag = 2
class US10_3(NamedTuple): # Pair
    v0 : static_array
    tag = 3
class US10_4(NamedTuple): # Quads
    v0 : static_array
    tag = 4
class US10_5(NamedTuple): # Straight
    v0 : static_array
    tag = 5
class US10_6(NamedTuple): # Straight_Flush
    v0 : static_array
    tag = 6
class US10_7(NamedTuple): # Triple
    v0 : static_array
    tag = 7
class US10_8(NamedTuple): # Two_Pair
    v0 : static_array
    tag = 8
US10 = Union[US10_0, US10_1, US10_2, US10_3, US10_4, US10_5, US10_6, US10_7, US10_8]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(22864,dtype=cp.uint8)
        v4 = cp.empty(22688,dtype=cp.uint8)
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
        v16, v17, v18, v19, v20 = method74(v3)
        del v3
        v21, v22, v23 = method100(v4)
        del v4
        return method102(v16, v17, v18, v19, v20, v21, v22, v23)
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
        return method141(v4, v3, v5, v0, v6)
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
def method18(v0 : object) -> US8:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Ace" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US8_0()
    else:
        del v4
        v7 = "Eight" == v1
        if v7:
            del v1, v7
            method4(v2)
            del v2
            return US8_1()
        else:
            del v7
            v10 = "Five" == v1
            if v10:
                del v1, v10
                method4(v2)
                del v2
                return US8_2()
            else:
                del v10
                v13 = "Four" == v1
                if v13:
                    del v1, v13
                    method4(v2)
                    del v2
                    return US8_3()
                else:
                    del v13
                    v16 = "Jack" == v1
                    if v16:
                        del v1, v16
                        method4(v2)
                        del v2
                        return US8_4()
                    else:
                        del v16
                        v19 = "King" == v1
                        if v19:
                            del v1, v19
                            method4(v2)
                            del v2
                            return US8_5()
                        else:
                            del v19
                            v22 = "Nine" == v1
                            if v22:
                                del v1, v22
                                method4(v2)
                                del v2
                                return US8_6()
                            else:
                                del v22
                                v25 = "Queen" == v1
                                if v25:
                                    del v1, v25
                                    method4(v2)
                                    del v2
                                    return US8_7()
                                else:
                                    del v25
                                    v28 = "Seven" == v1
                                    if v28:
                                        del v1, v28
                                        method4(v2)
                                        del v2
                                        return US8_8()
                                    else:
                                        del v28
                                        v31 = "Six" == v1
                                        if v31:
                                            del v1, v31
                                            method4(v2)
                                            del v2
                                            return US8_9()
                                        else:
                                            del v31
                                            v34 = "Ten" == v1
                                            if v34:
                                                del v1, v34
                                                method4(v2)
                                                del v2
                                                return US8_10()
                                            else:
                                                del v34
                                                v37 = "Three" == v1
                                                if v37:
                                                    del v1, v37
                                                    method4(v2)
                                                    del v2
                                                    return US8_11()
                                                else:
                                                    del v37
                                                    v40 = "Two" == v1
                                                    if v40:
                                                        del v1, v40
                                                        method4(v2)
                                                        del v2
                                                        return US8_12()
                                                    else:
                                                        del v2, v40
                                                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                                        del v1
                                                        raise Exception("Error")
def method19(v0 : object) -> US9:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Clubs" == v1
    if v4:
        del v1, v4
        method4(v2)
        del v2
        return US9_0()
    else:
        del v4
        v7 = "Diamonds" == v1
        if v7:
            del v1, v7
            method4(v2)
            del v2
            return US9_1()
        else:
            del v7
            v10 = "Hearts" == v1
            if v10:
                del v1, v10
                method4(v2)
                del v2
                return US9_2()
            else:
                del v10
                v13 = "Spades" == v1
                if v13:
                    del v1, v13
                    method4(v2)
                    del v2
                    return US9_3()
                else:
                    del v2, v13
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method17(v0 : object) -> Tuple[US8, US9]:
    v1 = v0[0] # type: ignore
    v2 = method18(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method19(v3)
    del v3
    return v2, v4
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
        v10, v11 = method17(v9)
        del v9
        v12 = 0 <= v7
        if v12:
            v13 = v6.length
            v14 = v7 < v13
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
        v6[v7] = (v10, v11)
        del v10, v11
        v7 += 1 
    del v0, v2, v7
    return v6
def method20(v0 : object) -> Tuple[i32, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0["winner_id"] # type: ignore
    del v0
    v4 = method5(v3)
    del v3
    return v2, v4
def method21(v0 : object) -> Tuple[i32, US1]:
    v1 = v0[0] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method3(v3)
    del v3
    return v2, v4
def method23(v0 : object) -> static_array:
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
        v9, v10 = method17(v8)
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
def method22(v0 : object) -> Tuple[i32, static_array]:
    v1 = v0[0] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0[1] # type: ignore
    del v0
    v4 = method23(v3)
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
        v9, v10 = method17(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 5
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
def method26(v0 : object) -> US10:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Flush" == v1
    if v4:
        del v1, v4
        v5 = method27(v2)
        del v2
        return US10_0(v5)
    else:
        del v4
        v8 = "Full_House" == v1
        if v8:
            del v1, v8
            v9 = method27(v2)
            del v2
            return US10_1(v9)
        else:
            del v8
            v12 = "High_Card" == v1
            if v12:
                del v1, v12
                v13 = method27(v2)
                del v2
                return US10_2(v13)
            else:
                del v12
                v16 = "Pair" == v1
                if v16:
                    del v1, v16
                    v17 = method27(v2)
                    del v2
                    return US10_3(v17)
                else:
                    del v16
                    v20 = "Quads" == v1
                    if v20:
                        del v1, v20
                        v21 = method27(v2)
                        del v2
                        return US10_4(v21)
                    else:
                        del v20
                        v24 = "Straight" == v1
                        if v24:
                            del v1, v24
                            v25 = method27(v2)
                            del v2
                            return US10_5(v25)
                        else:
                            del v24
                            v28 = "Straight_Flush" == v1
                            if v28:
                                del v1, v28
                                v29 = method27(v2)
                                del v2
                                return US10_6(v29)
                            else:
                                del v28
                                v32 = "Triple" == v1
                                if v32:
                                    del v1, v32
                                    v33 = method27(v2)
                                    del v2
                                    return US10_7(v33)
                                else:
                                    del v32
                                    v36 = "Two_Pair" == v1
                                    if v36:
                                        del v1, v36
                                        v37 = method27(v2)
                                        del v2
                                        return US10_8(v37)
                                    else:
                                        del v2, v36
                                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                        del v1
                                        raise Exception("Error")
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
    while method7(v1, v6):
        v8 = v0[v6]
        v9 = method26(v8)
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
def method24(v0 : object) -> Tuple[i32, static_array, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method5(v1)
    del v1
    v3 = v0["hands_shown"] # type: ignore
    v4 = method25(v3)
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
            v9, v10 = method20(v2)
            del v2
            return US7_1(v9, v10)
        else:
            del v8
            v13 = "PlayerAction" == v1
            if v13:
                del v1, v13
                v14, v15 = method21(v2)
                del v2
                return US7_2(v14, v15)
            else:
                del v13
                v18 = "PlayerGotCards" == v1
                if v18:
                    del v1, v18
                    v19, v20 = method22(v2)
                    del v2
                    return US7_3(v19, v20)
                else:
                    del v18
                    v23 = "Showdown" == v1
                    if v23:
                        del v1, v23
                        v24, v25, v26 = method24(v2)
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
def method32(v0 : object) -> i32:
    v1 = v0["min_raise"] # type: ignore
    del v0
    v2 = method5(v1)
    del v1
    return v2
def method33(v0 : object) -> bool:
    assert isinstance(v0,bool), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
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
        v9 = method23(v8)
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
        v9, v10 = method17(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 3
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
        v9, v10 = method17(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 4
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
def method31(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5]:
    v1 = v0["config"] # type: ignore
    v2 = method32(v1)
    del v1
    v3 = v0["is_button_s_first_move"] # type: ignore
    v4 = method33(v3)
    del v3
    v5 = v0["pl_card"] # type: ignore
    v6 = method34(v5)
    del v5
    v7 = v0["player_turn"] # type: ignore
    v8 = method5(v7)
    del v7
    v9 = v0["pot"] # type: ignore
    v10 = method35(v9)
    del v9
    v11 = v0["stack"] # type: ignore
    v12 = method35(v11)
    del v11
    v13 = v0["street"] # type: ignore
    del v0
    v14 = method36(v13)
    del v13
    return v2, v4, v6, v8, v10, v12, v14
def method39(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5, US1]:
    v1 = v0[0] # type: ignore
    v2, v3, v4, v5, v6, v7, v8 = method31(v1)
    del v1
    v9 = v0[1] # type: ignore
    del v0
    v10 = method3(v9)
    del v9
    return v2, v3, v4, v5, v6, v7, v8, v10
def method30(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "G_Flop" == v1
    if v4:
        del v1, v4
        v5, v6, v7, v8, v9, v10, v11 = method31(v2)
        del v2
        return US4_0(v5, v6, v7, v8, v9, v10, v11)
    else:
        del v4
        v14 = "G_Fold" == v1
        if v14:
            del v1, v14
            v15, v16, v17, v18, v19, v20, v21 = method31(v2)
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
                    v28, v29, v30, v31, v32, v33, v34 = method31(v2)
                    del v2
                    return US4_3(v28, v29, v30, v31, v32, v33, v34)
                else:
                    del v27
                    v37 = "G_Round" == v1
                    if v37:
                        del v1, v37
                        v38, v39, v40, v41, v42, v43, v44 = method31(v2)
                        del v2
                        return US4_4(v38, v39, v40, v41, v42, v43, v44)
                    else:
                        del v37
                        v47 = "G_Round'" == v1
                        if v47:
                            del v1, v47
                            v48, v49, v50, v51, v52, v53, v54, v55 = method39(v2)
                            del v2
                            return US4_5(v48, v49, v50, v51, v52, v53, v54, v55)
                        else:
                            del v47
                            v58 = "G_Showdown" == v1
                            if v58:
                                del v1, v58
                                v59, v60, v61, v62, v63, v64, v65 = method31(v2)
                                del v2
                                return US4_6(v59, v60, v61, v62, v63, v64, v65)
                            else:
                                del v58
                                v68 = "G_Turn" == v1
                                if v68:
                                    del v1, v68
                                    v69, v70, v71, v72, v73, v74, v75 = method31(v2)
                                    del v2
                                    return US4_7(v69, v70, v71, v72, v73, v74, v75)
                                else:
                                    del v2, v68
                                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                    del v1
                                    raise Exception("Error")
def method29(v0 : object) -> US3:
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
            v8 = method30(v2)
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
            v8, v9, v10, v11, v12, v13, v14 = method31(v2)
            del v2
            return US6_1(v8, v9, v10, v11, v12, v13, v14)
        else:
            del v7
            v17 = "WaitingForActionFromPlayerId" == v1
            if v17:
                del v1, v17
                v18, v19, v20, v21, v22, v23, v24 = method31(v2)
                del v2
                return US6_2(v18, v19, v20, v21, v22, v23, v24)
            else:
                del v2, v17
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method28(v0 : object) -> Tuple[US3, static_array, US6]:
    v1 = v0["game"] # type: ignore
    v2 = method29(v1)
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
    v5, v6, v7 = method28(v4)
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
def method54(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method53(v0 : cp.ndarray, v1 : US8, v2 : US9) -> None:
    v3 = v1.tag
    method42(v0, v3)
    del v3
    v4 = v0[4:].view(cp.uint8)
    match v1:
        case US8_0(): # Ace
            method44(v4)
        case US8_1(): # Eight
            method44(v4)
        case US8_2(): # Five
            method44(v4)
        case US8_3(): # Four
            method44(v4)
        case US8_4(): # Jack
            method44(v4)
        case US8_5(): # King
            method44(v4)
        case US8_6(): # Nine
            method44(v4)
        case US8_7(): # Queen
            method44(v4)
        case US8_8(): # Seven
            method44(v4)
        case US8_9(): # Six
            method44(v4)
        case US8_10(): # Ten
            method44(v4)
        case US8_11(): # Three
            method44(v4)
        case US8_12(): # Two
            method44(v4)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1, v4
    v5 = v2.tag
    method54(v0, v5)
    del v5
    v6 = v0[8:].view(cp.uint8)
    del v0
    match v2:
        case US9_0(): # Clubs
            del v2
            return method44(v6)
        case US9_1(): # Diamonds
            del v2
            return method44(v6)
        case US9_2(): # Hearts
            del v2
            return method44(v6)
        case US9_3(): # Spades
            del v2
            return method44(v6)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method52(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method42(v0, v2)
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
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
        method53(v9, v16, v17)
        del v9, v16, v17
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
def method56(v0 : cp.ndarray, v1 : i32, v2 : US1) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method54(v0, v4)
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
def method57(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method46(v4):
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
        method53(v9, v15, v16)
        del v9, v15, v16
        v4 += 1 
    del v0, v2, v4
    return 
def method61(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method60(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method61(v2):
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
        method53(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method59(v0 : cp.ndarray, v1 : US10) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US10_0(v4): # Flush
            del v1
            return method60(v3, v4)
        case US10_1(v5): # Full_House
            del v1
            return method60(v3, v5)
        case US10_2(v6): # High_Card
            del v1
            return method60(v3, v6)
        case US10_3(v7): # Pair
            del v1
            return method60(v3, v7)
        case US10_4(v8): # Quads
            del v1
            return method60(v3, v8)
        case US10_5(v9): # Straight
            del v1
            return method60(v3, v9)
        case US10_6(v10): # Straight_Flush
            del v1
            return method60(v3, v10)
        case US10_7(v11): # Triple
            del v1
            return method60(v3, v11)
        case US10_8(v12): # Two_Pair
            del v1
            return method60(v3, v12)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method58(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
    v4 = v0[0:].view(cp.int32)
    v4[0] = v1
    del v1, v4
    v5 = 0
    while method46(v5):
        v7 = u64(v5)
        v8 = v7 * 64
        del v7
        v9 = 16 + v8
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
        v16 = v2[v5]
        method59(v10, v16)
        del v10, v16
        v5 += 1 
    del v2, v5
    v17 = v0[144:].view(cp.int32)
    del v0
    v17[0] = v3
    del v3, v17
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
            return method57(v3, v9, v10)
        case US7_4(v11, v12, v13): # Showdown
            del v1
            return method58(v3, v11, v12, v13)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method62(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[22544:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method65(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method46(v2):
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
        method53(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method66(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[68:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method68(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method67(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method68(v2):
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
        method53(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method70(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method69(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method70(v2):
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
        method53(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method64(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[0:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[4:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method46(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 16 + v13
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
        method65(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[48:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method46(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 52 + v26
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
        method42(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method46(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 60 + v38
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
        method42(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method66(v0, v47)
    del v47
    v48 = v0[80:].view(cp.uint8)
    del v0
    match v7:
        case US5_0(v49): # Flop
            del v7
            return method67(v48, v49)
        case US5_1(): # Preflop
            del v7
            return method44(v48)
        case US5_2(v50): # River
            del v7
            return method60(v48, v50)
        case US5_3(v51): # Turn
            del v7
            return method69(v48, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method72(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[128:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method71(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[0:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[4:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method46(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 16 + v14
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
        method65(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[48:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method46(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 52 + v27
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
        method42(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method46(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 60 + v39
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
        method42(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method66(v0, v48)
    del v48
    v49 = v0[80:].view(cp.uint8)
    match v7:
        case US5_0(v50): # Flop
            method67(v49, v50)
        case US5_1(): # Preflop
            method44(v49)
        case US5_2(v51): # River
            method60(v49, v51)
        case US5_3(v52): # Turn
            method69(v49, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7, v49
    v53 = v8.tag
    method72(v0, v53)
    del v53
    v54 = v0[132:].view(cp.uint8)
    del v0
    match v8:
        case US1_0(): # A_Call
            del v8
            return method44(v54)
        case US1_1(): # A_Fold
            del v8
            return method44(v54)
        case US1_2(v55): # A_Raise
            del v8
            return method42(v54, v55)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method63(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method42(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9, v10): # G_Flop
            del v1
            return method64(v3, v4, v5, v6, v7, v8, v9, v10)
        case US4_1(v11, v12, v13, v14, v15, v16, v17): # G_Fold
            del v1
            return method64(v3, v11, v12, v13, v14, v15, v16, v17)
        case US4_2(): # G_Preflop
            del v1
            return method44(v3)
        case US4_3(v18, v19, v20, v21, v22, v23, v24): # G_River
            del v1
            return method64(v3, v18, v19, v20, v21, v22, v23, v24)
        case US4_4(v25, v26, v27, v28, v29, v30, v31): # G_Round
            del v1
            return method64(v3, v25, v26, v27, v28, v29, v30, v31)
        case US4_5(v32, v33, v34, v35, v36, v37, v38, v39): # G_Round'
            del v1
            return method71(v3, v32, v33, v34, v35, v36, v37, v38, v39)
        case US4_6(v40, v41, v42, v43, v44, v45, v46): # G_Showdown
            del v1
            return method64(v3, v40, v41, v42, v43, v44, v45, v46)
        case US4_7(v47, v48, v49, v50, v51, v52, v53): # G_Turn
            del v1
            return method64(v3, v47, v48, v49, v50, v51, v52, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method73(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[22728:].view(cp.int32)
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
        v11 = v10 * 176
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
    method62(v0, v21)
    del v21
    v22 = v0[22560:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method44(v22)
        case US3_1(v23): # Some
            method63(v22, v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v22
    v24 = 0
    while method46(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 22720 + v27
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
    method73(v0, v36)
    del v36
    v37 = v0[22736:].view(cp.uint8)
    del v0
    match v5:
        case US6_0(): # GameNotStarted
            del v5
            return method44(v37)
        case US6_1(v38, v39, v40, v41, v42, v43, v44): # GameOver
            del v5
            return method64(v37, v38, v39, v40, v41, v42, v43, v44)
        case US6_2(v45, v46, v47, v48, v49, v50, v51): # WaitingForActionFromPlayerId
            del v5
            return method64(v37, v45, v46, v47, v48, v49, v50, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method75(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method76(v0 : cp.ndarray) -> i32:
    v1 = v0[8:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method78(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method81(v0 : cp.ndarray) -> None:
    del v0
    return 
def method82(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method80(v0 : cp.ndarray) -> Tuple[US8, US9]:
    v1 = method78(v0)
    v2 = v0[4:].view(cp.uint8)
    if v1 == 0:
        method81(v2)
        v17 = US8_0()
    elif v1 == 1:
        method81(v2)
        v17 = US8_1()
    elif v1 == 2:
        method81(v2)
        v17 = US8_2()
    elif v1 == 3:
        method81(v2)
        v17 = US8_3()
    elif v1 == 4:
        method81(v2)
        v17 = US8_4()
    elif v1 == 5:
        method81(v2)
        v17 = US8_5()
    elif v1 == 6:
        method81(v2)
        v17 = US8_6()
    elif v1 == 7:
        method81(v2)
        v17 = US8_7()
    elif v1 == 8:
        method81(v2)
        v17 = US8_8()
    elif v1 == 9:
        method81(v2)
        v17 = US8_9()
    elif v1 == 10:
        method81(v2)
        v17 = US8_10()
    elif v1 == 11:
        method81(v2)
        v17 = US8_11()
    elif v1 == 12:
        method81(v2)
        v17 = US8_12()
    else:
        raise Exception("Invalid tag.")
    del v1, v2
    v18 = method82(v0)
    v19 = v0[8:].view(cp.uint8)
    del v0
    if v18 == 0:
        method81(v19)
        v25 = US9_0()
    elif v18 == 1:
        method81(v19)
        v25 = US9_1()
    elif v18 == 2:
        method81(v19)
        v25 = US9_2()
    elif v18 == 3:
        method81(v19)
        v25 = US9_3()
    else:
        raise Exception("Invalid tag.")
    del v18, v19
    return v17, v25
def method79(v0 : cp.ndarray) -> static_array_list:
    v1 = static_array_list(5)
    v2 = method78(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11 = method80(v9)
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
def method83(v0 : cp.ndarray) -> Tuple[i32, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.int32)
    del v0
    v4 = v3[0].item()
    del v3
    return v2, v4
def method84(v0 : cp.ndarray) -> Tuple[i32, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method82(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method81(v4)
        v10 = US1_0()
    elif v3 == 1:
        method81(v4)
        v10 = US1_1()
    elif v3 == 2:
        v8 = method78(v4)
        v10 = US1_2(v8)
    else:
        raise Exception("Invalid tag.")
    del v3, v4
    return v2, v10
def method85(v0 : cp.ndarray) -> Tuple[i32, static_array]:
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
        v10, v11 = method80(v9)
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
def method88(v0 : cp.ndarray) -> static_array:
    v1 = static_array(5)
    v2 = 0
    while method61(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method80(v6)
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
def method87(v0 : cp.ndarray) -> US10:
    v1 = method78(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method88(v2)
        del v2
        return US10_0(v4)
    elif v1 == 1:
        del v1
        v6 = method88(v2)
        del v2
        return US10_1(v6)
    elif v1 == 2:
        del v1
        v8 = method88(v2)
        del v2
        return US10_2(v8)
    elif v1 == 3:
        del v1
        v10 = method88(v2)
        del v2
        return US10_3(v10)
    elif v1 == 4:
        del v1
        v12 = method88(v2)
        del v2
        return US10_4(v12)
    elif v1 == 5:
        del v1
        v14 = method88(v2)
        del v2
        return US10_5(v14)
    elif v1 == 6:
        del v1
        v16 = method88(v2)
        del v2
        return US10_6(v16)
    elif v1 == 7:
        del v1
        v18 = method88(v2)
        del v2
        return US10_7(v18)
    elif v1 == 8:
        del v1
        v20 = method88(v2)
        del v2
        return US10_8(v20)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method86(v0 : cp.ndarray) -> Tuple[i32, static_array, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method46(v4):
        v6 = u64(v4)
        v7 = v6 * 64
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method87(v9)
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
    v16 = v0[144:].view(cp.int32)
    del v0
    v17 = v16[0].item()
    del v16
    return v2, v3, v17
def method77(v0 : cp.ndarray) -> US7:
    v1 = method78(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method79(v2)
        del v2
        return US7_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method83(v2)
        del v2
        return US7_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method84(v2)
        del v2
        return US7_2(v9, v10)
    elif v1 == 3:
        del v1
        v12, v13 = method85(v2)
        del v2
        return US7_3(v12, v13)
    elif v1 == 4:
        del v1
        v15, v16, v17 = method86(v2)
        del v2
        return US7_4(v15, v16, v17)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method89(v0 : cp.ndarray) -> i32:
    v1 = v0[22544:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method92(v0 : cp.ndarray) -> static_array:
    v1 = static_array(2)
    v2 = 0
    while method46(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method80(v6)
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
def method93(v0 : cp.ndarray) -> i32:
    v1 = v0[68:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method94(v0 : cp.ndarray) -> static_array:
    v1 = static_array(3)
    v2 = 0
    while method68(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method80(v6)
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
def method95(v0 : cp.ndarray) -> static_array:
    v1 = static_array(4)
    v2 = 0
    while method70(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7, v8 = method80(v6)
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
def method91(v0 : cp.ndarray) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.bool_)
    v4 = v3[0].item()
    del v3
    v5 = static_array(2)
    v6 = 0
    while method46(v6):
        v8 = u64(v6)
        v9 = v8 * 16
        del v8
        v10 = 16 + v9
        del v9
        v11 = v0[v10:].view(cp.uint8)
        del v10
        v12 = method92(v11)
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
    v18 = v0[48:].view(cp.int32)
    v19 = v18[0].item()
    del v18
    v20 = static_array(2)
    v21 = 0
    while method46(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 52 + v24
        del v24
        v26 = v0[v25:].view(cp.uint8)
        del v25
        v27 = method78(v26)
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
    while method46(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 60 + v37
        del v37
        v39 = v0[v38:].view(cp.uint8)
        del v38
        v40 = method78(v39)
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
    v46 = method93(v0)
    v47 = v0[80:].view(cp.uint8)
    del v0
    if v46 == 0:
        v49 = method94(v47)
        v56 = US5_0(v49)
    elif v46 == 1:
        method81(v47)
        v56 = US5_1()
    elif v46 == 2:
        v52 = method88(v47)
        v56 = US5_2(v52)
    elif v46 == 3:
        v54 = method95(v47)
        v56 = US5_3(v54)
    else:
        raise Exception("Invalid tag.")
    del v46, v47
    return v2, v4, v5, v19, v20, v33, v56
def method97(v0 : cp.ndarray) -> i32:
    v1 = v0[128:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method96(v0 : cp.ndarray) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5, US1]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.bool_)
    v4 = v3[0].item()
    del v3
    v5 = static_array(2)
    v6 = 0
    while method46(v6):
        v8 = u64(v6)
        v9 = v8 * 16
        del v8
        v10 = 16 + v9
        del v9
        v11 = v0[v10:].view(cp.uint8)
        del v10
        v12 = method92(v11)
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
    v18 = v0[48:].view(cp.int32)
    v19 = v18[0].item()
    del v18
    v20 = static_array(2)
    v21 = 0
    while method46(v21):
        v23 = u64(v21)
        v24 = v23 * 4
        del v23
        v25 = 52 + v24
        del v24
        v26 = v0[v25:].view(cp.uint8)
        del v25
        v27 = method78(v26)
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
    while method46(v34):
        v36 = u64(v34)
        v37 = v36 * 4
        del v36
        v38 = 60 + v37
        del v37
        v39 = v0[v38:].view(cp.uint8)
        del v38
        v40 = method78(v39)
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
    v46 = method93(v0)
    v47 = v0[80:].view(cp.uint8)
    if v46 == 0:
        v49 = method94(v47)
        v56 = US5_0(v49)
    elif v46 == 1:
        method81(v47)
        v56 = US5_1()
    elif v46 == 2:
        v52 = method88(v47)
        v56 = US5_2(v52)
    elif v46 == 3:
        v54 = method95(v47)
        v56 = US5_3(v54)
    else:
        raise Exception("Invalid tag.")
    del v46, v47
    v57 = method97(v0)
    v58 = v0[132:].view(cp.uint8)
    del v0
    if v57 == 0:
        method81(v58)
        v64 = US1_0()
    elif v57 == 1:
        method81(v58)
        v64 = US1_1()
    elif v57 == 2:
        v62 = method78(v58)
        v64 = US1_2(v62)
    else:
        raise Exception("Invalid tag.")
    del v57, v58
    return v2, v4, v5, v19, v20, v33, v56, v64
def method90(v0 : cp.ndarray) -> US4:
    v1 = method78(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9, v10 = method91(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9, v10)
    elif v1 == 1:
        del v1
        v12, v13, v14, v15, v16, v17, v18 = method91(v2)
        del v2
        return US4_1(v12, v13, v14, v15, v16, v17, v18)
    elif v1 == 2:
        del v1
        method81(v2)
        del v2
        return US4_2()
    elif v1 == 3:
        del v1
        v21, v22, v23, v24, v25, v26, v27 = method91(v2)
        del v2
        return US4_3(v21, v22, v23, v24, v25, v26, v27)
    elif v1 == 4:
        del v1
        v29, v30, v31, v32, v33, v34, v35 = method91(v2)
        del v2
        return US4_4(v29, v30, v31, v32, v33, v34, v35)
    elif v1 == 5:
        del v1
        v37, v38, v39, v40, v41, v42, v43, v44 = method96(v2)
        del v2
        return US4_5(v37, v38, v39, v40, v41, v42, v43, v44)
    elif v1 == 6:
        del v1
        v46, v47, v48, v49, v50, v51, v52 = method91(v2)
        del v2
        return US4_6(v46, v47, v48, v49, v50, v51, v52)
    elif v1 == 7:
        del v1
        v54, v55, v56, v57, v58, v59, v60 = method91(v2)
        del v2
        return US4_7(v54, v55, v56, v57, v58, v59, v60)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method98(v0 : cp.ndarray) -> US2:
    v1 = method78(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method81(v2)
        del v2
        return US2_0()
    elif v1 == 1:
        del v1
        method81(v2)
        del v2
        return US2_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method99(v0 : cp.ndarray) -> i32:
    v1 = v0[22728:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method74(v0 : cp.ndarray) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = method75(v0)
    v2 = static_array_list(128)
    v3 = method76(v0)
    v2.length = v3
    del v3
    v4 = v2.length
    v5 = 0
    while method7(v4, v5):
        v7 = u64(v5)
        v8 = v7 * 176
        del v7
        v9 = 16 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = method77(v10)
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
    v18 = method89(v0)
    v19 = v0[22560:].view(cp.uint8)
    if v18 == 0:
        method81(v19)
        v24 = US3_0()
    elif v18 == 1:
        v22 = method90(v19)
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
        v30 = 22720 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method98(v31)
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
    v38 = method99(v0)
    v39 = v0[22736:].view(cp.uint8)
    del v0
    if v38 == 0:
        method81(v39)
        v58 = US6_0()
    elif v38 == 1:
        v42, v43, v44, v45, v46, v47, v48 = method91(v39)
        v58 = US6_1(v42, v43, v44, v45, v46, v47, v48)
    elif v38 == 2:
        v50, v51, v52, v53, v54, v55, v56 = method91(v39)
        v58 = US6_2(v50, v51, v52, v53, v54, v55, v56)
    else:
        raise Exception("Invalid tag.")
    del v38, v39
    return v1, v2, v24, v25, v58
def method101(v0 : cp.ndarray) -> i32:
    v1 = v0[22552:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method100(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US6]:
    v1 = static_array_list(128)
    v2 = method78(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method7(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 176
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method77(v9)
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
        v22 = 22544 + v21
        del v21
        v23 = v0[v22:].view(cp.uint8)
        del v22
        v24 = method98(v23)
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
    v30 = method101(v0)
    v31 = v0[22560:].view(cp.uint8)
    del v0
    if v30 == 0:
        method81(v31)
        v50 = US6_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39, v40 = method91(v31)
        v50 = US6_1(v34, v35, v36, v37, v38, v39, v40)
    elif v30 == 2:
        v42, v43, v44, v45, v46, v47, v48 = method91(v31)
        v50 = US6_2(v42, v43, v44, v45, v46, v47, v48)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v50
def method107(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method106(v0 : u64) -> object:
    return method107(v0)
def method113() -> object:
    v0 = []
    return v0
def method112(v0 : US8) -> object:
    match v0:
        case US8_0(): # Ace
            del v0
            v1 = method113()
            v2 = "Ace"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US8_1(): # Eight
            del v0
            v4 = method113()
            v5 = "Eight"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US8_2(): # Five
            del v0
            v7 = method113()
            v8 = "Five"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US8_3(): # Four
            del v0
            v10 = method113()
            v11 = "Four"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US8_4(): # Jack
            del v0
            v13 = method113()
            v14 = "Jack"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case US8_5(): # King
            del v0
            v16 = method113()
            v17 = "King"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US8_6(): # Nine
            del v0
            v19 = method113()
            v20 = "Nine"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US8_7(): # Queen
            del v0
            v22 = method113()
            v23 = "Queen"
            v24 = [v23,v22]
            del v22, v23
            return v24
        case US8_8(): # Seven
            del v0
            v25 = method113()
            v26 = "Seven"
            v27 = [v26,v25]
            del v25, v26
            return v27
        case US8_9(): # Six
            del v0
            v28 = method113()
            v29 = "Six"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US8_10(): # Ten
            del v0
            v31 = method113()
            v32 = "Ten"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US8_11(): # Three
            del v0
            v34 = method113()
            v35 = "Three"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US8_12(): # Two
            del v0
            v37 = method113()
            v38 = "Two"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method114(v0 : US9) -> object:
    match v0:
        case US9_0(): # Clubs
            del v0
            v1 = method113()
            v2 = "Clubs"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US9_1(): # Diamonds
            del v0
            v4 = method113()
            v5 = "Diamonds"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US9_2(): # Hearts
            del v0
            v7 = method113()
            v8 = "Hearts"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US9_3(): # Spades
            del v0
            v10 = method113()
            v11 = "Spades"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method111(v0 : US8, v1 : US9) -> object:
    v2 = []
    v3 = method112(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method114(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method110(v0 : static_array_list) -> object:
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
        v11, v12 = v0[v3]
        v13 = method111(v11, v12)
        del v11, v12
        v1.append(v13)
        del v13
        v3 += 1 
    del v0, v2, v3
    return v1
def method116(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method115(v0 : i32, v1 : i32) -> object:
    v2 = method116(v0)
    del v0
    v3 = method116(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method118(v0 : US1) -> object:
    match v0:
        case US1_0(): # A_Call
            del v0
            v1 = method113()
            v2 = "A_Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # A_Fold
            del v0
            v4 = method113()
            v5 = "A_Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(v7): # A_Raise
            del v0
            v8 = method116(v7)
            del v7
            v9 = "A_Raise"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method117(v0 : i32, v1 : US1) -> object:
    v2 = []
    v3 = method116(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method118(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method120(v0 : static_array) -> object:
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
        v11 = method111(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method119(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method116(v0)
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
def method124(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method61(v2):
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
        v11 = method111(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method123(v0 : US10) -> object:
    match v0:
        case US10_0(v1): # Flush
            del v0
            v2 = method124(v1)
            del v1
            v3 = "Flush"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US10_1(v5): # Full_House
            del v0
            v6 = method124(v5)
            del v5
            v7 = "Full_House"
            v8 = [v7,v6]
            del v6, v7
            return v8
        case US10_2(v9): # High_Card
            del v0
            v10 = method124(v9)
            del v9
            v11 = "High_Card"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US10_3(v13): # Pair
            del v0
            v14 = method124(v13)
            del v13
            v15 = "Pair"
            v16 = [v15,v14]
            del v14, v15
            return v16
        case US10_4(v17): # Quads
            del v0
            v18 = method124(v17)
            del v17
            v19 = "Quads"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US10_5(v21): # Straight
            del v0
            v22 = method124(v21)
            del v21
            v23 = "Straight"
            v24 = [v23,v22]
            del v22, v23
            return v24
        case US10_6(v25): # Straight_Flush
            del v0
            v26 = method124(v25)
            del v25
            v27 = "Straight_Flush"
            v28 = [v27,v26]
            del v26, v27
            return v28
        case US10_7(v29): # Triple
            del v0
            v30 = method124(v29)
            del v29
            v31 = "Triple"
            v32 = [v31,v30]
            del v30, v31
            return v32
        case US10_8(v33): # Two_Pair
            del v0
            v34 = method124(v33)
            del v33
            v35 = "Two_Pair"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method122(v0 : static_array) -> object:
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
def method121(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method116(v0)
    del v0
    v4 = method122(v1)
    del v1
    v5 = method116(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method109(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method110(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method115(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method117(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method119(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method121(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method108(v0 : static_array_list) -> object:
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
        v12 = method109(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method105(v0 : u64, v1 : static_array_list) -> object:
    v2 = method106(v0)
    del v0
    v3 = method108(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method129(v0 : i32) -> object:
    v1 = method116(v0)
    del v0
    v2 = {'min_raise': v1}
    del v1
    return v2
def method130(v0 : bool) -> object:
    v1 = v0
    del v0
    return v1
def method131(v0 : static_array) -> object:
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
        v10 = method120(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method132(v0 : static_array) -> object:
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
        v10 = method116(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method134(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method68(v2):
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
        v11 = method111(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method135(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method70(v2):
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
        v11 = method111(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method133(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method134(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method113()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method124(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method135(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method128(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5) -> object:
    v7 = method129(v0)
    del v0
    v8 = method130(v1)
    del v1
    v9 = method131(v2)
    del v2
    v10 = method116(v3)
    del v3
    v11 = method132(v4)
    del v4
    v12 = method132(v5)
    del v5
    v13 = method133(v6)
    del v6
    v14 = {'config': v7, 'is_button_s_first_move': v8, 'pl_card': v9, 'player_turn': v10, 'pot': v11, 'stack': v12, 'street': v13}
    del v7, v8, v9, v10, v11, v12, v13
    return v14
def method136(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5, v7 : US1) -> object:
    v8 = []
    v9 = method128(v0, v1, v2, v3, v4, v5, v6)
    del v0, v1, v2, v3, v4, v5, v6
    v8.append(v9)
    del v9
    v10 = method118(v7)
    del v7
    v8.append(v10)
    del v10
    v11 = v8
    del v8
    return v11
def method127(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6, v7): # G_Flop
            del v0
            v8 = method128(v1, v2, v3, v4, v5, v6, v7)
            del v1, v2, v3, v4, v5, v6, v7
            v9 = "G_Flop"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case US4_1(v11, v12, v13, v14, v15, v16, v17): # G_Fold
            del v0
            v18 = method128(v11, v12, v13, v14, v15, v16, v17)
            del v11, v12, v13, v14, v15, v16, v17
            v19 = "G_Fold"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US4_2(): # G_Preflop
            del v0
            v21 = method113()
            v22 = "G_Preflop"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case US4_3(v24, v25, v26, v27, v28, v29, v30): # G_River
            del v0
            v31 = method128(v24, v25, v26, v27, v28, v29, v30)
            del v24, v25, v26, v27, v28, v29, v30
            v32 = "G_River"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US4_4(v34, v35, v36, v37, v38, v39, v40): # G_Round
            del v0
            v41 = method128(v34, v35, v36, v37, v38, v39, v40)
            del v34, v35, v36, v37, v38, v39, v40
            v42 = "G_Round"
            v43 = [v42,v41]
            del v41, v42
            return v43
        case US4_5(v44, v45, v46, v47, v48, v49, v50, v51): # G_Round'
            del v0
            v52 = method136(v44, v45, v46, v47, v48, v49, v50, v51)
            del v44, v45, v46, v47, v48, v49, v50, v51
            v53 = "G_Round'"
            v54 = [v53,v52]
            del v52, v53
            return v54
        case US4_6(v55, v56, v57, v58, v59, v60, v61): # G_Showdown
            del v0
            v62 = method128(v55, v56, v57, v58, v59, v60, v61)
            del v55, v56, v57, v58, v59, v60, v61
            v63 = "G_Showdown"
            v64 = [v63,v62]
            del v62, v63
            return v64
        case US4_7(v65, v66, v67, v68, v69, v70, v71): # G_Turn
            del v0
            v72 = method128(v65, v66, v67, v68, v69, v70, v71)
            del v65, v66, v67, v68, v69, v70, v71
            v73 = "G_Turn"
            v74 = [v73,v72]
            del v72, v73
            return v74
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method126(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method113()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method127(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method138(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = method113()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = method113()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method137(v0 : static_array) -> object:
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
        v10 = method138(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method139(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method113()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9, v10): # GameOver
            del v0
            v11 = method128(v4, v5, v6, v7, v8, v9, v10)
            del v4, v5, v6, v7, v8, v9, v10
            v12 = "GameOver"
            v13 = [v12,v11]
            del v11, v12
            return v13
        case US6_2(v14, v15, v16, v17, v18, v19, v20): # WaitingForActionFromPlayerId
            del v0
            v21 = method128(v14, v15, v16, v17, v18, v19, v20)
            del v14, v15, v16, v17, v18, v19, v20
            v22 = "WaitingForActionFromPlayerId"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method125(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method126(v0)
    del v0
    v4 = method137(v1)
    del v1
    v5 = method139(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method104(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method105(v0, v1)
    del v0, v1
    v6 = method125(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method140(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method108(v0)
    del v0
    v4 = method137(v1)
    del v1
    v5 = method139(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method103(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method104(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method140(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method102(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method103(v0, v1, v2, v3, v4, v5, v6, v7)
    del v0, v1, v2, v3, v4, v5, v6, v7
    return v8
def method142(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method104(v0, v1, v2, v3, v4)
    del v0, v2
    v6 = method140(v1, v3, v4)
    del v1, v3, v4
    v7 = {'game_state': v5, 'ui_state': v6}
    del v5, v6
    return v7
def method141(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method142(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("HU_Holdem_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
