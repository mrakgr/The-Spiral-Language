kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
struct US1;
struct Tuple0;
struct US0;
struct US4;
struct US3;
struct US2;
struct US5;   
struct US6;
struct Tuple1;
__device__ unsigned long long f_1(unsigned char * v0);
__device__ long f_2(unsigned char * v0);
__device__ long f_4(unsigned char * v0);
__device__ unsigned char f_7(unsigned char * v0);
__device__ unsigned char f_6(unsigned char * v0);
__device__ static_array_list<unsigned char,5l,long> f_5(unsigned char * v0);
struct Tuple2;
__device__ Tuple2 f_8(unsigned char * v0);
struct Tuple3;
__device__ long f_10(unsigned char * v0);
__device__ void f_11(unsigned char * v0);
__device__ Tuple3 f_9(unsigned char * v0);
struct Tuple4;
__device__ Tuple4 f_12(unsigned char * v0);
struct Tuple5;
__device__ Tuple0 f_15(unsigned char * v0);
__device__ Tuple0 f_14(unsigned char * v0);
__device__ Tuple5 f_13(unsigned char * v0);
__device__ US0 f_3(unsigned char * v0);
__device__ long f_16(unsigned char * v0);
struct Tuple6;
__device__ static_array<unsigned char,2l> f_19(unsigned char * v0);
__device__ long f_20(unsigned char * v0);
__device__ static_array<unsigned char,3l> f_21(unsigned char * v0);
__device__ static_array<unsigned char,5l> f_22(unsigned char * v0);
__device__ static_array<unsigned char,4l> f_23(unsigned char * v0);
__device__ Tuple6 f_18(unsigned char * v0);
struct Tuple7;
__device__ long f_25(unsigned char * v0);
__device__ Tuple7 f_24(unsigned char * v0);
__device__ US3 f_17(unsigned char * v0);
__device__ US5 f_26(unsigned char * v0);
__device__ long f_27(unsigned char * v0);
__device__ Tuple1 f_0(unsigned char * v0);
__device__ void f_29(unsigned char * v0, unsigned long long v1);
__device__ void f_30(unsigned char * v0, long v1);
__device__ void f_32(unsigned char * v0, long v1);
__device__ void f_35(unsigned char * v0, unsigned char v1);
__device__ void f_34(unsigned char * v0, unsigned char v1);
__device__ void f_33(unsigned char * v0, static_array_list<unsigned char,5l,long> v1);
__device__ void f_36(unsigned char * v0, long v1, long v2);
__device__ void f_38(unsigned char * v0, long v1);
__device__ void f_39(unsigned char * v0);
__device__ void f_37(unsigned char * v0, long v1, US1 v2);
__device__ void f_40(unsigned char * v0, long v1, static_array<unsigned char,2l> v2);
__device__ void f_43(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_42(unsigned char * v0, static_array<unsigned char,5l> v1, char v2);
__device__ void f_41(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3);
__device__ void f_31(unsigned char * v0, US0 v1);
__device__ void f_44(unsigned char * v0, long v1);
__device__ void f_47(unsigned char * v0, static_array<unsigned char,2l> v1);
__device__ void f_48(unsigned char * v0, long v1);
__device__ void f_49(unsigned char * v0, static_array<unsigned char,3l> v1);
__device__ void f_50(unsigned char * v0, static_array<unsigned char,5l> v1);
__device__ void f_51(unsigned char * v0, static_array<unsigned char,4l> v1);
__device__ void f_46(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US4 v6);
__device__ void f_53(unsigned char * v0, long v1);
__device__ void f_52(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US4 v6, US1 v7);
__device__ void f_45(unsigned char * v0, US3 v1);
__device__ void f_54(unsigned char * v0, US5 v1);
__device__ void f_55(unsigned char * v0, long v1);
__device__ void f_28(unsigned char * v0, unsigned long long v1, static_array_list<US0,128l,long> v2, US2 v3, static_array<US5,2l> v4, US6 v5);
__device__ void f_57(unsigned char * v0, long v1);
__device__ void f_56(unsigned char * v0, static_array_list<US0,128l,long> v1, static_array<US5,2l> v2, US6 v3);
struct US1 {
    union {
        struct {
            long v0;
        } case3; // A_Raise
    } v;
    unsigned long tag : 3;
};
struct Tuple0 {
    static_array<unsigned char,5l> v0;
    char v1;
    __device__ Tuple0(static_array<unsigned char,5l> t0, char t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct US0 {
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
struct US4 {
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
struct US3 {
    union {
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case0; // G_Flop
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case1; // G_Fold
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case3; // G_River
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case4; // G_Round
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            US1 v6;
            long v0;
            long v3;
        } case5; // G_Round'
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case6; // G_Showdown
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case7; // G_Turn
    } v;
    unsigned long tag : 4;
};
struct US2 {
    union {
        struct {
            US3 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US5 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US6 {
    union {
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case1; // GameOver
        struct {
            static_array<static_array<unsigned char,2l>,2l> v1;
            static_array<long,2l> v2;
            static_array<long,2l> v4;
            US4 v5;
            long v0;
            long v3;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple1 {
    unsigned long long v0;
    static_array_list<US0,128l,long> v1;
    US2 v2;
    static_array<US5,2l> v3;
    US6 v4;
    __device__ Tuple1(unsigned long long t0, static_array_list<US0,128l,long> t1, US2 t2, static_array<US5,2l> t3, US6 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
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
    US4 v5;
    long v0;
    long v3;
    __device__ Tuple6(long t0, static_array<static_array<unsigned char,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US4 t5) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5) {}
    __device__ Tuple6() = default;
};
struct Tuple7 {
    static_array<static_array<unsigned char,2l>,2l> v1;
    static_array<long,2l> v2;
    static_array<long,2l> v4;
    US4 v5;
    US1 v6;
    long v0;
    long v3;
    __device__ Tuple7(long t0, static_array<static_array<unsigned char,2l>,2l> t1, static_array<long,2l> t2, long t3, static_array<long,2l> t4, US4 t5, US1 t6) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4), v5(t5), v6(t6) {}
    __device__ Tuple7() = default;
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
__device__ US0 US0_0(static_array_list<unsigned char,5l,long> v0) { // CommunityCardsAre
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
__device__ US0 US0_2(long v0, US1 v1) { // PlayerAction
    US0 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US0 US0_3(long v0, static_array<unsigned char,2l> v1) { // PlayerGotCards
    US0 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1;
    return x;
}
__device__ US0 US0_4(long v0, static_array<Tuple0,2l> v1, long v2) { // Showdown
    US0 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2;
    return x;
}
__device__ US4 US4_0(static_array<unsigned char,3l> v0) { // Flop
    US4 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US4 US4_1() { // Preflop
    US4 x;
    x.tag = 1;
    return x;
}
__device__ US4 US4_2(static_array<unsigned char,5l> v0) { // River
    US4 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US4 US4_3(static_array<unsigned char,4l> v0) { // Turn
    US4 x;
    x.tag = 3;
    x.v.case3.v0 = v0;
    return x;
}
__device__ US3 US3_0(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_Flop
    US3 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5;
    return x;
}
__device__ US3 US3_1(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_Fold
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US3 US3_2() { // G_Preflop
    US3 x;
    x.tag = 2;
    return x;
}
__device__ US3 US3_3(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_River
    US3 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5;
    return x;
}
__device__ US3 US3_4(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_Round
    US3 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US3 US3_5(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5, US1 v6) { // G_Round'
    US3 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5; x.v.case5.v6 = v6;
    return x;
}
__device__ US3 US3_6(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_Showdown
    US3 x;
    x.tag = 6;
    x.v.case6.v0 = v0; x.v.case6.v1 = v1; x.v.case6.v2 = v2; x.v.case6.v3 = v3; x.v.case6.v4 = v4; x.v.case6.v5 = v5;
    return x;
}
__device__ US3 US3_7(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // G_Turn
    US3 x;
    x.tag = 7;
    x.v.case7.v0 = v0; x.v.case7.v1 = v1; x.v.case7.v2 = v2; x.v.case7.v3 = v3; x.v.case7.v4 = v4; x.v.case7.v5 = v5;
    return x;
}
__device__ US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1(US3 v0) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US5 US5_0() { // Computer
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1() { // Human
    US5 x;
    x.tag = 1;
    return x;
}
__device__ US6 US6_0() { // GameNotStarted
    US6 x;
    x.tag = 0;
    return x;
}
__device__ US6 US6_1(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // GameOver
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US6 US6_2(long v0, static_array<static_array<unsigned char,2l>,2l> v1, static_array<long,2l> v2, long v3, static_array<long,2l> v4, US4 v5) { // WaitingForActionFromPlayerId
    US6 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ unsigned long long f_1(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+0ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_2(unsigned char * v0){
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
__device__ long f_4(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned char f_7(unsigned char * v0){
    unsigned char * v1;
    v1 = (unsigned char *)(v0+0ull);
    unsigned char v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned char f_6(unsigned char * v0){
    unsigned char v1;
    v1 = f_7(v0);
    return v1;
}
__device__ static_array_list<unsigned char,5l,long> f_5(unsigned char * v0){
    static_array_list<unsigned char,5l,long> v1;
    v1.length = 0;
    long v2;
    v2 = f_4(v0);
    v1.length = v2;
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        unsigned char v9;
        v9 = f_6(v8);
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
__device__ Tuple2 f_8(unsigned char * v0){
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
__device__ long f_10(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ void f_11(unsigned char * v0){
    return ;
}
__device__ Tuple3 f_9(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    long v3;
    v3 = f_10(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US1 v11;
    switch (v3) {
        case 0: {
            f_11(v4);
            v11 = US1_0();
            break;
        }
        case 1: {
            f_11(v4);
            v11 = US1_1();
            break;
        }
        case 2: {
            f_11(v4);
            v11 = US1_2();
            break;
        }
        case 3: {
            long v9;
            v9 = f_4(v4);
            v11 = US1_3(v9);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple3(v2, v11);
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
    static_array<unsigned char,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = 4ull + v6;
        unsigned char * v8;
        v8 = (unsigned char *)(v0+v7);
        unsigned char v9;
        v9 = f_6(v8);
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
__device__ Tuple0 f_15(unsigned char * v0){
    static_array<unsigned char,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_6(v5);
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
__device__ Tuple0 f_14(unsigned char * v0){
    static_array<unsigned char,5l> v1; char v2;
    Tuple0 tmp3 = f_15(v0);
    v1 = tmp3.v0; v2 = tmp3.v1;
    return Tuple0(v1, v2);
}
__device__ Tuple5 f_13(unsigned char * v0){
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
        static_array<unsigned char,5l> v10; char v11;
        Tuple0 tmp4 = f_14(v9);
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
__device__ US0 f_3(unsigned char * v0){
    long v1;
    v1 = f_4(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            static_array_list<unsigned char,5l,long> v4;
            v4 = f_5(v2);
            return US0_0(v4);
            break;
        }
        case 1: {
            long v6; long v7;
            Tuple2 tmp0 = f_8(v2);
            v6 = tmp0.v0; v7 = tmp0.v1;
            return US0_1(v6, v7);
            break;
        }
        case 2: {
            long v9; US1 v10;
            Tuple3 tmp1 = f_9(v2);
            v9 = tmp1.v0; v10 = tmp1.v1;
            return US0_2(v9, v10);
            break;
        }
        case 3: {
            long v12; static_array<unsigned char,2l> v13;
            Tuple4 tmp2 = f_12(v2);
            v12 = tmp2.v0; v13 = tmp2.v1;
            return US0_3(v12, v13);
            break;
        }
        case 4: {
            long v15; static_array<Tuple0,2l> v16; long v17;
            Tuple5 tmp5 = f_13(v2);
            v15 = tmp5.v0; v16 = tmp5.v1; v17 = tmp5.v2;
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
    v1 = (long *)(v0+6160ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ static_array<unsigned char,2l> f_19(unsigned char * v0){
    static_array<unsigned char,2l> v1;
    long v2;
    v2 = 0l;
    while (while_method_1(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_6(v5);
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
__device__ long f_20(unsigned char * v0){
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
__device__ static_array<unsigned char,3l> f_21(unsigned char * v0){
    static_array<unsigned char,3l> v1;
    long v2;
    v2 = 0l;
    while (while_method_3(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_6(v5);
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
__device__ static_array<unsigned char,5l> f_22(unsigned char * v0){
    static_array<unsigned char,5l> v1;
    long v2;
    v2 = 0l;
    while (while_method_2(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_6(v5);
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
__device__ static_array<unsigned char,4l> f_23(unsigned char * v0){
    static_array<unsigned char,4l> v1;
    long v2;
    v2 = 0l;
    while (while_method_4(v2)){
        unsigned long long v4;
        v4 = (unsigned long long)v2;
        unsigned char * v5;
        v5 = (unsigned char *)(v0+v4);
        unsigned char v6;
        v6 = f_6(v5);
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
__device__ Tuple6 f_18(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<static_array<unsigned char,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 2ull;
        unsigned long long v8;
        v8 = 4ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<unsigned char,2l> v10;
        v10 = f_19(v9);
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
    while (while_method_1(v16)){
        unsigned long long v18;
        v18 = (unsigned long long)v16;
        unsigned long long v19;
        v19 = v18 * 4ull;
        unsigned long long v20;
        v20 = 8ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_4(v21);
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
    while (while_method_1(v30)){
        unsigned long long v32;
        v32 = (unsigned long long)v30;
        unsigned long long v33;
        v33 = v32 * 4ull;
        unsigned long long v34;
        v34 = 20ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_4(v35);
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
    v41 = f_20(v0);
    unsigned char * v42;
    v42 = (unsigned char *)(v0+32ull);
    US4 v51;
    switch (v41) {
        case 0: {
            static_array<unsigned char,3l> v44;
            v44 = f_21(v42);
            v51 = US4_0(v44);
            break;
        }
        case 1: {
            f_11(v42);
            v51 = US4_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v47;
            v47 = f_22(v42);
            v51 = US4_2(v47);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v49;
            v49 = f_23(v42);
            v51 = US4_3(v49);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple6(v2, v3, v15, v28, v29, v51);
}
__device__ long f_25(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+40ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple7 f_24(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    static_array<static_array<unsigned char,2l>,2l> v3;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 2ull;
        unsigned long long v8;
        v8 = 4ull + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        static_array<unsigned char,2l> v10;
        v10 = f_19(v9);
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
    while (while_method_1(v16)){
        unsigned long long v18;
        v18 = (unsigned long long)v16;
        unsigned long long v19;
        v19 = v18 * 4ull;
        unsigned long long v20;
        v20 = 8ull + v19;
        unsigned char * v21;
        v21 = (unsigned char *)(v0+v20);
        long v22;
        v22 = f_4(v21);
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
    while (while_method_1(v30)){
        unsigned long long v32;
        v32 = (unsigned long long)v30;
        unsigned long long v33;
        v33 = v32 * 4ull;
        unsigned long long v34;
        v34 = 20ull + v33;
        unsigned char * v35;
        v35 = (unsigned char *)(v0+v34);
        long v36;
        v36 = f_4(v35);
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
    v41 = f_20(v0);
    unsigned char * v42;
    v42 = (unsigned char *)(v0+32ull);
    US4 v51;
    switch (v41) {
        case 0: {
            static_array<unsigned char,3l> v44;
            v44 = f_21(v42);
            v51 = US4_0(v44);
            break;
        }
        case 1: {
            f_11(v42);
            v51 = US4_1();
            break;
        }
        case 2: {
            static_array<unsigned char,5l> v47;
            v47 = f_22(v42);
            v51 = US4_2(v47);
            break;
        }
        case 3: {
            static_array<unsigned char,4l> v49;
            v49 = f_23(v42);
            v51 = US4_3(v49);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    long v52;
    v52 = f_25(v0);
    unsigned char * v53;
    v53 = (unsigned char *)(v0+44ull);
    US1 v60;
    switch (v52) {
        case 0: {
            f_11(v53);
            v60 = US1_0();
            break;
        }
        case 1: {
            f_11(v53);
            v60 = US1_1();
            break;
        }
        case 2: {
            f_11(v53);
            v60 = US1_2();
            break;
        }
        case 3: {
            long v58;
            v58 = f_4(v53);
            v60 = US1_3(v58);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple7(v2, v3, v15, v28, v29, v51, v60);
}
__device__ US3 f_17(unsigned char * v0){
    long v1;
    v1 = f_4(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    switch (v1) {
        case 0: {
            long v4; static_array<static_array<unsigned char,2l>,2l> v5; static_array<long,2l> v6; long v7; static_array<long,2l> v8; US4 v9;
            Tuple6 tmp6 = f_18(v2);
            v4 = tmp6.v0; v5 = tmp6.v1; v6 = tmp6.v2; v7 = tmp6.v3; v8 = tmp6.v4; v9 = tmp6.v5;
            return US3_0(v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: {
            long v11; static_array<static_array<unsigned char,2l>,2l> v12; static_array<long,2l> v13; long v14; static_array<long,2l> v15; US4 v16;
            Tuple6 tmp7 = f_18(v2);
            v11 = tmp7.v0; v12 = tmp7.v1; v13 = tmp7.v2; v14 = tmp7.v3; v15 = tmp7.v4; v16 = tmp7.v5;
            return US3_1(v11, v12, v13, v14, v15, v16);
            break;
        }
        case 2: {
            f_11(v2);
            return US3_2();
            break;
        }
        case 3: {
            long v19; static_array<static_array<unsigned char,2l>,2l> v20; static_array<long,2l> v21; long v22; static_array<long,2l> v23; US4 v24;
            Tuple6 tmp8 = f_18(v2);
            v19 = tmp8.v0; v20 = tmp8.v1; v21 = tmp8.v2; v22 = tmp8.v3; v23 = tmp8.v4; v24 = tmp8.v5;
            return US3_3(v19, v20, v21, v22, v23, v24);
            break;
        }
        case 4: {
            long v26; static_array<static_array<unsigned char,2l>,2l> v27; static_array<long,2l> v28; long v29; static_array<long,2l> v30; US4 v31;
            Tuple6 tmp9 = f_18(v2);
            v26 = tmp9.v0; v27 = tmp9.v1; v28 = tmp9.v2; v29 = tmp9.v3; v30 = tmp9.v4; v31 = tmp9.v5;
            return US3_4(v26, v27, v28, v29, v30, v31);
            break;
        }
        case 5: {
            long v33; static_array<static_array<unsigned char,2l>,2l> v34; static_array<long,2l> v35; long v36; static_array<long,2l> v37; US4 v38; US1 v39;
            Tuple7 tmp10 = f_24(v2);
            v33 = tmp10.v0; v34 = tmp10.v1; v35 = tmp10.v2; v36 = tmp10.v3; v37 = tmp10.v4; v38 = tmp10.v5; v39 = tmp10.v6;
            return US3_5(v33, v34, v35, v36, v37, v38, v39);
            break;
        }
        case 6: {
            long v41; static_array<static_array<unsigned char,2l>,2l> v42; static_array<long,2l> v43; long v44; static_array<long,2l> v45; US4 v46;
            Tuple6 tmp11 = f_18(v2);
            v41 = tmp11.v0; v42 = tmp11.v1; v43 = tmp11.v2; v44 = tmp11.v3; v45 = tmp11.v4; v46 = tmp11.v5;
            return US3_6(v41, v42, v43, v44, v45, v46);
            break;
        }
        case 7: {
            long v48; static_array<static_array<unsigned char,2l>,2l> v49; static_array<long,2l> v50; long v51; static_array<long,2l> v52; US4 v53;
            Tuple6 tmp12 = f_18(v2);
            v48 = tmp12.v0; v49 = tmp12.v1; v50 = tmp12.v2; v51 = tmp12.v3; v52 = tmp12.v4; v53 = tmp12.v5;
            return US3_7(v48, v49, v50, v51, v52, v53);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ US5 f_26(unsigned char * v0){
    long v1;
    v1 = f_4(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+4ull);
    switch (v1) {
        case 0: {
            f_11(v2);
            return US5_0();
            break;
        }
        case 1: {
            f_11(v2);
            return US5_1();
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_27(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+6248ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple1 f_0(unsigned char * v0){
    unsigned long long v1;
    v1 = f_1(v0);
    static_array_list<US0,128l,long> v2;
    v2.length = 0;
    long v3;
    v3 = f_2(v0);
    v2.length = v3;
    long v4;
    v4 = v2.length;
    long v5;
    v5 = 0l;
    while (while_method_0(v4, v5)){
        unsigned long long v7;
        v7 = (unsigned long long)v5;
        unsigned long long v8;
        v8 = v7 * 48ull;
        unsigned long long v9;
        v9 = 16ull + v8;
        unsigned char * v10;
        v10 = (unsigned char *)(v0+v9);
        US0 v11;
        v11 = f_3(v10);
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
    v18 = (unsigned char *)(v0+6176ull);
    US2 v23;
    switch (v17) {
        case 0: {
            f_11(v18);
            v23 = US2_0();
            break;
        }
        case 1: {
            US3 v21;
            v21 = f_17(v18);
            v23 = US2_1(v21);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    static_array<US5,2l> v24;
    long v25;
    v25 = 0l;
    while (while_method_1(v25)){
        unsigned long long v27;
        v27 = (unsigned long long)v25;
        unsigned long long v28;
        v28 = v27 * 4ull;
        unsigned long long v29;
        v29 = 6240ull + v28;
        unsigned char * v30;
        v30 = (unsigned char *)(v0+v29);
        US5 v31;
        v31 = f_26(v30);
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
    v36 = f_27(v0);
    unsigned char * v37;
    v37 = (unsigned char *)(v0+6256ull);
    US6 v54;
    switch (v36) {
        case 0: {
            f_11(v37);
            v54 = US6_0();
            break;
        }
        case 1: {
            long v40; static_array<static_array<unsigned char,2l>,2l> v41; static_array<long,2l> v42; long v43; static_array<long,2l> v44; US4 v45;
            Tuple6 tmp13 = f_18(v37);
            v40 = tmp13.v0; v41 = tmp13.v1; v42 = tmp13.v2; v43 = tmp13.v3; v44 = tmp13.v4; v45 = tmp13.v5;
            v54 = US6_1(v40, v41, v42, v43, v44, v45);
            break;
        }
        case 2: {
            long v47; static_array<static_array<unsigned char,2l>,2l> v48; static_array<long,2l> v49; long v50; static_array<long,2l> v51; US4 v52;
            Tuple6 tmp14 = f_18(v37);
            v47 = tmp14.v0; v48 = tmp14.v1; v49 = tmp14.v2; v50 = tmp14.v3; v51 = tmp14.v4; v52 = tmp14.v5;
            v54 = US6_2(v47, v48, v49, v50, v51, v52);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
    return Tuple1(v1, v2, v23, v24, v54);
}
__device__ void f_29(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_30(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+8ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_32(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_35(unsigned char * v0, unsigned char v1){
    unsigned char * v2;
    v2 = (unsigned char *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_34(unsigned char * v0, unsigned char v1){
    return f_35(v0, v1);
}
__device__ void f_33(unsigned char * v0, static_array_list<unsigned char,5l,long> v1){
    long v2;
    v2 = v1.length;
    f_32(v0, v2);
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
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
        f_34(v8, v14);
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
__device__ void f_38(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_39(unsigned char * v0){
    return ;
}
__device__ void f_37(unsigned char * v0, long v1, US1 v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_38(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    switch (v2.tag) {
        case 0: { // A_All_In
            return f_39(v5);
            break;
        }
        case 1: { // A_Call
            return f_39(v5);
            break;
        }
        case 2: { // A_Fold
            return f_39(v5);
            break;
        }
        case 3: { // A_Raise
            long v6 = v2.v.case3.v0;
            return f_32(v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_40(unsigned char * v0, long v1, static_array<unsigned char,2l> v2){
    long * v3;
    v3 = (long *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = 0l;
    while (while_method_1(v4)){
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
        f_34(v8, v13);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_43(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
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
        f_34(v6, v11);
        v3 += 1l ;
    }
    char * v12;
    v12 = (char *)(v0+5ull);
    v12[0l] = v2;
    return ;
}
__device__ void f_42(unsigned char * v0, static_array<unsigned char,5l> v1, char v2){
    return f_43(v0, v1, v2);
}
__device__ void f_41(unsigned char * v0, long v1, static_array<Tuple0,2l> v2, long v3){
    long * v4;
    v4 = (long *)(v0+0ull);
    v4[0l] = v1;
    long v5;
    v5 = 0l;
    while (while_method_1(v5)){
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
        Tuple0 tmp16 = v2.v[v5];
        v15 = tmp16.v0; v16 = tmp16.v1;
        f_42(v10, v15, v16);
        v5 += 1l ;
    }
    long * v17;
    v17 = (long *)(v0+24ull);
    v17[0l] = v3;
    return ;
}
__device__ void f_31(unsigned char * v0, US0 v1){
    long v2;
    v2 = v1.tag;
    f_32(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // CommunityCardsAre
            static_array_list<unsigned char,5l,long> v4 = v1.v.case0.v0;
            return f_33(v3, v4);
            break;
        }
        case 1: { // Fold
            long v5 = v1.v.case1.v0; long v6 = v1.v.case1.v1;
            return f_36(v3, v5, v6);
            break;
        }
        case 2: { // PlayerAction
            long v7 = v1.v.case2.v0; US1 v8 = v1.v.case2.v1;
            return f_37(v3, v7, v8);
            break;
        }
        case 3: { // PlayerGotCards
            long v9 = v1.v.case3.v0; static_array<unsigned char,2l> v10 = v1.v.case3.v1;
            return f_40(v3, v9, v10);
            break;
        }
        case 4: { // Showdown
            long v11 = v1.v.case4.v0; static_array<Tuple0,2l> v12 = v1.v.case4.v1; long v13 = v1.v.case4.v2;
            return f_41(v3, v11, v12, v13);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_44(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6160ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_47(unsigned char * v0, static_array<unsigned char,2l> v1){
    long v2;
    v2 = 0l;
    while (while_method_1(v2)){
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
        f_34(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_48(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+28ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_49(unsigned char * v0, static_array<unsigned char,3l> v1){
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
        f_34(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_50(unsigned char * v0, static_array<unsigned char,5l> v1){
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
        f_34(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_51(unsigned char * v0, static_array<unsigned char,4l> v1){
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
        f_34(v5, v10);
        v2 += 1l ;
    }
    return ;
}
__device__ void f_46(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US4 v6){
    long * v7;
    v7 = (long *)(v0+0ull);
    v7[0l] = v1;
    long v8;
    v8 = 0l;
    while (while_method_1(v8)){
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
        f_47(v13, v18);
        v8 += 1l ;
    }
    long v19;
    v19 = 0l;
    while (while_method_1(v19)){
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
        f_32(v24, v29);
        v19 += 1l ;
    }
    long * v30;
    v30 = (long *)(v0+16ull);
    v30[0l] = v4;
    long v31;
    v31 = 0l;
    while (while_method_1(v31)){
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
        f_32(v36, v41);
        v31 += 1l ;
    }
    long v42;
    v42 = v6.tag;
    f_48(v0, v42);
    unsigned char * v43;
    v43 = (unsigned char *)(v0+32ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v44 = v6.v.case0.v0;
            return f_49(v43, v44);
            break;
        }
        case 1: { // Preflop
            return f_39(v43);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v45 = v6.v.case2.v0;
            return f_50(v43, v45);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v46 = v6.v.case3.v0;
            return f_51(v43, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_53(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+40ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_52(unsigned char * v0, long v1, static_array<static_array<unsigned char,2l>,2l> v2, static_array<long,2l> v3, long v4, static_array<long,2l> v5, US4 v6, US1 v7){
    long * v8;
    v8 = (long *)(v0+0ull);
    v8[0l] = v1;
    long v9;
    v9 = 0l;
    while (while_method_1(v9)){
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
        f_47(v14, v19);
        v9 += 1l ;
    }
    long v20;
    v20 = 0l;
    while (while_method_1(v20)){
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
        f_32(v25, v30);
        v20 += 1l ;
    }
    long * v31;
    v31 = (long *)(v0+16ull);
    v31[0l] = v4;
    long v32;
    v32 = 0l;
    while (while_method_1(v32)){
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
        f_32(v37, v42);
        v32 += 1l ;
    }
    long v43;
    v43 = v6.tag;
    f_48(v0, v43);
    unsigned char * v44;
    v44 = (unsigned char *)(v0+32ull);
    switch (v6.tag) {
        case 0: { // Flop
            static_array<unsigned char,3l> v45 = v6.v.case0.v0;
            f_49(v44, v45);
            break;
        }
        case 1: { // Preflop
            f_39(v44);
            break;
        }
        case 2: { // River
            static_array<unsigned char,5l> v46 = v6.v.case2.v0;
            f_50(v44, v46);
            break;
        }
        case 3: { // Turn
            static_array<unsigned char,4l> v47 = v6.v.case3.v0;
            f_51(v44, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
    long v48;
    v48 = v7.tag;
    f_53(v0, v48);
    unsigned char * v49;
    v49 = (unsigned char *)(v0+44ull);
    switch (v7.tag) {
        case 0: { // A_All_In
            return f_39(v49);
            break;
        }
        case 1: { // A_Call
            return f_39(v49);
            break;
        }
        case 2: { // A_Fold
            return f_39(v49);
            break;
        }
        case 3: { // A_Raise
            long v50 = v7.v.case3.v0;
            return f_32(v49, v50);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_45(unsigned char * v0, US3 v1){
    long v2;
    v2 = v1.tag;
    f_32(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    switch (v1.tag) {
        case 0: { // G_Flop
            long v4 = v1.v.case0.v0; static_array<static_array<unsigned char,2l>,2l> v5 = v1.v.case0.v1; static_array<long,2l> v6 = v1.v.case0.v2; long v7 = v1.v.case0.v3; static_array<long,2l> v8 = v1.v.case0.v4; US4 v9 = v1.v.case0.v5;
            return f_46(v3, v4, v5, v6, v7, v8, v9);
            break;
        }
        case 1: { // G_Fold
            long v10 = v1.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v11 = v1.v.case1.v1; static_array<long,2l> v12 = v1.v.case1.v2; long v13 = v1.v.case1.v3; static_array<long,2l> v14 = v1.v.case1.v4; US4 v15 = v1.v.case1.v5;
            return f_46(v3, v10, v11, v12, v13, v14, v15);
            break;
        }
        case 2: { // G_Preflop
            return f_39(v3);
            break;
        }
        case 3: { // G_River
            long v16 = v1.v.case3.v0; static_array<static_array<unsigned char,2l>,2l> v17 = v1.v.case3.v1; static_array<long,2l> v18 = v1.v.case3.v2; long v19 = v1.v.case3.v3; static_array<long,2l> v20 = v1.v.case3.v4; US4 v21 = v1.v.case3.v5;
            return f_46(v3, v16, v17, v18, v19, v20, v21);
            break;
        }
        case 4: { // G_Round
            long v22 = v1.v.case4.v0; static_array<static_array<unsigned char,2l>,2l> v23 = v1.v.case4.v1; static_array<long,2l> v24 = v1.v.case4.v2; long v25 = v1.v.case4.v3; static_array<long,2l> v26 = v1.v.case4.v4; US4 v27 = v1.v.case4.v5;
            return f_46(v3, v22, v23, v24, v25, v26, v27);
            break;
        }
        case 5: { // G_Round'
            long v28 = v1.v.case5.v0; static_array<static_array<unsigned char,2l>,2l> v29 = v1.v.case5.v1; static_array<long,2l> v30 = v1.v.case5.v2; long v31 = v1.v.case5.v3; static_array<long,2l> v32 = v1.v.case5.v4; US4 v33 = v1.v.case5.v5; US1 v34 = v1.v.case5.v6;
            return f_52(v3, v28, v29, v30, v31, v32, v33, v34);
            break;
        }
        case 6: { // G_Showdown
            long v35 = v1.v.case6.v0; static_array<static_array<unsigned char,2l>,2l> v36 = v1.v.case6.v1; static_array<long,2l> v37 = v1.v.case6.v2; long v38 = v1.v.case6.v3; static_array<long,2l> v39 = v1.v.case6.v4; US4 v40 = v1.v.case6.v5;
            return f_46(v3, v35, v36, v37, v38, v39, v40);
            break;
        }
        case 7: { // G_Turn
            long v41 = v1.v.case7.v0; static_array<static_array<unsigned char,2l>,2l> v42 = v1.v.case7.v1; static_array<long,2l> v43 = v1.v.case7.v2; long v44 = v1.v.case7.v3; static_array<long,2l> v45 = v1.v.case7.v4; US4 v46 = v1.v.case7.v5;
            return f_46(v3, v41, v42, v43, v44, v45, v46);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_54(unsigned char * v0, US5 v1){
    long v2;
    v2 = v1.tag;
    f_32(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+4ull);
    switch (v1.tag) {
        case 0: { // Computer
            return f_39(v3);
            break;
        }
        case 1: { // Human
            return f_39(v3);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_55(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6248ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_28(unsigned char * v0, unsigned long long v1, static_array_list<US0,128l,long> v2, US2 v3, static_array<US5,2l> v4, US6 v5){
    f_29(v0, v1);
    long v6;
    v6 = v2.length;
    f_30(v0, v6);
    long v7;
    v7 = v2.length;
    long v8;
    v8 = 0l;
    while (while_method_0(v7, v8)){
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
        US0 v19;
        v19 = v2.v[v8];
        f_31(v13, v19);
        v8 += 1l ;
    }
    long v20;
    v20 = v3.tag;
    f_44(v0, v20);
    unsigned char * v21;
    v21 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // None
            f_39(v21);
            break;
        }
        case 1: { // Some
            US3 v22 = v3.v.case1.v0;
            f_45(v21, v22);
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
        US5 v33;
        v33 = v4.v[v23];
        f_54(v28, v33);
        v23 += 1l ;
    }
    long v34;
    v34 = v5.tag;
    f_55(v0, v34);
    unsigned char * v35;
    v35 = (unsigned char *)(v0+6256ull);
    switch (v5.tag) {
        case 0: { // GameNotStarted
            return f_39(v35);
            break;
        }
        case 1: { // GameOver
            long v36 = v5.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v37 = v5.v.case1.v1; static_array<long,2l> v38 = v5.v.case1.v2; long v39 = v5.v.case1.v3; static_array<long,2l> v40 = v5.v.case1.v4; US4 v41 = v5.v.case1.v5;
            return f_46(v35, v36, v37, v38, v39, v40, v41);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v42 = v5.v.case2.v0; static_array<static_array<unsigned char,2l>,2l> v43 = v5.v.case2.v1; static_array<long,2l> v44 = v5.v.case2.v2; long v45 = v5.v.case2.v3; static_array<long,2l> v46 = v5.v.case2.v4; US4 v47 = v5.v.case2.v5;
            return f_46(v35, v42, v43, v44, v45, v46, v47);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_57(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+6168ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_56(unsigned char * v0, static_array_list<US0,128l,long> v1, static_array<US5,2l> v2, US6 v3){
    long v4;
    v4 = v1.length;
    f_32(v0, v4);
    long v5;
    v5 = v1.length;
    long v6;
    v6 = 0l;
    while (while_method_0(v5, v6)){
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
        US0 v17;
        v17 = v1.v[v6];
        f_31(v11, v17);
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
        US5 v28;
        v28 = v2.v[v18];
        f_54(v23, v28);
        v18 += 1l ;
    }
    long v29;
    v29 = v3.tag;
    f_57(v0, v29);
    unsigned char * v30;
    v30 = (unsigned char *)(v0+6176ull);
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return f_39(v30);
            break;
        }
        case 1: { // GameOver
            long v31 = v3.v.case1.v0; static_array<static_array<unsigned char,2l>,2l> v32 = v3.v.case1.v1; static_array<long,2l> v33 = v3.v.case1.v2; long v34 = v3.v.case1.v3; static_array<long,2l> v35 = v3.v.case1.v4; US4 v36 = v3.v.case1.v5;
            return f_46(v30, v31, v32, v33, v34, v35, v36);
            break;
        }
        case 2: { // WaitingForActionFromPlayerId
            long v37 = v3.v.case2.v0; static_array<static_array<unsigned char,2l>,2l> v38 = v3.v.case2.v1; static_array<long,2l> v39 = v3.v.case2.v2; long v40 = v3.v.case2.v3; static_array<long,2l> v41 = v3.v.case2.v4; US4 v42 = v3.v.case2.v5;
            return f_46(v30, v37, v38, v39, v40, v41, v42);
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
        unsigned long long v8; static_array_list<US0,128l,long> v9; US2 v10; static_array<US5,2l> v11; US6 v12;
        Tuple1 tmp15 = f_0(v0);
        v8 = tmp15.v0; v9 = tmp15.v1; v10 = tmp15.v2; v11 = tmp15.v3; v12 = tmp15.v4;
        f_28(v0, v8, v9, v10, v11, v12);
        return f_56(v2, v9, v11, v12);
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
def method14(v0 : cp.ndarray, v1 : u8) -> None:
    v2 = v0[0:].view(cp.uint8)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method13(v0 : cp.ndarray, v1 : u8) -> None:
    return method14(v0, v1)
def method12(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method1(v0, v2)
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
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
        method13(v8, v15)
        del v8, v15
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
def method17(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method16(v0 : cp.ndarray, v1 : i32, v2 : US2) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method17(v0, v4)
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
def method18(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[0:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method5(v4):
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
        method13(v8, v14)
        del v8, v14
        v4 += 1 
    del v0, v2, v4
    return 
def method22(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method21(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    v3 = 0
    while method22(v3):
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
        method13(v6, v12)
        del v6, v12
        v3 += 1 
    del v1, v3
    v13 = v0[5:].view(cp.int8)
    del v0
    v13[0] = v2
    del v2, v13
    return 
def method20(v0 : cp.ndarray, v1 : static_array, v2 : i8) -> None:
    return method21(v0, v1, v2)
def method19(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
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
        method20(v10, v16, v17)
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
            return method18(v3, v9, v10)
        case US7_4(v11, v12, v13): # Showdown
            del v1
            return method19(v3, v11, v12, v13)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method23(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6160:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method26(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method5(v2):
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
        method13(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method27(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[28:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method29(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method28(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method29(v2):
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
        method13(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method30(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method22(v2):
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
        method13(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method32(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method31(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method32(v2):
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
        method13(v5, v11)
        del v5, v11
        v2 += 1 
    del v0, v1, v2
    return 
def method25(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5) -> None:
    v7 = v0[0:].view(cp.int32)
    v7[0] = v1
    del v1, v7
    v8 = 0
    while method5(v8):
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
        method26(v13, v19)
        del v13, v19
        v8 += 1 
    del v2, v8
    v20 = 0
    while method5(v20):
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
        method1(v25, v31)
        del v25, v31
        v20 += 1 
    del v3, v20
    v32 = v0[16:].view(cp.int32)
    v32[0] = v4
    del v4, v32
    v33 = 0
    while method5(v33):
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
        method1(v38, v44)
        del v38, v44
        v33 += 1 
    del v5, v33
    v45 = v6.tag
    method27(v0, v45)
    del v45
    v46 = v0[32:].view(cp.uint8)
    del v0
    match v6:
        case US5_0(v47): # Flop
            del v6
            return method28(v46, v47)
        case US5_1(): # Preflop
            del v6
            return method3(v46)
        case US5_2(v48): # River
            del v6
            return method30(v46, v48)
        case US5_3(v49): # Turn
            del v6
            return method31(v46, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method34(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[40:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method33(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : static_array, v4 : i32, v5 : static_array, v6 : US5, v7 : US2) -> None:
    v8 = v0[0:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = 0
    while method5(v9):
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
        method26(v14, v20)
        del v14, v20
        v9 += 1 
    del v2, v9
    v21 = 0
    while method5(v21):
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
        method1(v26, v32)
        del v26, v32
        v21 += 1 
    del v3, v21
    v33 = v0[16:].view(cp.int32)
    v33[0] = v4
    del v4, v33
    v34 = 0
    while method5(v34):
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
        method1(v39, v45)
        del v39, v45
        v34 += 1 
    del v5, v34
    v46 = v6.tag
    method27(v0, v46)
    del v46
    v47 = v0[32:].view(cp.uint8)
    match v6:
        case US5_0(v48): # Flop
            method28(v47, v48)
        case US5_1(): # Preflop
            method3(v47)
        case US5_2(v49): # River
            method30(v47, v49)
        case US5_3(v50): # Turn
            method31(v47, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v6, v47
    v51 = v7.tag
    method34(v0, v51)
    del v51
    v52 = v0[44:].view(cp.uint8)
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
def method24(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method1(v0, v2)
    del v2
    v3 = v0[16:].view(cp.uint8)
    del v0
    match v1:
        case US4_0(v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method25(v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v1
            return method25(v3, v10, v11, v12, v13, v14, v15)
        case US4_2(): # G_Preflop
            del v1
            return method3(v3)
        case US4_3(v16, v17, v18, v19, v20, v21): # G_River
            del v1
            return method25(v3, v16, v17, v18, v19, v20, v21)
        case US4_4(v22, v23, v24, v25, v26, v27): # G_Round
            del v1
            return method25(v3, v22, v23, v24, v25, v26, v27)
        case US4_5(v28, v29, v30, v31, v32, v33, v34): # G_Round'
            del v1
            return method33(v3, v28, v29, v30, v31, v32, v33, v34)
        case US4_6(v35, v36, v37, v38, v39, v40): # G_Showdown
            del v1
            return method25(v3, v35, v36, v37, v38, v39, v40)
        case US4_7(v41, v42, v43, v44, v45, v46): # G_Turn
            del v1
            return method25(v3, v41, v42, v43, v44, v45, v46)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method35(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[6248:].view(cp.int32)
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
        method11(v13, v20)
        del v13, v20
        v8 += 1 
    del v2, v7, v8
    v21 = v3.tag
    method23(v0, v21)
    del v21
    v22 = v0[6176:].view(cp.uint8)
    match v3:
        case US3_0(): # None
            method3(v22)
        case US3_1(v23): # Some
            method24(v22, v23)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3, v22
    v24 = 0
    while method5(v24):
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
        method6(v29, v35)
        del v29, v35
        v24 += 1 
    del v4, v24
    v36 = v5.tag
    method35(v0, v36)
    del v36
    v37 = v0[6256:].view(cp.uint8)
    del v0
    match v5:
        case US6_0(): # GameNotStarted
            del v5
            return method3(v37)
        case US6_1(v38, v39, v40, v41, v42, v43): # GameOver
            del v5
            return method25(v37, v38, v39, v40, v41, v42, v43)
        case US6_2(v44, v45, v46, v47, v48, v49): # WaitingForActionFromPlayerId
            del v5
            return method25(v37, v44, v45, v46, v47, v48, v49)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method36(v0 : string) -> None:
    print(v0, end="")
    del v0
    return 
def method37(v0 : f64) -> None:
    print("{:.6f}".format(v0), end="")
    del v0
    return 
def method39(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method40(v0 : cp.ndarray) -> i32:
    v1 = v0[8:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method42(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method45(v0 : cp.ndarray) -> u8:
    v1 = v0[0:].view(cp.uint8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method44(v0 : cp.ndarray) -> u8:
    v1 = method45(v0)
    del v0
    return v1
def method43(v0 : cp.ndarray) -> static_array_list:
    v1 = static_array_list(5)
    v2 = method42(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = method44(v8)
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
def method46(v0 : cp.ndarray) -> Tuple[i32, i32]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = v0[4:].view(cp.int32)
    del v0
    v4 = v3[0].item()
    del v3
    return v2, v4
def method48(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method49(v0 : cp.ndarray) -> None:
    del v0
    return 
def method47(v0 : cp.ndarray) -> Tuple[i32, US2]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = method48(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    if v3 == 0:
        method49(v4)
        v11 = US2_0()
    elif v3 == 1:
        method49(v4)
        v11 = US2_1()
    elif v3 == 2:
        method49(v4)
        v11 = US2_2()
    elif v3 == 3:
        v9 = method42(v4)
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
        v7 = 4 + v6
        del v6
        v8 = v0[v7:].view(cp.uint8)
        del v7
        v9 = method44(v8)
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
def method53(v0 : cp.ndarray) -> Tuple[static_array, i8]:
    v1 = static_array(5)
    v2 = 0
    while method22(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method44(v5)
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
def method41(v0 : cp.ndarray) -> US7:
    v1 = method42(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4 = method43(v2)
        del v2
        return US7_0(v4)
    elif v1 == 1:
        del v1
        v6, v7 = method46(v2)
        del v2
        return US7_1(v6, v7)
    elif v1 == 2:
        del v1
        v9, v10 = method47(v2)
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
def method54(v0 : cp.ndarray) -> i32:
    v1 = v0[6160:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method57(v0 : cp.ndarray) -> static_array:
    v1 = static_array(2)
    v2 = 0
    while method5(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method44(v5)
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
def method58(v0 : cp.ndarray) -> i32:
    v1 = v0[28:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method59(v0 : cp.ndarray) -> static_array:
    v1 = static_array(3)
    v2 = 0
    while method29(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method44(v5)
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
def method60(v0 : cp.ndarray) -> static_array:
    v1 = static_array(5)
    v2 = 0
    while method22(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method44(v5)
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
def method61(v0 : cp.ndarray) -> static_array:
    v1 = static_array(4)
    v2 = 0
    while method32(v2):
        v4 = u64(v2)
        v5 = v0[v4:].view(cp.uint8)
        del v4
        v6 = method44(v5)
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
def method56(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 2
        del v6
        v8 = 4 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method57(v9)
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
        v21 = 8 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method42(v22)
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
    while method5(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 20 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method42(v37)
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
    v44 = method58(v0)
    v45 = v0[32:].view(cp.uint8)
    del v0
    if v44 == 0:
        v47 = method59(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method49(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method60(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method61(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    return v2, v3, v16, v30, v31, v54
def method63(v0 : cp.ndarray) -> i32:
    v1 = v0[40:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method62(v0 : cp.ndarray) -> Tuple[i32, static_array, static_array, i32, static_array, US5, US2]:
    v1 = v0[0:].view(cp.int32)
    v2 = v1[0].item()
    del v1
    v3 = static_array(2)
    v4 = 0
    while method5(v4):
        v6 = u64(v4)
        v7 = v6 * 2
        del v6
        v8 = 4 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method57(v9)
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
        v21 = 8 + v20
        del v20
        v22 = v0[v21:].view(cp.uint8)
        del v21
        v23 = method42(v22)
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
    while method5(v32):
        v34 = u64(v32)
        v35 = v34 * 4
        del v34
        v36 = 20 + v35
        del v35
        v37 = v0[v36:].view(cp.uint8)
        del v36
        v38 = method42(v37)
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
    v44 = method58(v0)
    v45 = v0[32:].view(cp.uint8)
    if v44 == 0:
        v47 = method59(v45)
        v54 = US5_0(v47)
    elif v44 == 1:
        method49(v45)
        v54 = US5_1()
    elif v44 == 2:
        v50 = method60(v45)
        v54 = US5_2(v50)
    elif v44 == 3:
        v52 = method61(v45)
        v54 = US5_3(v52)
    else:
        raise Exception("Invalid tag.")
    del v44, v45
    v55 = method63(v0)
    v56 = v0[44:].view(cp.uint8)
    del v0
    if v55 == 0:
        method49(v56)
        v63 = US2_0()
    elif v55 == 1:
        method49(v56)
        v63 = US2_1()
    elif v55 == 2:
        method49(v56)
        v63 = US2_2()
    elif v55 == 3:
        v61 = method42(v56)
        v63 = US2_3(v61)
    else:
        raise Exception("Invalid tag.")
    del v55, v56
    return v2, v3, v16, v30, v31, v54, v63
def method55(v0 : cp.ndarray) -> US4:
    v1 = method42(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        v4, v5, v6, v7, v8, v9 = method56(v2)
        del v2
        return US4_0(v4, v5, v6, v7, v8, v9)
    elif v1 == 1:
        del v1
        v11, v12, v13, v14, v15, v16 = method56(v2)
        del v2
        return US4_1(v11, v12, v13, v14, v15, v16)
    elif v1 == 2:
        del v1
        method49(v2)
        del v2
        return US4_2()
    elif v1 == 3:
        del v1
        v19, v20, v21, v22, v23, v24 = method56(v2)
        del v2
        return US4_3(v19, v20, v21, v22, v23, v24)
    elif v1 == 4:
        del v1
        v26, v27, v28, v29, v30, v31 = method56(v2)
        del v2
        return US4_4(v26, v27, v28, v29, v30, v31)
    elif v1 == 5:
        del v1
        v33, v34, v35, v36, v37, v38, v39 = method62(v2)
        del v2
        return US4_5(v33, v34, v35, v36, v37, v38, v39)
    elif v1 == 6:
        del v1
        v41, v42, v43, v44, v45, v46 = method56(v2)
        del v2
        return US4_6(v41, v42, v43, v44, v45, v46)
    elif v1 == 7:
        del v1
        v48, v49, v50, v51, v52, v53 = method56(v2)
        del v2
        return US4_7(v48, v49, v50, v51, v52, v53)
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method64(v0 : cp.ndarray) -> US0:
    v1 = method42(v0)
    v2 = v0[4:].view(cp.uint8)
    del v0
    if v1 == 0:
        del v1
        method49(v2)
        del v2
        return US0_0()
    elif v1 == 1:
        del v1
        method49(v2)
        del v2
        return US0_1()
    else:
        del v1, v2
        raise Exception("Invalid tag.")
def method65(v0 : cp.ndarray) -> i32:
    v1 = v0[6248:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method38(v0 : cp.ndarray) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = method39(v0)
    v2 = static_array_list(128)
    v3 = method40(v0)
    v2.length = v3
    del v3
    v4 = v2.length
    v5 = 0
    while method10(v4, v5):
        v7 = u64(v5)
        v8 = v7 * 48
        del v7
        v9 = 16 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = method41(v10)
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
    v18 = method54(v0)
    v19 = v0[6176:].view(cp.uint8)
    if v18 == 0:
        method49(v19)
        v24 = US3_0()
    elif v18 == 1:
        v22 = method55(v19)
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
        v30 = 6240 + v29
        del v29
        v31 = v0[v30:].view(cp.uint8)
        del v30
        v32 = method64(v31)
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
    v38 = method65(v0)
    v39 = v0[6256:].view(cp.uint8)
    del v0
    if v38 == 0:
        method49(v39)
        v56 = US6_0()
    elif v38 == 1:
        v42, v43, v44, v45, v46, v47 = method56(v39)
        v56 = US6_1(v42, v43, v44, v45, v46, v47)
    elif v38 == 2:
        v49, v50, v51, v52, v53, v54 = method56(v39)
        v56 = US6_2(v49, v50, v51, v52, v53, v54)
    else:
        raise Exception("Invalid tag.")
    del v38, v39
    return v1, v2, v24, v25, v56
def method67(v0 : cp.ndarray) -> i32:
    v1 = v0[6168:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method66(v0 : cp.ndarray) -> Tuple[static_array_list, static_array, US6]:
    v1 = static_array_list(128)
    v2 = method42(v0)
    v1.length = v2
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 48
        del v6
        v8 = 16 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = method41(v9)
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
        v22 = 6160 + v21
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
    v31 = v0[6176:].view(cp.uint8)
    del v0
    if v30 == 0:
        method49(v31)
        v48 = US6_0()
    elif v30 == 1:
        v34, v35, v36, v37, v38, v39 = method56(v31)
        v48 = US6_1(v34, v35, v36, v37, v38, v39)
    elif v30 == 2:
        v41, v42, v43, v44, v45, v46 = method56(v31)
        v48 = US6_2(v41, v42, v43, v44, v45, v46)
    else:
        raise Exception("Invalid tag.")
    del v30, v31
    return v1, v17, v48
def method73(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method72(v0 : u64) -> object:
    return method73(v0)
def method78(v0 : u8) -> object:
    v1 = v0
    del v0
    return v1
def method77(v0 : u8) -> object:
    return method78(v0)
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
def method80(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method79(v0 : i32, v1 : i32) -> object:
    v2 = method80(v0)
    del v0
    v3 = method80(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method83() -> object:
    v0 = []
    return v0
def method82(v0 : US2) -> object:
    match v0:
        case US2_0(): # A_All_In
            del v0
            v1 = method83()
            v2 = "A_All_In"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # A_Call
            del v0
            v4 = method83()
            v5 = "A_Call"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US2_2(): # A_Fold
            del v0
            v7 = method83()
            v8 = "A_Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US2_3(v10): # A_Raise
            del v0
            v11 = method80(v10)
            del v10
            v12 = "A_Raise"
            v13 = [v12,v11]
            del v11, v12
            return v13
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method81(v0 : i32, v1 : US2) -> object:
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
def method85(v0 : static_array) -> object:
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
        v10 = method77(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method84(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method80(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method85(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method90(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method22(v2):
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
        v10 = method77(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method91(v0 : i8) -> object:
    v1 = v0
    del v0
    return v1
def method89(v0 : static_array, v1 : i8) -> object:
    v2 = method90(v0)
    del v0
    v3 = method91(v1)
    del v1
    v4 = {'hand': v2, 'score': v3}
    del v2, v3
    return v4
def method88(v0 : static_array, v1 : i8) -> object:
    return method89(v0, v1)
def method87(v0 : static_array) -> object:
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
        v11 = method88(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method86(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method80(v0)
    del v0
    v4 = method87(v1)
    del v1
    v5 = method80(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method75(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method76(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method79(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method81(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method84(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method86(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method74(v0 : static_array_list) -> object:
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
        v12 = method75(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method71(v0 : u64, v1 : static_array_list) -> object:
    v2 = method72(v0)
    del v0
    v3 = method74(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method96(v0 : static_array) -> object:
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
        v10 = method85(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method97(v0 : static_array) -> object:
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
        v10 = method80(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method99(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method29(v2):
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
        v10 = method77(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method100(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method32(v2):
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
        v10 = method77(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method98(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method99(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method83()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method90(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method100(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method95(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5) -> object:
    v6 = method80(v0)
    del v0
    v7 = method96(v1)
    del v1
    v8 = method97(v2)
    del v2
    v9 = method80(v3)
    del v3
    v10 = method97(v4)
    del v4
    v11 = method98(v5)
    del v5
    v12 = {'min_raise': v6, 'pl_card': v7, 'pot': v8, 'round_turn': v9, 'stack': v10, 'street': v11}
    del v6, v7, v8, v9, v10, v11
    return v12
def method101(v0 : i32, v1 : static_array, v2 : static_array, v3 : i32, v4 : static_array, v5 : US5, v6 : US2) -> object:
    v7 = []
    v8 = method95(v0, v1, v2, v3, v4, v5)
    del v0, v1, v2, v3, v4, v5
    v7.append(v8)
    del v8
    v9 = method82(v6)
    del v6
    v7.append(v9)
    del v9
    v10 = v7
    del v7
    return v10
def method94(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # G_Flop
            del v0
            v7 = method95(v1, v2, v3, v4, v5, v6)
            del v1, v2, v3, v4, v5, v6
            v8 = "G_Flop"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US4_1(v10, v11, v12, v13, v14, v15): # G_Fold
            del v0
            v16 = method95(v10, v11, v12, v13, v14, v15)
            del v10, v11, v12, v13, v14, v15
            v17 = "G_Fold"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US4_2(): # G_Preflop
            del v0
            v19 = method83()
            v20 = "G_Preflop"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US4_3(v22, v23, v24, v25, v26, v27): # G_River
            del v0
            v28 = method95(v22, v23, v24, v25, v26, v27)
            del v22, v23, v24, v25, v26, v27
            v29 = "G_River"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US4_4(v31, v32, v33, v34, v35, v36): # G_Round
            del v0
            v37 = method95(v31, v32, v33, v34, v35, v36)
            del v31, v32, v33, v34, v35, v36
            v38 = "G_Round"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case US4_5(v40, v41, v42, v43, v44, v45, v46): # G_Round'
            del v0
            v47 = method101(v40, v41, v42, v43, v44, v45, v46)
            del v40, v41, v42, v43, v44, v45, v46
            v48 = "G_Round'"
            v49 = [v48,v47]
            del v47, v48
            return v49
        case US4_6(v50, v51, v52, v53, v54, v55): # G_Showdown
            del v0
            v56 = method95(v50, v51, v52, v53, v54, v55)
            del v50, v51, v52, v53, v54, v55
            v57 = "G_Showdown"
            v58 = [v57,v56]
            del v56, v57
            return v58
        case US4_7(v59, v60, v61, v62, v63, v64): # G_Turn
            del v0
            v65 = method95(v59, v60, v61, v62, v63, v64)
            del v59, v60, v61, v62, v63, v64
            v66 = "G_Turn"
            v67 = [v66,v65]
            del v65, v66
            return v67
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method93(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method83()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method94(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method103(v0 : US0) -> object:
    match v0:
        case US0_0(): # Computer
            del v0
            v1 = method83()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US0_1(): # Human
            del v0
            v4 = method83()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
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
        v10 = method103(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method104(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method83()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method95(v4, v5, v6, v7, v8, v9)
            del v4, v5, v6, v7, v8, v9
            v11 = "GameOver"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US6_2(v13, v14, v15, v16, v17, v18): # WaitingForActionFromPlayerId
            del v0
            v19 = method95(v13, v14, v15, v16, v17, v18)
            del v13, v14, v15, v16, v17, v18
            v20 = "WaitingForActionFromPlayerId"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method92(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method93(v0)
    del v0
    v4 = method102(v1)
    del v1
    v5 = method104(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method70(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method71(v0, v1)
    del v0, v1
    v6 = method92(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method105(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method74(v0)
    del v0
    v4 = method102(v1)
    del v1
    v5 = method104(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method69(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method70(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    v9 = method105(v5, v6, v7)
    del v5, v6, v7
    v10 = {'game_state': v8, 'ui_state': v9}
    del v8, v9
    return v10
def method68(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6, v5 : static_array_list, v6 : static_array, v7 : US6) -> object:
    v8 = method69(v0, v1, v2, v3, v4, v5, v6, v7)
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
    v9 = cp.empty(6304,dtype=cp.uint8)
    v10 = cp.empty(6224,dtype=cp.uint8)
    method0(v8, v4)
    del v4
    method7(v9, v5, v3, v6, v0, v7)
    del v0, v3, v5, v6, v7
    v11 = "Going to run the kernel."
    method36(v11)
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
    method36(v16)
    del v16
    v17 = v15 - v12
    del v12, v15
    method37(v17)
    del v17
    print()
    v18, v19, v20, v21, v22 = method38(v9)
    del v9
    v23, v24, v25 = method66(v10)
    del v10
    return method68(v18, v19, v20, v21, v22, v23, v24, v25)

if __name__ == '__main__': print(main())
