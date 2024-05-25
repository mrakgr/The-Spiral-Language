kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
__device__ void write_0(const char * v0);
struct US1;
struct US2;
struct Tuple0;
struct US3;
struct US4;
struct US0;
struct US7;
struct US6;
struct US5;
struct US8;
struct US9;
struct Tuple1;
__device__ unsigned long long f_2(unsigned char * v0);
__device__ long f_3(unsigned char * v0);
__device__ long f_5(unsigned char * v0);
__device__ void f_8(unsigned char * v0);
__device__ long f_9(unsigned char * v0);
__device__ Tuple0 f_7(unsigned char * v0);
__device__ static_array_list<Tuple0,5l,long> f_6(unsigned char * v0);
struct Tuple2;
__device__ Tuple2 f_10(unsigned char * v0);
struct Tuple3;
__device__ Tuple3 f_11(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_12(unsigned char * v0);
struct Tuple5;
__device__ static_array<Tuple0,5l> f_15(unsigned char * v0);
__device__ US4 f_14(unsigned char * v0);
__device__ Tuple5 f_13(unsigned char * v0);
__device__ US0 f_4(unsigned char * v0);
__device__ long f_16(unsigned char * v0);
struct Tuple6;
__device__ static_array<Tuple0,2l> f_19(unsigned char * v0);
__device__ long f_20(unsigned char * v0);
__device__ static_array<Tuple0,3l> f_21(unsigned char * v0);
__device__ static_array<Tuple0,4l> f_22(unsigned char * v0);
__device__ Tuple6 f_18(unsigned char * v0);
struct Tuple7;
__device__ long f_24(unsigned char * v0);
__device__ Tuple7 f_23(unsigned char * v0);
__device__ US6 f_17(unsigned char * v0);
__device__ US8 f_25(unsigned char * v0);
__device__ long f_26(unsigned char * v0);
__device__ Tuple1 f_1(unsigned char * v0);
__device__ void f_28(unsigned char * v0, unsigned long long v1);
__device__ void f_29(unsigned char * v0, long v1);
__device__ void f_31(unsigned char * v0, long v1);
__device__ void f_34(unsigned char * v0);
__device__ void f_35(unsigned char * v0, long v1);
__device__ void f_33(unsigned char * v0, US1 v1, US2 v2);
__device__ void f_32(unsigned char * v0, static_array_list<Tuple0,5l,long> v1);
__device__ void f_36(unsigned char * v0, long v1, long v2);
__device__ void f_37(unsigned char * v0, long v1, US3 v2);
__device__ void f_38(unsigned char * v0, long v1, static_array<Tuple0,2l> v2);
__device__ void f_41(unsigned char * v0, static_array<Tuple0,5l> v1);
__device__ void f_40(unsigned char * v0, US4 v1);
__device__ void f_39(unsigned char * v0, long v1, static_array<US4,2l> v2, long v3);
__device__ void f_30(unsigned char * v0, US0 v1);
__device__ void f_42(unsigned char * v0, long v1);
__device__ void f_45(unsigned char * v0, static_array<Tuple0,2l> v1);
__device__ void f_46(unsigned char * v0, long v1);
__device__ void f_47(unsigned char * v0, static_array<Tuple0,3l> v1);
__device__ void f_48(unsigned char * v0, static_array<Tuple0,4l> v1);
__device__ void f_44(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US7 v7);
__device__ void f_50(unsigned char * v0, long v1);
__device__ void f_49(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US7 v7, US3 v8);
__device__ void f_43(unsigned char * v0, US6 v1);
__device__ void f_51(unsigned char * v0, US8 v1);
__device__ void f_52(unsigned char * v0, long v1);
__device__ void f_27(unsigned char * v0, unsigned long long v1, static_array_list<US0,128l,long> v2, US5 v3, static_array<US8,2l> v4, US9 v5);
__device__ void f_54(unsigned char * v0, long v1);
__device__ void f_53(unsigned char * v0, static_array_list<US0,128l,long> v1, static_array<US8,2l> v2, US9 v3);
struct US1 {
    union {
    } v;
    unsigned long tag : 4;
};
struct US2 {
    union {
    } v;
    unsigned long tag : 3;
};
struct Tuple0 {
    US1 v0;
    US2 v1;
    __device__ Tuple0(US1 t0, US2 t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct US3 {
    union {
        struct {
            long v0;
        } case2; // A_Raise
    } v;
    unsigned long tag : 2;
};
struct US4 {
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
struct US0 {
    union {
        struct {
            static_array_list<Tuple0,5l,long> v0;
        } case0; // CommunityCardsAre
        struct {
            long v0;
            long v1;
        } case1; // Fold
        struct {
            US3 v1;
            long v0;
        } case2; // PlayerAction
        struct {
            static_array<Tuple0,2l> v1;
            long v0;
        } case3; // PlayerGotCards
        struct {
            static_array<US4,2l> v1;
            long v0;
            long v2;
        } case4; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US7 {
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
struct US6 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case0; // G_Flop
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // G_Fold
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case3; // G_River
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case4; // G_Round
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            US3 v7;
            long v0;
            long v3;
            bool v1;
        } case5; // G_Round'
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case6; // G_Showdown
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case7; // G_Turn
    } v;
    unsigned long tag : 4;
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
    } v;
    unsigned long tag : 2;
};
struct US9 {
    union {
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case1; // GameOver
        struct {
            static_array<static_array<Tuple0,2l>,2l> v2;
            static_array<long,2l> v4;
            static_array<long,2l> v5;
            US7 v6;
            long v0;
            long v3;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple1 {
    unsigned long long v0;
    static_array_list<US0,128l,long> v1;
    US5 v2;
    static_array<US8,2l> v3;
    US9 v4;
    __device__ Tuple1(unsigned long long t0, static_array_list<US0,128l,long> t1, US5 t2, static_array<US8,2l> t3, US9 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    long v0;
    long v1;
    __device__ Tuple2(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    US3 v1;
    long v0;
    __device__ Tuple3(long t0, US3 t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
struct Tuple4 {
    static_array<Tuple0,2l> v1;
    long v0;
    __device__ Tuple4(long t0, static_array<Tuple0,2l> t1) : v0(t0), v1(t1) {}
    __device__ Tuple4() = default;
};
struct Tuple5 {
    static_array<US4,2l> v1;
    long v0;
    long v2;
    __device__ Tuple5(long t0, static_array<US4,2l> t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple5() = default;
};
struct Tuple6 {
    static_array<static_array<Tuple0,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US7 v6;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple6(long t0, bool t1, static_array<static_array<Tuple0,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US7 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<Tuple0,2l>,2l> v2;
    static_array<long,2l> v4;
    static_array<long,2l> v5;
    US7 v6;
    US3 v7;
    long v0;
    long v3;
    bool v1;
    __device__ Tuple7(long t0, bool t1, static_array<static_array<Tuple0,2l>,2l> t2, long t3, static_array<long,2l> t4, static_array<long,2l> t5, US7 t6, US3 t7) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6), v7(t7) {}
    __device__ Tuple7() = default;
};
__device__ void write_0(const char * v0){
    const char * v1;
    v1 = "%s";
    printf(v1,v0);
    return ;
}
__device__ US1 US1_0() { // Ace
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // Eight
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2() { // Five
    US1 x;
    x.tag = 2;
    return x;
}
__device__ US1 US1_3() { // Four
    US1 x;
    x.tag = 3;
    return x;
}
__device__ US1 US1_4() { // Jack
    US1 x;
    x.tag = 4;
    return x;
}
__device__ US1 US1_5() { // King
    US1 x;
    x.tag = 5;
    return x;
}
__device__ US1 US1_6() { // Nine
    US1 x;
    x.tag = 6;
    return x;
}
__device__ US1 US1_7() { // Queen
    US1 x;
    x.tag = 7;
    return x;
}
__device__ US1 US1_8() { // Seven
    US1 x;
    x.tag = 8;
    return x;
}
__device__ US1 US1_9() { // Six
    US1 x;
    x.tag = 9;
    return x;
}
__device__ US1 US1_10() { // Ten
    US1 x;
    x.tag = 10;
    return x;
}
__device__ US1 US1_11() { // Three
    US1 x;
    x.tag = 11;
    return x;
}
__device__ US1 US1_12() { // Two
    US1 x;
    x.tag = 12;
    return x;
}
__device__ US2 US2_0() { // Clubs
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1() { // Diamonds
    US2 x;
    x.tag = 1;
    return x;
}
__device__ US2 US2_2() { // Hearts
    US2 x;
    x.tag = 2;
    return x;
}
__device__ US2 US2_3() { // Spades
    US2 x;
    x.tag = 3;
    return x;
}
__device__ US3 US3_0() { // A_Call
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1() { // A_Fold
    US3 x;
    x.tag = 1;
    return x;
}
__device__ US3 US3_2(long v0) { // A_Raise
    US3 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US4 US4_0(static_array<Tuple0,5l> v0) { // Flush
    US4 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US4 US4_1(static_array<Tuple0,5l> v0) { // Full_House
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US4 US4_2(static_array<Tuple0,5l> v0) { // High_Card
    US4 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US4 US4_3(static_array<Tuple0,5l> v0) { // Pair
    US4 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US4 US4_4(static_array<Tuple0,5l> v0) { // Quads
    US4 x;
    x.tag = 4;
    x.v.case4.v0 = v0;
    return x;
}
__device__ US4 US4_5(static_array<Tuple0,5l> v0) { // Straight
    US4 x;
    x.tag = 5;
    x.v.case5.v0 = v0;
    return x;
}
__device__ US4 US4_6(static_array<Tuple0,5l> v0) { // Straight_Flush
    US4 x;
    x.tag = 6;
    x.v.case6.v0 = v0;
    return x;
}
__device__ US4 US4_7(static_array<Tuple0,5l> v0) { // Triple
    US4 x;
    x.tag = 7;
    x.v.case7.v0 = v0;
    return x;
}
__device__ US4 US4_8(static_array<Tuple0,5l> v0) { // Two_Pair
    US4 x;
    x.tag = 8;
    x.v.case8.v0 = v0;
    return x;
}
__device__ US0 US0_0(static_array_list<Tuple0,5l,long> v0) { // CommunityCardsAre
    US0 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US0 US0_1(long v0, long v1) { // Fold
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US0 US0_2(long v0, US3 v1) { // PlayerAction
    US0 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US0 US0_3(long v0, static_array<Tuple0,2l> v1) { // PlayerGotCards
    US0 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1;
    return x;
}
__device__ US0 US0_4(long v0, static_array<US4,2l> v1, long v2) { // Showdown
    US0 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2;
    return x;
}
__device__ US7 US7_0(static_array<Tuple0,3l> v0) { // Flop
    US7 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US7 US7_1() { // Preflop
    US7 x;
    x.tag = 1;
    return x;
}
__device__ US7 US7_2(static_array<Tuple0,5l> v0) { // River
    US7 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US7 US7_3(static_array<Tuple0,4l> v0) { // Turn
    US7 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US6 US6_0(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_Flop
    US6 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5; x.v.case0.v6 = v6;
    return x;
}
__device__ US6 US6_1(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_Fold
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US6 US6_2() { // G_Preflop
    US6 x;
    x.tag = 2;
    return x;
}
__device__ US6 US6_3(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_River
    US6 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US6 US6_4(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_Round
    US6 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5; x.v.case4.v6 = v6;
    return x;
}
__device__ US6 US6_5(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6, US3 v7) { // G_Round'
    US6 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6; x.v.case5.v7 = v7;
    return x;
}
__device__ US6 US6_6(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_Showdown
    US6 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5; x.v.case6.v6 = v6;
    return x;
}
__device__ US6 US6_7(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // G_Turn
    US6 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5; x.v.case7.v6 = v6;
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
__device__ US8 US8_0() { // Computer
    US8 x;
    x.tag = 0;
    return x;
}
__device__ US8 US8_1() { // Human
    US8 x;
    x.tag = 1;
    return x;
}
__device__ US9 US9_0() { // GameNotStarted
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // GameOver
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5; x.v.case1.v6 = v6;
    return x;
}
__device__ US9 US9_2(long v0, bool v1, static_array<static_array<Tuple0,2l>,2l> v2, long v3, static_array<long,2l> v4, static_array<long,2l> v5, US7 v6) { // WaitingForActionFromPlayerId
    US9 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5; x.v.case2.v6 = v6;
    return x;
}
__device__ unsigned long long f_2(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+0ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_3(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+8ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ inline bool while_method_0(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ long f_5(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ void f_8(unsigned char * v0){
    return ;
}
__device__ long f_9(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple0 f_7(unsigned char * v0){
    long v1;
    v1 = f_5(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    US1 v17;
    switch (v1) {
        case 0: {
            f_8(v2);
            v17 = US1_0();
            break;
        }
        case 1: {
            f_8(v2);
            v17 = US1_1();
            break;
        }
        case 2: {
            f_8(v2);
            v17 = US1_2();
            break;
        }
        case 3: {
            f_8(v2);
            v17 = US1_3();
            break;
        }
        case 4: {
            f_8(v2);
            v17 = US1_4();
            break;
        }
        case 5: {
            f_8(v2);
            v17 = US1_5();
            break;
        }
        case 6: {
            f_8(v2);
            v17 = US1_6();
            break;
        }
        case 7: {
            f_8(v2);
            v17 = US1_7();
            break;
        }
        case 8: {
            f_8(v2);
            v17 = US1_8();
            break;
        }
        case 9: {
            f_8(v2);
            v17 = US1_9();
            break;
        }
        case 10: {
            f_8(v2);
            v17 = US1_10();
            break;
        }
        case 11: {
            f_8(v2);
            v17 = US1_11();
            break;
        }
        case 12: {
            f_8(v2);
            v17 = US1_12();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v18;
    v18 = f_9(v0);
    unsigned char * v19;
    v19 = (unsigned char *)(v0+8ull);
    US2 v25;
    switch (v18) {
        case 0: {
            f_8(v19);
            v25 = US2_0();
            break;
        }
        case 1: {
            f_8(v19);
            v25 = US2_1();
            break;
        }
        case 2: {
            f_8(v19);
            v25 = US2_2();
            break;
        }
        case 3: {
            f_8(v19);
            v25 = US2_3();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple0(v17, v25);
}
__device__ static_array_list<Tuple0,5l,long> f_6(unsigned char * v0){
    static_array_list<Tuple0,5l,long> v1;
    v1.length = 0;
    long v2;
    v2 = f_5(v0);
    v1.length = v2;
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US1 v10; US2 v11;
        Tuple0 tmp0 = f_7(v9);
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
__device__ Tuple2 f_10(unsigned char * v0){
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
__device__ Tuple3 f_11(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_9(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US3 v10;
    switch (v3) {
        case 0: {
            f_8(v4);
            v10 = US3_0();
            break;
        }
        case 1: {
            f_8(v4);
            v10 = US3_1();
            break;
        }
        case 2: {
            long v8;
            v8 = f_5(v4);
            v10 = US3_2(v8);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple3(v2, v10);
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ Tuple4 f_12(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<Tuple0,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 8ull;
        unsigned long long v8;
        v8 = 8ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US1 v10; US2 v11;
        Tuple0 tmp3 = f_7(v9);
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
__device__ static_array<Tuple0,5l> f_15(unsigned char * v0){
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
        US1 v7; US2 v8;
        Tuple0 tmp5 = f_7(v6);
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
__device__ US4 f_14(unsigned char * v0){
    long v1;
    v1 = f_5(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array<Tuple0,5l> v4;
            v4 = f_15(v2);
            return US4_0(v4);
            break;
        }
        case 1: {
            static_array<Tuple0,5l> v6;
            v6 = f_15(v2);
            return US4_1(v6);
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v8;
            v8 = f_15(v2);
            return US4_2(v8);
            break;
        }
        case 3: {
            static_array<Tuple0,5l> v10;
            v10 = f_15(v2);
            return US4_3(v10);
            break;
        }
        case 4: {
            static_array<Tuple0,5l> v12;
            v12 = f_15(v2);
            return US4_4(v12);
            break;
        }
        case 5: {
            static_array<Tuple0,5l> v14;
            v14 = f_15(v2);
            return US4_5(v14);
            break;
        }
        case 6: {
            static_array<Tuple0,5l> v16;
            v16 = f_15(v2);
            return US4_6(v16);
            break;
        }
        case 7: {
            static_array<Tuple0,5l> v18;
            v18 = f_15(v2);
            return US4_7(v18);
            break;
        }
        case 8: {
            static_array<Tuple0,5l> v20;
            v20 = f_15(v2);
            return US4_8(v20);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ Tuple5 f_13(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<US4,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 64ull;
        unsigned long long v8;
        v8 = 16ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        US4 v10;
        v10 = f_14(v9);
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
__device__ US0 f_4(unsigned char * v0){
    long v1;
    v1 = f_5(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array_list<Tuple0,5l,long> v4;
            v4 = f_6(v2);
            return US0_0(v4);
            break;
        }
        case 1: {
            long v6; long v7;
            Tuple2 tmp1 = f_10(v2);
            v6 = tmp1.v0; v7 = tmp1.v1;
            return US0_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US3 v10;
            Tuple3 tmp2 = f_11(v2);
            v9 = tmp2.v0; v10 = tmp2.v1;
            return US0_2(v9, v10);
            break;
        }
        case 3: {
            long v12; static_array<Tuple0,2l> v13;
            Tuple4 tmp4 = f_12(v2);
            v12 = tmp4.v0; v13 = tmp4.v1;
            return US0_3(v12, v13);
            break;
        }
        case 4: {
            long v15; static_array<US4,2l> v16; long v17;
            Tuple5 tmp6 = f_13(v2);
            v15 = tmp6.v0; v16 = tmp6.v1; v17 = tmp6.v2;
            return US0_4(v15, v16, v17);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_16(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+22544ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ static_array<Tuple0,2l> f_19(unsigned char * v0){
    static_array<Tuple0,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_1(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned long long v5;
        v5 = v4 * 8ull;
        unsigned char * v6;
        v6 = (unsigned char *)(v0+v5);
        US1 v7; US2 v8;
        Tuple0 tmp7 = f_7(v6);
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
__device__ long f_20(unsigned char * v0){
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
__device__ static_array<Tuple0,3l> f_21(unsigned char * v0){
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
        US1 v7; US2 v8;
        Tuple0 tmp8 = f_7(v6);
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
__device__ static_array<Tuple0,4l> f_22(unsigned char * v0){
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
        US1 v7; US2 v8;
        Tuple0 tmp9 = f_7(v6);
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
__device__ Tuple6 f_18(unsigned char * v0){
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
    while (while_method_1(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 16ull;
        unsigned long long v10;
        v10 = 16ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<Tuple0,2l> v12;
        v12 = f_19(v11);
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
    while (while_method_1(v20)){
        unsigned long long v22;
        v22 = (unsigned long long)v20;
        unsigned long long v23;
        v23 = v22 * 4ull;
        unsigned long long v24;
        v24 = 52ull + v23;
        unsigned char * v25;
        v25 = (unsigned char *)(v0+v24);
        long v26;
        v26 = f_5(v25);
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
    while (while_method_1(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 60ull + v35;
        unsigned char * v37;
        v37 = (unsigned char *)(v0+v36);
        long v38;
        v38 = f_5(v37);
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
    v43 = f_20(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+80ull);
    US7 v53;
    switch (v43) {
        case 0: {
            static_array<Tuple0,3l> v46;
            v46 = f_21(v44);
            v53 = US7_0(v46);
            break;
        }
        case 1: {
            f_8(v44);
            v53 = US7_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v49;
            v49 = f_15(v44);
            v53 = US7_2(v49);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v51;
            v51 = f_22(v44);
            v53 = US7_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple6(v2, v4, v5, v18, v19, v31, v53);
}
__device__ long f_24(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+128ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple7 f_23(unsigned char * v0){
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
    while (while_method_1(v6)){
        unsigned long long v8;
        v8 = (unsigned long long)v6;
        unsigned long long v9;
        v9 = v8 * 16ull;
        unsigned long long v10;
        v10 = 16ull + v9;
        unsigned char * v11;
        v11 = (unsigned char *)(v0+v10);
        static_array<Tuple0,2l> v12;
        v12 = f_19(v11);
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
    while (while_method_1(v20)){
        unsigned long long v22;
        v22 = (unsigned long long)v20;
        unsigned long long v23;
        v23 = v22 * 4ull;
        unsigned long long v24;
        v24 = 52ull + v23;
        unsigned char * v25;
        v25 = (unsigned char *)(v0+v24);
        long v26;
        v26 = f_5(v25);
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
    while (while_method_1(v32)){
        unsigned long long v34;
        v34 = (unsigned long long)v32;
        unsigned long long v35;
        v35 = v34 * 4ull;
        unsigned long long v36;
        v36 = 60ull + v35;
        unsigned char * v37;
        v37 = (unsigned char *)(v0+v36);
        long v38;
        v38 = f_5(v37);
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
    v43 = f_20(v0);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+80ull);
    US7 v53;
    switch (v43) {
        case 0: {
            static_array<Tuple0,3l> v46;
            v46 = f_21(v44);
            v53 = US7_0(v46);
            break;
        }
        case 1: {
            f_8(v44);
            v53 = US7_1();
            break;
        }
        case 2: {
            static_array<Tuple0,5l> v49;
            v49 = f_15(v44);
            v53 = US7_2(v49);
            break;
        }
        case 3: {
            static_array<Tuple0,4l> v51;
            v51 = f_22(v44);
            v53 = US7_3(v51);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v54;
    v54 = f_24(v0);
    unsigned char * v55;
    v55 = (unsigned char *)(v0+132ull);
    US3 v61;
    switch (v54) {
        case 0: {
            f_8(v55);
            v61 = US3_0();
            break;
        }
        case 1: {
            f_8(v55);
            v61 = US3_1();
            break;
        }
        case 2: {
            long v59;
            v59 = f_5(v55);
            v61 = US3_2(v59);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple7(v2, v4, v5, v18, v19, v31, v53, v61);
}
__device__ US6 f_17(unsigned char * v0){
    long v1;
    v1 = f_5(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; bool v5; static_array<static_array<Tuple0,2l>,2l> v6; long v7; static_array<long,2l> v8; static_array<long,2l> v9; US7 v10;
            Tuple6 tmp10 = f_18(v2);
            v4 = tmp10.v0; v5 = tmp10.v1; v6 = tmp10.v2; v7 = tmp10.v3; v8 = tmp10.v4; v9 = tmp10.v5; v10 = tmp10.v6;
            return US6_0(v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: {
            long v12; bool v13; static_array<static_array<Tuple0,2l>,2l> v14; long v15; static_array<long,2l> v16; static_array<long,2l> v17; US7 v18;
            Tuple6 tmp11 = f_18(v2);
            v12 = tmp11.v0; v13 = tmp11.v1; v14 = tmp11.v2; v15 = tmp11.v3; v16 = tmp11.v4; v17 = tmp11.v5; v18 = tmp11.v6;
            return US6_1(v12, v13, v14, v15, v16, v17, v18);
            break;
        }
        case 2: {
            f_8(v2);
            return US6_2();
            break;
        }
        case 3: {
            long v21; bool v22; static_array<static_array<Tuple0,2l>,2l> v23; long v24; static_array<long,2l> v25; static_array<long,2l> v26; US7 v27;
            Tuple6 tmp12 = f_18(v2);
            v21 = tmp12.v0; v22 = tmp12.v1; v23 = tmp12.v2; v24 = tmp12.v3; v25 = tmp12.v4; v26 = tmp12.v5; v27 = tmp12.v6;
            return US6_3(v21, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 4: {
            long v29; bool v30; static_array<static_array<Tuple0,2l>,2l> v31; long v32; static_array<long,2l> v33; static_array<long,2l> v34; US7 v35;
            Tuple6 tmp13 = f_18(v2);
            v29 = tmp13.v0; v30 = tmp13.v1; v31 = tmp13.v2; v32 = tmp13.v3; v33 = tmp13.v4; v34 = tmp13.v5; v35 = tmp13.v6;
            return US6_4(v29, v30, v31, v32, v33, v34, v35);
            break;
        }
        case 5: {
            long v37; bool v38; static_array<static_array<Tuple0,2l>,2l> v39; long v40; static_array<long,2l> v41; static_array<long,2l> v42; US7 v43; US3 v44;
            Tuple7 tmp14 = f_23(v2);
            v37 = tmp14.v0; v38 = tmp14.v1; v39 = tmp14.v2; v40 = tmp14.v3; v41 = tmp14.v4; v42 = tmp14.v5; v43 = tmp14.v6; v44 = tmp14.v7;
            return US6_5(v37, v38, v39, v40, v41, v42, v43, v44);
            break;
        }
        case 6: {
            long v46; bool v47; static_array<static_array<Tuple0,2l>,2l> v48; long v49; static_array<long,2l> v50; static_array<long,2l> v51; US7 v52;
            Tuple6 tmp15 = f_18(v2);
            v46 = tmp15.v0; v47 = tmp15.v1; v48 = tmp15.v2; v49 = tmp15.v3; v50 = tmp15.v4; v51 = tmp15.v5; v52 = tmp15.v6;
            return US6_6(v46, v47, v48, v49, v50, v51, v52);
            break;
        }
        case 7: {
            long v54; bool v55; static_array<static_array<Tuple0,2l>,2l> v56; long v57; static_array<long,2l> v58; static_array<long,2l> v59; US7 v60;
            Tuple6 tmp16 = f_18(v2);
            v54 = tmp16.v0; v55 = tmp16.v1; v56 = tmp16.v2; v57 = tmp16.v3; v58 = tmp16.v4; v59 = tmp16.v5; v60 = tmp16.v6;
            return US6_7(v54, v55, v56, v57, v58, v59, v60);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ US8 f_25(unsigned char * v0){
    long v1;
    v1 = f_5(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_8(v2);
            return US8_0();
            break;
        }
        case 1: {
            f_8(v2);
            return US8_1();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_26(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+22728ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple1 f_1(unsigned char * v0){
    unsigned long long v1;
    v1 = f_2(v0);
    static_array_list<US0,128l,long> v2;
    v2.length = 0;
    long v3;
    v3 = f_3(v0);
    v2.length = v3;
    long v4;
    v4 = v2.length;
    long v5;
    v5 = 0l;
    while (while_method_0(v4, v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 176ull;
        unsigned long long v9;
        v9 = 16ull + v8;
        unsigned char * v10;
        v10 = (unsigned char *)(v0+v9);
        US0 v11;
        v11 = f_4(v10);
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
    v17 = f_16(v0);
    unsigned char * v18;
    v18 = (unsigned char *)(v0+22560ull);
    US5 v23;
    switch (v17) {
        case 0: {
            f_8(v18);
            v23 = US5_0();
            break;
        }
        case 1: {
            US6 v21;
            v21 = f_17(v18);
            v23 = US5_1(v21);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    static_array<US8,2l> v24;
    long v25;
    v25 = 0l;
    while (while_method_1(v25)){
        unsigned long long v27;
        v27 = (unsigned long long)v25;
        unsigned long long v28;
        v28 = v27 * 4ull;
        unsigned long long v29;
        v29 = 22720ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        US8 v31;
        v31 = f_25(v30);
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
    v36 = f_26(v0);
    unsigned char * v37;
    v37 = (unsigned char *)(v0+22736ull);
    US9 v56;
    switch (v36) {
        case 0: {
            f_8(v37);
            v56 = US9_0();
            break;
        }
        case 1: {
            long v40; bool v41; static_array<static_array<Tuple0,2l>,2l> v42; long v43; static_array<long,2l> v44; static_array<long,2l> v45; US7 v46;
            Tuple6 tmp17 = f_18(v37);
            v40 = tmp17.v0; v41 = tmp17.v1; v42 = tmp17.v2; v43 = tmp17.v3; v44 = tmp17.v4; v45 = tmp17.v5; v46 = tmp17.v6;
            v56 = US9_1(v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 2: {
            long v48; bool v49; static_array<static_array<Tuple0,2l>,2l> v50; long v51; static_array<long,2l> v52; static_array<long,2l> v53; US7 v54;
            Tuple6 tmp18 = f_18(v37);
            v48 = tmp18.v0; v49 = tmp18.v1; v50 = tmp18.v2; v51 = tmp18.v3; v52 = tmp18.v4; v53 = tmp18.v5; v54 = tmp18.v6;
            v56 = US9_2(v48, v49, v50, v51, v52, v53, v54);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v1, v2, v23, v24, v56);
}
__device__ void f_28(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_29(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_31(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_34(unsigned char * v0){
    return ;
}
__device__ void f_35(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_33(unsigned char * v0, US1 v1, US2 v2){
    long v3;
    v3 = v1.tag;
    f_31(v0, v3);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Ace
            f_34(v4);
            break;
        }
        case 1: { // Eight
            f_34(v4);
            break;
        }
        case 2: { // Five
            f_34(v4);
            break;
        }
        case 3: { // Four
            f_34(v4);
            break;
        }
        case 4: { // Jack
            f_34(v4);
            break;
        }
        case 5: { // King
            f_34(v4);
            break;
        }
        case 6: { // Nine
            f_34(v4);
            break;
        }
        case 7: { // Queen
            f_34(v4);
            break;
        }
        case 8: { // Seven
            f_34(v4);
            break;
        }
        case 9: { // Six
            f_34(v4);
            break;
        }
        case 10: { // Ten
            f_34(v4);
            break;
        }
        case 11: { // Three
            f_34(v4);
            break;
        }
        case 12: { // Two
            f_34(v4);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v5;
    v5 = v2.tag;
    f_35(v0, v5);
    unsigned char * v6;
    v6 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // Clubs
            return f_34(v6);
            break;
        }
        case 1: { // Diamonds
            return f_34(v6);
            break;
        }
        case 2: { // Hearts
            return f_34(v6);
            break;
        }
        case 3: { // Spades
            return f_34(v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_32(unsigned char * v0, static_array_list<Tuple0,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_31(v0, v2);
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
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
        US1 v15; US2 v16;
        Tuple0 tmp20 = v1.v[v4];
        v15 = tmp20.v0; v16 = tmp20.v1;
        f_33(v9, v15, v16);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_36(unsigned char * v0, long v1, long v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long * v4;
    v4 = (long *)(v0+4ull);
    v4[0l] = v2;
    return ;
}
__device__ void f_37(unsigned char * v0, long v1, US3 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_35(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_Call
            return f_34(v5);
            break;
        }
        case 1: { // A_Fold
            return f_34(v5);
            break;
        }
        case 2: { // A_Raise
            long v6 = v2.v.case2.v0;
            return f_31(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_38(unsigned char * v0, long v1, static_array<Tuple0,2l> v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
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
        US1 v14; US2 v15;
        Tuple0 tmp21 = v2.v[v4];
        v14 = tmp21.v0; v15 = tmp21.v1;
        f_33(v9, v14, v15);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_41(unsigned char * v0, static_array<Tuple0,5l> v1){
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
        US1 v11; US2 v12;
        Tuple0 tmp22 = v1.v[v2];
        v11 = tmp22.v0; v12 = tmp22.v1;
        f_33(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_40(unsigned char * v0, US4 v1){
    long v2;
    v2 = v1.tag;
    f_31(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // Flush
            static_array<Tuple0,5l> v4 = v1.v.case0.v0;
            return f_41(v3, v4);
            break;
        }
        case 1: { // Full_House
            static_array<Tuple0,5l> v5 = v1.v.case1.v0;
            return f_41(v3, v5);
            break;
        }
        case 2: { // High_Card
            static_array<Tuple0,5l> v6 = v1.v.case2.v0;
            return f_41(v3, v6);
            break;
        }
        case 3: { // Pair
            static_array<Tuple0,5l> v7 = v1.v.case3.v0;
            return f_41(v3, v7);
            break;
        }
        case 4: { // Quads
            static_array<Tuple0,5l> v8 = v1.v.case4.v0;
            return f_41(v3, v8);
            break;
        }
        case 5: { // Straight
            static_array<Tuple0,5l> v9 = v1.v.case5.v0;
            return f_41(v3, v9);
            break;
        }
        case 6: { // Straight_Flush
            static_array<Tuple0,5l> v10 = v1.v.case6.v0;
            return f_41(v3, v10);
            break;
        }
        case 7: { // Triple
            static_array<Tuple0,5l> v11 = v1.v.case7.v0;
            return f_41(v3, v11);
            break;
        }
        case 8: { // Two_Pair
            static_array<Tuple0,5l> v12 = v1.v.case8.v0;
            return f_41(v3, v12);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_39(unsigned char * v0, long v1, static_array<US4,2l> v2, long v3){
    long * v4;
    v4 = (long *)(v0+0ull);
    v4[0l] = v1;
    long v5;
    v5 = 0l;
    while (while_method_1(v5)){
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
        US4 v15;
        v15 = v2.v[v5];
        f_40(v10, v15);
        v5 += 1l ;
    }
    long * v16;
    v16 = (long *)(v0+144ull);
    v16[0l] = v3;
    return ;
}
__device__ void f_30(unsigned char * v0, US0 v1){
    long v2;
    v2 = v1.tag;
    f_31(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<Tuple0,5l,long> v4 = v1.v.case0.v0;
            return f_32(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_36(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US3 v8 = v1.v.case2.v1;
            return f_37(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<Tuple0,2l> v10 = v1.v.case3.v1;
            return f_38(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<US4,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_39(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_42(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22544ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_45(unsigned char * v0, static_array<Tuple0,2l> v1){
    long v2;
    v2 = 0l;
    while (while_method_1(v2)){
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
        US1 v11; US2 v12;
        Tuple0 tmp23 = v1.v[v2];
        v11 = tmp23.v0; v12 = tmp23.v1;
        f_33(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_46(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+68ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_47(unsigned char * v0, static_array<Tuple0,3l> v1){
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
        US1 v11; US2 v12;
        Tuple0 tmp24 = v1.v[v2];
        v11 = tmp24.v0; v12 = tmp24.v1;
        f_33(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_48(unsigned char * v0, static_array<Tuple0,4l> v1){
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
        US1 v11; US2 v12;
        Tuple0 tmp25 = v1.v[v2];
        v11 = tmp25.v0; v12 = tmp25.v1;
        f_33(v6, v11, v12);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_44(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US7 v7){
    long * v8;
    v8 = (long *)(v0+0ull);
    v8[0l] = v1;
    bool * v9;
    v9 = (bool *)(v0+4ull);
    v9[0l] = v2;
    long v10;
    v10 = 0l;
    while (while_method_1(v10)){
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
        f_45(v15, v20);
        v10 += 1l ;
    }
    long * v21;
    v21 = (long *)(v0+48ull);
    v21[0l] = v4;
    long v22;
    v22 = 0l;
    while (while_method_1(v22)){
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
        f_31(v27, v32);
        v22 += 1l ;
    }
    long v33;
    v33 = 0l;
    while (while_method_1(v33)){
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
        f_31(v38, v43);
        v33 += 1l ;
    }
    long v44;
    v44 = v7.tag;
    f_46(v0, v44);
    unsigned char * v45;
    v45 = (unsigned char *)(v0+80ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v46 = v7.v.case0.v0;
            return f_47(v45, v46);
            break;
        }
        case 1: { // Preflop
            return f_34(v45);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v47 = v7.v.case2.v0;
            return f_41(v45, v47);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v48 = v7.v.case3.v0;
            return f_48(v45, v48);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_50(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+128ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_49(unsigned char * v0, long v1, bool v2, static_array<static_array<Tuple0,2l>,2l> v3, long v4, static_array<long,2l> v5, static_array<long,2l> v6, US7 v7, US3 v8){
    long * v9;
    v9 = (long *)(v0+0ull);
    v9[0l] = v1;
    bool * v10;
    v10 = (bool *)(v0+4ull);
    v10[0l] = v2;
    long v11;
    v11 = 0l;
    while (while_method_1(v11)){
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
        f_45(v16, v21);
        v11 += 1l ;
    }
    long * v22;
    v22 = (long *)(v0+48ull);
    v22[0l] = v4;
    long v23;
    v23 = 0l;
    while (while_method_1(v23)){
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
        f_31(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = 0l;
    while (while_method_1(v34)){
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
        f_31(v39, v44);
        v34 += 1l ;
    }
    long v45;
    v45 = v7.tag;
    f_46(v0, v45);
    unsigned char * v46;
    v46 = (unsigned char *)(v0+80ull);
    switch (v7.tag) {
        case 0: { // Flop
            static_array<Tuple0,3l> v47 = v7.v.case0.v0;
            f_47(v46, v47);
            break;
        }
        case 1: { // Preflop
            f_34(v46);
            break;
        }
        case 2: { // River
            static_array<Tuple0,5l> v48 = v7.v.case2.v0;
            f_41(v46, v48);
            break;
        }
        case 3: { // Turn
            static_array<Tuple0,4l> v49 = v7.v.case3.v0;
            f_48(v46, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v50;
    v50 = v8.tag;
    f_50(v0, v50);
    unsigned char * v51;
    v51 = (unsigned char *)(v0+132ull);
    switch (v8.tag) {
        case 0: { // A_Call
            return f_34(v51);
            break;
        }
        case 1: { // A_Fold
            return f_34(v51);
            break;
        }
        case 2: { // A_Raise
            long v52 = v8.v.case2.v0;
            return f_31(v51, v52);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_43(unsigned char * v0, US6 v1){
    long v2;
    v2 = v1.tag;
    f_31(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; bool v5 = v1.v.case0.v1; static_array<static_array<Tuple0,2l>,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; static_array<long,2l> v9 = v1.v.case0.v5; US7 v10 = v1.v.case0.v6;
            return f_44(v3, v4, v5, v6, v7, v8, v9, v10);
            break;
        }
        case 1: { // G_Fold
            long v11 = v1.v.case1.v0; bool v12 = v1.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v13 = v1.v.case1.v2; long v14 = v1.v.case1.v3; static_array<long,2l> v15 = v1.v.case1.v4; static_array<long,2l> v16 = v1.v.case1.v5; US7 v17 = v1.v.case1.v6;
            return f_44(v3, v11, v12, v13, v14, v15, v16, v17);
            break;
        }
        case 2: { // G_Preflop
            return f_34(v3);
            break;
        }
        case 3: { // G_River
            long v18 = v1.v.case3.v0; bool v19 = v1.v.case3.v1; static_array<static_array<Tuple0,2l>,2l> v20 = v1.v.case3.v2; long v21 = v1.v.case3.v3; static_array<long,2l> v22 = v1.v.case3.v4; static_array<long,2l> v23 = v1.v.case3.v5; US7 v24 = v1.v.case3.v6;
            return f_44(v3, v18, v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: { // G_Round
            long v25 = v1.v.case4.v0; bool v26 = v1.v.case4.v1; static_array<static_array<Tuple0,2l>,2l> v27 = v1.v.case4.v2; long v28 = v1.v.case4.v3; static_array<long,2l> v29 = v1.v.case4.v4; static_array<long,2l> v30 = v1.v.case4.v5; US7 v31 = v1.v.case4.v6;
            return f_44(v3, v25, v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: { // G_Round'
            long v32 = v1.v.case5.v0; bool v33 = v1.v.case5.v1; static_array<static_array<Tuple0,2l>,2l> v34 = v1.v.case5.v2; long v35 = v1.v.case5.v3; static_array<long,2l> v36 = v1.v.case5.v4; static_array<long,2l> v37 = v1.v.case5.v5; US7 v38 = v1.v.case5.v6; US3 v39 = v1.v.case5.v7;
            return f_49(v3, v32, v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: { // G_Showdown
            long v40 = v1.v.case6.v0; bool v41 = v1.v.case6.v1; static_array<static_array<Tuple0,2l>,2l> v42 = v1.v.case6.v2; long v43 = v1.v.case6.v3; static_array<long,2l> v44 = v1.v.case6.v4; static_array<long,2l> v45 = v1.v.case6.v5; US7 v46 = v1.v.case6.v6;
            return f_44(v3, v40, v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: { // G_Turn
            long v47 = v1.v.case7.v0; bool v48 = v1.v.case7.v1; static_array<static_array<Tuple0,2l>,2l> v49 = v1.v.case7.v2; long v50 = v1.v.case7.v3; static_array<long,2l> v51 = v1.v.case7.v4; static_array<long,2l> v52 = v1.v.case7.v5; US7 v53 = v1.v.case7.v6;
            return f_44(v3, v47, v48, v49, v50, v51, v52, v53);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_51(unsigned char * v0, US8 v1){
    long v2;
    v2 = v1.tag;
    f_31(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_34(v3);
            break;
        }
        case 1: { // Human
            return f_34(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_52(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22728ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_27(unsigned char * v0, unsigned long long v1, static_array_list<US0,128l,long> v2, US5 v3, static_array<US8,2l> v4, US9 v5){
    f_28(v0, v1);
    long v6;
    v6 = v2.length;
    f_29(v0, v6);
    long v7;
    v7 = v2.length;
    long v8;
    v8 = 0l;
    while (while_method_0(v7, v8)){
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
        US0 v19;
        v19 = v2.v[v8];
        f_30(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_42(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+22560ull);
    switch (v3.tag) {
        case 0: { // None
            f_34(v21);
            break;
        }
        case 1: { // Some
            US6 v22 = v3.v.case1.v0;
            f_43(v21, v22);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v23;
    v23 = 0l;
    while (while_method_1(v23)){
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
        US8 v33;
        v33 = v4.v[v23];
        f_51(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_52(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+22736ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_34(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; bool v37 = v5.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; static_array<long,2l> v41 = v5.v.case1.v5; US7 v42 = v5.v.case1.v6;
            return f_44(v35, v36, v37, v38, v39, v40, v41, v42);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v43 = v5.v.case2.v0; bool v44 = v5.v.case2.v1; static_array<static_array<Tuple0,2l>,2l> v45 = v5.v.case2.v2; long v46 = v5.v.case2.v3; static_array<long,2l> v47 = v5.v.case2.v4; static_array<long,2l> v48 = v5.v.case2.v5; US7 v49 = v5.v.case2.v6;
            return f_44(v35, v43, v44, v45, v46, v47, v48, v49);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_54(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+22552ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_53(unsigned char * v0, static_array_list<US0,128l,long> v1, static_array<US8,2l> v2, US9 v3){
    long v4;
    v4 = v1.length;
    f_31(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_0(v5, v6)){
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
        US0 v17;
        v17 = v1.v[v6];
        f_30(v11, v17);
        v6 += 1l ;
    }
    long v18;
    v18 = 0l;
    while (while_method_1(v18)){
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
        US8 v28;
        v28 = v2.v[v18];
        f_51(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_54(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+22560ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_34(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; bool v32 = v3.v.case1.v1; static_array<static_array<Tuple0,2l>,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; static_array<long,2l> v36 = v3.v.case1.v5; US7 v37 = v3.v.case1.v6;
            return f_44(v30, v31, v32, v33, v34, v35, v36, v37);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v38 = v3.v.case2.v0; bool v39 = v3.v.case2.v1; static_array<static_array<Tuple0,2l>,2l> v40 = v3.v.case2.v2; long v41 = v3.v.case2.v3; static_array<long,2l> v42 = v3.v.case2.v4; static_array<long,2l> v43 = v3.v.case2.v5; US7 v44 = v3.v.case2.v6;
            return f_44(v30, v38, v39, v40, v41, v42, v43, v44);
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
        unsigned long long v9; static_array_list<US0,128l,long> v10; US5 v11; static_array<US8,2l> v12; US9 v13;
        Tuple1 tmp19 = f_1(v0);
        v9 = tmp19.v0; v10 = tmp19.v1; v11 = tmp19.v2; v12 = tmp19.v3; v13 = tmp19.v4;
        f_27(v0, v9, v10, v11, v12, v13);
        return f_53(v2, v10, v12, v13);
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
