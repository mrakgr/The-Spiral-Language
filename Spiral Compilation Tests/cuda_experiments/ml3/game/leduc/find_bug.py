kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <curand_kernel.h>
struct US1;
struct US2;
struct US0;
struct US3;
struct US4;
struct US7;
struct US6;
struct US5;
struct US8;
struct Tuple0;
struct Tuple1;
struct Tuple2;
__device__ unsigned long loop_2(unsigned long v0, curandStatePhilox4_32_10_t * v1);
struct US9;
__device__ long tag_4(US3 v0);
__device__ bool is_pair_5(long v0, long v1);
__device__ Tuple2 order_6(long v0, long v1);
__device__ US9 compare_hands_3(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5);
__device__ US6 play_loop_inner_1(static_array_list<US3,6l,long> & v0, static_array_list<US4,32l,long> & v1, static_array<US2,2l> v2, US6 v3);
__device__ Tuple0 play_loop_0(US5 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US3,6l,long> & v3, static_array_list<US4,32l,long> & v4, US6 v5);
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
    US5 v0;
    static_array<US2,2l> v1;
    US8 v2;
    __device__ Tuple0(US5 t0, static_array<US2,2l> t1, US8 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    US6 v1;
    bool v0;
    __device__ Tuple1(bool t0, US6 t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    long v0;
    long v1;
    __device__ Tuple2(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple2() = default;
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
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
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
__device__ inline bool while_method_1(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
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
__device__ inline bool while_method_2(bool v0, US6 v1){
    return v0;
}
__device__ unsigned long loop_2(unsigned long v0, curandStatePhilox4_32_10_t * v1){
    unsigned long v2;
    v2 = curand(v1);
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
        return loop_2(v0, v1);
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
__device__ long tag_4(US3 v0){
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
__device__ bool is_pair_5(long v0, long v1){
    bool v2;
    v2 = v1 == v0;
    return v2;
}
__device__ Tuple2 order_6(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    if (v2){
        return Tuple2(v1, v0);
    } else {
        return Tuple2(v0, v1);
    }
}
__device__ US9 compare_hands_3(US7 v0, bool v1, static_array<US3,2l> v2, long v3, static_array<long,2l> v4, long v5){
    switch (v0.tag) {
        case 0: { // None
            printf("%s\n", "Expected the community card to be present in the table.");
            asm("exit;");
            break;
        }
        case 1: { // Some
            US3 v7 = v0.v.case1.v0;
            long v8;
            v8 = tag_4(v7);
            US3 v9;
            v9 = v2.v[0l];
            long v10;
            v10 = tag_4(v9);
            US3 v11;
            v11 = v2.v[1l];
            long v12;
            v12 = tag_4(v11);
            bool v13;
            v13 = is_pair_5(v8, v10);
            bool v14;
            v14 = is_pair_5(v8, v12);
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
                    Tuple2 tmp8 = order_6(v8, v10);
                    v25 = tmp8.v0; v26 = tmp8.v1;
                    long v27; long v28;
                    Tuple2 tmp9 = order_6(v8, v12);
                    v27 = tmp9.v0; v28 = tmp9.v1;
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
__device__ US6 play_loop_inner_1(static_array_list<US3,6l,long> & v0, static_array_list<US4,32l,long> & v1, static_array<US2,2l> v2, US6 v3){
    static_array_list<US4,32l,long> & v4 = v1;
    static_array_list<US3,6l,long> & v5 = v0;
    bool v6; US6 v7;
    Tuple1 tmp0 = Tuple1(true, v3);
    v6 = tmp0.v0; v7 = tmp0.v1;
    while (while_method_2(v6, v7)){
        bool v503; US6 v504;
        switch (v7.tag) {
            case 0: { // ChanceCommunityCard
                US7 v402 = v7.v.case0.v0; bool v403 = v7.v.case0.v1; static_array<US3,2l> v404 = v7.v.case0.v2; long v405 = v7.v.case0.v3; static_array<long,2l> v406 = v7.v.case0.v4; long v407 = v7.v.case0.v5;
                long v408;
                v408 = v5.length;
                long v409;
                v409 = v408 - 1l;
                bool v410;
                v410 = v409 >= 0l;
                bool v411;
                v411 = v410 == false;
                if (v411){
                    assert("The length before popping has to be greater than 0." && v410);
                } else {
                }
                bool v412;
                v412 = 0l <= v409;
                bool v415;
                if (v412){
                    long v413;
                    v413 = v5.length;
                    bool v414;
                    v414 = v409 < v413;
                    v415 = v414;
                } else {
                    v415 = false;
                }
                bool v416;
                v416 = v415 == false;
                if (v416){
                    assert("The read index needs to be in range for the static array list." && v415);
                } else {
                }
                US3 v417;
                v417 = v5.v[v409];
                v5.length = v409;
                long v418;
                v418 = v4.length;
                bool v419;
                v419 = v418 < 32l;
                bool v420;
                v420 = v419 == false;
                if (v420){
                    assert("The length has to be less than the maximum length of the array." && v419);
                } else {
                }
                long v421;
                v421 = v418 + 1l;
                v4.length = v421;
                bool v422;
                v422 = 0l <= v418;
                bool v425;
                if (v422){
                    long v423;
                    v423 = v4.length;
                    bool v424;
                    v424 = v418 < v423;
                    v425 = v424;
                } else {
                    v425 = false;
                }
                bool v426;
                v426 = v425 == false;
                if (v426){
                    assert("The set index needs to be in range for the static array list." && v425);
                } else {
                }
                US4 v427;
                v427 = US4_0(v417);
                v4.v[v418] = v427;
                long v428;
                v428 = 2l;
                long v429; long v430;
                Tuple2 tmp1 = Tuple2(0l, 0l);
                v429 = tmp1.v0; v430 = tmp1.v1;
                while (while_method_0(v429)){
                    bool v432;
                    v432 = 0l <= v429;
                    bool v434;
                    if (v432){
                        bool v433;
                        v433 = v429 < 2l;
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
                    v436 = v406.v[v429];
                    bool v437;
                    v437 = v430 >= v436;
                    long v438;
                    if (v437){
                        v438 = v430;
                    } else {
                        v438 = v436;
                    }
                    v430 = v438;
                    v429 += 1l ;
                }
                static_array<long,2l> v439;
                long v440;
                v440 = 0l;
                while (while_method_0(v440)){
                    bool v442;
                    v442 = 0l <= v440;
                    bool v444;
                    if (v442){
                        bool v443;
                        v443 = v440 < 2l;
                        v444 = v443;
                    } else {
                        v444 = false;
                    }
                    bool v445;
                    v445 = v444 == false;
                    if (v445){
                        assert("The read index needs to be in range for the static array." && v444);
                    } else {
                    }
                    v439.v[v440] = v430;
                    v440 += 1l ;
                }
                US7 v446;
                v446 = US7_1(v417);
                US6 v447;
                v447 = US6_2(v446, true, v404, 0l, v439, v428);
                v503 = true; v504 = v447;
                break;
            }
            case 1: { // ChanceInit
                long v448;
                v448 = v5.length;
                long v449;
                v449 = v448 - 1l;
                bool v450;
                v450 = v449 >= 0l;
                bool v451;
                v451 = v450 == false;
                if (v451){
                    assert("The length before popping has to be greater than 0." && v450);
                } else {
                }
                bool v452;
                v452 = 0l <= v449;
                bool v455;
                if (v452){
                    long v453;
                    v453 = v5.length;
                    bool v454;
                    v454 = v449 < v453;
                    v455 = v454;
                } else {
                    v455 = false;
                }
                bool v456;
                v456 = v455 == false;
                if (v456){
                    assert("The read index needs to be in range for the static array list." && v455);
                } else {
                }
                US3 v457;
                v457 = v5.v[v449];
                v5.length = v449;
                long v458;
                v458 = v5.length;
                long v459;
                v459 = v458 - 1l;
                bool v460;
                v460 = v459 >= 0l;
                bool v461;
                v461 = v460 == false;
                if (v461){
                    assert("The length before popping has to be greater than 0." && v460);
                } else {
                }
                bool v462;
                v462 = 0l <= v459;
                bool v465;
                if (v462){
                    long v463;
                    v463 = v5.length;
                    bool v464;
                    v464 = v459 < v463;
                    v465 = v464;
                } else {
                    v465 = false;
                }
                bool v466;
                v466 = v465 == false;
                if (v466){
                    assert("The read index needs to be in range for the static array list." && v465);
                } else {
                }
                US3 v467;
                v467 = v5.v[v459];
                v5.length = v459;
                long v468;
                v468 = v4.length;
                bool v469;
                v469 = v468 < 32l;
                bool v470;
                v470 = v469 == false;
                if (v470){
                    assert("The length has to be less than the maximum length of the array." && v469);
                } else {
                }
                long v471;
                v471 = v468 + 1l;
                v4.length = v471;
                bool v472;
                v472 = 0l <= v468;
                bool v475;
                if (v472){
                    long v473;
                    v473 = v4.length;
                    bool v474;
                    v474 = v468 < v473;
                    v475 = v474;
                } else {
                    v475 = false;
                }
                bool v476;
                v476 = v475 == false;
                if (v476){
                    assert("The set index needs to be in range for the static array list." && v475);
                } else {
                }
                US4 v477;
                v477 = US4_2(0l, v457);
                v4.v[v468] = v477;
                long v478;
                v478 = v4.length;
                bool v479;
                v479 = v478 < 32l;
                bool v480;
                v480 = v479 == false;
                if (v480){
                    assert("The length has to be less than the maximum length of the array." && v479);
                } else {
                }
                long v481;
                v481 = v478 + 1l;
                v4.length = v481;
                bool v482;
                v482 = 0l <= v478;
                bool v485;
                if (v482){
                    long v483;
                    v483 = v4.length;
                    bool v484;
                    v484 = v478 < v483;
                    v485 = v484;
                } else {
                    v485 = false;
                }
                bool v486;
                v486 = v485 == false;
                if (v486){
                    assert("The set index needs to be in range for the static array list." && v485);
                } else {
                }
                US4 v487;
                v487 = US4_2(1l, v467);
                v4.v[v478] = v487;
                long v488;
                v488 = 2l;
                static_array<long,2l> v489;
                v489.v[0l] = 1l;
                v489.v[1l] = 1l;
                static_array<US3,2l> v490;
                v490.v[0l] = v457;
                v490.v[1l] = v467;
                US7 v491;
                v491 = US7_0();
                US6 v492;
                v492 = US6_2(v491, true, v490, 0l, v489, v488);
                v503 = true; v504 = v492;
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
                        curandStatePhilox4_32_10_t * v103 = &v102;
                        curand_init(v101,0ull,0ull,v103);
                        long v104;
                        v104 = v71.length;
                        long v105;
                        v105 = v104 - 1l;
                        long v106;
                        v106 = 0l;
                        while (while_method_1(v105, v106)){
                            long v108;
                            v108 = v71.length;
                            long v109;
                            v109 = v108 - v106;
                            unsigned long v110;
                            v110 = (unsigned long)v109;
                            unsigned long v111;
                            v111 = loop_2(v110, v103);
                            unsigned long v112;
                            v112 = (unsigned long)v106;
                            unsigned long v113;
                            v113 = v111 + v112;
                            long v114;
                            v114 = (long)v113;
                            bool v115;
                            v115 = 0l <= v106;
                            bool v118;
                            if (v115){
                                long v116;
                                v116 = v71.length;
                                bool v117;
                                v117 = v106 < v116;
                                v118 = v117;
                            } else {
                                v118 = false;
                            }
                            bool v119;
                            v119 = v118 == false;
                            if (v119){
                                assert("The read index needs to be in range for the static array list." && v118);
                            } else {
                            }
                            US1 v120;
                            v120 = v71.v[v106];
                            bool v121;
                            v121 = 0l <= v114;
                            bool v124;
                            if (v121){
                                long v122;
                                v122 = v71.length;
                                bool v123;
                                v123 = v114 < v122;
                                v124 = v123;
                            } else {
                                v124 = false;
                            }
                            bool v125;
                            v125 = v124 == false;
                            if (v125){
                                assert("The read index needs to be in range for the static array list." && v124);
                            } else {
                            }
                            US1 v126;
                            v126 = v71.v[v114];
                            bool v129;
                            if (v115){
                                long v127;
                                v127 = v71.length;
                                bool v128;
                                v128 = v106 < v127;
                                v129 = v128;
                            } else {
                                v129 = false;
                            }
                            bool v130;
                            v130 = v129 == false;
                            if (v130){
                                assert("The set index needs to be in range for the static array list." && v129);
                            } else {
                            }
                            v71.v[v106] = v126;
                            bool v133;
                            if (v121){
                                long v131;
                                v131 = v71.length;
                                bool v132;
                                v132 = v114 < v131;
                                v133 = v132;
                            } else {
                                v133 = false;
                            }
                            bool v134;
                            v134 = v133 == false;
                            if (v134){
                                assert("The set index needs to be in range for the static array list." && v133);
                            } else {
                            }
                            v71.v[v114] = v120;
                            v106 += 1l ;
                        }
                        long v135;
                        v135 = v71.length;
                        long v136;
                        v136 = v135 - 1l;
                        bool v137;
                        v137 = v136 >= 0l;
                        bool v138;
                        v138 = v137 == false;
                        if (v138){
                            assert("The length before popping has to be greater than 0." && v137);
                        } else {
                        }
                        bool v139;
                        v139 = 0l <= v136;
                        bool v142;
                        if (v139){
                            long v140;
                            v140 = v71.length;
                            bool v141;
                            v141 = v136 < v140;
                            v142 = v141;
                        } else {
                            v142 = false;
                        }
                        bool v143;
                        v143 = v142 == false;
                        if (v143){
                            assert("The read index needs to be in range for the static array list." && v142);
                        } else {
                        }
                        US1 v144;
                        v144 = v71.v[v136];
                        v71.length = v136;
                        long v145;
                        v145 = v4.length;
                        bool v146;
                        v146 = v145 < 32l;
                        bool v147;
                        v147 = v146 == false;
                        if (v147){
                            assert("The length has to be less than the maximum length of the array." && v146);
                        } else {
                        }
                        long v148;
                        v148 = v145 + 1l;
                        v4.length = v148;
                        bool v149;
                        v149 = 0l <= v145;
                        bool v152;
                        if (v149){
                            long v150;
                            v150 = v4.length;
                            bool v151;
                            v151 = v145 < v150;
                            v152 = v151;
                        } else {
                            v152 = false;
                        }
                        bool v153;
                        v153 = v152 == false;
                        if (v153){
                            assert("The set index needs to be in range for the static array list." && v152);
                        } else {
                        }
                        US4 v154;
                        v154 = US4_1(v63, v144);
                        v4.v[v145] = v154;
                        US6 v266;
                        switch (v60.tag) {
                            case 0: { // None
                                switch (v144.tag) {
                                    case 0: { // Call
                                        if (v61){
                                            bool v220;
                                            v220 = v63 == 0l;
                                            long v221;
                                            if (v220){
                                                v221 = 1l;
                                            } else {
                                                v221 = 0l;
                                            }
                                            v266 = US6_2(v60, false, v62, v221, v64, v65);
                                        } else {
                                            v266 = US6_0(v60, v61, v62, v63, v64, v65);
                                        }
                                        break;
                                    }
                                    case 1: { // Fold
                                        v266 = US6_5(v60, v61, v62, v63, v64, v65);
                                        break;
                                    }
                                    case 2: { // Raise
                                        if (v90){
                                            bool v225;
                                            v225 = v63 == 0l;
                                            long v226;
                                            if (v225){
                                                v226 = 1l;
                                            } else {
                                                v226 = 0l;
                                            }
                                            long v227;
                                            v227 = -1l + v65;
                                            long v228; long v229;
                                            Tuple2 tmp2 = Tuple2(0l, 0l);
                                            v228 = tmp2.v0; v229 = tmp2.v1;
                                            while (while_method_0(v228)){
                                                bool v231;
                                                v231 = 0l <= v228;
                                                bool v233;
                                                if (v231){
                                                    bool v232;
                                                    v232 = v228 < 2l;
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
                                                v235 = v64.v[v228];
                                                bool v236;
                                                v236 = v229 >= v235;
                                                long v237;
                                                if (v236){
                                                    v237 = v229;
                                                } else {
                                                    v237 = v235;
                                                }
                                                v229 = v237;
                                                v228 += 1l ;
                                            }
                                            static_array<long,2l> v238;
                                            long v239;
                                            v239 = 0l;
                                            while (while_method_0(v239)){
                                                bool v241;
                                                v241 = 0l <= v239;
                                                bool v243;
                                                if (v241){
                                                    bool v242;
                                                    v242 = v239 < 2l;
                                                    v243 = v242;
                                                } else {
                                                    v243 = false;
                                                }
                                                bool v244;
                                                v244 = v243 == false;
                                                if (v244){
                                                    assert("The read index needs to be in range for the static array." && v243);
                                                } else {
                                                }
                                                v238.v[v239] = v229;
                                                v239 += 1l ;
                                            }
                                            static_array<long,2l> v245;
                                            long v246;
                                            v246 = 0l;
                                            while (while_method_0(v246)){
                                                bool v248;
                                                v248 = 0l <= v246;
                                                bool v250;
                                                if (v248){
                                                    bool v249;
                                                    v249 = v246 < 2l;
                                                    v250 = v249;
                                                } else {
                                                    v250 = false;
                                                }
                                                bool v251;
                                                v251 = v250 == false;
                                                if (v251){
                                                    assert("The read index needs to be in range for the static array." && v250);
                                                } else {
                                                }
                                                long v252;
                                                v252 = v238.v[v246];
                                                bool v253;
                                                v253 = v246 == v63;
                                                long v255;
                                                if (v253){
                                                    long v254;
                                                    v254 = v252 + 2l;
                                                    v255 = v254;
                                                } else {
                                                    v255 = v252;
                                                }
                                                bool v257;
                                                if (v248){
                                                    bool v256;
                                                    v256 = v246 < 2l;
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
                                                v245.v[v246] = v255;
                                                v246 += 1l ;
                                            }
                                            v266 = US6_2(v60, false, v62, v226, v245, v227);
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
                                US3 v155 = v60.v.case1.v0;
                                switch (v144.tag) {
                                    case 0: { // Call
                                        if (v61){
                                            bool v157;
                                            v157 = v63 == 0l;
                                            long v158;
                                            if (v157){
                                                v158 = 1l;
                                            } else {
                                                v158 = 0l;
                                            }
                                            v266 = US6_2(v60, false, v62, v158, v64, v65);
                                        } else {
                                            long v160; long v161;
                                            Tuple2 tmp3 = Tuple2(0l, 0l);
                                            v160 = tmp3.v0; v161 = tmp3.v1;
                                            while (while_method_0(v160)){
                                                bool v163;
                                                v163 = 0l <= v160;
                                                bool v165;
                                                if (v163){
                                                    bool v164;
                                                    v164 = v160 < 2l;
                                                    v165 = v164;
                                                } else {
                                                    v165 = false;
                                                }
                                                bool v166;
                                                v166 = v165 == false;
                                                if (v166){
                                                    assert("The read index needs to be in range for the static array." && v165);
                                                } else {
                                                }
                                                long v167;
                                                v167 = v64.v[v160];
                                                bool v168;
                                                v168 = v161 >= v167;
                                                long v169;
                                                if (v168){
                                                    v169 = v161;
                                                } else {
                                                    v169 = v167;
                                                }
                                                v161 = v169;
                                                v160 += 1l ;
                                            }
                                            static_array<long,2l> v170;
                                            long v171;
                                            v171 = 0l;
                                            while (while_method_0(v171)){
                                                bool v173;
                                                v173 = 0l <= v171;
                                                bool v175;
                                                if (v173){
                                                    bool v174;
                                                    v174 = v171 < 2l;
                                                    v175 = v174;
                                                } else {
                                                    v175 = false;
                                                }
                                                bool v176;
                                                v176 = v175 == false;
                                                if (v176){
                                                    assert("The read index needs to be in range for the static array." && v175);
                                                } else {
                                                }
                                                v170.v[v171] = v161;
                                                v171 += 1l ;
                                            }
                                            v266 = US6_4(v60, v61, v62, v63, v170, v65);
                                        }
                                        break;
                                    }
                                    case 1: { // Fold
                                        v266 = US6_5(v60, v61, v62, v63, v64, v65);
                                        break;
                                    }
                                    case 2: { // Raise
                                        if (v90){
                                            bool v179;
                                            v179 = v63 == 0l;
                                            long v180;
                                            if (v179){
                                                v180 = 1l;
                                            } else {
                                                v180 = 0l;
                                            }
                                            long v181;
                                            v181 = -1l + v65;
                                            long v182; long v183;
                                            Tuple2 tmp4 = Tuple2(0l, 0l);
                                            v182 = tmp4.v0; v183 = tmp4.v1;
                                            while (while_method_0(v182)){
                                                bool v185;
                                                v185 = 0l <= v182;
                                                bool v187;
                                                if (v185){
                                                    bool v186;
                                                    v186 = v182 < 2l;
                                                    v187 = v186;
                                                } else {
                                                    v187 = false;
                                                }
                                                bool v188;
                                                v188 = v187 == false;
                                                if (v188){
                                                    assert("The read index needs to be in range for the static array." && v187);
                                                } else {
                                                }
                                                long v189;
                                                v189 = v64.v[v182];
                                                bool v190;
                                                v190 = v183 >= v189;
                                                long v191;
                                                if (v190){
                                                    v191 = v183;
                                                } else {
                                                    v191 = v189;
                                                }
                                                v183 = v191;
                                                v182 += 1l ;
                                            }
                                            static_array<long,2l> v192;
                                            long v193;
                                            v193 = 0l;
                                            while (while_method_0(v193)){
                                                bool v195;
                                                v195 = 0l <= v193;
                                                bool v197;
                                                if (v195){
                                                    bool v196;
                                                    v196 = v193 < 2l;
                                                    v197 = v196;
                                                } else {
                                                    v197 = false;
                                                }
                                                bool v198;
                                                v198 = v197 == false;
                                                if (v198){
                                                    assert("The read index needs to be in range for the static array." && v197);
                                                } else {
                                                }
                                                v192.v[v193] = v183;
                                                v193 += 1l ;
                                            }
                                            static_array<long,2l> v199;
                                            long v200;
                                            v200 = 0l;
                                            while (while_method_0(v200)){
                                                bool v202;
                                                v202 = 0l <= v200;
                                                bool v204;
                                                if (v202){
                                                    bool v203;
                                                    v203 = v200 < 2l;
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
                                                long v206;
                                                v206 = v192.v[v200];
                                                bool v207;
                                                v207 = v200 == v63;
                                                long v209;
                                                if (v207){
                                                    long v208;
                                                    v208 = v206 + 4l;
                                                    v209 = v208;
                                                } else {
                                                    v209 = v206;
                                                }
                                                bool v211;
                                                if (v202){
                                                    bool v210;
                                                    v210 = v200 < 2l;
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
                                                v199.v[v200] = v209;
                                                v200 += 1l ;
                                            }
                                            v266 = US6_2(v60, false, v62, v180, v199, v181);
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
                        v503 = true; v504 = v266;
                        break;
                    }
                    case 1: { // Human
                        v503 = false; v504 = v7;
                        break;
                    }
                    default: {
                        assert("Invalid tag." && false);
                    }
                }
                break;
            }
            case 3: { // RoundWithAction
                US7 v271 = v7.v.case3.v0; bool v272 = v7.v.case3.v1; static_array<US3,2l> v273 = v7.v.case3.v2; long v274 = v7.v.case3.v3; static_array<long,2l> v275 = v7.v.case3.v4; long v276 = v7.v.case3.v5; US1 v277 = v7.v.case3.v6;
                long v278;
                v278 = v4.length;
                bool v279;
                v279 = v278 < 32l;
                bool v280;
                v280 = v279 == false;
                if (v280){
                    assert("The length has to be less than the maximum length of the array." && v279);
                } else {
                }
                long v281;
                v281 = v278 + 1l;
                v4.length = v281;
                bool v282;
                v282 = 0l <= v278;
                bool v285;
                if (v282){
                    long v283;
                    v283 = v4.length;
                    bool v284;
                    v284 = v278 < v283;
                    v285 = v284;
                } else {
                    v285 = false;
                }
                bool v286;
                v286 = v285 == false;
                if (v286){
                    assert("The set index needs to be in range for the static array list." && v285);
                } else {
                }
                US4 v287;
                v287 = US4_1(v274, v277);
                v4.v[v278] = v287;
                US6 v401;
                switch (v271.tag) {
                    case 0: { // None
                        switch (v277.tag) {
                            case 0: { // Call
                                if (v272){
                                    bool v354;
                                    v354 = v274 == 0l;
                                    long v355;
                                    if (v354){
                                        v355 = 1l;
                                    } else {
                                        v355 = 0l;
                                    }
                                    v401 = US6_2(v271, false, v273, v355, v275, v276);
                                } else {
                                    v401 = US6_0(v271, v272, v273, v274, v275, v276);
                                }
                                break;
                            }
                            case 1: { // Fold
                                v401 = US6_5(v271, v272, v273, v274, v275, v276);
                                break;
                            }
                            case 2: { // Raise
                                bool v359;
                                v359 = v276 > 0l;
                                if (v359){
                                    bool v360;
                                    v360 = v274 == 0l;
                                    long v361;
                                    if (v360){
                                        v361 = 1l;
                                    } else {
                                        v361 = 0l;
                                    }
                                    long v362;
                                    v362 = -1l + v276;
                                    long v363; long v364;
                                    Tuple2 tmp5 = Tuple2(0l, 0l);
                                    v363 = tmp5.v0; v364 = tmp5.v1;
                                    while (while_method_0(v363)){
                                        bool v366;
                                        v366 = 0l <= v363;
                                        bool v368;
                                        if (v366){
                                            bool v367;
                                            v367 = v363 < 2l;
                                            v368 = v367;
                                        } else {
                                            v368 = false;
                                        }
                                        bool v369;
                                        v369 = v368 == false;
                                        if (v369){
                                            assert("The read index needs to be in range for the static array." && v368);
                                        } else {
                                        }
                                        long v370;
                                        v370 = v275.v[v363];
                                        bool v371;
                                        v371 = v364 >= v370;
                                        long v372;
                                        if (v371){
                                            v372 = v364;
                                        } else {
                                            v372 = v370;
                                        }
                                        v364 = v372;
                                        v363 += 1l ;
                                    }
                                    static_array<long,2l> v373;
                                    long v374;
                                    v374 = 0l;
                                    while (while_method_0(v374)){
                                        bool v376;
                                        v376 = 0l <= v374;
                                        bool v378;
                                        if (v376){
                                            bool v377;
                                            v377 = v374 < 2l;
                                            v378 = v377;
                                        } else {
                                            v378 = false;
                                        }
                                        bool v379;
                                        v379 = v378 == false;
                                        if (v379){
                                            assert("The read index needs to be in range for the static array." && v378);
                                        } else {
                                        }
                                        v373.v[v374] = v364;
                                        v374 += 1l ;
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
                                        v387 = v373.v[v381];
                                        bool v388;
                                        v388 = v381 == v274;
                                        long v390;
                                        if (v388){
                                            long v389;
                                            v389 = v387 + 2l;
                                            v390 = v389;
                                        } else {
                                            v390 = v387;
                                        }
                                        bool v392;
                                        if (v383){
                                            bool v391;
                                            v391 = v381 < 2l;
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
                                        v380.v[v381] = v390;
                                        v381 += 1l ;
                                    }
                                    v401 = US6_2(v271, false, v273, v361, v380, v362);
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
                        US3 v288 = v271.v.case1.v0;
                        switch (v277.tag) {
                            case 0: { // Call
                                if (v272){
                                    bool v290;
                                    v290 = v274 == 0l;
                                    long v291;
                                    if (v290){
                                        v291 = 1l;
                                    } else {
                                        v291 = 0l;
                                    }
                                    v401 = US6_2(v271, false, v273, v291, v275, v276);
                                } else {
                                    long v293; long v294;
                                    Tuple2 tmp6 = Tuple2(0l, 0l);
                                    v293 = tmp6.v0; v294 = tmp6.v1;
                                    while (while_method_0(v293)){
                                        bool v296;
                                        v296 = 0l <= v293;
                                        bool v298;
                                        if (v296){
                                            bool v297;
                                            v297 = v293 < 2l;
                                            v298 = v297;
                                        } else {
                                            v298 = false;
                                        }
                                        bool v299;
                                        v299 = v298 == false;
                                        if (v299){
                                            assert("The read index needs to be in range for the static array." && v298);
                                        } else {
                                        }
                                        long v300;
                                        v300 = v275.v[v293];
                                        bool v301;
                                        v301 = v294 >= v300;
                                        long v302;
                                        if (v301){
                                            v302 = v294;
                                        } else {
                                            v302 = v300;
                                        }
                                        v294 = v302;
                                        v293 += 1l ;
                                    }
                                    static_array<long,2l> v303;
                                    long v304;
                                    v304 = 0l;
                                    while (while_method_0(v304)){
                                        bool v306;
                                        v306 = 0l <= v304;
                                        bool v308;
                                        if (v306){
                                            bool v307;
                                            v307 = v304 < 2l;
                                            v308 = v307;
                                        } else {
                                            v308 = false;
                                        }
                                        bool v309;
                                        v309 = v308 == false;
                                        if (v309){
                                            assert("The read index needs to be in range for the static array." && v308);
                                        } else {
                                        }
                                        v303.v[v304] = v294;
                                        v304 += 1l ;
                                    }
                                    v401 = US6_4(v271, v272, v273, v274, v303, v276);
                                }
                                break;
                            }
                            case 1: { // Fold
                                v401 = US6_5(v271, v272, v273, v274, v275, v276);
                                break;
                            }
                            case 2: { // Raise
                                bool v312;
                                v312 = v276 > 0l;
                                if (v312){
                                    bool v313;
                                    v313 = v274 == 0l;
                                    long v314;
                                    if (v313){
                                        v314 = 1l;
                                    } else {
                                        v314 = 0l;
                                    }
                                    long v315;
                                    v315 = -1l + v276;
                                    long v316; long v317;
                                    Tuple2 tmp7 = Tuple2(0l, 0l);
                                    v316 = tmp7.v0; v317 = tmp7.v1;
                                    while (while_method_0(v316)){
                                        bool v319;
                                        v319 = 0l <= v316;
                                        bool v321;
                                        if (v319){
                                            bool v320;
                                            v320 = v316 < 2l;
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
                                        v323 = v275.v[v316];
                                        bool v324;
                                        v324 = v317 >= v323;
                                        long v325;
                                        if (v324){
                                            v325 = v317;
                                        } else {
                                            v325 = v323;
                                        }
                                        v317 = v325;
                                        v316 += 1l ;
                                    }
                                    static_array<long,2l> v326;
                                    long v327;
                                    v327 = 0l;
                                    while (while_method_0(v327)){
                                        bool v329;
                                        v329 = 0l <= v327;
                                        bool v331;
                                        if (v329){
                                            bool v330;
                                            v330 = v327 < 2l;
                                            v331 = v330;
                                        } else {
                                            v331 = false;
                                        }
                                        bool v332;
                                        v332 = v331 == false;
                                        if (v332){
                                            assert("The read index needs to be in range for the static array." && v331);
                                        } else {
                                        }
                                        v326.v[v327] = v317;
                                        v327 += 1l ;
                                    }
                                    static_array<long,2l> v333;
                                    long v334;
                                    v334 = 0l;
                                    while (while_method_0(v334)){
                                        bool v336;
                                        v336 = 0l <= v334;
                                        bool v338;
                                        if (v336){
                                            bool v337;
                                            v337 = v334 < 2l;
                                            v338 = v337;
                                        } else {
                                            v338 = false;
                                        }
                                        bool v339;
                                        v339 = v338 == false;
                                        if (v339){
                                            assert("The read index needs to be in range for the static array." && v338);
                                        } else {
                                        }
                                        long v340;
                                        v340 = v326.v[v334];
                                        bool v341;
                                        v341 = v334 == v274;
                                        long v343;
                                        if (v341){
                                            long v342;
                                            v342 = v340 + 4l;
                                            v343 = v342;
                                        } else {
                                            v343 = v340;
                                        }
                                        bool v345;
                                        if (v336){
                                            bool v344;
                                            v344 = v334 < 2l;
                                            v345 = v344;
                                        } else {
                                            v345 = false;
                                        }
                                        bool v346;
                                        v346 = v345 == false;
                                        if (v346){
                                            assert("The read index needs to be in range for the static array." && v345);
                                        } else {
                                        }
                                        v333.v[v334] = v343;
                                        v334 += 1l ;
                                    }
                                    v401 = US6_2(v271, false, v273, v314, v333, v315);
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
                v503 = true; v504 = v401;
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
                v43 = compare_hands_3(v32, v33, v34, v35, v36, v37);
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
                v503 = false; v504 = v7;
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
                v503 = false; v504 = v7;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        v6 = v503;
        v7 = v504;
    }
    return v7;
}
__device__ Tuple0 play_loop_0(US5 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US3,6l,long> & v3, static_array_list<US4,32l,long> & v4, US6 v5){
    US6 v6;
    v6 = play_loop_inner_1(v3, v4, v1, v5);
    switch (v6.tag) {
        case 2: { // Round
            US7 v7 = v6.v.case2.v0; bool v8 = v6.v.case2.v1; static_array<US3,2l> v9 = v6.v.case2.v2; long v10 = v6.v.case2.v3; static_array<long,2l> v11 = v6.v.case2.v4; long v12 = v6.v.case2.v5;
            US5 v13;
            v13 = US5_1(v6);
            US8 v14;
            v14 = US8_2(v7, v8, v9, v10, v11, v12);
            return Tuple0(v13, v1, v14);
            break;
        }
        case 4: { // TerminalCall
            US7 v15 = v6.v.case4.v0; bool v16 = v6.v.case4.v1; static_array<US3,2l> v17 = v6.v.case4.v2; long v18 = v6.v.case4.v3; static_array<long,2l> v19 = v6.v.case4.v4; long v20 = v6.v.case4.v5;
            US5 v21;
            v21 = US5_0();
            US8 v22;
            v22 = US8_1(v15, v16, v17, v18, v19, v20);
            return Tuple0(v21, v1, v22);
            break;
        }
        case 5: { // TerminalFold
            US7 v23 = v6.v.case5.v0; bool v24 = v6.v.case5.v1; static_array<US3,2l> v25 = v6.v.case5.v2; long v26 = v6.v.case5.v3; static_array<long,2l> v27 = v6.v.case5.v4; long v28 = v6.v.case5.v5;
            US5 v29;
            v29 = US5_0();
            US8 v30;
            v30 = US8_1(v23, v24, v25, v26, v27, v28);
            return Tuple0(v29, v1, v30);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
extern "C" __global__ void entry0(unsigned char * v0, unsigned char * v1, unsigned char * v2) {
    long v3;
    v3 = threadIdx.x;
    long v4;
    v4 = blockIdx.x;
    long v5;
    v5 = v3 + v4;
    bool v6;
    v6 = v5 == 0l;
    if (v6){
        long * v7;
        v7 = (long *)(v1+0ull);
        long v8;
        v8 = v7[0l];
        US0 v37;
        switch (v8) {
            case 0: {
                long * v10;
                v10 = (long *)(v1+4ull);
                long v11;
                v11 = v10[0l];
                US1 v16;
                switch (v11) {
                    case 0: {
                        v16 = US1_0();
                        break;
                    }
                    case 1: {
                        v16 = US1_1();
                        break;
                    }
                    case 2: {
                        v16 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v37 = US0_0(v16);
                break;
            }
            case 1: {
                static_array<US2,2l> v18;
                long v19;
                v19 = 0l;
                while (while_method_0(v19)){
                    unsigned long long v21;
                    v21 = (unsigned long long)v19;
                    unsigned long long v22;
                    v22 = v21 * 4ull;
                    unsigned long long v23;
                    v23 = 4ull + v22;
                    unsigned char * v24;
                    v24 = (unsigned char *)(v1+v23);
                    long * v25;
                    v25 = (long *)(v24+0ull);
                    long v26;
                    v26 = v25[0l];
                    US2 v30;
                    switch (v26) {
                        case 0: {
                            v30 = US2_0();
                            break;
                        }
                        case 1: {
                            v30 = US2_1();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v31;
                    v31 = 0l <= v19;
                    bool v33;
                    if (v31){
                        bool v32;
                        v32 = v19 < 2l;
                        v33 = v32;
                    } else {
                        v33 = false;
                    }
                    bool v34;
                    v34 = v33 == false;
                    if (v34){
                        assert("The read index needs to be in range for the static array." && v33);
                    } else {
                    }
                    v18.v[v19] = v30;
                    v19 += 1l ;
                }
                v37 = US0_1(v18);
                break;
            }
            case 2: {
                v37 = US0_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US3,6l,long> v38;
        v38.length = 0;
        long * v39;
        v39 = (long *)(v0+0ull);
        long v40;
        v40 = v39[0l];
        v38.length = v40;
        long v41;
        v41 = v38.length;
        long v42;
        v42 = 0l;
        while (while_method_1(v41, v42)){
            unsigned long long v44;
            v44 = (unsigned long long)v42;
            unsigned long long v45;
            v45 = v44 * 4ull;
            unsigned long long v46;
            v46 = 4ull + v45;
            unsigned char * v47;
            v47 = (unsigned char *)(v0+v46);
            long * v48;
            v48 = (long *)(v47+0ull);
            long v49;
            v49 = v48[0l];
            US3 v54;
            switch (v49) {
                case 0: {
                    v54 = US3_0();
                    break;
                }
                case 1: {
                    v54 = US3_1();
                    break;
                }
                case 2: {
                    v54 = US3_2();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v55;
            v55 = 0l <= v42;
            bool v58;
            if (v55){
                long v56;
                v56 = v38.length;
                bool v57;
                v57 = v42 < v56;
                v58 = v57;
            } else {
                v58 = false;
            }
            bool v59;
            v59 = v58 == false;
            if (v59){
                assert("The set index needs to be in range for the static array list." && v58);
            } else {
            }
            v38.v[v42] = v54;
            v42 += 1l ;
        }
        static_array_list<US4,32l,long> v60;
        v60.length = 0;
        long * v61;
        v61 = (long *)(v0+28ull);
        long v62;
        v62 = v61[0l];
        v60.length = v62;
        long v63;
        v63 = v60.length;
        long v64;
        v64 = 0l;
        while (while_method_1(v63, v64)){
            unsigned long long v66;
            v66 = (unsigned long long)v64;
            unsigned long long v67;
            v67 = v66 * 32ull;
            unsigned long long v68;
            v68 = 32ull + v67;
            unsigned char * v69;
            v69 = (unsigned char *)(v0+v68);
            long * v70;
            v70 = (long *)(v69+0ull);
            long v71;
            v71 = v70[0l];
            US4 v124;
            switch (v71) {
                case 0: {
                    long * v73;
                    v73 = (long *)(v69+4ull);
                    long v74;
                    v74 = v73[0l];
                    US3 v79;
                    switch (v74) {
                        case 0: {
                            v79 = US3_0();
                            break;
                        }
                        case 1: {
                            v79 = US3_1();
                            break;
                        }
                        case 2: {
                            v79 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v124 = US4_0(v79);
                    break;
                }
                case 1: {
                    long * v81;
                    v81 = (long *)(v69+4ull);
                    long v82;
                    v82 = v81[0l];
                    long * v83;
                    v83 = (long *)(v69+8ull);
                    long v84;
                    v84 = v83[0l];
                    US1 v89;
                    switch (v84) {
                        case 0: {
                            v89 = US1_0();
                            break;
                        }
                        case 1: {
                            v89 = US1_1();
                            break;
                        }
                        case 2: {
                            v89 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v124 = US4_1(v82, v89);
                    break;
                }
                case 2: {
                    long * v91;
                    v91 = (long *)(v69+4ull);
                    long v92;
                    v92 = v91[0l];
                    long * v93;
                    v93 = (long *)(v69+8ull);
                    long v94;
                    v94 = v93[0l];
                    US3 v99;
                    switch (v94) {
                        case 0: {
                            v99 = US3_0();
                            break;
                        }
                        case 1: {
                            v99 = US3_1();
                            break;
                        }
                        case 2: {
                            v99 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v124 = US4_2(v92, v99);
                    break;
                }
                case 3: {
                    static_array<US3,2l> v101;
                    long v102;
                    v102 = 0l;
                    while (while_method_0(v102)){
                        unsigned long long v104;
                        v104 = (unsigned long long)v102;
                        unsigned long long v105;
                        v105 = v104 * 4ull;
                        unsigned long long v106;
                        v106 = 4ull + v105;
                        unsigned char * v107;
                        v107 = (unsigned char *)(v69+v106);
                        long * v108;
                        v108 = (long *)(v107+0ull);
                        long v109;
                        v109 = v108[0l];
                        US3 v114;
                        switch (v109) {
                            case 0: {
                                v114 = US3_0();
                                break;
                            }
                            case 1: {
                                v114 = US3_1();
                                break;
                            }
                            case 2: {
                                v114 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool v115;
                        v115 = 0l <= v102;
                        bool v117;
                        if (v115){
                            bool v116;
                            v116 = v102 < 2l;
                            v117 = v116;
                        } else {
                            v117 = false;
                        }
                        bool v118;
                        v118 = v117 == false;
                        if (v118){
                            assert("The read index needs to be in range for the static array." && v117);
                        } else {
                        }
                        v101.v[v102] = v114;
                        v102 += 1l ;
                    }
                    long * v119;
                    v119 = (long *)(v69+12ull);
                    long v120;
                    v120 = v119[0l];
                    long * v121;
                    v121 = (long *)(v69+16ull);
                    long v122;
                    v122 = v121[0l];
                    v124 = US4_3(v101, v120, v122);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v125;
            v125 = 0l <= v64;
            bool v128;
            if (v125){
                long v126;
                v126 = v60.length;
                bool v127;
                v127 = v64 < v126;
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
            v60.v[v64] = v124;
            v64 += 1l ;
        }
        long * v130;
        v130 = (long *)(v0+1056ull);
        long v131;
        v131 = v130[0l];
        US5 v402;
        switch (v131) {
            case 0: {
                v402 = US5_0();
                break;
            }
            case 1: {
                long * v134;
                v134 = (long *)(v0+1060ull);
                long v135;
                v135 = v134[0l];
                US6 v400;
                switch (v135) {
                    case 0: {
                        long * v137;
                        v137 = (long *)(v0+1064ull);
                        long v138;
                        v138 = v137[0l];
                        US7 v149;
                        switch (v138) {
                            case 0: {
                                v149 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v141;
                                v141 = (long *)(v0+1068ull);
                                long v142;
                                v142 = v141[0l];
                                US3 v147;
                                switch (v142) {
                                    case 0: {
                                        v147 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v147 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v147 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v149 = US7_1(v147);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v150;
                        v150 = (bool *)(v0+1072ull);
                        bool v151;
                        v151 = v150[0l];
                        static_array<US3,2l> v152;
                        long v153;
                        v153 = 0l;
                        while (while_method_0(v153)){
                            unsigned long long v155;
                            v155 = (unsigned long long)v153;
                            unsigned long long v156;
                            v156 = v155 * 4ull;
                            unsigned long long v157;
                            v157 = 1076ull + v156;
                            unsigned char * v158;
                            v158 = (unsigned char *)(v0+v157);
                            long * v159;
                            v159 = (long *)(v158+0ull);
                            long v160;
                            v160 = v159[0l];
                            US3 v165;
                            switch (v160) {
                                case 0: {
                                    v165 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v165 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v165 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v166;
                            v166 = 0l <= v153;
                            bool v168;
                            if (v166){
                                bool v167;
                                v167 = v153 < 2l;
                                v168 = v167;
                            } else {
                                v168 = false;
                            }
                            bool v169;
                            v169 = v168 == false;
                            if (v169){
                                assert("The read index needs to be in range for the static array." && v168);
                            } else {
                            }
                            v152.v[v153] = v165;
                            v153 += 1l ;
                        }
                        long * v170;
                        v170 = (long *)(v0+1084ull);
                        long v171;
                        v171 = v170[0l];
                        static_array<long,2l> v172;
                        long v173;
                        v173 = 0l;
                        while (while_method_0(v173)){
                            unsigned long long v175;
                            v175 = (unsigned long long)v173;
                            unsigned long long v176;
                            v176 = v175 * 4ull;
                            unsigned long long v177;
                            v177 = 1088ull + v176;
                            unsigned char * v178;
                            v178 = (unsigned char *)(v0+v177);
                            long * v179;
                            v179 = (long *)(v178+0ull);
                            long v180;
                            v180 = v179[0l];
                            bool v181;
                            v181 = 0l <= v173;
                            bool v183;
                            if (v181){
                                bool v182;
                                v182 = v173 < 2l;
                                v183 = v182;
                            } else {
                                v183 = false;
                            }
                            bool v184;
                            v184 = v183 == false;
                            if (v184){
                                assert("The read index needs to be in range for the static array." && v183);
                            } else {
                            }
                            v172.v[v173] = v180;
                            v173 += 1l ;
                        }
                        long * v185;
                        v185 = (long *)(v0+1096ull);
                        long v186;
                        v186 = v185[0l];
                        v400 = US6_0(v149, v151, v152, v171, v172, v186);
                        break;
                    }
                    case 1: {
                        v400 = US6_1();
                        break;
                    }
                    case 2: {
                        long * v189;
                        v189 = (long *)(v0+1064ull);
                        long v190;
                        v190 = v189[0l];
                        US7 v201;
                        switch (v190) {
                            case 0: {
                                v201 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v193;
                                v193 = (long *)(v0+1068ull);
                                long v194;
                                v194 = v193[0l];
                                US3 v199;
                                switch (v194) {
                                    case 0: {
                                        v199 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v199 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v199 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v201 = US7_1(v199);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v202;
                        v202 = (bool *)(v0+1072ull);
                        bool v203;
                        v203 = v202[0l];
                        static_array<US3,2l> v204;
                        long v205;
                        v205 = 0l;
                        while (while_method_0(v205)){
                            unsigned long long v207;
                            v207 = (unsigned long long)v205;
                            unsigned long long v208;
                            v208 = v207 * 4ull;
                            unsigned long long v209;
                            v209 = 1076ull + v208;
                            unsigned char * v210;
                            v210 = (unsigned char *)(v0+v209);
                            long * v211;
                            v211 = (long *)(v210+0ull);
                            long v212;
                            v212 = v211[0l];
                            US3 v217;
                            switch (v212) {
                                case 0: {
                                    v217 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v217 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v217 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v218;
                            v218 = 0l <= v205;
                            bool v220;
                            if (v218){
                                bool v219;
                                v219 = v205 < 2l;
                                v220 = v219;
                            } else {
                                v220 = false;
                            }
                            bool v221;
                            v221 = v220 == false;
                            if (v221){
                                assert("The read index needs to be in range for the static array." && v220);
                            } else {
                            }
                            v204.v[v205] = v217;
                            v205 += 1l ;
                        }
                        long * v222;
                        v222 = (long *)(v0+1084ull);
                        long v223;
                        v223 = v222[0l];
                        static_array<long,2l> v224;
                        long v225;
                        v225 = 0l;
                        while (while_method_0(v225)){
                            unsigned long long v227;
                            v227 = (unsigned long long)v225;
                            unsigned long long v228;
                            v228 = v227 * 4ull;
                            unsigned long long v229;
                            v229 = 1088ull + v228;
                            unsigned char * v230;
                            v230 = (unsigned char *)(v0+v229);
                            long * v231;
                            v231 = (long *)(v230+0ull);
                            long v232;
                            v232 = v231[0l];
                            bool v233;
                            v233 = 0l <= v225;
                            bool v235;
                            if (v233){
                                bool v234;
                                v234 = v225 < 2l;
                                v235 = v234;
                            } else {
                                v235 = false;
                            }
                            bool v236;
                            v236 = v235 == false;
                            if (v236){
                                assert("The read index needs to be in range for the static array." && v235);
                            } else {
                            }
                            v224.v[v225] = v232;
                            v225 += 1l ;
                        }
                        long * v237;
                        v237 = (long *)(v0+1096ull);
                        long v238;
                        v238 = v237[0l];
                        v400 = US6_2(v201, v203, v204, v223, v224, v238);
                        break;
                    }
                    case 3: {
                        long * v240;
                        v240 = (long *)(v0+1064ull);
                        long v241;
                        v241 = v240[0l];
                        US7 v252;
                        switch (v241) {
                            case 0: {
                                v252 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v244;
                                v244 = (long *)(v0+1068ull);
                                long v245;
                                v245 = v244[0l];
                                US3 v250;
                                switch (v245) {
                                    case 0: {
                                        v250 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v250 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v250 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v252 = US7_1(v250);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v253;
                        v253 = (bool *)(v0+1072ull);
                        bool v254;
                        v254 = v253[0l];
                        static_array<US3,2l> v255;
                        long v256;
                        v256 = 0l;
                        while (while_method_0(v256)){
                            unsigned long long v258;
                            v258 = (unsigned long long)v256;
                            unsigned long long v259;
                            v259 = v258 * 4ull;
                            unsigned long long v260;
                            v260 = 1076ull + v259;
                            unsigned char * v261;
                            v261 = (unsigned char *)(v0+v260);
                            long * v262;
                            v262 = (long *)(v261+0ull);
                            long v263;
                            v263 = v262[0l];
                            US3 v268;
                            switch (v263) {
                                case 0: {
                                    v268 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v268 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v268 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v269;
                            v269 = 0l <= v256;
                            bool v271;
                            if (v269){
                                bool v270;
                                v270 = v256 < 2l;
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
                            v255.v[v256] = v268;
                            v256 += 1l ;
                        }
                        long * v273;
                        v273 = (long *)(v0+1084ull);
                        long v274;
                        v274 = v273[0l];
                        static_array<long,2l> v275;
                        long v276;
                        v276 = 0l;
                        while (while_method_0(v276)){
                            unsigned long long v278;
                            v278 = (unsigned long long)v276;
                            unsigned long long v279;
                            v279 = v278 * 4ull;
                            unsigned long long v280;
                            v280 = 1088ull + v279;
                            unsigned char * v281;
                            v281 = (unsigned char *)(v0+v280);
                            long * v282;
                            v282 = (long *)(v281+0ull);
                            long v283;
                            v283 = v282[0l];
                            bool v284;
                            v284 = 0l <= v276;
                            bool v286;
                            if (v284){
                                bool v285;
                                v285 = v276 < 2l;
                                v286 = v285;
                            } else {
                                v286 = false;
                            }
                            bool v287;
                            v287 = v286 == false;
                            if (v287){
                                assert("The read index needs to be in range for the static array." && v286);
                            } else {
                            }
                            v275.v[v276] = v283;
                            v276 += 1l ;
                        }
                        long * v288;
                        v288 = (long *)(v0+1096ull);
                        long v289;
                        v289 = v288[0l];
                        long * v290;
                        v290 = (long *)(v0+1100ull);
                        long v291;
                        v291 = v290[0l];
                        US1 v296;
                        switch (v291) {
                            case 0: {
                                v296 = US1_0();
                                break;
                            }
                            case 1: {
                                v296 = US1_1();
                                break;
                            }
                            case 2: {
                                v296 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v400 = US6_3(v252, v254, v255, v274, v275, v289, v296);
                        break;
                    }
                    case 4: {
                        long * v298;
                        v298 = (long *)(v0+1064ull);
                        long v299;
                        v299 = v298[0l];
                        US7 v310;
                        switch (v299) {
                            case 0: {
                                v310 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v302;
                                v302 = (long *)(v0+1068ull);
                                long v303;
                                v303 = v302[0l];
                                US3 v308;
                                switch (v303) {
                                    case 0: {
                                        v308 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v308 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v308 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v310 = US7_1(v308);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v311;
                        v311 = (bool *)(v0+1072ull);
                        bool v312;
                        v312 = v311[0l];
                        static_array<US3,2l> v313;
                        long v314;
                        v314 = 0l;
                        while (while_method_0(v314)){
                            unsigned long long v316;
                            v316 = (unsigned long long)v314;
                            unsigned long long v317;
                            v317 = v316 * 4ull;
                            unsigned long long v318;
                            v318 = 1076ull + v317;
                            unsigned char * v319;
                            v319 = (unsigned char *)(v0+v318);
                            long * v320;
                            v320 = (long *)(v319+0ull);
                            long v321;
                            v321 = v320[0l];
                            US3 v326;
                            switch (v321) {
                                case 0: {
                                    v326 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v326 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v326 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v327;
                            v327 = 0l <= v314;
                            bool v329;
                            if (v327){
                                bool v328;
                                v328 = v314 < 2l;
                                v329 = v328;
                            } else {
                                v329 = false;
                            }
                            bool v330;
                            v330 = v329 == false;
                            if (v330){
                                assert("The read index needs to be in range for the static array." && v329);
                            } else {
                            }
                            v313.v[v314] = v326;
                            v314 += 1l ;
                        }
                        long * v331;
                        v331 = (long *)(v0+1084ull);
                        long v332;
                        v332 = v331[0l];
                        static_array<long,2l> v333;
                        long v334;
                        v334 = 0l;
                        while (while_method_0(v334)){
                            unsigned long long v336;
                            v336 = (unsigned long long)v334;
                            unsigned long long v337;
                            v337 = v336 * 4ull;
                            unsigned long long v338;
                            v338 = 1088ull + v337;
                            unsigned char * v339;
                            v339 = (unsigned char *)(v0+v338);
                            long * v340;
                            v340 = (long *)(v339+0ull);
                            long v341;
                            v341 = v340[0l];
                            bool v342;
                            v342 = 0l <= v334;
                            bool v344;
                            if (v342){
                                bool v343;
                                v343 = v334 < 2l;
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
                            v333.v[v334] = v341;
                            v334 += 1l ;
                        }
                        long * v346;
                        v346 = (long *)(v0+1096ull);
                        long v347;
                        v347 = v346[0l];
                        v400 = US6_4(v310, v312, v313, v332, v333, v347);
                        break;
                    }
                    case 5: {
                        long * v349;
                        v349 = (long *)(v0+1064ull);
                        long v350;
                        v350 = v349[0l];
                        US7 v361;
                        switch (v350) {
                            case 0: {
                                v361 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v353;
                                v353 = (long *)(v0+1068ull);
                                long v354;
                                v354 = v353[0l];
                                US3 v359;
                                switch (v354) {
                                    case 0: {
                                        v359 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v359 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v359 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v361 = US7_1(v359);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v362;
                        v362 = (bool *)(v0+1072ull);
                        bool v363;
                        v363 = v362[0l];
                        static_array<US3,2l> v364;
                        long v365;
                        v365 = 0l;
                        while (while_method_0(v365)){
                            unsigned long long v367;
                            v367 = (unsigned long long)v365;
                            unsigned long long v368;
                            v368 = v367 * 4ull;
                            unsigned long long v369;
                            v369 = 1076ull + v368;
                            unsigned char * v370;
                            v370 = (unsigned char *)(v0+v369);
                            long * v371;
                            v371 = (long *)(v370+0ull);
                            long v372;
                            v372 = v371[0l];
                            US3 v377;
                            switch (v372) {
                                case 0: {
                                    v377 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v377 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v377 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v378;
                            v378 = 0l <= v365;
                            bool v380;
                            if (v378){
                                bool v379;
                                v379 = v365 < 2l;
                                v380 = v379;
                            } else {
                                v380 = false;
                            }
                            bool v381;
                            v381 = v380 == false;
                            if (v381){
                                assert("The read index needs to be in range for the static array." && v380);
                            } else {
                            }
                            v364.v[v365] = v377;
                            v365 += 1l ;
                        }
                        long * v382;
                        v382 = (long *)(v0+1084ull);
                        long v383;
                        v383 = v382[0l];
                        static_array<long,2l> v384;
                        long v385;
                        v385 = 0l;
                        while (while_method_0(v385)){
                            unsigned long long v387;
                            v387 = (unsigned long long)v385;
                            unsigned long long v388;
                            v388 = v387 * 4ull;
                            unsigned long long v389;
                            v389 = 1088ull + v388;
                            unsigned char * v390;
                            v390 = (unsigned char *)(v0+v389);
                            long * v391;
                            v391 = (long *)(v390+0ull);
                            long v392;
                            v392 = v391[0l];
                            bool v393;
                            v393 = 0l <= v385;
                            bool v395;
                            if (v393){
                                bool v394;
                                v394 = v385 < 2l;
                                v395 = v394;
                            } else {
                                v395 = false;
                            }
                            bool v396;
                            v396 = v395 == false;
                            if (v396){
                                assert("The read index needs to be in range for the static array." && v395);
                            } else {
                            }
                            v384.v[v385] = v392;
                            v385 += 1l ;
                        }
                        long * v397;
                        v397 = (long *)(v0+1096ull);
                        long v398;
                        v398 = v397[0l];
                        v400 = US6_5(v361, v363, v364, v383, v384, v398);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v402 = US5_1(v400);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array<US2,2l> v403;
        long v404;
        v404 = 0l;
        while (while_method_0(v404)){
            unsigned long long v406;
            v406 = (unsigned long long)v404;
            unsigned long long v407;
            v407 = v406 * 4ull;
            unsigned long long v408;
            v408 = 1104ull + v407;
            unsigned char * v409;
            v409 = (unsigned char *)(v0+v408);
            long * v410;
            v410 = (long *)(v409+0ull);
            long v411;
            v411 = v410[0l];
            US2 v415;
            switch (v411) {
                case 0: {
                    v415 = US2_0();
                    break;
                }
                case 1: {
                    v415 = US2_1();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v416;
            v416 = 0l <= v404;
            bool v418;
            if (v416){
                bool v417;
                v417 = v404 < 2l;
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
            v403.v[v404] = v415;
            v404 += 1l ;
        }
        long * v420;
        v420 = (long *)(v0+1112ull);
        long v421;
        v421 = v420[0l];
        US8 v526;
        switch (v421) {
            case 0: {
                v526 = US8_0();
                break;
            }
            case 1: {
                long * v424;
                v424 = (long *)(v0+1116ull);
                long v425;
                v425 = v424[0l];
                US7 v436;
                switch (v425) {
                    case 0: {
                        v436 = US7_0();
                        break;
                    }
                    case 1: {
                        long * v428;
                        v428 = (long *)(v0+1120ull);
                        long v429;
                        v429 = v428[0l];
                        US3 v434;
                        switch (v429) {
                            case 0: {
                                v434 = US3_0();
                                break;
                            }
                            case 1: {
                                v434 = US3_1();
                                break;
                            }
                            case 2: {
                                v434 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v436 = US7_1(v434);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v437;
                v437 = (bool *)(v0+1124ull);
                bool v438;
                v438 = v437[0l];
                static_array<US3,2l> v439;
                long v440;
                v440 = 0l;
                while (while_method_0(v440)){
                    unsigned long long v442;
                    v442 = (unsigned long long)v440;
                    unsigned long long v443;
                    v443 = v442 * 4ull;
                    unsigned long long v444;
                    v444 = 1128ull + v443;
                    unsigned char * v445;
                    v445 = (unsigned char *)(v0+v444);
                    long * v446;
                    v446 = (long *)(v445+0ull);
                    long v447;
                    v447 = v446[0l];
                    US3 v452;
                    switch (v447) {
                        case 0: {
                            v452 = US3_0();
                            break;
                        }
                        case 1: {
                            v452 = US3_1();
                            break;
                        }
                        case 2: {
                            v452 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v453;
                    v453 = 0l <= v440;
                    bool v455;
                    if (v453){
                        bool v454;
                        v454 = v440 < 2l;
                        v455 = v454;
                    } else {
                        v455 = false;
                    }
                    bool v456;
                    v456 = v455 == false;
                    if (v456){
                        assert("The read index needs to be in range for the static array." && v455);
                    } else {
                    }
                    v439.v[v440] = v452;
                    v440 += 1l ;
                }
                long * v457;
                v457 = (long *)(v0+1136ull);
                long v458;
                v458 = v457[0l];
                static_array<long,2l> v459;
                long v460;
                v460 = 0l;
                while (while_method_0(v460)){
                    unsigned long long v462;
                    v462 = (unsigned long long)v460;
                    unsigned long long v463;
                    v463 = v462 * 4ull;
                    unsigned long long v464;
                    v464 = 1140ull + v463;
                    unsigned char * v465;
                    v465 = (unsigned char *)(v0+v464);
                    long * v466;
                    v466 = (long *)(v465+0ull);
                    long v467;
                    v467 = v466[0l];
                    bool v468;
                    v468 = 0l <= v460;
                    bool v470;
                    if (v468){
                        bool v469;
                        v469 = v460 < 2l;
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
                    v459.v[v460] = v467;
                    v460 += 1l ;
                }
                long * v472;
                v472 = (long *)(v0+1148ull);
                long v473;
                v473 = v472[0l];
                v526 = US8_1(v436, v438, v439, v458, v459, v473);
                break;
            }
            case 2: {
                long * v475;
                v475 = (long *)(v0+1116ull);
                long v476;
                v476 = v475[0l];
                US7 v487;
                switch (v476) {
                    case 0: {
                        v487 = US7_0();
                        break;
                    }
                    case 1: {
                        long * v479;
                        v479 = (long *)(v0+1120ull);
                        long v480;
                        v480 = v479[0l];
                        US3 v485;
                        switch (v480) {
                            case 0: {
                                v485 = US3_0();
                                break;
                            }
                            case 1: {
                                v485 = US3_1();
                                break;
                            }
                            case 2: {
                                v485 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v487 = US7_1(v485);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v488;
                v488 = (bool *)(v0+1124ull);
                bool v489;
                v489 = v488[0l];
                static_array<US3,2l> v490;
                long v491;
                v491 = 0l;
                while (while_method_0(v491)){
                    unsigned long long v493;
                    v493 = (unsigned long long)v491;
                    unsigned long long v494;
                    v494 = v493 * 4ull;
                    unsigned long long v495;
                    v495 = 1128ull + v494;
                    unsigned char * v496;
                    v496 = (unsigned char *)(v0+v495);
                    long * v497;
                    v497 = (long *)(v496+0ull);
                    long v498;
                    v498 = v497[0l];
                    US3 v503;
                    switch (v498) {
                        case 0: {
                            v503 = US3_0();
                            break;
                        }
                        case 1: {
                            v503 = US3_1();
                            break;
                        }
                        case 2: {
                            v503 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v504;
                    v504 = 0l <= v491;
                    bool v506;
                    if (v504){
                        bool v505;
                        v505 = v491 < 2l;
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
                    v490.v[v491] = v503;
                    v491 += 1l ;
                }
                long * v508;
                v508 = (long *)(v0+1136ull);
                long v509;
                v509 = v508[0l];
                static_array<long,2l> v510;
                long v511;
                v511 = 0l;
                while (while_method_0(v511)){
                    unsigned long long v513;
                    v513 = (unsigned long long)v511;
                    unsigned long long v514;
                    v514 = v513 * 4ull;
                    unsigned long long v515;
                    v515 = 1140ull + v514;
                    unsigned char * v516;
                    v516 = (unsigned char *)(v0+v515);
                    long * v517;
                    v517 = (long *)(v516+0ull);
                    long v518;
                    v518 = v517[0l];
                    bool v519;
                    v519 = 0l <= v511;
                    bool v521;
                    if (v519){
                        bool v520;
                        v520 = v511 < 2l;
                        v521 = v520;
                    } else {
                        v521 = false;
                    }
                    bool v522;
                    v522 = v521 == false;
                    if (v522){
                        assert("The read index needs to be in range for the static array." && v521);
                    } else {
                    }
                    v510.v[v511] = v518;
                    v511 += 1l ;
                }
                long * v523;
                v523 = (long *)(v0+1148ull);
                long v524;
                v524 = v523[0l];
                v526 = US8_2(v487, v489, v490, v509, v510, v524);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US3,6l,long> & v527 = v38;
        static_array_list<US4,32l,long> & v528 = v60;
        US5 v629; static_array<US2,2l> v630; US8 v631;
        switch (v37.tag) {
            case 0: { // ActionSelected
                US1 v599 = v37.v.case0.v0;
                switch (v402.tag) {
                    case 0: { // None
                        v629 = v402; v630 = v403; v631 = v526;
                        break;
                    }
                    case 1: { // Some
                        US6 v600 = v402.v.case1.v0;
                        switch (v600.tag) {
                            case 2: { // Round
                                US7 v601 = v600.v.case2.v0; bool v602 = v600.v.case2.v1; static_array<US3,2l> v603 = v600.v.case2.v2; long v604 = v600.v.case2.v3; static_array<long,2l> v605 = v600.v.case2.v4; long v606 = v600.v.case2.v5;
                                US6 v607;
                                v607 = US6_3(v601, v602, v603, v604, v605, v606, v599);
                                Tuple0 tmp10 = play_loop_0(v402, v403, v526, v527, v528, v607);
                                v629 = tmp10.v0; v630 = tmp10.v1; v631 = tmp10.v2;
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
                static_array<US2,2l> v598 = v37.v.case1.v0;
                v629 = v402; v630 = v598; v631 = v526;
                break;
            }
            case 2: { // StartGame
                static_array<US2,2l> v529;
                US2 v530;
                v530 = US2_0();
                v529.v[0l] = v530;
                US2 v531;
                v531 = US2_0();
                v529.v[1l] = v531;
                static_array_list<US3,6l,long> v532;
                v532.length = 0;
                v532.length = 6l;
                long v533;
                v533 = v532.length;
                bool v534;
                v534 = 0l < v533;
                bool v535;
                v535 = v534 == false;
                if (v535){
                    assert("The set index needs to be in range for the static array list." && v534);
                } else {
                }
                US3 v536;
                v536 = US3_1();
                v532.v[0l] = v536;
                long v537;
                v537 = v532.length;
                bool v538;
                v538 = 1l < v537;
                bool v539;
                v539 = v538 == false;
                if (v539){
                    assert("The set index needs to be in range for the static array list." && v538);
                } else {
                }
                US3 v540;
                v540 = US3_1();
                v532.v[1l] = v540;
                long v541;
                v541 = v532.length;
                bool v542;
                v542 = 2l < v541;
                bool v543;
                v543 = v542 == false;
                if (v543){
                    assert("The set index needs to be in range for the static array list." && v542);
                } else {
                }
                US3 v544;
                v544 = US3_2();
                v532.v[2l] = v544;
                long v545;
                v545 = v532.length;
                bool v546;
                v546 = 3l < v545;
                bool v547;
                v547 = v546 == false;
                if (v547){
                    assert("The set index needs to be in range for the static array list." && v546);
                } else {
                }
                US3 v548;
                v548 = US3_2();
                v532.v[3l] = v548;
                long v549;
                v549 = v532.length;
                bool v550;
                v550 = 4l < v549;
                bool v551;
                v551 = v550 == false;
                if (v551){
                    assert("The set index needs to be in range for the static array list." && v550);
                } else {
                }
                US3 v552;
                v552 = US3_0();
                v532.v[4l] = v552;
                long v553;
                v553 = v532.length;
                bool v554;
                v554 = 5l < v553;
                bool v555;
                v555 = v554 == false;
                if (v555){
                    assert("The set index needs to be in range for the static array list." && v554);
                } else {
                }
                US3 v556;
                v556 = US3_0();
                v532.v[5l] = v556;
                unsigned long long v557;
                v557 = clock64();
                curandStatePhilox4_32_10_t v558;
                curandStatePhilox4_32_10_t * v559 = &v558;
                curand_init(v557,0ull,0ull,v559);
                long v560;
                v560 = v532.length;
                long v561;
                v561 = v560 - 1l;
                long v562;
                v562 = 0l;
                while (while_method_1(v561, v562)){
                    long v564;
                    v564 = v532.length;
                    long v565;
                    v565 = v564 - v562;
                    unsigned long v566;
                    v566 = (unsigned long)v565;
                    unsigned long v567;
                    v567 = loop_2(v566, v559);
                    unsigned long v568;
                    v568 = (unsigned long)v562;
                    unsigned long v569;
                    v569 = v567 + v568;
                    long v570;
                    v570 = (long)v569;
                    bool v571;
                    v571 = 0l <= v562;
                    bool v574;
                    if (v571){
                        long v572;
                        v572 = v532.length;
                        bool v573;
                        v573 = v562 < v572;
                        v574 = v573;
                    } else {
                        v574 = false;
                    }
                    bool v575;
                    v575 = v574 == false;
                    if (v575){
                        assert("The read index needs to be in range for the static array list." && v574);
                    } else {
                    }
                    US3 v576;
                    v576 = v532.v[v562];
                    bool v577;
                    v577 = 0l <= v570;
                    bool v580;
                    if (v577){
                        long v578;
                        v578 = v532.length;
                        bool v579;
                        v579 = v570 < v578;
                        v580 = v579;
                    } else {
                        v580 = false;
                    }
                    bool v581;
                    v581 = v580 == false;
                    if (v581){
                        assert("The read index needs to be in range for the static array list." && v580);
                    } else {
                    }
                    US3 v582;
                    v582 = v532.v[v570];
                    bool v585;
                    if (v571){
                        long v583;
                        v583 = v532.length;
                        bool v584;
                        v584 = v562 < v583;
                        v585 = v584;
                    } else {
                        v585 = false;
                    }
                    bool v586;
                    v586 = v585 == false;
                    if (v586){
                        assert("The set index needs to be in range for the static array list." && v585);
                    } else {
                    }
                    v532.v[v562] = v582;
                    bool v589;
                    if (v577){
                        long v587;
                        v587 = v532.length;
                        bool v588;
                        v588 = v570 < v587;
                        v589 = v588;
                    } else {
                        v589 = false;
                    }
                    bool v590;
                    v590 = v589 == false;
                    if (v590){
                        assert("The set index needs to be in range for the static array list." && v589);
                    } else {
                    }
                    v532.v[v570] = v576;
                    v562 += 1l ;
                }
                static_array_list<US4,32l,long> v591;
                v591.length = 0;
                v527 = v532;
                v528 = v591;
                US5 v592;
                v592 = US5_0();
                US8 v593;
                v593 = US8_0();
                US6 v594;
                v594 = US6_1();
                Tuple0 tmp11 = play_loop_0(v592, v529, v593, v527, v528, v594);
                v629 = tmp11.v0; v630 = tmp11.v1; v631 = tmp11.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        long v632;
        v632 = v38.length;
        long * v633;
        v633 = (long *)(v0+0ull);
        v633[0l] = v632;
        long v634;
        v634 = v38.length;
        long v635;
        v635 = 0l;
        while (while_method_1(v634, v635)){
            unsigned long long v637;
            v637 = (unsigned long long)v635;
            unsigned long long v638;
            v638 = v637 * 4ull;
            unsigned long long v639;
            v639 = 4ull + v638;
            unsigned char * v640;
            v640 = (unsigned char *)(v0+v639);
            bool v641;
            v641 = 0l <= v635;
            bool v644;
            if (v641){
                long v642;
                v642 = v38.length;
                bool v643;
                v643 = v635 < v642;
                v644 = v643;
            } else {
                v644 = false;
            }
            bool v645;
            v645 = v644 == false;
            if (v645){
                assert("The read index needs to be in range for the static array list." && v644);
            } else {
            }
            US3 v646;
            v646 = v38.v[v635];
            long v647;
            v647 = v646.tag;
            long * v648;
            v648 = (long *)(v640+0ull);
            v648[0l] = v647;
            switch (v646.tag) {
                case 0: { // Jack
                    break;
                }
                case 1: { // King
                    break;
                }
                case 2: { // Queen
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v635 += 1l ;
        }
        long v649;
        v649 = v60.length;
        long * v650;
        v650 = (long *)(v0+28ull);
        v650[0l] = v649;
        long v651;
        v651 = v60.length;
        long v652;
        v652 = 0l;
        while (while_method_1(v651, v652)){
            unsigned long long v654;
            v654 = (unsigned long long)v652;
            unsigned long long v655;
            v655 = v654 * 32ull;
            unsigned long long v656;
            v656 = 32ull + v655;
            unsigned char * v657;
            v657 = (unsigned char *)(v0+v656);
            bool v658;
            v658 = 0l <= v652;
            bool v661;
            if (v658){
                long v659;
                v659 = v60.length;
                bool v660;
                v660 = v652 < v659;
                v661 = v660;
            } else {
                v661 = false;
            }
            bool v662;
            v662 = v661 == false;
            if (v662){
                assert("The read index needs to be in range for the static array list." && v661);
            } else {
            }
            US4 v663;
            v663 = v60.v[v652];
            long v664;
            v664 = v663.tag;
            long * v665;
            v665 = (long *)(v657+0ull);
            v665[0l] = v664;
            switch (v663.tag) {
                case 0: { // CommunityCardIs
                    US3 v666 = v663.v.case0.v0;
                    long v667;
                    v667 = v666.tag;
                    long * v668;
                    v668 = (long *)(v657+4ull);
                    v668[0l] = v667;
                    switch (v666.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 1: { // PlayerAction
                    long v669 = v663.v.case1.v0; US1 v670 = v663.v.case1.v1;
                    long * v671;
                    v671 = (long *)(v657+4ull);
                    v671[0l] = v669;
                    long v672;
                    v672 = v670.tag;
                    long * v673;
                    v673 = (long *)(v657+8ull);
                    v673[0l] = v672;
                    switch (v670.tag) {
                        case 0: { // Call
                            break;
                        }
                        case 1: { // Fold
                            break;
                        }
                        case 2: { // Raise
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 2: { // PlayerGotCard
                    long v674 = v663.v.case2.v0; US3 v675 = v663.v.case2.v1;
                    long * v676;
                    v676 = (long *)(v657+4ull);
                    v676[0l] = v674;
                    long v677;
                    v677 = v675.tag;
                    long * v678;
                    v678 = (long *)(v657+8ull);
                    v678[0l] = v677;
                    switch (v675.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 3: { // Showdown
                    static_array<US3,2l> v679 = v663.v.case3.v0; long v680 = v663.v.case3.v1; long v681 = v663.v.case3.v2;
                    long v682;
                    v682 = 0l;
                    while (while_method_0(v682)){
                        unsigned long long v684;
                        v684 = (unsigned long long)v682;
                        unsigned long long v685;
                        v685 = v684 * 4ull;
                        unsigned long long v686;
                        v686 = 4ull + v685;
                        unsigned char * v687;
                        v687 = (unsigned char *)(v657+v686);
                        bool v688;
                        v688 = 0l <= v682;
                        bool v690;
                        if (v688){
                            bool v689;
                            v689 = v682 < 2l;
                            v690 = v689;
                        } else {
                            v690 = false;
                        }
                        bool v691;
                        v691 = v690 == false;
                        if (v691){
                            assert("The read index needs to be in range for the static array." && v690);
                        } else {
                        }
                        US3 v692;
                        v692 = v679.v[v682];
                        long v693;
                        v693 = v692.tag;
                        long * v694;
                        v694 = (long *)(v687+0ull);
                        v694[0l] = v693;
                        switch (v692.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v682 += 1l ;
                    }
                    long * v695;
                    v695 = (long *)(v657+12ull);
                    v695[0l] = v680;
                    long * v696;
                    v696 = (long *)(v657+16ull);
                    v696[0l] = v681;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v652 += 1l ;
        }
        long v697;
        v697 = v629.tag;
        long * v698;
        v698 = (long *)(v0+1056ull);
        v698[0l] = v697;
        switch (v629.tag) {
            case 0: { // None
                break;
            }
            case 1: { // Some
                US6 v699 = v629.v.case1.v0;
                long v700;
                v700 = v699.tag;
                long * v701;
                v701 = (long *)(v0+1060ull);
                v701[0l] = v700;
                switch (v699.tag) {
                    case 0: { // ChanceCommunityCard
                        US7 v702 = v699.v.case0.v0; bool v703 = v699.v.case0.v1; static_array<US3,2l> v704 = v699.v.case0.v2; long v705 = v699.v.case0.v3; static_array<long,2l> v706 = v699.v.case0.v4; long v707 = v699.v.case0.v5;
                        long v708;
                        v708 = v702.tag;
                        long * v709;
                        v709 = (long *)(v0+1064ull);
                        v709[0l] = v708;
                        switch (v702.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v710 = v702.v.case1.v0;
                                long v711;
                                v711 = v710.tag;
                                long * v712;
                                v712 = (long *)(v0+1068ull);
                                v712[0l] = v711;
                                switch (v710.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    case 2: { // Queen
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
                        bool * v713;
                        v713 = (bool *)(v0+1072ull);
                        v713[0l] = v703;
                        long v714;
                        v714 = 0l;
                        while (while_method_0(v714)){
                            unsigned long long v716;
                            v716 = (unsigned long long)v714;
                            unsigned long long v717;
                            v717 = v716 * 4ull;
                            unsigned long long v718;
                            v718 = 1076ull + v717;
                            unsigned char * v719;
                            v719 = (unsigned char *)(v0+v718);
                            bool v720;
                            v720 = 0l <= v714;
                            bool v722;
                            if (v720){
                                bool v721;
                                v721 = v714 < 2l;
                                v722 = v721;
                            } else {
                                v722 = false;
                            }
                            bool v723;
                            v723 = v722 == false;
                            if (v723){
                                assert("The read index needs to be in range for the static array." && v722);
                            } else {
                            }
                            US3 v724;
                            v724 = v704.v[v714];
                            long v725;
                            v725 = v724.tag;
                            long * v726;
                            v726 = (long *)(v719+0ull);
                            v726[0l] = v725;
                            switch (v724.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                case 2: { // Queen
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            v714 += 1l ;
                        }
                        long * v727;
                        v727 = (long *)(v0+1084ull);
                        v727[0l] = v705;
                        long v728;
                        v728 = 0l;
                        while (while_method_0(v728)){
                            unsigned long long v730;
                            v730 = (unsigned long long)v728;
                            unsigned long long v731;
                            v731 = v730 * 4ull;
                            unsigned long long v732;
                            v732 = 1088ull + v731;
                            unsigned char * v733;
                            v733 = (unsigned char *)(v0+v732);
                            bool v734;
                            v734 = 0l <= v728;
                            bool v736;
                            if (v734){
                                bool v735;
                                v735 = v728 < 2l;
                                v736 = v735;
                            } else {
                                v736 = false;
                            }
                            bool v737;
                            v737 = v736 == false;
                            if (v737){
                                assert("The read index needs to be in range for the static array." && v736);
                            } else {
                            }
                            long v738;
                            v738 = v706.v[v728];
                            long * v739;
                            v739 = (long *)(v733+0ull);
                            v739[0l] = v738;
                            v728 += 1l ;
                        }
                        long * v740;
                        v740 = (long *)(v0+1096ull);
                        v740[0l] = v707;
                        break;
                    }
                    case 1: { // ChanceInit
                        break;
                    }
                    case 2: { // Round
                        US7 v741 = v699.v.case2.v0; bool v742 = v699.v.case2.v1; static_array<US3,2l> v743 = v699.v.case2.v2; long v744 = v699.v.case2.v3; static_array<long,2l> v745 = v699.v.case2.v4; long v746 = v699.v.case2.v5;
                        long v747;
                        v747 = v741.tag;
                        long * v748;
                        v748 = (long *)(v0+1064ull);
                        v748[0l] = v747;
                        switch (v741.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v749 = v741.v.case1.v0;
                                long v750;
                                v750 = v749.tag;
                                long * v751;
                                v751 = (long *)(v0+1068ull);
                                v751[0l] = v750;
                                switch (v749.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    case 2: { // Queen
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
                        bool * v752;
                        v752 = (bool *)(v0+1072ull);
                        v752[0l] = v742;
                        long v753;
                        v753 = 0l;
                        while (while_method_0(v753)){
                            unsigned long long v755;
                            v755 = (unsigned long long)v753;
                            unsigned long long v756;
                            v756 = v755 * 4ull;
                            unsigned long long v757;
                            v757 = 1076ull + v756;
                            unsigned char * v758;
                            v758 = (unsigned char *)(v0+v757);
                            bool v759;
                            v759 = 0l <= v753;
                            bool v761;
                            if (v759){
                                bool v760;
                                v760 = v753 < 2l;
                                v761 = v760;
                            } else {
                                v761 = false;
                            }
                            bool v762;
                            v762 = v761 == false;
                            if (v762){
                                assert("The read index needs to be in range for the static array." && v761);
                            } else {
                            }
                            US3 v763;
                            v763 = v743.v[v753];
                            long v764;
                            v764 = v763.tag;
                            long * v765;
                            v765 = (long *)(v758+0ull);
                            v765[0l] = v764;
                            switch (v763.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                case 2: { // Queen
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            v753 += 1l ;
                        }
                        long * v766;
                        v766 = (long *)(v0+1084ull);
                        v766[0l] = v744;
                        long v767;
                        v767 = 0l;
                        while (while_method_0(v767)){
                            unsigned long long v769;
                            v769 = (unsigned long long)v767;
                            unsigned long long v770;
                            v770 = v769 * 4ull;
                            unsigned long long v771;
                            v771 = 1088ull + v770;
                            unsigned char * v772;
                            v772 = (unsigned char *)(v0+v771);
                            bool v773;
                            v773 = 0l <= v767;
                            bool v775;
                            if (v773){
                                bool v774;
                                v774 = v767 < 2l;
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
                            long v777;
                            v777 = v745.v[v767];
                            long * v778;
                            v778 = (long *)(v772+0ull);
                            v778[0l] = v777;
                            v767 += 1l ;
                        }
                        long * v779;
                        v779 = (long *)(v0+1096ull);
                        v779[0l] = v746;
                        break;
                    }
                    case 3: { // RoundWithAction
                        US7 v780 = v699.v.case3.v0; bool v781 = v699.v.case3.v1; static_array<US3,2l> v782 = v699.v.case3.v2; long v783 = v699.v.case3.v3; static_array<long,2l> v784 = v699.v.case3.v4; long v785 = v699.v.case3.v5; US1 v786 = v699.v.case3.v6;
                        long v787;
                        v787 = v780.tag;
                        long * v788;
                        v788 = (long *)(v0+1064ull);
                        v788[0l] = v787;
                        switch (v780.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v789 = v780.v.case1.v0;
                                long v790;
                                v790 = v789.tag;
                                long * v791;
                                v791 = (long *)(v0+1068ull);
                                v791[0l] = v790;
                                switch (v789.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    case 2: { // Queen
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
                        bool * v792;
                        v792 = (bool *)(v0+1072ull);
                        v792[0l] = v781;
                        long v793;
                        v793 = 0l;
                        while (while_method_0(v793)){
                            unsigned long long v795;
                            v795 = (unsigned long long)v793;
                            unsigned long long v796;
                            v796 = v795 * 4ull;
                            unsigned long long v797;
                            v797 = 1076ull + v796;
                            unsigned char * v798;
                            v798 = (unsigned char *)(v0+v797);
                            bool v799;
                            v799 = 0l <= v793;
                            bool v801;
                            if (v799){
                                bool v800;
                                v800 = v793 < 2l;
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
                            US3 v803;
                            v803 = v782.v[v793];
                            long v804;
                            v804 = v803.tag;
                            long * v805;
                            v805 = (long *)(v798+0ull);
                            v805[0l] = v804;
                            switch (v803.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                case 2: { // Queen
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            v793 += 1l ;
                        }
                        long * v806;
                        v806 = (long *)(v0+1084ull);
                        v806[0l] = v783;
                        long v807;
                        v807 = 0l;
                        while (while_method_0(v807)){
                            unsigned long long v809;
                            v809 = (unsigned long long)v807;
                            unsigned long long v810;
                            v810 = v809 * 4ull;
                            unsigned long long v811;
                            v811 = 1088ull + v810;
                            unsigned char * v812;
                            v812 = (unsigned char *)(v0+v811);
                            bool v813;
                            v813 = 0l <= v807;
                            bool v815;
                            if (v813){
                                bool v814;
                                v814 = v807 < 2l;
                                v815 = v814;
                            } else {
                                v815 = false;
                            }
                            bool v816;
                            v816 = v815 == false;
                            if (v816){
                                assert("The read index needs to be in range for the static array." && v815);
                            } else {
                            }
                            long v817;
                            v817 = v784.v[v807];
                            long * v818;
                            v818 = (long *)(v812+0ull);
                            v818[0l] = v817;
                            v807 += 1l ;
                        }
                        long * v819;
                        v819 = (long *)(v0+1096ull);
                        v819[0l] = v785;
                        long v820;
                        v820 = v786.tag;
                        long * v821;
                        v821 = (long *)(v0+1100ull);
                        v821[0l] = v820;
                        switch (v786.tag) {
                            case 0: { // Call
                                break;
                            }
                            case 1: { // Fold
                                break;
                            }
                            case 2: { // Raise
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        break;
                    }
                    case 4: { // TerminalCall
                        US7 v822 = v699.v.case4.v0; bool v823 = v699.v.case4.v1; static_array<US3,2l> v824 = v699.v.case4.v2; long v825 = v699.v.case4.v3; static_array<long,2l> v826 = v699.v.case4.v4; long v827 = v699.v.case4.v5;
                        long v828;
                        v828 = v822.tag;
                        long * v829;
                        v829 = (long *)(v0+1064ull);
                        v829[0l] = v828;
                        switch (v822.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v830 = v822.v.case1.v0;
                                long v831;
                                v831 = v830.tag;
                                long * v832;
                                v832 = (long *)(v0+1068ull);
                                v832[0l] = v831;
                                switch (v830.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    case 2: { // Queen
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
                        bool * v833;
                        v833 = (bool *)(v0+1072ull);
                        v833[0l] = v823;
                        long v834;
                        v834 = 0l;
                        while (while_method_0(v834)){
                            unsigned long long v836;
                            v836 = (unsigned long long)v834;
                            unsigned long long v837;
                            v837 = v836 * 4ull;
                            unsigned long long v838;
                            v838 = 1076ull + v837;
                            unsigned char * v839;
                            v839 = (unsigned char *)(v0+v838);
                            bool v840;
                            v840 = 0l <= v834;
                            bool v842;
                            if (v840){
                                bool v841;
                                v841 = v834 < 2l;
                                v842 = v841;
                            } else {
                                v842 = false;
                            }
                            bool v843;
                            v843 = v842 == false;
                            if (v843){
                                assert("The read index needs to be in range for the static array." && v842);
                            } else {
                            }
                            US3 v844;
                            v844 = v824.v[v834];
                            long v845;
                            v845 = v844.tag;
                            long * v846;
                            v846 = (long *)(v839+0ull);
                            v846[0l] = v845;
                            switch (v844.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                case 2: { // Queen
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            v834 += 1l ;
                        }
                        long * v847;
                        v847 = (long *)(v0+1084ull);
                        v847[0l] = v825;
                        long v848;
                        v848 = 0l;
                        while (while_method_0(v848)){
                            unsigned long long v850;
                            v850 = (unsigned long long)v848;
                            unsigned long long v851;
                            v851 = v850 * 4ull;
                            unsigned long long v852;
                            v852 = 1088ull + v851;
                            unsigned char * v853;
                            v853 = (unsigned char *)(v0+v852);
                            bool v854;
                            v854 = 0l <= v848;
                            bool v856;
                            if (v854){
                                bool v855;
                                v855 = v848 < 2l;
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
                            long v858;
                            v858 = v826.v[v848];
                            long * v859;
                            v859 = (long *)(v853+0ull);
                            v859[0l] = v858;
                            v848 += 1l ;
                        }
                        long * v860;
                        v860 = (long *)(v0+1096ull);
                        v860[0l] = v827;
                        break;
                    }
                    case 5: { // TerminalFold
                        US7 v861 = v699.v.case5.v0; bool v862 = v699.v.case5.v1; static_array<US3,2l> v863 = v699.v.case5.v2; long v864 = v699.v.case5.v3; static_array<long,2l> v865 = v699.v.case5.v4; long v866 = v699.v.case5.v5;
                        long v867;
                        v867 = v861.tag;
                        long * v868;
                        v868 = (long *)(v0+1064ull);
                        v868[0l] = v867;
                        switch (v861.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v869 = v861.v.case1.v0;
                                long v870;
                                v870 = v869.tag;
                                long * v871;
                                v871 = (long *)(v0+1068ull);
                                v871[0l] = v870;
                                switch (v869.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    case 2: { // Queen
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
                        bool * v872;
                        v872 = (bool *)(v0+1072ull);
                        v872[0l] = v862;
                        long v873;
                        v873 = 0l;
                        while (while_method_0(v873)){
                            unsigned long long v875;
                            v875 = (unsigned long long)v873;
                            unsigned long long v876;
                            v876 = v875 * 4ull;
                            unsigned long long v877;
                            v877 = 1076ull + v876;
                            unsigned char * v878;
                            v878 = (unsigned char *)(v0+v877);
                            bool v879;
                            v879 = 0l <= v873;
                            bool v881;
                            if (v879){
                                bool v880;
                                v880 = v873 < 2l;
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
                            US3 v883;
                            v883 = v863.v[v873];
                            long v884;
                            v884 = v883.tag;
                            long * v885;
                            v885 = (long *)(v878+0ull);
                            v885[0l] = v884;
                            switch (v883.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                case 2: { // Queen
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            v873 += 1l ;
                        }
                        long * v886;
                        v886 = (long *)(v0+1084ull);
                        v886[0l] = v864;
                        long v887;
                        v887 = 0l;
                        while (while_method_0(v887)){
                            unsigned long long v889;
                            v889 = (unsigned long long)v887;
                            unsigned long long v890;
                            v890 = v889 * 4ull;
                            unsigned long long v891;
                            v891 = 1088ull + v890;
                            unsigned char * v892;
                            v892 = (unsigned char *)(v0+v891);
                            bool v893;
                            v893 = 0l <= v887;
                            bool v895;
                            if (v893){
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
                            v897 = v865.v[v887];
                            long * v898;
                            v898 = (long *)(v892+0ull);
                            v898[0l] = v897;
                            v887 += 1l ;
                        }
                        long * v899;
                        v899 = (long *)(v0+1096ull);
                        v899[0l] = v866;
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
        long v900;
        v900 = 0l;
        while (while_method_0(v900)){
            unsigned long long v902;
            v902 = (unsigned long long)v900;
            unsigned long long v903;
            v903 = v902 * 4ull;
            unsigned long long v904;
            v904 = 1104ull + v903;
            unsigned char * v905;
            v905 = (unsigned char *)(v0+v904);
            bool v906;
            v906 = 0l <= v900;
            bool v908;
            if (v906){
                bool v907;
                v907 = v900 < 2l;
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
            US2 v910;
            v910 = v630.v[v900];
            long v911;
            v911 = v910.tag;
            long * v912;
            v912 = (long *)(v905+0ull);
            v912[0l] = v911;
            switch (v910.tag) {
                case 0: { // Computer
                    break;
                }
                case 1: { // Human
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v900 += 1l ;
        }
        long v913;
        v913 = v631.tag;
        long * v914;
        v914 = (long *)(v0+1112ull);
        v914[0l] = v913;
        switch (v631.tag) {
            case 0: { // GameNotStarted
                break;
            }
            case 1: { // GameOver
                US7 v915 = v631.v.case1.v0; bool v916 = v631.v.case1.v1; static_array<US3,2l> v917 = v631.v.case1.v2; long v918 = v631.v.case1.v3; static_array<long,2l> v919 = v631.v.case1.v4; long v920 = v631.v.case1.v5;
                long v921;
                v921 = v915.tag;
                long * v922;
                v922 = (long *)(v0+1116ull);
                v922[0l] = v921;
                switch (v915.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v923 = v915.v.case1.v0;
                        long v924;
                        v924 = v923.tag;
                        long * v925;
                        v925 = (long *)(v0+1120ull);
                        v925[0l] = v924;
                        switch (v923.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
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
                bool * v926;
                v926 = (bool *)(v0+1124ull);
                v926[0l] = v916;
                long v927;
                v927 = 0l;
                while (while_method_0(v927)){
                    unsigned long long v929;
                    v929 = (unsigned long long)v927;
                    unsigned long long v930;
                    v930 = v929 * 4ull;
                    unsigned long long v931;
                    v931 = 1128ull + v930;
                    unsigned char * v932;
                    v932 = (unsigned char *)(v0+v931);
                    bool v933;
                    v933 = 0l <= v927;
                    bool v935;
                    if (v933){
                        bool v934;
                        v934 = v927 < 2l;
                        v935 = v934;
                    } else {
                        v935 = false;
                    }
                    bool v936;
                    v936 = v935 == false;
                    if (v936){
                        assert("The read index needs to be in range for the static array." && v935);
                    } else {
                    }
                    US3 v937;
                    v937 = v917.v[v927];
                    long v938;
                    v938 = v937.tag;
                    long * v939;
                    v939 = (long *)(v932+0ull);
                    v939[0l] = v938;
                    switch (v937.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    v927 += 1l ;
                }
                long * v940;
                v940 = (long *)(v0+1136ull);
                v940[0l] = v918;
                long v941;
                v941 = 0l;
                while (while_method_0(v941)){
                    unsigned long long v943;
                    v943 = (unsigned long long)v941;
                    unsigned long long v944;
                    v944 = v943 * 4ull;
                    unsigned long long v945;
                    v945 = 1140ull + v944;
                    unsigned char * v946;
                    v946 = (unsigned char *)(v0+v945);
                    bool v947;
                    v947 = 0l <= v941;
                    bool v949;
                    if (v947){
                        bool v948;
                        v948 = v941 < 2l;
                        v949 = v948;
                    } else {
                        v949 = false;
                    }
                    bool v950;
                    v950 = v949 == false;
                    if (v950){
                        assert("The read index needs to be in range for the static array." && v949);
                    } else {
                    }
                    long v951;
                    v951 = v919.v[v941];
                    long * v952;
                    v952 = (long *)(v946+0ull);
                    v952[0l] = v951;
                    v941 += 1l ;
                }
                long * v953;
                v953 = (long *)(v0+1148ull);
                v953[0l] = v920;
                break;
            }
            case 2: { // WaitingForActionFromPlayerId
                US7 v954 = v631.v.case2.v0; bool v955 = v631.v.case2.v1; static_array<US3,2l> v956 = v631.v.case2.v2; long v957 = v631.v.case2.v3; static_array<long,2l> v958 = v631.v.case2.v4; long v959 = v631.v.case2.v5;
                long v960;
                v960 = v954.tag;
                long * v961;
                v961 = (long *)(v0+1116ull);
                v961[0l] = v960;
                switch (v954.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v962 = v954.v.case1.v0;
                        long v963;
                        v963 = v962.tag;
                        long * v964;
                        v964 = (long *)(v0+1120ull);
                        v964[0l] = v963;
                        switch (v962.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
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
                bool * v965;
                v965 = (bool *)(v0+1124ull);
                v965[0l] = v955;
                long v966;
                v966 = 0l;
                while (while_method_0(v966)){
                    unsigned long long v968;
                    v968 = (unsigned long long)v966;
                    unsigned long long v969;
                    v969 = v968 * 4ull;
                    unsigned long long v970;
                    v970 = 1128ull + v969;
                    unsigned char * v971;
                    v971 = (unsigned char *)(v0+v970);
                    bool v972;
                    v972 = 0l <= v966;
                    bool v974;
                    if (v972){
                        bool v973;
                        v973 = v966 < 2l;
                        v974 = v973;
                    } else {
                        v974 = false;
                    }
                    bool v975;
                    v975 = v974 == false;
                    if (v975){
                        assert("The read index needs to be in range for the static array." && v974);
                    } else {
                    }
                    US3 v976;
                    v976 = v956.v[v966];
                    long v977;
                    v977 = v976.tag;
                    long * v978;
                    v978 = (long *)(v971+0ull);
                    v978[0l] = v977;
                    switch (v976.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    v966 += 1l ;
                }
                long * v979;
                v979 = (long *)(v0+1136ull);
                v979[0l] = v957;
                long v980;
                v980 = 0l;
                while (while_method_0(v980)){
                    unsigned long long v982;
                    v982 = (unsigned long long)v980;
                    unsigned long long v983;
                    v983 = v982 * 4ull;
                    unsigned long long v984;
                    v984 = 1140ull + v983;
                    unsigned char * v985;
                    v985 = (unsigned char *)(v0+v984);
                    bool v986;
                    v986 = 0l <= v980;
                    bool v988;
                    if (v986){
                        bool v987;
                        v987 = v980 < 2l;
                        v988 = v987;
                    } else {
                        v988 = false;
                    }
                    bool v989;
                    v989 = v988 == false;
                    if (v989){
                        assert("The read index needs to be in range for the static array." && v988);
                    } else {
                    }
                    long v990;
                    v990 = v958.v[v980];
                    long * v991;
                    v991 = (long *)(v985+0ull);
                    v991[0l] = v990;
                    v980 += 1l ;
                }
                long * v992;
                v992 = (long *)(v0+1148ull);
                v992[0l] = v959;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        long v993;
        v993 = v60.length;
        long * v994;
        v994 = (long *)(v2+0ull);
        v994[0l] = v993;
        long v995;
        v995 = v60.length;
        long v996;
        v996 = 0l;
        while (while_method_1(v995, v996)){
            unsigned long long v998;
            v998 = (unsigned long long)v996;
            unsigned long long v999;
            v999 = v998 * 32ull;
            unsigned long long v1000;
            v1000 = 16ull + v999;
            unsigned char * v1001;
            v1001 = (unsigned char *)(v2+v1000);
            bool v1002;
            v1002 = 0l <= v996;
            bool v1005;
            if (v1002){
                long v1003;
                v1003 = v60.length;
                bool v1004;
                v1004 = v996 < v1003;
                v1005 = v1004;
            } else {
                v1005 = false;
            }
            bool v1006;
            v1006 = v1005 == false;
            if (v1006){
                assert("The read index needs to be in range for the static array list." && v1005);
            } else {
            }
            US4 v1007;
            v1007 = v60.v[v996];
            long v1008;
            v1008 = v1007.tag;
            long * v1009;
            v1009 = (long *)(v1001+0ull);
            v1009[0l] = v1008;
            switch (v1007.tag) {
                case 0: { // CommunityCardIs
                    US3 v1010 = v1007.v.case0.v0;
                    long v1011;
                    v1011 = v1010.tag;
                    long * v1012;
                    v1012 = (long *)(v1001+4ull);
                    v1012[0l] = v1011;
                    switch (v1010.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 1: { // PlayerAction
                    long v1013 = v1007.v.case1.v0; US1 v1014 = v1007.v.case1.v1;
                    long * v1015;
                    v1015 = (long *)(v1001+4ull);
                    v1015[0l] = v1013;
                    long v1016;
                    v1016 = v1014.tag;
                    long * v1017;
                    v1017 = (long *)(v1001+8ull);
                    v1017[0l] = v1016;
                    switch (v1014.tag) {
                        case 0: { // Call
                            break;
                        }
                        case 1: { // Fold
                            break;
                        }
                        case 2: { // Raise
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 2: { // PlayerGotCard
                    long v1018 = v1007.v.case2.v0; US3 v1019 = v1007.v.case2.v1;
                    long * v1020;
                    v1020 = (long *)(v1001+4ull);
                    v1020[0l] = v1018;
                    long v1021;
                    v1021 = v1019.tag;
                    long * v1022;
                    v1022 = (long *)(v1001+8ull);
                    v1022[0l] = v1021;
                    switch (v1019.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    break;
                }
                case 3: { // Showdown
                    static_array<US3,2l> v1023 = v1007.v.case3.v0; long v1024 = v1007.v.case3.v1; long v1025 = v1007.v.case3.v2;
                    long v1026;
                    v1026 = 0l;
                    while (while_method_0(v1026)){
                        unsigned long long v1028;
                        v1028 = (unsigned long long)v1026;
                        unsigned long long v1029;
                        v1029 = v1028 * 4ull;
                        unsigned long long v1030;
                        v1030 = 4ull + v1029;
                        unsigned char * v1031;
                        v1031 = (unsigned char *)(v1001+v1030);
                        bool v1032;
                        v1032 = 0l <= v1026;
                        bool v1034;
                        if (v1032){
                            bool v1033;
                            v1033 = v1026 < 2l;
                            v1034 = v1033;
                        } else {
                            v1034 = false;
                        }
                        bool v1035;
                        v1035 = v1034 == false;
                        if (v1035){
                            assert("The read index needs to be in range for the static array." && v1034);
                        } else {
                        }
                        US3 v1036;
                        v1036 = v1023.v[v1026];
                        long v1037;
                        v1037 = v1036.tag;
                        long * v1038;
                        v1038 = (long *)(v1031+0ull);
                        v1038[0l] = v1037;
                        switch (v1036.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
                                break;
                            }
                            default: {
                                assert("Invalid tag." && false);
                            }
                        }
                        v1026 += 1l ;
                    }
                    long * v1039;
                    v1039 = (long *)(v1001+12ull);
                    v1039[0l] = v1024;
                    long * v1040;
                    v1040 = (long *)(v1001+16ull);
                    v1040[0l] = v1025;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v996 += 1l ;
        }
        long v1041;
        v1041 = 0l;
        while (while_method_0(v1041)){
            unsigned long long v1043;
            v1043 = (unsigned long long)v1041;
            unsigned long long v1044;
            v1044 = v1043 * 4ull;
            unsigned long long v1045;
            v1045 = 1040ull + v1044;
            unsigned char * v1046;
            v1046 = (unsigned char *)(v2+v1045);
            bool v1047;
            v1047 = 0l <= v1041;
            bool v1049;
            if (v1047){
                bool v1048;
                v1048 = v1041 < 2l;
                v1049 = v1048;
            } else {
                v1049 = false;
            }
            bool v1050;
            v1050 = v1049 == false;
            if (v1050){
                assert("The read index needs to be in range for the static array." && v1049);
            } else {
            }
            US2 v1051;
            v1051 = v630.v[v1041];
            long v1052;
            v1052 = v1051.tag;
            long * v1053;
            v1053 = (long *)(v1046+0ull);
            v1053[0l] = v1052;
            switch (v1051.tag) {
                case 0: { // Computer
                    break;
                }
                case 1: { // Human
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v1041 += 1l ;
        }
        long * v1054;
        v1054 = (long *)(v2+1048ull);
        v1054[0l] = v913;
        switch (v631.tag) {
            case 0: { // GameNotStarted
                return ;
                break;
            }
            case 1: { // GameOver
                US7 v1055 = v631.v.case1.v0; bool v1056 = v631.v.case1.v1; static_array<US3,2l> v1057 = v631.v.case1.v2; long v1058 = v631.v.case1.v3; static_array<long,2l> v1059 = v631.v.case1.v4; long v1060 = v631.v.case1.v5;
                long v1061;
                v1061 = v1055.tag;
                long * v1062;
                v1062 = (long *)(v2+1052ull);
                v1062[0l] = v1061;
                switch (v1055.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v1063 = v1055.v.case1.v0;
                        long v1064;
                        v1064 = v1063.tag;
                        long * v1065;
                        v1065 = (long *)(v2+1056ull);
                        v1065[0l] = v1064;
                        switch (v1063.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
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
                bool * v1066;
                v1066 = (bool *)(v2+1060ull);
                v1066[0l] = v1056;
                long v1067;
                v1067 = 0l;
                while (while_method_0(v1067)){
                    unsigned long long v1069;
                    v1069 = (unsigned long long)v1067;
                    unsigned long long v1070;
                    v1070 = v1069 * 4ull;
                    unsigned long long v1071;
                    v1071 = 1064ull + v1070;
                    unsigned char * v1072;
                    v1072 = (unsigned char *)(v2+v1071);
                    bool v1073;
                    v1073 = 0l <= v1067;
                    bool v1075;
                    if (v1073){
                        bool v1074;
                        v1074 = v1067 < 2l;
                        v1075 = v1074;
                    } else {
                        v1075 = false;
                    }
                    bool v1076;
                    v1076 = v1075 == false;
                    if (v1076){
                        assert("The read index needs to be in range for the static array." && v1075);
                    } else {
                    }
                    US3 v1077;
                    v1077 = v1057.v[v1067];
                    long v1078;
                    v1078 = v1077.tag;
                    long * v1079;
                    v1079 = (long *)(v1072+0ull);
                    v1079[0l] = v1078;
                    switch (v1077.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    v1067 += 1l ;
                }
                long * v1080;
                v1080 = (long *)(v2+1072ull);
                v1080[0l] = v1058;
                long v1081;
                v1081 = 0l;
                while (while_method_0(v1081)){
                    unsigned long long v1083;
                    v1083 = (unsigned long long)v1081;
                    unsigned long long v1084;
                    v1084 = v1083 * 4ull;
                    unsigned long long v1085;
                    v1085 = 1076ull + v1084;
                    unsigned char * v1086;
                    v1086 = (unsigned char *)(v2+v1085);
                    bool v1087;
                    v1087 = 0l <= v1081;
                    bool v1089;
                    if (v1087){
                        bool v1088;
                        v1088 = v1081 < 2l;
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
                    long v1091;
                    v1091 = v1059.v[v1081];
                    long * v1092;
                    v1092 = (long *)(v1086+0ull);
                    v1092[0l] = v1091;
                    v1081 += 1l ;
                }
                long * v1093;
                v1093 = (long *)(v2+1084ull);
                v1093[0l] = v1060;
                return ;
                break;
            }
            case 2: { // WaitingForActionFromPlayerId
                US7 v1094 = v631.v.case2.v0; bool v1095 = v631.v.case2.v1; static_array<US3,2l> v1096 = v631.v.case2.v2; long v1097 = v631.v.case2.v3; static_array<long,2l> v1098 = v631.v.case2.v4; long v1099 = v631.v.case2.v5;
                long v1100;
                v1100 = v1094.tag;
                long * v1101;
                v1101 = (long *)(v2+1052ull);
                v1101[0l] = v1100;
                switch (v1094.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v1102 = v1094.v.case1.v0;
                        long v1103;
                        v1103 = v1102.tag;
                        long * v1104;
                        v1104 = (long *)(v2+1056ull);
                        v1104[0l] = v1103;
                        switch (v1102.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            case 2: { // Queen
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
                bool * v1105;
                v1105 = (bool *)(v2+1060ull);
                v1105[0l] = v1095;
                long v1106;
                v1106 = 0l;
                while (while_method_0(v1106)){
                    unsigned long long v1108;
                    v1108 = (unsigned long long)v1106;
                    unsigned long long v1109;
                    v1109 = v1108 * 4ull;
                    unsigned long long v1110;
                    v1110 = 1064ull + v1109;
                    unsigned char * v1111;
                    v1111 = (unsigned char *)(v2+v1110);
                    bool v1112;
                    v1112 = 0l <= v1106;
                    bool v1114;
                    if (v1112){
                        bool v1113;
                        v1113 = v1106 < 2l;
                        v1114 = v1113;
                    } else {
                        v1114 = false;
                    }
                    bool v1115;
                    v1115 = v1114 == false;
                    if (v1115){
                        assert("The read index needs to be in range for the static array." && v1114);
                    } else {
                    }
                    US3 v1116;
                    v1116 = v1096.v[v1106];
                    long v1117;
                    v1117 = v1116.tag;
                    long * v1118;
                    v1118 = (long *)(v1111+0ull);
                    v1118[0l] = v1117;
                    switch (v1116.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        case 2: { // Queen
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    v1106 += 1l ;
                }
                long * v1119;
                v1119 = (long *)(v2+1072ull);
                v1119[0l] = v1097;
                long v1120;
                v1120 = 0l;
                while (while_method_0(v1120)){
                    unsigned long long v1122;
                    v1122 = (unsigned long long)v1120;
                    unsigned long long v1123;
                    v1123 = v1122 * 4ull;
                    unsigned long long v1124;
                    v1124 = 1076ull + v1123;
                    unsigned char * v1125;
                    v1125 = (unsigned char *)(v2+v1124);
                    bool v1126;
                    v1126 = 0l <= v1120;
                    bool v1128;
                    if (v1126){
                        bool v1127;
                        v1127 = v1120 < 2l;
                        v1128 = v1127;
                    } else {
                        v1128 = false;
                    }
                    bool v1129;
                    v1129 = v1128 == false;
                    if (v1129){
                        assert("The read index needs to be in range for the static array." && v1128);
                    } else {
                    }
                    long v1130;
                    v1130 = v1098.v[v1120];
                    long * v1131;
                    v1131 = (long *)(v1125+0ull);
                    v1131[0l] = v1130;
                    v1120 += 1l ;
                }
                long * v1132;
                v1132 = (long *)(v2+1084ull);
                v1132[0l] = v1099;
                return ;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
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

import random
options = []
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
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
class US3_0(NamedTuple): # Jack
    tag = 0
class US3_1(NamedTuple): # King
    tag = 1
class US3_2(NamedTuple): # Queen
    tag = 2
US3 = Union[US3_0, US3_1, US3_2]
class US6_0(NamedTuple): # None
    tag = 0
class US6_1(NamedTuple): # Some
    v0 : US3
    tag = 1
US6 = Union[US6_0, US6_1]
class US5_0(NamedTuple): # ChanceCommunityCard
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 0
class US5_1(NamedTuple): # ChanceInit
    tag = 1
class US5_2(NamedTuple): # Round
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 2
class US5_3(NamedTuple): # RoundWithAction
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    v6 : US1
    tag = 3
class US5_4(NamedTuple): # TerminalCall
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 4
class US5_5(NamedTuple): # TerminalFold
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 5
US5 = Union[US5_0, US5_1, US5_2, US5_3, US5_4, US5_5]
class US4_0(NamedTuple): # None
    tag = 0
class US4_1(NamedTuple): # Some
    v0 : US5
    tag = 1
US4 = Union[US4_0, US4_1]
class US7_0(NamedTuple): # GameNotStarted
    tag = 0
class US7_1(NamedTuple): # GameOver
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 1
class US7_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US6
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : i32
    tag = 2
US7 = Union[US7_0, US7_1, US7_2]
class US8_0(NamedTuple): # CommunityCardIs
    v0 : US3
    tag = 0
class US8_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US8_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US3
    tag = 2
class US8_3(NamedTuple): # Showdown
    v0 : static_array
    v1 : i32
    v2 : i32
    tag = 3
US8 = Union[US8_0, US8_1, US8_2, US8_3]
def method0(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method1(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method3(v0 : US3) -> object:
    match v0:
        case US3_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US3_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method5(v0 : US1) -> object:
    match v0:
        case US1_0(): # Call
            del v0
            v1 = []
            v2 = "Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # Fold
            del v0
            v4 = []
            v5 = "Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(): # Raise
            del v0
            v7 = []
            v8 = "Raise"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method4(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method3(v1)
            del v1
            v3 = "CommunityCardIs"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US8_1(v5, v6): # PlayerAction
            del v0
            v7 = []
            v8 = v5
            del v5
            v7.append(v8)
            del v8
            v9 = method5(v6)
            del v6
            v7.append(v9)
            del v9
            v10 = v7
            del v7
            v11 = "PlayerAction"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US8_2(v13, v14): # PlayerGotCard
            del v0
            v15 = []
            v16 = v13
            del v13
            v15.append(v16)
            del v16
            v17 = method3(v14)
            del v14
            v15.append(v17)
            del v17
            v18 = v15
            del v15
            v19 = "PlayerGotCard"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US8_3(v21, v22, v23): # Showdown
            del v0
            v24 = []
            v25 = 0
            while method1(v25):
                v27 = 0 <= v25
                if v27:
                    v28 = v25 < 2
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
                v32 = v21[v25]
                v33 = method3(v32)
                del v32
                v24.append(v33)
                del v33
                v25 += 1 
            del v21, v25
            v34 = v22
            del v22
            v35 = v23
            del v23
            v36 = {'cards_shown': v24, 'chips_won': v34, 'winner_id': v35}
            del v24, v34, v35
            v37 = "Showdown"
            v38 = [v37,v36]
            del v36, v37
            return v38
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method8(v0 : US6) -> object:
    match v0:
        case US6_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4): # Some
            del v0
            v5 = method3(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method7(v0 : US5) -> object:
    match v0:
        case US5_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method8(v1)
            del v1
            v8 = v2
            del v2
            v9 = []
            v10 = 0
            while method1(v10):
                v12 = 0 <= v10
                if v12:
                    v13 = v10 < 2
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
                v17 = v3[v10]
                v18 = method3(v17)
                del v17
                v9.append(v18)
                del v18
                v10 += 1 
            del v3, v10
            v19 = v4
            del v4
            v20 = []
            v21 = 0
            while method1(v21):
                v23 = 0 <= v21
                if v23:
                    v24 = v21 < 2
                    v25 = v24
                else:
                    v25 = False
                del v23
                v26 = v25 == False
                if v26:
                    v27 = "The read index needs to be in range for the static array."
                    assert v25, v27
                    del v27
                else:
                    pass
                del v25, v26
                v28 = v5[v21]
                v29 = v28
                del v28
                v20.append(v29)
                del v29
                v21 += 1 
            del v5, v21
            v30 = v6
            del v6
            v31 = {'community_card': v7, 'is_button_s_first_move': v8, 'pl_card': v9, 'player_turn': v19, 'pot': v20, 'raises_left': v30}
            del v7, v8, v9, v19, v20, v30
            v32 = "ChanceCommunityCard"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US5_1(): # ChanceInit
            del v0
            v34 = []
            v35 = "ChanceInit"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US5_2(v37, v38, v39, v40, v41, v42): # Round
            del v0
            v43 = method8(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method1(v46):
                v48 = 0 <= v46
                if v48:
                    v49 = v46 < 2
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
                v53 = v39[v46]
                v54 = method3(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method1(v57):
                v59 = 0 <= v57
                if v59:
                    v60 = v57 < 2
                    v61 = v60
                else:
                    v61 = False
                del v59
                v62 = v61 == False
                if v62:
                    v63 = "The read index needs to be in range for the static array."
                    assert v61, v63
                    del v63
                else:
                    pass
                del v61, v62
                v64 = v41[v57]
                v65 = v64
                del v64
                v56.append(v65)
                del v65
                v57 += 1 
            del v41, v57
            v66 = v42
            del v42
            v67 = {'community_card': v43, 'is_button_s_first_move': v44, 'pl_card': v45, 'player_turn': v55, 'pot': v56, 'raises_left': v66}
            del v43, v44, v45, v55, v56, v66
            v68 = "Round"
            v69 = [v68,v67]
            del v67, v68
            return v69
        case US5_3(v70, v71, v72, v73, v74, v75, v76): # RoundWithAction
            del v0
            v77 = []
            v78 = method8(v70)
            del v70
            v79 = v71
            del v71
            v80 = []
            v81 = 0
            while method1(v81):
                v83 = 0 <= v81
                if v83:
                    v84 = v81 < 2
                    v85 = v84
                else:
                    v85 = False
                del v83
                v86 = v85 == False
                if v86:
                    v87 = "The read index needs to be in range for the static array."
                    assert v85, v87
                    del v87
                else:
                    pass
                del v85, v86
                v88 = v72[v81]
                v89 = method3(v88)
                del v88
                v80.append(v89)
                del v89
                v81 += 1 
            del v72, v81
            v90 = v73
            del v73
            v91 = []
            v92 = 0
            while method1(v92):
                v94 = 0 <= v92
                if v94:
                    v95 = v92 < 2
                    v96 = v95
                else:
                    v96 = False
                del v94
                v97 = v96 == False
                if v97:
                    v98 = "The read index needs to be in range for the static array."
                    assert v96, v98
                    del v98
                else:
                    pass
                del v96, v97
                v99 = v74[v92]
                v100 = v99
                del v99
                v91.append(v100)
                del v100
                v92 += 1 
            del v74, v92
            v101 = v75
            del v75
            v102 = {'community_card': v78, 'is_button_s_first_move': v79, 'pl_card': v80, 'player_turn': v90, 'pot': v91, 'raises_left': v101}
            del v78, v79, v80, v90, v91, v101
            v77.append(v102)
            del v102
            v103 = method5(v76)
            del v76
            v77.append(v103)
            del v103
            v104 = v77
            del v77
            v105 = "RoundWithAction"
            v106 = [v105,v104]
            del v104, v105
            return v106
        case US5_4(v107, v108, v109, v110, v111, v112): # TerminalCall
            del v0
            v113 = method8(v107)
            del v107
            v114 = v108
            del v108
            v115 = []
            v116 = 0
            while method1(v116):
                v118 = 0 <= v116
                if v118:
                    v119 = v116 < 2
                    v120 = v119
                else:
                    v120 = False
                del v118
                v121 = v120 == False
                if v121:
                    v122 = "The read index needs to be in range for the static array."
                    assert v120, v122
                    del v122
                else:
                    pass
                del v120, v121
                v123 = v109[v116]
                v124 = method3(v123)
                del v123
                v115.append(v124)
                del v124
                v116 += 1 
            del v109, v116
            v125 = v110
            del v110
            v126 = []
            v127 = 0
            while method1(v127):
                v129 = 0 <= v127
                if v129:
                    v130 = v127 < 2
                    v131 = v130
                else:
                    v131 = False
                del v129
                v132 = v131 == False
                if v132:
                    v133 = "The read index needs to be in range for the static array."
                    assert v131, v133
                    del v133
                else:
                    pass
                del v131, v132
                v134 = v111[v127]
                v135 = v134
                del v134
                v126.append(v135)
                del v135
                v127 += 1 
            del v111, v127
            v136 = v112
            del v112
            v137 = {'community_card': v113, 'is_button_s_first_move': v114, 'pl_card': v115, 'player_turn': v125, 'pot': v126, 'raises_left': v136}
            del v113, v114, v115, v125, v126, v136
            v138 = "TerminalCall"
            v139 = [v138,v137]
            del v137, v138
            return v139
        case US5_5(v140, v141, v142, v143, v144, v145): # TerminalFold
            del v0
            v146 = method8(v140)
            del v140
            v147 = v141
            del v141
            v148 = []
            v149 = 0
            while method1(v149):
                v151 = 0 <= v149
                if v151:
                    v152 = v149 < 2
                    v153 = v152
                else:
                    v153 = False
                del v151
                v154 = v153 == False
                if v154:
                    v155 = "The read index needs to be in range for the static array."
                    assert v153, v155
                    del v155
                else:
                    pass
                del v153, v154
                v156 = v142[v149]
                v157 = method3(v156)
                del v156
                v148.append(v157)
                del v157
                v149 += 1 
            del v142, v149
            v158 = v143
            del v143
            v159 = []
            v160 = 0
            while method1(v160):
                v162 = 0 <= v160
                if v162:
                    v163 = v160 < 2
                    v164 = v163
                else:
                    v164 = False
                del v162
                v165 = v164 == False
                if v165:
                    v166 = "The read index needs to be in range for the static array."
                    assert v164, v166
                    del v166
                else:
                    pass
                del v164, v165
                v167 = v144[v160]
                v168 = v167
                del v167
                v159.append(v168)
                del v168
                v160 += 1 
            del v144, v160
            v169 = v145
            del v145
            v170 = {'community_card': v146, 'is_button_s_first_move': v147, 'pl_card': v148, 'player_turn': v158, 'pot': v159, 'raises_left': v169}
            del v146, v147, v148, v158, v159, v169
            v171 = "TerminalFold"
            v172 = [v171,v170]
            del v170, v171
            return v172
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method6(v0 : US4) -> object:
    match v0:
        case US4_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(v4): # Some
            del v0
            v5 = method7(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method9(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = []
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = []
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method10(v0 : US7) -> object:
    match v0:
        case US7_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US7_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method8(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method1(v13):
                v15 = 0 <= v13
                if v15:
                    v16 = v13 < 2
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
                v20 = v6[v13]
                v21 = method3(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method1(v24):
                v26 = 0 <= v24
                if v26:
                    v27 = v24 < 2
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
                v31 = v8[v24]
                v32 = v31
                del v31
                v23.append(v32)
                del v32
                v24 += 1 
            del v8, v24
            v33 = v9
            del v9
            v34 = {'community_card': v10, 'is_button_s_first_move': v11, 'pl_card': v12, 'player_turn': v22, 'pot': v23, 'raises_left': v33}
            del v10, v11, v12, v22, v23, v33
            v35 = "GameOver"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US7_2(v37, v38, v39, v40, v41, v42): # WaitingForActionFromPlayerId
            del v0
            v43 = method8(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method1(v46):
                v48 = 0 <= v46
                if v48:
                    v49 = v46 < 2
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
                v53 = v39[v46]
                v54 = method3(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method1(v57):
                v59 = 0 <= v57
                if v59:
                    v60 = v57 < 2
                    v61 = v60
                else:
                    v61 = False
                del v59
                v62 = v61 == False
                if v62:
                    v63 = "The read index needs to be in range for the static array."
                    assert v61, v63
                    del v63
                else:
                    pass
                del v61, v62
                v64 = v41[v57]
                v65 = v64
                del v64
                v56.append(v65)
                del v65
                v57 += 1 
            del v41, v57
            v66 = v42
            del v42
            v67 = {'community_card': v43, 'is_button_s_first_move': v44, 'pl_card': v45, 'player_turn': v55, 'pot': v56, 'raises_left': v66}
            del v43, v44, v45, v55, v56, v66
            v68 = "WaitingForActionFromPlayerId"
            v69 = [v68,v67]
            del v67, v68
            return v69
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method2(v0 : static_array_list, v1 : static_array_list, v2 : US4, v3 : static_array, v4 : US7) -> object:
    v5 = []
    v6 = v0.length
    v7 = 0
    while method0(v6, v7):
        v9 = 0 <= v7
        if v9:
            v10 = v0.length
            v11 = v7 < v10
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
        v15 = v0[v7]
        v16 = method3(v15)
        del v15
        v5.append(v16)
        del v16
        v7 += 1 
    del v0, v6, v7
    v17 = []
    v18 = v1.length
    v19 = 0
    while method0(v18, v19):
        v21 = 0 <= v19
        if v21:
            v22 = v1.length
            v23 = v19 < v22
            del v22
            v24 = v23
        else:
            v24 = False
        del v21
        v25 = v24 == False
        if v25:
            v26 = "The read index needs to be in range for the static array list."
            assert v24, v26
            del v26
        else:
            pass
        del v24, v25
        v27 = v1[v19]
        v28 = method4(v27)
        del v27
        v17.append(v28)
        del v28
        v19 += 1 
    del v1, v18, v19
    v29 = {'deck': v5, 'messages': v17}
    del v5, v17
    v30 = method6(v2)
    del v2
    v31 = []
    v32 = 0
    while method1(v32):
        v34 = 0 <= v32
        if v34:
            v35 = v32 < 2
            v36 = v35
        else:
            v36 = False
        del v34
        v37 = v36 == False
        if v37:
            v38 = "The read index needs to be in range for the static array."
            assert v36, v38
            del v38
        else:
            pass
        del v36, v37
        v39 = v3[v32]
        v40 = method9(v39)
        del v39
        v31.append(v40)
        del v40
        v32 += 1 
    del v3, v32
    v41 = method10(v4)
    del v4
    v42 = {'game': v30, 'pl_type': v31, 'ui_game_state': v41}
    del v30, v31, v41
    v43 = {'large': v29, 'small': v42}
    del v29, v42
    return v43
def method11(v0 : static_array_list, v1 : static_array, v2 : US7) -> object:
    v3 = []
    v4 = v0.length
    v5 = 0
    while method0(v4, v5):
        v7 = 0 <= v5
        if v7:
            v8 = v0.length
            v9 = v5 < v8
            del v8
            v10 = v9
        else:
            v10 = False
        del v7
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array list."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v0[v5]
        v14 = method4(v13)
        del v13
        v3.append(v14)
        del v14
        v5 += 1 
    del v0, v4, v5
    v15 = []
    v16 = 0
    while method1(v16):
        v18 = 0 <= v16
        if v18:
            v19 = v16 < 2
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
        v23 = v1[v16]
        v24 = method9(v23)
        del v23
        v15.append(v24)
        del v24
        v16 += 1 
    del v1, v16
    v25 = method10(v2)
    del v2
    v26 = {'messages': v3, 'pl_type': v15, 'ui_game_state': v25}
    del v3, v15, v25
    return v26
def main():
    v0 = cp.empty(16,dtype=cp.uint8)
    v1 = cp.empty(1152,dtype=cp.uint8)
    v2 = cp.empty(1088,dtype=cp.uint8)
    v3 = US0_2()
    v4 = static_array(2)
    v5 = US2_0()
    v4[0] = v5
    del v5
    v6 = US2_0()
    v4[1] = v6
    del v6
    v7 = static_array_list(6)
    v7.length = 6
    v8 = v7.length
    v9 = 0 < v8
    del v8
    v10 = v9 == False
    if v10:
        v11 = "The set index needs to be in range for the static array list."
        assert v9, v11
        del v11
    else:
        pass
    del v9, v10
    v12 = US3_1()
    v7[0] = v12
    del v12
    v13 = v7.length
    v14 = 1 < v13
    del v13
    v15 = v14 == False
    if v15:
        v16 = "The set index needs to be in range for the static array list."
        assert v14, v16
        del v16
    else:
        pass
    del v14, v15
    v17 = US3_1()
    v7[1] = v17
    del v17
    v18 = v7.length
    v19 = 2 < v18
    del v18
    v20 = v19 == False
    if v20:
        v21 = "The set index needs to be in range for the static array list."
        assert v19, v21
        del v21
    else:
        pass
    del v19, v20
    v22 = US3_2()
    v7[2] = v22
    del v22
    v23 = v7.length
    v24 = 3 < v23
    del v23
    v25 = v24 == False
    if v25:
        v26 = "The set index needs to be in range for the static array list."
        assert v24, v26
        del v26
    else:
        pass
    del v24, v25
    v27 = US3_2()
    v7[3] = v27
    del v27
    v28 = v7.length
    v29 = 4 < v28
    del v28
    v30 = v29 == False
    if v30:
        v31 = "The set index needs to be in range for the static array list."
        assert v29, v31
        del v31
    else:
        pass
    del v29, v30
    v32 = US3_0()
    v7[4] = v32
    del v32
    v33 = v7.length
    v34 = 5 < v33
    del v33
    v35 = v34 == False
    if v35:
        v36 = "The set index needs to be in range for the static array list."
        assert v34, v36
        del v36
    else:
        pass
    del v34, v35
    v37 = US3_0()
    v7[5] = v37
    del v37
    v38 = v7.length
    v39 = v38 - 1
    del v38
    v40 = 0
    while method0(v39, v40):
        v42 = v7.length
        v43 = random.randrange(v40, v42)
        del v42
        v44 = 0 <= v40
        if v44:
            v45 = v7.length
            v46 = v40 < v45
            del v45
            v47 = v46
        else:
            v47 = False
        v48 = v47 == False
        if v48:
            v49 = "The read index needs to be in range for the static array list."
            assert v47, v49
            del v49
        else:
            pass
        del v47, v48
        v50 = v7[v40]
        v51 = 0 <= v43
        if v51:
            v52 = v7.length
            v53 = v43 < v52
            del v52
            v54 = v53
        else:
            v54 = False
        v55 = v54 == False
        if v55:
            v56 = "The read index needs to be in range for the static array list."
            assert v54, v56
            del v56
        else:
            pass
        del v54, v55
        v57 = v7[v43]
        if v44:
            v58 = v7.length
            v59 = v40 < v58
            del v58
            v60 = v59
        else:
            v60 = False
        del v44
        v61 = v60 == False
        if v61:
            v62 = "The set index needs to be in range for the static array list."
            assert v60, v62
            del v62
        else:
            pass
        del v60, v61
        v7[v40] = v57
        del v57
        if v51:
            v63 = v7.length
            v64 = v43 < v63
            del v63
            v65 = v64
        else:
            v65 = False
        del v51
        v66 = v65 == False
        if v66:
            v67 = "The set index needs to be in range for the static array list."
            assert v65, v67
            del v67
        else:
            pass
        del v65, v66
        v7[v43] = v50
        del v43, v50
        v40 += 1 
    del v39, v40
    v68 = static_array_list(32)
    v69 = US4_0()
    v70 = US7_0()
    v71 = v3.tag
    v72 = v0[0:].view(cp.int32)
    v72[0] = v71
    del v71, v72
    match v3:
        case US0_0(v73): # ActionSelected
            v74 = v73.tag
            v75 = v0[4:].view(cp.int32)
            v75[0] = v74
            del v74, v75
            match v73:
                case US1_0(): # Call
                    del v73
                case US1_1(): # Fold
                    del v73
                case US1_2(): # Raise
                    del v73
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case US0_1(v76): # PlayerChanged
            v77 = 0
            while method1(v77):
                v79 = u64(v77)
                v80 = v79 * 4
                del v79
                v81 = 4 + v80
                del v80
                v82 = v0[v81:].view(cp.uint8)
                del v81
                v83 = 0 <= v77
                if v83:
                    v84 = v77 < 2
                    v85 = v84
                else:
                    v85 = False
                del v83
                v86 = v85 == False
                if v86:
                    v87 = "The read index needs to be in range for the static array."
                    assert v85, v87
                    del v87
                else:
                    pass
                del v85, v86
                v88 = v76[v77]
                v89 = v88.tag
                v90 = v82[0:].view(cp.int32)
                del v82
                v90[0] = v89
                del v89, v90
                match v88:
                    case US2_0(): # Computer
                        pass
                    case US2_1(): # Human
                        pass
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v88
                v77 += 1 
            del v76, v77
        case US0_2(): # StartGame
            pass
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3
    v91 = v7.length
    v92 = v1[0:].view(cp.int32)
    v92[0] = v91
    del v91, v92
    v93 = v7.length
    v94 = 0
    while method0(v93, v94):
        v96 = u64(v94)
        v97 = v96 * 4
        del v96
        v98 = 4 + v97
        del v97
        v99 = v1[v98:].view(cp.uint8)
        del v98
        v100 = 0 <= v94
        if v100:
            v101 = v7.length
            v102 = v94 < v101
            del v101
            v103 = v102
        else:
            v103 = False
        del v100
        v104 = v103 == False
        if v104:
            v105 = "The read index needs to be in range for the static array list."
            assert v103, v105
            del v105
        else:
            pass
        del v103, v104
        v106 = v7[v94]
        v107 = v106.tag
        v108 = v99[0:].view(cp.int32)
        del v99
        v108[0] = v107
        del v107, v108
        match v106:
            case US3_0(): # Jack
                pass
            case US3_1(): # King
                pass
            case US3_2(): # Queen
                pass
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v106
        v94 += 1 
    del v7, v93, v94
    v109 = v68.length
    v110 = v1[28:].view(cp.int32)
    v110[0] = v109
    del v109, v110
    v111 = v68.length
    v112 = 0
    while method0(v111, v112):
        v114 = u64(v112)
        v115 = v114 * 32
        del v114
        v116 = 32 + v115
        del v115
        v117 = v1[v116:].view(cp.uint8)
        del v116
        v118 = 0 <= v112
        if v118:
            v119 = v68.length
            v120 = v112 < v119
            del v119
            v121 = v120
        else:
            v121 = False
        del v118
        v122 = v121 == False
        if v122:
            v123 = "The read index needs to be in range for the static array list."
            assert v121, v123
            del v123
        else:
            pass
        del v121, v122
        v124 = v68[v112]
        v125 = v124.tag
        v126 = v117[0:].view(cp.int32)
        v126[0] = v125
        del v125, v126
        match v124:
            case US8_0(v127): # CommunityCardIs
                v128 = v127.tag
                v129 = v117[4:].view(cp.int32)
                v129[0] = v128
                del v128, v129
                match v127:
                    case US3_0(): # Jack
                        del v127
                    case US3_1(): # King
                        del v127
                    case US3_2(): # Queen
                        del v127
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US8_1(v130, v131): # PlayerAction
                v132 = v117[4:].view(cp.int32)
                v132[0] = v130
                del v130, v132
                v133 = v131.tag
                v134 = v117[8:].view(cp.int32)
                v134[0] = v133
                del v133, v134
                match v131:
                    case US1_0(): # Call
                        del v131
                    case US1_1(): # Fold
                        del v131
                    case US1_2(): # Raise
                        del v131
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US8_2(v135, v136): # PlayerGotCard
                v137 = v117[4:].view(cp.int32)
                v137[0] = v135
                del v135, v137
                v138 = v136.tag
                v139 = v117[8:].view(cp.int32)
                v139[0] = v138
                del v138, v139
                match v136:
                    case US3_0(): # Jack
                        del v136
                    case US3_1(): # King
                        del v136
                    case US3_2(): # Queen
                        del v136
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US8_3(v140, v141, v142): # Showdown
                v143 = 0
                while method1(v143):
                    v145 = u64(v143)
                    v146 = v145 * 4
                    del v145
                    v147 = 4 + v146
                    del v146
                    v148 = v117[v147:].view(cp.uint8)
                    del v147
                    v149 = 0 <= v143
                    if v149:
                        v150 = v143 < 2
                        v151 = v150
                    else:
                        v151 = False
                    del v149
                    v152 = v151 == False
                    if v152:
                        v153 = "The read index needs to be in range for the static array."
                        assert v151, v153
                        del v153
                    else:
                        pass
                    del v151, v152
                    v154 = v140[v143]
                    v155 = v154.tag
                    v156 = v148[0:].view(cp.int32)
                    del v148
                    v156[0] = v155
                    del v155, v156
                    match v154:
                        case US3_0(): # Jack
                            pass
                        case US3_1(): # King
                            pass
                        case US3_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v154
                    v143 += 1 
                del v140, v143
                v157 = v117[12:].view(cp.int32)
                v157[0] = v141
                del v141, v157
                v158 = v117[16:].view(cp.int32)
                v158[0] = v142
                del v142, v158
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v117, v124
        v112 += 1 
    del v68, v111, v112
    v159 = v69.tag
    v160 = v1[1056:].view(cp.int32)
    v160[0] = v159
    del v159, v160
    match v69:
        case US4_0(): # None
            pass
        case US4_1(v161): # Some
            v162 = v161.tag
            v163 = v1[1060:].view(cp.int32)
            v163[0] = v162
            del v162, v163
            match v161:
                case US5_0(v164, v165, v166, v167, v168, v169): # ChanceCommunityCard
                    del v161
                    v170 = v164.tag
                    v171 = v1[1064:].view(cp.int32)
                    v171[0] = v170
                    del v170, v171
                    match v164:
                        case US6_0(): # None
                            pass
                        case US6_1(v172): # Some
                            v173 = v172.tag
                            v174 = v1[1068:].view(cp.int32)
                            v174[0] = v173
                            del v173, v174
                            match v172:
                                case US3_0(): # Jack
                                    del v172
                                case US3_1(): # King
                                    del v172
                                case US3_2(): # Queen
                                    del v172
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v164
                    v175 = v1[1072:].view(cp.int8)
                    v175[0] = v165
                    del v165, v175
                    v176 = 0
                    while method1(v176):
                        v178 = u64(v176)
                        v179 = v178 * 4
                        del v178
                        v180 = 1076 + v179
                        del v179
                        v181 = v1[v180:].view(cp.uint8)
                        del v180
                        v182 = 0 <= v176
                        if v182:
                            v183 = v176 < 2
                            v184 = v183
                        else:
                            v184 = False
                        del v182
                        v185 = v184 == False
                        if v185:
                            v186 = "The read index needs to be in range for the static array."
                            assert v184, v186
                            del v186
                        else:
                            pass
                        del v184, v185
                        v187 = v166[v176]
                        v188 = v187.tag
                        v189 = v181[0:].view(cp.int32)
                        del v181
                        v189[0] = v188
                        del v188, v189
                        match v187:
                            case US3_0(): # Jack
                                pass
                            case US3_1(): # King
                                pass
                            case US3_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v187
                        v176 += 1 
                    del v166, v176
                    v190 = v1[1084:].view(cp.int32)
                    v190[0] = v167
                    del v167, v190
                    v191 = 0
                    while method1(v191):
                        v193 = u64(v191)
                        v194 = v193 * 4
                        del v193
                        v195 = 1088 + v194
                        del v194
                        v196 = v1[v195:].view(cp.uint8)
                        del v195
                        v197 = 0 <= v191
                        if v197:
                            v198 = v191 < 2
                            v199 = v198
                        else:
                            v199 = False
                        del v197
                        v200 = v199 == False
                        if v200:
                            v201 = "The read index needs to be in range for the static array."
                            assert v199, v201
                            del v201
                        else:
                            pass
                        del v199, v200
                        v202 = v168[v191]
                        v203 = v196[0:].view(cp.int32)
                        del v196
                        v203[0] = v202
                        del v202, v203
                        v191 += 1 
                    del v168, v191
                    v204 = v1[1096:].view(cp.int32)
                    v204[0] = v169
                    del v169, v204
                case US5_1(): # ChanceInit
                    del v161
                case US5_2(v205, v206, v207, v208, v209, v210): # Round
                    del v161
                    v211 = v205.tag
                    v212 = v1[1064:].view(cp.int32)
                    v212[0] = v211
                    del v211, v212
                    match v205:
                        case US6_0(): # None
                            pass
                        case US6_1(v213): # Some
                            v214 = v213.tag
                            v215 = v1[1068:].view(cp.int32)
                            v215[0] = v214
                            del v214, v215
                            match v213:
                                case US3_0(): # Jack
                                    del v213
                                case US3_1(): # King
                                    del v213
                                case US3_2(): # Queen
                                    del v213
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v205
                    v216 = v1[1072:].view(cp.int8)
                    v216[0] = v206
                    del v206, v216
                    v217 = 0
                    while method1(v217):
                        v219 = u64(v217)
                        v220 = v219 * 4
                        del v219
                        v221 = 1076 + v220
                        del v220
                        v222 = v1[v221:].view(cp.uint8)
                        del v221
                        v223 = 0 <= v217
                        if v223:
                            v224 = v217 < 2
                            v225 = v224
                        else:
                            v225 = False
                        del v223
                        v226 = v225 == False
                        if v226:
                            v227 = "The read index needs to be in range for the static array."
                            assert v225, v227
                            del v227
                        else:
                            pass
                        del v225, v226
                        v228 = v207[v217]
                        v229 = v228.tag
                        v230 = v222[0:].view(cp.int32)
                        del v222
                        v230[0] = v229
                        del v229, v230
                        match v228:
                            case US3_0(): # Jack
                                pass
                            case US3_1(): # King
                                pass
                            case US3_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v228
                        v217 += 1 
                    del v207, v217
                    v231 = v1[1084:].view(cp.int32)
                    v231[0] = v208
                    del v208, v231
                    v232 = 0
                    while method1(v232):
                        v234 = u64(v232)
                        v235 = v234 * 4
                        del v234
                        v236 = 1088 + v235
                        del v235
                        v237 = v1[v236:].view(cp.uint8)
                        del v236
                        v238 = 0 <= v232
                        if v238:
                            v239 = v232 < 2
                            v240 = v239
                        else:
                            v240 = False
                        del v238
                        v241 = v240 == False
                        if v241:
                            v242 = "The read index needs to be in range for the static array."
                            assert v240, v242
                            del v242
                        else:
                            pass
                        del v240, v241
                        v243 = v209[v232]
                        v244 = v237[0:].view(cp.int32)
                        del v237
                        v244[0] = v243
                        del v243, v244
                        v232 += 1 
                    del v209, v232
                    v245 = v1[1096:].view(cp.int32)
                    v245[0] = v210
                    del v210, v245
                case US5_3(v246, v247, v248, v249, v250, v251, v252): # RoundWithAction
                    del v161
                    v253 = v246.tag
                    v254 = v1[1064:].view(cp.int32)
                    v254[0] = v253
                    del v253, v254
                    match v246:
                        case US6_0(): # None
                            pass
                        case US6_1(v255): # Some
                            v256 = v255.tag
                            v257 = v1[1068:].view(cp.int32)
                            v257[0] = v256
                            del v256, v257
                            match v255:
                                case US3_0(): # Jack
                                    del v255
                                case US3_1(): # King
                                    del v255
                                case US3_2(): # Queen
                                    del v255
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v246
                    v258 = v1[1072:].view(cp.int8)
                    v258[0] = v247
                    del v247, v258
                    v259 = 0
                    while method1(v259):
                        v261 = u64(v259)
                        v262 = v261 * 4
                        del v261
                        v263 = 1076 + v262
                        del v262
                        v264 = v1[v263:].view(cp.uint8)
                        del v263
                        v265 = 0 <= v259
                        if v265:
                            v266 = v259 < 2
                            v267 = v266
                        else:
                            v267 = False
                        del v265
                        v268 = v267 == False
                        if v268:
                            v269 = "The read index needs to be in range for the static array."
                            assert v267, v269
                            del v269
                        else:
                            pass
                        del v267, v268
                        v270 = v248[v259]
                        v271 = v270.tag
                        v272 = v264[0:].view(cp.int32)
                        del v264
                        v272[0] = v271
                        del v271, v272
                        match v270:
                            case US3_0(): # Jack
                                pass
                            case US3_1(): # King
                                pass
                            case US3_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v270
                        v259 += 1 
                    del v248, v259
                    v273 = v1[1084:].view(cp.int32)
                    v273[0] = v249
                    del v249, v273
                    v274 = 0
                    while method1(v274):
                        v276 = u64(v274)
                        v277 = v276 * 4
                        del v276
                        v278 = 1088 + v277
                        del v277
                        v279 = v1[v278:].view(cp.uint8)
                        del v278
                        v280 = 0 <= v274
                        if v280:
                            v281 = v274 < 2
                            v282 = v281
                        else:
                            v282 = False
                        del v280
                        v283 = v282 == False
                        if v283:
                            v284 = "The read index needs to be in range for the static array."
                            assert v282, v284
                            del v284
                        else:
                            pass
                        del v282, v283
                        v285 = v250[v274]
                        v286 = v279[0:].view(cp.int32)
                        del v279
                        v286[0] = v285
                        del v285, v286
                        v274 += 1 
                    del v250, v274
                    v287 = v1[1096:].view(cp.int32)
                    v287[0] = v251
                    del v251, v287
                    v288 = v252.tag
                    v289 = v1[1100:].view(cp.int32)
                    v289[0] = v288
                    del v288, v289
                    match v252:
                        case US1_0(): # Call
                            del v252
                        case US1_1(): # Fold
                            del v252
                        case US1_2(): # Raise
                            del v252
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US5_4(v290, v291, v292, v293, v294, v295): # TerminalCall
                    del v161
                    v296 = v290.tag
                    v297 = v1[1064:].view(cp.int32)
                    v297[0] = v296
                    del v296, v297
                    match v290:
                        case US6_0(): # None
                            pass
                        case US6_1(v298): # Some
                            v299 = v298.tag
                            v300 = v1[1068:].view(cp.int32)
                            v300[0] = v299
                            del v299, v300
                            match v298:
                                case US3_0(): # Jack
                                    del v298
                                case US3_1(): # King
                                    del v298
                                case US3_2(): # Queen
                                    del v298
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v290
                    v301 = v1[1072:].view(cp.int8)
                    v301[0] = v291
                    del v291, v301
                    v302 = 0
                    while method1(v302):
                        v304 = u64(v302)
                        v305 = v304 * 4
                        del v304
                        v306 = 1076 + v305
                        del v305
                        v307 = v1[v306:].view(cp.uint8)
                        del v306
                        v308 = 0 <= v302
                        if v308:
                            v309 = v302 < 2
                            v310 = v309
                        else:
                            v310 = False
                        del v308
                        v311 = v310 == False
                        if v311:
                            v312 = "The read index needs to be in range for the static array."
                            assert v310, v312
                            del v312
                        else:
                            pass
                        del v310, v311
                        v313 = v292[v302]
                        v314 = v313.tag
                        v315 = v307[0:].view(cp.int32)
                        del v307
                        v315[0] = v314
                        del v314, v315
                        match v313:
                            case US3_0(): # Jack
                                pass
                            case US3_1(): # King
                                pass
                            case US3_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v313
                        v302 += 1 
                    del v292, v302
                    v316 = v1[1084:].view(cp.int32)
                    v316[0] = v293
                    del v293, v316
                    v317 = 0
                    while method1(v317):
                        v319 = u64(v317)
                        v320 = v319 * 4
                        del v319
                        v321 = 1088 + v320
                        del v320
                        v322 = v1[v321:].view(cp.uint8)
                        del v321
                        v323 = 0 <= v317
                        if v323:
                            v324 = v317 < 2
                            v325 = v324
                        else:
                            v325 = False
                        del v323
                        v326 = v325 == False
                        if v326:
                            v327 = "The read index needs to be in range for the static array."
                            assert v325, v327
                            del v327
                        else:
                            pass
                        del v325, v326
                        v328 = v294[v317]
                        v329 = v322[0:].view(cp.int32)
                        del v322
                        v329[0] = v328
                        del v328, v329
                        v317 += 1 
                    del v294, v317
                    v330 = v1[1096:].view(cp.int32)
                    v330[0] = v295
                    del v295, v330
                case US5_5(v331, v332, v333, v334, v335, v336): # TerminalFold
                    del v161
                    v337 = v331.tag
                    v338 = v1[1064:].view(cp.int32)
                    v338[0] = v337
                    del v337, v338
                    match v331:
                        case US6_0(): # None
                            pass
                        case US6_1(v339): # Some
                            v340 = v339.tag
                            v341 = v1[1068:].view(cp.int32)
                            v341[0] = v340
                            del v340, v341
                            match v339:
                                case US3_0(): # Jack
                                    del v339
                                case US3_1(): # King
                                    del v339
                                case US3_2(): # Queen
                                    del v339
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v331
                    v342 = v1[1072:].view(cp.int8)
                    v342[0] = v332
                    del v332, v342
                    v343 = 0
                    while method1(v343):
                        v345 = u64(v343)
                        v346 = v345 * 4
                        del v345
                        v347 = 1076 + v346
                        del v346
                        v348 = v1[v347:].view(cp.uint8)
                        del v347
                        v349 = 0 <= v343
                        if v349:
                            v350 = v343 < 2
                            v351 = v350
                        else:
                            v351 = False
                        del v349
                        v352 = v351 == False
                        if v352:
                            v353 = "The read index needs to be in range for the static array."
                            assert v351, v353
                            del v353
                        else:
                            pass
                        del v351, v352
                        v354 = v333[v343]
                        v355 = v354.tag
                        v356 = v348[0:].view(cp.int32)
                        del v348
                        v356[0] = v355
                        del v355, v356
                        match v354:
                            case US3_0(): # Jack
                                pass
                            case US3_1(): # King
                                pass
                            case US3_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v354
                        v343 += 1 
                    del v333, v343
                    v357 = v1[1084:].view(cp.int32)
                    v357[0] = v334
                    del v334, v357
                    v358 = 0
                    while method1(v358):
                        v360 = u64(v358)
                        v361 = v360 * 4
                        del v360
                        v362 = 1088 + v361
                        del v361
                        v363 = v1[v362:].view(cp.uint8)
                        del v362
                        v364 = 0 <= v358
                        if v364:
                            v365 = v358 < 2
                            v366 = v365
                        else:
                            v366 = False
                        del v364
                        v367 = v366 == False
                        if v367:
                            v368 = "The read index needs to be in range for the static array."
                            assert v366, v368
                            del v368
                        else:
                            pass
                        del v366, v367
                        v369 = v335[v358]
                        v370 = v363[0:].view(cp.int32)
                        del v363
                        v370[0] = v369
                        del v369, v370
                        v358 += 1 
                    del v335, v358
                    v371 = v1[1096:].view(cp.int32)
                    v371[0] = v336
                    del v336, v371
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v69
    v372 = 0
    while method1(v372):
        v374 = u64(v372)
        v375 = v374 * 4
        del v374
        v376 = 1104 + v375
        del v375
        v377 = v1[v376:].view(cp.uint8)
        del v376
        v378 = 0 <= v372
        if v378:
            v379 = v372 < 2
            v380 = v379
        else:
            v380 = False
        del v378
        v381 = v380 == False
        if v381:
            v382 = "The read index needs to be in range for the static array."
            assert v380, v382
            del v382
        else:
            pass
        del v380, v381
        v383 = v4[v372]
        v384 = v383.tag
        v385 = v377[0:].view(cp.int32)
        del v377
        v385[0] = v384
        del v384, v385
        match v383:
            case US2_0(): # Computer
                pass
            case US2_1(): # Human
                pass
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v383
        v372 += 1 
    del v4, v372
    v386 = v70.tag
    v387 = v1[1112:].view(cp.int32)
    v387[0] = v386
    del v386, v387
    match v70:
        case US7_0(): # GameNotStarted
            pass
        case US7_1(v388, v389, v390, v391, v392, v393): # GameOver
            v394 = v388.tag
            v395 = v1[1116:].view(cp.int32)
            v395[0] = v394
            del v394, v395
            match v388:
                case US6_0(): # None
                    pass
                case US6_1(v396): # Some
                    v397 = v396.tag
                    v398 = v1[1120:].view(cp.int32)
                    v398[0] = v397
                    del v397, v398
                    match v396:
                        case US3_0(): # Jack
                            del v396
                        case US3_1(): # King
                            del v396
                        case US3_2(): # Queen
                            del v396
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v388
            v399 = v1[1124:].view(cp.int8)
            v399[0] = v389
            del v389, v399
            v400 = 0
            while method1(v400):
                v402 = u64(v400)
                v403 = v402 * 4
                del v402
                v404 = 1128 + v403
                del v403
                v405 = v1[v404:].view(cp.uint8)
                del v404
                v406 = 0 <= v400
                if v406:
                    v407 = v400 < 2
                    v408 = v407
                else:
                    v408 = False
                del v406
                v409 = v408 == False
                if v409:
                    v410 = "The read index needs to be in range for the static array."
                    assert v408, v410
                    del v410
                else:
                    pass
                del v408, v409
                v411 = v390[v400]
                v412 = v411.tag
                v413 = v405[0:].view(cp.int32)
                del v405
                v413[0] = v412
                del v412, v413
                match v411:
                    case US3_0(): # Jack
                        pass
                    case US3_1(): # King
                        pass
                    case US3_2(): # Queen
                        pass
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v411
                v400 += 1 
            del v390, v400
            v414 = v1[1136:].view(cp.int32)
            v414[0] = v391
            del v391, v414
            v415 = 0
            while method1(v415):
                v417 = u64(v415)
                v418 = v417 * 4
                del v417
                v419 = 1140 + v418
                del v418
                v420 = v1[v419:].view(cp.uint8)
                del v419
                v421 = 0 <= v415
                if v421:
                    v422 = v415 < 2
                    v423 = v422
                else:
                    v423 = False
                del v421
                v424 = v423 == False
                if v424:
                    v425 = "The read index needs to be in range for the static array."
                    assert v423, v425
                    del v425
                else:
                    pass
                del v423, v424
                v426 = v392[v415]
                v427 = v420[0:].view(cp.int32)
                del v420
                v427[0] = v426
                del v426, v427
                v415 += 1 
            del v392, v415
            v428 = v1[1148:].view(cp.int32)
            v428[0] = v393
            del v393, v428
        case US7_2(v429, v430, v431, v432, v433, v434): # WaitingForActionFromPlayerId
            v435 = v429.tag
            v436 = v1[1116:].view(cp.int32)
            v436[0] = v435
            del v435, v436
            match v429:
                case US6_0(): # None
                    pass
                case US6_1(v437): # Some
                    v438 = v437.tag
                    v439 = v1[1120:].view(cp.int32)
                    v439[0] = v438
                    del v438, v439
                    match v437:
                        case US3_0(): # Jack
                            del v437
                        case US3_1(): # King
                            del v437
                        case US3_2(): # Queen
                            del v437
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v429
            v440 = v1[1124:].view(cp.int8)
            v440[0] = v430
            del v430, v440
            v441 = 0
            while method1(v441):
                v443 = u64(v441)
                v444 = v443 * 4
                del v443
                v445 = 1128 + v444
                del v444
                v446 = v1[v445:].view(cp.uint8)
                del v445
                v447 = 0 <= v441
                if v447:
                    v448 = v441 < 2
                    v449 = v448
                else:
                    v449 = False
                del v447
                v450 = v449 == False
                if v450:
                    v451 = "The read index needs to be in range for the static array."
                    assert v449, v451
                    del v451
                else:
                    pass
                del v449, v450
                v452 = v431[v441]
                v453 = v452.tag
                v454 = v446[0:].view(cp.int32)
                del v446
                v454[0] = v453
                del v453, v454
                match v452:
                    case US3_0(): # Jack
                        pass
                    case US3_1(): # King
                        pass
                    case US3_2(): # Queen
                        pass
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v452
                v441 += 1 
            del v431, v441
            v455 = v1[1136:].view(cp.int32)
            v455[0] = v432
            del v432, v455
            v456 = 0
            while method1(v456):
                v458 = u64(v456)
                v459 = v458 * 4
                del v458
                v460 = 1140 + v459
                del v459
                v461 = v1[v460:].view(cp.uint8)
                del v460
                v462 = 0 <= v456
                if v462:
                    v463 = v456 < 2
                    v464 = v463
                else:
                    v464 = False
                del v462
                v465 = v464 == False
                if v465:
                    v466 = "The read index needs to be in range for the static array."
                    assert v464, v466
                    del v466
                else:
                    pass
                del v464, v465
                v467 = v433[v456]
                v468 = v461[0:].view(cp.int32)
                del v461
                v468[0] = v467
                del v467, v468
                v456 += 1 
            del v433, v456
            v469 = v1[1148:].view(cp.int32)
            v469[0] = v434
            del v434, v469
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v70
    v470 = 0
    v471 = raw_module.get_function(f"entry{v470}")
    del v470
    v471.max_dynamic_shared_size_bytes = 0 
    v471((1,),(1,),(v1, v0, v2),shared_mem=0)
    del v0, v471
    cp.cuda.Stream.null.synchronize()
    v472 = static_array_list(6)
    v473 = v1[0:].view(cp.int32)
    v474 = v473[0].item()
    del v473
    v472.length = v474
    del v474
    v475 = v472.length
    v476 = 0
    while method0(v475, v476):
        v478 = u64(v476)
        v479 = v478 * 4
        del v478
        v480 = 4 + v479
        del v479
        v481 = v1[v480:].view(cp.uint8)
        del v480
        v482 = v481[0:].view(cp.int32)
        del v481
        v483 = v482[0].item()
        del v482
        if v483 == 0:
            v488 = US3_0()
        elif v483 == 1:
            v488 = US3_1()
        elif v483 == 2:
            v488 = US3_2()
        else:
            raise Exception("Invalid tag.")
        del v483
        v489 = 0 <= v476
        if v489:
            v490 = v472.length
            v491 = v476 < v490
            del v490
            v492 = v491
        else:
            v492 = False
        del v489
        v493 = v492 == False
        if v493:
            v494 = "The set index needs to be in range for the static array list."
            assert v492, v494
            del v494
        else:
            pass
        del v492, v493
        v472[v476] = v488
        del v488
        v476 += 1 
    del v475, v476
    v495 = static_array_list(32)
    v496 = v1[28:].view(cp.int32)
    v497 = v496[0].item()
    del v496
    v495.length = v497
    del v497
    v498 = v495.length
    v499 = 0
    while method0(v498, v499):
        v501 = u64(v499)
        v502 = v501 * 32
        del v501
        v503 = 32 + v502
        del v502
        v504 = v1[v503:].view(cp.uint8)
        del v503
        v505 = v504[0:].view(cp.int32)
        v506 = v505[0].item()
        del v505
        if v506 == 0:
            v508 = v504[4:].view(cp.int32)
            v509 = v508[0].item()
            del v508
            if v509 == 0:
                v514 = US3_0()
            elif v509 == 1:
                v514 = US3_1()
            elif v509 == 2:
                v514 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v509
            v560 = US8_0(v514)
        elif v506 == 1:
            v516 = v504[4:].view(cp.int32)
            v517 = v516[0].item()
            del v516
            v518 = v504[8:].view(cp.int32)
            v519 = v518[0].item()
            del v518
            if v519 == 0:
                v524 = US1_0()
            elif v519 == 1:
                v524 = US1_1()
            elif v519 == 2:
                v524 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v519
            v560 = US8_1(v517, v524)
        elif v506 == 2:
            v526 = v504[4:].view(cp.int32)
            v527 = v526[0].item()
            del v526
            v528 = v504[8:].view(cp.int32)
            v529 = v528[0].item()
            del v528
            if v529 == 0:
                v534 = US3_0()
            elif v529 == 1:
                v534 = US3_1()
            elif v529 == 2:
                v534 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v529
            v560 = US8_2(v527, v534)
        elif v506 == 3:
            v536 = static_array(2)
            v537 = 0
            while method1(v537):
                v539 = u64(v537)
                v540 = v539 * 4
                del v539
                v541 = 4 + v540
                del v540
                v542 = v504[v541:].view(cp.uint8)
                del v541
                v543 = v542[0:].view(cp.int32)
                del v542
                v544 = v543[0].item()
                del v543
                if v544 == 0:
                    v549 = US3_0()
                elif v544 == 1:
                    v549 = US3_1()
                elif v544 == 2:
                    v549 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v544
                v550 = 0 <= v537
                if v550:
                    v551 = v537 < 2
                    v552 = v551
                else:
                    v552 = False
                del v550
                v553 = v552 == False
                if v553:
                    v554 = "The read index needs to be in range for the static array."
                    assert v552, v554
                    del v554
                else:
                    pass
                del v552, v553
                v536[v537] = v549
                del v549
                v537 += 1 
            del v537
            v555 = v504[12:].view(cp.int32)
            v556 = v555[0].item()
            del v555
            v557 = v504[16:].view(cp.int32)
            v558 = v557[0].item()
            del v557
            v560 = US8_3(v536, v556, v558)
        else:
            raise Exception("Invalid tag.")
        del v504, v506
        v561 = 0 <= v499
        if v561:
            v562 = v495.length
            v563 = v499 < v562
            del v562
            v564 = v563
        else:
            v564 = False
        del v561
        v565 = v564 == False
        if v565:
            v566 = "The set index needs to be in range for the static array list."
            assert v564, v566
            del v566
        else:
            pass
        del v564, v565
        v495[v499] = v560
        del v560
        v499 += 1 
    del v498, v499
    v567 = v1[1056:].view(cp.int32)
    v568 = v567[0].item()
    del v567
    if v568 == 0:
        v849 = US4_0()
    elif v568 == 1:
        v571 = v1[1060:].view(cp.int32)
        v572 = v571[0].item()
        del v571
        if v572 == 0:
            v574 = v1[1064:].view(cp.int32)
            v575 = v574[0].item()
            del v574
            if v575 == 0:
                v586 = US6_0()
            elif v575 == 1:
                v578 = v1[1068:].view(cp.int32)
                v579 = v578[0].item()
                del v578
                if v579 == 0:
                    v584 = US3_0()
                elif v579 == 1:
                    v584 = US3_1()
                elif v579 == 2:
                    v584 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v579
                v586 = US6_1(v584)
            else:
                raise Exception("Invalid tag.")
            del v575
            v587 = v1[1072:].view(cp.int8)
            v588 = v587[0].item()
            del v587
            v589 = static_array(2)
            v590 = 0
            while method1(v590):
                v592 = u64(v590)
                v593 = v592 * 4
                del v592
                v594 = 1076 + v593
                del v593
                v595 = v1[v594:].view(cp.uint8)
                del v594
                v596 = v595[0:].view(cp.int32)
                del v595
                v597 = v596[0].item()
                del v596
                if v597 == 0:
                    v602 = US3_0()
                elif v597 == 1:
                    v602 = US3_1()
                elif v597 == 2:
                    v602 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v597
                v603 = 0 <= v590
                if v603:
                    v604 = v590 < 2
                    v605 = v604
                else:
                    v605 = False
                del v603
                v606 = v605 == False
                if v606:
                    v607 = "The read index needs to be in range for the static array."
                    assert v605, v607
                    del v607
                else:
                    pass
                del v605, v606
                v589[v590] = v602
                del v602
                v590 += 1 
            del v590
            v608 = v1[1084:].view(cp.int32)
            v609 = v608[0].item()
            del v608
            v610 = static_array(2)
            v611 = 0
            while method1(v611):
                v613 = u64(v611)
                v614 = v613 * 4
                del v613
                v615 = 1088 + v614
                del v614
                v616 = v1[v615:].view(cp.uint8)
                del v615
                v617 = v616[0:].view(cp.int32)
                del v616
                v618 = v617[0].item()
                del v617
                v619 = 0 <= v611
                if v619:
                    v620 = v611 < 2
                    v621 = v620
                else:
                    v621 = False
                del v619
                v622 = v621 == False
                if v622:
                    v623 = "The read index needs to be in range for the static array."
                    assert v621, v623
                    del v623
                else:
                    pass
                del v621, v622
                v610[v611] = v618
                del v618
                v611 += 1 
            del v611
            v624 = v1[1096:].view(cp.int32)
            v625 = v624[0].item()
            del v624
            v847 = US5_0(v586, v588, v589, v609, v610, v625)
        elif v572 == 1:
            v847 = US5_1()
        elif v572 == 2:
            v628 = v1[1064:].view(cp.int32)
            v629 = v628[0].item()
            del v628
            if v629 == 0:
                v640 = US6_0()
            elif v629 == 1:
                v632 = v1[1068:].view(cp.int32)
                v633 = v632[0].item()
                del v632
                if v633 == 0:
                    v638 = US3_0()
                elif v633 == 1:
                    v638 = US3_1()
                elif v633 == 2:
                    v638 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v633
                v640 = US6_1(v638)
            else:
                raise Exception("Invalid tag.")
            del v629
            v641 = v1[1072:].view(cp.int8)
            v642 = v641[0].item()
            del v641
            v643 = static_array(2)
            v644 = 0
            while method1(v644):
                v646 = u64(v644)
                v647 = v646 * 4
                del v646
                v648 = 1076 + v647
                del v647
                v649 = v1[v648:].view(cp.uint8)
                del v648
                v650 = v649[0:].view(cp.int32)
                del v649
                v651 = v650[0].item()
                del v650
                if v651 == 0:
                    v656 = US3_0()
                elif v651 == 1:
                    v656 = US3_1()
                elif v651 == 2:
                    v656 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v651
                v657 = 0 <= v644
                if v657:
                    v658 = v644 < 2
                    v659 = v658
                else:
                    v659 = False
                del v657
                v660 = v659 == False
                if v660:
                    v661 = "The read index needs to be in range for the static array."
                    assert v659, v661
                    del v661
                else:
                    pass
                del v659, v660
                v643[v644] = v656
                del v656
                v644 += 1 
            del v644
            v662 = v1[1084:].view(cp.int32)
            v663 = v662[0].item()
            del v662
            v664 = static_array(2)
            v665 = 0
            while method1(v665):
                v667 = u64(v665)
                v668 = v667 * 4
                del v667
                v669 = 1088 + v668
                del v668
                v670 = v1[v669:].view(cp.uint8)
                del v669
                v671 = v670[0:].view(cp.int32)
                del v670
                v672 = v671[0].item()
                del v671
                v673 = 0 <= v665
                if v673:
                    v674 = v665 < 2
                    v675 = v674
                else:
                    v675 = False
                del v673
                v676 = v675 == False
                if v676:
                    v677 = "The read index needs to be in range for the static array."
                    assert v675, v677
                    del v677
                else:
                    pass
                del v675, v676
                v664[v665] = v672
                del v672
                v665 += 1 
            del v665
            v678 = v1[1096:].view(cp.int32)
            v679 = v678[0].item()
            del v678
            v847 = US5_2(v640, v642, v643, v663, v664, v679)
        elif v572 == 3:
            v681 = v1[1064:].view(cp.int32)
            v682 = v681[0].item()
            del v681
            if v682 == 0:
                v693 = US6_0()
            elif v682 == 1:
                v685 = v1[1068:].view(cp.int32)
                v686 = v685[0].item()
                del v685
                if v686 == 0:
                    v691 = US3_0()
                elif v686 == 1:
                    v691 = US3_1()
                elif v686 == 2:
                    v691 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v686
                v693 = US6_1(v691)
            else:
                raise Exception("Invalid tag.")
            del v682
            v694 = v1[1072:].view(cp.int8)
            v695 = v694[0].item()
            del v694
            v696 = static_array(2)
            v697 = 0
            while method1(v697):
                v699 = u64(v697)
                v700 = v699 * 4
                del v699
                v701 = 1076 + v700
                del v700
                v702 = v1[v701:].view(cp.uint8)
                del v701
                v703 = v702[0:].view(cp.int32)
                del v702
                v704 = v703[0].item()
                del v703
                if v704 == 0:
                    v709 = US3_0()
                elif v704 == 1:
                    v709 = US3_1()
                elif v704 == 2:
                    v709 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v704
                v710 = 0 <= v697
                if v710:
                    v711 = v697 < 2
                    v712 = v711
                else:
                    v712 = False
                del v710
                v713 = v712 == False
                if v713:
                    v714 = "The read index needs to be in range for the static array."
                    assert v712, v714
                    del v714
                else:
                    pass
                del v712, v713
                v696[v697] = v709
                del v709
                v697 += 1 
            del v697
            v715 = v1[1084:].view(cp.int32)
            v716 = v715[0].item()
            del v715
            v717 = static_array(2)
            v718 = 0
            while method1(v718):
                v720 = u64(v718)
                v721 = v720 * 4
                del v720
                v722 = 1088 + v721
                del v721
                v723 = v1[v722:].view(cp.uint8)
                del v722
                v724 = v723[0:].view(cp.int32)
                del v723
                v725 = v724[0].item()
                del v724
                v726 = 0 <= v718
                if v726:
                    v727 = v718 < 2
                    v728 = v727
                else:
                    v728 = False
                del v726
                v729 = v728 == False
                if v729:
                    v730 = "The read index needs to be in range for the static array."
                    assert v728, v730
                    del v730
                else:
                    pass
                del v728, v729
                v717[v718] = v725
                del v725
                v718 += 1 
            del v718
            v731 = v1[1096:].view(cp.int32)
            v732 = v731[0].item()
            del v731
            v733 = v1[1100:].view(cp.int32)
            v734 = v733[0].item()
            del v733
            if v734 == 0:
                v739 = US1_0()
            elif v734 == 1:
                v739 = US1_1()
            elif v734 == 2:
                v739 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v734
            v847 = US5_3(v693, v695, v696, v716, v717, v732, v739)
        elif v572 == 4:
            v741 = v1[1064:].view(cp.int32)
            v742 = v741[0].item()
            del v741
            if v742 == 0:
                v753 = US6_0()
            elif v742 == 1:
                v745 = v1[1068:].view(cp.int32)
                v746 = v745[0].item()
                del v745
                if v746 == 0:
                    v751 = US3_0()
                elif v746 == 1:
                    v751 = US3_1()
                elif v746 == 2:
                    v751 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v746
                v753 = US6_1(v751)
            else:
                raise Exception("Invalid tag.")
            del v742
            v754 = v1[1072:].view(cp.int8)
            v755 = v754[0].item()
            del v754
            v756 = static_array(2)
            v757 = 0
            while method1(v757):
                v759 = u64(v757)
                v760 = v759 * 4
                del v759
                v761 = 1076 + v760
                del v760
                v762 = v1[v761:].view(cp.uint8)
                del v761
                v763 = v762[0:].view(cp.int32)
                del v762
                v764 = v763[0].item()
                del v763
                if v764 == 0:
                    v769 = US3_0()
                elif v764 == 1:
                    v769 = US3_1()
                elif v764 == 2:
                    v769 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v764
                v770 = 0 <= v757
                if v770:
                    v771 = v757 < 2
                    v772 = v771
                else:
                    v772 = False
                del v770
                v773 = v772 == False
                if v773:
                    v774 = "The read index needs to be in range for the static array."
                    assert v772, v774
                    del v774
                else:
                    pass
                del v772, v773
                v756[v757] = v769
                del v769
                v757 += 1 
            del v757
            v775 = v1[1084:].view(cp.int32)
            v776 = v775[0].item()
            del v775
            v777 = static_array(2)
            v778 = 0
            while method1(v778):
                v780 = u64(v778)
                v781 = v780 * 4
                del v780
                v782 = 1088 + v781
                del v781
                v783 = v1[v782:].view(cp.uint8)
                del v782
                v784 = v783[0:].view(cp.int32)
                del v783
                v785 = v784[0].item()
                del v784
                v786 = 0 <= v778
                if v786:
                    v787 = v778 < 2
                    v788 = v787
                else:
                    v788 = False
                del v786
                v789 = v788 == False
                if v789:
                    v790 = "The read index needs to be in range for the static array."
                    assert v788, v790
                    del v790
                else:
                    pass
                del v788, v789
                v777[v778] = v785
                del v785
                v778 += 1 
            del v778
            v791 = v1[1096:].view(cp.int32)
            v792 = v791[0].item()
            del v791
            v847 = US5_4(v753, v755, v756, v776, v777, v792)
        elif v572 == 5:
            v794 = v1[1064:].view(cp.int32)
            v795 = v794[0].item()
            del v794
            if v795 == 0:
                v806 = US6_0()
            elif v795 == 1:
                v798 = v1[1068:].view(cp.int32)
                v799 = v798[0].item()
                del v798
                if v799 == 0:
                    v804 = US3_0()
                elif v799 == 1:
                    v804 = US3_1()
                elif v799 == 2:
                    v804 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v799
                v806 = US6_1(v804)
            else:
                raise Exception("Invalid tag.")
            del v795
            v807 = v1[1072:].view(cp.int8)
            v808 = v807[0].item()
            del v807
            v809 = static_array(2)
            v810 = 0
            while method1(v810):
                v812 = u64(v810)
                v813 = v812 * 4
                del v812
                v814 = 1076 + v813
                del v813
                v815 = v1[v814:].view(cp.uint8)
                del v814
                v816 = v815[0:].view(cp.int32)
                del v815
                v817 = v816[0].item()
                del v816
                if v817 == 0:
                    v822 = US3_0()
                elif v817 == 1:
                    v822 = US3_1()
                elif v817 == 2:
                    v822 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v817
                v823 = 0 <= v810
                if v823:
                    v824 = v810 < 2
                    v825 = v824
                else:
                    v825 = False
                del v823
                v826 = v825 == False
                if v826:
                    v827 = "The read index needs to be in range for the static array."
                    assert v825, v827
                    del v827
                else:
                    pass
                del v825, v826
                v809[v810] = v822
                del v822
                v810 += 1 
            del v810
            v828 = v1[1084:].view(cp.int32)
            v829 = v828[0].item()
            del v828
            v830 = static_array(2)
            v831 = 0
            while method1(v831):
                v833 = u64(v831)
                v834 = v833 * 4
                del v833
                v835 = 1088 + v834
                del v834
                v836 = v1[v835:].view(cp.uint8)
                del v835
                v837 = v836[0:].view(cp.int32)
                del v836
                v838 = v837[0].item()
                del v837
                v839 = 0 <= v831
                if v839:
                    v840 = v831 < 2
                    v841 = v840
                else:
                    v841 = False
                del v839
                v842 = v841 == False
                if v842:
                    v843 = "The read index needs to be in range for the static array."
                    assert v841, v843
                    del v843
                else:
                    pass
                del v841, v842
                v830[v831] = v838
                del v838
                v831 += 1 
            del v831
            v844 = v1[1096:].view(cp.int32)
            v845 = v844[0].item()
            del v844
            v847 = US5_5(v806, v808, v809, v829, v830, v845)
        else:
            raise Exception("Invalid tag.")
        del v572
        v849 = US4_1(v847)
    else:
        raise Exception("Invalid tag.")
    del v568
    v850 = static_array(2)
    v851 = 0
    while method1(v851):
        v853 = u64(v851)
        v854 = v853 * 4
        del v853
        v855 = 1104 + v854
        del v854
        v856 = v1[v855:].view(cp.uint8)
        del v855
        v857 = v856[0:].view(cp.int32)
        del v856
        v858 = v857[0].item()
        del v857
        if v858 == 0:
            v862 = US2_0()
        elif v858 == 1:
            v862 = US2_1()
        else:
            raise Exception("Invalid tag.")
        del v858
        v863 = 0 <= v851
        if v863:
            v864 = v851 < 2
            v865 = v864
        else:
            v865 = False
        del v863
        v866 = v865 == False
        if v866:
            v867 = "The read index needs to be in range for the static array."
            assert v865, v867
            del v867
        else:
            pass
        del v865, v866
        v850[v851] = v862
        del v862
        v851 += 1 
    del v851
    v868 = v1[1112:].view(cp.int32)
    v869 = v868[0].item()
    del v868
    if v869 == 0:
        v978 = US7_0()
    elif v869 == 1:
        v872 = v1[1116:].view(cp.int32)
        v873 = v872[0].item()
        del v872
        if v873 == 0:
            v884 = US6_0()
        elif v873 == 1:
            v876 = v1[1120:].view(cp.int32)
            v877 = v876[0].item()
            del v876
            if v877 == 0:
                v882 = US3_0()
            elif v877 == 1:
                v882 = US3_1()
            elif v877 == 2:
                v882 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v877
            v884 = US6_1(v882)
        else:
            raise Exception("Invalid tag.")
        del v873
        v885 = v1[1124:].view(cp.int8)
        v886 = v885[0].item()
        del v885
        v887 = static_array(2)
        v888 = 0
        while method1(v888):
            v890 = u64(v888)
            v891 = v890 * 4
            del v890
            v892 = 1128 + v891
            del v891
            v893 = v1[v892:].view(cp.uint8)
            del v892
            v894 = v893[0:].view(cp.int32)
            del v893
            v895 = v894[0].item()
            del v894
            if v895 == 0:
                v900 = US3_0()
            elif v895 == 1:
                v900 = US3_1()
            elif v895 == 2:
                v900 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v895
            v901 = 0 <= v888
            if v901:
                v902 = v888 < 2
                v903 = v902
            else:
                v903 = False
            del v901
            v904 = v903 == False
            if v904:
                v905 = "The read index needs to be in range for the static array."
                assert v903, v905
                del v905
            else:
                pass
            del v903, v904
            v887[v888] = v900
            del v900
            v888 += 1 
        del v888
        v906 = v1[1136:].view(cp.int32)
        v907 = v906[0].item()
        del v906
        v908 = static_array(2)
        v909 = 0
        while method1(v909):
            v911 = u64(v909)
            v912 = v911 * 4
            del v911
            v913 = 1140 + v912
            del v912
            v914 = v1[v913:].view(cp.uint8)
            del v913
            v915 = v914[0:].view(cp.int32)
            del v914
            v916 = v915[0].item()
            del v915
            v917 = 0 <= v909
            if v917:
                v918 = v909 < 2
                v919 = v918
            else:
                v919 = False
            del v917
            v920 = v919 == False
            if v920:
                v921 = "The read index needs to be in range for the static array."
                assert v919, v921
                del v921
            else:
                pass
            del v919, v920
            v908[v909] = v916
            del v916
            v909 += 1 
        del v909
        v922 = v1[1148:].view(cp.int32)
        v923 = v922[0].item()
        del v922
        v978 = US7_1(v884, v886, v887, v907, v908, v923)
    elif v869 == 2:
        v925 = v1[1116:].view(cp.int32)
        v926 = v925[0].item()
        del v925
        if v926 == 0:
            v937 = US6_0()
        elif v926 == 1:
            v929 = v1[1120:].view(cp.int32)
            v930 = v929[0].item()
            del v929
            if v930 == 0:
                v935 = US3_0()
            elif v930 == 1:
                v935 = US3_1()
            elif v930 == 2:
                v935 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v930
            v937 = US6_1(v935)
        else:
            raise Exception("Invalid tag.")
        del v926
        v938 = v1[1124:].view(cp.int8)
        v939 = v938[0].item()
        del v938
        v940 = static_array(2)
        v941 = 0
        while method1(v941):
            v943 = u64(v941)
            v944 = v943 * 4
            del v943
            v945 = 1128 + v944
            del v944
            v946 = v1[v945:].view(cp.uint8)
            del v945
            v947 = v946[0:].view(cp.int32)
            del v946
            v948 = v947[0].item()
            del v947
            if v948 == 0:
                v953 = US3_0()
            elif v948 == 1:
                v953 = US3_1()
            elif v948 == 2:
                v953 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v948
            v954 = 0 <= v941
            if v954:
                v955 = v941 < 2
                v956 = v955
            else:
                v956 = False
            del v954
            v957 = v956 == False
            if v957:
                v958 = "The read index needs to be in range for the static array."
                assert v956, v958
                del v958
            else:
                pass
            del v956, v957
            v940[v941] = v953
            del v953
            v941 += 1 
        del v941
        v959 = v1[1136:].view(cp.int32)
        v960 = v959[0].item()
        del v959
        v961 = static_array(2)
        v962 = 0
        while method1(v962):
            v964 = u64(v962)
            v965 = v964 * 4
            del v964
            v966 = 1140 + v965
            del v965
            v967 = v1[v966:].view(cp.uint8)
            del v966
            v968 = v967[0:].view(cp.int32)
            del v967
            v969 = v968[0].item()
            del v968
            v970 = 0 <= v962
            if v970:
                v971 = v962 < 2
                v972 = v971
            else:
                v972 = False
            del v970
            v973 = v972 == False
            if v973:
                v974 = "The read index needs to be in range for the static array."
                assert v972, v974
                del v974
            else:
                pass
            del v972, v973
            v961[v962] = v969
            del v969
            v962 += 1 
        del v962
        v975 = v1[1148:].view(cp.int32)
        v976 = v975[0].item()
        del v975
        v978 = US7_2(v937, v939, v940, v960, v961, v976)
    else:
        raise Exception("Invalid tag.")
    del v1, v869
    v979 = method2(v472, v495, v849, v850, v978)
    del v472, v495, v849, v850, v978
    v980 = static_array_list(32)
    v981 = v2[0:].view(cp.int32)
    v982 = v981[0].item()
    del v981
    v980.length = v982
    del v982
    v983 = v980.length
    v984 = 0
    while method0(v983, v984):
        v986 = u64(v984)
        v987 = v986 * 32
        del v986
        v988 = 16 + v987
        del v987
        v989 = v2[v988:].view(cp.uint8)
        del v988
        v990 = v989[0:].view(cp.int32)
        v991 = v990[0].item()
        del v990
        if v991 == 0:
            v993 = v989[4:].view(cp.int32)
            v994 = v993[0].item()
            del v993
            if v994 == 0:
                v999 = US3_0()
            elif v994 == 1:
                v999 = US3_1()
            elif v994 == 2:
                v999 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v994
            v1045 = US8_0(v999)
        elif v991 == 1:
            v1001 = v989[4:].view(cp.int32)
            v1002 = v1001[0].item()
            del v1001
            v1003 = v989[8:].view(cp.int32)
            v1004 = v1003[0].item()
            del v1003
            if v1004 == 0:
                v1009 = US1_0()
            elif v1004 == 1:
                v1009 = US1_1()
            elif v1004 == 2:
                v1009 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v1004
            v1045 = US8_1(v1002, v1009)
        elif v991 == 2:
            v1011 = v989[4:].view(cp.int32)
            v1012 = v1011[0].item()
            del v1011
            v1013 = v989[8:].view(cp.int32)
            v1014 = v1013[0].item()
            del v1013
            if v1014 == 0:
                v1019 = US3_0()
            elif v1014 == 1:
                v1019 = US3_1()
            elif v1014 == 2:
                v1019 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v1014
            v1045 = US8_2(v1012, v1019)
        elif v991 == 3:
            v1021 = static_array(2)
            v1022 = 0
            while method1(v1022):
                v1024 = u64(v1022)
                v1025 = v1024 * 4
                del v1024
                v1026 = 4 + v1025
                del v1025
                v1027 = v989[v1026:].view(cp.uint8)
                del v1026
                v1028 = v1027[0:].view(cp.int32)
                del v1027
                v1029 = v1028[0].item()
                del v1028
                if v1029 == 0:
                    v1034 = US3_0()
                elif v1029 == 1:
                    v1034 = US3_1()
                elif v1029 == 2:
                    v1034 = US3_2()
                else:
                    raise Exception("Invalid tag.")
                del v1029
                v1035 = 0 <= v1022
                if v1035:
                    v1036 = v1022 < 2
                    v1037 = v1036
                else:
                    v1037 = False
                del v1035
                v1038 = v1037 == False
                if v1038:
                    v1039 = "The read index needs to be in range for the static array."
                    assert v1037, v1039
                    del v1039
                else:
                    pass
                del v1037, v1038
                v1021[v1022] = v1034
                del v1034
                v1022 += 1 
            del v1022
            v1040 = v989[12:].view(cp.int32)
            v1041 = v1040[0].item()
            del v1040
            v1042 = v989[16:].view(cp.int32)
            v1043 = v1042[0].item()
            del v1042
            v1045 = US8_3(v1021, v1041, v1043)
        else:
            raise Exception("Invalid tag.")
        del v989, v991
        v1046 = 0 <= v984
        if v1046:
            v1047 = v980.length
            v1048 = v984 < v1047
            del v1047
            v1049 = v1048
        else:
            v1049 = False
        del v1046
        v1050 = v1049 == False
        if v1050:
            v1051 = "The set index needs to be in range for the static array list."
            assert v1049, v1051
            del v1051
        else:
            pass
        del v1049, v1050
        v980[v984] = v1045
        del v1045
        v984 += 1 
    del v983, v984
    v1052 = static_array(2)
    v1053 = 0
    while method1(v1053):
        v1055 = u64(v1053)
        v1056 = v1055 * 4
        del v1055
        v1057 = 1040 + v1056
        del v1056
        v1058 = v2[v1057:].view(cp.uint8)
        del v1057
        v1059 = v1058[0:].view(cp.int32)
        del v1058
        v1060 = v1059[0].item()
        del v1059
        if v1060 == 0:
            v1064 = US2_0()
        elif v1060 == 1:
            v1064 = US2_1()
        else:
            raise Exception("Invalid tag.")
        del v1060
        v1065 = 0 <= v1053
        if v1065:
            v1066 = v1053 < 2
            v1067 = v1066
        else:
            v1067 = False
        del v1065
        v1068 = v1067 == False
        if v1068:
            v1069 = "The read index needs to be in range for the static array."
            assert v1067, v1069
            del v1069
        else:
            pass
        del v1067, v1068
        v1052[v1053] = v1064
        del v1064
        v1053 += 1 
    del v1053
    v1070 = v2[1048:].view(cp.int32)
    v1071 = v1070[0].item()
    del v1070
    if v1071 == 0:
        v1180 = US7_0()
    elif v1071 == 1:
        v1074 = v2[1052:].view(cp.int32)
        v1075 = v1074[0].item()
        del v1074
        if v1075 == 0:
            v1086 = US6_0()
        elif v1075 == 1:
            v1078 = v2[1056:].view(cp.int32)
            v1079 = v1078[0].item()
            del v1078
            if v1079 == 0:
                v1084 = US3_0()
            elif v1079 == 1:
                v1084 = US3_1()
            elif v1079 == 2:
                v1084 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v1079
            v1086 = US6_1(v1084)
        else:
            raise Exception("Invalid tag.")
        del v1075
        v1087 = v2[1060:].view(cp.int8)
        v1088 = v1087[0].item()
        del v1087
        v1089 = static_array(2)
        v1090 = 0
        while method1(v1090):
            v1092 = u64(v1090)
            v1093 = v1092 * 4
            del v1092
            v1094 = 1064 + v1093
            del v1093
            v1095 = v2[v1094:].view(cp.uint8)
            del v1094
            v1096 = v1095[0:].view(cp.int32)
            del v1095
            v1097 = v1096[0].item()
            del v1096
            if v1097 == 0:
                v1102 = US3_0()
            elif v1097 == 1:
                v1102 = US3_1()
            elif v1097 == 2:
                v1102 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v1097
            v1103 = 0 <= v1090
            if v1103:
                v1104 = v1090 < 2
                v1105 = v1104
            else:
                v1105 = False
            del v1103
            v1106 = v1105 == False
            if v1106:
                v1107 = "The read index needs to be in range for the static array."
                assert v1105, v1107
                del v1107
            else:
                pass
            del v1105, v1106
            v1089[v1090] = v1102
            del v1102
            v1090 += 1 
        del v1090
        v1108 = v2[1072:].view(cp.int32)
        v1109 = v1108[0].item()
        del v1108
        v1110 = static_array(2)
        v1111 = 0
        while method1(v1111):
            v1113 = u64(v1111)
            v1114 = v1113 * 4
            del v1113
            v1115 = 1076 + v1114
            del v1114
            v1116 = v2[v1115:].view(cp.uint8)
            del v1115
            v1117 = v1116[0:].view(cp.int32)
            del v1116
            v1118 = v1117[0].item()
            del v1117
            v1119 = 0 <= v1111
            if v1119:
                v1120 = v1111 < 2
                v1121 = v1120
            else:
                v1121 = False
            del v1119
            v1122 = v1121 == False
            if v1122:
                v1123 = "The read index needs to be in range for the static array."
                assert v1121, v1123
                del v1123
            else:
                pass
            del v1121, v1122
            v1110[v1111] = v1118
            del v1118
            v1111 += 1 
        del v1111
        v1124 = v2[1084:].view(cp.int32)
        v1125 = v1124[0].item()
        del v1124
        v1180 = US7_1(v1086, v1088, v1089, v1109, v1110, v1125)
    elif v1071 == 2:
        v1127 = v2[1052:].view(cp.int32)
        v1128 = v1127[0].item()
        del v1127
        if v1128 == 0:
            v1139 = US6_0()
        elif v1128 == 1:
            v1131 = v2[1056:].view(cp.int32)
            v1132 = v1131[0].item()
            del v1131
            if v1132 == 0:
                v1137 = US3_0()
            elif v1132 == 1:
                v1137 = US3_1()
            elif v1132 == 2:
                v1137 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v1132
            v1139 = US6_1(v1137)
        else:
            raise Exception("Invalid tag.")
        del v1128
        v1140 = v2[1060:].view(cp.int8)
        v1141 = v1140[0].item()
        del v1140
        v1142 = static_array(2)
        v1143 = 0
        while method1(v1143):
            v1145 = u64(v1143)
            v1146 = v1145 * 4
            del v1145
            v1147 = 1064 + v1146
            del v1146
            v1148 = v2[v1147:].view(cp.uint8)
            del v1147
            v1149 = v1148[0:].view(cp.int32)
            del v1148
            v1150 = v1149[0].item()
            del v1149
            if v1150 == 0:
                v1155 = US3_0()
            elif v1150 == 1:
                v1155 = US3_1()
            elif v1150 == 2:
                v1155 = US3_2()
            else:
                raise Exception("Invalid tag.")
            del v1150
            v1156 = 0 <= v1143
            if v1156:
                v1157 = v1143 < 2
                v1158 = v1157
            else:
                v1158 = False
            del v1156
            v1159 = v1158 == False
            if v1159:
                v1160 = "The read index needs to be in range for the static array."
                assert v1158, v1160
                del v1160
            else:
                pass
            del v1158, v1159
            v1142[v1143] = v1155
            del v1155
            v1143 += 1 
        del v1143
        v1161 = v2[1072:].view(cp.int32)
        v1162 = v1161[0].item()
        del v1161
        v1163 = static_array(2)
        v1164 = 0
        while method1(v1164):
            v1166 = u64(v1164)
            v1167 = v1166 * 4
            del v1166
            v1168 = 1076 + v1167
            del v1167
            v1169 = v2[v1168:].view(cp.uint8)
            del v1168
            v1170 = v1169[0:].view(cp.int32)
            del v1169
            v1171 = v1170[0].item()
            del v1170
            v1172 = 0 <= v1164
            if v1172:
                v1173 = v1164 < 2
                v1174 = v1173
            else:
                v1174 = False
            del v1172
            v1175 = v1174 == False
            if v1175:
                v1176 = "The read index needs to be in range for the static array."
                assert v1174, v1176
                del v1176
            else:
                pass
            del v1174, v1175
            v1163[v1164] = v1171
            del v1171
            v1164 += 1 
        del v1164
        v1177 = v2[1084:].view(cp.int32)
        v1178 = v1177[0].item()
        del v1177
        v1180 = US7_2(v1139, v1141, v1142, v1162, v1163, v1178)
    else:
        raise Exception("Invalid tag.")
    del v2, v1071
    v1181 = method11(v980, v1052, v1180)
    del v980, v1052, v1180
    return v979, v1181

if __name__ == '__main__': print(main())
