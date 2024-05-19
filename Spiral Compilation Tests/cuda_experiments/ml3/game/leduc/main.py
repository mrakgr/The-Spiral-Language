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
    v5 = v4 * 512l;
    long v6;
    v6 = v3 + v5;
    bool v7;
    v7 = v6 == 0l;
    if (v7){
        long * v8;
        v8 = (long *)(v1+0ull);
        long v9;
        v9 = v8[0l];
        US0 v38;
        switch (v9) {
            case 0: {
                long * v11;
                v11 = (long *)(v1+4ull);
                long v12;
                v12 = v11[0l];
                US1 v17;
                switch (v12) {
                    case 0: {
                        v17 = US1_0();
                        break;
                    }
                    case 1: {
                        v17 = US1_1();
                        break;
                    }
                    case 2: {
                        v17 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v38 = US0_0(v17);
                break;
            }
            case 1: {
                static_array<US2,2l> v19;
                long v20;
                v20 = 0l;
                while (while_method_0(v20)){
                    unsigned long long v22;
                    v22 = (unsigned long long)v20;
                    unsigned long long v23;
                    v23 = v22 * 4ull;
                    unsigned long long v24;
                    v24 = 4ull + v23;
                    unsigned char * v25;
                    v25 = (unsigned char *)(v1+v24);
                    long * v26;
                    v26 = (long *)(v25+0ull);
                    long v27;
                    v27 = v26[0l];
                    US2 v31;
                    switch (v27) {
                        case 0: {
                            v31 = US2_0();
                            break;
                        }
                        case 1: {
                            v31 = US2_1();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v32;
                    v32 = 0l <= v20;
                    bool v34;
                    if (v32){
                        bool v33;
                        v33 = v20 < 2l;
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
                    v19.v[v20] = v31;
                    v20 += 1l ;
                }
                v38 = US0_1(v19);
                break;
            }
            case 2: {
                v38 = US0_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US3,6l,long> v39;
        v39.length = 0;
        long * v40;
        v40 = (long *)(v0+0ull);
        long v41;
        v41 = v40[0l];
        v39.length = v41;
        long v42;
        v42 = v39.length;
        long v43;
        v43 = 0l;
        while (while_method_1(v42, v43)){
            unsigned long long v45;
            v45 = (unsigned long long)v43;
            unsigned long long v46;
            v46 = v45 * 4ull;
            unsigned long long v47;
            v47 = 4ull + v46;
            unsigned char * v48;
            v48 = (unsigned char *)(v0+v47);
            long * v49;
            v49 = (long *)(v48+0ull);
            long v50;
            v50 = v49[0l];
            US3 v55;
            switch (v50) {
                case 0: {
                    v55 = US3_0();
                    break;
                }
                case 1: {
                    v55 = US3_1();
                    break;
                }
                case 2: {
                    v55 = US3_2();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v56;
            v56 = 0l <= v43;
            bool v59;
            if (v56){
                long v57;
                v57 = v39.length;
                bool v58;
                v58 = v43 < v57;
                v59 = v58;
            } else {
                v59 = false;
            }
            bool v60;
            v60 = v59 == false;
            if (v60){
                assert("The set index needs to be in range for the static array list." && v59);
            } else {
            }
            v39.v[v43] = v55;
            v43 += 1l ;
        }
        static_array_list<US4,32l,long> v61;
        v61.length = 0;
        long * v62;
        v62 = (long *)(v0+28ull);
        long v63;
        v63 = v62[0l];
        v61.length = v63;
        long v64;
        v64 = v61.length;
        long v65;
        v65 = 0l;
        while (while_method_1(v64, v65)){
            unsigned long long v67;
            v67 = (unsigned long long)v65;
            unsigned long long v68;
            v68 = v67 * 32ull;
            unsigned long long v69;
            v69 = 32ull + v68;
            unsigned char * v70;
            v70 = (unsigned char *)(v0+v69);
            long * v71;
            v71 = (long *)(v70+0ull);
            long v72;
            v72 = v71[0l];
            US4 v125;
            switch (v72) {
                case 0: {
                    long * v74;
                    v74 = (long *)(v70+4ull);
                    long v75;
                    v75 = v74[0l];
                    US3 v80;
                    switch (v75) {
                        case 0: {
                            v80 = US3_0();
                            break;
                        }
                        case 1: {
                            v80 = US3_1();
                            break;
                        }
                        case 2: {
                            v80 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v125 = US4_0(v80);
                    break;
                }
                case 1: {
                    long * v82;
                    v82 = (long *)(v70+4ull);
                    long v83;
                    v83 = v82[0l];
                    long * v84;
                    v84 = (long *)(v70+8ull);
                    long v85;
                    v85 = v84[0l];
                    US1 v90;
                    switch (v85) {
                        case 0: {
                            v90 = US1_0();
                            break;
                        }
                        case 1: {
                            v90 = US1_1();
                            break;
                        }
                        case 2: {
                            v90 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v125 = US4_1(v83, v90);
                    break;
                }
                case 2: {
                    long * v92;
                    v92 = (long *)(v70+4ull);
                    long v93;
                    v93 = v92[0l];
                    long * v94;
                    v94 = (long *)(v70+8ull);
                    long v95;
                    v95 = v94[0l];
                    US3 v100;
                    switch (v95) {
                        case 0: {
                            v100 = US3_0();
                            break;
                        }
                        case 1: {
                            v100 = US3_1();
                            break;
                        }
                        case 2: {
                            v100 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v125 = US4_2(v93, v100);
                    break;
                }
                case 3: {
                    static_array<US3,2l> v102;
                    long v103;
                    v103 = 0l;
                    while (while_method_0(v103)){
                        unsigned long long v105;
                        v105 = (unsigned long long)v103;
                        unsigned long long v106;
                        v106 = v105 * 4ull;
                        unsigned long long v107;
                        v107 = 4ull + v106;
                        unsigned char * v108;
                        v108 = (unsigned char *)(v70+v107);
                        long * v109;
                        v109 = (long *)(v108+0ull);
                        long v110;
                        v110 = v109[0l];
                        US3 v115;
                        switch (v110) {
                            case 0: {
                                v115 = US3_0();
                                break;
                            }
                            case 1: {
                                v115 = US3_1();
                                break;
                            }
                            case 2: {
                                v115 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool v116;
                        v116 = 0l <= v103;
                        bool v118;
                        if (v116){
                            bool v117;
                            v117 = v103 < 2l;
                            v118 = v117;
                        } else {
                            v118 = false;
                        }
                        bool v119;
                        v119 = v118 == false;
                        if (v119){
                            assert("The read index needs to be in range for the static array." && v118);
                        } else {
                        }
                        v102.v[v103] = v115;
                        v103 += 1l ;
                    }
                    long * v120;
                    v120 = (long *)(v70+12ull);
                    long v121;
                    v121 = v120[0l];
                    long * v122;
                    v122 = (long *)(v70+16ull);
                    long v123;
                    v123 = v122[0l];
                    v125 = US4_3(v102, v121, v123);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v126;
            v126 = 0l <= v65;
            bool v129;
            if (v126){
                long v127;
                v127 = v61.length;
                bool v128;
                v128 = v65 < v127;
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
            v61.v[v65] = v125;
            v65 += 1l ;
        }
        long * v131;
        v131 = (long *)(v0+1056ull);
        long v132;
        v132 = v131[0l];
        US5 v403;
        switch (v132) {
            case 0: {
                v403 = US5_0();
                break;
            }
            case 1: {
                long * v135;
                v135 = (long *)(v0+1060ull);
                long v136;
                v136 = v135[0l];
                US6 v401;
                switch (v136) {
                    case 0: {
                        long * v138;
                        v138 = (long *)(v0+1064ull);
                        long v139;
                        v139 = v138[0l];
                        US7 v150;
                        switch (v139) {
                            case 0: {
                                v150 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v142;
                                v142 = (long *)(v0+1068ull);
                                long v143;
                                v143 = v142[0l];
                                US3 v148;
                                switch (v143) {
                                    case 0: {
                                        v148 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v148 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v148 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v150 = US7_1(v148);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v151;
                        v151 = (bool *)(v0+1072ull);
                        bool v152;
                        v152 = v151[0l];
                        static_array<US3,2l> v153;
                        long v154;
                        v154 = 0l;
                        while (while_method_0(v154)){
                            unsigned long long v156;
                            v156 = (unsigned long long)v154;
                            unsigned long long v157;
                            v157 = v156 * 4ull;
                            unsigned long long v158;
                            v158 = 1076ull + v157;
                            unsigned char * v159;
                            v159 = (unsigned char *)(v0+v158);
                            long * v160;
                            v160 = (long *)(v159+0ull);
                            long v161;
                            v161 = v160[0l];
                            US3 v166;
                            switch (v161) {
                                case 0: {
                                    v166 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v166 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v166 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v167;
                            v167 = 0l <= v154;
                            bool v169;
                            if (v167){
                                bool v168;
                                v168 = v154 < 2l;
                                v169 = v168;
                            } else {
                                v169 = false;
                            }
                            bool v170;
                            v170 = v169 == false;
                            if (v170){
                                assert("The read index needs to be in range for the static array." && v169);
                            } else {
                            }
                            v153.v[v154] = v166;
                            v154 += 1l ;
                        }
                        long * v171;
                        v171 = (long *)(v0+1084ull);
                        long v172;
                        v172 = v171[0l];
                        static_array<long,2l> v173;
                        long v174;
                        v174 = 0l;
                        while (while_method_0(v174)){
                            unsigned long long v176;
                            v176 = (unsigned long long)v174;
                            unsigned long long v177;
                            v177 = v176 * 4ull;
                            unsigned long long v178;
                            v178 = 1088ull + v177;
                            unsigned char * v179;
                            v179 = (unsigned char *)(v0+v178);
                            long * v180;
                            v180 = (long *)(v179+0ull);
                            long v181;
                            v181 = v180[0l];
                            bool v182;
                            v182 = 0l <= v174;
                            bool v184;
                            if (v182){
                                bool v183;
                                v183 = v174 < 2l;
                                v184 = v183;
                            } else {
                                v184 = false;
                            }
                            bool v185;
                            v185 = v184 == false;
                            if (v185){
                                assert("The read index needs to be in range for the static array." && v184);
                            } else {
                            }
                            v173.v[v174] = v181;
                            v174 += 1l ;
                        }
                        long * v186;
                        v186 = (long *)(v0+1096ull);
                        long v187;
                        v187 = v186[0l];
                        v401 = US6_0(v150, v152, v153, v172, v173, v187);
                        break;
                    }
                    case 1: {
                        v401 = US6_1();
                        break;
                    }
                    case 2: {
                        long * v190;
                        v190 = (long *)(v0+1064ull);
                        long v191;
                        v191 = v190[0l];
                        US7 v202;
                        switch (v191) {
                            case 0: {
                                v202 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v194;
                                v194 = (long *)(v0+1068ull);
                                long v195;
                                v195 = v194[0l];
                                US3 v200;
                                switch (v195) {
                                    case 0: {
                                        v200 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v200 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v200 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v202 = US7_1(v200);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v203;
                        v203 = (bool *)(v0+1072ull);
                        bool v204;
                        v204 = v203[0l];
                        static_array<US3,2l> v205;
                        long v206;
                        v206 = 0l;
                        while (while_method_0(v206)){
                            unsigned long long v208;
                            v208 = (unsigned long long)v206;
                            unsigned long long v209;
                            v209 = v208 * 4ull;
                            unsigned long long v210;
                            v210 = 1076ull + v209;
                            unsigned char * v211;
                            v211 = (unsigned char *)(v0+v210);
                            long * v212;
                            v212 = (long *)(v211+0ull);
                            long v213;
                            v213 = v212[0l];
                            US3 v218;
                            switch (v213) {
                                case 0: {
                                    v218 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v218 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v218 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v219;
                            v219 = 0l <= v206;
                            bool v221;
                            if (v219){
                                bool v220;
                                v220 = v206 < 2l;
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
                            v205.v[v206] = v218;
                            v206 += 1l ;
                        }
                        long * v223;
                        v223 = (long *)(v0+1084ull);
                        long v224;
                        v224 = v223[0l];
                        static_array<long,2l> v225;
                        long v226;
                        v226 = 0l;
                        while (while_method_0(v226)){
                            unsigned long long v228;
                            v228 = (unsigned long long)v226;
                            unsigned long long v229;
                            v229 = v228 * 4ull;
                            unsigned long long v230;
                            v230 = 1088ull + v229;
                            unsigned char * v231;
                            v231 = (unsigned char *)(v0+v230);
                            long * v232;
                            v232 = (long *)(v231+0ull);
                            long v233;
                            v233 = v232[0l];
                            bool v234;
                            v234 = 0l <= v226;
                            bool v236;
                            if (v234){
                                bool v235;
                                v235 = v226 < 2l;
                                v236 = v235;
                            } else {
                                v236 = false;
                            }
                            bool v237;
                            v237 = v236 == false;
                            if (v237){
                                assert("The read index needs to be in range for the static array." && v236);
                            } else {
                            }
                            v225.v[v226] = v233;
                            v226 += 1l ;
                        }
                        long * v238;
                        v238 = (long *)(v0+1096ull);
                        long v239;
                        v239 = v238[0l];
                        v401 = US6_2(v202, v204, v205, v224, v225, v239);
                        break;
                    }
                    case 3: {
                        long * v241;
                        v241 = (long *)(v0+1064ull);
                        long v242;
                        v242 = v241[0l];
                        US7 v253;
                        switch (v242) {
                            case 0: {
                                v253 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v245;
                                v245 = (long *)(v0+1068ull);
                                long v246;
                                v246 = v245[0l];
                                US3 v251;
                                switch (v246) {
                                    case 0: {
                                        v251 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v251 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v251 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v253 = US7_1(v251);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v254;
                        v254 = (bool *)(v0+1072ull);
                        bool v255;
                        v255 = v254[0l];
                        static_array<US3,2l> v256;
                        long v257;
                        v257 = 0l;
                        while (while_method_0(v257)){
                            unsigned long long v259;
                            v259 = (unsigned long long)v257;
                            unsigned long long v260;
                            v260 = v259 * 4ull;
                            unsigned long long v261;
                            v261 = 1076ull + v260;
                            unsigned char * v262;
                            v262 = (unsigned char *)(v0+v261);
                            long * v263;
                            v263 = (long *)(v262+0ull);
                            long v264;
                            v264 = v263[0l];
                            US3 v269;
                            switch (v264) {
                                case 0: {
                                    v269 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v269 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v269 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v270;
                            v270 = 0l <= v257;
                            bool v272;
                            if (v270){
                                bool v271;
                                v271 = v257 < 2l;
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
                            v256.v[v257] = v269;
                            v257 += 1l ;
                        }
                        long * v274;
                        v274 = (long *)(v0+1084ull);
                        long v275;
                        v275 = v274[0l];
                        static_array<long,2l> v276;
                        long v277;
                        v277 = 0l;
                        while (while_method_0(v277)){
                            unsigned long long v279;
                            v279 = (unsigned long long)v277;
                            unsigned long long v280;
                            v280 = v279 * 4ull;
                            unsigned long long v281;
                            v281 = 1088ull + v280;
                            unsigned char * v282;
                            v282 = (unsigned char *)(v0+v281);
                            long * v283;
                            v283 = (long *)(v282+0ull);
                            long v284;
                            v284 = v283[0l];
                            bool v285;
                            v285 = 0l <= v277;
                            bool v287;
                            if (v285){
                                bool v286;
                                v286 = v277 < 2l;
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
                            v276.v[v277] = v284;
                            v277 += 1l ;
                        }
                        long * v289;
                        v289 = (long *)(v0+1096ull);
                        long v290;
                        v290 = v289[0l];
                        long * v291;
                        v291 = (long *)(v0+1100ull);
                        long v292;
                        v292 = v291[0l];
                        US1 v297;
                        switch (v292) {
                            case 0: {
                                v297 = US1_0();
                                break;
                            }
                            case 1: {
                                v297 = US1_1();
                                break;
                            }
                            case 2: {
                                v297 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v401 = US6_3(v253, v255, v256, v275, v276, v290, v297);
                        break;
                    }
                    case 4: {
                        long * v299;
                        v299 = (long *)(v0+1064ull);
                        long v300;
                        v300 = v299[0l];
                        US7 v311;
                        switch (v300) {
                            case 0: {
                                v311 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v303;
                                v303 = (long *)(v0+1068ull);
                                long v304;
                                v304 = v303[0l];
                                US3 v309;
                                switch (v304) {
                                    case 0: {
                                        v309 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v309 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v309 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v311 = US7_1(v309);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v312;
                        v312 = (bool *)(v0+1072ull);
                        bool v313;
                        v313 = v312[0l];
                        static_array<US3,2l> v314;
                        long v315;
                        v315 = 0l;
                        while (while_method_0(v315)){
                            unsigned long long v317;
                            v317 = (unsigned long long)v315;
                            unsigned long long v318;
                            v318 = v317 * 4ull;
                            unsigned long long v319;
                            v319 = 1076ull + v318;
                            unsigned char * v320;
                            v320 = (unsigned char *)(v0+v319);
                            long * v321;
                            v321 = (long *)(v320+0ull);
                            long v322;
                            v322 = v321[0l];
                            US3 v327;
                            switch (v322) {
                                case 0: {
                                    v327 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v327 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v327 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v328;
                            v328 = 0l <= v315;
                            bool v330;
                            if (v328){
                                bool v329;
                                v329 = v315 < 2l;
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
                            v314.v[v315] = v327;
                            v315 += 1l ;
                        }
                        long * v332;
                        v332 = (long *)(v0+1084ull);
                        long v333;
                        v333 = v332[0l];
                        static_array<long,2l> v334;
                        long v335;
                        v335 = 0l;
                        while (while_method_0(v335)){
                            unsigned long long v337;
                            v337 = (unsigned long long)v335;
                            unsigned long long v338;
                            v338 = v337 * 4ull;
                            unsigned long long v339;
                            v339 = 1088ull + v338;
                            unsigned char * v340;
                            v340 = (unsigned char *)(v0+v339);
                            long * v341;
                            v341 = (long *)(v340+0ull);
                            long v342;
                            v342 = v341[0l];
                            bool v343;
                            v343 = 0l <= v335;
                            bool v345;
                            if (v343){
                                bool v344;
                                v344 = v335 < 2l;
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
                            v334.v[v335] = v342;
                            v335 += 1l ;
                        }
                        long * v347;
                        v347 = (long *)(v0+1096ull);
                        long v348;
                        v348 = v347[0l];
                        v401 = US6_4(v311, v313, v314, v333, v334, v348);
                        break;
                    }
                    case 5: {
                        long * v350;
                        v350 = (long *)(v0+1064ull);
                        long v351;
                        v351 = v350[0l];
                        US7 v362;
                        switch (v351) {
                            case 0: {
                                v362 = US7_0();
                                break;
                            }
                            case 1: {
                                long * v354;
                                v354 = (long *)(v0+1068ull);
                                long v355;
                                v355 = v354[0l];
                                US3 v360;
                                switch (v355) {
                                    case 0: {
                                        v360 = US3_0();
                                        break;
                                    }
                                    case 1: {
                                        v360 = US3_1();
                                        break;
                                    }
                                    case 2: {
                                        v360 = US3_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v362 = US7_1(v360);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v363;
                        v363 = (bool *)(v0+1072ull);
                        bool v364;
                        v364 = v363[0l];
                        static_array<US3,2l> v365;
                        long v366;
                        v366 = 0l;
                        while (while_method_0(v366)){
                            unsigned long long v368;
                            v368 = (unsigned long long)v366;
                            unsigned long long v369;
                            v369 = v368 * 4ull;
                            unsigned long long v370;
                            v370 = 1076ull + v369;
                            unsigned char * v371;
                            v371 = (unsigned char *)(v0+v370);
                            long * v372;
                            v372 = (long *)(v371+0ull);
                            long v373;
                            v373 = v372[0l];
                            US3 v378;
                            switch (v373) {
                                case 0: {
                                    v378 = US3_0();
                                    break;
                                }
                                case 1: {
                                    v378 = US3_1();
                                    break;
                                }
                                case 2: {
                                    v378 = US3_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v379;
                            v379 = 0l <= v366;
                            bool v381;
                            if (v379){
                                bool v380;
                                v380 = v366 < 2l;
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
                            v365.v[v366] = v378;
                            v366 += 1l ;
                        }
                        long * v383;
                        v383 = (long *)(v0+1084ull);
                        long v384;
                        v384 = v383[0l];
                        static_array<long,2l> v385;
                        long v386;
                        v386 = 0l;
                        while (while_method_0(v386)){
                            unsigned long long v388;
                            v388 = (unsigned long long)v386;
                            unsigned long long v389;
                            v389 = v388 * 4ull;
                            unsigned long long v390;
                            v390 = 1088ull + v389;
                            unsigned char * v391;
                            v391 = (unsigned char *)(v0+v390);
                            long * v392;
                            v392 = (long *)(v391+0ull);
                            long v393;
                            v393 = v392[0l];
                            bool v394;
                            v394 = 0l <= v386;
                            bool v396;
                            if (v394){
                                bool v395;
                                v395 = v386 < 2l;
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
                            v385.v[v386] = v393;
                            v386 += 1l ;
                        }
                        long * v398;
                        v398 = (long *)(v0+1096ull);
                        long v399;
                        v399 = v398[0l];
                        v401 = US6_5(v362, v364, v365, v384, v385, v399);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v403 = US5_1(v401);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array<US2,2l> v404;
        long v405;
        v405 = 0l;
        while (while_method_0(v405)){
            unsigned long long v407;
            v407 = (unsigned long long)v405;
            unsigned long long v408;
            v408 = v407 * 4ull;
            unsigned long long v409;
            v409 = 1104ull + v408;
            unsigned char * v410;
            v410 = (unsigned char *)(v0+v409);
            long * v411;
            v411 = (long *)(v410+0ull);
            long v412;
            v412 = v411[0l];
            US2 v416;
            switch (v412) {
                case 0: {
                    v416 = US2_0();
                    break;
                }
                case 1: {
                    v416 = US2_1();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v417;
            v417 = 0l <= v405;
            bool v419;
            if (v417){
                bool v418;
                v418 = v405 < 2l;
                v419 = v418;
            } else {
                v419 = false;
            }
            bool v420;
            v420 = v419 == false;
            if (v420){
                assert("The read index needs to be in range for the static array." && v419);
            } else {
            }
            v404.v[v405] = v416;
            v405 += 1l ;
        }
        long * v421;
        v421 = (long *)(v0+1112ull);
        long v422;
        v422 = v421[0l];
        US8 v527;
        switch (v422) {
            case 0: {
                v527 = US8_0();
                break;
            }
            case 1: {
                long * v425;
                v425 = (long *)(v0+1116ull);
                long v426;
                v426 = v425[0l];
                US7 v437;
                switch (v426) {
                    case 0: {
                        v437 = US7_0();
                        break;
                    }
                    case 1: {
                        long * v429;
                        v429 = (long *)(v0+1120ull);
                        long v430;
                        v430 = v429[0l];
                        US3 v435;
                        switch (v430) {
                            case 0: {
                                v435 = US3_0();
                                break;
                            }
                            case 1: {
                                v435 = US3_1();
                                break;
                            }
                            case 2: {
                                v435 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v437 = US7_1(v435);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v438;
                v438 = (bool *)(v0+1124ull);
                bool v439;
                v439 = v438[0l];
                static_array<US3,2l> v440;
                long v441;
                v441 = 0l;
                while (while_method_0(v441)){
                    unsigned long long v443;
                    v443 = (unsigned long long)v441;
                    unsigned long long v444;
                    v444 = v443 * 4ull;
                    unsigned long long v445;
                    v445 = 1128ull + v444;
                    unsigned char * v446;
                    v446 = (unsigned char *)(v0+v445);
                    long * v447;
                    v447 = (long *)(v446+0ull);
                    long v448;
                    v448 = v447[0l];
                    US3 v453;
                    switch (v448) {
                        case 0: {
                            v453 = US3_0();
                            break;
                        }
                        case 1: {
                            v453 = US3_1();
                            break;
                        }
                        case 2: {
                            v453 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v454;
                    v454 = 0l <= v441;
                    bool v456;
                    if (v454){
                        bool v455;
                        v455 = v441 < 2l;
                        v456 = v455;
                    } else {
                        v456 = false;
                    }
                    bool v457;
                    v457 = v456 == false;
                    if (v457){
                        assert("The read index needs to be in range for the static array." && v456);
                    } else {
                    }
                    v440.v[v441] = v453;
                    v441 += 1l ;
                }
                long * v458;
                v458 = (long *)(v0+1136ull);
                long v459;
                v459 = v458[0l];
                static_array<long,2l> v460;
                long v461;
                v461 = 0l;
                while (while_method_0(v461)){
                    unsigned long long v463;
                    v463 = (unsigned long long)v461;
                    unsigned long long v464;
                    v464 = v463 * 4ull;
                    unsigned long long v465;
                    v465 = 1140ull + v464;
                    unsigned char * v466;
                    v466 = (unsigned char *)(v0+v465);
                    long * v467;
                    v467 = (long *)(v466+0ull);
                    long v468;
                    v468 = v467[0l];
                    bool v469;
                    v469 = 0l <= v461;
                    bool v471;
                    if (v469){
                        bool v470;
                        v470 = v461 < 2l;
                        v471 = v470;
                    } else {
                        v471 = false;
                    }
                    bool v472;
                    v472 = v471 == false;
                    if (v472){
                        assert("The read index needs to be in range for the static array." && v471);
                    } else {
                    }
                    v460.v[v461] = v468;
                    v461 += 1l ;
                }
                long * v473;
                v473 = (long *)(v0+1148ull);
                long v474;
                v474 = v473[0l];
                v527 = US8_1(v437, v439, v440, v459, v460, v474);
                break;
            }
            case 2: {
                long * v476;
                v476 = (long *)(v0+1116ull);
                long v477;
                v477 = v476[0l];
                US7 v488;
                switch (v477) {
                    case 0: {
                        v488 = US7_0();
                        break;
                    }
                    case 1: {
                        long * v480;
                        v480 = (long *)(v0+1120ull);
                        long v481;
                        v481 = v480[0l];
                        US3 v486;
                        switch (v481) {
                            case 0: {
                                v486 = US3_0();
                                break;
                            }
                            case 1: {
                                v486 = US3_1();
                                break;
                            }
                            case 2: {
                                v486 = US3_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v488 = US7_1(v486);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v489;
                v489 = (bool *)(v0+1124ull);
                bool v490;
                v490 = v489[0l];
                static_array<US3,2l> v491;
                long v492;
                v492 = 0l;
                while (while_method_0(v492)){
                    unsigned long long v494;
                    v494 = (unsigned long long)v492;
                    unsigned long long v495;
                    v495 = v494 * 4ull;
                    unsigned long long v496;
                    v496 = 1128ull + v495;
                    unsigned char * v497;
                    v497 = (unsigned char *)(v0+v496);
                    long * v498;
                    v498 = (long *)(v497+0ull);
                    long v499;
                    v499 = v498[0l];
                    US3 v504;
                    switch (v499) {
                        case 0: {
                            v504 = US3_0();
                            break;
                        }
                        case 1: {
                            v504 = US3_1();
                            break;
                        }
                        case 2: {
                            v504 = US3_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v505;
                    v505 = 0l <= v492;
                    bool v507;
                    if (v505){
                        bool v506;
                        v506 = v492 < 2l;
                        v507 = v506;
                    } else {
                        v507 = false;
                    }
                    bool v508;
                    v508 = v507 == false;
                    if (v508){
                        assert("The read index needs to be in range for the static array." && v507);
                    } else {
                    }
                    v491.v[v492] = v504;
                    v492 += 1l ;
                }
                long * v509;
                v509 = (long *)(v0+1136ull);
                long v510;
                v510 = v509[0l];
                static_array<long,2l> v511;
                long v512;
                v512 = 0l;
                while (while_method_0(v512)){
                    unsigned long long v514;
                    v514 = (unsigned long long)v512;
                    unsigned long long v515;
                    v515 = v514 * 4ull;
                    unsigned long long v516;
                    v516 = 1140ull + v515;
                    unsigned char * v517;
                    v517 = (unsigned char *)(v0+v516);
                    long * v518;
                    v518 = (long *)(v517+0ull);
                    long v519;
                    v519 = v518[0l];
                    bool v520;
                    v520 = 0l <= v512;
                    bool v522;
                    if (v520){
                        bool v521;
                        v521 = v512 < 2l;
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
                    v511.v[v512] = v519;
                    v512 += 1l ;
                }
                long * v524;
                v524 = (long *)(v0+1148ull);
                long v525;
                v525 = v524[0l];
                v527 = US8_2(v488, v490, v491, v510, v511, v525);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US3,6l,long> & v528 = v39;
        static_array_list<US4,32l,long> & v529 = v61;
        US5 v630; static_array<US2,2l> v631; US8 v632;
        switch (v38.tag) {
            case 0: { // ActionSelected
                US1 v600 = v38.v.case0.v0;
                switch (v403.tag) {
                    case 0: { // None
                        v630 = v403; v631 = v404; v632 = v527;
                        break;
                    }
                    case 1: { // Some
                        US6 v601 = v403.v.case1.v0;
                        switch (v601.tag) {
                            case 2: { // Round
                                US7 v602 = v601.v.case2.v0; bool v603 = v601.v.case2.v1; static_array<US3,2l> v604 = v601.v.case2.v2; long v605 = v601.v.case2.v3; static_array<long,2l> v606 = v601.v.case2.v4; long v607 = v601.v.case2.v5;
                                US6 v608;
                                v608 = US6_3(v602, v603, v604, v605, v606, v607, v600);
                                Tuple0 tmp10 = play_loop_0(v403, v404, v527, v528, v529, v608);
                                v630 = tmp10.v0; v631 = tmp10.v1; v632 = tmp10.v2;
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
                static_array<US2,2l> v599 = v38.v.case1.v0;
                v630 = v403; v631 = v599; v632 = v527;
                break;
            }
            case 2: { // StartGame
                static_array<US2,2l> v530;
                US2 v531;
                v531 = US2_0();
                v530.v[0l] = v531;
                US2 v532;
                v532 = US2_1();
                v530.v[1l] = v532;
                static_array_list<US3,6l,long> v533;
                v533.length = 0;
                v533.length = 6l;
                long v534;
                v534 = v533.length;
                bool v535;
                v535 = 0l < v534;
                bool v536;
                v536 = v535 == false;
                if (v536){
                    assert("The set index needs to be in range for the static array list." && v535);
                } else {
                }
                US3 v537;
                v537 = US3_1();
                v533.v[0l] = v537;
                long v538;
                v538 = v533.length;
                bool v539;
                v539 = 1l < v538;
                bool v540;
                v540 = v539 == false;
                if (v540){
                    assert("The set index needs to be in range for the static array list." && v539);
                } else {
                }
                US3 v541;
                v541 = US3_1();
                v533.v[1l] = v541;
                long v542;
                v542 = v533.length;
                bool v543;
                v543 = 2l < v542;
                bool v544;
                v544 = v543 == false;
                if (v544){
                    assert("The set index needs to be in range for the static array list." && v543);
                } else {
                }
                US3 v545;
                v545 = US3_2();
                v533.v[2l] = v545;
                long v546;
                v546 = v533.length;
                bool v547;
                v547 = 3l < v546;
                bool v548;
                v548 = v547 == false;
                if (v548){
                    assert("The set index needs to be in range for the static array list." && v547);
                } else {
                }
                US3 v549;
                v549 = US3_2();
                v533.v[3l] = v549;
                long v550;
                v550 = v533.length;
                bool v551;
                v551 = 4l < v550;
                bool v552;
                v552 = v551 == false;
                if (v552){
                    assert("The set index needs to be in range for the static array list." && v551);
                } else {
                }
                US3 v553;
                v553 = US3_0();
                v533.v[4l] = v553;
                long v554;
                v554 = v533.length;
                bool v555;
                v555 = 5l < v554;
                bool v556;
                v556 = v555 == false;
                if (v556){
                    assert("The set index needs to be in range for the static array list." && v555);
                } else {
                }
                US3 v557;
                v557 = US3_0();
                v533.v[5l] = v557;
                unsigned long long v558;
                v558 = clock64();
                curandStatePhilox4_32_10_t v559;
                curandStatePhilox4_32_10_t * v560 = &v559;
                curand_init(v558,0ull,0ull,v560);
                long v561;
                v561 = v533.length;
                long v562;
                v562 = v561 - 1l;
                long v563;
                v563 = 0l;
                while (while_method_1(v562, v563)){
                    long v565;
                    v565 = v533.length;
                    long v566;
                    v566 = v565 - v563;
                    unsigned long v567;
                    v567 = (unsigned long)v566;
                    unsigned long v568;
                    v568 = loop_2(v567, v560);
                    unsigned long v569;
                    v569 = (unsigned long)v563;
                    unsigned long v570;
                    v570 = v568 + v569;
                    long v571;
                    v571 = (long)v570;
                    bool v572;
                    v572 = 0l <= v563;
                    bool v575;
                    if (v572){
                        long v573;
                        v573 = v533.length;
                        bool v574;
                        v574 = v563 < v573;
                        v575 = v574;
                    } else {
                        v575 = false;
                    }
                    bool v576;
                    v576 = v575 == false;
                    if (v576){
                        assert("The read index needs to be in range for the static array list." && v575);
                    } else {
                    }
                    US3 v577;
                    v577 = v533.v[v563];
                    bool v578;
                    v578 = 0l <= v571;
                    bool v581;
                    if (v578){
                        long v579;
                        v579 = v533.length;
                        bool v580;
                        v580 = v571 < v579;
                        v581 = v580;
                    } else {
                        v581 = false;
                    }
                    bool v582;
                    v582 = v581 == false;
                    if (v582){
                        assert("The read index needs to be in range for the static array list." && v581);
                    } else {
                    }
                    US3 v583;
                    v583 = v533.v[v571];
                    bool v586;
                    if (v572){
                        long v584;
                        v584 = v533.length;
                        bool v585;
                        v585 = v563 < v584;
                        v586 = v585;
                    } else {
                        v586 = false;
                    }
                    bool v587;
                    v587 = v586 == false;
                    if (v587){
                        assert("The set index needs to be in range for the static array list." && v586);
                    } else {
                    }
                    v533.v[v563] = v583;
                    bool v590;
                    if (v578){
                        long v588;
                        v588 = v533.length;
                        bool v589;
                        v589 = v571 < v588;
                        v590 = v589;
                    } else {
                        v590 = false;
                    }
                    bool v591;
                    v591 = v590 == false;
                    if (v591){
                        assert("The set index needs to be in range for the static array list." && v590);
                    } else {
                    }
                    v533.v[v571] = v577;
                    v563 += 1l ;
                }
                static_array_list<US4,32l,long> v592;
                v592.length = 0;
                v528 = v533;
                v529 = v592;
                US5 v593;
                v593 = US5_0();
                US8 v594;
                v594 = US8_0();
                US6 v595;
                v595 = US6_1();
                Tuple0 tmp11 = play_loop_0(v593, v530, v594, v528, v529, v595);
                v630 = tmp11.v0; v631 = tmp11.v1; v632 = tmp11.v2;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        long v633;
        v633 = v39.length;
        long * v634;
        v634 = (long *)(v0+0ull);
        v634[0l] = v633;
        long v635;
        v635 = v39.length;
        long v636;
        v636 = 0l;
        while (while_method_1(v635, v636)){
            unsigned long long v638;
            v638 = (unsigned long long)v636;
            unsigned long long v639;
            v639 = v638 * 4ull;
            unsigned long long v640;
            v640 = 4ull + v639;
            unsigned char * v641;
            v641 = (unsigned char *)(v0+v640);
            bool v642;
            v642 = 0l <= v636;
            bool v645;
            if (v642){
                long v643;
                v643 = v39.length;
                bool v644;
                v644 = v636 < v643;
                v645 = v644;
            } else {
                v645 = false;
            }
            bool v646;
            v646 = v645 == false;
            if (v646){
                assert("The read index needs to be in range for the static array list." && v645);
            } else {
            }
            US3 v647;
            v647 = v39.v[v636];
            long v648;
            v648 = v647.tag;
            long * v649;
            v649 = (long *)(v641+0ull);
            v649[0l] = v648;
            switch (v647.tag) {
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
            v636 += 1l ;
        }
        long v650;
        v650 = v61.length;
        long * v651;
        v651 = (long *)(v0+28ull);
        v651[0l] = v650;
        long v652;
        v652 = v61.length;
        long v653;
        v653 = 0l;
        while (while_method_1(v652, v653)){
            unsigned long long v655;
            v655 = (unsigned long long)v653;
            unsigned long long v656;
            v656 = v655 * 32ull;
            unsigned long long v657;
            v657 = 32ull + v656;
            unsigned char * v658;
            v658 = (unsigned char *)(v0+v657);
            bool v659;
            v659 = 0l <= v653;
            bool v662;
            if (v659){
                long v660;
                v660 = v61.length;
                bool v661;
                v661 = v653 < v660;
                v662 = v661;
            } else {
                v662 = false;
            }
            bool v663;
            v663 = v662 == false;
            if (v663){
                assert("The read index needs to be in range for the static array list." && v662);
            } else {
            }
            US4 v664;
            v664 = v61.v[v653];
            long v665;
            v665 = v664.tag;
            long * v666;
            v666 = (long *)(v658+0ull);
            v666[0l] = v665;
            switch (v664.tag) {
                case 0: { // CommunityCardIs
                    US3 v667 = v664.v.case0.v0;
                    long v668;
                    v668 = v667.tag;
                    long * v669;
                    v669 = (long *)(v658+4ull);
                    v669[0l] = v668;
                    switch (v667.tag) {
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
                    long v670 = v664.v.case1.v0; US1 v671 = v664.v.case1.v1;
                    long * v672;
                    v672 = (long *)(v658+4ull);
                    v672[0l] = v670;
                    long v673;
                    v673 = v671.tag;
                    long * v674;
                    v674 = (long *)(v658+8ull);
                    v674[0l] = v673;
                    switch (v671.tag) {
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
                    long v675 = v664.v.case2.v0; US3 v676 = v664.v.case2.v1;
                    long * v677;
                    v677 = (long *)(v658+4ull);
                    v677[0l] = v675;
                    long v678;
                    v678 = v676.tag;
                    long * v679;
                    v679 = (long *)(v658+8ull);
                    v679[0l] = v678;
                    switch (v676.tag) {
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
                    static_array<US3,2l> v680 = v664.v.case3.v0; long v681 = v664.v.case3.v1; long v682 = v664.v.case3.v2;
                    long v683;
                    v683 = 0l;
                    while (while_method_0(v683)){
                        unsigned long long v685;
                        v685 = (unsigned long long)v683;
                        unsigned long long v686;
                        v686 = v685 * 4ull;
                        unsigned long long v687;
                        v687 = 4ull + v686;
                        unsigned char * v688;
                        v688 = (unsigned char *)(v658+v687);
                        bool v689;
                        v689 = 0l <= v683;
                        bool v691;
                        if (v689){
                            bool v690;
                            v690 = v683 < 2l;
                            v691 = v690;
                        } else {
                            v691 = false;
                        }
                        bool v692;
                        v692 = v691 == false;
                        if (v692){
                            assert("The read index needs to be in range for the static array." && v691);
                        } else {
                        }
                        US3 v693;
                        v693 = v680.v[v683];
                        long v694;
                        v694 = v693.tag;
                        long * v695;
                        v695 = (long *)(v688+0ull);
                        v695[0l] = v694;
                        switch (v693.tag) {
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
                        v683 += 1l ;
                    }
                    long * v696;
                    v696 = (long *)(v658+12ull);
                    v696[0l] = v681;
                    long * v697;
                    v697 = (long *)(v658+16ull);
                    v697[0l] = v682;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v653 += 1l ;
        }
        long v698;
        v698 = v630.tag;
        long * v699;
        v699 = (long *)(v0+1056ull);
        v699[0l] = v698;
        switch (v630.tag) {
            case 0: { // None
                break;
            }
            case 1: { // Some
                US6 v700 = v630.v.case1.v0;
                long v701;
                v701 = v700.tag;
                long * v702;
                v702 = (long *)(v0+1060ull);
                v702[0l] = v701;
                switch (v700.tag) {
                    case 0: { // ChanceCommunityCard
                        US7 v703 = v700.v.case0.v0; bool v704 = v700.v.case0.v1; static_array<US3,2l> v705 = v700.v.case0.v2; long v706 = v700.v.case0.v3; static_array<long,2l> v707 = v700.v.case0.v4; long v708 = v700.v.case0.v5;
                        long v709;
                        v709 = v703.tag;
                        long * v710;
                        v710 = (long *)(v0+1064ull);
                        v710[0l] = v709;
                        switch (v703.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v711 = v703.v.case1.v0;
                                long v712;
                                v712 = v711.tag;
                                long * v713;
                                v713 = (long *)(v0+1068ull);
                                v713[0l] = v712;
                                switch (v711.tag) {
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
                        bool * v714;
                        v714 = (bool *)(v0+1072ull);
                        v714[0l] = v704;
                        long v715;
                        v715 = 0l;
                        while (while_method_0(v715)){
                            unsigned long long v717;
                            v717 = (unsigned long long)v715;
                            unsigned long long v718;
                            v718 = v717 * 4ull;
                            unsigned long long v719;
                            v719 = 1076ull + v718;
                            unsigned char * v720;
                            v720 = (unsigned char *)(v0+v719);
                            bool v721;
                            v721 = 0l <= v715;
                            bool v723;
                            if (v721){
                                bool v722;
                                v722 = v715 < 2l;
                                v723 = v722;
                            } else {
                                v723 = false;
                            }
                            bool v724;
                            v724 = v723 == false;
                            if (v724){
                                assert("The read index needs to be in range for the static array." && v723);
                            } else {
                            }
                            US3 v725;
                            v725 = v705.v[v715];
                            long v726;
                            v726 = v725.tag;
                            long * v727;
                            v727 = (long *)(v720+0ull);
                            v727[0l] = v726;
                            switch (v725.tag) {
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
                            v715 += 1l ;
                        }
                        long * v728;
                        v728 = (long *)(v0+1084ull);
                        v728[0l] = v706;
                        long v729;
                        v729 = 0l;
                        while (while_method_0(v729)){
                            unsigned long long v731;
                            v731 = (unsigned long long)v729;
                            unsigned long long v732;
                            v732 = v731 * 4ull;
                            unsigned long long v733;
                            v733 = 1088ull + v732;
                            unsigned char * v734;
                            v734 = (unsigned char *)(v0+v733);
                            bool v735;
                            v735 = 0l <= v729;
                            bool v737;
                            if (v735){
                                bool v736;
                                v736 = v729 < 2l;
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
                            long v739;
                            v739 = v707.v[v729];
                            long * v740;
                            v740 = (long *)(v734+0ull);
                            v740[0l] = v739;
                            v729 += 1l ;
                        }
                        long * v741;
                        v741 = (long *)(v0+1096ull);
                        v741[0l] = v708;
                        break;
                    }
                    case 1: { // ChanceInit
                        break;
                    }
                    case 2: { // Round
                        US7 v742 = v700.v.case2.v0; bool v743 = v700.v.case2.v1; static_array<US3,2l> v744 = v700.v.case2.v2; long v745 = v700.v.case2.v3; static_array<long,2l> v746 = v700.v.case2.v4; long v747 = v700.v.case2.v5;
                        long v748;
                        v748 = v742.tag;
                        long * v749;
                        v749 = (long *)(v0+1064ull);
                        v749[0l] = v748;
                        switch (v742.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v750 = v742.v.case1.v0;
                                long v751;
                                v751 = v750.tag;
                                long * v752;
                                v752 = (long *)(v0+1068ull);
                                v752[0l] = v751;
                                switch (v750.tag) {
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
                        bool * v753;
                        v753 = (bool *)(v0+1072ull);
                        v753[0l] = v743;
                        long v754;
                        v754 = 0l;
                        while (while_method_0(v754)){
                            unsigned long long v756;
                            v756 = (unsigned long long)v754;
                            unsigned long long v757;
                            v757 = v756 * 4ull;
                            unsigned long long v758;
                            v758 = 1076ull + v757;
                            unsigned char * v759;
                            v759 = (unsigned char *)(v0+v758);
                            bool v760;
                            v760 = 0l <= v754;
                            bool v762;
                            if (v760){
                                bool v761;
                                v761 = v754 < 2l;
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
                            US3 v764;
                            v764 = v744.v[v754];
                            long v765;
                            v765 = v764.tag;
                            long * v766;
                            v766 = (long *)(v759+0ull);
                            v766[0l] = v765;
                            switch (v764.tag) {
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
                            v754 += 1l ;
                        }
                        long * v767;
                        v767 = (long *)(v0+1084ull);
                        v767[0l] = v745;
                        long v768;
                        v768 = 0l;
                        while (while_method_0(v768)){
                            unsigned long long v770;
                            v770 = (unsigned long long)v768;
                            unsigned long long v771;
                            v771 = v770 * 4ull;
                            unsigned long long v772;
                            v772 = 1088ull + v771;
                            unsigned char * v773;
                            v773 = (unsigned char *)(v0+v772);
                            bool v774;
                            v774 = 0l <= v768;
                            bool v776;
                            if (v774){
                                bool v775;
                                v775 = v768 < 2l;
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
                            long v778;
                            v778 = v746.v[v768];
                            long * v779;
                            v779 = (long *)(v773+0ull);
                            v779[0l] = v778;
                            v768 += 1l ;
                        }
                        long * v780;
                        v780 = (long *)(v0+1096ull);
                        v780[0l] = v747;
                        break;
                    }
                    case 3: { // RoundWithAction
                        US7 v781 = v700.v.case3.v0; bool v782 = v700.v.case3.v1; static_array<US3,2l> v783 = v700.v.case3.v2; long v784 = v700.v.case3.v3; static_array<long,2l> v785 = v700.v.case3.v4; long v786 = v700.v.case3.v5; US1 v787 = v700.v.case3.v6;
                        long v788;
                        v788 = v781.tag;
                        long * v789;
                        v789 = (long *)(v0+1064ull);
                        v789[0l] = v788;
                        switch (v781.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v790 = v781.v.case1.v0;
                                long v791;
                                v791 = v790.tag;
                                long * v792;
                                v792 = (long *)(v0+1068ull);
                                v792[0l] = v791;
                                switch (v790.tag) {
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
                        bool * v793;
                        v793 = (bool *)(v0+1072ull);
                        v793[0l] = v782;
                        long v794;
                        v794 = 0l;
                        while (while_method_0(v794)){
                            unsigned long long v796;
                            v796 = (unsigned long long)v794;
                            unsigned long long v797;
                            v797 = v796 * 4ull;
                            unsigned long long v798;
                            v798 = 1076ull + v797;
                            unsigned char * v799;
                            v799 = (unsigned char *)(v0+v798);
                            bool v800;
                            v800 = 0l <= v794;
                            bool v802;
                            if (v800){
                                bool v801;
                                v801 = v794 < 2l;
                                v802 = v801;
                            } else {
                                v802 = false;
                            }
                            bool v803;
                            v803 = v802 == false;
                            if (v803){
                                assert("The read index needs to be in range for the static array." && v802);
                            } else {
                            }
                            US3 v804;
                            v804 = v783.v[v794];
                            long v805;
                            v805 = v804.tag;
                            long * v806;
                            v806 = (long *)(v799+0ull);
                            v806[0l] = v805;
                            switch (v804.tag) {
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
                            v794 += 1l ;
                        }
                        long * v807;
                        v807 = (long *)(v0+1084ull);
                        v807[0l] = v784;
                        long v808;
                        v808 = 0l;
                        while (while_method_0(v808)){
                            unsigned long long v810;
                            v810 = (unsigned long long)v808;
                            unsigned long long v811;
                            v811 = v810 * 4ull;
                            unsigned long long v812;
                            v812 = 1088ull + v811;
                            unsigned char * v813;
                            v813 = (unsigned char *)(v0+v812);
                            bool v814;
                            v814 = 0l <= v808;
                            bool v816;
                            if (v814){
                                bool v815;
                                v815 = v808 < 2l;
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
                            long v818;
                            v818 = v785.v[v808];
                            long * v819;
                            v819 = (long *)(v813+0ull);
                            v819[0l] = v818;
                            v808 += 1l ;
                        }
                        long * v820;
                        v820 = (long *)(v0+1096ull);
                        v820[0l] = v786;
                        long v821;
                        v821 = v787.tag;
                        long * v822;
                        v822 = (long *)(v0+1100ull);
                        v822[0l] = v821;
                        switch (v787.tag) {
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
                        US7 v823 = v700.v.case4.v0; bool v824 = v700.v.case4.v1; static_array<US3,2l> v825 = v700.v.case4.v2; long v826 = v700.v.case4.v3; static_array<long,2l> v827 = v700.v.case4.v4; long v828 = v700.v.case4.v5;
                        long v829;
                        v829 = v823.tag;
                        long * v830;
                        v830 = (long *)(v0+1064ull);
                        v830[0l] = v829;
                        switch (v823.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v831 = v823.v.case1.v0;
                                long v832;
                                v832 = v831.tag;
                                long * v833;
                                v833 = (long *)(v0+1068ull);
                                v833[0l] = v832;
                                switch (v831.tag) {
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
                        bool * v834;
                        v834 = (bool *)(v0+1072ull);
                        v834[0l] = v824;
                        long v835;
                        v835 = 0l;
                        while (while_method_0(v835)){
                            unsigned long long v837;
                            v837 = (unsigned long long)v835;
                            unsigned long long v838;
                            v838 = v837 * 4ull;
                            unsigned long long v839;
                            v839 = 1076ull + v838;
                            unsigned char * v840;
                            v840 = (unsigned char *)(v0+v839);
                            bool v841;
                            v841 = 0l <= v835;
                            bool v843;
                            if (v841){
                                bool v842;
                                v842 = v835 < 2l;
                                v843 = v842;
                            } else {
                                v843 = false;
                            }
                            bool v844;
                            v844 = v843 == false;
                            if (v844){
                                assert("The read index needs to be in range for the static array." && v843);
                            } else {
                            }
                            US3 v845;
                            v845 = v825.v[v835];
                            long v846;
                            v846 = v845.tag;
                            long * v847;
                            v847 = (long *)(v840+0ull);
                            v847[0l] = v846;
                            switch (v845.tag) {
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
                            v835 += 1l ;
                        }
                        long * v848;
                        v848 = (long *)(v0+1084ull);
                        v848[0l] = v826;
                        long v849;
                        v849 = 0l;
                        while (while_method_0(v849)){
                            unsigned long long v851;
                            v851 = (unsigned long long)v849;
                            unsigned long long v852;
                            v852 = v851 * 4ull;
                            unsigned long long v853;
                            v853 = 1088ull + v852;
                            unsigned char * v854;
                            v854 = (unsigned char *)(v0+v853);
                            bool v855;
                            v855 = 0l <= v849;
                            bool v857;
                            if (v855){
                                bool v856;
                                v856 = v849 < 2l;
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
                            long v859;
                            v859 = v827.v[v849];
                            long * v860;
                            v860 = (long *)(v854+0ull);
                            v860[0l] = v859;
                            v849 += 1l ;
                        }
                        long * v861;
                        v861 = (long *)(v0+1096ull);
                        v861[0l] = v828;
                        break;
                    }
                    case 5: { // TerminalFold
                        US7 v862 = v700.v.case5.v0; bool v863 = v700.v.case5.v1; static_array<US3,2l> v864 = v700.v.case5.v2; long v865 = v700.v.case5.v3; static_array<long,2l> v866 = v700.v.case5.v4; long v867 = v700.v.case5.v5;
                        long v868;
                        v868 = v862.tag;
                        long * v869;
                        v869 = (long *)(v0+1064ull);
                        v869[0l] = v868;
                        switch (v862.tag) {
                            case 0: { // None
                                break;
                            }
                            case 1: { // Some
                                US3 v870 = v862.v.case1.v0;
                                long v871;
                                v871 = v870.tag;
                                long * v872;
                                v872 = (long *)(v0+1068ull);
                                v872[0l] = v871;
                                switch (v870.tag) {
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
                        bool * v873;
                        v873 = (bool *)(v0+1072ull);
                        v873[0l] = v863;
                        long v874;
                        v874 = 0l;
                        while (while_method_0(v874)){
                            unsigned long long v876;
                            v876 = (unsigned long long)v874;
                            unsigned long long v877;
                            v877 = v876 * 4ull;
                            unsigned long long v878;
                            v878 = 1076ull + v877;
                            unsigned char * v879;
                            v879 = (unsigned char *)(v0+v878);
                            bool v880;
                            v880 = 0l <= v874;
                            bool v882;
                            if (v880){
                                bool v881;
                                v881 = v874 < 2l;
                                v882 = v881;
                            } else {
                                v882 = false;
                            }
                            bool v883;
                            v883 = v882 == false;
                            if (v883){
                                assert("The read index needs to be in range for the static array." && v882);
                            } else {
                            }
                            US3 v884;
                            v884 = v864.v[v874];
                            long v885;
                            v885 = v884.tag;
                            long * v886;
                            v886 = (long *)(v879+0ull);
                            v886[0l] = v885;
                            switch (v884.tag) {
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
                            v874 += 1l ;
                        }
                        long * v887;
                        v887 = (long *)(v0+1084ull);
                        v887[0l] = v865;
                        long v888;
                        v888 = 0l;
                        while (while_method_0(v888)){
                            unsigned long long v890;
                            v890 = (unsigned long long)v888;
                            unsigned long long v891;
                            v891 = v890 * 4ull;
                            unsigned long long v892;
                            v892 = 1088ull + v891;
                            unsigned char * v893;
                            v893 = (unsigned char *)(v0+v892);
                            bool v894;
                            v894 = 0l <= v888;
                            bool v896;
                            if (v894){
                                bool v895;
                                v895 = v888 < 2l;
                                v896 = v895;
                            } else {
                                v896 = false;
                            }
                            bool v897;
                            v897 = v896 == false;
                            if (v897){
                                assert("The read index needs to be in range for the static array." && v896);
                            } else {
                            }
                            long v898;
                            v898 = v866.v[v888];
                            long * v899;
                            v899 = (long *)(v893+0ull);
                            v899[0l] = v898;
                            v888 += 1l ;
                        }
                        long * v900;
                        v900 = (long *)(v0+1096ull);
                        v900[0l] = v867;
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
        long v901;
        v901 = 0l;
        while (while_method_0(v901)){
            unsigned long long v903;
            v903 = (unsigned long long)v901;
            unsigned long long v904;
            v904 = v903 * 4ull;
            unsigned long long v905;
            v905 = 1104ull + v904;
            unsigned char * v906;
            v906 = (unsigned char *)(v0+v905);
            bool v907;
            v907 = 0l <= v901;
            bool v909;
            if (v907){
                bool v908;
                v908 = v901 < 2l;
                v909 = v908;
            } else {
                v909 = false;
            }
            bool v910;
            v910 = v909 == false;
            if (v910){
                assert("The read index needs to be in range for the static array." && v909);
            } else {
            }
            US2 v911;
            v911 = v631.v[v901];
            long v912;
            v912 = v911.tag;
            long * v913;
            v913 = (long *)(v906+0ull);
            v913[0l] = v912;
            switch (v911.tag) {
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
            v901 += 1l ;
        }
        long v914;
        v914 = v632.tag;
        long * v915;
        v915 = (long *)(v0+1112ull);
        v915[0l] = v914;
        switch (v632.tag) {
            case 0: { // GameNotStarted
                break;
            }
            case 1: { // GameOver
                US7 v916 = v632.v.case1.v0; bool v917 = v632.v.case1.v1; static_array<US3,2l> v918 = v632.v.case1.v2; long v919 = v632.v.case1.v3; static_array<long,2l> v920 = v632.v.case1.v4; long v921 = v632.v.case1.v5;
                long v922;
                v922 = v916.tag;
                long * v923;
                v923 = (long *)(v0+1116ull);
                v923[0l] = v922;
                switch (v916.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v924 = v916.v.case1.v0;
                        long v925;
                        v925 = v924.tag;
                        long * v926;
                        v926 = (long *)(v0+1120ull);
                        v926[0l] = v925;
                        switch (v924.tag) {
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
                bool * v927;
                v927 = (bool *)(v0+1124ull);
                v927[0l] = v917;
                long v928;
                v928 = 0l;
                while (while_method_0(v928)){
                    unsigned long long v930;
                    v930 = (unsigned long long)v928;
                    unsigned long long v931;
                    v931 = v930 * 4ull;
                    unsigned long long v932;
                    v932 = 1128ull + v931;
                    unsigned char * v933;
                    v933 = (unsigned char *)(v0+v932);
                    bool v934;
                    v934 = 0l <= v928;
                    bool v936;
                    if (v934){
                        bool v935;
                        v935 = v928 < 2l;
                        v936 = v935;
                    } else {
                        v936 = false;
                    }
                    bool v937;
                    v937 = v936 == false;
                    if (v937){
                        assert("The read index needs to be in range for the static array." && v936);
                    } else {
                    }
                    US3 v938;
                    v938 = v918.v[v928];
                    long v939;
                    v939 = v938.tag;
                    long * v940;
                    v940 = (long *)(v933+0ull);
                    v940[0l] = v939;
                    switch (v938.tag) {
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
                    v928 += 1l ;
                }
                long * v941;
                v941 = (long *)(v0+1136ull);
                v941[0l] = v919;
                long v942;
                v942 = 0l;
                while (while_method_0(v942)){
                    unsigned long long v944;
                    v944 = (unsigned long long)v942;
                    unsigned long long v945;
                    v945 = v944 * 4ull;
                    unsigned long long v946;
                    v946 = 1140ull + v945;
                    unsigned char * v947;
                    v947 = (unsigned char *)(v0+v946);
                    bool v948;
                    v948 = 0l <= v942;
                    bool v950;
                    if (v948){
                        bool v949;
                        v949 = v942 < 2l;
                        v950 = v949;
                    } else {
                        v950 = false;
                    }
                    bool v951;
                    v951 = v950 == false;
                    if (v951){
                        assert("The read index needs to be in range for the static array." && v950);
                    } else {
                    }
                    long v952;
                    v952 = v920.v[v942];
                    long * v953;
                    v953 = (long *)(v947+0ull);
                    v953[0l] = v952;
                    v942 += 1l ;
                }
                long * v954;
                v954 = (long *)(v0+1148ull);
                v954[0l] = v921;
                break;
            }
            case 2: { // WaitingForActionFromPlayerId
                US7 v955 = v632.v.case2.v0; bool v956 = v632.v.case2.v1; static_array<US3,2l> v957 = v632.v.case2.v2; long v958 = v632.v.case2.v3; static_array<long,2l> v959 = v632.v.case2.v4; long v960 = v632.v.case2.v5;
                long v961;
                v961 = v955.tag;
                long * v962;
                v962 = (long *)(v0+1116ull);
                v962[0l] = v961;
                switch (v955.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v963 = v955.v.case1.v0;
                        long v964;
                        v964 = v963.tag;
                        long * v965;
                        v965 = (long *)(v0+1120ull);
                        v965[0l] = v964;
                        switch (v963.tag) {
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
                bool * v966;
                v966 = (bool *)(v0+1124ull);
                v966[0l] = v956;
                long v967;
                v967 = 0l;
                while (while_method_0(v967)){
                    unsigned long long v969;
                    v969 = (unsigned long long)v967;
                    unsigned long long v970;
                    v970 = v969 * 4ull;
                    unsigned long long v971;
                    v971 = 1128ull + v970;
                    unsigned char * v972;
                    v972 = (unsigned char *)(v0+v971);
                    bool v973;
                    v973 = 0l <= v967;
                    bool v975;
                    if (v973){
                        bool v974;
                        v974 = v967 < 2l;
                        v975 = v974;
                    } else {
                        v975 = false;
                    }
                    bool v976;
                    v976 = v975 == false;
                    if (v976){
                        assert("The read index needs to be in range for the static array." && v975);
                    } else {
                    }
                    US3 v977;
                    v977 = v957.v[v967];
                    long v978;
                    v978 = v977.tag;
                    long * v979;
                    v979 = (long *)(v972+0ull);
                    v979[0l] = v978;
                    switch (v977.tag) {
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
                    v967 += 1l ;
                }
                long * v980;
                v980 = (long *)(v0+1136ull);
                v980[0l] = v958;
                long v981;
                v981 = 0l;
                while (while_method_0(v981)){
                    unsigned long long v983;
                    v983 = (unsigned long long)v981;
                    unsigned long long v984;
                    v984 = v983 * 4ull;
                    unsigned long long v985;
                    v985 = 1140ull + v984;
                    unsigned char * v986;
                    v986 = (unsigned char *)(v0+v985);
                    bool v987;
                    v987 = 0l <= v981;
                    bool v989;
                    if (v987){
                        bool v988;
                        v988 = v981 < 2l;
                        v989 = v988;
                    } else {
                        v989 = false;
                    }
                    bool v990;
                    v990 = v989 == false;
                    if (v990){
                        assert("The read index needs to be in range for the static array." && v989);
                    } else {
                    }
                    long v991;
                    v991 = v959.v[v981];
                    long * v992;
                    v992 = (long *)(v986+0ull);
                    v992[0l] = v991;
                    v981 += 1l ;
                }
                long * v993;
                v993 = (long *)(v0+1148ull);
                v993[0l] = v960;
                break;
            }
            default: {
                assert("Invalid tag." && false);
            }
        }
        long v994;
        v994 = v61.length;
        long * v995;
        v995 = (long *)(v2+0ull);
        v995[0l] = v994;
        long v996;
        v996 = v61.length;
        long v997;
        v997 = 0l;
        while (while_method_1(v996, v997)){
            unsigned long long v999;
            v999 = (unsigned long long)v997;
            unsigned long long v1000;
            v1000 = v999 * 32ull;
            unsigned long long v1001;
            v1001 = 16ull + v1000;
            unsigned char * v1002;
            v1002 = (unsigned char *)(v2+v1001);
            bool v1003;
            v1003 = 0l <= v997;
            bool v1006;
            if (v1003){
                long v1004;
                v1004 = v61.length;
                bool v1005;
                v1005 = v997 < v1004;
                v1006 = v1005;
            } else {
                v1006 = false;
            }
            bool v1007;
            v1007 = v1006 == false;
            if (v1007){
                assert("The read index needs to be in range for the static array list." && v1006);
            } else {
            }
            US4 v1008;
            v1008 = v61.v[v997];
            long v1009;
            v1009 = v1008.tag;
            long * v1010;
            v1010 = (long *)(v1002+0ull);
            v1010[0l] = v1009;
            switch (v1008.tag) {
                case 0: { // CommunityCardIs
                    US3 v1011 = v1008.v.case0.v0;
                    long v1012;
                    v1012 = v1011.tag;
                    long * v1013;
                    v1013 = (long *)(v1002+4ull);
                    v1013[0l] = v1012;
                    switch (v1011.tag) {
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
                    long v1014 = v1008.v.case1.v0; US1 v1015 = v1008.v.case1.v1;
                    long * v1016;
                    v1016 = (long *)(v1002+4ull);
                    v1016[0l] = v1014;
                    long v1017;
                    v1017 = v1015.tag;
                    long * v1018;
                    v1018 = (long *)(v1002+8ull);
                    v1018[0l] = v1017;
                    switch (v1015.tag) {
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
                    long v1019 = v1008.v.case2.v0; US3 v1020 = v1008.v.case2.v1;
                    long * v1021;
                    v1021 = (long *)(v1002+4ull);
                    v1021[0l] = v1019;
                    long v1022;
                    v1022 = v1020.tag;
                    long * v1023;
                    v1023 = (long *)(v1002+8ull);
                    v1023[0l] = v1022;
                    switch (v1020.tag) {
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
                    static_array<US3,2l> v1024 = v1008.v.case3.v0; long v1025 = v1008.v.case3.v1; long v1026 = v1008.v.case3.v2;
                    long v1027;
                    v1027 = 0l;
                    while (while_method_0(v1027)){
                        unsigned long long v1029;
                        v1029 = (unsigned long long)v1027;
                        unsigned long long v1030;
                        v1030 = v1029 * 4ull;
                        unsigned long long v1031;
                        v1031 = 4ull + v1030;
                        unsigned char * v1032;
                        v1032 = (unsigned char *)(v1002+v1031);
                        bool v1033;
                        v1033 = 0l <= v1027;
                        bool v1035;
                        if (v1033){
                            bool v1034;
                            v1034 = v1027 < 2l;
                            v1035 = v1034;
                        } else {
                            v1035 = false;
                        }
                        bool v1036;
                        v1036 = v1035 == false;
                        if (v1036){
                            assert("The read index needs to be in range for the static array." && v1035);
                        } else {
                        }
                        US3 v1037;
                        v1037 = v1024.v[v1027];
                        long v1038;
                        v1038 = v1037.tag;
                        long * v1039;
                        v1039 = (long *)(v1032+0ull);
                        v1039[0l] = v1038;
                        switch (v1037.tag) {
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
                        v1027 += 1l ;
                    }
                    long * v1040;
                    v1040 = (long *)(v1002+12ull);
                    v1040[0l] = v1025;
                    long * v1041;
                    v1041 = (long *)(v1002+16ull);
                    v1041[0l] = v1026;
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            v997 += 1l ;
        }
        long v1042;
        v1042 = 0l;
        while (while_method_0(v1042)){
            unsigned long long v1044;
            v1044 = (unsigned long long)v1042;
            unsigned long long v1045;
            v1045 = v1044 * 4ull;
            unsigned long long v1046;
            v1046 = 1040ull + v1045;
            unsigned char * v1047;
            v1047 = (unsigned char *)(v2+v1046);
            bool v1048;
            v1048 = 0l <= v1042;
            bool v1050;
            if (v1048){
                bool v1049;
                v1049 = v1042 < 2l;
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
            US2 v1052;
            v1052 = v631.v[v1042];
            long v1053;
            v1053 = v1052.tag;
            long * v1054;
            v1054 = (long *)(v1047+0ull);
            v1054[0l] = v1053;
            switch (v1052.tag) {
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
            v1042 += 1l ;
        }
        long * v1055;
        v1055 = (long *)(v2+1048ull);
        v1055[0l] = v914;
        switch (v632.tag) {
            case 0: { // GameNotStarted
                return ;
                break;
            }
            case 1: { // GameOver
                US7 v1056 = v632.v.case1.v0; bool v1057 = v632.v.case1.v1; static_array<US3,2l> v1058 = v632.v.case1.v2; long v1059 = v632.v.case1.v3; static_array<long,2l> v1060 = v632.v.case1.v4; long v1061 = v632.v.case1.v5;
                long v1062;
                v1062 = v1056.tag;
                long * v1063;
                v1063 = (long *)(v2+1052ull);
                v1063[0l] = v1062;
                switch (v1056.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v1064 = v1056.v.case1.v0;
                        long v1065;
                        v1065 = v1064.tag;
                        long * v1066;
                        v1066 = (long *)(v2+1056ull);
                        v1066[0l] = v1065;
                        switch (v1064.tag) {
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
                bool * v1067;
                v1067 = (bool *)(v2+1060ull);
                v1067[0l] = v1057;
                long v1068;
                v1068 = 0l;
                while (while_method_0(v1068)){
                    unsigned long long v1070;
                    v1070 = (unsigned long long)v1068;
                    unsigned long long v1071;
                    v1071 = v1070 * 4ull;
                    unsigned long long v1072;
                    v1072 = 1064ull + v1071;
                    unsigned char * v1073;
                    v1073 = (unsigned char *)(v2+v1072);
                    bool v1074;
                    v1074 = 0l <= v1068;
                    bool v1076;
                    if (v1074){
                        bool v1075;
                        v1075 = v1068 < 2l;
                        v1076 = v1075;
                    } else {
                        v1076 = false;
                    }
                    bool v1077;
                    v1077 = v1076 == false;
                    if (v1077){
                        assert("The read index needs to be in range for the static array." && v1076);
                    } else {
                    }
                    US3 v1078;
                    v1078 = v1058.v[v1068];
                    long v1079;
                    v1079 = v1078.tag;
                    long * v1080;
                    v1080 = (long *)(v1073+0ull);
                    v1080[0l] = v1079;
                    switch (v1078.tag) {
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
                    v1068 += 1l ;
                }
                long * v1081;
                v1081 = (long *)(v2+1072ull);
                v1081[0l] = v1059;
                long v1082;
                v1082 = 0l;
                while (while_method_0(v1082)){
                    unsigned long long v1084;
                    v1084 = (unsigned long long)v1082;
                    unsigned long long v1085;
                    v1085 = v1084 * 4ull;
                    unsigned long long v1086;
                    v1086 = 1076ull + v1085;
                    unsigned char * v1087;
                    v1087 = (unsigned char *)(v2+v1086);
                    bool v1088;
                    v1088 = 0l <= v1082;
                    bool v1090;
                    if (v1088){
                        bool v1089;
                        v1089 = v1082 < 2l;
                        v1090 = v1089;
                    } else {
                        v1090 = false;
                    }
                    bool v1091;
                    v1091 = v1090 == false;
                    if (v1091){
                        assert("The read index needs to be in range for the static array." && v1090);
                    } else {
                    }
                    long v1092;
                    v1092 = v1060.v[v1082];
                    long * v1093;
                    v1093 = (long *)(v1087+0ull);
                    v1093[0l] = v1092;
                    v1082 += 1l ;
                }
                long * v1094;
                v1094 = (long *)(v2+1084ull);
                v1094[0l] = v1061;
                return ;
                break;
            }
            case 2: { // WaitingForActionFromPlayerId
                US7 v1095 = v632.v.case2.v0; bool v1096 = v632.v.case2.v1; static_array<US3,2l> v1097 = v632.v.case2.v2; long v1098 = v632.v.case2.v3; static_array<long,2l> v1099 = v632.v.case2.v4; long v1100 = v632.v.case2.v5;
                long v1101;
                v1101 = v1095.tag;
                long * v1102;
                v1102 = (long *)(v2+1052ull);
                v1102[0l] = v1101;
                switch (v1095.tag) {
                    case 0: { // None
                        break;
                    }
                    case 1: { // Some
                        US3 v1103 = v1095.v.case1.v0;
                        long v1104;
                        v1104 = v1103.tag;
                        long * v1105;
                        v1105 = (long *)(v2+1056ull);
                        v1105[0l] = v1104;
                        switch (v1103.tag) {
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
                bool * v1106;
                v1106 = (bool *)(v2+1060ull);
                v1106[0l] = v1096;
                long v1107;
                v1107 = 0l;
                while (while_method_0(v1107)){
                    unsigned long long v1109;
                    v1109 = (unsigned long long)v1107;
                    unsigned long long v1110;
                    v1110 = v1109 * 4ull;
                    unsigned long long v1111;
                    v1111 = 1064ull + v1110;
                    unsigned char * v1112;
                    v1112 = (unsigned char *)(v2+v1111);
                    bool v1113;
                    v1113 = 0l <= v1107;
                    bool v1115;
                    if (v1113){
                        bool v1114;
                        v1114 = v1107 < 2l;
                        v1115 = v1114;
                    } else {
                        v1115 = false;
                    }
                    bool v1116;
                    v1116 = v1115 == false;
                    if (v1116){
                        assert("The read index needs to be in range for the static array." && v1115);
                    } else {
                    }
                    US3 v1117;
                    v1117 = v1097.v[v1107];
                    long v1118;
                    v1118 = v1117.tag;
                    long * v1119;
                    v1119 = (long *)(v1112+0ull);
                    v1119[0l] = v1118;
                    switch (v1117.tag) {
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
                    v1107 += 1l ;
                }
                long * v1120;
                v1120 = (long *)(v2+1072ull);
                v1120[0l] = v1098;
                long v1121;
                v1121 = 0l;
                while (while_method_0(v1121)){
                    unsigned long long v1123;
                    v1123 = (unsigned long long)v1121;
                    unsigned long long v1124;
                    v1124 = v1123 * 4ull;
                    unsigned long long v1125;
                    v1125 = 1076ull + v1124;
                    unsigned char * v1126;
                    v1126 = (unsigned char *)(v2+v1125);
                    bool v1127;
                    v1127 = 0l <= v1121;
                    bool v1129;
                    if (v1127){
                        bool v1128;
                        v1128 = v1121 < 2l;
                        v1129 = v1128;
                    } else {
                        v1129 = false;
                    }
                    bool v1130;
                    v1130 = v1129 == false;
                    if (v1130){
                        assert("The read index needs to be in range for the static array." && v1129);
                    } else {
                    }
                    long v1131;
                    v1131 = v1099.v[v1121];
                    long * v1132;
                    v1132 = (long *)(v1126+0ull);
                    v1132[0l] = v1131;
                    v1121 += 1l ;
                }
                long * v1133;
                v1133 = (long *)(v2+1084ull);
                v1133[0l] = v1100;
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
        v3 = cp.empty(1152,dtype=cp.uint8)
        v4 = cp.empty(1088,dtype=cp.uint8)
        v5 = method0(v0)
        v6, v7, v8, v9, v10 = method5(v1)
        v11 = v5.tag
        v12 = v2[0:].view(cp.int32)
        v12[0] = v11
        del v11, v12
        match v5:
            case US0_0(v13): # ActionSelected
                v14 = v13.tag
                v15 = v2[4:].view(cp.int32)
                v15[0] = v14
                del v14, v15
                match v13:
                    case US1_0(): # Call
                        del v13
                    case US1_1(): # Fold
                        del v13
                    case US1_2(): # Raise
                        del v13
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US0_1(v16): # PlayerChanged
                v17 = 0
                while method12(v17):
                    v19 = u64(v17)
                    v20 = v19 * 4
                    del v19
                    v21 = 4 + v20
                    del v20
                    v22 = v2[v21:].view(cp.uint8)
                    del v21
                    v23 = 0 <= v17
                    if v23:
                        v24 = v17 < 2
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
                    v28 = v16[v17]
                    v29 = v28.tag
                    v30 = v22[0:].view(cp.int32)
                    del v22
                    v30[0] = v29
                    del v29, v30
                    match v28:
                        case US2_0(): # Computer
                            pass
                        case US2_1(): # Human
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v28
                    v17 += 1 
                del v16, v17
            case US0_2(): # StartGame
                pass
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v5
        v31 = v6.length
        v32 = v3[0:].view(cp.int32)
        v32[0] = v31
        del v31, v32
        v33 = v6.length
        v34 = 0
        while method3(v33, v34):
            v36 = u64(v34)
            v37 = v36 * 4
            del v36
            v38 = 4 + v37
            del v37
            v39 = v3[v38:].view(cp.uint8)
            del v38
            v40 = 0 <= v34
            if v40:
                v41 = v6.length
                v42 = v34 < v41
                del v41
                v43 = v42
            else:
                v43 = False
            del v40
            v44 = v43 == False
            if v44:
                v45 = "The read index needs to be in range for the static array list."
                assert v43, v45
                del v45
            else:
                pass
            del v43, v44
            v46 = v6[v34]
            v47 = v46.tag
            v48 = v39[0:].view(cp.int32)
            del v39
            v48[0] = v47
            del v47, v48
            match v46:
                case US6_0(): # Jack
                    pass
                case US6_1(): # King
                    pass
                case US6_2(): # Queen
                    pass
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v46
            v34 += 1 
        del v6, v33, v34
        v49 = v7.length
        v50 = v3[28:].view(cp.int32)
        v50[0] = v49
        del v49, v50
        v51 = v7.length
        v52 = 0
        while method3(v51, v52):
            v54 = u64(v52)
            v55 = v54 * 32
            del v54
            v56 = 32 + v55
            del v55
            v57 = v3[v56:].view(cp.uint8)
            del v56
            v58 = 0 <= v52
            if v58:
                v59 = v7.length
                v60 = v52 < v59
                del v59
                v61 = v60
            else:
                v61 = False
            del v58
            v62 = v61 == False
            if v62:
                v63 = "The read index needs to be in range for the static array list."
                assert v61, v63
                del v63
            else:
                pass
            del v61, v62
            v64 = v7[v52]
            v65 = v64.tag
            v66 = v57[0:].view(cp.int32)
            v66[0] = v65
            del v65, v66
            match v64:
                case US8_0(v67): # CommunityCardIs
                    v68 = v67.tag
                    v69 = v57[4:].view(cp.int32)
                    v69[0] = v68
                    del v68, v69
                    match v67:
                        case US6_0(): # Jack
                            del v67
                        case US6_1(): # King
                            del v67
                        case US6_2(): # Queen
                            del v67
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US8_1(v70, v71): # PlayerAction
                    v72 = v57[4:].view(cp.int32)
                    v72[0] = v70
                    del v70, v72
                    v73 = v71.tag
                    v74 = v57[8:].view(cp.int32)
                    v74[0] = v73
                    del v73, v74
                    match v71:
                        case US1_0(): # Call
                            del v71
                        case US1_1(): # Fold
                            del v71
                        case US1_2(): # Raise
                            del v71
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US8_2(v75, v76): # PlayerGotCard
                    v77 = v57[4:].view(cp.int32)
                    v77[0] = v75
                    del v75, v77
                    v78 = v76.tag
                    v79 = v57[8:].view(cp.int32)
                    v79[0] = v78
                    del v78, v79
                    match v76:
                        case US6_0(): # Jack
                            del v76
                        case US6_1(): # King
                            del v76
                        case US6_2(): # Queen
                            del v76
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US8_3(v80, v81, v82): # Showdown
                    v83 = 0
                    while method12(v83):
                        v85 = u64(v83)
                        v86 = v85 * 4
                        del v85
                        v87 = 4 + v86
                        del v86
                        v88 = v57[v87:].view(cp.uint8)
                        del v87
                        v89 = 0 <= v83
                        if v89:
                            v90 = v83 < 2
                            v91 = v90
                        else:
                            v91 = False
                        del v89
                        v92 = v91 == False
                        if v92:
                            v93 = "The read index needs to be in range for the static array."
                            assert v91, v93
                            del v93
                        else:
                            pass
                        del v91, v92
                        v94 = v80[v83]
                        v95 = v94.tag
                        v96 = v88[0:].view(cp.int32)
                        del v88
                        v96[0] = v95
                        del v95, v96
                        match v94:
                            case US6_0(): # Jack
                                pass
                            case US6_1(): # King
                                pass
                            case US6_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v94
                        v83 += 1 
                    del v80, v83
                    v97 = v57[12:].view(cp.int32)
                    v97[0] = v81
                    del v81, v97
                    v98 = v57[16:].view(cp.int32)
                    v98[0] = v82
                    del v82, v98
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v57, v64
            v52 += 1 
        del v7, v51, v52
        v99 = v8.tag
        v100 = v3[1056:].view(cp.int32)
        v100[0] = v99
        del v99, v100
        match v8:
            case US3_0(): # None
                pass
            case US3_1(v101): # Some
                v102 = v101.tag
                v103 = v3[1060:].view(cp.int32)
                v103[0] = v102
                del v102, v103
                match v101:
                    case US4_0(v104, v105, v106, v107, v108, v109): # ChanceCommunityCard
                        del v101
                        v110 = v104.tag
                        v111 = v3[1064:].view(cp.int32)
                        v111[0] = v110
                        del v110, v111
                        match v104:
                            case US5_0(): # None
                                pass
                            case US5_1(v112): # Some
                                v113 = v112.tag
                                v114 = v3[1068:].view(cp.int32)
                                v114[0] = v113
                                del v113, v114
                                match v112:
                                    case US6_0(): # Jack
                                        del v112
                                    case US6_1(): # King
                                        del v112
                                    case US6_2(): # Queen
                                        del v112
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v104
                        v115 = v3[1072:].view(cp.bool_)
                        v115[0] = v105
                        del v105, v115
                        v116 = 0
                        while method12(v116):
                            v118 = u64(v116)
                            v119 = v118 * 4
                            del v118
                            v120 = 1076 + v119
                            del v119
                            v121 = v3[v120:].view(cp.uint8)
                            del v120
                            v122 = 0 <= v116
                            if v122:
                                v123 = v116 < 2
                                v124 = v123
                            else:
                                v124 = False
                            del v122
                            v125 = v124 == False
                            if v125:
                                v126 = "The read index needs to be in range for the static array."
                                assert v124, v126
                                del v126
                            else:
                                pass
                            del v124, v125
                            v127 = v106[v116]
                            v128 = v127.tag
                            v129 = v121[0:].view(cp.int32)
                            del v121
                            v129[0] = v128
                            del v128, v129
                            match v127:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v127
                            v116 += 1 
                        del v106, v116
                        v130 = v3[1084:].view(cp.int32)
                        v130[0] = v107
                        del v107, v130
                        v131 = 0
                        while method12(v131):
                            v133 = u64(v131)
                            v134 = v133 * 4
                            del v133
                            v135 = 1088 + v134
                            del v134
                            v136 = v3[v135:].view(cp.uint8)
                            del v135
                            v137 = 0 <= v131
                            if v137:
                                v138 = v131 < 2
                                v139 = v138
                            else:
                                v139 = False
                            del v137
                            v140 = v139 == False
                            if v140:
                                v141 = "The read index needs to be in range for the static array."
                                assert v139, v141
                                del v141
                            else:
                                pass
                            del v139, v140
                            v142 = v108[v131]
                            v143 = v136[0:].view(cp.int32)
                            del v136
                            v143[0] = v142
                            del v142, v143
                            v131 += 1 
                        del v108, v131
                        v144 = v3[1096:].view(cp.int32)
                        v144[0] = v109
                        del v109, v144
                    case US4_1(): # ChanceInit
                        del v101
                    case US4_2(v145, v146, v147, v148, v149, v150): # Round
                        del v101
                        v151 = v145.tag
                        v152 = v3[1064:].view(cp.int32)
                        v152[0] = v151
                        del v151, v152
                        match v145:
                            case US5_0(): # None
                                pass
                            case US5_1(v153): # Some
                                v154 = v153.tag
                                v155 = v3[1068:].view(cp.int32)
                                v155[0] = v154
                                del v154, v155
                                match v153:
                                    case US6_0(): # Jack
                                        del v153
                                    case US6_1(): # King
                                        del v153
                                    case US6_2(): # Queen
                                        del v153
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v145
                        v156 = v3[1072:].view(cp.bool_)
                        v156[0] = v146
                        del v146, v156
                        v157 = 0
                        while method12(v157):
                            v159 = u64(v157)
                            v160 = v159 * 4
                            del v159
                            v161 = 1076 + v160
                            del v160
                            v162 = v3[v161:].view(cp.uint8)
                            del v161
                            v163 = 0 <= v157
                            if v163:
                                v164 = v157 < 2
                                v165 = v164
                            else:
                                v165 = False
                            del v163
                            v166 = v165 == False
                            if v166:
                                v167 = "The read index needs to be in range for the static array."
                                assert v165, v167
                                del v167
                            else:
                                pass
                            del v165, v166
                            v168 = v147[v157]
                            v169 = v168.tag
                            v170 = v162[0:].view(cp.int32)
                            del v162
                            v170[0] = v169
                            del v169, v170
                            match v168:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v168
                            v157 += 1 
                        del v147, v157
                        v171 = v3[1084:].view(cp.int32)
                        v171[0] = v148
                        del v148, v171
                        v172 = 0
                        while method12(v172):
                            v174 = u64(v172)
                            v175 = v174 * 4
                            del v174
                            v176 = 1088 + v175
                            del v175
                            v177 = v3[v176:].view(cp.uint8)
                            del v176
                            v178 = 0 <= v172
                            if v178:
                                v179 = v172 < 2
                                v180 = v179
                            else:
                                v180 = False
                            del v178
                            v181 = v180 == False
                            if v181:
                                v182 = "The read index needs to be in range for the static array."
                                assert v180, v182
                                del v182
                            else:
                                pass
                            del v180, v181
                            v183 = v149[v172]
                            v184 = v177[0:].view(cp.int32)
                            del v177
                            v184[0] = v183
                            del v183, v184
                            v172 += 1 
                        del v149, v172
                        v185 = v3[1096:].view(cp.int32)
                        v185[0] = v150
                        del v150, v185
                    case US4_3(v186, v187, v188, v189, v190, v191, v192): # RoundWithAction
                        del v101
                        v193 = v186.tag
                        v194 = v3[1064:].view(cp.int32)
                        v194[0] = v193
                        del v193, v194
                        match v186:
                            case US5_0(): # None
                                pass
                            case US5_1(v195): # Some
                                v196 = v195.tag
                                v197 = v3[1068:].view(cp.int32)
                                v197[0] = v196
                                del v196, v197
                                match v195:
                                    case US6_0(): # Jack
                                        del v195
                                    case US6_1(): # King
                                        del v195
                                    case US6_2(): # Queen
                                        del v195
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v186
                        v198 = v3[1072:].view(cp.bool_)
                        v198[0] = v187
                        del v187, v198
                        v199 = 0
                        while method12(v199):
                            v201 = u64(v199)
                            v202 = v201 * 4
                            del v201
                            v203 = 1076 + v202
                            del v202
                            v204 = v3[v203:].view(cp.uint8)
                            del v203
                            v205 = 0 <= v199
                            if v205:
                                v206 = v199 < 2
                                v207 = v206
                            else:
                                v207 = False
                            del v205
                            v208 = v207 == False
                            if v208:
                                v209 = "The read index needs to be in range for the static array."
                                assert v207, v209
                                del v209
                            else:
                                pass
                            del v207, v208
                            v210 = v188[v199]
                            v211 = v210.tag
                            v212 = v204[0:].view(cp.int32)
                            del v204
                            v212[0] = v211
                            del v211, v212
                            match v210:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v210
                            v199 += 1 
                        del v188, v199
                        v213 = v3[1084:].view(cp.int32)
                        v213[0] = v189
                        del v189, v213
                        v214 = 0
                        while method12(v214):
                            v216 = u64(v214)
                            v217 = v216 * 4
                            del v216
                            v218 = 1088 + v217
                            del v217
                            v219 = v3[v218:].view(cp.uint8)
                            del v218
                            v220 = 0 <= v214
                            if v220:
                                v221 = v214 < 2
                                v222 = v221
                            else:
                                v222 = False
                            del v220
                            v223 = v222 == False
                            if v223:
                                v224 = "The read index needs to be in range for the static array."
                                assert v222, v224
                                del v224
                            else:
                                pass
                            del v222, v223
                            v225 = v190[v214]
                            v226 = v219[0:].view(cp.int32)
                            del v219
                            v226[0] = v225
                            del v225, v226
                            v214 += 1 
                        del v190, v214
                        v227 = v3[1096:].view(cp.int32)
                        v227[0] = v191
                        del v191, v227
                        v228 = v192.tag
                        v229 = v3[1100:].view(cp.int32)
                        v229[0] = v228
                        del v228, v229
                        match v192:
                            case US1_0(): # Call
                                del v192
                            case US1_1(): # Fold
                                del v192
                            case US1_2(): # Raise
                                del v192
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case US4_4(v230, v231, v232, v233, v234, v235): # TerminalCall
                        del v101
                        v236 = v230.tag
                        v237 = v3[1064:].view(cp.int32)
                        v237[0] = v236
                        del v236, v237
                        match v230:
                            case US5_0(): # None
                                pass
                            case US5_1(v238): # Some
                                v239 = v238.tag
                                v240 = v3[1068:].view(cp.int32)
                                v240[0] = v239
                                del v239, v240
                                match v238:
                                    case US6_0(): # Jack
                                        del v238
                                    case US6_1(): # King
                                        del v238
                                    case US6_2(): # Queen
                                        del v238
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v230
                        v241 = v3[1072:].view(cp.bool_)
                        v241[0] = v231
                        del v231, v241
                        v242 = 0
                        while method12(v242):
                            v244 = u64(v242)
                            v245 = v244 * 4
                            del v244
                            v246 = 1076 + v245
                            del v245
                            v247 = v3[v246:].view(cp.uint8)
                            del v246
                            v248 = 0 <= v242
                            if v248:
                                v249 = v242 < 2
                                v250 = v249
                            else:
                                v250 = False
                            del v248
                            v251 = v250 == False
                            if v251:
                                v252 = "The read index needs to be in range for the static array."
                                assert v250, v252
                                del v252
                            else:
                                pass
                            del v250, v251
                            v253 = v232[v242]
                            v254 = v253.tag
                            v255 = v247[0:].view(cp.int32)
                            del v247
                            v255[0] = v254
                            del v254, v255
                            match v253:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v253
                            v242 += 1 
                        del v232, v242
                        v256 = v3[1084:].view(cp.int32)
                        v256[0] = v233
                        del v233, v256
                        v257 = 0
                        while method12(v257):
                            v259 = u64(v257)
                            v260 = v259 * 4
                            del v259
                            v261 = 1088 + v260
                            del v260
                            v262 = v3[v261:].view(cp.uint8)
                            del v261
                            v263 = 0 <= v257
                            if v263:
                                v264 = v257 < 2
                                v265 = v264
                            else:
                                v265 = False
                            del v263
                            v266 = v265 == False
                            if v266:
                                v267 = "The read index needs to be in range for the static array."
                                assert v265, v267
                                del v267
                            else:
                                pass
                            del v265, v266
                            v268 = v234[v257]
                            v269 = v262[0:].view(cp.int32)
                            del v262
                            v269[0] = v268
                            del v268, v269
                            v257 += 1 
                        del v234, v257
                        v270 = v3[1096:].view(cp.int32)
                        v270[0] = v235
                        del v235, v270
                    case US4_5(v271, v272, v273, v274, v275, v276): # TerminalFold
                        del v101
                        v277 = v271.tag
                        v278 = v3[1064:].view(cp.int32)
                        v278[0] = v277
                        del v277, v278
                        match v271:
                            case US5_0(): # None
                                pass
                            case US5_1(v279): # Some
                                v280 = v279.tag
                                v281 = v3[1068:].view(cp.int32)
                                v281[0] = v280
                                del v280, v281
                                match v279:
                                    case US6_0(): # Jack
                                        del v279
                                    case US6_1(): # King
                                        del v279
                                    case US6_2(): # Queen
                                        del v279
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v271
                        v282 = v3[1072:].view(cp.bool_)
                        v282[0] = v272
                        del v272, v282
                        v283 = 0
                        while method12(v283):
                            v285 = u64(v283)
                            v286 = v285 * 4
                            del v285
                            v287 = 1076 + v286
                            del v286
                            v288 = v3[v287:].view(cp.uint8)
                            del v287
                            v289 = 0 <= v283
                            if v289:
                                v290 = v283 < 2
                                v291 = v290
                            else:
                                v291 = False
                            del v289
                            v292 = v291 == False
                            if v292:
                                v293 = "The read index needs to be in range for the static array."
                                assert v291, v293
                                del v293
                            else:
                                pass
                            del v291, v292
                            v294 = v273[v283]
                            v295 = v294.tag
                            v296 = v288[0:].view(cp.int32)
                            del v288
                            v296[0] = v295
                            del v295, v296
                            match v294:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v294
                            v283 += 1 
                        del v273, v283
                        v297 = v3[1084:].view(cp.int32)
                        v297[0] = v274
                        del v274, v297
                        v298 = 0
                        while method12(v298):
                            v300 = u64(v298)
                            v301 = v300 * 4
                            del v300
                            v302 = 1088 + v301
                            del v301
                            v303 = v3[v302:].view(cp.uint8)
                            del v302
                            v304 = 0 <= v298
                            if v304:
                                v305 = v298 < 2
                                v306 = v305
                            else:
                                v306 = False
                            del v304
                            v307 = v306 == False
                            if v307:
                                v308 = "The read index needs to be in range for the static array."
                                assert v306, v308
                                del v308
                            else:
                                pass
                            del v306, v307
                            v309 = v275[v298]
                            v310 = v303[0:].view(cp.int32)
                            del v303
                            v310[0] = v309
                            del v309, v310
                            v298 += 1 
                        del v275, v298
                        v311 = v3[1096:].view(cp.int32)
                        v311[0] = v276
                        del v276, v311
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v8
        v312 = 0
        while method12(v312):
            v314 = u64(v312)
            v315 = v314 * 4
            del v314
            v316 = 1104 + v315
            del v315
            v317 = v3[v316:].view(cp.uint8)
            del v316
            v318 = 0 <= v312
            if v318:
                v319 = v312 < 2
                v320 = v319
            else:
                v320 = False
            del v318
            v321 = v320 == False
            if v321:
                v322 = "The read index needs to be in range for the static array."
                assert v320, v322
                del v322
            else:
                pass
            del v320, v321
            v323 = v9[v312]
            v324 = v323.tag
            v325 = v317[0:].view(cp.int32)
            del v317
            v325[0] = v324
            del v324, v325
            match v323:
                case US2_0(): # Computer
                    pass
                case US2_1(): # Human
                    pass
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v323
            v312 += 1 
        del v9, v312
        v326 = v10.tag
        v327 = v3[1112:].view(cp.int32)
        v327[0] = v326
        del v326, v327
        match v10:
            case US7_0(): # GameNotStarted
                pass
            case US7_1(v328, v329, v330, v331, v332, v333): # GameOver
                v334 = v328.tag
                v335 = v3[1116:].view(cp.int32)
                v335[0] = v334
                del v334, v335
                match v328:
                    case US5_0(): # None
                        pass
                    case US5_1(v336): # Some
                        v337 = v336.tag
                        v338 = v3[1120:].view(cp.int32)
                        v338[0] = v337
                        del v337, v338
                        match v336:
                            case US6_0(): # Jack
                                del v336
                            case US6_1(): # King
                                del v336
                            case US6_2(): # Queen
                                del v336
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v328
                v339 = v3[1124:].view(cp.bool_)
                v339[0] = v329
                del v329, v339
                v340 = 0
                while method12(v340):
                    v342 = u64(v340)
                    v343 = v342 * 4
                    del v342
                    v344 = 1128 + v343
                    del v343
                    v345 = v3[v344:].view(cp.uint8)
                    del v344
                    v346 = 0 <= v340
                    if v346:
                        v347 = v340 < 2
                        v348 = v347
                    else:
                        v348 = False
                    del v346
                    v349 = v348 == False
                    if v349:
                        v350 = "The read index needs to be in range for the static array."
                        assert v348, v350
                        del v350
                    else:
                        pass
                    del v348, v349
                    v351 = v330[v340]
                    v352 = v351.tag
                    v353 = v345[0:].view(cp.int32)
                    del v345
                    v353[0] = v352
                    del v352, v353
                    match v351:
                        case US6_0(): # Jack
                            pass
                        case US6_1(): # King
                            pass
                        case US6_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v351
                    v340 += 1 
                del v330, v340
                v354 = v3[1136:].view(cp.int32)
                v354[0] = v331
                del v331, v354
                v355 = 0
                while method12(v355):
                    v357 = u64(v355)
                    v358 = v357 * 4
                    del v357
                    v359 = 1140 + v358
                    del v358
                    v360 = v3[v359:].view(cp.uint8)
                    del v359
                    v361 = 0 <= v355
                    if v361:
                        v362 = v355 < 2
                        v363 = v362
                    else:
                        v363 = False
                    del v361
                    v364 = v363 == False
                    if v364:
                        v365 = "The read index needs to be in range for the static array."
                        assert v363, v365
                        del v365
                    else:
                        pass
                    del v363, v364
                    v366 = v332[v355]
                    v367 = v360[0:].view(cp.int32)
                    del v360
                    v367[0] = v366
                    del v366, v367
                    v355 += 1 
                del v332, v355
                v368 = v3[1148:].view(cp.int32)
                v368[0] = v333
                del v333, v368
            case US7_2(v369, v370, v371, v372, v373, v374): # WaitingForActionFromPlayerId
                v375 = v369.tag
                v376 = v3[1116:].view(cp.int32)
                v376[0] = v375
                del v375, v376
                match v369:
                    case US5_0(): # None
                        pass
                    case US5_1(v377): # Some
                        v378 = v377.tag
                        v379 = v3[1120:].view(cp.int32)
                        v379[0] = v378
                        del v378, v379
                        match v377:
                            case US6_0(): # Jack
                                del v377
                            case US6_1(): # King
                                del v377
                            case US6_2(): # Queen
                                del v377
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v369
                v380 = v3[1124:].view(cp.bool_)
                v380[0] = v370
                del v370, v380
                v381 = 0
                while method12(v381):
                    v383 = u64(v381)
                    v384 = v383 * 4
                    del v383
                    v385 = 1128 + v384
                    del v384
                    v386 = v3[v385:].view(cp.uint8)
                    del v385
                    v387 = 0 <= v381
                    if v387:
                        v388 = v381 < 2
                        v389 = v388
                    else:
                        v389 = False
                    del v387
                    v390 = v389 == False
                    if v390:
                        v391 = "The read index needs to be in range for the static array."
                        assert v389, v391
                        del v391
                    else:
                        pass
                    del v389, v390
                    v392 = v371[v381]
                    v393 = v392.tag
                    v394 = v386[0:].view(cp.int32)
                    del v386
                    v394[0] = v393
                    del v393, v394
                    match v392:
                        case US6_0(): # Jack
                            pass
                        case US6_1(): # King
                            pass
                        case US6_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v392
                    v381 += 1 
                del v371, v381
                v395 = v3[1136:].view(cp.int32)
                v395[0] = v372
                del v372, v395
                v396 = 0
                while method12(v396):
                    v398 = u64(v396)
                    v399 = v398 * 4
                    del v398
                    v400 = 1140 + v399
                    del v399
                    v401 = v3[v400:].view(cp.uint8)
                    del v400
                    v402 = 0 <= v396
                    if v402:
                        v403 = v396 < 2
                        v404 = v403
                    else:
                        v404 = False
                    del v402
                    v405 = v404 == False
                    if v405:
                        v406 = "The read index needs to be in range for the static array."
                        assert v404, v406
                        del v406
                    else:
                        pass
                    del v404, v405
                    v407 = v373[v396]
                    v408 = v401[0:].view(cp.int32)
                    del v401
                    v408[0] = v407
                    del v407, v408
                    v396 += 1 
                del v373, v396
                v409 = v3[1148:].view(cp.int32)
                v409[0] = v374
                del v374, v409
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v10
        v410 = 0
        v411 = raw_module.get_function(f"entry{v410}")
        del v410
        v411.max_dynamic_shared_size_bytes = 0 
        v411((1,),(512,),(v3, v2, v4),shared_mem=0)
        del v2, v411
        v412 = static_array_list(6)
        v413 = v3[0:].view(cp.int32)
        v414 = v413[0].item()
        del v413
        v412.length = v414
        del v414
        v415 = v412.length
        v416 = 0
        while method3(v415, v416):
            v418 = u64(v416)
            v419 = v418 * 4
            del v418
            v420 = 4 + v419
            del v419
            v421 = v3[v420:].view(cp.uint8)
            del v420
            v422 = v421[0:].view(cp.int32)
            del v421
            v423 = v422[0].item()
            del v422
            if v423 == 0:
                v428 = US6_0()
            elif v423 == 1:
                v428 = US6_1()
            elif v423 == 2:
                v428 = US6_2()
            else:
                raise Exception("Invalid tag.")
            del v423
            v429 = 0 <= v416
            if v429:
                v430 = v412.length
                v431 = v416 < v430
                del v430
                v432 = v431
            else:
                v432 = False
            del v429
            v433 = v432 == False
            if v433:
                v434 = "The set index needs to be in range for the static array list."
                assert v432, v434
                del v434
            else:
                pass
            del v432, v433
            v412[v416] = v428
            del v428
            v416 += 1 
        del v415, v416
        v435 = static_array_list(32)
        v436 = v3[28:].view(cp.int32)
        v437 = v436[0].item()
        del v436
        v435.length = v437
        del v437
        v438 = v435.length
        v439 = 0
        while method3(v438, v439):
            v441 = u64(v439)
            v442 = v441 * 32
            del v441
            v443 = 32 + v442
            del v442
            v444 = v3[v443:].view(cp.uint8)
            del v443
            v445 = v444[0:].view(cp.int32)
            v446 = v445[0].item()
            del v445
            if v446 == 0:
                v448 = v444[4:].view(cp.int32)
                v449 = v448[0].item()
                del v448
                if v449 == 0:
                    v454 = US6_0()
                elif v449 == 1:
                    v454 = US6_1()
                elif v449 == 2:
                    v454 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v449
                v500 = US8_0(v454)
            elif v446 == 1:
                v456 = v444[4:].view(cp.int32)
                v457 = v456[0].item()
                del v456
                v458 = v444[8:].view(cp.int32)
                v459 = v458[0].item()
                del v458
                if v459 == 0:
                    v464 = US1_0()
                elif v459 == 1:
                    v464 = US1_1()
                elif v459 == 2:
                    v464 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v459
                v500 = US8_1(v457, v464)
            elif v446 == 2:
                v466 = v444[4:].view(cp.int32)
                v467 = v466[0].item()
                del v466
                v468 = v444[8:].view(cp.int32)
                v469 = v468[0].item()
                del v468
                if v469 == 0:
                    v474 = US6_0()
                elif v469 == 1:
                    v474 = US6_1()
                elif v469 == 2:
                    v474 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v469
                v500 = US8_2(v467, v474)
            elif v446 == 3:
                v476 = static_array(2)
                v477 = 0
                while method12(v477):
                    v479 = u64(v477)
                    v480 = v479 * 4
                    del v479
                    v481 = 4 + v480
                    del v480
                    v482 = v444[v481:].view(cp.uint8)
                    del v481
                    v483 = v482[0:].view(cp.int32)
                    del v482
                    v484 = v483[0].item()
                    del v483
                    if v484 == 0:
                        v489 = US6_0()
                    elif v484 == 1:
                        v489 = US6_1()
                    elif v484 == 2:
                        v489 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v484
                    v490 = 0 <= v477
                    if v490:
                        v491 = v477 < 2
                        v492 = v491
                    else:
                        v492 = False
                    del v490
                    v493 = v492 == False
                    if v493:
                        v494 = "The read index needs to be in range for the static array."
                        assert v492, v494
                        del v494
                    else:
                        pass
                    del v492, v493
                    v476[v477] = v489
                    del v489
                    v477 += 1 
                del v477
                v495 = v444[12:].view(cp.int32)
                v496 = v495[0].item()
                del v495
                v497 = v444[16:].view(cp.int32)
                v498 = v497[0].item()
                del v497
                v500 = US8_3(v476, v496, v498)
            else:
                raise Exception("Invalid tag.")
            del v444, v446
            v501 = 0 <= v439
            if v501:
                v502 = v435.length
                v503 = v439 < v502
                del v502
                v504 = v503
            else:
                v504 = False
            del v501
            v505 = v504 == False
            if v505:
                v506 = "The set index needs to be in range for the static array list."
                assert v504, v506
                del v506
            else:
                pass
            del v504, v505
            v435[v439] = v500
            del v500
            v439 += 1 
        del v438, v439
        v507 = v3[1056:].view(cp.int32)
        v508 = v507[0].item()
        del v507
        if v508 == 0:
            v789 = US3_0()
        elif v508 == 1:
            v511 = v3[1060:].view(cp.int32)
            v512 = v511[0].item()
            del v511
            if v512 == 0:
                v514 = v3[1064:].view(cp.int32)
                v515 = v514[0].item()
                del v514
                if v515 == 0:
                    v526 = US5_0()
                elif v515 == 1:
                    v518 = v3[1068:].view(cp.int32)
                    v519 = v518[0].item()
                    del v518
                    if v519 == 0:
                        v524 = US6_0()
                    elif v519 == 1:
                        v524 = US6_1()
                    elif v519 == 2:
                        v524 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v519
                    v526 = US5_1(v524)
                else:
                    raise Exception("Invalid tag.")
                del v515
                v527 = v3[1072:].view(cp.bool_)
                v528 = v527[0].item()
                del v527
                v529 = static_array(2)
                v530 = 0
                while method12(v530):
                    v532 = u64(v530)
                    v533 = v532 * 4
                    del v532
                    v534 = 1076 + v533
                    del v533
                    v535 = v3[v534:].view(cp.uint8)
                    del v534
                    v536 = v535[0:].view(cp.int32)
                    del v535
                    v537 = v536[0].item()
                    del v536
                    if v537 == 0:
                        v542 = US6_0()
                    elif v537 == 1:
                        v542 = US6_1()
                    elif v537 == 2:
                        v542 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v537
                    v543 = 0 <= v530
                    if v543:
                        v544 = v530 < 2
                        v545 = v544
                    else:
                        v545 = False
                    del v543
                    v546 = v545 == False
                    if v546:
                        v547 = "The read index needs to be in range for the static array."
                        assert v545, v547
                        del v547
                    else:
                        pass
                    del v545, v546
                    v529[v530] = v542
                    del v542
                    v530 += 1 
                del v530
                v548 = v3[1084:].view(cp.int32)
                v549 = v548[0].item()
                del v548
                v550 = static_array(2)
                v551 = 0
                while method12(v551):
                    v553 = u64(v551)
                    v554 = v553 * 4
                    del v553
                    v555 = 1088 + v554
                    del v554
                    v556 = v3[v555:].view(cp.uint8)
                    del v555
                    v557 = v556[0:].view(cp.int32)
                    del v556
                    v558 = v557[0].item()
                    del v557
                    v559 = 0 <= v551
                    if v559:
                        v560 = v551 < 2
                        v561 = v560
                    else:
                        v561 = False
                    del v559
                    v562 = v561 == False
                    if v562:
                        v563 = "The read index needs to be in range for the static array."
                        assert v561, v563
                        del v563
                    else:
                        pass
                    del v561, v562
                    v550[v551] = v558
                    del v558
                    v551 += 1 
                del v551
                v564 = v3[1096:].view(cp.int32)
                v565 = v564[0].item()
                del v564
                v787 = US4_0(v526, v528, v529, v549, v550, v565)
            elif v512 == 1:
                v787 = US4_1()
            elif v512 == 2:
                v568 = v3[1064:].view(cp.int32)
                v569 = v568[0].item()
                del v568
                if v569 == 0:
                    v580 = US5_0()
                elif v569 == 1:
                    v572 = v3[1068:].view(cp.int32)
                    v573 = v572[0].item()
                    del v572
                    if v573 == 0:
                        v578 = US6_0()
                    elif v573 == 1:
                        v578 = US6_1()
                    elif v573 == 2:
                        v578 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v573
                    v580 = US5_1(v578)
                else:
                    raise Exception("Invalid tag.")
                del v569
                v581 = v3[1072:].view(cp.bool_)
                v582 = v581[0].item()
                del v581
                v583 = static_array(2)
                v584 = 0
                while method12(v584):
                    v586 = u64(v584)
                    v587 = v586 * 4
                    del v586
                    v588 = 1076 + v587
                    del v587
                    v589 = v3[v588:].view(cp.uint8)
                    del v588
                    v590 = v589[0:].view(cp.int32)
                    del v589
                    v591 = v590[0].item()
                    del v590
                    if v591 == 0:
                        v596 = US6_0()
                    elif v591 == 1:
                        v596 = US6_1()
                    elif v591 == 2:
                        v596 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v591
                    v597 = 0 <= v584
                    if v597:
                        v598 = v584 < 2
                        v599 = v598
                    else:
                        v599 = False
                    del v597
                    v600 = v599 == False
                    if v600:
                        v601 = "The read index needs to be in range for the static array."
                        assert v599, v601
                        del v601
                    else:
                        pass
                    del v599, v600
                    v583[v584] = v596
                    del v596
                    v584 += 1 
                del v584
                v602 = v3[1084:].view(cp.int32)
                v603 = v602[0].item()
                del v602
                v604 = static_array(2)
                v605 = 0
                while method12(v605):
                    v607 = u64(v605)
                    v608 = v607 * 4
                    del v607
                    v609 = 1088 + v608
                    del v608
                    v610 = v3[v609:].view(cp.uint8)
                    del v609
                    v611 = v610[0:].view(cp.int32)
                    del v610
                    v612 = v611[0].item()
                    del v611
                    v613 = 0 <= v605
                    if v613:
                        v614 = v605 < 2
                        v615 = v614
                    else:
                        v615 = False
                    del v613
                    v616 = v615 == False
                    if v616:
                        v617 = "The read index needs to be in range for the static array."
                        assert v615, v617
                        del v617
                    else:
                        pass
                    del v615, v616
                    v604[v605] = v612
                    del v612
                    v605 += 1 
                del v605
                v618 = v3[1096:].view(cp.int32)
                v619 = v618[0].item()
                del v618
                v787 = US4_2(v580, v582, v583, v603, v604, v619)
            elif v512 == 3:
                v621 = v3[1064:].view(cp.int32)
                v622 = v621[0].item()
                del v621
                if v622 == 0:
                    v633 = US5_0()
                elif v622 == 1:
                    v625 = v3[1068:].view(cp.int32)
                    v626 = v625[0].item()
                    del v625
                    if v626 == 0:
                        v631 = US6_0()
                    elif v626 == 1:
                        v631 = US6_1()
                    elif v626 == 2:
                        v631 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v626
                    v633 = US5_1(v631)
                else:
                    raise Exception("Invalid tag.")
                del v622
                v634 = v3[1072:].view(cp.bool_)
                v635 = v634[0].item()
                del v634
                v636 = static_array(2)
                v637 = 0
                while method12(v637):
                    v639 = u64(v637)
                    v640 = v639 * 4
                    del v639
                    v641 = 1076 + v640
                    del v640
                    v642 = v3[v641:].view(cp.uint8)
                    del v641
                    v643 = v642[0:].view(cp.int32)
                    del v642
                    v644 = v643[0].item()
                    del v643
                    if v644 == 0:
                        v649 = US6_0()
                    elif v644 == 1:
                        v649 = US6_1()
                    elif v644 == 2:
                        v649 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v644
                    v650 = 0 <= v637
                    if v650:
                        v651 = v637 < 2
                        v652 = v651
                    else:
                        v652 = False
                    del v650
                    v653 = v652 == False
                    if v653:
                        v654 = "The read index needs to be in range for the static array."
                        assert v652, v654
                        del v654
                    else:
                        pass
                    del v652, v653
                    v636[v637] = v649
                    del v649
                    v637 += 1 
                del v637
                v655 = v3[1084:].view(cp.int32)
                v656 = v655[0].item()
                del v655
                v657 = static_array(2)
                v658 = 0
                while method12(v658):
                    v660 = u64(v658)
                    v661 = v660 * 4
                    del v660
                    v662 = 1088 + v661
                    del v661
                    v663 = v3[v662:].view(cp.uint8)
                    del v662
                    v664 = v663[0:].view(cp.int32)
                    del v663
                    v665 = v664[0].item()
                    del v664
                    v666 = 0 <= v658
                    if v666:
                        v667 = v658 < 2
                        v668 = v667
                    else:
                        v668 = False
                    del v666
                    v669 = v668 == False
                    if v669:
                        v670 = "The read index needs to be in range for the static array."
                        assert v668, v670
                        del v670
                    else:
                        pass
                    del v668, v669
                    v657[v658] = v665
                    del v665
                    v658 += 1 
                del v658
                v671 = v3[1096:].view(cp.int32)
                v672 = v671[0].item()
                del v671
                v673 = v3[1100:].view(cp.int32)
                v674 = v673[0].item()
                del v673
                if v674 == 0:
                    v679 = US1_0()
                elif v674 == 1:
                    v679 = US1_1()
                elif v674 == 2:
                    v679 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v674
                v787 = US4_3(v633, v635, v636, v656, v657, v672, v679)
            elif v512 == 4:
                v681 = v3[1064:].view(cp.int32)
                v682 = v681[0].item()
                del v681
                if v682 == 0:
                    v693 = US5_0()
                elif v682 == 1:
                    v685 = v3[1068:].view(cp.int32)
                    v686 = v685[0].item()
                    del v685
                    if v686 == 0:
                        v691 = US6_0()
                    elif v686 == 1:
                        v691 = US6_1()
                    elif v686 == 2:
                        v691 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v686
                    v693 = US5_1(v691)
                else:
                    raise Exception("Invalid tag.")
                del v682
                v694 = v3[1072:].view(cp.bool_)
                v695 = v694[0].item()
                del v694
                v696 = static_array(2)
                v697 = 0
                while method12(v697):
                    v699 = u64(v697)
                    v700 = v699 * 4
                    del v699
                    v701 = 1076 + v700
                    del v700
                    v702 = v3[v701:].view(cp.uint8)
                    del v701
                    v703 = v702[0:].view(cp.int32)
                    del v702
                    v704 = v703[0].item()
                    del v703
                    if v704 == 0:
                        v709 = US6_0()
                    elif v704 == 1:
                        v709 = US6_1()
                    elif v704 == 2:
                        v709 = US6_2()
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
                v715 = v3[1084:].view(cp.int32)
                v716 = v715[0].item()
                del v715
                v717 = static_array(2)
                v718 = 0
                while method12(v718):
                    v720 = u64(v718)
                    v721 = v720 * 4
                    del v720
                    v722 = 1088 + v721
                    del v721
                    v723 = v3[v722:].view(cp.uint8)
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
                v731 = v3[1096:].view(cp.int32)
                v732 = v731[0].item()
                del v731
                v787 = US4_4(v693, v695, v696, v716, v717, v732)
            elif v512 == 5:
                v734 = v3[1064:].view(cp.int32)
                v735 = v734[0].item()
                del v734
                if v735 == 0:
                    v746 = US5_0()
                elif v735 == 1:
                    v738 = v3[1068:].view(cp.int32)
                    v739 = v738[0].item()
                    del v738
                    if v739 == 0:
                        v744 = US6_0()
                    elif v739 == 1:
                        v744 = US6_1()
                    elif v739 == 2:
                        v744 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v739
                    v746 = US5_1(v744)
                else:
                    raise Exception("Invalid tag.")
                del v735
                v747 = v3[1072:].view(cp.bool_)
                v748 = v747[0].item()
                del v747
                v749 = static_array(2)
                v750 = 0
                while method12(v750):
                    v752 = u64(v750)
                    v753 = v752 * 4
                    del v752
                    v754 = 1076 + v753
                    del v753
                    v755 = v3[v754:].view(cp.uint8)
                    del v754
                    v756 = v755[0:].view(cp.int32)
                    del v755
                    v757 = v756[0].item()
                    del v756
                    if v757 == 0:
                        v762 = US6_0()
                    elif v757 == 1:
                        v762 = US6_1()
                    elif v757 == 2:
                        v762 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v757
                    v763 = 0 <= v750
                    if v763:
                        v764 = v750 < 2
                        v765 = v764
                    else:
                        v765 = False
                    del v763
                    v766 = v765 == False
                    if v766:
                        v767 = "The read index needs to be in range for the static array."
                        assert v765, v767
                        del v767
                    else:
                        pass
                    del v765, v766
                    v749[v750] = v762
                    del v762
                    v750 += 1 
                del v750
                v768 = v3[1084:].view(cp.int32)
                v769 = v768[0].item()
                del v768
                v770 = static_array(2)
                v771 = 0
                while method12(v771):
                    v773 = u64(v771)
                    v774 = v773 * 4
                    del v773
                    v775 = 1088 + v774
                    del v774
                    v776 = v3[v775:].view(cp.uint8)
                    del v775
                    v777 = v776[0:].view(cp.int32)
                    del v776
                    v778 = v777[0].item()
                    del v777
                    v779 = 0 <= v771
                    if v779:
                        v780 = v771 < 2
                        v781 = v780
                    else:
                        v781 = False
                    del v779
                    v782 = v781 == False
                    if v782:
                        v783 = "The read index needs to be in range for the static array."
                        assert v781, v783
                        del v783
                    else:
                        pass
                    del v781, v782
                    v770[v771] = v778
                    del v778
                    v771 += 1 
                del v771
                v784 = v3[1096:].view(cp.int32)
                v785 = v784[0].item()
                del v784
                v787 = US4_5(v746, v748, v749, v769, v770, v785)
            else:
                raise Exception("Invalid tag.")
            del v512
            v789 = US3_1(v787)
        else:
            raise Exception("Invalid tag.")
        del v508
        v790 = static_array(2)
        v791 = 0
        while method12(v791):
            v793 = u64(v791)
            v794 = v793 * 4
            del v793
            v795 = 1104 + v794
            del v794
            v796 = v3[v795:].view(cp.uint8)
            del v795
            v797 = v796[0:].view(cp.int32)
            del v796
            v798 = v797[0].item()
            del v797
            if v798 == 0:
                v802 = US2_0()
            elif v798 == 1:
                v802 = US2_1()
            else:
                raise Exception("Invalid tag.")
            del v798
            v803 = 0 <= v791
            if v803:
                v804 = v791 < 2
                v805 = v804
            else:
                v805 = False
            del v803
            v806 = v805 == False
            if v806:
                v807 = "The read index needs to be in range for the static array."
                assert v805, v807
                del v807
            else:
                pass
            del v805, v806
            v790[v791] = v802
            del v802
            v791 += 1 
        del v791
        v808 = v3[1112:].view(cp.int32)
        v809 = v808[0].item()
        del v808
        if v809 == 0:
            v918 = US7_0()
        elif v809 == 1:
            v812 = v3[1116:].view(cp.int32)
            v813 = v812[0].item()
            del v812
            if v813 == 0:
                v824 = US5_0()
            elif v813 == 1:
                v816 = v3[1120:].view(cp.int32)
                v817 = v816[0].item()
                del v816
                if v817 == 0:
                    v822 = US6_0()
                elif v817 == 1:
                    v822 = US6_1()
                elif v817 == 2:
                    v822 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v817
                v824 = US5_1(v822)
            else:
                raise Exception("Invalid tag.")
            del v813
            v825 = v3[1124:].view(cp.bool_)
            v826 = v825[0].item()
            del v825
            v827 = static_array(2)
            v828 = 0
            while method12(v828):
                v830 = u64(v828)
                v831 = v830 * 4
                del v830
                v832 = 1128 + v831
                del v831
                v833 = v3[v832:].view(cp.uint8)
                del v832
                v834 = v833[0:].view(cp.int32)
                del v833
                v835 = v834[0].item()
                del v834
                if v835 == 0:
                    v840 = US6_0()
                elif v835 == 1:
                    v840 = US6_1()
                elif v835 == 2:
                    v840 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v835
                v841 = 0 <= v828
                if v841:
                    v842 = v828 < 2
                    v843 = v842
                else:
                    v843 = False
                del v841
                v844 = v843 == False
                if v844:
                    v845 = "The read index needs to be in range for the static array."
                    assert v843, v845
                    del v845
                else:
                    pass
                del v843, v844
                v827[v828] = v840
                del v840
                v828 += 1 
            del v828
            v846 = v3[1136:].view(cp.int32)
            v847 = v846[0].item()
            del v846
            v848 = static_array(2)
            v849 = 0
            while method12(v849):
                v851 = u64(v849)
                v852 = v851 * 4
                del v851
                v853 = 1140 + v852
                del v852
                v854 = v3[v853:].view(cp.uint8)
                del v853
                v855 = v854[0:].view(cp.int32)
                del v854
                v856 = v855[0].item()
                del v855
                v857 = 0 <= v849
                if v857:
                    v858 = v849 < 2
                    v859 = v858
                else:
                    v859 = False
                del v857
                v860 = v859 == False
                if v860:
                    v861 = "The read index needs to be in range for the static array."
                    assert v859, v861
                    del v861
                else:
                    pass
                del v859, v860
                v848[v849] = v856
                del v856
                v849 += 1 
            del v849
            v862 = v3[1148:].view(cp.int32)
            v863 = v862[0].item()
            del v862
            v918 = US7_1(v824, v826, v827, v847, v848, v863)
        elif v809 == 2:
            v865 = v3[1116:].view(cp.int32)
            v866 = v865[0].item()
            del v865
            if v866 == 0:
                v877 = US5_0()
            elif v866 == 1:
                v869 = v3[1120:].view(cp.int32)
                v870 = v869[0].item()
                del v869
                if v870 == 0:
                    v875 = US6_0()
                elif v870 == 1:
                    v875 = US6_1()
                elif v870 == 2:
                    v875 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v870
                v877 = US5_1(v875)
            else:
                raise Exception("Invalid tag.")
            del v866
            v878 = v3[1124:].view(cp.bool_)
            v879 = v878[0].item()
            del v878
            v880 = static_array(2)
            v881 = 0
            while method12(v881):
                v883 = u64(v881)
                v884 = v883 * 4
                del v883
                v885 = 1128 + v884
                del v884
                v886 = v3[v885:].view(cp.uint8)
                del v885
                v887 = v886[0:].view(cp.int32)
                del v886
                v888 = v887[0].item()
                del v887
                if v888 == 0:
                    v893 = US6_0()
                elif v888 == 1:
                    v893 = US6_1()
                elif v888 == 2:
                    v893 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v888
                v894 = 0 <= v881
                if v894:
                    v895 = v881 < 2
                    v896 = v895
                else:
                    v896 = False
                del v894
                v897 = v896 == False
                if v897:
                    v898 = "The read index needs to be in range for the static array."
                    assert v896, v898
                    del v898
                else:
                    pass
                del v896, v897
                v880[v881] = v893
                del v893
                v881 += 1 
            del v881
            v899 = v3[1136:].view(cp.int32)
            v900 = v899[0].item()
            del v899
            v901 = static_array(2)
            v902 = 0
            while method12(v902):
                v904 = u64(v902)
                v905 = v904 * 4
                del v904
                v906 = 1140 + v905
                del v905
                v907 = v3[v906:].view(cp.uint8)
                del v906
                v908 = v907[0:].view(cp.int32)
                del v907
                v909 = v908[0].item()
                del v908
                v910 = 0 <= v902
                if v910:
                    v911 = v902 < 2
                    v912 = v911
                else:
                    v912 = False
                del v910
                v913 = v912 == False
                if v913:
                    v914 = "The read index needs to be in range for the static array."
                    assert v912, v914
                    del v914
                else:
                    pass
                del v912, v913
                v901[v902] = v909
                del v909
                v902 += 1 
            del v902
            v915 = v3[1148:].view(cp.int32)
            v916 = v915[0].item()
            del v915
            v918 = US7_2(v877, v879, v880, v900, v901, v916)
        else:
            raise Exception("Invalid tag.")
        del v3, v809
        v919 = static_array_list(32)
        v920 = v4[0:].view(cp.int32)
        v921 = v920[0].item()
        del v920
        v919.length = v921
        del v921
        v922 = v919.length
        v923 = 0
        while method3(v922, v923):
            v925 = u64(v923)
            v926 = v925 * 32
            del v925
            v927 = 16 + v926
            del v926
            v928 = v4[v927:].view(cp.uint8)
            del v927
            v929 = v928[0:].view(cp.int32)
            v930 = v929[0].item()
            del v929
            if v930 == 0:
                v932 = v928[4:].view(cp.int32)
                v933 = v932[0].item()
                del v932
                if v933 == 0:
                    v938 = US6_0()
                elif v933 == 1:
                    v938 = US6_1()
                elif v933 == 2:
                    v938 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v933
                v984 = US8_0(v938)
            elif v930 == 1:
                v940 = v928[4:].view(cp.int32)
                v941 = v940[0].item()
                del v940
                v942 = v928[8:].view(cp.int32)
                v943 = v942[0].item()
                del v942
                if v943 == 0:
                    v948 = US1_0()
                elif v943 == 1:
                    v948 = US1_1()
                elif v943 == 2:
                    v948 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v943
                v984 = US8_1(v941, v948)
            elif v930 == 2:
                v950 = v928[4:].view(cp.int32)
                v951 = v950[0].item()
                del v950
                v952 = v928[8:].view(cp.int32)
                v953 = v952[0].item()
                del v952
                if v953 == 0:
                    v958 = US6_0()
                elif v953 == 1:
                    v958 = US6_1()
                elif v953 == 2:
                    v958 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v953
                v984 = US8_2(v951, v958)
            elif v930 == 3:
                v960 = static_array(2)
                v961 = 0
                while method12(v961):
                    v963 = u64(v961)
                    v964 = v963 * 4
                    del v963
                    v965 = 4 + v964
                    del v964
                    v966 = v928[v965:].view(cp.uint8)
                    del v965
                    v967 = v966[0:].view(cp.int32)
                    del v966
                    v968 = v967[0].item()
                    del v967
                    if v968 == 0:
                        v973 = US6_0()
                    elif v968 == 1:
                        v973 = US6_1()
                    elif v968 == 2:
                        v973 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v968
                    v974 = 0 <= v961
                    if v974:
                        v975 = v961 < 2
                        v976 = v975
                    else:
                        v976 = False
                    del v974
                    v977 = v976 == False
                    if v977:
                        v978 = "The read index needs to be in range for the static array."
                        assert v976, v978
                        del v978
                    else:
                        pass
                    del v976, v977
                    v960[v961] = v973
                    del v973
                    v961 += 1 
                del v961
                v979 = v928[12:].view(cp.int32)
                v980 = v979[0].item()
                del v979
                v981 = v928[16:].view(cp.int32)
                v982 = v981[0].item()
                del v981
                v984 = US8_3(v960, v980, v982)
            else:
                raise Exception("Invalid tag.")
            del v928, v930
            v985 = 0 <= v923
            if v985:
                v986 = v919.length
                v987 = v923 < v986
                del v986
                v988 = v987
            else:
                v988 = False
            del v985
            v989 = v988 == False
            if v989:
                v990 = "The set index needs to be in range for the static array list."
                assert v988, v990
                del v990
            else:
                pass
            del v988, v989
            v919[v923] = v984
            del v984
            v923 += 1 
        del v922, v923
        v991 = static_array(2)
        v992 = 0
        while method12(v992):
            v994 = u64(v992)
            v995 = v994 * 4
            del v994
            v996 = 1040 + v995
            del v995
            v997 = v4[v996:].view(cp.uint8)
            del v996
            v998 = v997[0:].view(cp.int32)
            del v997
            v999 = v998[0].item()
            del v998
            if v999 == 0:
                v1003 = US2_0()
            elif v999 == 1:
                v1003 = US2_1()
            else:
                raise Exception("Invalid tag.")
            del v999
            v1004 = 0 <= v992
            if v1004:
                v1005 = v992 < 2
                v1006 = v1005
            else:
                v1006 = False
            del v1004
            v1007 = v1006 == False
            if v1007:
                v1008 = "The read index needs to be in range for the static array."
                assert v1006, v1008
                del v1008
            else:
                pass
            del v1006, v1007
            v991[v992] = v1003
            del v1003
            v992 += 1 
        del v992
        v1009 = v4[1048:].view(cp.int32)
        v1010 = v1009[0].item()
        del v1009
        if v1010 == 0:
            v1119 = US7_0()
        elif v1010 == 1:
            v1013 = v4[1052:].view(cp.int32)
            v1014 = v1013[0].item()
            del v1013
            if v1014 == 0:
                v1025 = US5_0()
            elif v1014 == 1:
                v1017 = v4[1056:].view(cp.int32)
                v1018 = v1017[0].item()
                del v1017
                if v1018 == 0:
                    v1023 = US6_0()
                elif v1018 == 1:
                    v1023 = US6_1()
                elif v1018 == 2:
                    v1023 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v1018
                v1025 = US5_1(v1023)
            else:
                raise Exception("Invalid tag.")
            del v1014
            v1026 = v4[1060:].view(cp.bool_)
            v1027 = v1026[0].item()
            del v1026
            v1028 = static_array(2)
            v1029 = 0
            while method12(v1029):
                v1031 = u64(v1029)
                v1032 = v1031 * 4
                del v1031
                v1033 = 1064 + v1032
                del v1032
                v1034 = v4[v1033:].view(cp.uint8)
                del v1033
                v1035 = v1034[0:].view(cp.int32)
                del v1034
                v1036 = v1035[0].item()
                del v1035
                if v1036 == 0:
                    v1041 = US6_0()
                elif v1036 == 1:
                    v1041 = US6_1()
                elif v1036 == 2:
                    v1041 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v1036
                v1042 = 0 <= v1029
                if v1042:
                    v1043 = v1029 < 2
                    v1044 = v1043
                else:
                    v1044 = False
                del v1042
                v1045 = v1044 == False
                if v1045:
                    v1046 = "The read index needs to be in range for the static array."
                    assert v1044, v1046
                    del v1046
                else:
                    pass
                del v1044, v1045
                v1028[v1029] = v1041
                del v1041
                v1029 += 1 
            del v1029
            v1047 = v4[1072:].view(cp.int32)
            v1048 = v1047[0].item()
            del v1047
            v1049 = static_array(2)
            v1050 = 0
            while method12(v1050):
                v1052 = u64(v1050)
                v1053 = v1052 * 4
                del v1052
                v1054 = 1076 + v1053
                del v1053
                v1055 = v4[v1054:].view(cp.uint8)
                del v1054
                v1056 = v1055[0:].view(cp.int32)
                del v1055
                v1057 = v1056[0].item()
                del v1056
                v1058 = 0 <= v1050
                if v1058:
                    v1059 = v1050 < 2
                    v1060 = v1059
                else:
                    v1060 = False
                del v1058
                v1061 = v1060 == False
                if v1061:
                    v1062 = "The read index needs to be in range for the static array."
                    assert v1060, v1062
                    del v1062
                else:
                    pass
                del v1060, v1061
                v1049[v1050] = v1057
                del v1057
                v1050 += 1 
            del v1050
            v1063 = v4[1084:].view(cp.int32)
            v1064 = v1063[0].item()
            del v1063
            v1119 = US7_1(v1025, v1027, v1028, v1048, v1049, v1064)
        elif v1010 == 2:
            v1066 = v4[1052:].view(cp.int32)
            v1067 = v1066[0].item()
            del v1066
            if v1067 == 0:
                v1078 = US5_0()
            elif v1067 == 1:
                v1070 = v4[1056:].view(cp.int32)
                v1071 = v1070[0].item()
                del v1070
                if v1071 == 0:
                    v1076 = US6_0()
                elif v1071 == 1:
                    v1076 = US6_1()
                elif v1071 == 2:
                    v1076 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v1071
                v1078 = US5_1(v1076)
            else:
                raise Exception("Invalid tag.")
            del v1067
            v1079 = v4[1060:].view(cp.bool_)
            v1080 = v1079[0].item()
            del v1079
            v1081 = static_array(2)
            v1082 = 0
            while method12(v1082):
                v1084 = u64(v1082)
                v1085 = v1084 * 4
                del v1084
                v1086 = 1064 + v1085
                del v1085
                v1087 = v4[v1086:].view(cp.uint8)
                del v1086
                v1088 = v1087[0:].view(cp.int32)
                del v1087
                v1089 = v1088[0].item()
                del v1088
                if v1089 == 0:
                    v1094 = US6_0()
                elif v1089 == 1:
                    v1094 = US6_1()
                elif v1089 == 2:
                    v1094 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v1089
                v1095 = 0 <= v1082
                if v1095:
                    v1096 = v1082 < 2
                    v1097 = v1096
                else:
                    v1097 = False
                del v1095
                v1098 = v1097 == False
                if v1098:
                    v1099 = "The read index needs to be in range for the static array."
                    assert v1097, v1099
                    del v1099
                else:
                    pass
                del v1097, v1098
                v1081[v1082] = v1094
                del v1094
                v1082 += 1 
            del v1082
            v1100 = v4[1072:].view(cp.int32)
            v1101 = v1100[0].item()
            del v1100
            v1102 = static_array(2)
            v1103 = 0
            while method12(v1103):
                v1105 = u64(v1103)
                v1106 = v1105 * 4
                del v1105
                v1107 = 1076 + v1106
                del v1106
                v1108 = v4[v1107:].view(cp.uint8)
                del v1107
                v1109 = v1108[0:].view(cp.int32)
                del v1108
                v1110 = v1109[0].item()
                del v1109
                v1111 = 0 <= v1103
                if v1111:
                    v1112 = v1103 < 2
                    v1113 = v1112
                else:
                    v1113 = False
                del v1111
                v1114 = v1113 == False
                if v1114:
                    v1115 = "The read index needs to be in range for the static array."
                    assert v1113, v1115
                    del v1115
                else:
                    pass
                del v1113, v1114
                v1102[v1103] = v1110
                del v1110
                v1103 += 1 
            del v1103
            v1116 = v4[1084:].view(cp.int32)
            v1117 = v1116[0].item()
            del v1116
            v1119 = US7_2(v1078, v1080, v1081, v1101, v1102, v1117)
        else:
            raise Exception("Invalid tag.")
        del v4, v1010
        return method13(v412, v435, v789, v790, v918, v919, v991, v1119)
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
        while method3(v35, v36):
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
        return method22(v3, v64, v65, v0, v66)
    return inner
def method2(v0 : object) -> US1:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Call" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US1_0()
    else:
        del v4
        v7 = "Fold" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US1_1()
        else:
            del v7
            v10 = "Raise" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US1_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method3(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method4(v0 : object) -> US2:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
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
            assert isinstance(v2,list), f'The object needs to be a Python list. Got: {v2}'
            v9 = len(v2)
            v10 = 2 == v9
            v11 = v10 == False
            if v11:
                v12 = "The type level dimension has to equal the value passed at runtime into create."
                assert v10, v12
                del v12
            else:
                pass
            del v10, v11
            v13 = static_array(2)
            v14 = 0
            while method3(v9, v14):
                v16 = v2[v14]
                v17 = method4(v16)
                del v16
                v18 = 0 <= v14
                if v18:
                    v19 = v14 < 2
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
                v13[v14] = v17
                del v17
                v14 += 1 
            del v2, v9, v14
            return US0_1(v13)
        else:
            del v8
            v25 = "StartGame" == v1
            if v25:
                del v1, v25
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US0_2()
            else:
                del v2, v25
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method0(v0 : object) -> US0:
    return method1(v0)
def method6(v0 : object) -> US6:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US6_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US6_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US6_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method7(v0 : object) -> US8:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method6(v2)
        del v2
        return US8_0(v5)
    else:
        del v4
        v8 = "PlayerAction" == v1
        if v8:
            del v1, v8
            v9 = v2[0]
            assert isinstance(v9,i32), f'The object needs to be the right primitive type. Got: {v9}'
            v10 = v9
            del v9
            v11 = v2[1]
            del v2
            v12 = method2(v11)
            del v11
            return US8_1(v10, v12)
        else:
            del v8
            v15 = "PlayerGotCard" == v1
            if v15:
                del v1, v15
                v16 = v2[0]
                assert isinstance(v16,i32), f'The object needs to be the right primitive type. Got: {v16}'
                v17 = v16
                del v16
                v18 = v2[1]
                del v2
                v19 = method6(v18)
                del v18
                return US8_2(v17, v19)
            else:
                del v15
                v22 = "Showdown" == v1
                if v22:
                    del v1, v22
                    v23 = v2["cards_shown"] # type: ignore
                    assert isinstance(v23,list), f'The object needs to be a Python list. Got: {v23}'
                    v24 = len(v23)
                    v25 = 2 == v24
                    v26 = v25 == False
                    if v26:
                        v27 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v25, v27
                        del v27
                    else:
                        pass
                    del v25, v26
                    v28 = static_array(2)
                    v29 = 0
                    while method3(v24, v29):
                        v31 = v23[v29]
                        v32 = method6(v31)
                        del v31
                        v33 = 0 <= v29
                        if v33:
                            v34 = v29 < 2
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
                        v28[v29] = v32
                        del v32
                        v29 += 1 
                    del v23, v24, v29
                    v38 = v2["chips_won"] # type: ignore
                    assert isinstance(v38,i32), f'The object needs to be the right primitive type. Got: {v38}'
                    v39 = v38
                    del v38
                    v40 = v2["winner_id"] # type: ignore
                    del v2
                    assert isinstance(v40,i32), f'The object needs to be the right primitive type. Got: {v40}'
                    v41 = v40
                    del v40
                    return US8_3(v28, v39, v41)
                else:
                    del v2, v22
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method10(v0 : object) -> US5:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US5_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method6(v2)
            del v2
            return US5_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method9(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5 = v2["community_card"] # type: ignore
        v6 = method10(v5)
        del v5
        v7 = v2["is_button_s_first_move"] # type: ignore
        assert isinstance(v7,bool), f'The object needs to be the right primitive type. Got: {v7}'
        v8 = v7
        del v7
        v9 = v2["pl_card"] # type: ignore
        assert isinstance(v9,list), f'The object needs to be a Python list. Got: {v9}'
        v10 = len(v9)
        v11 = 2 == v10
        v12 = v11 == False
        if v12:
            v13 = "The type level dimension has to equal the value passed at runtime into create."
            assert v11, v13
            del v13
        else:
            pass
        del v11, v12
        v14 = static_array(2)
        v15 = 0
        while method3(v10, v15):
            v17 = v9[v15]
            v18 = method6(v17)
            del v17
            v19 = 0 <= v15
            if v19:
                v20 = v15 < 2
                v21 = v20
            else:
                v21 = False
            del v19
            v22 = v21 == False
            if v22:
                v23 = "The read index needs to be in range for the static array."
                assert v21, v23
                del v23
            else:
                pass
            del v21, v22
            v14[v15] = v18
            del v18
            v15 += 1 
        del v9, v10, v15
        v24 = v2["player_turn"] # type: ignore
        assert isinstance(v24,i32), f'The object needs to be the right primitive type. Got: {v24}'
        v25 = v24
        del v24
        v26 = v2["pot"] # type: ignore
        assert isinstance(v26,list), f'The object needs to be a Python list. Got: {v26}'
        v27 = len(v26)
        v28 = 2 == v27
        v29 = v28 == False
        if v29:
            v30 = "The type level dimension has to equal the value passed at runtime into create."
            assert v28, v30
            del v30
        else:
            pass
        del v28, v29
        v31 = static_array(2)
        v32 = 0
        while method3(v27, v32):
            v34 = v26[v32]
            assert isinstance(v34,i32), f'The object needs to be the right primitive type. Got: {v34}'
            v35 = v34
            del v34
            v36 = 0 <= v32
            if v36:
                v37 = v32 < 2
                v38 = v37
            else:
                v38 = False
            del v36
            v39 = v38 == False
            if v39:
                v40 = "The read index needs to be in range for the static array."
                assert v38, v40
                del v40
            else:
                pass
            del v38, v39
            v31[v32] = v35
            del v35
            v32 += 1 
        del v26, v27, v32
        v41 = v2["raises_left"] # type: ignore
        del v2
        assert isinstance(v41,i32), f'The object needs to be the right primitive type. Got: {v41}'
        v42 = v41
        del v41
        return US4_0(v6, v8, v14, v25, v31, v42)
    else:
        del v4
        v45 = "ChanceInit" == v1
        if v45:
            del v1, v45
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US4_1()
        else:
            del v45
            v48 = "Round" == v1
            if v48:
                del v1, v48
                v49 = v2["community_card"] # type: ignore
                v50 = method10(v49)
                del v49
                v51 = v2["is_button_s_first_move"] # type: ignore
                assert isinstance(v51,bool), f'The object needs to be the right primitive type. Got: {v51}'
                v52 = v51
                del v51
                v53 = v2["pl_card"] # type: ignore
                assert isinstance(v53,list), f'The object needs to be a Python list. Got: {v53}'
                v54 = len(v53)
                v55 = 2 == v54
                v56 = v55 == False
                if v56:
                    v57 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v55, v57
                    del v57
                else:
                    pass
                del v55, v56
                v58 = static_array(2)
                v59 = 0
                while method3(v54, v59):
                    v61 = v53[v59]
                    v62 = method6(v61)
                    del v61
                    v63 = 0 <= v59
                    if v63:
                        v64 = v59 < 2
                        v65 = v64
                    else:
                        v65 = False
                    del v63
                    v66 = v65 == False
                    if v66:
                        v67 = "The read index needs to be in range for the static array."
                        assert v65, v67
                        del v67
                    else:
                        pass
                    del v65, v66
                    v58[v59] = v62
                    del v62
                    v59 += 1 
                del v53, v54, v59
                v68 = v2["player_turn"] # type: ignore
                assert isinstance(v68,i32), f'The object needs to be the right primitive type. Got: {v68}'
                v69 = v68
                del v68
                v70 = v2["pot"] # type: ignore
                assert isinstance(v70,list), f'The object needs to be a Python list. Got: {v70}'
                v71 = len(v70)
                v72 = 2 == v71
                v73 = v72 == False
                if v73:
                    v74 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v72, v74
                    del v74
                else:
                    pass
                del v72, v73
                v75 = static_array(2)
                v76 = 0
                while method3(v71, v76):
                    v78 = v70[v76]
                    assert isinstance(v78,i32), f'The object needs to be the right primitive type. Got: {v78}'
                    v79 = v78
                    del v78
                    v80 = 0 <= v76
                    if v80:
                        v81 = v76 < 2
                        v82 = v81
                    else:
                        v82 = False
                    del v80
                    v83 = v82 == False
                    if v83:
                        v84 = "The read index needs to be in range for the static array."
                        assert v82, v84
                        del v84
                    else:
                        pass
                    del v82, v83
                    v75[v76] = v79
                    del v79
                    v76 += 1 
                del v70, v71, v76
                v85 = v2["raises_left"] # type: ignore
                del v2
                assert isinstance(v85,i32), f'The object needs to be the right primitive type. Got: {v85}'
                v86 = v85
                del v85
                return US4_2(v50, v52, v58, v69, v75, v86)
            else:
                del v48
                v89 = "RoundWithAction" == v1
                if v89:
                    del v1, v89
                    v90 = v2[0]
                    v91 = v90["community_card"] # type: ignore
                    v92 = method10(v91)
                    del v91
                    v93 = v90["is_button_s_first_move"] # type: ignore
                    assert isinstance(v93,bool), f'The object needs to be the right primitive type. Got: {v93}'
                    v94 = v93
                    del v93
                    v95 = v90["pl_card"] # type: ignore
                    assert isinstance(v95,list), f'The object needs to be a Python list. Got: {v95}'
                    v96 = len(v95)
                    v97 = 2 == v96
                    v98 = v97 == False
                    if v98:
                        v99 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v97, v99
                        del v99
                    else:
                        pass
                    del v97, v98
                    v100 = static_array(2)
                    v101 = 0
                    while method3(v96, v101):
                        v103 = v95[v101]
                        v104 = method6(v103)
                        del v103
                        v105 = 0 <= v101
                        if v105:
                            v106 = v101 < 2
                            v107 = v106
                        else:
                            v107 = False
                        del v105
                        v108 = v107 == False
                        if v108:
                            v109 = "The read index needs to be in range for the static array."
                            assert v107, v109
                            del v109
                        else:
                            pass
                        del v107, v108
                        v100[v101] = v104
                        del v104
                        v101 += 1 
                    del v95, v96, v101
                    v110 = v90["player_turn"] # type: ignore
                    assert isinstance(v110,i32), f'The object needs to be the right primitive type. Got: {v110}'
                    v111 = v110
                    del v110
                    v112 = v90["pot"] # type: ignore
                    assert isinstance(v112,list), f'The object needs to be a Python list. Got: {v112}'
                    v113 = len(v112)
                    v114 = 2 == v113
                    v115 = v114 == False
                    if v115:
                        v116 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v114, v116
                        del v116
                    else:
                        pass
                    del v114, v115
                    v117 = static_array(2)
                    v118 = 0
                    while method3(v113, v118):
                        v120 = v112[v118]
                        assert isinstance(v120,i32), f'The object needs to be the right primitive type. Got: {v120}'
                        v121 = v120
                        del v120
                        v122 = 0 <= v118
                        if v122:
                            v123 = v118 < 2
                            v124 = v123
                        else:
                            v124 = False
                        del v122
                        v125 = v124 == False
                        if v125:
                            v126 = "The read index needs to be in range for the static array."
                            assert v124, v126
                            del v126
                        else:
                            pass
                        del v124, v125
                        v117[v118] = v121
                        del v121
                        v118 += 1 
                    del v112, v113, v118
                    v127 = v90["raises_left"] # type: ignore
                    del v90
                    assert isinstance(v127,i32), f'The object needs to be the right primitive type. Got: {v127}'
                    v128 = v127
                    del v127
                    v129 = v2[1]
                    del v2
                    v130 = method2(v129)
                    del v129
                    return US4_3(v92, v94, v100, v111, v117, v128, v130)
                else:
                    del v89
                    v133 = "TerminalCall" == v1
                    if v133:
                        del v1, v133
                        v134 = v2["community_card"] # type: ignore
                        v135 = method10(v134)
                        del v134
                        v136 = v2["is_button_s_first_move"] # type: ignore
                        assert isinstance(v136,bool), f'The object needs to be the right primitive type. Got: {v136}'
                        v137 = v136
                        del v136
                        v138 = v2["pl_card"] # type: ignore
                        assert isinstance(v138,list), f'The object needs to be a Python list. Got: {v138}'
                        v139 = len(v138)
                        v140 = 2 == v139
                        v141 = v140 == False
                        if v141:
                            v142 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v140, v142
                            del v142
                        else:
                            pass
                        del v140, v141
                        v143 = static_array(2)
                        v144 = 0
                        while method3(v139, v144):
                            v146 = v138[v144]
                            v147 = method6(v146)
                            del v146
                            v148 = 0 <= v144
                            if v148:
                                v149 = v144 < 2
                                v150 = v149
                            else:
                                v150 = False
                            del v148
                            v151 = v150 == False
                            if v151:
                                v152 = "The read index needs to be in range for the static array."
                                assert v150, v152
                                del v152
                            else:
                                pass
                            del v150, v151
                            v143[v144] = v147
                            del v147
                            v144 += 1 
                        del v138, v139, v144
                        v153 = v2["player_turn"] # type: ignore
                        assert isinstance(v153,i32), f'The object needs to be the right primitive type. Got: {v153}'
                        v154 = v153
                        del v153
                        v155 = v2["pot"] # type: ignore
                        assert isinstance(v155,list), f'The object needs to be a Python list. Got: {v155}'
                        v156 = len(v155)
                        v157 = 2 == v156
                        v158 = v157 == False
                        if v158:
                            v159 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v157, v159
                            del v159
                        else:
                            pass
                        del v157, v158
                        v160 = static_array(2)
                        v161 = 0
                        while method3(v156, v161):
                            v163 = v155[v161]
                            assert isinstance(v163,i32), f'The object needs to be the right primitive type. Got: {v163}'
                            v164 = v163
                            del v163
                            v165 = 0 <= v161
                            if v165:
                                v166 = v161 < 2
                                v167 = v166
                            else:
                                v167 = False
                            del v165
                            v168 = v167 == False
                            if v168:
                                v169 = "The read index needs to be in range for the static array."
                                assert v167, v169
                                del v169
                            else:
                                pass
                            del v167, v168
                            v160[v161] = v164
                            del v164
                            v161 += 1 
                        del v155, v156, v161
                        v170 = v2["raises_left"] # type: ignore
                        del v2
                        assert isinstance(v170,i32), f'The object needs to be the right primitive type. Got: {v170}'
                        v171 = v170
                        del v170
                        return US4_4(v135, v137, v143, v154, v160, v171)
                    else:
                        del v133
                        v174 = "TerminalFold" == v1
                        if v174:
                            del v1, v174
                            v175 = v2["community_card"] # type: ignore
                            v176 = method10(v175)
                            del v175
                            v177 = v2["is_button_s_first_move"] # type: ignore
                            assert isinstance(v177,bool), f'The object needs to be the right primitive type. Got: {v177}'
                            v178 = v177
                            del v177
                            v179 = v2["pl_card"] # type: ignore
                            assert isinstance(v179,list), f'The object needs to be a Python list. Got: {v179}'
                            v180 = len(v179)
                            v181 = 2 == v180
                            v182 = v181 == False
                            if v182:
                                v183 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v181, v183
                                del v183
                            else:
                                pass
                            del v181, v182
                            v184 = static_array(2)
                            v185 = 0
                            while method3(v180, v185):
                                v187 = v179[v185]
                                v188 = method6(v187)
                                del v187
                                v189 = 0 <= v185
                                if v189:
                                    v190 = v185 < 2
                                    v191 = v190
                                else:
                                    v191 = False
                                del v189
                                v192 = v191 == False
                                if v192:
                                    v193 = "The read index needs to be in range for the static array."
                                    assert v191, v193
                                    del v193
                                else:
                                    pass
                                del v191, v192
                                v184[v185] = v188
                                del v188
                                v185 += 1 
                            del v179, v180, v185
                            v194 = v2["player_turn"] # type: ignore
                            assert isinstance(v194,i32), f'The object needs to be the right primitive type. Got: {v194}'
                            v195 = v194
                            del v194
                            v196 = v2["pot"] # type: ignore
                            assert isinstance(v196,list), f'The object needs to be a Python list. Got: {v196}'
                            v197 = len(v196)
                            v198 = 2 == v197
                            v199 = v198 == False
                            if v199:
                                v200 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v198, v200
                                del v200
                            else:
                                pass
                            del v198, v199
                            v201 = static_array(2)
                            v202 = 0
                            while method3(v197, v202):
                                v204 = v196[v202]
                                assert isinstance(v204,i32), f'The object needs to be the right primitive type. Got: {v204}'
                                v205 = v204
                                del v204
                                v206 = 0 <= v202
                                if v206:
                                    v207 = v202 < 2
                                    v208 = v207
                                else:
                                    v208 = False
                                del v206
                                v209 = v208 == False
                                if v209:
                                    v210 = "The read index needs to be in range for the static array."
                                    assert v208, v210
                                    del v210
                                else:
                                    pass
                                del v208, v209
                                v201[v202] = v205
                                del v205
                                v202 += 1 
                            del v196, v197, v202
                            v211 = v2["raises_left"] # type: ignore
                            del v2
                            assert isinstance(v211,i32), f'The object needs to be the right primitive type. Got: {v211}'
                            v212 = v211
                            del v211
                            return US4_5(v176, v178, v184, v195, v201, v212)
                        else:
                            del v2, v174
                            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                            del v1
                            raise Exception("Error")
def method8(v0 : object) -> US3:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method9(v2)
            del v2
            return US3_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method11(v0 : object) -> US7:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US7_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = v2["community_card"] # type: ignore
            v9 = method10(v8)
            del v8
            v10 = v2["is_button_s_first_move"] # type: ignore
            assert isinstance(v10,bool), f'The object needs to be the right primitive type. Got: {v10}'
            v11 = v10
            del v10
            v12 = v2["pl_card"] # type: ignore
            assert isinstance(v12,list), f'The object needs to be a Python list. Got: {v12}'
            v13 = len(v12)
            v14 = 2 == v13
            v15 = v14 == False
            if v15:
                v16 = "The type level dimension has to equal the value passed at runtime into create."
                assert v14, v16
                del v16
            else:
                pass
            del v14, v15
            v17 = static_array(2)
            v18 = 0
            while method3(v13, v18):
                v20 = v12[v18]
                v21 = method6(v20)
                del v20
                v22 = 0 <= v18
                if v22:
                    v23 = v18 < 2
                    v24 = v23
                else:
                    v24 = False
                del v22
                v25 = v24 == False
                if v25:
                    v26 = "The read index needs to be in range for the static array."
                    assert v24, v26
                    del v26
                else:
                    pass
                del v24, v25
                v17[v18] = v21
                del v21
                v18 += 1 
            del v12, v13, v18
            v27 = v2["player_turn"] # type: ignore
            assert isinstance(v27,i32), f'The object needs to be the right primitive type. Got: {v27}'
            v28 = v27
            del v27
            v29 = v2["pot"] # type: ignore
            assert isinstance(v29,list), f'The object needs to be a Python list. Got: {v29}'
            v30 = len(v29)
            v31 = 2 == v30
            v32 = v31 == False
            if v32:
                v33 = "The type level dimension has to equal the value passed at runtime into create."
                assert v31, v33
                del v33
            else:
                pass
            del v31, v32
            v34 = static_array(2)
            v35 = 0
            while method3(v30, v35):
                v37 = v29[v35]
                assert isinstance(v37,i32), f'The object needs to be the right primitive type. Got: {v37}'
                v38 = v37
                del v37
                v39 = 0 <= v35
                if v39:
                    v40 = v35 < 2
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
                v34[v35] = v38
                del v38
                v35 += 1 
            del v29, v30, v35
            v44 = v2["raises_left"] # type: ignore
            del v2
            assert isinstance(v44,i32), f'The object needs to be the right primitive type. Got: {v44}'
            v45 = v44
            del v44
            return US7_1(v9, v11, v17, v28, v34, v45)
        else:
            del v7
            v48 = "WaitingForActionFromPlayerId" == v1
            if v48:
                del v1, v48
                v49 = v2["community_card"] # type: ignore
                v50 = method10(v49)
                del v49
                v51 = v2["is_button_s_first_move"] # type: ignore
                assert isinstance(v51,bool), f'The object needs to be the right primitive type. Got: {v51}'
                v52 = v51
                del v51
                v53 = v2["pl_card"] # type: ignore
                assert isinstance(v53,list), f'The object needs to be a Python list. Got: {v53}'
                v54 = len(v53)
                v55 = 2 == v54
                v56 = v55 == False
                if v56:
                    v57 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v55, v57
                    del v57
                else:
                    pass
                del v55, v56
                v58 = static_array(2)
                v59 = 0
                while method3(v54, v59):
                    v61 = v53[v59]
                    v62 = method6(v61)
                    del v61
                    v63 = 0 <= v59
                    if v63:
                        v64 = v59 < 2
                        v65 = v64
                    else:
                        v65 = False
                    del v63
                    v66 = v65 == False
                    if v66:
                        v67 = "The read index needs to be in range for the static array."
                        assert v65, v67
                        del v67
                    else:
                        pass
                    del v65, v66
                    v58[v59] = v62
                    del v62
                    v59 += 1 
                del v53, v54, v59
                v68 = v2["player_turn"] # type: ignore
                assert isinstance(v68,i32), f'The object needs to be the right primitive type. Got: {v68}'
                v69 = v68
                del v68
                v70 = v2["pot"] # type: ignore
                assert isinstance(v70,list), f'The object needs to be a Python list. Got: {v70}'
                v71 = len(v70)
                v72 = 2 == v71
                v73 = v72 == False
                if v73:
                    v74 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v72, v74
                    del v74
                else:
                    pass
                del v72, v73
                v75 = static_array(2)
                v76 = 0
                while method3(v71, v76):
                    v78 = v70[v76]
                    assert isinstance(v78,i32), f'The object needs to be the right primitive type. Got: {v78}'
                    v79 = v78
                    del v78
                    v80 = 0 <= v76
                    if v80:
                        v81 = v76 < 2
                        v82 = v81
                    else:
                        v82 = False
                    del v80
                    v83 = v82 == False
                    if v83:
                        v84 = "The read index needs to be in range for the static array."
                        assert v82, v84
                        del v84
                    else:
                        pass
                    del v82, v83
                    v75[v76] = v79
                    del v79
                    v76 += 1 
                del v70, v71, v76
                v85 = v2["raises_left"] # type: ignore
                del v2
                assert isinstance(v85,i32), f'The object needs to be the right primitive type. Got: {v85}'
                v86 = v85
                del v85
                return US7_2(v50, v52, v58, v69, v75, v86)
            else:
                del v2, v48
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : object) -> Tuple[static_array_list, static_array_list, US3, static_array, US7]:
    v1 = v0["large"] # type: ignore
    v2 = v1["deck"] # type: ignore
    v3 = len(v2)
    assert (6 >= v3), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v3} '
    del v3
    assert isinstance(v2,list), f'The object needs to be a Python list. Got: {v2}'
    v4 = len(v2)
    v5 = 6 >= v4
    v6 = v5 == False
    if v6:
        v7 = "The type level dimension has to equal the value passed at runtime into create."
        assert v5, v7
        del v7
    else:
        pass
    del v5, v6
    v8 = static_array_list(6)
    v8.length = v4
    v9 = 0
    while method3(v4, v9):
        v11 = v2[v9]
        v12 = method6(v11)
        del v11
        v13 = 0 <= v9
        if v13:
            v14 = v8.length
            v15 = v9 < v14
            del v14
            v16 = v15
        else:
            v16 = False
        del v13
        v17 = v16 == False
        if v17:
            v18 = "The set index needs to be in range for the static array list."
            assert v16, v18
            del v18
        else:
            pass
        del v16, v17
        v8[v9] = v12
        del v12
        v9 += 1 
    del v2, v4, v9
    v19 = v1["messages"] # type: ignore
    del v1
    v20 = len(v19)
    assert (32 >= v20), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v20} '
    del v20
    assert isinstance(v19,list), f'The object needs to be a Python list. Got: {v19}'
    v21 = len(v19)
    v22 = 32 >= v21
    v23 = v22 == False
    if v23:
        v24 = "The type level dimension has to equal the value passed at runtime into create."
        assert v22, v24
        del v24
    else:
        pass
    del v22, v23
    v25 = static_array_list(32)
    v25.length = v21
    v26 = 0
    while method3(v21, v26):
        v28 = v19[v26]
        v29 = method7(v28)
        del v28
        v30 = 0 <= v26
        if v30:
            v31 = v25.length
            v32 = v26 < v31
            del v31
            v33 = v32
        else:
            v33 = False
        del v30
        v34 = v33 == False
        if v34:
            v35 = "The set index needs to be in range for the static array list."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        v25[v26] = v29
        del v29
        v26 += 1 
    del v19, v21, v26
    v36 = v0["small"] # type: ignore
    del v0
    v37 = v36["game"] # type: ignore
    v38 = method8(v37)
    del v37
    v39 = v36["pl_type"] # type: ignore
    assert isinstance(v39,list), f'The object needs to be a Python list. Got: {v39}'
    v40 = len(v39)
    v41 = 2 == v40
    v42 = v41 == False
    if v42:
        v43 = "The type level dimension has to equal the value passed at runtime into create."
        assert v41, v43
        del v43
    else:
        pass
    del v41, v42
    v44 = static_array(2)
    v45 = 0
    while method3(v40, v45):
        v47 = v39[v45]
        v48 = method4(v47)
        del v47
        v49 = 0 <= v45
        if v49:
            v50 = v45 < 2
            v51 = v50
        else:
            v51 = False
        del v49
        v52 = v51 == False
        if v52:
            v53 = "The read index needs to be in range for the static array."
            assert v51, v53
            del v53
        else:
            pass
        del v51, v52
        v44[v45] = v48
        del v48
        v45 += 1 
    del v39, v40, v45
    v54 = v36["ui_game_state"] # type: ignore
    del v36
    v55 = method11(v54)
    del v54
    return v8, v25, v38, v44, v55
def method12(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method14(v0 : US6) -> object:
    match v0:
        case US6_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US6_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method16(v0 : US1) -> object:
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
def method15(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method14(v1)
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
            v9 = method16(v6)
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
            v17 = method14(v14)
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
            while method12(v25):
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
                v33 = method14(v32)
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
def method19(v0 : US5) -> object:
    match v0:
        case US5_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US5_1(v4): # Some
            del v0
            v5 = method14(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method18(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method19(v1)
            del v1
            v8 = v2
            del v2
            v9 = []
            v10 = 0
            while method12(v10):
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
                v18 = method14(v17)
                del v17
                v9.append(v18)
                del v18
                v10 += 1 
            del v3, v10
            v19 = v4
            del v4
            v20 = []
            v21 = 0
            while method12(v21):
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
        case US4_1(): # ChanceInit
            del v0
            v34 = []
            v35 = "ChanceInit"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US4_2(v37, v38, v39, v40, v41, v42): # Round
            del v0
            v43 = method19(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method12(v46):
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
                v54 = method14(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method12(v57):
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
        case US4_3(v70, v71, v72, v73, v74, v75, v76): # RoundWithAction
            del v0
            v77 = []
            v78 = method19(v70)
            del v70
            v79 = v71
            del v71
            v80 = []
            v81 = 0
            while method12(v81):
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
                v89 = method14(v88)
                del v88
                v80.append(v89)
                del v89
                v81 += 1 
            del v72, v81
            v90 = v73
            del v73
            v91 = []
            v92 = 0
            while method12(v92):
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
            v103 = method16(v76)
            del v76
            v77.append(v103)
            del v103
            v104 = v77
            del v77
            v105 = "RoundWithAction"
            v106 = [v105,v104]
            del v104, v105
            return v106
        case US4_4(v107, v108, v109, v110, v111, v112): # TerminalCall
            del v0
            v113 = method19(v107)
            del v107
            v114 = v108
            del v108
            v115 = []
            v116 = 0
            while method12(v116):
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
                v124 = method14(v123)
                del v123
                v115.append(v124)
                del v124
                v116 += 1 
            del v109, v116
            v125 = v110
            del v110
            v126 = []
            v127 = 0
            while method12(v127):
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
        case US4_5(v140, v141, v142, v143, v144, v145): # TerminalFold
            del v0
            v146 = method19(v140)
            del v140
            v147 = v141
            del v141
            v148 = []
            v149 = 0
            while method12(v149):
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
                v157 = method14(v156)
                del v156
                v148.append(v157)
                del v157
                v149 += 1 
            del v142, v149
            v158 = v143
            del v143
            v159 = []
            v160 = 0
            while method12(v160):
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
def method17(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method18(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method20(v0 : US2) -> object:
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
def method21(v0 : US7) -> object:
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
            v10 = method19(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method12(v13):
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
                v21 = method14(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method12(v24):
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
            v43 = method19(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method12(v46):
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
                v54 = method14(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method12(v57):
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
def method13(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7, v5 : static_array_list, v6 : static_array, v7 : US7) -> object:
    v8 = []
    v9 = v0.length
    v10 = 0
    while method3(v9, v10):
        v12 = 0 <= v10
        if v12:
            v13 = v0.length
            v14 = v10 < v13
            del v13
            v15 = v14
        else:
            v15 = False
        del v12
        v16 = v15 == False
        if v16:
            v17 = "The read index needs to be in range for the static array list."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v18 = v0[v10]
        v19 = method14(v18)
        del v18
        v8.append(v19)
        del v19
        v10 += 1 
    del v0, v9, v10
    v20 = []
    v21 = v1.length
    v22 = 0
    while method3(v21, v22):
        v24 = 0 <= v22
        if v24:
            v25 = v1.length
            v26 = v22 < v25
            del v25
            v27 = v26
        else:
            v27 = False
        del v24
        v28 = v27 == False
        if v28:
            v29 = "The read index needs to be in range for the static array list."
            assert v27, v29
            del v29
        else:
            pass
        del v27, v28
        v30 = v1[v22]
        v31 = method15(v30)
        del v30
        v20.append(v31)
        del v31
        v22 += 1 
    del v1, v21, v22
    v32 = {'deck': v8, 'messages': v20}
    del v8, v20
    v33 = method17(v2)
    del v2
    v34 = []
    v35 = 0
    while method12(v35):
        v37 = 0 <= v35
        if v37:
            v38 = v35 < 2
            v39 = v38
        else:
            v39 = False
        del v37
        v40 = v39 == False
        if v40:
            v41 = "The read index needs to be in range for the static array."
            assert v39, v41
            del v41
        else:
            pass
        del v39, v40
        v42 = v3[v35]
        v43 = method20(v42)
        del v42
        v34.append(v43)
        del v43
        v35 += 1 
    del v3, v35
    v44 = method21(v4)
    del v4
    v45 = {'game': v33, 'pl_type': v34, 'ui_game_state': v44}
    del v33, v34, v44
    v46 = {'large': v32, 'small': v45}
    del v32, v45
    v47 = []
    v48 = v5.length
    v49 = 0
    while method3(v48, v49):
        v51 = 0 <= v49
        if v51:
            v52 = v5.length
            v53 = v49 < v52
            del v52
            v54 = v53
        else:
            v54 = False
        del v51
        v55 = v54 == False
        if v55:
            v56 = "The read index needs to be in range for the static array list."
            assert v54, v56
            del v56
        else:
            pass
        del v54, v55
        v57 = v5[v49]
        v58 = method15(v57)
        del v57
        v47.append(v58)
        del v58
        v49 += 1 
    del v5, v48, v49
    v59 = []
    v60 = 0
    while method12(v60):
        v62 = 0 <= v60
        if v62:
            v63 = v60 < 2
            v64 = v63
        else:
            v64 = False
        del v62
        v65 = v64 == False
        if v65:
            v66 = "The read index needs to be in range for the static array."
            assert v64, v66
            del v66
        else:
            pass
        del v64, v65
        v67 = v6[v60]
        v68 = method20(v67)
        del v67
        v59.append(v68)
        del v68
        v60 += 1 
    del v6, v60
    v69 = method21(v7)
    del v7
    v70 = {'messages': v47, 'pl_type': v59, 'ui_game_state': v69}
    del v47, v59, v69
    v71 = {'game_state': v46, 'ui_state': v70}
    del v46, v70
    return v71
def method22(v0 : static_array_list, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US7) -> object:
    v5 = []
    v6 = v0.length
    v7 = 0
    while method3(v6, v7):
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
        v16 = method14(v15)
        del v15
        v5.append(v16)
        del v16
        v7 += 1 
    del v0, v6, v7
    v17 = []
    v18 = v1.length
    v19 = 0
    while method3(v18, v19):
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
        v28 = method15(v27)
        del v27
        v17.append(v28)
        del v28
        v19 += 1 
    del v18, v19
    v29 = {'deck': v5, 'messages': v17}
    del v5, v17
    v30 = method17(v2)
    del v2
    v31 = []
    v32 = 0
    while method12(v32):
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
        v40 = method20(v39)
        del v39
        v31.append(v40)
        del v40
        v32 += 1 
    del v32
    v41 = method21(v4)
    v42 = {'game': v30, 'pl_type': v31, 'ui_game_state': v41}
    del v30, v31, v41
    v43 = {'large': v29, 'small': v42}
    del v29, v42
    v44 = []
    v45 = v1.length
    v46 = 0
    while method3(v45, v46):
        v48 = 0 <= v46
        if v48:
            v49 = v1.length
            v50 = v46 < v49
            del v49
            v51 = v50
        else:
            v51 = False
        del v48
        v52 = v51 == False
        if v52:
            v53 = "The read index needs to be in range for the static array list."
            assert v51, v53
            del v53
        else:
            pass
        del v51, v52
        v54 = v1[v46]
        v55 = method15(v54)
        del v54
        v44.append(v55)
        del v55
        v46 += 1 
    del v1, v45, v46
    v56 = []
    v57 = 0
    while method12(v57):
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
        v64 = v3[v57]
        v65 = method20(v64)
        del v64
        v56.append(v65)
        del v65
        v57 += 1 
    del v3, v57
    v66 = method21(v4)
    del v4
    v67 = {'messages': v44, 'pl_type': v56, 'ui_game_state': v66}
    del v44, v56, v66
    v68 = {'game_state': v43, 'ui_state': v67}
    del v43, v67
    return v68
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("Leduc_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
