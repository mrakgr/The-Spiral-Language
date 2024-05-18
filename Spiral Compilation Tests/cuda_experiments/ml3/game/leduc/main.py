kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <curand_kernel.h>
struct US1;
struct US2;
struct US0;
struct US4;
struct US6;
struct US5;
struct US3;
struct US7;
struct US8;
struct Tuple0;
struct Tuple1;
__device__ unsigned long loop_2(unsigned long v0, curandStatePhilox4_32_10_t * v1);
struct US9;
__device__ long tag_4(US4 v0);
__device__ bool is_pair_5(long v0, long v1);
__device__ Tuple1 order_6(long v0, long v1);
__device__ US9 compare_hands_3(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5);
__device__ US5 play_loop_inner_1(static_array_list<US4,6l,long> v0, static_array_list<US7,32l,long> v1, static_array<US2,2l> v2, US5 v3);
__device__ Tuple0 play_loop_0(US3 v0, static_array_list<US7,32l,long> v1, static_array<US2,2l> v2, US8 v3, static_array_list<US4,6l,long> v4, US5 v5);
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
struct US4 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US6 {
    union {
        struct {
            US4 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US5 {
    union {
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case0; // ChanceCommunityCard
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // Round
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            US1 v6;
            long v3;
            long v5;
            bool v1;
        } case3; // RoundWithAction
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case4; // TerminalCall
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case5; // TerminalFold
    } v;
    unsigned long tag : 3;
};
struct US3 {
    union {
        struct {
            static_array_list<US4,6l,long> v0;
            US5 v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US7 {
    union {
        struct {
            US4 v0;
        } case0; // CommunityCardIs
        struct {
            US1 v1;
            long v0;
        } case1; // PlayerAction
        struct {
            US4 v1;
            long v0;
        } case2; // PlayerGotCard
        struct {
            static_array<US4,2l> v0;
            long v1;
            long v2;
        } case3; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US8 {
    union {
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case1; // GameOver
        struct {
            US6 v0;
            static_array<US4,2l> v2;
            static_array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US3 v0;
    static_array_list<US7,32l,long> v1;
    static_array<US2,2l> v2;
    US8 v3;
    __device__ Tuple0(US3 t0, static_array_list<US7,32l,long> t1, static_array<US2,2l> t2, US8 t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    long v0;
    long v1;
    __device__ Tuple1(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
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
__device__ US4 US4_0() { // Jack
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1() { // King
    US4 x;
    x.tag = 1;
    return x;
}
__device__ US4 US4_2() { // Queen
    US4 x;
    x.tag = 2;
    return x;
}
__device__ US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
__device__ US6 US6_1(US4 v0) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US5 US5_0(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // ChanceCommunityCard
    US5 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2; x.v.case0.v3 = v3; x.v.case0.v4 = v4; x.v.case0.v5 = v5;
    return x;
}
__device__ US5 US5_1() { // ChanceInit
    US5 x;
    x.tag = 1;
    return x;
}
__device__ US5 US5_2(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // Round
    US5 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ US5 US5_3(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5, US1 v6) { // RoundWithAction
    US5 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US5 US5_4(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // TerminalCall
    US5 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US5 US5_5(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // TerminalFold
    US5 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5;
    return x;
}
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(static_array_list<US4,6l,long> v0, US5 v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_1(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ US7 US7_0(US4 v0) { // CommunityCardIs
    US7 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US7 US7_1(long v0, US1 v1) { // PlayerAction
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US7 US7_2(long v0, US4 v1) { // PlayerGotCard
    US7 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US7 US7_3(static_array<US4,2l> v0, long v1, long v2) { // Showdown
    US7 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2;
    return x;
}
__device__ US8 US8_0() { // GameNotStarted
    US8 x;
    x.tag = 0;
    return x;
}
__device__ US8 US8_1(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // GameOver
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US8 US8_2(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5) { // WaitingForActionFromPlayerId
    US8 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
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
__device__ long tag_4(US4 v0){
    switch (v0.tag) {
        case 0: { // Jack
            return 0l;
            break;
        }
        case 1: { // King
            return 2l;
            break;
        }
        default: { // Queen
            return 1l;
        }
    }
}
__device__ bool is_pair_5(long v0, long v1){
    bool v2;
    v2 = v1 == v0;
    return v2;
}
__device__ Tuple1 order_6(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    if (v2){
        return Tuple1(v1, v0);
    } else {
        return Tuple1(v0, v1);
    }
}
__device__ US9 compare_hands_3(US6 v0, bool v1, static_array<US4,2l> v2, long v3, static_array<long,2l> v4, long v5){
    switch (v0.tag) {
        case 0: { // None
            printf("%s\n", "Expected the community card to be present in the table.");
            asm("exit;");
            break;
        }
        default: { // Some
            US4 v7 = v0.v.case1.v0;
            long v8;
            v8 = tag_4(v7);
            US4 v9;
            v9 = v2.v[0l];
            long v10;
            v10 = tag_4(v9);
            US4 v11;
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
                    Tuple1 tmp7 = order_6(v8, v10);
                    v25 = tmp7.v0; v26 = tmp7.v1;
                    long v27; long v28;
                    Tuple1 tmp8 = order_6(v8, v12);
                    v27 = tmp8.v0; v28 = tmp8.v1;
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
        }
    }
}
__device__ US5 play_loop_inner_1(static_array_list<US4,6l,long> v0, static_array_list<US7,32l,long> v1, static_array<US2,2l> v2, US5 v3){
    switch (v3.tag) {
        case 0: { // ChanceCommunityCard
            US6 v395 = v3.v.case0.v0; bool v396 = v3.v.case0.v1; static_array<US4,2l> v397 = v3.v.case0.v2; long v398 = v3.v.case0.v3; static_array<long,2l> v399 = v3.v.case0.v4; long v400 = v3.v.case0.v5;
            long v401;
            v401 = v0.length;
            long v402;
            v402 = v401 - 1l;
            bool v403;
            v403 = 0l <= v402;
            bool v406;
            if (v403){
                long v404;
                v404 = v0.length;
                bool v405;
                v405 = v402 < v404;
                v406 = v405;
            } else {
                v406 = false;
            }
            bool v407;
            v407 = v406 == false;
            if (v407){
                assert("The read index needs to be in range." && v406);
            } else {
            }
            US4 v408;
            v408 = v0.v[v402];
            v0.length = v402;
            long v409;
            v409 = v1.length;
            bool v410;
            v410 = v409 < 32l;
            bool v411;
            v411 = v410 == false;
            if (v411){
                assert("The length has to be less than the maximum length of the array." && v410);
            } else {
            }
            long v412;
            v412 = v409 + 1l;
            v1.length = v412;
            bool v413;
            v413 = 0l <= v409;
            bool v416;
            if (v413){
                long v414;
                v414 = v1.length;
                bool v415;
                v415 = v409 < v414;
                v416 = v415;
            } else {
                v416 = false;
            }
            bool v417;
            v417 = v416 == false;
            if (v417){
                assert("The set index needs to be in range." && v416);
            } else {
            }
            US7 v418;
            v418 = US7_0(v408);
            v1.v[v409] = v418;
            long v419;
            v419 = 2l;
            long v420; long v421;
            Tuple1 tmp0 = Tuple1(0l, 0l);
            v420 = tmp0.v0; v421 = tmp0.v1;
            while (while_method_0(v420)){
                bool v423;
                v423 = 0l <= v420;
                bool v425;
                if (v423){
                    bool v424;
                    v424 = v420 < 2l;
                    v425 = v424;
                } else {
                    v425 = false;
                }
                bool v426;
                v426 = v425 == false;
                if (v426){
                    assert("The read index needs to be in range." && v425);
                } else {
                }
                long v427;
                v427 = v399.v[v420];
                bool v428;
                v428 = v421 >= v427;
                long v429;
                if (v428){
                    v429 = v421;
                } else {
                    v429 = v427;
                }
                v421 = v429;
                v420 += 1l ;
            }
            static_array<long,2l> v430;
            long v431;
            v431 = 0l;
            while (while_method_0(v431)){
                bool v433;
                v433 = 0l <= v431;
                bool v435;
                if (v433){
                    bool v434;
                    v434 = v431 < 2l;
                    v435 = v434;
                } else {
                    v435 = false;
                }
                bool v436;
                v436 = v435 == false;
                if (v436){
                    assert("The read index needs to be in range." && v435);
                } else {
                }
                v430.v[v431] = v421;
                v431 += 1l ;
            }
            US6 v437;
            v437 = US6_1(v408);
            bool v438;
            v438 = true;
            long v439;
            v439 = 0l;
            US5 v440;
            v440 = US5_2(v437, v438, v397, v439, v430, v419);
            return play_loop_inner_1(v0, v1, v2, v440);
            break;
        }
        case 1: { // ChanceInit
            long v442;
            v442 = v0.length;
            long v443;
            v443 = v442 - 1l;
            bool v444;
            v444 = 0l <= v443;
            bool v447;
            if (v444){
                long v445;
                v445 = v0.length;
                bool v446;
                v446 = v443 < v445;
                v447 = v446;
            } else {
                v447 = false;
            }
            bool v448;
            v448 = v447 == false;
            if (v448){
                assert("The read index needs to be in range." && v447);
            } else {
            }
            US4 v449;
            v449 = v0.v[v443];
            v0.length = v443;
            long v450;
            v450 = v0.length;
            long v451;
            v451 = v450 - 1l;
            bool v452;
            v452 = 0l <= v451;
            bool v455;
            if (v452){
                long v453;
                v453 = v0.length;
                bool v454;
                v454 = v451 < v453;
                v455 = v454;
            } else {
                v455 = false;
            }
            bool v456;
            v456 = v455 == false;
            if (v456){
                assert("The read index needs to be in range." && v455);
            } else {
            }
            US4 v457;
            v457 = v0.v[v451];
            v0.length = v451;
            long v458;
            v458 = v1.length;
            bool v459;
            v459 = v458 < 32l;
            bool v460;
            v460 = v459 == false;
            if (v460){
                assert("The length has to be less than the maximum length of the array." && v459);
            } else {
            }
            long v461;
            v461 = v458 + 1l;
            v1.length = v461;
            bool v462;
            v462 = 0l <= v458;
            bool v465;
            if (v462){
                long v463;
                v463 = v1.length;
                bool v464;
                v464 = v458 < v463;
                v465 = v464;
            } else {
                v465 = false;
            }
            bool v466;
            v466 = v465 == false;
            if (v466){
                assert("The set index needs to be in range." && v465);
            } else {
            }
            US7 v467;
            v467 = US7_2(0l, v449);
            v1.v[v458] = v467;
            long v468;
            v468 = v1.length;
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
            v1.length = v471;
            bool v472;
            v472 = 0l <= v468;
            bool v475;
            if (v472){
                long v473;
                v473 = v1.length;
                bool v474;
                v474 = v468 < v473;
                v475 = v474;
            } else {
                v475 = false;
            }
            bool v476;
            v476 = v475 == false;
            if (v476){
                assert("The set index needs to be in range." && v475);
            } else {
            }
            US7 v477;
            v477 = US7_2(1l, v457);
            v1.v[v468] = v477;
            long v478;
            v478 = 2l;
            static_array<long,2l> v479;
            v479.v[0l] = 1l;
            v479.v[1l] = 1l;
            static_array<US4,2l> v480;
            v480.v[0l] = v449;
            v480.v[1l] = v457;
            US6 v481;
            v481 = US6_0();
            bool v482;
            v482 = true;
            long v483;
            v483 = 0l;
            US5 v484;
            v484 = US5_2(v481, v482, v480, v483, v479, v478);
            return play_loop_inner_1(v0, v1, v2, v484);
            break;
        }
        case 2: { // Round
            US6 v55 = v3.v.case2.v0; bool v56 = v3.v.case2.v1; static_array<US4,2l> v57 = v3.v.case2.v2; long v58 = v3.v.case2.v3; static_array<long,2l> v59 = v3.v.case2.v4; long v60 = v3.v.case2.v5;
            bool v61;
            v61 = 0l <= v58;
            bool v63;
            if (v61){
                bool v62;
                v62 = v58 < 2l;
                v63 = v62;
            } else {
                v63 = false;
            }
            bool v64;
            v64 = v63 == false;
            if (v64){
                assert("The read index needs to be in range." && v63);
            } else {
            }
            US2 v65;
            v65 = v2.v[v58];
            switch (v65.tag) {
                case 0: { // Computer
                    static_array_list<US1,3l,long> v66;
                    v66.length = 0;
                    v66.length = 1l;
                    long v67;
                    v67 = v66.length;
                    bool v68;
                    v68 = 0l < v67;
                    bool v69;
                    v69 = v68 == false;
                    if (v69){
                        assert("The set index needs to be in range." && v68);
                    } else {
                    }
                    US1 v70;
                    v70 = US1_0();
                    v66.v[0l] = v70;
                    long v71;
                    v71 = v59.v[0l];
                    long v72;
                    v72 = v59.v[1l];
                    bool v73;
                    v73 = v71 == v72;
                    bool v74;
                    v74 = v73 != true;
                    if (v74){
                        long v75;
                        v75 = v66.length;
                        bool v76;
                        v76 = v75 < 3l;
                        bool v77;
                        v77 = v76 == false;
                        if (v77){
                            assert("The length has to be less than the maximum length of the array." && v76);
                        } else {
                        }
                        long v78;
                        v78 = v75 + 1l;
                        v66.length = v78;
                        bool v79;
                        v79 = 0l <= v75;
                        bool v82;
                        if (v79){
                            long v80;
                            v80 = v66.length;
                            bool v81;
                            v81 = v75 < v80;
                            v82 = v81;
                        } else {
                            v82 = false;
                        }
                        bool v83;
                        v83 = v82 == false;
                        if (v83){
                            assert("The set index needs to be in range." && v82);
                        } else {
                        }
                        US1 v84;
                        v84 = US1_1();
                        v66.v[v75] = v84;
                    } else {
                    }
                    bool v85;
                    v85 = v60 > 0l;
                    if (v85){
                        long v86;
                        v86 = v66.length;
                        bool v87;
                        v87 = v86 < 3l;
                        bool v88;
                        v88 = v87 == false;
                        if (v88){
                            assert("The length has to be less than the maximum length of the array." && v87);
                        } else {
                        }
                        long v89;
                        v89 = v86 + 1l;
                        v66.length = v89;
                        bool v90;
                        v90 = 0l <= v86;
                        bool v93;
                        if (v90){
                            long v91;
                            v91 = v66.length;
                            bool v92;
                            v92 = v86 < v91;
                            v93 = v92;
                        } else {
                            v93 = false;
                        }
                        bool v94;
                        v94 = v93 == false;
                        if (v94){
                            assert("The set index needs to be in range." && v93);
                        } else {
                        }
                        US1 v95;
                        v95 = US1_2();
                        v66.v[v86] = v95;
                    } else {
                    }
                    unsigned long long v96;
                    v96 = clock64();
                    curandStatePhilox4_32_10_t v97;
                    curandStatePhilox4_32_10_t * v98 = &v97;
                    curand_init(v96,0ull,0ull,v98);
                    long v99;
                    v99 = v66.length;
                    long v100;
                    v100 = v99 - 1l;
                    long v101;
                    v101 = 0l;
                    while (while_method_1(v100, v101)){
                        long v103;
                        v103 = v66.length;
                        long v104;
                        v104 = v103 - v101;
                        unsigned long v105;
                        v105 = (unsigned long)v104;
                        unsigned long v106;
                        v106 = loop_2(v105, v98);
                        unsigned long v107;
                        v107 = (unsigned long)v101;
                        unsigned long v108;
                        v108 = v106 - v107;
                        long v109;
                        v109 = (long)v108;
                        bool v110;
                        v110 = 0l <= v101;
                        bool v113;
                        if (v110){
                            long v111;
                            v111 = v66.length;
                            bool v112;
                            v112 = v101 < v111;
                            v113 = v112;
                        } else {
                            v113 = false;
                        }
                        bool v114;
                        v114 = v113 == false;
                        if (v114){
                            assert("The read index needs to be in range." && v113);
                        } else {
                        }
                        US1 v115;
                        v115 = v66.v[v101];
                        bool v116;
                        v116 = 0l <= v109;
                        bool v119;
                        if (v116){
                            long v117;
                            v117 = v66.length;
                            bool v118;
                            v118 = v109 < v117;
                            v119 = v118;
                        } else {
                            v119 = false;
                        }
                        bool v120;
                        v120 = v119 == false;
                        if (v120){
                            assert("The read index needs to be in range." && v119);
                        } else {
                        }
                        US1 v121;
                        v121 = v66.v[v109];
                        bool v124;
                        if (v110){
                            long v122;
                            v122 = v66.length;
                            bool v123;
                            v123 = v101 < v122;
                            v124 = v123;
                        } else {
                            v124 = false;
                        }
                        bool v125;
                        v125 = v124 == false;
                        if (v125){
                            assert("The set index needs to be in range." && v124);
                        } else {
                        }
                        v66.v[v101] = v121;
                        bool v128;
                        if (v116){
                            long v126;
                            v126 = v66.length;
                            bool v127;
                            v127 = v109 < v126;
                            v128 = v127;
                        } else {
                            v128 = false;
                        }
                        bool v129;
                        v129 = v128 == false;
                        if (v129){
                            assert("The set index needs to be in range." && v128);
                        } else {
                        }
                        v66.v[v109] = v115;
                        v101 += 1l ;
                    }
                    long v130;
                    v130 = v66.length;
                    long v131;
                    v131 = v130 - 1l;
                    bool v132;
                    v132 = 0l <= v131;
                    bool v135;
                    if (v132){
                        long v133;
                        v133 = v66.length;
                        bool v134;
                        v134 = v131 < v133;
                        v135 = v134;
                    } else {
                        v135 = false;
                    }
                    bool v136;
                    v136 = v135 == false;
                    if (v136){
                        assert("The read index needs to be in range." && v135);
                    } else {
                    }
                    US1 v137;
                    v137 = v66.v[v131];
                    v66.length = v131;
                    long v138;
                    v138 = v1.length;
                    bool v139;
                    v139 = v138 < 32l;
                    bool v140;
                    v140 = v139 == false;
                    if (v140){
                        assert("The length has to be less than the maximum length of the array." && v139);
                    } else {
                    }
                    long v141;
                    v141 = v138 + 1l;
                    v1.length = v141;
                    bool v142;
                    v142 = 0l <= v138;
                    bool v145;
                    if (v142){
                        long v143;
                        v143 = v1.length;
                        bool v144;
                        v144 = v138 < v143;
                        v145 = v144;
                    } else {
                        v145 = false;
                    }
                    bool v146;
                    v146 = v145 == false;
                    if (v146){
                        assert("The set index needs to be in range." && v145);
                    } else {
                    }
                    US7 v147;
                    v147 = US7_1(v58, v137);
                    v1.v[v138] = v147;
                    US5 v259;
                    switch (v55.tag) {
                        case 0: { // None
                            switch (v137.tag) {
                                case 0: { // Call
                                    if (v56){
                                        bool v213;
                                        v213 = v58 == 0l;
                                        long v214;
                                        if (v213){
                                            v214 = 1l;
                                        } else {
                                            v214 = 0l;
                                        }
                                        v259 = US5_2(v55, false, v57, v214, v59, v60);
                                    } else {
                                        v259 = US5_0(v55, v56, v57, v58, v59, v60);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v259 = US5_5(v55, v56, v57, v58, v59, v60);
                                    break;
                                }
                                default: { // Raise
                                    if (v85){
                                        bool v218;
                                        v218 = v58 == 0l;
                                        long v219;
                                        if (v218){
                                            v219 = 1l;
                                        } else {
                                            v219 = 0l;
                                        }
                                        long v220;
                                        v220 = -1l + v60;
                                        long v221; long v222;
                                        Tuple1 tmp1 = Tuple1(0l, 0l);
                                        v221 = tmp1.v0; v222 = tmp1.v1;
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
                                                assert("The read index needs to be in range." && v226);
                                            } else {
                                            }
                                            long v228;
                                            v228 = v59.v[v221];
                                            bool v229;
                                            v229 = v222 >= v228;
                                            long v230;
                                            if (v229){
                                                v230 = v222;
                                            } else {
                                                v230 = v228;
                                            }
                                            v222 = v230;
                                            v221 += 1l ;
                                        }
                                        static_array<long,2l> v231;
                                        long v232;
                                        v232 = 0l;
                                        while (while_method_0(v232)){
                                            bool v234;
                                            v234 = 0l <= v232;
                                            bool v236;
                                            if (v234){
                                                bool v235;
                                                v235 = v232 < 2l;
                                                v236 = v235;
                                            } else {
                                                v236 = false;
                                            }
                                            bool v237;
                                            v237 = v236 == false;
                                            if (v237){
                                                assert("The read index needs to be in range." && v236);
                                            } else {
                                            }
                                            v231.v[v232] = v222;
                                            v232 += 1l ;
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
                                                assert("The read index needs to be in range." && v243);
                                            } else {
                                            }
                                            long v245;
                                            v245 = v231.v[v239];
                                            bool v246;
                                            v246 = v239 == v58;
                                            long v248;
                                            if (v246){
                                                long v247;
                                                v247 = v245 + 2l;
                                                v248 = v247;
                                            } else {
                                                v248 = v245;
                                            }
                                            bool v250;
                                            if (v241){
                                                bool v249;
                                                v249 = v239 < 2l;
                                                v250 = v249;
                                            } else {
                                                v250 = false;
                                            }
                                            bool v251;
                                            v251 = v250 == false;
                                            if (v251){
                                                assert("The read index needs to be in range." && v250);
                                            } else {
                                            }
                                            v238.v[v239] = v248;
                                            v239 += 1l ;
                                        }
                                        v259 = US5_2(v55, false, v57, v219, v238, v220);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                            break;
                        }
                        default: { // Some
                            US4 v148 = v55.v.case1.v0;
                            switch (v137.tag) {
                                case 0: { // Call
                                    if (v56){
                                        bool v150;
                                        v150 = v58 == 0l;
                                        long v151;
                                        if (v150){
                                            v151 = 1l;
                                        } else {
                                            v151 = 0l;
                                        }
                                        v259 = US5_2(v55, false, v57, v151, v59, v60);
                                    } else {
                                        long v153; long v154;
                                        Tuple1 tmp2 = Tuple1(0l, 0l);
                                        v153 = tmp2.v0; v154 = tmp2.v1;
                                        while (while_method_0(v153)){
                                            bool v156;
                                            v156 = 0l <= v153;
                                            bool v158;
                                            if (v156){
                                                bool v157;
                                                v157 = v153 < 2l;
                                                v158 = v157;
                                            } else {
                                                v158 = false;
                                            }
                                            bool v159;
                                            v159 = v158 == false;
                                            if (v159){
                                                assert("The read index needs to be in range." && v158);
                                            } else {
                                            }
                                            long v160;
                                            v160 = v59.v[v153];
                                            bool v161;
                                            v161 = v154 >= v160;
                                            long v162;
                                            if (v161){
                                                v162 = v154;
                                            } else {
                                                v162 = v160;
                                            }
                                            v154 = v162;
                                            v153 += 1l ;
                                        }
                                        static_array<long,2l> v163;
                                        long v164;
                                        v164 = 0l;
                                        while (while_method_0(v164)){
                                            bool v166;
                                            v166 = 0l <= v164;
                                            bool v168;
                                            if (v166){
                                                bool v167;
                                                v167 = v164 < 2l;
                                                v168 = v167;
                                            } else {
                                                v168 = false;
                                            }
                                            bool v169;
                                            v169 = v168 == false;
                                            if (v169){
                                                assert("The read index needs to be in range." && v168);
                                            } else {
                                            }
                                            v163.v[v164] = v154;
                                            v164 += 1l ;
                                        }
                                        v259 = US5_4(v55, v56, v57, v58, v163, v60);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v259 = US5_5(v55, v56, v57, v58, v59, v60);
                                    break;
                                }
                                default: { // Raise
                                    if (v85){
                                        bool v172;
                                        v172 = v58 == 0l;
                                        long v173;
                                        if (v172){
                                            v173 = 1l;
                                        } else {
                                            v173 = 0l;
                                        }
                                        long v174;
                                        v174 = -1l + v60;
                                        long v175; long v176;
                                        Tuple1 tmp3 = Tuple1(0l, 0l);
                                        v175 = tmp3.v0; v176 = tmp3.v1;
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
                                                assert("The read index needs to be in range." && v180);
                                            } else {
                                            }
                                            long v182;
                                            v182 = v59.v[v175];
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
                                                assert("The read index needs to be in range." && v190);
                                            } else {
                                            }
                                            v185.v[v186] = v176;
                                            v186 += 1l ;
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
                                                assert("The read index needs to be in range." && v197);
                                            } else {
                                            }
                                            long v199;
                                            v199 = v185.v[v193];
                                            bool v200;
                                            v200 = v193 == v58;
                                            long v202;
                                            if (v200){
                                                long v201;
                                                v201 = v199 + 4l;
                                                v202 = v201;
                                            } else {
                                                v202 = v199;
                                            }
                                            bool v204;
                                            if (v195){
                                                bool v203;
                                                v203 = v193 < 2l;
                                                v204 = v203;
                                            } else {
                                                v204 = false;
                                            }
                                            bool v205;
                                            v205 = v204 == false;
                                            if (v205){
                                                assert("The read index needs to be in range." && v204);
                                            } else {
                                            }
                                            v192.v[v193] = v202;
                                            v193 += 1l ;
                                        }
                                        v259 = US5_2(v55, false, v57, v173, v192, v174);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                        }
                    }
                    return play_loop_inner_1(v0, v1, v2, v259);
                    break;
                }
                default: { // Human
                    return v3;
                }
            }
            break;
        }
        case 3: { // RoundWithAction
            US6 v263 = v3.v.case3.v0; bool v264 = v3.v.case3.v1; static_array<US4,2l> v265 = v3.v.case3.v2; long v266 = v3.v.case3.v3; static_array<long,2l> v267 = v3.v.case3.v4; long v268 = v3.v.case3.v5; US1 v269 = v3.v.case3.v6;
            long v270;
            v270 = v1.length;
            bool v271;
            v271 = v270 < 32l;
            bool v272;
            v272 = v271 == false;
            if (v272){
                assert("The length has to be less than the maximum length of the array." && v271);
            } else {
            }
            long v273;
            v273 = v270 + 1l;
            v1.length = v273;
            bool v274;
            v274 = 0l <= v270;
            bool v277;
            if (v274){
                long v275;
                v275 = v1.length;
                bool v276;
                v276 = v270 < v275;
                v277 = v276;
            } else {
                v277 = false;
            }
            bool v278;
            v278 = v277 == false;
            if (v278){
                assert("The set index needs to be in range." && v277);
            } else {
            }
            US7 v279;
            v279 = US7_1(v266, v269);
            v1.v[v270] = v279;
            US5 v393;
            switch (v263.tag) {
                case 0: { // None
                    switch (v269.tag) {
                        case 0: { // Call
                            if (v264){
                                bool v346;
                                v346 = v266 == 0l;
                                long v347;
                                if (v346){
                                    v347 = 1l;
                                } else {
                                    v347 = 0l;
                                }
                                v393 = US5_2(v263, false, v265, v347, v267, v268);
                            } else {
                                v393 = US5_0(v263, v264, v265, v266, v267, v268);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v393 = US5_5(v263, v264, v265, v266, v267, v268);
                            break;
                        }
                        default: { // Raise
                            bool v351;
                            v351 = v268 > 0l;
                            if (v351){
                                bool v352;
                                v352 = v266 == 0l;
                                long v353;
                                if (v352){
                                    v353 = 1l;
                                } else {
                                    v353 = 0l;
                                }
                                long v354;
                                v354 = -1l + v268;
                                long v355; long v356;
                                Tuple1 tmp4 = Tuple1(0l, 0l);
                                v355 = tmp4.v0; v356 = tmp4.v1;
                                while (while_method_0(v355)){
                                    bool v358;
                                    v358 = 0l <= v355;
                                    bool v360;
                                    if (v358){
                                        bool v359;
                                        v359 = v355 < 2l;
                                        v360 = v359;
                                    } else {
                                        v360 = false;
                                    }
                                    bool v361;
                                    v361 = v360 == false;
                                    if (v361){
                                        assert("The read index needs to be in range." && v360);
                                    } else {
                                    }
                                    long v362;
                                    v362 = v267.v[v355];
                                    bool v363;
                                    v363 = v356 >= v362;
                                    long v364;
                                    if (v363){
                                        v364 = v356;
                                    } else {
                                        v364 = v362;
                                    }
                                    v356 = v364;
                                    v355 += 1l ;
                                }
                                static_array<long,2l> v365;
                                long v366;
                                v366 = 0l;
                                while (while_method_0(v366)){
                                    bool v368;
                                    v368 = 0l <= v366;
                                    bool v370;
                                    if (v368){
                                        bool v369;
                                        v369 = v366 < 2l;
                                        v370 = v369;
                                    } else {
                                        v370 = false;
                                    }
                                    bool v371;
                                    v371 = v370 == false;
                                    if (v371){
                                        assert("The read index needs to be in range." && v370);
                                    } else {
                                    }
                                    v365.v[v366] = v356;
                                    v366 += 1l ;
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
                                        assert("The read index needs to be in range." && v377);
                                    } else {
                                    }
                                    long v379;
                                    v379 = v365.v[v373];
                                    bool v380;
                                    v380 = v373 == v266;
                                    long v382;
                                    if (v380){
                                        long v381;
                                        v381 = v379 + 2l;
                                        v382 = v381;
                                    } else {
                                        v382 = v379;
                                    }
                                    bool v384;
                                    if (v375){
                                        bool v383;
                                        v383 = v373 < 2l;
                                        v384 = v383;
                                    } else {
                                        v384 = false;
                                    }
                                    bool v385;
                                    v385 = v384 == false;
                                    if (v385){
                                        assert("The read index needs to be in range." && v384);
                                    } else {
                                    }
                                    v372.v[v373] = v382;
                                    v373 += 1l ;
                                }
                                v393 = US5_2(v263, false, v265, v353, v372, v354);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                    break;
                }
                default: { // Some
                    US4 v280 = v263.v.case1.v0;
                    switch (v269.tag) {
                        case 0: { // Call
                            if (v264){
                                bool v282;
                                v282 = v266 == 0l;
                                long v283;
                                if (v282){
                                    v283 = 1l;
                                } else {
                                    v283 = 0l;
                                }
                                v393 = US5_2(v263, false, v265, v283, v267, v268);
                            } else {
                                long v285; long v286;
                                Tuple1 tmp5 = Tuple1(0l, 0l);
                                v285 = tmp5.v0; v286 = tmp5.v1;
                                while (while_method_0(v285)){
                                    bool v288;
                                    v288 = 0l <= v285;
                                    bool v290;
                                    if (v288){
                                        bool v289;
                                        v289 = v285 < 2l;
                                        v290 = v289;
                                    } else {
                                        v290 = false;
                                    }
                                    bool v291;
                                    v291 = v290 == false;
                                    if (v291){
                                        assert("The read index needs to be in range." && v290);
                                    } else {
                                    }
                                    long v292;
                                    v292 = v267.v[v285];
                                    bool v293;
                                    v293 = v286 >= v292;
                                    long v294;
                                    if (v293){
                                        v294 = v286;
                                    } else {
                                        v294 = v292;
                                    }
                                    v286 = v294;
                                    v285 += 1l ;
                                }
                                static_array<long,2l> v295;
                                long v296;
                                v296 = 0l;
                                while (while_method_0(v296)){
                                    bool v298;
                                    v298 = 0l <= v296;
                                    bool v300;
                                    if (v298){
                                        bool v299;
                                        v299 = v296 < 2l;
                                        v300 = v299;
                                    } else {
                                        v300 = false;
                                    }
                                    bool v301;
                                    v301 = v300 == false;
                                    if (v301){
                                        assert("The read index needs to be in range." && v300);
                                    } else {
                                    }
                                    v295.v[v296] = v286;
                                    v296 += 1l ;
                                }
                                v393 = US5_4(v263, v264, v265, v266, v295, v268);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v393 = US5_5(v263, v264, v265, v266, v267, v268);
                            break;
                        }
                        default: { // Raise
                            bool v304;
                            v304 = v268 > 0l;
                            if (v304){
                                bool v305;
                                v305 = v266 == 0l;
                                long v306;
                                if (v305){
                                    v306 = 1l;
                                } else {
                                    v306 = 0l;
                                }
                                long v307;
                                v307 = -1l + v268;
                                long v308; long v309;
                                Tuple1 tmp6 = Tuple1(0l, 0l);
                                v308 = tmp6.v0; v309 = tmp6.v1;
                                while (while_method_0(v308)){
                                    bool v311;
                                    v311 = 0l <= v308;
                                    bool v313;
                                    if (v311){
                                        bool v312;
                                        v312 = v308 < 2l;
                                        v313 = v312;
                                    } else {
                                        v313 = false;
                                    }
                                    bool v314;
                                    v314 = v313 == false;
                                    if (v314){
                                        assert("The read index needs to be in range." && v313);
                                    } else {
                                    }
                                    long v315;
                                    v315 = v267.v[v308];
                                    bool v316;
                                    v316 = v309 >= v315;
                                    long v317;
                                    if (v316){
                                        v317 = v309;
                                    } else {
                                        v317 = v315;
                                    }
                                    v309 = v317;
                                    v308 += 1l ;
                                }
                                static_array<long,2l> v318;
                                long v319;
                                v319 = 0l;
                                while (while_method_0(v319)){
                                    bool v321;
                                    v321 = 0l <= v319;
                                    bool v323;
                                    if (v321){
                                        bool v322;
                                        v322 = v319 < 2l;
                                        v323 = v322;
                                    } else {
                                        v323 = false;
                                    }
                                    bool v324;
                                    v324 = v323 == false;
                                    if (v324){
                                        assert("The read index needs to be in range." && v323);
                                    } else {
                                    }
                                    v318.v[v319] = v309;
                                    v319 += 1l ;
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
                                        assert("The read index needs to be in range." && v330);
                                    } else {
                                    }
                                    long v332;
                                    v332 = v318.v[v326];
                                    bool v333;
                                    v333 = v326 == v266;
                                    long v335;
                                    if (v333){
                                        long v334;
                                        v334 = v332 + 4l;
                                        v335 = v334;
                                    } else {
                                        v335 = v332;
                                    }
                                    bool v337;
                                    if (v328){
                                        bool v336;
                                        v336 = v326 < 2l;
                                        v337 = v336;
                                    } else {
                                        v337 = false;
                                    }
                                    bool v338;
                                    v338 = v337 == false;
                                    if (v338){
                                        assert("The read index needs to be in range." && v337);
                                    } else {
                                    }
                                    v325.v[v326] = v335;
                                    v326 += 1l ;
                                }
                                v393 = US5_2(v263, false, v265, v306, v325, v307);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                }
            }
            return play_loop_inner_1(v0, v1, v2, v393);
            break;
        }
        case 4: { // TerminalCall
            US6 v27 = v3.v.case4.v0; bool v28 = v3.v.case4.v1; static_array<US4,2l> v29 = v3.v.case4.v2; long v30 = v3.v.case4.v3; static_array<long,2l> v31 = v3.v.case4.v4; long v32 = v3.v.case4.v5;
            bool v33;
            v33 = 0l <= v30;
            bool v35;
            if (v33){
                bool v34;
                v34 = v30 < 2l;
                v35 = v34;
            } else {
                v35 = false;
            }
            bool v36;
            v36 = v35 == false;
            if (v36){
                assert("The read index needs to be in range." && v35);
            } else {
            }
            long v37;
            v37 = v31.v[v30];
            US9 v38;
            v38 = compare_hands_3(v27, v28, v29, v30, v31, v32);
            long v43; long v44;
            switch (v38.tag) {
                case 0: { // Eq
                    v43 = 0l; v44 = -1l;
                    break;
                }
                case 1: { // Gt
                    v43 = v37; v44 = 0l;
                    break;
                }
                default: { // Lt
                    v43 = v37; v44 = 1l;
                }
            }
            long v45;
            v45 = v1.length;
            bool v46;
            v46 = v45 < 32l;
            bool v47;
            v47 = v46 == false;
            if (v47){
                assert("The length has to be less than the maximum length of the array." && v46);
            } else {
            }
            long v48;
            v48 = v45 + 1l;
            v1.length = v48;
            bool v49;
            v49 = 0l <= v45;
            bool v52;
            if (v49){
                long v50;
                v50 = v1.length;
                bool v51;
                v51 = v45 < v50;
                v52 = v51;
            } else {
                v52 = false;
            }
            bool v53;
            v53 = v52 == false;
            if (v53){
                assert("The set index needs to be in range." && v52);
            } else {
            }
            US7 v54;
            v54 = US7_3(v29, v43, v44);
            v1.v[v45] = v54;
            return v3;
            break;
        }
        default: { // TerminalFold
            US6 v4 = v3.v.case5.v0; bool v5 = v3.v.case5.v1; static_array<US4,2l> v6 = v3.v.case5.v2; long v7 = v3.v.case5.v3; static_array<long,2l> v8 = v3.v.case5.v4; long v9 = v3.v.case5.v5;
            bool v10;
            v10 = 0l <= v7;
            bool v12;
            if (v10){
                bool v11;
                v11 = v7 < 2l;
                v12 = v11;
            } else {
                v12 = false;
            }
            bool v13;
            v13 = v12 == false;
            if (v13){
                assert("The read index needs to be in range." && v12);
            } else {
            }
            long v14;
            v14 = v8.v[v7];
            bool v15;
            v15 = v7 == 0l;
            long v16;
            if (v15){
                v16 = 1l;
            } else {
                v16 = 0l;
            }
            long v17;
            v17 = v1.length;
            bool v18;
            v18 = v17 < 32l;
            bool v19;
            v19 = v18 == false;
            if (v19){
                assert("The length has to be less than the maximum length of the array." && v18);
            } else {
            }
            long v20;
            v20 = v17 + 1l;
            v1.length = v20;
            bool v21;
            v21 = 0l <= v17;
            bool v24;
            if (v21){
                long v22;
                v22 = v1.length;
                bool v23;
                v23 = v17 < v22;
                v24 = v23;
            } else {
                v24 = false;
            }
            bool v25;
            v25 = v24 == false;
            if (v25){
                assert("The set index needs to be in range." && v24);
            } else {
            }
            US7 v26;
            v26 = US7_3(v6, v14, v16);
            v1.v[v17] = v26;
            return v3;
        }
    }
}
__device__ Tuple0 play_loop_0(US3 v0, static_array_list<US7,32l,long> v1, static_array<US2,2l> v2, US8 v3, static_array_list<US4,6l,long> v4, US5 v5){
    US5 v6;
    v6 = play_loop_inner_1(v4, v1, v2, v5);
    switch (v6.tag) {
        case 2: { // Round
            US6 v7 = v6.v.case2.v0; bool v8 = v6.v.case2.v1; static_array<US4,2l> v9 = v6.v.case2.v2; long v10 = v6.v.case2.v3; static_array<long,2l> v11 = v6.v.case2.v4; long v12 = v6.v.case2.v5;
            US3 v13;
            v13 = US3_1(v4, v6);
            US8 v14;
            v14 = US8_2(v7, v8, v9, v10, v11, v12);
            return Tuple0(v13, v1, v2, v14);
            break;
        }
        case 4: { // TerminalCall
            US6 v15 = v6.v.case4.v0; bool v16 = v6.v.case4.v1; static_array<US4,2l> v17 = v6.v.case4.v2; long v18 = v6.v.case4.v3; static_array<long,2l> v19 = v6.v.case4.v4; long v20 = v6.v.case4.v5;
            US3 v21;
            v21 = US3_0();
            US8 v22;
            v22 = US8_1(v15, v16, v17, v18, v19, v20);
            return Tuple0(v21, v1, v2, v22);
            break;
        }
        case 5: { // TerminalFold
            US6 v23 = v6.v.case5.v0; bool v24 = v6.v.case5.v1; static_array<US4,2l> v25 = v6.v.case5.v2; long v26 = v6.v.case5.v3; static_array<long,2l> v27 = v6.v.case5.v4; long v28 = v6.v.case5.v5;
            US3 v29;
            v29 = US3_0();
            US8 v30;
            v30 = US8_1(v23, v24, v25, v26, v27, v28);
            return Tuple0(v29, v1, v2, v30);
            break;
        }
        default: {
            printf("%s\n", "Unexpected node received in play_loop.");
            asm("exit;");
        }
    }
}
extern "C" __global__ void entry0(unsigned char * v0, unsigned char * v1) {
    long v2;
    v2 = threadIdx.x;
    long v3;
    v3 = blockIdx.x;
    long v4;
    v4 = v3 * 512l;
    long v5;
    v5 = v2 + v4;
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
                        assert("The read index needs to be in range." && v33);
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
        long * v38;
        v38 = (long *)(v0+0ull);
        long v39;
        v39 = v38[0l];
        US3 v332;
        switch (v39) {
            case 0: {
                v332 = US3_0();
                break;
            }
            case 1: {
                static_array_list<US4,6l,long> v42;
                v42.length = 0;
                long * v43;
                v43 = (long *)(v0+4ull);
                long v44;
                v44 = v43[0l];
                v42.length = v44;
                long v45;
                v45 = v42.length;
                long v46;
                v46 = 0l;
                while (while_method_1(v45, v46)){
                    unsigned long long v48;
                    v48 = (unsigned long long)v46;
                    unsigned long long v49;
                    v49 = v48 * 4ull;
                    unsigned long long v50;
                    v50 = 8ull + v49;
                    unsigned char * v51;
                    v51 = (unsigned char *)(v0+v50);
                    long * v52;
                    v52 = (long *)(v51+0ull);
                    long v53;
                    v53 = v52[0l];
                    US4 v58;
                    switch (v53) {
                        case 0: {
                            v58 = US4_0();
                            break;
                        }
                        case 1: {
                            v58 = US4_1();
                            break;
                        }
                        case 2: {
                            v58 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v59;
                    v59 = 0l <= v46;
                    bool v62;
                    if (v59){
                        long v60;
                        v60 = v42.length;
                        bool v61;
                        v61 = v46 < v60;
                        v62 = v61;
                    } else {
                        v62 = false;
                    }
                    bool v63;
                    v63 = v62 == false;
                    if (v63){
                        assert("The set index needs to be in range." && v62);
                    } else {
                    }
                    v42.v[v46] = v58;
                    v46 += 1l ;
                }
                long * v64;
                v64 = (long *)(v0+32ull);
                long v65;
                v65 = v64[0l];
                US5 v330;
                switch (v65) {
                    case 0: {
                        long * v67;
                        v67 = (long *)(v0+36ull);
                        long v68;
                        v68 = v67[0l];
                        US6 v79;
                        switch (v68) {
                            case 0: {
                                v79 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v71;
                                v71 = (long *)(v0+40ull);
                                long v72;
                                v72 = v71[0l];
                                US4 v77;
                                switch (v72) {
                                    case 0: {
                                        v77 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v77 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v77 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v79 = US6_1(v77);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v80;
                        v80 = (bool *)(v0+44ull);
                        bool v81;
                        v81 = v80[0l];
                        static_array<US4,2l> v82;
                        long v83;
                        v83 = 0l;
                        while (while_method_0(v83)){
                            unsigned long long v85;
                            v85 = (unsigned long long)v83;
                            unsigned long long v86;
                            v86 = v85 * 4ull;
                            unsigned long long v87;
                            v87 = 48ull + v86;
                            unsigned char * v88;
                            v88 = (unsigned char *)(v0+v87);
                            long * v89;
                            v89 = (long *)(v88+0ull);
                            long v90;
                            v90 = v89[0l];
                            US4 v95;
                            switch (v90) {
                                case 0: {
                                    v95 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v95 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v95 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v96;
                            v96 = 0l <= v83;
                            bool v98;
                            if (v96){
                                bool v97;
                                v97 = v83 < 2l;
                                v98 = v97;
                            } else {
                                v98 = false;
                            }
                            bool v99;
                            v99 = v98 == false;
                            if (v99){
                                assert("The read index needs to be in range." && v98);
                            } else {
                            }
                            v82.v[v83] = v95;
                            v83 += 1l ;
                        }
                        long * v100;
                        v100 = (long *)(v0+56ull);
                        long v101;
                        v101 = v100[0l];
                        static_array<long,2l> v102;
                        long v103;
                        v103 = 0l;
                        while (while_method_0(v103)){
                            unsigned long long v105;
                            v105 = (unsigned long long)v103;
                            unsigned long long v106;
                            v106 = v105 * 4ull;
                            unsigned long long v107;
                            v107 = 60ull + v106;
                            unsigned char * v108;
                            v108 = (unsigned char *)(v0+v107);
                            long * v109;
                            v109 = (long *)(v108+0ull);
                            long v110;
                            v110 = v109[0l];
                            bool v111;
                            v111 = 0l <= v103;
                            bool v113;
                            if (v111){
                                bool v112;
                                v112 = v103 < 2l;
                                v113 = v112;
                            } else {
                                v113 = false;
                            }
                            bool v114;
                            v114 = v113 == false;
                            if (v114){
                                assert("The read index needs to be in range." && v113);
                            } else {
                            }
                            v102.v[v103] = v110;
                            v103 += 1l ;
                        }
                        long * v115;
                        v115 = (long *)(v0+68ull);
                        long v116;
                        v116 = v115[0l];
                        v330 = US5_0(v79, v81, v82, v101, v102, v116);
                        break;
                    }
                    case 1: {
                        v330 = US5_1();
                        break;
                    }
                    case 2: {
                        long * v119;
                        v119 = (long *)(v0+36ull);
                        long v120;
                        v120 = v119[0l];
                        US6 v131;
                        switch (v120) {
                            case 0: {
                                v131 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v123;
                                v123 = (long *)(v0+40ull);
                                long v124;
                                v124 = v123[0l];
                                US4 v129;
                                switch (v124) {
                                    case 0: {
                                        v129 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v129 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v129 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v131 = US6_1(v129);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v132;
                        v132 = (bool *)(v0+44ull);
                        bool v133;
                        v133 = v132[0l];
                        static_array<US4,2l> v134;
                        long v135;
                        v135 = 0l;
                        while (while_method_0(v135)){
                            unsigned long long v137;
                            v137 = (unsigned long long)v135;
                            unsigned long long v138;
                            v138 = v137 * 4ull;
                            unsigned long long v139;
                            v139 = 48ull + v138;
                            unsigned char * v140;
                            v140 = (unsigned char *)(v0+v139);
                            long * v141;
                            v141 = (long *)(v140+0ull);
                            long v142;
                            v142 = v141[0l];
                            US4 v147;
                            switch (v142) {
                                case 0: {
                                    v147 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v147 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v147 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v148;
                            v148 = 0l <= v135;
                            bool v150;
                            if (v148){
                                bool v149;
                                v149 = v135 < 2l;
                                v150 = v149;
                            } else {
                                v150 = false;
                            }
                            bool v151;
                            v151 = v150 == false;
                            if (v151){
                                assert("The read index needs to be in range." && v150);
                            } else {
                            }
                            v134.v[v135] = v147;
                            v135 += 1l ;
                        }
                        long * v152;
                        v152 = (long *)(v0+56ull);
                        long v153;
                        v153 = v152[0l];
                        static_array<long,2l> v154;
                        long v155;
                        v155 = 0l;
                        while (while_method_0(v155)){
                            unsigned long long v157;
                            v157 = (unsigned long long)v155;
                            unsigned long long v158;
                            v158 = v157 * 4ull;
                            unsigned long long v159;
                            v159 = 60ull + v158;
                            unsigned char * v160;
                            v160 = (unsigned char *)(v0+v159);
                            long * v161;
                            v161 = (long *)(v160+0ull);
                            long v162;
                            v162 = v161[0l];
                            bool v163;
                            v163 = 0l <= v155;
                            bool v165;
                            if (v163){
                                bool v164;
                                v164 = v155 < 2l;
                                v165 = v164;
                            } else {
                                v165 = false;
                            }
                            bool v166;
                            v166 = v165 == false;
                            if (v166){
                                assert("The read index needs to be in range." && v165);
                            } else {
                            }
                            v154.v[v155] = v162;
                            v155 += 1l ;
                        }
                        long * v167;
                        v167 = (long *)(v0+68ull);
                        long v168;
                        v168 = v167[0l];
                        v330 = US5_2(v131, v133, v134, v153, v154, v168);
                        break;
                    }
                    case 3: {
                        long * v170;
                        v170 = (long *)(v0+36ull);
                        long v171;
                        v171 = v170[0l];
                        US6 v182;
                        switch (v171) {
                            case 0: {
                                v182 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v174;
                                v174 = (long *)(v0+40ull);
                                long v175;
                                v175 = v174[0l];
                                US4 v180;
                                switch (v175) {
                                    case 0: {
                                        v180 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v180 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v180 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v182 = US6_1(v180);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v183;
                        v183 = (bool *)(v0+44ull);
                        bool v184;
                        v184 = v183[0l];
                        static_array<US4,2l> v185;
                        long v186;
                        v186 = 0l;
                        while (while_method_0(v186)){
                            unsigned long long v188;
                            v188 = (unsigned long long)v186;
                            unsigned long long v189;
                            v189 = v188 * 4ull;
                            unsigned long long v190;
                            v190 = 48ull + v189;
                            unsigned char * v191;
                            v191 = (unsigned char *)(v0+v190);
                            long * v192;
                            v192 = (long *)(v191+0ull);
                            long v193;
                            v193 = v192[0l];
                            US4 v198;
                            switch (v193) {
                                case 0: {
                                    v198 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v198 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v198 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v199;
                            v199 = 0l <= v186;
                            bool v201;
                            if (v199){
                                bool v200;
                                v200 = v186 < 2l;
                                v201 = v200;
                            } else {
                                v201 = false;
                            }
                            bool v202;
                            v202 = v201 == false;
                            if (v202){
                                assert("The read index needs to be in range." && v201);
                            } else {
                            }
                            v185.v[v186] = v198;
                            v186 += 1l ;
                        }
                        long * v203;
                        v203 = (long *)(v0+56ull);
                        long v204;
                        v204 = v203[0l];
                        static_array<long,2l> v205;
                        long v206;
                        v206 = 0l;
                        while (while_method_0(v206)){
                            unsigned long long v208;
                            v208 = (unsigned long long)v206;
                            unsigned long long v209;
                            v209 = v208 * 4ull;
                            unsigned long long v210;
                            v210 = 60ull + v209;
                            unsigned char * v211;
                            v211 = (unsigned char *)(v0+v210);
                            long * v212;
                            v212 = (long *)(v211+0ull);
                            long v213;
                            v213 = v212[0l];
                            bool v214;
                            v214 = 0l <= v206;
                            bool v216;
                            if (v214){
                                bool v215;
                                v215 = v206 < 2l;
                                v216 = v215;
                            } else {
                                v216 = false;
                            }
                            bool v217;
                            v217 = v216 == false;
                            if (v217){
                                assert("The read index needs to be in range." && v216);
                            } else {
                            }
                            v205.v[v206] = v213;
                            v206 += 1l ;
                        }
                        long * v218;
                        v218 = (long *)(v0+68ull);
                        long v219;
                        v219 = v218[0l];
                        long * v220;
                        v220 = (long *)(v0+72ull);
                        long v221;
                        v221 = v220[0l];
                        US1 v226;
                        switch (v221) {
                            case 0: {
                                v226 = US1_0();
                                break;
                            }
                            case 1: {
                                v226 = US1_1();
                                break;
                            }
                            case 2: {
                                v226 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v330 = US5_3(v182, v184, v185, v204, v205, v219, v226);
                        break;
                    }
                    case 4: {
                        long * v228;
                        v228 = (long *)(v0+36ull);
                        long v229;
                        v229 = v228[0l];
                        US6 v240;
                        switch (v229) {
                            case 0: {
                                v240 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v232;
                                v232 = (long *)(v0+40ull);
                                long v233;
                                v233 = v232[0l];
                                US4 v238;
                                switch (v233) {
                                    case 0: {
                                        v238 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v238 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v238 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v240 = US6_1(v238);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v241;
                        v241 = (bool *)(v0+44ull);
                        bool v242;
                        v242 = v241[0l];
                        static_array<US4,2l> v243;
                        long v244;
                        v244 = 0l;
                        while (while_method_0(v244)){
                            unsigned long long v246;
                            v246 = (unsigned long long)v244;
                            unsigned long long v247;
                            v247 = v246 * 4ull;
                            unsigned long long v248;
                            v248 = 48ull + v247;
                            unsigned char * v249;
                            v249 = (unsigned char *)(v0+v248);
                            long * v250;
                            v250 = (long *)(v249+0ull);
                            long v251;
                            v251 = v250[0l];
                            US4 v256;
                            switch (v251) {
                                case 0: {
                                    v256 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v256 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v256 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v257;
                            v257 = 0l <= v244;
                            bool v259;
                            if (v257){
                                bool v258;
                                v258 = v244 < 2l;
                                v259 = v258;
                            } else {
                                v259 = false;
                            }
                            bool v260;
                            v260 = v259 == false;
                            if (v260){
                                assert("The read index needs to be in range." && v259);
                            } else {
                            }
                            v243.v[v244] = v256;
                            v244 += 1l ;
                        }
                        long * v261;
                        v261 = (long *)(v0+56ull);
                        long v262;
                        v262 = v261[0l];
                        static_array<long,2l> v263;
                        long v264;
                        v264 = 0l;
                        while (while_method_0(v264)){
                            unsigned long long v266;
                            v266 = (unsigned long long)v264;
                            unsigned long long v267;
                            v267 = v266 * 4ull;
                            unsigned long long v268;
                            v268 = 60ull + v267;
                            unsigned char * v269;
                            v269 = (unsigned char *)(v0+v268);
                            long * v270;
                            v270 = (long *)(v269+0ull);
                            long v271;
                            v271 = v270[0l];
                            bool v272;
                            v272 = 0l <= v264;
                            bool v274;
                            if (v272){
                                bool v273;
                                v273 = v264 < 2l;
                                v274 = v273;
                            } else {
                                v274 = false;
                            }
                            bool v275;
                            v275 = v274 == false;
                            if (v275){
                                assert("The read index needs to be in range." && v274);
                            } else {
                            }
                            v263.v[v264] = v271;
                            v264 += 1l ;
                        }
                        long * v276;
                        v276 = (long *)(v0+68ull);
                        long v277;
                        v277 = v276[0l];
                        v330 = US5_4(v240, v242, v243, v262, v263, v277);
                        break;
                    }
                    case 5: {
                        long * v279;
                        v279 = (long *)(v0+36ull);
                        long v280;
                        v280 = v279[0l];
                        US6 v291;
                        switch (v280) {
                            case 0: {
                                v291 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v283;
                                v283 = (long *)(v0+40ull);
                                long v284;
                                v284 = v283[0l];
                                US4 v289;
                                switch (v284) {
                                    case 0: {
                                        v289 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v289 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v289 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v291 = US6_1(v289);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v292;
                        v292 = (bool *)(v0+44ull);
                        bool v293;
                        v293 = v292[0l];
                        static_array<US4,2l> v294;
                        long v295;
                        v295 = 0l;
                        while (while_method_0(v295)){
                            unsigned long long v297;
                            v297 = (unsigned long long)v295;
                            unsigned long long v298;
                            v298 = v297 * 4ull;
                            unsigned long long v299;
                            v299 = 48ull + v298;
                            unsigned char * v300;
                            v300 = (unsigned char *)(v0+v299);
                            long * v301;
                            v301 = (long *)(v300+0ull);
                            long v302;
                            v302 = v301[0l];
                            US4 v307;
                            switch (v302) {
                                case 0: {
                                    v307 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v307 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v307 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v308;
                            v308 = 0l <= v295;
                            bool v310;
                            if (v308){
                                bool v309;
                                v309 = v295 < 2l;
                                v310 = v309;
                            } else {
                                v310 = false;
                            }
                            bool v311;
                            v311 = v310 == false;
                            if (v311){
                                assert("The read index needs to be in range." && v310);
                            } else {
                            }
                            v294.v[v295] = v307;
                            v295 += 1l ;
                        }
                        long * v312;
                        v312 = (long *)(v0+56ull);
                        long v313;
                        v313 = v312[0l];
                        static_array<long,2l> v314;
                        long v315;
                        v315 = 0l;
                        while (while_method_0(v315)){
                            unsigned long long v317;
                            v317 = (unsigned long long)v315;
                            unsigned long long v318;
                            v318 = v317 * 4ull;
                            unsigned long long v319;
                            v319 = 60ull + v318;
                            unsigned char * v320;
                            v320 = (unsigned char *)(v0+v319);
                            long * v321;
                            v321 = (long *)(v320+0ull);
                            long v322;
                            v322 = v321[0l];
                            bool v323;
                            v323 = 0l <= v315;
                            bool v325;
                            if (v323){
                                bool v324;
                                v324 = v315 < 2l;
                                v325 = v324;
                            } else {
                                v325 = false;
                            }
                            bool v326;
                            v326 = v325 == false;
                            if (v326){
                                assert("The read index needs to be in range." && v325);
                            } else {
                            }
                            v314.v[v315] = v322;
                            v315 += 1l ;
                        }
                        long * v327;
                        v327 = (long *)(v0+68ull);
                        long v328;
                        v328 = v327[0l];
                        v330 = US5_5(v291, v293, v294, v313, v314, v328);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v332 = US3_1(v42, v330);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US7,32l,long> v333;
        v333.length = 0;
        long * v334;
        v334 = (long *)(v0+76ull);
        long v335;
        v335 = v334[0l];
        v333.length = v335;
        long v336;
        v336 = v333.length;
        long v337;
        v337 = 0l;
        while (while_method_1(v336, v337)){
            unsigned long long v339;
            v339 = (unsigned long long)v337;
            unsigned long long v340;
            v340 = v339 * 32ull;
            unsigned long long v341;
            v341 = 80ull + v340;
            unsigned char * v342;
            v342 = (unsigned char *)(v0+v341);
            long * v343;
            v343 = (long *)(v342+0ull);
            long v344;
            v344 = v343[0l];
            US7 v397;
            switch (v344) {
                case 0: {
                    long * v346;
                    v346 = (long *)(v342+4ull);
                    long v347;
                    v347 = v346[0l];
                    US4 v352;
                    switch (v347) {
                        case 0: {
                            v352 = US4_0();
                            break;
                        }
                        case 1: {
                            v352 = US4_1();
                            break;
                        }
                        case 2: {
                            v352 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v397 = US7_0(v352);
                    break;
                }
                case 1: {
                    long * v354;
                    v354 = (long *)(v342+4ull);
                    long v355;
                    v355 = v354[0l];
                    long * v356;
                    v356 = (long *)(v342+8ull);
                    long v357;
                    v357 = v356[0l];
                    US1 v362;
                    switch (v357) {
                        case 0: {
                            v362 = US1_0();
                            break;
                        }
                        case 1: {
                            v362 = US1_1();
                            break;
                        }
                        case 2: {
                            v362 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v397 = US7_1(v355, v362);
                    break;
                }
                case 2: {
                    long * v364;
                    v364 = (long *)(v342+4ull);
                    long v365;
                    v365 = v364[0l];
                    long * v366;
                    v366 = (long *)(v342+8ull);
                    long v367;
                    v367 = v366[0l];
                    US4 v372;
                    switch (v367) {
                        case 0: {
                            v372 = US4_0();
                            break;
                        }
                        case 1: {
                            v372 = US4_1();
                            break;
                        }
                        case 2: {
                            v372 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v397 = US7_2(v365, v372);
                    break;
                }
                case 3: {
                    static_array<US4,2l> v374;
                    long v375;
                    v375 = 0l;
                    while (while_method_0(v375)){
                        unsigned long long v377;
                        v377 = (unsigned long long)v375;
                        unsigned long long v378;
                        v378 = v377 * 4ull;
                        unsigned long long v379;
                        v379 = 4ull + v378;
                        unsigned char * v380;
                        v380 = (unsigned char *)(v342+v379);
                        long * v381;
                        v381 = (long *)(v380+0ull);
                        long v382;
                        v382 = v381[0l];
                        US4 v387;
                        switch (v382) {
                            case 0: {
                                v387 = US4_0();
                                break;
                            }
                            case 1: {
                                v387 = US4_1();
                                break;
                            }
                            case 2: {
                                v387 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool v388;
                        v388 = 0l <= v375;
                        bool v390;
                        if (v388){
                            bool v389;
                            v389 = v375 < 2l;
                            v390 = v389;
                        } else {
                            v390 = false;
                        }
                        bool v391;
                        v391 = v390 == false;
                        if (v391){
                            assert("The read index needs to be in range." && v390);
                        } else {
                        }
                        v374.v[v375] = v387;
                        v375 += 1l ;
                    }
                    long * v392;
                    v392 = (long *)(v342+12ull);
                    long v393;
                    v393 = v392[0l];
                    long * v394;
                    v394 = (long *)(v342+16ull);
                    long v395;
                    v395 = v394[0l];
                    v397 = US7_3(v374, v393, v395);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v398;
            v398 = 0l <= v337;
            bool v401;
            if (v398){
                long v399;
                v399 = v333.length;
                bool v400;
                v400 = v337 < v399;
                v401 = v400;
            } else {
                v401 = false;
            }
            bool v402;
            v402 = v401 == false;
            if (v402){
                assert("The set index needs to be in range." && v401);
            } else {
            }
            v333.v[v337] = v397;
            v337 += 1l ;
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
                assert("The read index needs to be in range." && v418);
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
                US6 v436;
                switch (v425) {
                    case 0: {
                        v436 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v428;
                        v428 = (long *)(v0+1120ull);
                        long v429;
                        v429 = v428[0l];
                        US4 v434;
                        switch (v429) {
                            case 0: {
                                v434 = US4_0();
                                break;
                            }
                            case 1: {
                                v434 = US4_1();
                                break;
                            }
                            case 2: {
                                v434 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v436 = US6_1(v434);
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
                static_array<US4,2l> v439;
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
                    US4 v452;
                    switch (v447) {
                        case 0: {
                            v452 = US4_0();
                            break;
                        }
                        case 1: {
                            v452 = US4_1();
                            break;
                        }
                        case 2: {
                            v452 = US4_2();
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
                        assert("The read index needs to be in range." && v455);
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
                        assert("The read index needs to be in range." && v470);
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
                US6 v487;
                switch (v476) {
                    case 0: {
                        v487 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v479;
                        v479 = (long *)(v0+1120ull);
                        long v480;
                        v480 = v479[0l];
                        US4 v485;
                        switch (v480) {
                            case 0: {
                                v485 = US4_0();
                                break;
                            }
                            case 1: {
                                v485 = US4_1();
                                break;
                            }
                            case 2: {
                                v485 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v487 = US6_1(v485);
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
                static_array<US4,2l> v490;
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
                    US4 v503;
                    switch (v498) {
                        case 0: {
                            v503 = US4_0();
                            break;
                        }
                        case 1: {
                            v503 = US4_1();
                            break;
                        }
                        case 2: {
                            v503 = US4_2();
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
                        assert("The read index needs to be in range." && v506);
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
                        assert("The read index needs to be in range." && v521);
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
        US3 v636; static_array_list<US7,32l,long> v637; static_array<US2,2l> v638; US8 v639;
        switch (v37.tag) {
            case 0: { // ActionSelected
                US1 v598 = v37.v.case0.v0;
                switch (v332.tag) {
                    case 0: { // None
                        v636 = v332; v637 = v333; v638 = v403; v639 = v526;
                        break;
                    }
                    default: { // Some
                        static_array_list<US4,6l,long> v599 = v332.v.case1.v0; US5 v600 = v332.v.case1.v1;
                        switch (v600.tag) {
                            case 2: { // Round
                                US6 v601 = v600.v.case2.v0; bool v602 = v600.v.case2.v1; static_array<US4,2l> v603 = v600.v.case2.v2; long v604 = v600.v.case2.v3; static_array<long,2l> v605 = v600.v.case2.v4; long v606 = v600.v.case2.v5;
                                US5 v607;
                                v607 = US5_3(v601, v602, v603, v604, v605, v606, v598);
                                Tuple0 tmp9 = play_loop_0(v332, v333, v403, v526, v599, v607);
                                v636 = tmp9.v0; v637 = tmp9.v1; v638 = tmp9.v2; v639 = tmp9.v3;
                                break;
                            }
                            default: {
                                printf("%s\n", "Unexpected game node in ActionSelected.");
                                asm("exit;");
                            }
                        }
                    }
                }
                break;
            }
            case 1: { // PlayerChanged
                static_array<US2,2l> v597 = v37.v.case1.v0;
                v636 = v332; v637 = v333; v638 = v597; v639 = v526;
                break;
            }
            default: { // StartGame
                static_array<US2,2l> v527;
                US2 v528;
                v528 = US2_0();
                v527.v[0l] = v528;
                US2 v529;
                v529 = US2_1();
                v527.v[1l] = v529;
                static_array_list<US7,32l,long> v530;
                v530.length = 0;
                US3 v531;
                v531 = US3_0();
                US8 v532;
                v532 = US8_0();
                static_array_list<US4,6l,long> v533;
                v533.length = 0;
                v533.length = 6l;
                long v534;
                v534 = v533.length;
                bool v535;
                v535 = 0l < v534;
                bool v536;
                v536 = v535 == false;
                if (v536){
                    assert("The set index needs to be in range." && v535);
                } else {
                }
                US4 v537;
                v537 = US4_1();
                v533.v[0l] = v537;
                long v538;
                v538 = v533.length;
                bool v539;
                v539 = 1l < v538;
                bool v540;
                v540 = v539 == false;
                if (v540){
                    assert("The set index needs to be in range." && v539);
                } else {
                }
                US4 v541;
                v541 = US4_1();
                v533.v[1l] = v541;
                long v542;
                v542 = v533.length;
                bool v543;
                v543 = 2l < v542;
                bool v544;
                v544 = v543 == false;
                if (v544){
                    assert("The set index needs to be in range." && v543);
                } else {
                }
                US4 v545;
                v545 = US4_2();
                v533.v[2l] = v545;
                long v546;
                v546 = v533.length;
                bool v547;
                v547 = 3l < v546;
                bool v548;
                v548 = v547 == false;
                if (v548){
                    assert("The set index needs to be in range." && v547);
                } else {
                }
                US4 v549;
                v549 = US4_2();
                v533.v[3l] = v549;
                long v550;
                v550 = v533.length;
                bool v551;
                v551 = 4l < v550;
                bool v552;
                v552 = v551 == false;
                if (v552){
                    assert("The set index needs to be in range." && v551);
                } else {
                }
                US4 v553;
                v553 = US4_0();
                v533.v[4l] = v553;
                long v554;
                v554 = v533.length;
                bool v555;
                v555 = 5l < v554;
                bool v556;
                v556 = v555 == false;
                if (v556){
                    assert("The set index needs to be in range." && v555);
                } else {
                }
                US4 v557;
                v557 = US4_0();
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
                    v570 = v568 - v569;
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
                        assert("The read index needs to be in range." && v575);
                    } else {
                    }
                    US4 v577;
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
                        assert("The read index needs to be in range." && v581);
                    } else {
                    }
                    US4 v583;
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
                        assert("The set index needs to be in range." && v586);
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
                        assert("The set index needs to be in range." && v590);
                    } else {
                    }
                    v533.v[v571] = v577;
                    v563 += 1l ;
                }
                US5 v592;
                v592 = US5_1();
                Tuple0 tmp10 = play_loop_0(v531, v530, v527, v532, v533, v592);
                v636 = tmp10.v0; v637 = tmp10.v1; v638 = tmp10.v2; v639 = tmp10.v3;
            }
        }
        long v640;
        v640 = v636.tag;
        long * v641;
        v641 = (long *)(v0+0ull);
        v641[0l] = v640;
        switch (v636.tag) {
            case 0: { // None
                break;
            }
            default: { // Some
                static_array_list<US4,6l,long> v642 = v636.v.case1.v0; US5 v643 = v636.v.case1.v1;
                long v644;
                v644 = v642.length;
                long * v645;
                v645 = (long *)(v0+4ull);
                v645[0l] = v644;
                long v646;
                v646 = v642.length;
                long v647;
                v647 = 0l;
                while (while_method_1(v646, v647)){
                    unsigned long long v649;
                    v649 = (unsigned long long)v647;
                    unsigned long long v650;
                    v650 = v649 * 4ull;
                    unsigned long long v651;
                    v651 = 8ull + v650;
                    unsigned char * v652;
                    v652 = (unsigned char *)(v0+v651);
                    bool v653;
                    v653 = 0l <= v647;
                    bool v656;
                    if (v653){
                        long v654;
                        v654 = v642.length;
                        bool v655;
                        v655 = v647 < v654;
                        v656 = v655;
                    } else {
                        v656 = false;
                    }
                    bool v657;
                    v657 = v656 == false;
                    if (v657){
                        assert("The read index needs to be in range." && v656);
                    } else {
                    }
                    US4 v658;
                    v658 = v642.v[v647];
                    long v659;
                    v659 = v658.tag;
                    long * v660;
                    v660 = (long *)(v652+0ull);
                    v660[0l] = v659;
                    switch (v658.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v647 += 1l ;
                }
                long v661;
                v661 = v643.tag;
                long * v662;
                v662 = (long *)(v0+32ull);
                v662[0l] = v661;
                switch (v643.tag) {
                    case 0: { // ChanceCommunityCard
                        US6 v663 = v643.v.case0.v0; bool v664 = v643.v.case0.v1; static_array<US4,2l> v665 = v643.v.case0.v2; long v666 = v643.v.case0.v3; static_array<long,2l> v667 = v643.v.case0.v4; long v668 = v643.v.case0.v5;
                        long v669;
                        v669 = v663.tag;
                        long * v670;
                        v670 = (long *)(v0+36ull);
                        v670[0l] = v669;
                        switch (v663.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v671 = v663.v.case1.v0;
                                long v672;
                                v672 = v671.tag;
                                long * v673;
                                v673 = (long *)(v0+40ull);
                                v673[0l] = v672;
                                switch (v671.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                            }
                        }
                        bool * v674;
                        v674 = (bool *)(v0+44ull);
                        v674[0l] = v664;
                        long v675;
                        v675 = 0l;
                        while (while_method_0(v675)){
                            unsigned long long v677;
                            v677 = (unsigned long long)v675;
                            unsigned long long v678;
                            v678 = v677 * 4ull;
                            unsigned long long v679;
                            v679 = 48ull + v678;
                            unsigned char * v680;
                            v680 = (unsigned char *)(v0+v679);
                            bool v681;
                            v681 = 0l <= v675;
                            bool v683;
                            if (v681){
                                bool v682;
                                v682 = v675 < 2l;
                                v683 = v682;
                            } else {
                                v683 = false;
                            }
                            bool v684;
                            v684 = v683 == false;
                            if (v684){
                                assert("The read index needs to be in range." && v683);
                            } else {
                            }
                            US4 v685;
                            v685 = v665.v[v675];
                            long v686;
                            v686 = v685.tag;
                            long * v687;
                            v687 = (long *)(v680+0ull);
                            v687[0l] = v686;
                            switch (v685.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v675 += 1l ;
                        }
                        long * v688;
                        v688 = (long *)(v0+56ull);
                        v688[0l] = v666;
                        long v689;
                        v689 = 0l;
                        while (while_method_0(v689)){
                            unsigned long long v691;
                            v691 = (unsigned long long)v689;
                            unsigned long long v692;
                            v692 = v691 * 4ull;
                            unsigned long long v693;
                            v693 = 60ull + v692;
                            unsigned char * v694;
                            v694 = (unsigned char *)(v0+v693);
                            bool v695;
                            v695 = 0l <= v689;
                            bool v697;
                            if (v695){
                                bool v696;
                                v696 = v689 < 2l;
                                v697 = v696;
                            } else {
                                v697 = false;
                            }
                            bool v698;
                            v698 = v697 == false;
                            if (v698){
                                assert("The read index needs to be in range." && v697);
                            } else {
                            }
                            long v699;
                            v699 = v667.v[v689];
                            long * v700;
                            v700 = (long *)(v694+0ull);
                            v700[0l] = v699;
                            v689 += 1l ;
                        }
                        long * v701;
                        v701 = (long *)(v0+68ull);
                        v701[0l] = v668;
                        break;
                    }
                    case 1: { // ChanceInit
                        break;
                    }
                    case 2: { // Round
                        US6 v702 = v643.v.case2.v0; bool v703 = v643.v.case2.v1; static_array<US4,2l> v704 = v643.v.case2.v2; long v705 = v643.v.case2.v3; static_array<long,2l> v706 = v643.v.case2.v4; long v707 = v643.v.case2.v5;
                        long v708;
                        v708 = v702.tag;
                        long * v709;
                        v709 = (long *)(v0+36ull);
                        v709[0l] = v708;
                        switch (v702.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v710 = v702.v.case1.v0;
                                long v711;
                                v711 = v710.tag;
                                long * v712;
                                v712 = (long *)(v0+40ull);
                                v712[0l] = v711;
                                switch (v710.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                            }
                        }
                        bool * v713;
                        v713 = (bool *)(v0+44ull);
                        v713[0l] = v703;
                        long v714;
                        v714 = 0l;
                        while (while_method_0(v714)){
                            unsigned long long v716;
                            v716 = (unsigned long long)v714;
                            unsigned long long v717;
                            v717 = v716 * 4ull;
                            unsigned long long v718;
                            v718 = 48ull + v717;
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
                                assert("The read index needs to be in range." && v722);
                            } else {
                            }
                            US4 v724;
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
                                default: { // Queen
                                }
                            }
                            v714 += 1l ;
                        }
                        long * v727;
                        v727 = (long *)(v0+56ull);
                        v727[0l] = v705;
                        long v728;
                        v728 = 0l;
                        while (while_method_0(v728)){
                            unsigned long long v730;
                            v730 = (unsigned long long)v728;
                            unsigned long long v731;
                            v731 = v730 * 4ull;
                            unsigned long long v732;
                            v732 = 60ull + v731;
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
                                assert("The read index needs to be in range." && v736);
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
                        v740 = (long *)(v0+68ull);
                        v740[0l] = v707;
                        break;
                    }
                    case 3: { // RoundWithAction
                        US6 v741 = v643.v.case3.v0; bool v742 = v643.v.case3.v1; static_array<US4,2l> v743 = v643.v.case3.v2; long v744 = v643.v.case3.v3; static_array<long,2l> v745 = v643.v.case3.v4; long v746 = v643.v.case3.v5; US1 v747 = v643.v.case3.v6;
                        long v748;
                        v748 = v741.tag;
                        long * v749;
                        v749 = (long *)(v0+36ull);
                        v749[0l] = v748;
                        switch (v741.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v750 = v741.v.case1.v0;
                                long v751;
                                v751 = v750.tag;
                                long * v752;
                                v752 = (long *)(v0+40ull);
                                v752[0l] = v751;
                                switch (v750.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                            }
                        }
                        bool * v753;
                        v753 = (bool *)(v0+44ull);
                        v753[0l] = v742;
                        long v754;
                        v754 = 0l;
                        while (while_method_0(v754)){
                            unsigned long long v756;
                            v756 = (unsigned long long)v754;
                            unsigned long long v757;
                            v757 = v756 * 4ull;
                            unsigned long long v758;
                            v758 = 48ull + v757;
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
                                assert("The read index needs to be in range." && v762);
                            } else {
                            }
                            US4 v764;
                            v764 = v743.v[v754];
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
                                default: { // Queen
                                }
                            }
                            v754 += 1l ;
                        }
                        long * v767;
                        v767 = (long *)(v0+56ull);
                        v767[0l] = v744;
                        long v768;
                        v768 = 0l;
                        while (while_method_0(v768)){
                            unsigned long long v770;
                            v770 = (unsigned long long)v768;
                            unsigned long long v771;
                            v771 = v770 * 4ull;
                            unsigned long long v772;
                            v772 = 60ull + v771;
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
                                assert("The read index needs to be in range." && v776);
                            } else {
                            }
                            long v778;
                            v778 = v745.v[v768];
                            long * v779;
                            v779 = (long *)(v773+0ull);
                            v779[0l] = v778;
                            v768 += 1l ;
                        }
                        long * v780;
                        v780 = (long *)(v0+68ull);
                        v780[0l] = v746;
                        long v781;
                        v781 = v747.tag;
                        long * v782;
                        v782 = (long *)(v0+72ull);
                        v782[0l] = v781;
                        switch (v747.tag) {
                            case 0: { // Call
                                break;
                            }
                            case 1: { // Fold
                                break;
                            }
                            default: { // Raise
                            }
                        }
                        break;
                    }
                    case 4: { // TerminalCall
                        US6 v783 = v643.v.case4.v0; bool v784 = v643.v.case4.v1; static_array<US4,2l> v785 = v643.v.case4.v2; long v786 = v643.v.case4.v3; static_array<long,2l> v787 = v643.v.case4.v4; long v788 = v643.v.case4.v5;
                        long v789;
                        v789 = v783.tag;
                        long * v790;
                        v790 = (long *)(v0+36ull);
                        v790[0l] = v789;
                        switch (v783.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v791 = v783.v.case1.v0;
                                long v792;
                                v792 = v791.tag;
                                long * v793;
                                v793 = (long *)(v0+40ull);
                                v793[0l] = v792;
                                switch (v791.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                            }
                        }
                        bool * v794;
                        v794 = (bool *)(v0+44ull);
                        v794[0l] = v784;
                        long v795;
                        v795 = 0l;
                        while (while_method_0(v795)){
                            unsigned long long v797;
                            v797 = (unsigned long long)v795;
                            unsigned long long v798;
                            v798 = v797 * 4ull;
                            unsigned long long v799;
                            v799 = 48ull + v798;
                            unsigned char * v800;
                            v800 = (unsigned char *)(v0+v799);
                            bool v801;
                            v801 = 0l <= v795;
                            bool v803;
                            if (v801){
                                bool v802;
                                v802 = v795 < 2l;
                                v803 = v802;
                            } else {
                                v803 = false;
                            }
                            bool v804;
                            v804 = v803 == false;
                            if (v804){
                                assert("The read index needs to be in range." && v803);
                            } else {
                            }
                            US4 v805;
                            v805 = v785.v[v795];
                            long v806;
                            v806 = v805.tag;
                            long * v807;
                            v807 = (long *)(v800+0ull);
                            v807[0l] = v806;
                            switch (v805.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v795 += 1l ;
                        }
                        long * v808;
                        v808 = (long *)(v0+56ull);
                        v808[0l] = v786;
                        long v809;
                        v809 = 0l;
                        while (while_method_0(v809)){
                            unsigned long long v811;
                            v811 = (unsigned long long)v809;
                            unsigned long long v812;
                            v812 = v811 * 4ull;
                            unsigned long long v813;
                            v813 = 60ull + v812;
                            unsigned char * v814;
                            v814 = (unsigned char *)(v0+v813);
                            bool v815;
                            v815 = 0l <= v809;
                            bool v817;
                            if (v815){
                                bool v816;
                                v816 = v809 < 2l;
                                v817 = v816;
                            } else {
                                v817 = false;
                            }
                            bool v818;
                            v818 = v817 == false;
                            if (v818){
                                assert("The read index needs to be in range." && v817);
                            } else {
                            }
                            long v819;
                            v819 = v787.v[v809];
                            long * v820;
                            v820 = (long *)(v814+0ull);
                            v820[0l] = v819;
                            v809 += 1l ;
                        }
                        long * v821;
                        v821 = (long *)(v0+68ull);
                        v821[0l] = v788;
                        break;
                    }
                    default: { // TerminalFold
                        US6 v822 = v643.v.case5.v0; bool v823 = v643.v.case5.v1; static_array<US4,2l> v824 = v643.v.case5.v2; long v825 = v643.v.case5.v3; static_array<long,2l> v826 = v643.v.case5.v4; long v827 = v643.v.case5.v5;
                        long v828;
                        v828 = v822.tag;
                        long * v829;
                        v829 = (long *)(v0+36ull);
                        v829[0l] = v828;
                        switch (v822.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v830 = v822.v.case1.v0;
                                long v831;
                                v831 = v830.tag;
                                long * v832;
                                v832 = (long *)(v0+40ull);
                                v832[0l] = v831;
                                switch (v830.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                            }
                        }
                        bool * v833;
                        v833 = (bool *)(v0+44ull);
                        v833[0l] = v823;
                        long v834;
                        v834 = 0l;
                        while (while_method_0(v834)){
                            unsigned long long v836;
                            v836 = (unsigned long long)v834;
                            unsigned long long v837;
                            v837 = v836 * 4ull;
                            unsigned long long v838;
                            v838 = 48ull + v837;
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
                                assert("The read index needs to be in range." && v842);
                            } else {
                            }
                            US4 v844;
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
                                default: { // Queen
                                }
                            }
                            v834 += 1l ;
                        }
                        long * v847;
                        v847 = (long *)(v0+56ull);
                        v847[0l] = v825;
                        long v848;
                        v848 = 0l;
                        while (while_method_0(v848)){
                            unsigned long long v850;
                            v850 = (unsigned long long)v848;
                            unsigned long long v851;
                            v851 = v850 * 4ull;
                            unsigned long long v852;
                            v852 = 60ull + v851;
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
                                assert("The read index needs to be in range." && v856);
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
                        v860 = (long *)(v0+68ull);
                        v860[0l] = v827;
                    }
                }
            }
        }
        long v861;
        v861 = v637.length;
        long * v862;
        v862 = (long *)(v0+76ull);
        v862[0l] = v861;
        long v863;
        v863 = v637.length;
        long v864;
        v864 = 0l;
        while (while_method_1(v863, v864)){
            unsigned long long v866;
            v866 = (unsigned long long)v864;
            unsigned long long v867;
            v867 = v866 * 32ull;
            unsigned long long v868;
            v868 = 80ull + v867;
            unsigned char * v869;
            v869 = (unsigned char *)(v0+v868);
            bool v870;
            v870 = 0l <= v864;
            bool v873;
            if (v870){
                long v871;
                v871 = v637.length;
                bool v872;
                v872 = v864 < v871;
                v873 = v872;
            } else {
                v873 = false;
            }
            bool v874;
            v874 = v873 == false;
            if (v874){
                assert("The read index needs to be in range." && v873);
            } else {
            }
            US7 v875;
            v875 = v637.v[v864];
            long v876;
            v876 = v875.tag;
            long * v877;
            v877 = (long *)(v869+0ull);
            v877[0l] = v876;
            switch (v875.tag) {
                case 0: { // CommunityCardIs
                    US4 v878 = v875.v.case0.v0;
                    long v879;
                    v879 = v878.tag;
                    long * v880;
                    v880 = (long *)(v869+4ull);
                    v880[0l] = v879;
                    switch (v878.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    break;
                }
                case 1: { // PlayerAction
                    long v881 = v875.v.case1.v0; US1 v882 = v875.v.case1.v1;
                    long * v883;
                    v883 = (long *)(v869+4ull);
                    v883[0l] = v881;
                    long v884;
                    v884 = v882.tag;
                    long * v885;
                    v885 = (long *)(v869+8ull);
                    v885[0l] = v884;
                    switch (v882.tag) {
                        case 0: { // Call
                            break;
                        }
                        case 1: { // Fold
                            break;
                        }
                        default: { // Raise
                        }
                    }
                    break;
                }
                case 2: { // PlayerGotCard
                    long v886 = v875.v.case2.v0; US4 v887 = v875.v.case2.v1;
                    long * v888;
                    v888 = (long *)(v869+4ull);
                    v888[0l] = v886;
                    long v889;
                    v889 = v887.tag;
                    long * v890;
                    v890 = (long *)(v869+8ull);
                    v890[0l] = v889;
                    switch (v887.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    break;
                }
                default: { // Showdown
                    static_array<US4,2l> v891 = v875.v.case3.v0; long v892 = v875.v.case3.v1; long v893 = v875.v.case3.v2;
                    long v894;
                    v894 = 0l;
                    while (while_method_0(v894)){
                        unsigned long long v896;
                        v896 = (unsigned long long)v894;
                        unsigned long long v897;
                        v897 = v896 * 4ull;
                        unsigned long long v898;
                        v898 = 4ull + v897;
                        unsigned char * v899;
                        v899 = (unsigned char *)(v869+v898);
                        bool v900;
                        v900 = 0l <= v894;
                        bool v902;
                        if (v900){
                            bool v901;
                            v901 = v894 < 2l;
                            v902 = v901;
                        } else {
                            v902 = false;
                        }
                        bool v903;
                        v903 = v902 == false;
                        if (v903){
                            assert("The read index needs to be in range." && v902);
                        } else {
                        }
                        US4 v904;
                        v904 = v891.v[v894];
                        long v905;
                        v905 = v904.tag;
                        long * v906;
                        v906 = (long *)(v899+0ull);
                        v906[0l] = v905;
                        switch (v904.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            default: { // Queen
                            }
                        }
                        v894 += 1l ;
                    }
                    long * v907;
                    v907 = (long *)(v869+12ull);
                    v907[0l] = v892;
                    long * v908;
                    v908 = (long *)(v869+16ull);
                    v908[0l] = v893;
                }
            }
            v864 += 1l ;
        }
        long v909;
        v909 = 0l;
        while (while_method_0(v909)){
            unsigned long long v911;
            v911 = (unsigned long long)v909;
            unsigned long long v912;
            v912 = v911 * 4ull;
            unsigned long long v913;
            v913 = 1104ull + v912;
            unsigned char * v914;
            v914 = (unsigned char *)(v0+v913);
            bool v915;
            v915 = 0l <= v909;
            bool v917;
            if (v915){
                bool v916;
                v916 = v909 < 2l;
                v917 = v916;
            } else {
                v917 = false;
            }
            bool v918;
            v918 = v917 == false;
            if (v918){
                assert("The read index needs to be in range." && v917);
            } else {
            }
            US2 v919;
            v919 = v638.v[v909];
            long v920;
            v920 = v919.tag;
            long * v921;
            v921 = (long *)(v914+0ull);
            v921[0l] = v920;
            switch (v919.tag) {
                case 0: { // Computer
                    break;
                }
                default: { // Human
                }
            }
            v909 += 1l ;
        }
        long v922;
        v922 = v639.tag;
        long * v923;
        v923 = (long *)(v0+1112ull);
        v923[0l] = v922;
        switch (v639.tag) {
            case 0: { // GameNotStarted
                return ;
                break;
            }
            case 1: { // GameOver
                US6 v924 = v639.v.case1.v0; bool v925 = v639.v.case1.v1; static_array<US4,2l> v926 = v639.v.case1.v2; long v927 = v639.v.case1.v3; static_array<long,2l> v928 = v639.v.case1.v4; long v929 = v639.v.case1.v5;
                long v930;
                v930 = v924.tag;
                long * v931;
                v931 = (long *)(v0+1116ull);
                v931[0l] = v930;
                switch (v924.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US4 v932 = v924.v.case1.v0;
                        long v933;
                        v933 = v932.tag;
                        long * v934;
                        v934 = (long *)(v0+1120ull);
                        v934[0l] = v933;
                        switch (v932.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            default: { // Queen
                            }
                        }
                    }
                }
                bool * v935;
                v935 = (bool *)(v0+1124ull);
                v935[0l] = v925;
                long v936;
                v936 = 0l;
                while (while_method_0(v936)){
                    unsigned long long v938;
                    v938 = (unsigned long long)v936;
                    unsigned long long v939;
                    v939 = v938 * 4ull;
                    unsigned long long v940;
                    v940 = 1128ull + v939;
                    unsigned char * v941;
                    v941 = (unsigned char *)(v0+v940);
                    bool v942;
                    v942 = 0l <= v936;
                    bool v944;
                    if (v942){
                        bool v943;
                        v943 = v936 < 2l;
                        v944 = v943;
                    } else {
                        v944 = false;
                    }
                    bool v945;
                    v945 = v944 == false;
                    if (v945){
                        assert("The read index needs to be in range." && v944);
                    } else {
                    }
                    US4 v946;
                    v946 = v926.v[v936];
                    long v947;
                    v947 = v946.tag;
                    long * v948;
                    v948 = (long *)(v941+0ull);
                    v948[0l] = v947;
                    switch (v946.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v936 += 1l ;
                }
                long * v949;
                v949 = (long *)(v0+1136ull);
                v949[0l] = v927;
                long v950;
                v950 = 0l;
                while (while_method_0(v950)){
                    unsigned long long v952;
                    v952 = (unsigned long long)v950;
                    unsigned long long v953;
                    v953 = v952 * 4ull;
                    unsigned long long v954;
                    v954 = 1140ull + v953;
                    unsigned char * v955;
                    v955 = (unsigned char *)(v0+v954);
                    bool v956;
                    v956 = 0l <= v950;
                    bool v958;
                    if (v956){
                        bool v957;
                        v957 = v950 < 2l;
                        v958 = v957;
                    } else {
                        v958 = false;
                    }
                    bool v959;
                    v959 = v958 == false;
                    if (v959){
                        assert("The read index needs to be in range." && v958);
                    } else {
                    }
                    long v960;
                    v960 = v928.v[v950];
                    long * v961;
                    v961 = (long *)(v955+0ull);
                    v961[0l] = v960;
                    v950 += 1l ;
                }
                long * v962;
                v962 = (long *)(v0+1148ull);
                v962[0l] = v929;
                return ;
                break;
            }
            default: { // WaitingForActionFromPlayerId
                US6 v963 = v639.v.case2.v0; bool v964 = v639.v.case2.v1; static_array<US4,2l> v965 = v639.v.case2.v2; long v966 = v639.v.case2.v3; static_array<long,2l> v967 = v639.v.case2.v4; long v968 = v639.v.case2.v5;
                long v969;
                v969 = v963.tag;
                long * v970;
                v970 = (long *)(v0+1116ull);
                v970[0l] = v969;
                switch (v963.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US4 v971 = v963.v.case1.v0;
                        long v972;
                        v972 = v971.tag;
                        long * v973;
                        v973 = (long *)(v0+1120ull);
                        v973[0l] = v972;
                        switch (v971.tag) {
                            case 0: { // Jack
                                break;
                            }
                            case 1: { // King
                                break;
                            }
                            default: { // Queen
                            }
                        }
                    }
                }
                bool * v974;
                v974 = (bool *)(v0+1124ull);
                v974[0l] = v964;
                long v975;
                v975 = 0l;
                while (while_method_0(v975)){
                    unsigned long long v977;
                    v977 = (unsigned long long)v975;
                    unsigned long long v978;
                    v978 = v977 * 4ull;
                    unsigned long long v979;
                    v979 = 1128ull + v978;
                    unsigned char * v980;
                    v980 = (unsigned char *)(v0+v979);
                    bool v981;
                    v981 = 0l <= v975;
                    bool v983;
                    if (v981){
                        bool v982;
                        v982 = v975 < 2l;
                        v983 = v982;
                    } else {
                        v983 = false;
                    }
                    bool v984;
                    v984 = v983 == false;
                    if (v984){
                        assert("The read index needs to be in range." && v983);
                    } else {
                    }
                    US4 v985;
                    v985 = v965.v[v975];
                    long v986;
                    v986 = v985.tag;
                    long * v987;
                    v987 = (long *)(v980+0ull);
                    v987[0l] = v986;
                    switch (v985.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v975 += 1l ;
                }
                long * v988;
                v988 = (long *)(v0+1136ull);
                v988[0l] = v966;
                long v989;
                v989 = 0l;
                while (while_method_0(v989)){
                    unsigned long long v991;
                    v991 = (unsigned long long)v989;
                    unsigned long long v992;
                    v992 = v991 * 4ull;
                    unsigned long long v993;
                    v993 = 1140ull + v992;
                    unsigned char * v994;
                    v994 = (unsigned char *)(v0+v993);
                    bool v995;
                    v995 = 0l <= v989;
                    bool v997;
                    if (v995){
                        bool v996;
                        v996 = v989 < 2l;
                        v997 = v996;
                    } else {
                        v997 = false;
                    }
                    bool v998;
                    v998 = v997 == false;
                    if (v998){
                        assert("The read index needs to be in range." && v997);
                    } else {
                    }
                    long v999;
                    v999 = v967.v[v989];
                    long * v1000;
                    v1000 = (long *)(v994+0ull);
                    v1000[0l] = v999;
                    v989 += 1l ;
                }
                long * v1001;
                v1001 = (long *)(v0+1148ull);
                v1001[0l] = v968;
                return ;
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
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
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
    v0 : static_array_list
    v1 : US4
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
class US9_0(NamedTuple): # Eq
    tag = 0
class US9_1(NamedTuple): # Gt
    tag = 1
class US9_2(NamedTuple): # Lt
    tag = 2
US9 = Union[US9_0, US9_1, US9_2]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6 = method5(v1)
        match v2:
            case US0_0(v80): # ActionSelected
                match v3:
                    case US3_0(): # None
                        del v80
                        v118, v119, v120, v121 = v3, v4, v5, v6
                    case US3_1(v81, v82): # Some
                        match v82:
                            case US4_2(v83, v84, v85, v86, v87, v88): # Round
                                del v82
                                v89 = US4_3(v83, v84, v85, v86, v87, v88, v80)
                                del v80, v83, v84, v85, v86, v87, v88
                                v118, v119, v120, v121 = method12(v3, v4, v5, v6, v81, v89)
                            case t:
                                del v80, v81, v82
                                raise Exception("Unexpected game node in ActionSelected.")
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US0_1(v79): # PlayerChanged
                v118, v119, v120, v121 = v3, v4, v79, v6
            case US0_2(): # StartGame
                v7 = static_array(2)
                v8 = US2_0()
                v7[0] = v8
                del v8
                v9 = US2_1()
                v7[1] = v9
                del v9
                v10 = static_array_list(32)
                v11 = US3_0()
                v12 = US7_0()
                v13 = static_array_list(6)
                v13.length = 6
                v14 = v13.length
                v15 = 0 < v14
                del v14
                v16 = v15 == False
                if v16:
                    v17 = "The set index needs to be in range."
                    assert v15, v17
                    del v17
                else:
                    pass
                del v15, v16
                v18 = US6_1()
                v13[0] = v18
                del v18
                v19 = v13.length
                v20 = 1 < v19
                del v19
                v21 = v20 == False
                if v21:
                    v22 = "The set index needs to be in range."
                    assert v20, v22
                    del v22
                else:
                    pass
                del v20, v21
                v23 = US6_1()
                v13[1] = v23
                del v23
                v24 = v13.length
                v25 = 2 < v24
                del v24
                v26 = v25 == False
                if v26:
                    v27 = "The set index needs to be in range."
                    assert v25, v27
                    del v27
                else:
                    pass
                del v25, v26
                v28 = US6_2()
                v13[2] = v28
                del v28
                v29 = v13.length
                v30 = 3 < v29
                del v29
                v31 = v30 == False
                if v31:
                    v32 = "The set index needs to be in range."
                    assert v30, v32
                    del v32
                else:
                    pass
                del v30, v31
                v33 = US6_2()
                v13[3] = v33
                del v33
                v34 = v13.length
                v35 = 4 < v34
                del v34
                v36 = v35 == False
                if v36:
                    v37 = "The set index needs to be in range."
                    assert v35, v37
                    del v37
                else:
                    pass
                del v35, v36
                v38 = US6_0()
                v13[4] = v38
                del v38
                v39 = v13.length
                v40 = 5 < v39
                del v39
                v41 = v40 == False
                if v41:
                    v42 = "The set index needs to be in range."
                    assert v40, v42
                    del v42
                else:
                    pass
                del v40, v41
                v43 = US6_0()
                v13[5] = v43
                del v43
                v44 = v13.length
                v45 = v44 - 1
                del v44
                v46 = 0
                while method3(v45, v46):
                    v48 = v13.length
                    v49 = random.randrange(v46, v48)
                    del v48
                    v50 = 0 <= v46
                    if v50:
                        v51 = v13.length
                        v52 = v46 < v51
                        del v51
                        v53 = v52
                    else:
                        v53 = False
                    v54 = v53 == False
                    if v54:
                        v55 = "The read index needs to be in range."
                        assert v53, v55
                        del v55
                    else:
                        pass
                    del v53, v54
                    v56 = v13[v46]
                    v57 = 0 <= v49
                    if v57:
                        v58 = v13.length
                        v59 = v49 < v58
                        del v58
                        v60 = v59
                    else:
                        v60 = False
                    v61 = v60 == False
                    if v61:
                        v62 = "The read index needs to be in range."
                        assert v60, v62
                        del v62
                    else:
                        pass
                    del v60, v61
                    v63 = v13[v49]
                    if v50:
                        v64 = v13.length
                        v65 = v46 < v64
                        del v64
                        v66 = v65
                    else:
                        v66 = False
                    del v50
                    v67 = v66 == False
                    if v67:
                        v68 = "The set index needs to be in range."
                        assert v66, v68
                        del v68
                    else:
                        pass
                    del v66, v67
                    v13[v46] = v63
                    del v63
                    if v57:
                        v69 = v13.length
                        v70 = v49 < v69
                        del v69
                        v71 = v70
                    else:
                        v71 = False
                    del v57
                    v72 = v71 == False
                    if v72:
                        v73 = "The set index needs to be in range."
                        assert v71, v73
                        del v73
                    else:
                        pass
                    del v71, v72
                    v13[v49] = v56
                    del v49, v56
                    v46 += 1 
                del v45, v46
                v74 = US4_1()
                v118, v119, v120, v121 = method12(v11, v10, v7, v12, v13, v74)
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v2, v3, v4, v5, v6
        return method19(v118, v119, v120, v121)
    return inner
def Closure1():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(1152,dtype=cp.uint8)
        v4 = method0(v0)
        v5, v6, v7, v8 = method5(v1)
        v9 = v4.tag
        v10 = v2[0:].view(cp.int32)
        v10[0] = v9
        del v9, v10
        match v4:
            case US0_0(v11): # ActionSelected
                v12 = v11.tag
                v13 = v2[4:].view(cp.int32)
                v13[0] = v12
                del v12, v13
                match v11:
                    case US1_0(): # Call
                        del v11
                    case US1_1(): # Fold
                        del v11
                    case US1_2(): # Raise
                        del v11
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case US0_1(v14): # PlayerChanged
                v15 = 0
                while method14(v15):
                    v17 = u64(v15)
                    v18 = v17 * 4
                    del v17
                    v19 = 4 + v18
                    del v18
                    v20 = v2[v19:].view(cp.uint8)
                    del v19
                    v21 = 0 <= v15
                    if v21:
                        v22 = v15 < 2
                        v23 = v22
                    else:
                        v23 = False
                    del v21
                    v24 = v23 == False
                    if v24:
                        v25 = "The read index needs to be in range."
                        assert v23, v25
                        del v25
                    else:
                        pass
                    del v23, v24
                    v26 = v14[v15]
                    v27 = v26.tag
                    v28 = v20[0:].view(cp.int32)
                    del v20
                    v28[0] = v27
                    del v27, v28
                    match v26:
                        case US2_0(): # Computer
                            pass
                        case US2_1(): # Human
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v26
                    v15 += 1 
                del v14, v15
            case US0_2(): # StartGame
                pass
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v4
        v29 = v5.tag
        v30 = v3[0:].view(cp.int32)
        v30[0] = v29
        del v29, v30
        match v5:
            case US3_0(): # None
                pass
            case US3_1(v31, v32): # Some
                v33 = v31.length
                v34 = v3[4:].view(cp.int32)
                v34[0] = v33
                del v33, v34
                v35 = v31.length
                v36 = 0
                while method3(v35, v36):
                    v38 = u64(v36)
                    v39 = v38 * 4
                    del v38
                    v40 = 8 + v39
                    del v39
                    v41 = v3[v40:].view(cp.uint8)
                    del v40
                    v42 = 0 <= v36
                    if v42:
                        v43 = v31.length
                        v44 = v36 < v43
                        del v43
                        v45 = v44
                    else:
                        v45 = False
                    del v42
                    v46 = v45 == False
                    if v46:
                        v47 = "The read index needs to be in range."
                        assert v45, v47
                        del v47
                    else:
                        pass
                    del v45, v46
                    v48 = v31[v36]
                    v49 = v48.tag
                    v50 = v41[0:].view(cp.int32)
                    del v41
                    v50[0] = v49
                    del v49, v50
                    match v48:
                        case US6_0(): # Jack
                            pass
                        case US6_1(): # King
                            pass
                        case US6_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v48
                    v36 += 1 
                del v31, v35, v36
                v51 = v32.tag
                v52 = v3[32:].view(cp.int32)
                v52[0] = v51
                del v51, v52
                match v32:
                    case US4_0(v53, v54, v55, v56, v57, v58): # ChanceCommunityCard
                        del v32
                        v59 = v53.tag
                        v60 = v3[36:].view(cp.int32)
                        v60[0] = v59
                        del v59, v60
                        match v53:
                            case US5_0(): # None
                                pass
                            case US5_1(v61): # Some
                                v62 = v61.tag
                                v63 = v3[40:].view(cp.int32)
                                v63[0] = v62
                                del v62, v63
                                match v61:
                                    case US6_0(): # Jack
                                        del v61
                                    case US6_1(): # King
                                        del v61
                                    case US6_2(): # Queen
                                        del v61
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v53
                        v64 = v3[44:].view(cp.int8)
                        v64[0] = v54
                        del v54, v64
                        v65 = 0
                        while method14(v65):
                            v67 = u64(v65)
                            v68 = v67 * 4
                            del v67
                            v69 = 48 + v68
                            del v68
                            v70 = v3[v69:].view(cp.uint8)
                            del v69
                            v71 = 0 <= v65
                            if v71:
                                v72 = v65 < 2
                                v73 = v72
                            else:
                                v73 = False
                            del v71
                            v74 = v73 == False
                            if v74:
                                v75 = "The read index needs to be in range."
                                assert v73, v75
                                del v75
                            else:
                                pass
                            del v73, v74
                            v76 = v55[v65]
                            v77 = v76.tag
                            v78 = v70[0:].view(cp.int32)
                            del v70
                            v78[0] = v77
                            del v77, v78
                            match v76:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v76
                            v65 += 1 
                        del v55, v65
                        v79 = v3[56:].view(cp.int32)
                        v79[0] = v56
                        del v56, v79
                        v80 = 0
                        while method14(v80):
                            v82 = u64(v80)
                            v83 = v82 * 4
                            del v82
                            v84 = 60 + v83
                            del v83
                            v85 = v3[v84:].view(cp.uint8)
                            del v84
                            v86 = 0 <= v80
                            if v86:
                                v87 = v80 < 2
                                v88 = v87
                            else:
                                v88 = False
                            del v86
                            v89 = v88 == False
                            if v89:
                                v90 = "The read index needs to be in range."
                                assert v88, v90
                                del v90
                            else:
                                pass
                            del v88, v89
                            v91 = v57[v80]
                            v92 = v85[0:].view(cp.int32)
                            del v85
                            v92[0] = v91
                            del v91, v92
                            v80 += 1 
                        del v57, v80
                        v93 = v3[68:].view(cp.int32)
                        v93[0] = v58
                        del v58, v93
                    case US4_1(): # ChanceInit
                        del v32
                    case US4_2(v94, v95, v96, v97, v98, v99): # Round
                        del v32
                        v100 = v94.tag
                        v101 = v3[36:].view(cp.int32)
                        v101[0] = v100
                        del v100, v101
                        match v94:
                            case US5_0(): # None
                                pass
                            case US5_1(v102): # Some
                                v103 = v102.tag
                                v104 = v3[40:].view(cp.int32)
                                v104[0] = v103
                                del v103, v104
                                match v102:
                                    case US6_0(): # Jack
                                        del v102
                                    case US6_1(): # King
                                        del v102
                                    case US6_2(): # Queen
                                        del v102
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v94
                        v105 = v3[44:].view(cp.int8)
                        v105[0] = v95
                        del v95, v105
                        v106 = 0
                        while method14(v106):
                            v108 = u64(v106)
                            v109 = v108 * 4
                            del v108
                            v110 = 48 + v109
                            del v109
                            v111 = v3[v110:].view(cp.uint8)
                            del v110
                            v112 = 0 <= v106
                            if v112:
                                v113 = v106 < 2
                                v114 = v113
                            else:
                                v114 = False
                            del v112
                            v115 = v114 == False
                            if v115:
                                v116 = "The read index needs to be in range."
                                assert v114, v116
                                del v116
                            else:
                                pass
                            del v114, v115
                            v117 = v96[v106]
                            v118 = v117.tag
                            v119 = v111[0:].view(cp.int32)
                            del v111
                            v119[0] = v118
                            del v118, v119
                            match v117:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v117
                            v106 += 1 
                        del v96, v106
                        v120 = v3[56:].view(cp.int32)
                        v120[0] = v97
                        del v97, v120
                        v121 = 0
                        while method14(v121):
                            v123 = u64(v121)
                            v124 = v123 * 4
                            del v123
                            v125 = 60 + v124
                            del v124
                            v126 = v3[v125:].view(cp.uint8)
                            del v125
                            v127 = 0 <= v121
                            if v127:
                                v128 = v121 < 2
                                v129 = v128
                            else:
                                v129 = False
                            del v127
                            v130 = v129 == False
                            if v130:
                                v131 = "The read index needs to be in range."
                                assert v129, v131
                                del v131
                            else:
                                pass
                            del v129, v130
                            v132 = v98[v121]
                            v133 = v126[0:].view(cp.int32)
                            del v126
                            v133[0] = v132
                            del v132, v133
                            v121 += 1 
                        del v98, v121
                        v134 = v3[68:].view(cp.int32)
                        v134[0] = v99
                        del v99, v134
                    case US4_3(v135, v136, v137, v138, v139, v140, v141): # RoundWithAction
                        del v32
                        v142 = v135.tag
                        v143 = v3[36:].view(cp.int32)
                        v143[0] = v142
                        del v142, v143
                        match v135:
                            case US5_0(): # None
                                pass
                            case US5_1(v144): # Some
                                v145 = v144.tag
                                v146 = v3[40:].view(cp.int32)
                                v146[0] = v145
                                del v145, v146
                                match v144:
                                    case US6_0(): # Jack
                                        del v144
                                    case US6_1(): # King
                                        del v144
                                    case US6_2(): # Queen
                                        del v144
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v135
                        v147 = v3[44:].view(cp.int8)
                        v147[0] = v136
                        del v136, v147
                        v148 = 0
                        while method14(v148):
                            v150 = u64(v148)
                            v151 = v150 * 4
                            del v150
                            v152 = 48 + v151
                            del v151
                            v153 = v3[v152:].view(cp.uint8)
                            del v152
                            v154 = 0 <= v148
                            if v154:
                                v155 = v148 < 2
                                v156 = v155
                            else:
                                v156 = False
                            del v154
                            v157 = v156 == False
                            if v157:
                                v158 = "The read index needs to be in range."
                                assert v156, v158
                                del v158
                            else:
                                pass
                            del v156, v157
                            v159 = v137[v148]
                            v160 = v159.tag
                            v161 = v153[0:].view(cp.int32)
                            del v153
                            v161[0] = v160
                            del v160, v161
                            match v159:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v159
                            v148 += 1 
                        del v137, v148
                        v162 = v3[56:].view(cp.int32)
                        v162[0] = v138
                        del v138, v162
                        v163 = 0
                        while method14(v163):
                            v165 = u64(v163)
                            v166 = v165 * 4
                            del v165
                            v167 = 60 + v166
                            del v166
                            v168 = v3[v167:].view(cp.uint8)
                            del v167
                            v169 = 0 <= v163
                            if v169:
                                v170 = v163 < 2
                                v171 = v170
                            else:
                                v171 = False
                            del v169
                            v172 = v171 == False
                            if v172:
                                v173 = "The read index needs to be in range."
                                assert v171, v173
                                del v173
                            else:
                                pass
                            del v171, v172
                            v174 = v139[v163]
                            v175 = v168[0:].view(cp.int32)
                            del v168
                            v175[0] = v174
                            del v174, v175
                            v163 += 1 
                        del v139, v163
                        v176 = v3[68:].view(cp.int32)
                        v176[0] = v140
                        del v140, v176
                        v177 = v141.tag
                        v178 = v3[72:].view(cp.int32)
                        v178[0] = v177
                        del v177, v178
                        match v141:
                            case US1_0(): # Call
                                del v141
                            case US1_1(): # Fold
                                del v141
                            case US1_2(): # Raise
                                del v141
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case US4_4(v179, v180, v181, v182, v183, v184): # TerminalCall
                        del v32
                        v185 = v179.tag
                        v186 = v3[36:].view(cp.int32)
                        v186[0] = v185
                        del v185, v186
                        match v179:
                            case US5_0(): # None
                                pass
                            case US5_1(v187): # Some
                                v188 = v187.tag
                                v189 = v3[40:].view(cp.int32)
                                v189[0] = v188
                                del v188, v189
                                match v187:
                                    case US6_0(): # Jack
                                        del v187
                                    case US6_1(): # King
                                        del v187
                                    case US6_2(): # Queen
                                        del v187
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v179
                        v190 = v3[44:].view(cp.int8)
                        v190[0] = v180
                        del v180, v190
                        v191 = 0
                        while method14(v191):
                            v193 = u64(v191)
                            v194 = v193 * 4
                            del v193
                            v195 = 48 + v194
                            del v194
                            v196 = v3[v195:].view(cp.uint8)
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
                                v201 = "The read index needs to be in range."
                                assert v199, v201
                                del v201
                            else:
                                pass
                            del v199, v200
                            v202 = v181[v191]
                            v203 = v202.tag
                            v204 = v196[0:].view(cp.int32)
                            del v196
                            v204[0] = v203
                            del v203, v204
                            match v202:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v202
                            v191 += 1 
                        del v181, v191
                        v205 = v3[56:].view(cp.int32)
                        v205[0] = v182
                        del v182, v205
                        v206 = 0
                        while method14(v206):
                            v208 = u64(v206)
                            v209 = v208 * 4
                            del v208
                            v210 = 60 + v209
                            del v209
                            v211 = v3[v210:].view(cp.uint8)
                            del v210
                            v212 = 0 <= v206
                            if v212:
                                v213 = v206 < 2
                                v214 = v213
                            else:
                                v214 = False
                            del v212
                            v215 = v214 == False
                            if v215:
                                v216 = "The read index needs to be in range."
                                assert v214, v216
                                del v216
                            else:
                                pass
                            del v214, v215
                            v217 = v183[v206]
                            v218 = v211[0:].view(cp.int32)
                            del v211
                            v218[0] = v217
                            del v217, v218
                            v206 += 1 
                        del v183, v206
                        v219 = v3[68:].view(cp.int32)
                        v219[0] = v184
                        del v184, v219
                    case US4_5(v220, v221, v222, v223, v224, v225): # TerminalFold
                        del v32
                        v226 = v220.tag
                        v227 = v3[36:].view(cp.int32)
                        v227[0] = v226
                        del v226, v227
                        match v220:
                            case US5_0(): # None
                                pass
                            case US5_1(v228): # Some
                                v229 = v228.tag
                                v230 = v3[40:].view(cp.int32)
                                v230[0] = v229
                                del v229, v230
                                match v228:
                                    case US6_0(): # Jack
                                        del v228
                                    case US6_1(): # King
                                        del v228
                                    case US6_2(): # Queen
                                        del v228
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v220
                        v231 = v3[44:].view(cp.int8)
                        v231[0] = v221
                        del v221, v231
                        v232 = 0
                        while method14(v232):
                            v234 = u64(v232)
                            v235 = v234 * 4
                            del v234
                            v236 = 48 + v235
                            del v235
                            v237 = v3[v236:].view(cp.uint8)
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
                                v242 = "The read index needs to be in range."
                                assert v240, v242
                                del v242
                            else:
                                pass
                            del v240, v241
                            v243 = v222[v232]
                            v244 = v243.tag
                            v245 = v237[0:].view(cp.int32)
                            del v237
                            v245[0] = v244
                            del v244, v245
                            match v243:
                                case US6_0(): # Jack
                                    pass
                                case US6_1(): # King
                                    pass
                                case US6_2(): # Queen
                                    pass
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                            del v243
                            v232 += 1 
                        del v222, v232
                        v246 = v3[56:].view(cp.int32)
                        v246[0] = v223
                        del v223, v246
                        v247 = 0
                        while method14(v247):
                            v249 = u64(v247)
                            v250 = v249 * 4
                            del v249
                            v251 = 60 + v250
                            del v250
                            v252 = v3[v251:].view(cp.uint8)
                            del v251
                            v253 = 0 <= v247
                            if v253:
                                v254 = v247 < 2
                                v255 = v254
                            else:
                                v255 = False
                            del v253
                            v256 = v255 == False
                            if v256:
                                v257 = "The read index needs to be in range."
                                assert v255, v257
                                del v257
                            else:
                                pass
                            del v255, v256
                            v258 = v224[v247]
                            v259 = v252[0:].view(cp.int32)
                            del v252
                            v259[0] = v258
                            del v258, v259
                            v247 += 1 
                        del v224, v247
                        v260 = v3[68:].view(cp.int32)
                        v260[0] = v225
                        del v225, v260
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v5
        v261 = v6.length
        v262 = v3[76:].view(cp.int32)
        v262[0] = v261
        del v261, v262
        v263 = v6.length
        v264 = 0
        while method3(v263, v264):
            v266 = u64(v264)
            v267 = v266 * 32
            del v266
            v268 = 80 + v267
            del v267
            v269 = v3[v268:].view(cp.uint8)
            del v268
            v270 = 0 <= v264
            if v270:
                v271 = v6.length
                v272 = v264 < v271
                del v271
                v273 = v272
            else:
                v273 = False
            del v270
            v274 = v273 == False
            if v274:
                v275 = "The read index needs to be in range."
                assert v273, v275
                del v275
            else:
                pass
            del v273, v274
            v276 = v6[v264]
            v277 = v276.tag
            v278 = v269[0:].view(cp.int32)
            v278[0] = v277
            del v277, v278
            match v276:
                case US8_0(v279): # CommunityCardIs
                    v280 = v279.tag
                    v281 = v269[4:].view(cp.int32)
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
                case US8_1(v282, v283): # PlayerAction
                    v284 = v269[4:].view(cp.int32)
                    v284[0] = v282
                    del v282, v284
                    v285 = v283.tag
                    v286 = v269[8:].view(cp.int32)
                    v286[0] = v285
                    del v285, v286
                    match v283:
                        case US1_0(): # Call
                            del v283
                        case US1_1(): # Fold
                            del v283
                        case US1_2(): # Raise
                            del v283
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US8_2(v287, v288): # PlayerGotCard
                    v289 = v269[4:].view(cp.int32)
                    v289[0] = v287
                    del v287, v289
                    v290 = v288.tag
                    v291 = v269[8:].view(cp.int32)
                    v291[0] = v290
                    del v290, v291
                    match v288:
                        case US6_0(): # Jack
                            del v288
                        case US6_1(): # King
                            del v288
                        case US6_2(): # Queen
                            del v288
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US8_3(v292, v293, v294): # Showdown
                    v295 = 0
                    while method14(v295):
                        v297 = u64(v295)
                        v298 = v297 * 4
                        del v297
                        v299 = 4 + v298
                        del v298
                        v300 = v269[v299:].view(cp.uint8)
                        del v299
                        v301 = 0 <= v295
                        if v301:
                            v302 = v295 < 2
                            v303 = v302
                        else:
                            v303 = False
                        del v301
                        v304 = v303 == False
                        if v304:
                            v305 = "The read index needs to be in range."
                            assert v303, v305
                            del v305
                        else:
                            pass
                        del v303, v304
                        v306 = v292[v295]
                        v307 = v306.tag
                        v308 = v300[0:].view(cp.int32)
                        del v300
                        v308[0] = v307
                        del v307, v308
                        match v306:
                            case US6_0(): # Jack
                                pass
                            case US6_1(): # King
                                pass
                            case US6_2(): # Queen
                                pass
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v306
                        v295 += 1 
                    del v292, v295
                    v309 = v269[12:].view(cp.int32)
                    v309[0] = v293
                    del v293, v309
                    v310 = v269[16:].view(cp.int32)
                    v310[0] = v294
                    del v294, v310
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v269, v276
            v264 += 1 
        del v6, v263, v264
        v311 = 0
        while method14(v311):
            v313 = u64(v311)
            v314 = v313 * 4
            del v313
            v315 = 1104 + v314
            del v314
            v316 = v3[v315:].view(cp.uint8)
            del v315
            v317 = 0 <= v311
            if v317:
                v318 = v311 < 2
                v319 = v318
            else:
                v319 = False
            del v317
            v320 = v319 == False
            if v320:
                v321 = "The read index needs to be in range."
                assert v319, v321
                del v321
            else:
                pass
            del v319, v320
            v322 = v7[v311]
            v323 = v322.tag
            v324 = v316[0:].view(cp.int32)
            del v316
            v324[0] = v323
            del v323, v324
            match v322:
                case US2_0(): # Computer
                    pass
                case US2_1(): # Human
                    pass
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v322
            v311 += 1 
        del v7, v311
        v325 = v8.tag
        v326 = v3[1112:].view(cp.int32)
        v326[0] = v325
        del v325, v326
        match v8:
            case US7_0(): # GameNotStarted
                pass
            case US7_1(v327, v328, v329, v330, v331, v332): # GameOver
                v333 = v327.tag
                v334 = v3[1116:].view(cp.int32)
                v334[0] = v333
                del v333, v334
                match v327:
                    case US5_0(): # None
                        pass
                    case US5_1(v335): # Some
                        v336 = v335.tag
                        v337 = v3[1120:].view(cp.int32)
                        v337[0] = v336
                        del v336, v337
                        match v335:
                            case US6_0(): # Jack
                                del v335
                            case US6_1(): # King
                                del v335
                            case US6_2(): # Queen
                                del v335
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v327
                v338 = v3[1124:].view(cp.int8)
                v338[0] = v328
                del v328, v338
                v339 = 0
                while method14(v339):
                    v341 = u64(v339)
                    v342 = v341 * 4
                    del v341
                    v343 = 1128 + v342
                    del v342
                    v344 = v3[v343:].view(cp.uint8)
                    del v343
                    v345 = 0 <= v339
                    if v345:
                        v346 = v339 < 2
                        v347 = v346
                    else:
                        v347 = False
                    del v345
                    v348 = v347 == False
                    if v348:
                        v349 = "The read index needs to be in range."
                        assert v347, v349
                        del v349
                    else:
                        pass
                    del v347, v348
                    v350 = v329[v339]
                    v351 = v350.tag
                    v352 = v344[0:].view(cp.int32)
                    del v344
                    v352[0] = v351
                    del v351, v352
                    match v350:
                        case US6_0(): # Jack
                            pass
                        case US6_1(): # King
                            pass
                        case US6_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v350
                    v339 += 1 
                del v329, v339
                v353 = v3[1136:].view(cp.int32)
                v353[0] = v330
                del v330, v353
                v354 = 0
                while method14(v354):
                    v356 = u64(v354)
                    v357 = v356 * 4
                    del v356
                    v358 = 1140 + v357
                    del v357
                    v359 = v3[v358:].view(cp.uint8)
                    del v358
                    v360 = 0 <= v354
                    if v360:
                        v361 = v354 < 2
                        v362 = v361
                    else:
                        v362 = False
                    del v360
                    v363 = v362 == False
                    if v363:
                        v364 = "The read index needs to be in range."
                        assert v362, v364
                        del v364
                    else:
                        pass
                    del v362, v363
                    v365 = v331[v354]
                    v366 = v359[0:].view(cp.int32)
                    del v359
                    v366[0] = v365
                    del v365, v366
                    v354 += 1 
                del v331, v354
                v367 = v3[1148:].view(cp.int32)
                v367[0] = v332
                del v332, v367
            case US7_2(v368, v369, v370, v371, v372, v373): # WaitingForActionFromPlayerId
                v374 = v368.tag
                v375 = v3[1116:].view(cp.int32)
                v375[0] = v374
                del v374, v375
                match v368:
                    case US5_0(): # None
                        pass
                    case US5_1(v376): # Some
                        v377 = v376.tag
                        v378 = v3[1120:].view(cp.int32)
                        v378[0] = v377
                        del v377, v378
                        match v376:
                            case US6_0(): # Jack
                                del v376
                            case US6_1(): # King
                                del v376
                            case US6_2(): # Queen
                                del v376
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v368
                v379 = v3[1124:].view(cp.int8)
                v379[0] = v369
                del v369, v379
                v380 = 0
                while method14(v380):
                    v382 = u64(v380)
                    v383 = v382 * 4
                    del v382
                    v384 = 1128 + v383
                    del v383
                    v385 = v3[v384:].view(cp.uint8)
                    del v384
                    v386 = 0 <= v380
                    if v386:
                        v387 = v380 < 2
                        v388 = v387
                    else:
                        v388 = False
                    del v386
                    v389 = v388 == False
                    if v389:
                        v390 = "The read index needs to be in range."
                        assert v388, v390
                        del v390
                    else:
                        pass
                    del v388, v389
                    v391 = v370[v380]
                    v392 = v391.tag
                    v393 = v385[0:].view(cp.int32)
                    del v385
                    v393[0] = v392
                    del v392, v393
                    match v391:
                        case US6_0(): # Jack
                            pass
                        case US6_1(): # King
                            pass
                        case US6_2(): # Queen
                            pass
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v391
                    v380 += 1 
                del v370, v380
                v394 = v3[1136:].view(cp.int32)
                v394[0] = v371
                del v371, v394
                v395 = 0
                while method14(v395):
                    v397 = u64(v395)
                    v398 = v397 * 4
                    del v397
                    v399 = 1140 + v398
                    del v398
                    v400 = v3[v399:].view(cp.uint8)
                    del v399
                    v401 = 0 <= v395
                    if v401:
                        v402 = v395 < 2
                        v403 = v402
                    else:
                        v403 = False
                    del v401
                    v404 = v403 == False
                    if v404:
                        v405 = "The read index needs to be in range."
                        assert v403, v405
                        del v405
                    else:
                        pass
                    del v403, v404
                    v406 = v372[v395]
                    v407 = v400[0:].view(cp.int32)
                    del v400
                    v407[0] = v406
                    del v406, v407
                    v395 += 1 
                del v372, v395
                v408 = v3[1148:].view(cp.int32)
                v408[0] = v373
                del v373, v408
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v8
        v409 = 0
        v410 = raw_module.get_function(f"entry{v409}")
        del v409
        v410.max_dynamic_shared_size_bytes = 0 
        v410((1,),(512,),(v3, v2),shared_mem=0)
        del v2, v410
        v411 = v3[0:].view(cp.int32)
        v412 = v411[0].item()
        del v411
        if v412 == 0:
            v716 = US3_0()
        elif v412 == 1:
            v415 = static_array_list(6)
            v416 = v3[4:].view(cp.int32)
            v417 = v416[0].item()
            del v416
            v415.length = v417
            del v417
            v418 = v415.length
            v419 = 0
            while method3(v418, v419):
                v421 = u64(v419)
                v422 = v421 * 4
                del v421
                v423 = 8 + v422
                del v422
                v424 = v3[v423:].view(cp.uint8)
                del v423
                v425 = v424[0:].view(cp.int32)
                del v424
                v426 = v425[0].item()
                del v425
                if v426 == 0:
                    v431 = US6_0()
                elif v426 == 1:
                    v431 = US6_1()
                elif v426 == 2:
                    v431 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v426
                v432 = 0 <= v419
                if v432:
                    v433 = v415.length
                    v434 = v419 < v433
                    del v433
                    v435 = v434
                else:
                    v435 = False
                del v432
                v436 = v435 == False
                if v436:
                    v437 = "The set index needs to be in range."
                    assert v435, v437
                    del v437
                else:
                    pass
                del v435, v436
                v415[v419] = v431
                del v431
                v419 += 1 
            del v418, v419
            v438 = v3[32:].view(cp.int32)
            v439 = v438[0].item()
            del v438
            if v439 == 0:
                v441 = v3[36:].view(cp.int32)
                v442 = v441[0].item()
                del v441
                if v442 == 0:
                    v453 = US5_0()
                elif v442 == 1:
                    v445 = v3[40:].view(cp.int32)
                    v446 = v445[0].item()
                    del v445
                    if v446 == 0:
                        v451 = US6_0()
                    elif v446 == 1:
                        v451 = US6_1()
                    elif v446 == 2:
                        v451 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v446
                    v453 = US5_1(v451)
                else:
                    raise Exception("Invalid tag.")
                del v442
                v454 = v3[44:].view(cp.int8)
                v455 = v454[0].item()
                del v454
                v456 = static_array(2)
                v457 = 0
                while method14(v457):
                    v459 = u64(v457)
                    v460 = v459 * 4
                    del v459
                    v461 = 48 + v460
                    del v460
                    v462 = v3[v461:].view(cp.uint8)
                    del v461
                    v463 = v462[0:].view(cp.int32)
                    del v462
                    v464 = v463[0].item()
                    del v463
                    if v464 == 0:
                        v469 = US6_0()
                    elif v464 == 1:
                        v469 = US6_1()
                    elif v464 == 2:
                        v469 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v464
                    v470 = 0 <= v457
                    if v470:
                        v471 = v457 < 2
                        v472 = v471
                    else:
                        v472 = False
                    del v470
                    v473 = v472 == False
                    if v473:
                        v474 = "The read index needs to be in range."
                        assert v472, v474
                        del v474
                    else:
                        pass
                    del v472, v473
                    v456[v457] = v469
                    del v469
                    v457 += 1 
                del v457
                v475 = v3[56:].view(cp.int32)
                v476 = v475[0].item()
                del v475
                v477 = static_array(2)
                v478 = 0
                while method14(v478):
                    v480 = u64(v478)
                    v481 = v480 * 4
                    del v480
                    v482 = 60 + v481
                    del v481
                    v483 = v3[v482:].view(cp.uint8)
                    del v482
                    v484 = v483[0:].view(cp.int32)
                    del v483
                    v485 = v484[0].item()
                    del v484
                    v486 = 0 <= v478
                    if v486:
                        v487 = v478 < 2
                        v488 = v487
                    else:
                        v488 = False
                    del v486
                    v489 = v488 == False
                    if v489:
                        v490 = "The read index needs to be in range."
                        assert v488, v490
                        del v490
                    else:
                        pass
                    del v488, v489
                    v477[v478] = v485
                    del v485
                    v478 += 1 
                del v478
                v491 = v3[68:].view(cp.int32)
                v492 = v491[0].item()
                del v491
                v714 = US4_0(v453, v455, v456, v476, v477, v492)
            elif v439 == 1:
                v714 = US4_1()
            elif v439 == 2:
                v495 = v3[36:].view(cp.int32)
                v496 = v495[0].item()
                del v495
                if v496 == 0:
                    v507 = US5_0()
                elif v496 == 1:
                    v499 = v3[40:].view(cp.int32)
                    v500 = v499[0].item()
                    del v499
                    if v500 == 0:
                        v505 = US6_0()
                    elif v500 == 1:
                        v505 = US6_1()
                    elif v500 == 2:
                        v505 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v500
                    v507 = US5_1(v505)
                else:
                    raise Exception("Invalid tag.")
                del v496
                v508 = v3[44:].view(cp.int8)
                v509 = v508[0].item()
                del v508
                v510 = static_array(2)
                v511 = 0
                while method14(v511):
                    v513 = u64(v511)
                    v514 = v513 * 4
                    del v513
                    v515 = 48 + v514
                    del v514
                    v516 = v3[v515:].view(cp.uint8)
                    del v515
                    v517 = v516[0:].view(cp.int32)
                    del v516
                    v518 = v517[0].item()
                    del v517
                    if v518 == 0:
                        v523 = US6_0()
                    elif v518 == 1:
                        v523 = US6_1()
                    elif v518 == 2:
                        v523 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v518
                    v524 = 0 <= v511
                    if v524:
                        v525 = v511 < 2
                        v526 = v525
                    else:
                        v526 = False
                    del v524
                    v527 = v526 == False
                    if v527:
                        v528 = "The read index needs to be in range."
                        assert v526, v528
                        del v528
                    else:
                        pass
                    del v526, v527
                    v510[v511] = v523
                    del v523
                    v511 += 1 
                del v511
                v529 = v3[56:].view(cp.int32)
                v530 = v529[0].item()
                del v529
                v531 = static_array(2)
                v532 = 0
                while method14(v532):
                    v534 = u64(v532)
                    v535 = v534 * 4
                    del v534
                    v536 = 60 + v535
                    del v535
                    v537 = v3[v536:].view(cp.uint8)
                    del v536
                    v538 = v537[0:].view(cp.int32)
                    del v537
                    v539 = v538[0].item()
                    del v538
                    v540 = 0 <= v532
                    if v540:
                        v541 = v532 < 2
                        v542 = v541
                    else:
                        v542 = False
                    del v540
                    v543 = v542 == False
                    if v543:
                        v544 = "The read index needs to be in range."
                        assert v542, v544
                        del v544
                    else:
                        pass
                    del v542, v543
                    v531[v532] = v539
                    del v539
                    v532 += 1 
                del v532
                v545 = v3[68:].view(cp.int32)
                v546 = v545[0].item()
                del v545
                v714 = US4_2(v507, v509, v510, v530, v531, v546)
            elif v439 == 3:
                v548 = v3[36:].view(cp.int32)
                v549 = v548[0].item()
                del v548
                if v549 == 0:
                    v560 = US5_0()
                elif v549 == 1:
                    v552 = v3[40:].view(cp.int32)
                    v553 = v552[0].item()
                    del v552
                    if v553 == 0:
                        v558 = US6_0()
                    elif v553 == 1:
                        v558 = US6_1()
                    elif v553 == 2:
                        v558 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v553
                    v560 = US5_1(v558)
                else:
                    raise Exception("Invalid tag.")
                del v549
                v561 = v3[44:].view(cp.int8)
                v562 = v561[0].item()
                del v561
                v563 = static_array(2)
                v564 = 0
                while method14(v564):
                    v566 = u64(v564)
                    v567 = v566 * 4
                    del v566
                    v568 = 48 + v567
                    del v567
                    v569 = v3[v568:].view(cp.uint8)
                    del v568
                    v570 = v569[0:].view(cp.int32)
                    del v569
                    v571 = v570[0].item()
                    del v570
                    if v571 == 0:
                        v576 = US6_0()
                    elif v571 == 1:
                        v576 = US6_1()
                    elif v571 == 2:
                        v576 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v571
                    v577 = 0 <= v564
                    if v577:
                        v578 = v564 < 2
                        v579 = v578
                    else:
                        v579 = False
                    del v577
                    v580 = v579 == False
                    if v580:
                        v581 = "The read index needs to be in range."
                        assert v579, v581
                        del v581
                    else:
                        pass
                    del v579, v580
                    v563[v564] = v576
                    del v576
                    v564 += 1 
                del v564
                v582 = v3[56:].view(cp.int32)
                v583 = v582[0].item()
                del v582
                v584 = static_array(2)
                v585 = 0
                while method14(v585):
                    v587 = u64(v585)
                    v588 = v587 * 4
                    del v587
                    v589 = 60 + v588
                    del v588
                    v590 = v3[v589:].view(cp.uint8)
                    del v589
                    v591 = v590[0:].view(cp.int32)
                    del v590
                    v592 = v591[0].item()
                    del v591
                    v593 = 0 <= v585
                    if v593:
                        v594 = v585 < 2
                        v595 = v594
                    else:
                        v595 = False
                    del v593
                    v596 = v595 == False
                    if v596:
                        v597 = "The read index needs to be in range."
                        assert v595, v597
                        del v597
                    else:
                        pass
                    del v595, v596
                    v584[v585] = v592
                    del v592
                    v585 += 1 
                del v585
                v598 = v3[68:].view(cp.int32)
                v599 = v598[0].item()
                del v598
                v600 = v3[72:].view(cp.int32)
                v601 = v600[0].item()
                del v600
                if v601 == 0:
                    v606 = US1_0()
                elif v601 == 1:
                    v606 = US1_1()
                elif v601 == 2:
                    v606 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v601
                v714 = US4_3(v560, v562, v563, v583, v584, v599, v606)
            elif v439 == 4:
                v608 = v3[36:].view(cp.int32)
                v609 = v608[0].item()
                del v608
                if v609 == 0:
                    v620 = US5_0()
                elif v609 == 1:
                    v612 = v3[40:].view(cp.int32)
                    v613 = v612[0].item()
                    del v612
                    if v613 == 0:
                        v618 = US6_0()
                    elif v613 == 1:
                        v618 = US6_1()
                    elif v613 == 2:
                        v618 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v613
                    v620 = US5_1(v618)
                else:
                    raise Exception("Invalid tag.")
                del v609
                v621 = v3[44:].view(cp.int8)
                v622 = v621[0].item()
                del v621
                v623 = static_array(2)
                v624 = 0
                while method14(v624):
                    v626 = u64(v624)
                    v627 = v626 * 4
                    del v626
                    v628 = 48 + v627
                    del v627
                    v629 = v3[v628:].view(cp.uint8)
                    del v628
                    v630 = v629[0:].view(cp.int32)
                    del v629
                    v631 = v630[0].item()
                    del v630
                    if v631 == 0:
                        v636 = US6_0()
                    elif v631 == 1:
                        v636 = US6_1()
                    elif v631 == 2:
                        v636 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v631
                    v637 = 0 <= v624
                    if v637:
                        v638 = v624 < 2
                        v639 = v638
                    else:
                        v639 = False
                    del v637
                    v640 = v639 == False
                    if v640:
                        v641 = "The read index needs to be in range."
                        assert v639, v641
                        del v641
                    else:
                        pass
                    del v639, v640
                    v623[v624] = v636
                    del v636
                    v624 += 1 
                del v624
                v642 = v3[56:].view(cp.int32)
                v643 = v642[0].item()
                del v642
                v644 = static_array(2)
                v645 = 0
                while method14(v645):
                    v647 = u64(v645)
                    v648 = v647 * 4
                    del v647
                    v649 = 60 + v648
                    del v648
                    v650 = v3[v649:].view(cp.uint8)
                    del v649
                    v651 = v650[0:].view(cp.int32)
                    del v650
                    v652 = v651[0].item()
                    del v651
                    v653 = 0 <= v645
                    if v653:
                        v654 = v645 < 2
                        v655 = v654
                    else:
                        v655 = False
                    del v653
                    v656 = v655 == False
                    if v656:
                        v657 = "The read index needs to be in range."
                        assert v655, v657
                        del v657
                    else:
                        pass
                    del v655, v656
                    v644[v645] = v652
                    del v652
                    v645 += 1 
                del v645
                v658 = v3[68:].view(cp.int32)
                v659 = v658[0].item()
                del v658
                v714 = US4_4(v620, v622, v623, v643, v644, v659)
            elif v439 == 5:
                v661 = v3[36:].view(cp.int32)
                v662 = v661[0].item()
                del v661
                if v662 == 0:
                    v673 = US5_0()
                elif v662 == 1:
                    v665 = v3[40:].view(cp.int32)
                    v666 = v665[0].item()
                    del v665
                    if v666 == 0:
                        v671 = US6_0()
                    elif v666 == 1:
                        v671 = US6_1()
                    elif v666 == 2:
                        v671 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v666
                    v673 = US5_1(v671)
                else:
                    raise Exception("Invalid tag.")
                del v662
                v674 = v3[44:].view(cp.int8)
                v675 = v674[0].item()
                del v674
                v676 = static_array(2)
                v677 = 0
                while method14(v677):
                    v679 = u64(v677)
                    v680 = v679 * 4
                    del v679
                    v681 = 48 + v680
                    del v680
                    v682 = v3[v681:].view(cp.uint8)
                    del v681
                    v683 = v682[0:].view(cp.int32)
                    del v682
                    v684 = v683[0].item()
                    del v683
                    if v684 == 0:
                        v689 = US6_0()
                    elif v684 == 1:
                        v689 = US6_1()
                    elif v684 == 2:
                        v689 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v684
                    v690 = 0 <= v677
                    if v690:
                        v691 = v677 < 2
                        v692 = v691
                    else:
                        v692 = False
                    del v690
                    v693 = v692 == False
                    if v693:
                        v694 = "The read index needs to be in range."
                        assert v692, v694
                        del v694
                    else:
                        pass
                    del v692, v693
                    v676[v677] = v689
                    del v689
                    v677 += 1 
                del v677
                v695 = v3[56:].view(cp.int32)
                v696 = v695[0].item()
                del v695
                v697 = static_array(2)
                v698 = 0
                while method14(v698):
                    v700 = u64(v698)
                    v701 = v700 * 4
                    del v700
                    v702 = 60 + v701
                    del v701
                    v703 = v3[v702:].view(cp.uint8)
                    del v702
                    v704 = v703[0:].view(cp.int32)
                    del v703
                    v705 = v704[0].item()
                    del v704
                    v706 = 0 <= v698
                    if v706:
                        v707 = v698 < 2
                        v708 = v707
                    else:
                        v708 = False
                    del v706
                    v709 = v708 == False
                    if v709:
                        v710 = "The read index needs to be in range."
                        assert v708, v710
                        del v710
                    else:
                        pass
                    del v708, v709
                    v697[v698] = v705
                    del v705
                    v698 += 1 
                del v698
                v711 = v3[68:].view(cp.int32)
                v712 = v711[0].item()
                del v711
                v714 = US4_5(v673, v675, v676, v696, v697, v712)
            else:
                raise Exception("Invalid tag.")
            del v439
            v716 = US3_1(v415, v714)
        else:
            raise Exception("Invalid tag.")
        del v412
        v717 = static_array_list(32)
        v718 = v3[76:].view(cp.int32)
        v719 = v718[0].item()
        del v718
        v717.length = v719
        del v719
        v720 = v717.length
        v721 = 0
        while method3(v720, v721):
            v723 = u64(v721)
            v724 = v723 * 32
            del v723
            v725 = 80 + v724
            del v724
            v726 = v3[v725:].view(cp.uint8)
            del v725
            v727 = v726[0:].view(cp.int32)
            v728 = v727[0].item()
            del v727
            if v728 == 0:
                v730 = v726[4:].view(cp.int32)
                v731 = v730[0].item()
                del v730
                if v731 == 0:
                    v736 = US6_0()
                elif v731 == 1:
                    v736 = US6_1()
                elif v731 == 2:
                    v736 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v731
                v782 = US8_0(v736)
            elif v728 == 1:
                v738 = v726[4:].view(cp.int32)
                v739 = v738[0].item()
                del v738
                v740 = v726[8:].view(cp.int32)
                v741 = v740[0].item()
                del v740
                if v741 == 0:
                    v746 = US1_0()
                elif v741 == 1:
                    v746 = US1_1()
                elif v741 == 2:
                    v746 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v741
                v782 = US8_1(v739, v746)
            elif v728 == 2:
                v748 = v726[4:].view(cp.int32)
                v749 = v748[0].item()
                del v748
                v750 = v726[8:].view(cp.int32)
                v751 = v750[0].item()
                del v750
                if v751 == 0:
                    v756 = US6_0()
                elif v751 == 1:
                    v756 = US6_1()
                elif v751 == 2:
                    v756 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v751
                v782 = US8_2(v749, v756)
            elif v728 == 3:
                v758 = static_array(2)
                v759 = 0
                while method14(v759):
                    v761 = u64(v759)
                    v762 = v761 * 4
                    del v761
                    v763 = 4 + v762
                    del v762
                    v764 = v726[v763:].view(cp.uint8)
                    del v763
                    v765 = v764[0:].view(cp.int32)
                    del v764
                    v766 = v765[0].item()
                    del v765
                    if v766 == 0:
                        v771 = US6_0()
                    elif v766 == 1:
                        v771 = US6_1()
                    elif v766 == 2:
                        v771 = US6_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v766
                    v772 = 0 <= v759
                    if v772:
                        v773 = v759 < 2
                        v774 = v773
                    else:
                        v774 = False
                    del v772
                    v775 = v774 == False
                    if v775:
                        v776 = "The read index needs to be in range."
                        assert v774, v776
                        del v776
                    else:
                        pass
                    del v774, v775
                    v758[v759] = v771
                    del v771
                    v759 += 1 
                del v759
                v777 = v726[12:].view(cp.int32)
                v778 = v777[0].item()
                del v777
                v779 = v726[16:].view(cp.int32)
                v780 = v779[0].item()
                del v779
                v782 = US8_3(v758, v778, v780)
            else:
                raise Exception("Invalid tag.")
            del v726, v728
            v783 = 0 <= v721
            if v783:
                v784 = v717.length
                v785 = v721 < v784
                del v784
                v786 = v785
            else:
                v786 = False
            del v783
            v787 = v786 == False
            if v787:
                v788 = "The set index needs to be in range."
                assert v786, v788
                del v788
            else:
                pass
            del v786, v787
            v717[v721] = v782
            del v782
            v721 += 1 
        del v720, v721
        v789 = static_array(2)
        v790 = 0
        while method14(v790):
            v792 = u64(v790)
            v793 = v792 * 4
            del v792
            v794 = 1104 + v793
            del v793
            v795 = v3[v794:].view(cp.uint8)
            del v794
            v796 = v795[0:].view(cp.int32)
            del v795
            v797 = v796[0].item()
            del v796
            if v797 == 0:
                v801 = US2_0()
            elif v797 == 1:
                v801 = US2_1()
            else:
                raise Exception("Invalid tag.")
            del v797
            v802 = 0 <= v790
            if v802:
                v803 = v790 < 2
                v804 = v803
            else:
                v804 = False
            del v802
            v805 = v804 == False
            if v805:
                v806 = "The read index needs to be in range."
                assert v804, v806
                del v806
            else:
                pass
            del v804, v805
            v789[v790] = v801
            del v801
            v790 += 1 
        del v790
        v807 = v3[1112:].view(cp.int32)
        v808 = v807[0].item()
        del v807
        if v808 == 0:
            v917 = US7_0()
        elif v808 == 1:
            v811 = v3[1116:].view(cp.int32)
            v812 = v811[0].item()
            del v811
            if v812 == 0:
                v823 = US5_0()
            elif v812 == 1:
                v815 = v3[1120:].view(cp.int32)
                v816 = v815[0].item()
                del v815
                if v816 == 0:
                    v821 = US6_0()
                elif v816 == 1:
                    v821 = US6_1()
                elif v816 == 2:
                    v821 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v816
                v823 = US5_1(v821)
            else:
                raise Exception("Invalid tag.")
            del v812
            v824 = v3[1124:].view(cp.int8)
            v825 = v824[0].item()
            del v824
            v826 = static_array(2)
            v827 = 0
            while method14(v827):
                v829 = u64(v827)
                v830 = v829 * 4
                del v829
                v831 = 1128 + v830
                del v830
                v832 = v3[v831:].view(cp.uint8)
                del v831
                v833 = v832[0:].view(cp.int32)
                del v832
                v834 = v833[0].item()
                del v833
                if v834 == 0:
                    v839 = US6_0()
                elif v834 == 1:
                    v839 = US6_1()
                elif v834 == 2:
                    v839 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v834
                v840 = 0 <= v827
                if v840:
                    v841 = v827 < 2
                    v842 = v841
                else:
                    v842 = False
                del v840
                v843 = v842 == False
                if v843:
                    v844 = "The read index needs to be in range."
                    assert v842, v844
                    del v844
                else:
                    pass
                del v842, v843
                v826[v827] = v839
                del v839
                v827 += 1 
            del v827
            v845 = v3[1136:].view(cp.int32)
            v846 = v845[0].item()
            del v845
            v847 = static_array(2)
            v848 = 0
            while method14(v848):
                v850 = u64(v848)
                v851 = v850 * 4
                del v850
                v852 = 1140 + v851
                del v851
                v853 = v3[v852:].view(cp.uint8)
                del v852
                v854 = v853[0:].view(cp.int32)
                del v853
                v855 = v854[0].item()
                del v854
                v856 = 0 <= v848
                if v856:
                    v857 = v848 < 2
                    v858 = v857
                else:
                    v858 = False
                del v856
                v859 = v858 == False
                if v859:
                    v860 = "The read index needs to be in range."
                    assert v858, v860
                    del v860
                else:
                    pass
                del v858, v859
                v847[v848] = v855
                del v855
                v848 += 1 
            del v848
            v861 = v3[1148:].view(cp.int32)
            v862 = v861[0].item()
            del v861
            v917 = US7_1(v823, v825, v826, v846, v847, v862)
        elif v808 == 2:
            v864 = v3[1116:].view(cp.int32)
            v865 = v864[0].item()
            del v864
            if v865 == 0:
                v876 = US5_0()
            elif v865 == 1:
                v868 = v3[1120:].view(cp.int32)
                v869 = v868[0].item()
                del v868
                if v869 == 0:
                    v874 = US6_0()
                elif v869 == 1:
                    v874 = US6_1()
                elif v869 == 2:
                    v874 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v869
                v876 = US5_1(v874)
            else:
                raise Exception("Invalid tag.")
            del v865
            v877 = v3[1124:].view(cp.int8)
            v878 = v877[0].item()
            del v877
            v879 = static_array(2)
            v880 = 0
            while method14(v880):
                v882 = u64(v880)
                v883 = v882 * 4
                del v882
                v884 = 1128 + v883
                del v883
                v885 = v3[v884:].view(cp.uint8)
                del v884
                v886 = v885[0:].view(cp.int32)
                del v885
                v887 = v886[0].item()
                del v886
                if v887 == 0:
                    v892 = US6_0()
                elif v887 == 1:
                    v892 = US6_1()
                elif v887 == 2:
                    v892 = US6_2()
                else:
                    raise Exception("Invalid tag.")
                del v887
                v893 = 0 <= v880
                if v893:
                    v894 = v880 < 2
                    v895 = v894
                else:
                    v895 = False
                del v893
                v896 = v895 == False
                if v896:
                    v897 = "The read index needs to be in range."
                    assert v895, v897
                    del v897
                else:
                    pass
                del v895, v896
                v879[v880] = v892
                del v892
                v880 += 1 
            del v880
            v898 = v3[1136:].view(cp.int32)
            v899 = v898[0].item()
            del v898
            v900 = static_array(2)
            v901 = 0
            while method14(v901):
                v903 = u64(v901)
                v904 = v903 * 4
                del v903
                v905 = 1140 + v904
                del v904
                v906 = v3[v905:].view(cp.uint8)
                del v905
                v907 = v906[0:].view(cp.int32)
                del v906
                v908 = v907[0].item()
                del v907
                v909 = 0 <= v901
                if v909:
                    v910 = v901 < 2
                    v911 = v910
                else:
                    v911 = False
                del v909
                v912 = v911 == False
                if v912:
                    v913 = "The read index needs to be in range."
                    assert v911, v913
                    del v913
                else:
                    pass
                del v911, v912
                v900[v901] = v908
                del v908
                v901 += 1 
            del v901
            v914 = v3[1148:].view(cp.int32)
            v915 = v914[0].item()
            del v914
            v917 = US7_2(v876, v878, v879, v899, v900, v915)
        else:
            raise Exception("Invalid tag.")
        del v3, v808
        return method19(v716, v717, v789, v917)
    return inner
def Closure2():
    def inner() -> object:
        v0 = static_array(2)
        v1 = US2_0()
        v0[0] = v1
        del v1
        v2 = US2_1()
        v0[1] = v2
        del v2
        v3 = static_array_list(32)
        v4 = US3_0()
        v5 = US7_0()
        return method19(v4, v3, v0, v5)
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
                    v22 = "The read index needs to be in range."
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
def method7(v0 : object) -> US6:
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
def method9(v0 : object) -> US5:
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
            v8 = method7(v2)
            del v2
            return US5_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method8(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5 = v2["community_card"] # type: ignore
        v6 = method9(v5)
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
            v18 = method7(v17)
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
                v23 = "The read index needs to be in range."
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
                v40 = "The read index needs to be in range."
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
                v50 = method9(v49)
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
                    v62 = method7(v61)
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
                        v67 = "The read index needs to be in range."
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
                        v84 = "The read index needs to be in range."
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
                    v92 = method9(v91)
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
                        v104 = method7(v103)
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
                            v109 = "The read index needs to be in range."
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
                            v126 = "The read index needs to be in range."
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
                        v135 = method9(v134)
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
                            v147 = method7(v146)
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
                                v152 = "The read index needs to be in range."
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
                                v169 = "The read index needs to be in range."
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
                            v176 = method9(v175)
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
                                v188 = method7(v187)
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
                                    v193 = "The read index needs to be in range."
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
                                    v210 = "The read index needs to be in range."
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
def method6(v0 : object) -> US3:
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
            v8 = v2["deck"] # type: ignore
            v9 = len(v8)
            assert (6 >= v9), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v9} '
            del v9
            assert isinstance(v8,list), f'The object needs to be a Python list. Got: {v8}'
            v10 = len(v8)
            v11 = 6 >= v10
            v12 = v11 == False
            if v12:
                v13 = "The type level dimension has to equal the value passed at runtime into create."
                assert v11, v13
                del v13
            else:
                pass
            del v11, v12
            v14 = static_array_list(6)
            v14.length = v10
            v15 = 0
            while method3(v10, v15):
                v17 = v8[v15]
                v18 = method7(v17)
                del v17
                v19 = 0 <= v15
                if v19:
                    v20 = v14.length
                    v21 = v15 < v20
                    del v20
                    v22 = v21
                else:
                    v22 = False
                del v19
                v23 = v22 == False
                if v23:
                    v24 = "The set index needs to be in range."
                    assert v22, v24
                    del v24
                else:
                    pass
                del v22, v23
                v14[v15] = v18
                del v18
                v15 += 1 
            del v8, v10, v15
            v25 = v2["game"] # type: ignore
            del v2
            v26 = method8(v25)
            del v25
            return US3_1(v14, v26)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method10(v0 : object) -> US8:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method7(v2)
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
                v19 = method7(v18)
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
                        v32 = method7(v31)
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
                            v37 = "The read index needs to be in range."
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
            v9 = method9(v8)
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
                v21 = method7(v20)
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
                    v26 = "The read index needs to be in range."
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
                    v43 = "The read index needs to be in range."
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
                v50 = method9(v49)
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
                    v62 = method7(v61)
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
                        v67 = "The read index needs to be in range."
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
                        v84 = "The read index needs to be in range."
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
def method5(v0 : object) -> Tuple[US3, static_array_list, static_array, US7]:
    v1 = v0["game_state"] # type: ignore
    v2 = method6(v1)
    del v1
    v3 = v0["ui_state"] # type: ignore
    del v0
    v4 = v3["messages"] # type: ignore
    v5 = len(v4)
    assert (32 >= v5), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v5} '
    del v5
    assert isinstance(v4,list), f'The object needs to be a Python list. Got: {v4}'
    v6 = len(v4)
    v7 = 32 >= v6
    v8 = v7 == False
    if v8:
        v9 = "The type level dimension has to equal the value passed at runtime into create."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = static_array_list(32)
    v10.length = v6
    v11 = 0
    while method3(v6, v11):
        v13 = v4[v11]
        v14 = method10(v13)
        del v13
        v15 = 0 <= v11
        if v15:
            v16 = v10.length
            v17 = v11 < v16
            del v16
            v18 = v17
        else:
            v18 = False
        del v15
        v19 = v18 == False
        if v19:
            v20 = "The set index needs to be in range."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v10[v11] = v14
        del v14
        v11 += 1 
    del v4, v6, v11
    v21 = v3["pl_type"] # type: ignore
    assert isinstance(v21,list), f'The object needs to be a Python list. Got: {v21}'
    v22 = len(v21)
    v23 = 2 == v22
    v24 = v23 == False
    if v24:
        v25 = "The type level dimension has to equal the value passed at runtime into create."
        assert v23, v25
        del v25
    else:
        pass
    del v23, v24
    v26 = static_array(2)
    v27 = 0
    while method3(v22, v27):
        v29 = v21[v27]
        v30 = method4(v29)
        del v29
        v31 = 0 <= v27
        if v31:
            v32 = v27 < 2
            v33 = v32
        else:
            v33 = False
        del v31
        v34 = v33 == False
        if v34:
            v35 = "The read index needs to be in range."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        v26[v27] = v30
        del v30
        v27 += 1 
    del v21, v22, v27
    v36 = v3["ui_game_state"] # type: ignore
    del v3
    v37 = method11(v36)
    del v36
    return v2, v10, v26, v37
def method14(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method16(v0 : US6) -> i32:
    match v0:
        case US6_0(): # Jack
            del v0
            return 0
        case US6_1(): # King
            del v0
            return 2
        case US6_2(): # Queen
            del v0
            return 1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method17(v0 : i32, v1 : i32) -> bool:
    v2 = v1 == v0
    del v0, v1
    return v2
def method18(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    v2 = v1 > v0
    if v2:
        del v2
        return v1, v0
    else:
        del v2
        return v0, v1
def method15(v0 : US5, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : i32) -> US9:
    del v1, v3, v4, v5
    match v0:
        case US5_0(): # None
            del v0, v2
            raise Exception("Expected the community card to be present in the table.")
        case US5_1(v7): # Some
            del v0
            v8 = method16(v7)
            del v7
            v9 = v2[0]
            v10 = method16(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method16(v11)
            del v11
            v13 = method17(v8, v10)
            v14 = method17(v8, v12)
            if v13:
                del v8, v13
                if v14:
                    del v14
                    v15 = v10 < v12
                    if v15:
                        del v10, v12, v15
                        return US9_2()
                    else:
                        del v15
                        v17 = v10 > v12
                        del v10, v12
                        if v17:
                            del v17
                            return US9_1()
                        else:
                            del v17
                            return US9_0()
                else:
                    del v10, v12, v14
                    return US9_1()
            else:
                del v13
                if v14:
                    del v8, v10, v12, v14
                    return US9_2()
                else:
                    del v14
                    v25, v26 = method18(v8, v10)
                    del v10
                    v27, v28 = method18(v8, v12)
                    del v8, v12
                    v29 = v25 < v27
                    if v29:
                        v35 = US9_2()
                    else:
                        v31 = v25 > v27
                        if v31:
                            del v31
                            v35 = US9_1()
                        else:
                            del v31
                            v35 = US9_0()
                    del v25, v27, v29
                    match v35:
                        case US9_0(): # Eq
                            v36 = True
                        case t:
                            v36 = False
                    if v36:
                        del v35, v36
                        v37 = v26 < v28
                        if v37:
                            del v26, v28, v37
                            return US9_2()
                        else:
                            del v37
                            v39 = v26 > v28
                            del v26, v28
                            if v39:
                                del v39
                                return US9_1()
                            else:
                                del v39
                                return US9_0()
                    else:
                        del v26, v28, v36
                        return v35
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method13(v0 : static_array_list, v1 : static_array_list, v2 : static_array, v3 : US4) -> US4:
    match v3:
        case US4_0(_, _, v430, _, v432, _): # ChanceCommunityCard
            del v3
            v434 = v0.length
            v435 = v434 - 1
            del v434
            v436 = 0 <= v435
            if v436:
                v437 = v0.length
                v438 = v435 < v437
                del v437
                v439 = v438
            else:
                v439 = False
            del v436
            v440 = v439 == False
            if v440:
                v441 = "The read index needs to be in range."
                assert v439, v441
                del v441
            else:
                pass
            del v439, v440
            v442 = v0[v435]
            v0.length = v435
            del v435
            v443 = v1.length
            v444 = v443 < 32
            v445 = v444 == False
            if v445:
                v446 = "The length has to be less than the maximum length of the array."
                assert v444, v446
                del v446
            else:
                pass
            del v444, v445
            v447 = v443 + 1
            v1.length = v447
            del v447
            v448 = 0 <= v443
            if v448:
                v449 = v1.length
                v450 = v443 < v449
                del v449
                v451 = v450
            else:
                v451 = False
            del v448
            v452 = v451 == False
            if v452:
                v453 = "The set index needs to be in range."
                assert v451, v453
                del v453
            else:
                pass
            del v451, v452
            v454 = US8_0(v442)
            v1[v443] = v454
            del v443, v454
            v455 = 2
            v456, v457 = (0, 0)
            while method14(v456):
                v459 = 0 <= v456
                if v459:
                    v460 = v456 < 2
                    v461 = v460
                else:
                    v461 = False
                del v459
                v462 = v461 == False
                if v462:
                    v463 = "The read index needs to be in range."
                    assert v461, v463
                    del v463
                else:
                    pass
                del v461, v462
                v464 = v432[v456]
                v465 = v457 >= v464
                if v465:
                    v466 = v457
                else:
                    v466 = v464
                del v464, v465
                v457 = v466
                del v466
                v456 += 1 
            del v432, v456
            v467 = static_array(2)
            v468 = 0
            while method14(v468):
                v470 = 0 <= v468
                if v470:
                    v471 = v468 < 2
                    v472 = v471
                else:
                    v472 = False
                del v470
                v473 = v472 == False
                if v473:
                    v474 = "The read index needs to be in range."
                    assert v472, v474
                    del v474
                else:
                    pass
                del v472, v473
                v467[v468] = v457
                v468 += 1 
            del v457, v468
            v475 = US5_1(v442)
            del v442
            v476 = True
            v477 = 0
            v478 = US4_2(v475, v476, v430, v477, v467, v455)
            del v430, v455, v467, v475, v476, v477
            return method13(v0, v1, v2, v478)
        case US4_1(): # ChanceInit
            del v3
            v480 = v0.length
            v481 = v480 - 1
            del v480
            v482 = 0 <= v481
            if v482:
                v483 = v0.length
                v484 = v481 < v483
                del v483
                v485 = v484
            else:
                v485 = False
            del v482
            v486 = v485 == False
            if v486:
                v487 = "The read index needs to be in range."
                assert v485, v487
                del v487
            else:
                pass
            del v485, v486
            v488 = v0[v481]
            v0.length = v481
            del v481
            v489 = v0.length
            v490 = v489 - 1
            del v489
            v491 = 0 <= v490
            if v491:
                v492 = v0.length
                v493 = v490 < v492
                del v492
                v494 = v493
            else:
                v494 = False
            del v491
            v495 = v494 == False
            if v495:
                v496 = "The read index needs to be in range."
                assert v494, v496
                del v496
            else:
                pass
            del v494, v495
            v497 = v0[v490]
            v0.length = v490
            del v490
            v498 = v1.length
            v499 = v498 < 32
            v500 = v499 == False
            if v500:
                v501 = "The length has to be less than the maximum length of the array."
                assert v499, v501
                del v501
            else:
                pass
            del v499, v500
            v502 = v498 + 1
            v1.length = v502
            del v502
            v503 = 0 <= v498
            if v503:
                v504 = v1.length
                v505 = v498 < v504
                del v504
                v506 = v505
            else:
                v506 = False
            del v503
            v507 = v506 == False
            if v507:
                v508 = "The set index needs to be in range."
                assert v506, v508
                del v508
            else:
                pass
            del v506, v507
            v509 = US8_2(0, v488)
            v1[v498] = v509
            del v498, v509
            v510 = v1.length
            v511 = v510 < 32
            v512 = v511 == False
            if v512:
                v513 = "The length has to be less than the maximum length of the array."
                assert v511, v513
                del v513
            else:
                pass
            del v511, v512
            v514 = v510 + 1
            v1.length = v514
            del v514
            v515 = 0 <= v510
            if v515:
                v516 = v1.length
                v517 = v510 < v516
                del v516
                v518 = v517
            else:
                v518 = False
            del v515
            v519 = v518 == False
            if v519:
                v520 = "The set index needs to be in range."
                assert v518, v520
                del v520
            else:
                pass
            del v518, v519
            v521 = US8_2(1, v497)
            v1[v510] = v521
            del v510, v521
            v522 = 2
            v523 = static_array(2)
            v523[0] = 1
            v523[1] = 1
            v524 = static_array(2)
            v524[0] = v488
            del v488
            v524[1] = v497
            del v497
            v525 = US5_0()
            v526 = True
            v527 = 0
            v528 = US4_2(v525, v526, v524, v527, v523, v522)
            del v522, v523, v524, v525, v526, v527
            return method13(v0, v1, v2, v528)
        case US4_2(v61, v62, v63, v64, v65, v66): # Round
            v67 = 0 <= v64
            if v67:
                v68 = v64 < 2
                v69 = v68
            else:
                v69 = False
            del v67
            v70 = v69 == False
            if v70:
                v71 = "The read index needs to be in range."
                assert v69, v71
                del v71
            else:
                pass
            del v69, v70
            v72 = v2[v64]
            match v72:
                case US2_0(): # Computer
                    del v3, v72
                    v73 = static_array_list(3)
                    v73.length = 1
                    v74 = v73.length
                    v75 = 0 < v74
                    del v74
                    v76 = v75 == False
                    if v76:
                        v77 = "The set index needs to be in range."
                        assert v75, v77
                        del v77
                    else:
                        pass
                    del v75, v76
                    v78 = US1_0()
                    v73[0] = v78
                    del v78
                    v79 = v65[0]
                    v80 = v65[1]
                    v81 = v79 == v80
                    del v79, v80
                    v82 = v81 != True
                    del v81
                    if v82:
                        v83 = v73.length
                        v84 = v83 < 3
                        v85 = v84 == False
                        if v85:
                            v86 = "The length has to be less than the maximum length of the array."
                            assert v84, v86
                            del v86
                        else:
                            pass
                        del v84, v85
                        v87 = v83 + 1
                        v73.length = v87
                        del v87
                        v88 = 0 <= v83
                        if v88:
                            v89 = v73.length
                            v90 = v83 < v89
                            del v89
                            v91 = v90
                        else:
                            v91 = False
                        del v88
                        v92 = v91 == False
                        if v92:
                            v93 = "The set index needs to be in range."
                            assert v91, v93
                            del v93
                        else:
                            pass
                        del v91, v92
                        v94 = US1_1()
                        v73[v83] = v94
                        del v83, v94
                    else:
                        pass
                    del v82
                    v95 = v66 > 0
                    if v95:
                        v96 = v73.length
                        v97 = v96 < 3
                        v98 = v97 == False
                        if v98:
                            v99 = "The length has to be less than the maximum length of the array."
                            assert v97, v99
                            del v99
                        else:
                            pass
                        del v97, v98
                        v100 = v96 + 1
                        v73.length = v100
                        del v100
                        v101 = 0 <= v96
                        if v101:
                            v102 = v73.length
                            v103 = v96 < v102
                            del v102
                            v104 = v103
                        else:
                            v104 = False
                        del v101
                        v105 = v104 == False
                        if v105:
                            v106 = "The set index needs to be in range."
                            assert v104, v106
                            del v106
                        else:
                            pass
                        del v104, v105
                        v107 = US1_2()
                        v73[v96] = v107
                        del v96, v107
                    else:
                        pass
                    v108 = v73.length
                    v109 = v108 - 1
                    del v108
                    v110 = 0
                    while method3(v109, v110):
                        v112 = v73.length
                        v113 = random.randrange(v110, v112)
                        del v112
                        v114 = 0 <= v110
                        if v114:
                            v115 = v73.length
                            v116 = v110 < v115
                            del v115
                            v117 = v116
                        else:
                            v117 = False
                        v118 = v117 == False
                        if v118:
                            v119 = "The read index needs to be in range."
                            assert v117, v119
                            del v119
                        else:
                            pass
                        del v117, v118
                        v120 = v73[v110]
                        v121 = 0 <= v113
                        if v121:
                            v122 = v73.length
                            v123 = v113 < v122
                            del v122
                            v124 = v123
                        else:
                            v124 = False
                        v125 = v124 == False
                        if v125:
                            v126 = "The read index needs to be in range."
                            assert v124, v126
                            del v126
                        else:
                            pass
                        del v124, v125
                        v127 = v73[v113]
                        if v114:
                            v128 = v73.length
                            v129 = v110 < v128
                            del v128
                            v130 = v129
                        else:
                            v130 = False
                        del v114
                        v131 = v130 == False
                        if v131:
                            v132 = "The set index needs to be in range."
                            assert v130, v132
                            del v132
                        else:
                            pass
                        del v130, v131
                        v73[v110] = v127
                        del v127
                        if v121:
                            v133 = v73.length
                            v134 = v113 < v133
                            del v133
                            v135 = v134
                        else:
                            v135 = False
                        del v121
                        v136 = v135 == False
                        if v136:
                            v137 = "The set index needs to be in range."
                            assert v135, v137
                            del v137
                        else:
                            pass
                        del v135, v136
                        v73[v113] = v120
                        del v113, v120
                        v110 += 1 
                    del v109, v110
                    v138 = v73.length
                    v139 = v138 - 1
                    del v138
                    v140 = 0 <= v139
                    if v140:
                        v141 = v73.length
                        v142 = v139 < v141
                        del v141
                        v143 = v142
                    else:
                        v143 = False
                    del v140
                    v144 = v143 == False
                    if v144:
                        v145 = "The read index needs to be in range."
                        assert v143, v145
                        del v145
                    else:
                        pass
                    del v143, v144
                    v146 = v73[v139]
                    v73.length = v139
                    del v73, v139
                    v147 = v1.length
                    v148 = v147 < 32
                    v149 = v148 == False
                    if v149:
                        v150 = "The length has to be less than the maximum length of the array."
                        assert v148, v150
                        del v150
                    else:
                        pass
                    del v148, v149
                    v151 = v147 + 1
                    v1.length = v151
                    del v151
                    v152 = 0 <= v147
                    if v152:
                        v153 = v1.length
                        v154 = v147 < v153
                        del v153
                        v155 = v154
                    else:
                        v155 = False
                    del v152
                    v156 = v155 == False
                    if v156:
                        v157 = "The set index needs to be in range."
                        assert v155, v157
                        del v157
                    else:
                        pass
                    del v155, v156
                    v158 = US8_1(v64, v146)
                    v1[v147] = v158
                    del v147, v158
                    match v61:
                        case US5_0(): # None
                            match v146:
                                case US1_0(): # Call
                                    if v62:
                                        v230 = v64 == 0
                                        if v230:
                                            v231 = 1
                                        else:
                                            v231 = 0
                                        del v230
                                        v280 = US4_2(v61, False, v63, v231, v65, v66)
                                    else:
                                        v280 = US4_0(v61, v62, v63, v64, v65, v66)
                                case US1_1(): # Fold
                                    v280 = US4_5(v61, v62, v63, v64, v65, v66)
                                case US1_2(): # Raise
                                    if v95:
                                        v235 = v64 == 0
                                        if v235:
                                            v236 = 1
                                        else:
                                            v236 = 0
                                        del v235
                                        v237 = -1 + v66
                                        v238, v239 = (0, 0)
                                        while method14(v238):
                                            v241 = 0 <= v238
                                            if v241:
                                                v242 = v238 < 2
                                                v243 = v242
                                            else:
                                                v243 = False
                                            del v241
                                            v244 = v243 == False
                                            if v244:
                                                v245 = "The read index needs to be in range."
                                                assert v243, v245
                                                del v245
                                            else:
                                                pass
                                            del v243, v244
                                            v246 = v65[v238]
                                            v247 = v239 >= v246
                                            if v247:
                                                v248 = v239
                                            else:
                                                v248 = v246
                                            del v246, v247
                                            v239 = v248
                                            del v248
                                            v238 += 1 
                                        del v238
                                        v249 = static_array(2)
                                        v250 = 0
                                        while method14(v250):
                                            v252 = 0 <= v250
                                            if v252:
                                                v253 = v250 < 2
                                                v254 = v253
                                            else:
                                                v254 = False
                                            del v252
                                            v255 = v254 == False
                                            if v255:
                                                v256 = "The read index needs to be in range."
                                                assert v254, v256
                                                del v256
                                            else:
                                                pass
                                            del v254, v255
                                            v249[v250] = v239
                                            v250 += 1 
                                        del v239, v250
                                        v257 = static_array(2)
                                        v258 = 0
                                        while method14(v258):
                                            v260 = 0 <= v258
                                            if v260:
                                                v261 = v258 < 2
                                                v262 = v261
                                            else:
                                                v262 = False
                                            v263 = v262 == False
                                            if v263:
                                                v264 = "The read index needs to be in range."
                                                assert v262, v264
                                                del v264
                                            else:
                                                pass
                                            del v262, v263
                                            v265 = v249[v258]
                                            v266 = v258 == v64
                                            if v266:
                                                v267 = v265 + 2
                                                v268 = v267
                                            else:
                                                v268 = v265
                                            del v265, v266
                                            if v260:
                                                v269 = v258 < 2
                                                v270 = v269
                                            else:
                                                v270 = False
                                            del v260
                                            v271 = v270 == False
                                            if v271:
                                                v272 = "The read index needs to be in range."
                                                assert v270, v272
                                                del v272
                                            else:
                                                pass
                                            del v270, v271
                                            v257[v258] = v268
                                            del v268
                                            v258 += 1 
                                        del v249, v258
                                        v280 = US4_2(v61, False, v63, v236, v257, v237)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case US5_1(_): # Some
                            match v146:
                                case US1_0(): # Call
                                    if v62:
                                        v161 = v64 == 0
                                        if v161:
                                            v162 = 1
                                        else:
                                            v162 = 0
                                        del v161
                                        v280 = US4_2(v61, False, v63, v162, v65, v66)
                                    else:
                                        v164, v165 = (0, 0)
                                        while method14(v164):
                                            v167 = 0 <= v164
                                            if v167:
                                                v168 = v164 < 2
                                                v169 = v168
                                            else:
                                                v169 = False
                                            del v167
                                            v170 = v169 == False
                                            if v170:
                                                v171 = "The read index needs to be in range."
                                                assert v169, v171
                                                del v171
                                            else:
                                                pass
                                            del v169, v170
                                            v172 = v65[v164]
                                            v173 = v165 >= v172
                                            if v173:
                                                v174 = v165
                                            else:
                                                v174 = v172
                                            del v172, v173
                                            v165 = v174
                                            del v174
                                            v164 += 1 
                                        del v164
                                        v175 = static_array(2)
                                        v176 = 0
                                        while method14(v176):
                                            v178 = 0 <= v176
                                            if v178:
                                                v179 = v176 < 2
                                                v180 = v179
                                            else:
                                                v180 = False
                                            del v178
                                            v181 = v180 == False
                                            if v181:
                                                v182 = "The read index needs to be in range."
                                                assert v180, v182
                                                del v182
                                            else:
                                                pass
                                            del v180, v181
                                            v175[v176] = v165
                                            v176 += 1 
                                        del v165, v176
                                        v280 = US4_4(v61, v62, v63, v64, v175, v66)
                                case US1_1(): # Fold
                                    v280 = US4_5(v61, v62, v63, v64, v65, v66)
                                case US1_2(): # Raise
                                    if v95:
                                        v185 = v64 == 0
                                        if v185:
                                            v186 = 1
                                        else:
                                            v186 = 0
                                        del v185
                                        v187 = -1 + v66
                                        v188, v189 = (0, 0)
                                        while method14(v188):
                                            v191 = 0 <= v188
                                            if v191:
                                                v192 = v188 < 2
                                                v193 = v192
                                            else:
                                                v193 = False
                                            del v191
                                            v194 = v193 == False
                                            if v194:
                                                v195 = "The read index needs to be in range."
                                                assert v193, v195
                                                del v195
                                            else:
                                                pass
                                            del v193, v194
                                            v196 = v65[v188]
                                            v197 = v189 >= v196
                                            if v197:
                                                v198 = v189
                                            else:
                                                v198 = v196
                                            del v196, v197
                                            v189 = v198
                                            del v198
                                            v188 += 1 
                                        del v188
                                        v199 = static_array(2)
                                        v200 = 0
                                        while method14(v200):
                                            v202 = 0 <= v200
                                            if v202:
                                                v203 = v200 < 2
                                                v204 = v203
                                            else:
                                                v204 = False
                                            del v202
                                            v205 = v204 == False
                                            if v205:
                                                v206 = "The read index needs to be in range."
                                                assert v204, v206
                                                del v206
                                            else:
                                                pass
                                            del v204, v205
                                            v199[v200] = v189
                                            v200 += 1 
                                        del v189, v200
                                        v207 = static_array(2)
                                        v208 = 0
                                        while method14(v208):
                                            v210 = 0 <= v208
                                            if v210:
                                                v211 = v208 < 2
                                                v212 = v211
                                            else:
                                                v212 = False
                                            v213 = v212 == False
                                            if v213:
                                                v214 = "The read index needs to be in range."
                                                assert v212, v214
                                                del v214
                                            else:
                                                pass
                                            del v212, v213
                                            v215 = v199[v208]
                                            v216 = v208 == v64
                                            if v216:
                                                v217 = v215 + 4
                                                v218 = v217
                                            else:
                                                v218 = v215
                                            del v215, v216
                                            if v210:
                                                v219 = v208 < 2
                                                v220 = v219
                                            else:
                                                v220 = False
                                            del v210
                                            v221 = v220 == False
                                            if v221:
                                                v222 = "The read index needs to be in range."
                                                assert v220, v222
                                                del v222
                                            else:
                                                pass
                                            del v220, v221
                                            v207[v208] = v218
                                            del v218
                                            v208 += 1 
                                        del v199, v208
                                        v280 = US4_2(v61, False, v63, v186, v207, v187)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                    del v61, v62, v63, v64, v65, v66, v95, v146
                    return method13(v0, v1, v2, v280)
                case US2_1(): # Human
                    del v0, v1, v2, v61, v62, v63, v64, v65, v66, v72
                    return v3
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case US4_3(v284, v285, v286, v287, v288, v289, v290): # RoundWithAction
            del v3
            v291 = v1.length
            v292 = v291 < 32
            v293 = v292 == False
            if v293:
                v294 = "The length has to be less than the maximum length of the array."
                assert v292, v294
                del v294
            else:
                pass
            del v292, v293
            v295 = v291 + 1
            v1.length = v295
            del v295
            v296 = 0 <= v291
            if v296:
                v297 = v1.length
                v298 = v291 < v297
                del v297
                v299 = v298
            else:
                v299 = False
            del v296
            v300 = v299 == False
            if v300:
                v301 = "The set index needs to be in range."
                assert v299, v301
                del v301
            else:
                pass
            del v299, v300
            v302 = US8_1(v287, v290)
            v1[v291] = v302
            del v291, v302
            match v284:
                case US5_0(): # None
                    match v290:
                        case US1_0(): # Call
                            if v285:
                                v375 = v287 == 0
                                if v375:
                                    v376 = 1
                                else:
                                    v376 = 0
                                del v375
                                v426 = US4_2(v284, False, v286, v376, v288, v289)
                            else:
                                v426 = US4_0(v284, v285, v286, v287, v288, v289)
                        case US1_1(): # Fold
                            v426 = US4_5(v284, v285, v286, v287, v288, v289)
                        case US1_2(): # Raise
                            v380 = v289 > 0
                            if v380:
                                del v380
                                v381 = v287 == 0
                                if v381:
                                    v382 = 1
                                else:
                                    v382 = 0
                                del v381
                                v383 = -1 + v289
                                v384, v385 = (0, 0)
                                while method14(v384):
                                    v387 = 0 <= v384
                                    if v387:
                                        v388 = v384 < 2
                                        v389 = v388
                                    else:
                                        v389 = False
                                    del v387
                                    v390 = v389 == False
                                    if v390:
                                        v391 = "The read index needs to be in range."
                                        assert v389, v391
                                        del v391
                                    else:
                                        pass
                                    del v389, v390
                                    v392 = v288[v384]
                                    v393 = v385 >= v392
                                    if v393:
                                        v394 = v385
                                    else:
                                        v394 = v392
                                    del v392, v393
                                    v385 = v394
                                    del v394
                                    v384 += 1 
                                del v384
                                v395 = static_array(2)
                                v396 = 0
                                while method14(v396):
                                    v398 = 0 <= v396
                                    if v398:
                                        v399 = v396 < 2
                                        v400 = v399
                                    else:
                                        v400 = False
                                    del v398
                                    v401 = v400 == False
                                    if v401:
                                        v402 = "The read index needs to be in range."
                                        assert v400, v402
                                        del v402
                                    else:
                                        pass
                                    del v400, v401
                                    v395[v396] = v385
                                    v396 += 1 
                                del v385, v396
                                v403 = static_array(2)
                                v404 = 0
                                while method14(v404):
                                    v406 = 0 <= v404
                                    if v406:
                                        v407 = v404 < 2
                                        v408 = v407
                                    else:
                                        v408 = False
                                    v409 = v408 == False
                                    if v409:
                                        v410 = "The read index needs to be in range."
                                        assert v408, v410
                                        del v410
                                    else:
                                        pass
                                    del v408, v409
                                    v411 = v395[v404]
                                    v412 = v404 == v287
                                    if v412:
                                        v413 = v411 + 2
                                        v414 = v413
                                    else:
                                        v414 = v411
                                    del v411, v412
                                    if v406:
                                        v415 = v404 < 2
                                        v416 = v415
                                    else:
                                        v416 = False
                                    del v406
                                    v417 = v416 == False
                                    if v417:
                                        v418 = "The read index needs to be in range."
                                        assert v416, v418
                                        del v418
                                    else:
                                        pass
                                    del v416, v417
                                    v403[v404] = v414
                                    del v414
                                    v404 += 1 
                                del v395, v404
                                v426 = US4_2(v284, False, v286, v382, v403, v383)
                            else:
                                del v380
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case US5_1(_): # Some
                    match v290:
                        case US1_0(): # Call
                            if v285:
                                v305 = v287 == 0
                                if v305:
                                    v306 = 1
                                else:
                                    v306 = 0
                                del v305
                                v426 = US4_2(v284, False, v286, v306, v288, v289)
                            else:
                                v308, v309 = (0, 0)
                                while method14(v308):
                                    v311 = 0 <= v308
                                    if v311:
                                        v312 = v308 < 2
                                        v313 = v312
                                    else:
                                        v313 = False
                                    del v311
                                    v314 = v313 == False
                                    if v314:
                                        v315 = "The read index needs to be in range."
                                        assert v313, v315
                                        del v315
                                    else:
                                        pass
                                    del v313, v314
                                    v316 = v288[v308]
                                    v317 = v309 >= v316
                                    if v317:
                                        v318 = v309
                                    else:
                                        v318 = v316
                                    del v316, v317
                                    v309 = v318
                                    del v318
                                    v308 += 1 
                                del v308
                                v319 = static_array(2)
                                v320 = 0
                                while method14(v320):
                                    v322 = 0 <= v320
                                    if v322:
                                        v323 = v320 < 2
                                        v324 = v323
                                    else:
                                        v324 = False
                                    del v322
                                    v325 = v324 == False
                                    if v325:
                                        v326 = "The read index needs to be in range."
                                        assert v324, v326
                                        del v326
                                    else:
                                        pass
                                    del v324, v325
                                    v319[v320] = v309
                                    v320 += 1 
                                del v309, v320
                                v426 = US4_4(v284, v285, v286, v287, v319, v289)
                        case US1_1(): # Fold
                            v426 = US4_5(v284, v285, v286, v287, v288, v289)
                        case US1_2(): # Raise
                            v329 = v289 > 0
                            if v329:
                                del v329
                                v330 = v287 == 0
                                if v330:
                                    v331 = 1
                                else:
                                    v331 = 0
                                del v330
                                v332 = -1 + v289
                                v333, v334 = (0, 0)
                                while method14(v333):
                                    v336 = 0 <= v333
                                    if v336:
                                        v337 = v333 < 2
                                        v338 = v337
                                    else:
                                        v338 = False
                                    del v336
                                    v339 = v338 == False
                                    if v339:
                                        v340 = "The read index needs to be in range."
                                        assert v338, v340
                                        del v340
                                    else:
                                        pass
                                    del v338, v339
                                    v341 = v288[v333]
                                    v342 = v334 >= v341
                                    if v342:
                                        v343 = v334
                                    else:
                                        v343 = v341
                                    del v341, v342
                                    v334 = v343
                                    del v343
                                    v333 += 1 
                                del v333
                                v344 = static_array(2)
                                v345 = 0
                                while method14(v345):
                                    v347 = 0 <= v345
                                    if v347:
                                        v348 = v345 < 2
                                        v349 = v348
                                    else:
                                        v349 = False
                                    del v347
                                    v350 = v349 == False
                                    if v350:
                                        v351 = "The read index needs to be in range."
                                        assert v349, v351
                                        del v351
                                    else:
                                        pass
                                    del v349, v350
                                    v344[v345] = v334
                                    v345 += 1 
                                del v334, v345
                                v352 = static_array(2)
                                v353 = 0
                                while method14(v353):
                                    v355 = 0 <= v353
                                    if v355:
                                        v356 = v353 < 2
                                        v357 = v356
                                    else:
                                        v357 = False
                                    v358 = v357 == False
                                    if v358:
                                        v359 = "The read index needs to be in range."
                                        assert v357, v359
                                        del v359
                                    else:
                                        pass
                                    del v357, v358
                                    v360 = v344[v353]
                                    v361 = v353 == v287
                                    if v361:
                                        v362 = v360 + 4
                                        v363 = v362
                                    else:
                                        v363 = v360
                                    del v360, v361
                                    if v355:
                                        v364 = v353 < 2
                                        v365 = v364
                                    else:
                                        v365 = False
                                    del v355
                                    v366 = v365 == False
                                    if v366:
                                        v367 = "The read index needs to be in range."
                                        assert v365, v367
                                        del v367
                                    else:
                                        pass
                                    del v365, v366
                                    v352[v353] = v363
                                    del v363
                                    v353 += 1 
                                del v344, v353
                                v426 = US4_2(v284, False, v286, v331, v352, v332)
                            else:
                                del v329
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v284, v285, v286, v287, v288, v289, v290
            return method13(v0, v1, v2, v426)
        case US4_4(v30, v31, v32, v33, v34, v35): # TerminalCall
            del v0, v2
            v36 = 0 <= v33
            if v36:
                v37 = v33 < 2
                v38 = v37
            else:
                v38 = False
            del v36
            v39 = v38 == False
            if v39:
                v40 = "The read index needs to be in range."
                assert v38, v40
                del v40
            else:
                pass
            del v38, v39
            v41 = v34[v33]
            v42 = method15(v30, v31, v32, v33, v34, v35)
            del v30, v31, v33, v34, v35
            match v42:
                case US9_0(): # Eq
                    v47, v48 = 0, -1
                case US9_1(): # Gt
                    v47, v48 = v41, 0
                case US9_2(): # Lt
                    v47, v48 = v41, 1
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
            del v41, v42
            v49 = v1.length
            v50 = v49 < 32
            v51 = v50 == False
            if v51:
                v52 = "The length has to be less than the maximum length of the array."
                assert v50, v52
                del v52
            else:
                pass
            del v50, v51
            v53 = v49 + 1
            v1.length = v53
            del v53
            v54 = 0 <= v49
            if v54:
                v55 = v1.length
                v56 = v49 < v55
                del v55
                v57 = v56
            else:
                v57 = False
            del v54
            v58 = v57 == False
            if v58:
                v59 = "The set index needs to be in range."
                assert v57, v59
                del v59
            else:
                pass
            del v57, v58
            v60 = US8_3(v32, v47, v48)
            del v32, v47, v48
            v1[v49] = v60
            del v1, v49, v60
            return v3
        case US4_5(_, _, v6, v7, v8, _): # TerminalFold
            del v0, v2
            v10 = 0 <= v7
            if v10:
                v11 = v7 < 2
                v12 = v11
            else:
                v12 = False
            del v10
            v13 = v12 == False
            if v13:
                v14 = "The read index needs to be in range."
                assert v12, v14
                del v14
            else:
                pass
            del v12, v13
            v15 = v8[v7]
            del v8
            v16 = v7 == 0
            del v7
            if v16:
                v17 = 1
            else:
                v17 = 0
            del v16
            v18 = v1.length
            v19 = v18 < 32
            v20 = v19 == False
            if v20:
                v21 = "The length has to be less than the maximum length of the array."
                assert v19, v21
                del v21
            else:
                pass
            del v19, v20
            v22 = v18 + 1
            v1.length = v22
            del v22
            v23 = 0 <= v18
            if v23:
                v24 = v1.length
                v25 = v18 < v24
                del v24
                v26 = v25
            else:
                v26 = False
            del v23
            v27 = v26 == False
            if v27:
                v28 = "The set index needs to be in range."
                assert v26, v28
                del v28
            else:
                pass
            del v26, v27
            v29 = US8_3(v6, v15, v17)
            del v6, v15, v17
            v1[v18] = v29
            del v1, v18, v29
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method12(v0 : US3, v1 : static_array_list, v2 : static_array, v3 : US7, v4 : static_array_list, v5 : US4) -> Tuple[US3, static_array_list, static_array, US7]:
    del v0, v3
    v6 = method13(v4, v1, v2, v5)
    del v5
    match v6:
        case US4_2(v7, v8, v9, v10, v11, v12): # Round
            v13 = US3_1(v4, v6)
            del v4, v6
            v14 = US7_2(v7, v8, v9, v10, v11, v12)
            del v7, v8, v9, v10, v11, v12
            return v13, v1, v2, v14
        case US4_4(v15, v16, v17, v18, v19, v20): # TerminalCall
            del v4, v6
            v21 = US3_0()
            v22 = US7_1(v15, v16, v17, v18, v19, v20)
            del v15, v16, v17, v18, v19, v20
            return v21, v1, v2, v22
        case US4_5(v23, v24, v25, v26, v27, v28): # TerminalFold
            del v4, v6
            v29 = US3_0()
            v30 = US7_1(v23, v24, v25, v26, v27, v28)
            del v23, v24, v25, v26, v27, v28
            return v29, v1, v2, v30
        case t:
            del v1, v2, v4, v6
            raise Exception("Unexpected node received in play_loop.")
def method21(v0 : US6) -> object:
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
def method23(v0 : US5) -> object:
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
            v5 = method21(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method24(v0 : US1) -> object:
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
def method22(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method23(v1)
            del v1
            v8 = v2
            del v2
            v9 = []
            v10 = 0
            while method14(v10):
                v12 = 0 <= v10
                if v12:
                    v13 = v10 < 2
                    v14 = v13
                else:
                    v14 = False
                del v12
                v15 = v14 == False
                if v15:
                    v16 = "The read index needs to be in range."
                    assert v14, v16
                    del v16
                else:
                    pass
                del v14, v15
                v17 = v3[v10]
                v18 = method21(v17)
                del v17
                v9.append(v18)
                del v18
                v10 += 1 
            del v3, v10
            v19 = v4
            del v4
            v20 = []
            v21 = 0
            while method14(v21):
                v23 = 0 <= v21
                if v23:
                    v24 = v21 < 2
                    v25 = v24
                else:
                    v25 = False
                del v23
                v26 = v25 == False
                if v26:
                    v27 = "The read index needs to be in range."
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
            v43 = method23(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method14(v46):
                v48 = 0 <= v46
                if v48:
                    v49 = v46 < 2
                    v50 = v49
                else:
                    v50 = False
                del v48
                v51 = v50 == False
                if v51:
                    v52 = "The read index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = v39[v46]
                v54 = method21(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method14(v57):
                v59 = 0 <= v57
                if v59:
                    v60 = v57 < 2
                    v61 = v60
                else:
                    v61 = False
                del v59
                v62 = v61 == False
                if v62:
                    v63 = "The read index needs to be in range."
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
            v78 = method23(v70)
            del v70
            v79 = v71
            del v71
            v80 = []
            v81 = 0
            while method14(v81):
                v83 = 0 <= v81
                if v83:
                    v84 = v81 < 2
                    v85 = v84
                else:
                    v85 = False
                del v83
                v86 = v85 == False
                if v86:
                    v87 = "The read index needs to be in range."
                    assert v85, v87
                    del v87
                else:
                    pass
                del v85, v86
                v88 = v72[v81]
                v89 = method21(v88)
                del v88
                v80.append(v89)
                del v89
                v81 += 1 
            del v72, v81
            v90 = v73
            del v73
            v91 = []
            v92 = 0
            while method14(v92):
                v94 = 0 <= v92
                if v94:
                    v95 = v92 < 2
                    v96 = v95
                else:
                    v96 = False
                del v94
                v97 = v96 == False
                if v97:
                    v98 = "The read index needs to be in range."
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
            v103 = method24(v76)
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
            v113 = method23(v107)
            del v107
            v114 = v108
            del v108
            v115 = []
            v116 = 0
            while method14(v116):
                v118 = 0 <= v116
                if v118:
                    v119 = v116 < 2
                    v120 = v119
                else:
                    v120 = False
                del v118
                v121 = v120 == False
                if v121:
                    v122 = "The read index needs to be in range."
                    assert v120, v122
                    del v122
                else:
                    pass
                del v120, v121
                v123 = v109[v116]
                v124 = method21(v123)
                del v123
                v115.append(v124)
                del v124
                v116 += 1 
            del v109, v116
            v125 = v110
            del v110
            v126 = []
            v127 = 0
            while method14(v127):
                v129 = 0 <= v127
                if v129:
                    v130 = v127 < 2
                    v131 = v130
                else:
                    v131 = False
                del v129
                v132 = v131 == False
                if v132:
                    v133 = "The read index needs to be in range."
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
            v146 = method23(v140)
            del v140
            v147 = v141
            del v141
            v148 = []
            v149 = 0
            while method14(v149):
                v151 = 0 <= v149
                if v151:
                    v152 = v149 < 2
                    v153 = v152
                else:
                    v153 = False
                del v151
                v154 = v153 == False
                if v154:
                    v155 = "The read index needs to be in range."
                    assert v153, v155
                    del v155
                else:
                    pass
                del v153, v154
                v156 = v142[v149]
                v157 = method21(v156)
                del v156
                v148.append(v157)
                del v157
                v149 += 1 
            del v142, v149
            v158 = v143
            del v143
            v159 = []
            v160 = 0
            while method14(v160):
                v162 = 0 <= v160
                if v162:
                    v163 = v160 < 2
                    v164 = v163
                else:
                    v164 = False
                del v162
                v165 = v164 == False
                if v165:
                    v166 = "The read index needs to be in range."
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
def method20(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4, v5): # Some
            del v0
            v6 = []
            v7 = v4.length
            v8 = 0
            while method3(v7, v8):
                v10 = 0 <= v8
                if v10:
                    v11 = v4.length
                    v12 = v8 < v11
                    del v11
                    v13 = v12
                else:
                    v13 = False
                del v10
                v14 = v13 == False
                if v14:
                    v15 = "The read index needs to be in range."
                    assert v13, v15
                    del v15
                else:
                    pass
                del v13, v14
                v16 = v4[v8]
                v17 = method21(v16)
                del v16
                v6.append(v17)
                del v17
                v8 += 1 
            del v4, v7, v8
            v18 = method22(v5)
            del v5
            v19 = {'deck': v6, 'game': v18}
            del v6, v18
            v20 = "Some"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method25(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method21(v1)
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
            v9 = method24(v6)
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
            v17 = method21(v14)
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
            while method14(v25):
                v27 = 0 <= v25
                if v27:
                    v28 = v25 < 2
                    v29 = v28
                else:
                    v29 = False
                del v27
                v30 = v29 == False
                if v30:
                    v31 = "The read index needs to be in range."
                    assert v29, v31
                    del v31
                else:
                    pass
                del v29, v30
                v32 = v21[v25]
                v33 = method21(v32)
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
def method26(v0 : US2) -> object:
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
def method27(v0 : US7) -> object:
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
            v10 = method23(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method14(v13):
                v15 = 0 <= v13
                if v15:
                    v16 = v13 < 2
                    v17 = v16
                else:
                    v17 = False
                del v15
                v18 = v17 == False
                if v18:
                    v19 = "The read index needs to be in range."
                    assert v17, v19
                    del v19
                else:
                    pass
                del v17, v18
                v20 = v6[v13]
                v21 = method21(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method14(v24):
                v26 = 0 <= v24
                if v26:
                    v27 = v24 < 2
                    v28 = v27
                else:
                    v28 = False
                del v26
                v29 = v28 == False
                if v29:
                    v30 = "The read index needs to be in range."
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
            v43 = method23(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method14(v46):
                v48 = 0 <= v46
                if v48:
                    v49 = v46 < 2
                    v50 = v49
                else:
                    v50 = False
                del v48
                v51 = v50 == False
                if v51:
                    v52 = "The read index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = v39[v46]
                v54 = method21(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method14(v57):
                v59 = 0 <= v57
                if v59:
                    v60 = v57 < 2
                    v61 = v60
                else:
                    v61 = False
                del v59
                v62 = v61 == False
                if v62:
                    v63 = "The read index needs to be in range."
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
def method19(v0 : US3, v1 : static_array_list, v2 : static_array, v3 : US7) -> object:
    v4 = method20(v0)
    del v0
    v5 = []
    v6 = v1.length
    v7 = 0
    while method3(v6, v7):
        v9 = 0 <= v7
        if v9:
            v10 = v1.length
            v11 = v7 < v10
            del v10
            v12 = v11
        else:
            v12 = False
        del v9
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v15 = v1[v7]
        v16 = method25(v15)
        del v15
        v5.append(v16)
        del v16
        v7 += 1 
    del v1, v6, v7
    v17 = []
    v18 = 0
    while method14(v18):
        v20 = 0 <= v18
        if v20:
            v21 = v18 < 2
            v22 = v21
        else:
            v22 = False
        del v20
        v23 = v22 == False
        if v23:
            v24 = "The read index needs to be in range."
            assert v22, v24
            del v24
        else:
            pass
        del v22, v23
        v25 = v2[v18]
        v26 = method26(v25)
        del v25
        v17.append(v26)
        del v26
        v18 += 1 
    del v2, v18
    v27 = method27(v3)
    del v3
    v28 = {'messages': v5, 'pl_type': v17, 'ui_game_state': v27}
    del v5, v17, v27
    v29 = {'game_state': v4, 'ui_state': v28}
    del v4, v28
    return v29
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = Closure2()
    v3 = collections.namedtuple("Leduc_Game",['event_loop_cpu', 'event_loop_gpu', 'init'])(v0, v1, v2)
    del v0, v1, v2
    return v3

if __name__ == '__main__': print(main())
