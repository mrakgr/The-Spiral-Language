kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct US1;
struct US2;
struct US0;
struct US5;
struct US4;
struct US6;
struct US3;
struct US8;
struct US7;
struct US9;
struct Tuple0;
struct Tuple1;
__device__ unsigned long loop_2(unsigned long v0, curandStatePhilox4_32_10_t * v1);
struct US10;
__device__ long tag_4(US5 v0);
__device__ bool is_pair_5(long v0, long v1);
__device__ Tuple1 order_6(long v0, long v1);
__device__ US10 compare_hands_3(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5);
__device__ US6 play_loop_inner_1(array<US5,6l> & v0, long & v1, array<US8,32l> & v2, long & v3, array<US2,2l> & v4, US6 v5);
__device__ Tuple0 play_loop_0(US3 v0, array<US7,32l> & v1, array<US2,2l> & v2, US9 v3, array<US5,6l> & v4, long & v5, US6 v6);
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
            array<US2,2l> & v0;
        } case1; // PlayerChanged
    } v;
    unsigned long tag : 2;
};
struct US5 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US4 {
    union {
        struct {
            US5 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US6 {
    union {
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            long v3;
            long v5;
            bool v1;
        } case0; // ChanceCommunityCard
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            long v3;
            long v5;
            bool v1;
        } case2; // Round
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            US1 v6;
            long v3;
            long v5;
            bool v1;
        } case3; // RoundWithAction
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            long v3;
            long v5;
            bool v1;
        } case4; // TerminalCall
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
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
            array<US4,6l> & v0;
            US6 v1;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US8 {
    union {
        struct {
            US5 v0;
        } case0; // CommunityCardIs
        struct {
            US1 v1;
            long v0;
        } case1; // PlayerAction
        struct {
            US5 v1;
            long v0;
        } case2; // PlayerGotCard
        struct {
            array<US5,2l> & v0;
            long v1;
            long v2;
        } case3; // Showdown
    } v;
    unsigned long tag : 3;
};
struct US7 {
    union {
        struct {
            US8 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US9 {
    union {
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            long v3;
            long v5;
            bool v1;
        } case1; // GameOver
        struct {
            US4 v0;
            array<US5,2l> & v2;
            array<long,2l> & v4;
            long v3;
            long v5;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US3 v0;
    array<US7,32l> & v1;
    array<US2,2l> & v2;
    US9 v3;
    __device__ Tuple0(US3 t0, array<US7,32l> & t1, array<US2,2l> & t2, US9 t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    long v0;
    long v1;
    __device__ Tuple1(long t0, long t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
struct US10 {
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
__device__ US0 US0_1(array<US2,2l> & v0) { // PlayerChanged
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
__device__ US5 US5_0() { // Jack
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1() { // King
    US5 x;
    x.tag = 1;
    return x;
}
__device__ US5 US5_2() { // Queen
    US5 x;
    x.tag = 2;
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
__device__ US6 US6_0(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // ChanceCommunityCard
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
__device__ US6 US6_2(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // Round
    US6 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ US6 US6_3(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5, US1 v6) { // RoundWithAction
    US6 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US6 US6_4(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // TerminalCall
    US6 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US6 US6_5(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // TerminalFold
    US6 x;
    x.tag = 5;
    x.v.case5.v0 = v0; x.v.case5.v1 = v1; x.v.case5.v2 = v2; x.v.case5.v3 = v3; x.v.case5.v4 = v4; x.v.case5.v5 = v5;
    return x;
}
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(array<US4,6l> & v0, US6 v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 6l;
    return v1;
}
__device__ US8 US8_0(US5 v0) { // CommunityCardIs
    US8 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US8 US8_1(long v0, US1 v1) { // PlayerAction
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US8 US8_2(long v0, US5 v1) { // PlayerGotCard
    US8 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1;
    return x;
}
__device__ US8 US8_3(array<US5,2l> & v0, long v1, long v2) { // Showdown
    US8 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2;
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
__device__ inline bool while_method_2(long v0){
    bool v1;
    v1 = v0 < 32l;
    return v1;
}
__device__ US9 US9_0() { // GameNotStarted
    US9 x;
    x.tag = 0;
    return x;
}
__device__ US9 US9_1(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // GameOver
    US9 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US9 US9_2(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5) { // WaitingForActionFromPlayerId
    US9 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
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
__device__ long tag_4(US5 v0){
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
__device__ US10 compare_hands_3(US4 v0, bool v1, array<US5,2l> & v2, long v3, array<long,2l> & v4, long v5){
    switch (v0.tag) {
        case 0: { // None
            printf("%s\n", "Expected the community card to be present in the table.");
            asm("exit;");
            break;
        }
        default: { // Some
            US5 v7 = v0.v.case1.v0;
            long v8;
            v8 = tag_4(v7);
            US5 v9;
            v9 = v2.v[0l];
            long v10;
            v10 = tag_4(v9);
            US5 v11;
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
                        return US10_2();
                    } else {
                        bool v17;
                        v17 = v10 > v12;
                        if (v17){
                            return US10_1();
                        } else {
                            return US10_0();
                        }
                    }
                } else {
                    return US10_1();
                }
            } else {
                if (v14){
                    return US10_2();
                } else {
                    long v25; long v26;
                    Tuple1 tmp7 = order_6(v8, v10);
                    v25 = tmp7.v0; v26 = tmp7.v1;
                    long v27; long v28;
                    Tuple1 tmp8 = order_6(v8, v12);
                    v27 = tmp8.v0; v28 = tmp8.v1;
                    bool v29;
                    v29 = v25 < v27;
                    US10 v35;
                    if (v29){
                        v35 = US10_2();
                    } else {
                        bool v31;
                        v31 = v25 > v27;
                        if (v31){
                            v35 = US10_1();
                        } else {
                            v35 = US10_0();
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
                            return US10_2();
                        } else {
                            bool v39;
                            v39 = v26 > v28;
                            if (v39){
                                return US10_1();
                            } else {
                                return US10_0();
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
__device__ US6 play_loop_inner_1(array<US5,6l> & v0, long & v1, array<US8,32l> & v2, long & v3, array<US2,2l> & v4, US6 v5){
    switch (v5.tag) {
        case 0: { // ChanceCommunityCard
            US4 v421 = v5.v.case0.v0; bool v422 = v5.v.case0.v1; array<US5,2l> & v423 = v5.v.case0.v2; long v424 = v5.v.case0.v3; array<long,2l> & v425 = v5.v.case0.v4; long v426 = v5.v.case0.v5;
            long & v427 = v1;
            long v428;
            v428 = v427 - 1l;
            bool v429;
            v429 = 0l <= v428;
            bool v432;
            if (v429){
                long & v430 = v1;
                bool v431;
                v431 = v428 < v430;
                v432 = v431;
            } else {
                v432 = false;
            }
            bool v433;
            v433 = v432 == false;
            if (v433){
                assert("The read index needs to be in range." && v432);
            } else {
            }
            bool v435;
            if (v429){
                bool v434;
                v434 = v428 < 6l;
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
            US5 v437;
            v437 = v0.v[v428];
            long & v438 = v1;
            v1 = v428;
            long & v439 = v3;
            long v440;
            v440 = 1l + v439;
            v3 = v440;
            bool v441;
            v441 = 0l <= v439;
            bool v444;
            if (v441){
                long & v442 = v3;
                bool v443;
                v443 = v439 < v442;
                v444 = v443;
            } else {
                v444 = false;
            }
            bool v445;
            v445 = v444 == false;
            if (v445){
                assert("The set index needs to be in range." && v444);
            } else {
            }
            bool v447;
            if (v441){
                bool v446;
                v446 = v439 < 32l;
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
            US8 v449;
            v449 = US8_0(v437);
            v2.v[v439] = v449;
            long v450;
            v450 = 2l;
            long v451; long v452;
            Tuple1 tmp0 = Tuple1(0l, 0l);
            v451 = tmp0.v0; v452 = tmp0.v1;
            while (while_method_0(v451)){
                bool v454;
                v454 = 0l <= v451;
                bool v456;
                if (v454){
                    bool v455;
                    v455 = v451 < 2l;
                    v456 = v455;
                } else {
                    v456 = false;
                }
                bool v457;
                v457 = v456 == false;
                if (v457){
                    assert("The read index needs to be in range." && v456);
                } else {
                }
                long v458;
                v458 = v425.v[v451];
                bool v459;
                v459 = v452 >= v458;
                long v460;
                if (v459){
                    v460 = v452;
                } else {
                    v460 = v458;
                }
                v452 = v460;
                v451 += 1l ;
            }
            array<long,2l> v461;
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
                    assert("The read index needs to be in range." && v466);
                } else {
                }
                v461.v[v462] = v452;
                v462 += 1l ;
            }
            US4 v468;
            v468 = US4_1(v437);
            bool v469;
            v469 = true;
            long v470;
            v470 = 0l;
            US6 v471;
            v471 = US6_2(v468, v469, v423, v470, v461, v450);
            return play_loop_inner_1(v0, v1, v2, v3, v4, v471);
            break;
        }
        case 1: { // ChanceInit
            long & v473 = v1;
            long v474;
            v474 = v473 - 1l;
            bool v475;
            v475 = 0l <= v474;
            bool v478;
            if (v475){
                long & v476 = v1;
                bool v477;
                v477 = v474 < v476;
                v478 = v477;
            } else {
                v478 = false;
            }
            bool v479;
            v479 = v478 == false;
            if (v479){
                assert("The read index needs to be in range." && v478);
            } else {
            }
            bool v481;
            if (v475){
                bool v480;
                v480 = v474 < 6l;
                v481 = v480;
            } else {
                v481 = false;
            }
            bool v482;
            v482 = v481 == false;
            if (v482){
                assert("The read index needs to be in range." && v481);
            } else {
            }
            US5 v483;
            v483 = v0.v[v474];
            long & v484 = v1;
            v1 = v474;
            long & v485 = v1;
            long v486;
            v486 = v485 - 1l;
            bool v487;
            v487 = 0l <= v486;
            bool v490;
            if (v487){
                long & v488 = v1;
                bool v489;
                v489 = v486 < v488;
                v490 = v489;
            } else {
                v490 = false;
            }
            bool v491;
            v491 = v490 == false;
            if (v491){
                assert("The read index needs to be in range." && v490);
            } else {
            }
            bool v493;
            if (v487){
                bool v492;
                v492 = v486 < 6l;
                v493 = v492;
            } else {
                v493 = false;
            }
            bool v494;
            v494 = v493 == false;
            if (v494){
                assert("The read index needs to be in range." && v493);
            } else {
            }
            US5 v495;
            v495 = v0.v[v486];
            long & v496 = v1;
            v1 = v486;
            long & v497 = v3;
            long v498;
            v498 = 1l + v497;
            v3 = v498;
            bool v499;
            v499 = 0l <= v497;
            bool v502;
            if (v499){
                long & v500 = v3;
                bool v501;
                v501 = v497 < v500;
                v502 = v501;
            } else {
                v502 = false;
            }
            bool v503;
            v503 = v502 == false;
            if (v503){
                assert("The set index needs to be in range." && v502);
            } else {
            }
            bool v505;
            if (v499){
                bool v504;
                v504 = v497 < 32l;
                v505 = v504;
            } else {
                v505 = false;
            }
            bool v506;
            v506 = v505 == false;
            if (v506){
                assert("The read index needs to be in range." && v505);
            } else {
            }
            US8 v507;
            v507 = US8_2(0l, v483);
            v2.v[v497] = v507;
            long & v508 = v3;
            long v509;
            v509 = 1l + v508;
            v3 = v509;
            bool v510;
            v510 = 0l <= v508;
            bool v513;
            if (v510){
                long & v511 = v3;
                bool v512;
                v512 = v508 < v511;
                v513 = v512;
            } else {
                v513 = false;
            }
            bool v514;
            v514 = v513 == false;
            if (v514){
                assert("The set index needs to be in range." && v513);
            } else {
            }
            bool v516;
            if (v510){
                bool v515;
                v515 = v508 < 32l;
                v516 = v515;
            } else {
                v516 = false;
            }
            bool v517;
            v517 = v516 == false;
            if (v517){
                assert("The read index needs to be in range." && v516);
            } else {
            }
            US8 v518;
            v518 = US8_2(1l, v495);
            v2.v[v508] = v518;
            long v519;
            v519 = 2l;
            array<long,2l> v520;
            v520.v[0l] = 1l;
            v520.v[1l] = 1l;
            array<US5,2l> v521;
            v521.v[0l] = v483;
            v521.v[1l] = v495;
            US4 v522;
            v522 = US4_0();
            bool v523;
            v523 = true;
            long v524;
            v524 = 0l;
            US6 v525;
            v525 = US6_2(v522, v523, v521, v524, v520, v519);
            return play_loop_inner_1(v0, v1, v2, v3, v4, v525);
            break;
        }
        case 2: { // Round
            US4 v59 = v5.v.case2.v0; bool v60 = v5.v.case2.v1; array<US5,2l> & v61 = v5.v.case2.v2; long v62 = v5.v.case2.v3; array<long,2l> & v63 = v5.v.case2.v4; long v64 = v5.v.case2.v5;
            bool v65;
            v65 = 0l <= v62;
            bool v67;
            if (v65){
                bool v66;
                v66 = v62 < 2l;
                v67 = v66;
            } else {
                v67 = false;
            }
            bool v68;
            v68 = v67 == false;
            if (v68){
                assert("The read index needs to be in range." && v67);
            } else {
            }
            US2 v69;
            v69 = v4.v[v62];
            switch (v69.tag) {
                case 0: { // Computer
                    array<US1,3l> v70;
                    long v71 = 0l;
                    long & v72 = v71;
                    v71 = 1l;
                    long & v73 = v71;
                    bool v74;
                    v74 = 0l < v73;
                    bool v75;
                    v75 = v74 == false;
                    if (v75){
                        assert("The set index needs to be in range." && v74);
                    } else {
                    }
                    US1 v76;
                    v76 = US1_0();
                    v70.v[0l] = v76;
                    long v77;
                    v77 = v63.v[0l];
                    long v78;
                    v78 = v63.v[1l];
                    bool v79;
                    v79 = v77 == v78;
                    bool v80;
                    v80 = v79 != true;
                    if (v80){
                        long & v81 = v71;
                        long v82;
                        v82 = 1l + v81;
                        v71 = v82;
                        bool v83;
                        v83 = 0l <= v81;
                        bool v86;
                        if (v83){
                            long & v84 = v71;
                            bool v85;
                            v85 = v81 < v84;
                            v86 = v85;
                        } else {
                            v86 = false;
                        }
                        bool v87;
                        v87 = v86 == false;
                        if (v87){
                            assert("The set index needs to be in range." && v86);
                        } else {
                        }
                        bool v89;
                        if (v83){
                            bool v88;
                            v88 = v81 < 3l;
                            v89 = v88;
                        } else {
                            v89 = false;
                        }
                        bool v90;
                        v90 = v89 == false;
                        if (v90){
                            assert("The read index needs to be in range." && v89);
                        } else {
                        }
                        US1 v91;
                        v91 = US1_1();
                        v70.v[v81] = v91;
                    } else {
                    }
                    bool v92;
                    v92 = v64 > 0l;
                    if (v92){
                        long & v93 = v71;
                        long v94;
                        v94 = 1l + v93;
                        v71 = v94;
                        bool v95;
                        v95 = 0l <= v93;
                        bool v98;
                        if (v95){
                            long & v96 = v71;
                            bool v97;
                            v97 = v93 < v96;
                            v98 = v97;
                        } else {
                            v98 = false;
                        }
                        bool v99;
                        v99 = v98 == false;
                        if (v99){
                            assert("The set index needs to be in range." && v98);
                        } else {
                        }
                        bool v101;
                        if (v95){
                            bool v100;
                            v100 = v93 < 3l;
                            v101 = v100;
                        } else {
                            v101 = false;
                        }
                        bool v102;
                        v102 = v101 == false;
                        if (v102){
                            assert("The read index needs to be in range." && v101);
                        } else {
                        }
                        US1 v103;
                        v103 = US1_2();
                        v70.v[v93] = v103;
                    } else {
                    }
                    unsigned long long v104;
                    v104 = clock64();
                    curandStatePhilox4_32_10_t v105;
                    curandStatePhilox4_32_10_t * v106 = &v105;
                    curand_init(v104,0ull,0ull,v106);
                    long & v107 = v71;
                    long v108;
                    v108 = v107 - 1l;
                    long v109;
                    v109 = 0l;
                    while (while_method_3(v108, v109)){
                        long & v111 = v71;
                        long v112;
                        v112 = v111 - v109;
                        unsigned long v113;
                        v113 = (unsigned long)v112;
                        unsigned long v114;
                        v114 = loop_2(v113, v106);
                        unsigned long v115;
                        v115 = (unsigned long)v109;
                        unsigned long v116;
                        v116 = v114 - v115;
                        long v117;
                        v117 = (long)v116;
                        bool v118;
                        v118 = 0l <= v109;
                        bool v121;
                        if (v118){
                            long & v119 = v71;
                            bool v120;
                            v120 = v109 < v119;
                            v121 = v120;
                        } else {
                            v121 = false;
                        }
                        bool v122;
                        v122 = v121 == false;
                        if (v122){
                            assert("The read index needs to be in range." && v121);
                        } else {
                        }
                        bool v124;
                        if (v118){
                            bool v123;
                            v123 = v109 < 3l;
                            v124 = v123;
                        } else {
                            v124 = false;
                        }
                        bool v125;
                        v125 = v124 == false;
                        if (v125){
                            assert("The read index needs to be in range." && v124);
                        } else {
                        }
                        US1 v126;
                        v126 = v70.v[v109];
                        bool v127;
                        v127 = 0l <= v117;
                        bool v130;
                        if (v127){
                            long & v128 = v71;
                            bool v129;
                            v129 = v117 < v128;
                            v130 = v129;
                        } else {
                            v130 = false;
                        }
                        bool v131;
                        v131 = v130 == false;
                        if (v131){
                            assert("The read index needs to be in range." && v130);
                        } else {
                        }
                        bool v133;
                        if (v127){
                            bool v132;
                            v132 = v117 < 3l;
                            v133 = v132;
                        } else {
                            v133 = false;
                        }
                        bool v134;
                        v134 = v133 == false;
                        if (v134){
                            assert("The read index needs to be in range." && v133);
                        } else {
                        }
                        US1 v135;
                        v135 = v70.v[v117];
                        bool v138;
                        if (v118){
                            long & v136 = v71;
                            bool v137;
                            v137 = v109 < v136;
                            v138 = v137;
                        } else {
                            v138 = false;
                        }
                        bool v139;
                        v139 = v138 == false;
                        if (v139){
                            assert("The set index needs to be in range." && v138);
                        } else {
                        }
                        bool v141;
                        if (v118){
                            bool v140;
                            v140 = v109 < 3l;
                            v141 = v140;
                        } else {
                            v141 = false;
                        }
                        bool v142;
                        v142 = v141 == false;
                        if (v142){
                            assert("The read index needs to be in range." && v141);
                        } else {
                        }
                        v70.v[v109] = v135;
                        bool v145;
                        if (v127){
                            long & v143 = v71;
                            bool v144;
                            v144 = v117 < v143;
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
                        bool v148;
                        if (v127){
                            bool v147;
                            v147 = v117 < 3l;
                            v148 = v147;
                        } else {
                            v148 = false;
                        }
                        bool v149;
                        v149 = v148 == false;
                        if (v149){
                            assert("The read index needs to be in range." && v148);
                        } else {
                        }
                        v70.v[v117] = v126;
                        v109 += 1l ;
                    }
                    long & v150 = v71;
                    long v151;
                    v151 = v150 - 1l;
                    bool v152;
                    v152 = 0l <= v151;
                    bool v155;
                    if (v152){
                        long & v153 = v71;
                        bool v154;
                        v154 = v151 < v153;
                        v155 = v154;
                    } else {
                        v155 = false;
                    }
                    bool v156;
                    v156 = v155 == false;
                    if (v156){
                        assert("The read index needs to be in range." && v155);
                    } else {
                    }
                    bool v158;
                    if (v152){
                        bool v157;
                        v157 = v151 < 3l;
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
                    US1 v160;
                    v160 = v70.v[v151];
                    long & v161 = v71;
                    v71 = v151;
                    long & v162 = v3;
                    long v163;
                    v163 = 1l + v162;
                    v3 = v163;
                    bool v164;
                    v164 = 0l <= v162;
                    bool v167;
                    if (v164){
                        long & v165 = v3;
                        bool v166;
                        v166 = v162 < v165;
                        v167 = v166;
                    } else {
                        v167 = false;
                    }
                    bool v168;
                    v168 = v167 == false;
                    if (v168){
                        assert("The set index needs to be in range." && v167);
                    } else {
                    }
                    bool v170;
                    if (v164){
                        bool v169;
                        v169 = v162 < 32l;
                        v170 = v169;
                    } else {
                        v170 = false;
                    }
                    bool v171;
                    v171 = v170 == false;
                    if (v171){
                        assert("The read index needs to be in range." && v170);
                    } else {
                    }
                    US8 v172;
                    v172 = US8_1(v62, v160);
                    v2.v[v162] = v172;
                    US6 v284;
                    switch (v59.tag) {
                        case 0: { // None
                            switch (v160.tag) {
                                case 0: { // Call
                                    if (v60){
                                        bool v238;
                                        v238 = v62 == 0l;
                                        long v239;
                                        if (v238){
                                            v239 = 1l;
                                        } else {
                                            v239 = 0l;
                                        }
                                        v284 = US6_2(v59, false, v61, v239, v63, v64);
                                    } else {
                                        v284 = US6_0(v59, v60, v61, v62, v63, v64);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v284 = US6_5(v59, v60, v61, v62, v63, v64);
                                    break;
                                }
                                default: { // Raise
                                    if (v92){
                                        bool v243;
                                        v243 = v62 == 0l;
                                        long v244;
                                        if (v243){
                                            v244 = 1l;
                                        } else {
                                            v244 = 0l;
                                        }
                                        long v245;
                                        v245 = -1l + v64;
                                        long v246; long v247;
                                        Tuple1 tmp1 = Tuple1(0l, 0l);
                                        v246 = tmp1.v0; v247 = tmp1.v1;
                                        while (while_method_0(v246)){
                                            bool v249;
                                            v249 = 0l <= v246;
                                            bool v251;
                                            if (v249){
                                                bool v250;
                                                v250 = v246 < 2l;
                                                v251 = v250;
                                            } else {
                                                v251 = false;
                                            }
                                            bool v252;
                                            v252 = v251 == false;
                                            if (v252){
                                                assert("The read index needs to be in range." && v251);
                                            } else {
                                            }
                                            long v253;
                                            v253 = v63.v[v246];
                                            bool v254;
                                            v254 = v247 >= v253;
                                            long v255;
                                            if (v254){
                                                v255 = v247;
                                            } else {
                                                v255 = v253;
                                            }
                                            v247 = v255;
                                            v246 += 1l ;
                                        }
                                        array<long,2l> v256;
                                        long v257;
                                        v257 = 0l;
                                        while (while_method_0(v257)){
                                            bool v259;
                                            v259 = 0l <= v257;
                                            bool v261;
                                            if (v259){
                                                bool v260;
                                                v260 = v257 < 2l;
                                                v261 = v260;
                                            } else {
                                                v261 = false;
                                            }
                                            bool v262;
                                            v262 = v261 == false;
                                            if (v262){
                                                assert("The read index needs to be in range." && v261);
                                            } else {
                                            }
                                            v256.v[v257] = v247;
                                            v257 += 1l ;
                                        }
                                        array<long,2l> v263;
                                        long v264;
                                        v264 = 0l;
                                        while (while_method_0(v264)){
                                            bool v266;
                                            v266 = 0l <= v264;
                                            bool v268;
                                            if (v266){
                                                bool v267;
                                                v267 = v264 < 2l;
                                                v268 = v267;
                                            } else {
                                                v268 = false;
                                            }
                                            bool v269;
                                            v269 = v268 == false;
                                            if (v269){
                                                assert("The read index needs to be in range." && v268);
                                            } else {
                                            }
                                            long v270;
                                            v270 = v256.v[v264];
                                            bool v271;
                                            v271 = v264 == v62;
                                            long v273;
                                            if (v271){
                                                long v272;
                                                v272 = v270 + 2l;
                                                v273 = v272;
                                            } else {
                                                v273 = v270;
                                            }
                                            bool v275;
                                            if (v266){
                                                bool v274;
                                                v274 = v264 < 2l;
                                                v275 = v274;
                                            } else {
                                                v275 = false;
                                            }
                                            bool v276;
                                            v276 = v275 == false;
                                            if (v276){
                                                assert("The read index needs to be in range." && v275);
                                            } else {
                                            }
                                            v263.v[v264] = v273;
                                            v264 += 1l ;
                                        }
                                        v284 = US6_2(v59, false, v61, v244, v263, v245);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                            break;
                        }
                        default: { // Some
                            US5 v173 = v59.v.case1.v0;
                            switch (v160.tag) {
                                case 0: { // Call
                                    if (v60){
                                        bool v175;
                                        v175 = v62 == 0l;
                                        long v176;
                                        if (v175){
                                            v176 = 1l;
                                        } else {
                                            v176 = 0l;
                                        }
                                        v284 = US6_2(v59, false, v61, v176, v63, v64);
                                    } else {
                                        long v178; long v179;
                                        Tuple1 tmp2 = Tuple1(0l, 0l);
                                        v178 = tmp2.v0; v179 = tmp2.v1;
                                        while (while_method_0(v178)){
                                            bool v181;
                                            v181 = 0l <= v178;
                                            bool v183;
                                            if (v181){
                                                bool v182;
                                                v182 = v178 < 2l;
                                                v183 = v182;
                                            } else {
                                                v183 = false;
                                            }
                                            bool v184;
                                            v184 = v183 == false;
                                            if (v184){
                                                assert("The read index needs to be in range." && v183);
                                            } else {
                                            }
                                            long v185;
                                            v185 = v63.v[v178];
                                            bool v186;
                                            v186 = v179 >= v185;
                                            long v187;
                                            if (v186){
                                                v187 = v179;
                                            } else {
                                                v187 = v185;
                                            }
                                            v179 = v187;
                                            v178 += 1l ;
                                        }
                                        array<long,2l> v188;
                                        long v189;
                                        v189 = 0l;
                                        while (while_method_0(v189)){
                                            bool v191;
                                            v191 = 0l <= v189;
                                            bool v193;
                                            if (v191){
                                                bool v192;
                                                v192 = v189 < 2l;
                                                v193 = v192;
                                            } else {
                                                v193 = false;
                                            }
                                            bool v194;
                                            v194 = v193 == false;
                                            if (v194){
                                                assert("The read index needs to be in range." && v193);
                                            } else {
                                            }
                                            v188.v[v189] = v179;
                                            v189 += 1l ;
                                        }
                                        v284 = US6_4(v59, v60, v61, v62, v188, v64);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v284 = US6_5(v59, v60, v61, v62, v63, v64);
                                    break;
                                }
                                default: { // Raise
                                    if (v92){
                                        bool v197;
                                        v197 = v62 == 0l;
                                        long v198;
                                        if (v197){
                                            v198 = 1l;
                                        } else {
                                            v198 = 0l;
                                        }
                                        long v199;
                                        v199 = -1l + v64;
                                        long v200; long v201;
                                        Tuple1 tmp3 = Tuple1(0l, 0l);
                                        v200 = tmp3.v0; v201 = tmp3.v1;
                                        while (while_method_0(v200)){
                                            bool v203;
                                            v203 = 0l <= v200;
                                            bool v205;
                                            if (v203){
                                                bool v204;
                                                v204 = v200 < 2l;
                                                v205 = v204;
                                            } else {
                                                v205 = false;
                                            }
                                            bool v206;
                                            v206 = v205 == false;
                                            if (v206){
                                                assert("The read index needs to be in range." && v205);
                                            } else {
                                            }
                                            long v207;
                                            v207 = v63.v[v200];
                                            bool v208;
                                            v208 = v201 >= v207;
                                            long v209;
                                            if (v208){
                                                v209 = v201;
                                            } else {
                                                v209 = v207;
                                            }
                                            v201 = v209;
                                            v200 += 1l ;
                                        }
                                        array<long,2l> v210;
                                        long v211;
                                        v211 = 0l;
                                        while (while_method_0(v211)){
                                            bool v213;
                                            v213 = 0l <= v211;
                                            bool v215;
                                            if (v213){
                                                bool v214;
                                                v214 = v211 < 2l;
                                                v215 = v214;
                                            } else {
                                                v215 = false;
                                            }
                                            bool v216;
                                            v216 = v215 == false;
                                            if (v216){
                                                assert("The read index needs to be in range." && v215);
                                            } else {
                                            }
                                            v210.v[v211] = v201;
                                            v211 += 1l ;
                                        }
                                        array<long,2l> v217;
                                        long v218;
                                        v218 = 0l;
                                        while (while_method_0(v218)){
                                            bool v220;
                                            v220 = 0l <= v218;
                                            bool v222;
                                            if (v220){
                                                bool v221;
                                                v221 = v218 < 2l;
                                                v222 = v221;
                                            } else {
                                                v222 = false;
                                            }
                                            bool v223;
                                            v223 = v222 == false;
                                            if (v223){
                                                assert("The read index needs to be in range." && v222);
                                            } else {
                                            }
                                            long v224;
                                            v224 = v210.v[v218];
                                            bool v225;
                                            v225 = v218 == v62;
                                            long v227;
                                            if (v225){
                                                long v226;
                                                v226 = v224 + 4l;
                                                v227 = v226;
                                            } else {
                                                v227 = v224;
                                            }
                                            bool v229;
                                            if (v220){
                                                bool v228;
                                                v228 = v218 < 2l;
                                                v229 = v228;
                                            } else {
                                                v229 = false;
                                            }
                                            bool v230;
                                            v230 = v229 == false;
                                            if (v230){
                                                assert("The read index needs to be in range." && v229);
                                            } else {
                                            }
                                            v217.v[v218] = v227;
                                            v218 += 1l ;
                                        }
                                        v284 = US6_2(v59, false, v61, v198, v217, v199);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                        }
                    }
                    return play_loop_inner_1(v0, v1, v2, v3, v4, v284);
                    break;
                }
                default: { // Human
                    return v5;
                }
            }
            break;
        }
        case 3: { // RoundWithAction
            US4 v288 = v5.v.case3.v0; bool v289 = v5.v.case3.v1; array<US5,2l> & v290 = v5.v.case3.v2; long v291 = v5.v.case3.v3; array<long,2l> & v292 = v5.v.case3.v4; long v293 = v5.v.case3.v5; US1 v294 = v5.v.case3.v6;
            long & v295 = v3;
            long v296;
            v296 = 1l + v295;
            v3 = v296;
            bool v297;
            v297 = 0l <= v295;
            bool v300;
            if (v297){
                long & v298 = v3;
                bool v299;
                v299 = v295 < v298;
                v300 = v299;
            } else {
                v300 = false;
            }
            bool v301;
            v301 = v300 == false;
            if (v301){
                assert("The set index needs to be in range." && v300);
            } else {
            }
            bool v303;
            if (v297){
                bool v302;
                v302 = v295 < 32l;
                v303 = v302;
            } else {
                v303 = false;
            }
            bool v304;
            v304 = v303 == false;
            if (v304){
                assert("The read index needs to be in range." && v303);
            } else {
            }
            US8 v305;
            v305 = US8_1(v291, v294);
            v2.v[v295] = v305;
            US6 v419;
            switch (v288.tag) {
                case 0: { // None
                    switch (v294.tag) {
                        case 0: { // Call
                            if (v289){
                                bool v372;
                                v372 = v291 == 0l;
                                long v373;
                                if (v372){
                                    v373 = 1l;
                                } else {
                                    v373 = 0l;
                                }
                                v419 = US6_2(v288, false, v290, v373, v292, v293);
                            } else {
                                v419 = US6_0(v288, v289, v290, v291, v292, v293);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v419 = US6_5(v288, v289, v290, v291, v292, v293);
                            break;
                        }
                        default: { // Raise
                            bool v377;
                            v377 = v293 > 0l;
                            if (v377){
                                bool v378;
                                v378 = v291 == 0l;
                                long v379;
                                if (v378){
                                    v379 = 1l;
                                } else {
                                    v379 = 0l;
                                }
                                long v380;
                                v380 = -1l + v293;
                                long v381; long v382;
                                Tuple1 tmp4 = Tuple1(0l, 0l);
                                v381 = tmp4.v0; v382 = tmp4.v1;
                                while (while_method_0(v381)){
                                    bool v384;
                                    v384 = 0l <= v381;
                                    bool v386;
                                    if (v384){
                                        bool v385;
                                        v385 = v381 < 2l;
                                        v386 = v385;
                                    } else {
                                        v386 = false;
                                    }
                                    bool v387;
                                    v387 = v386 == false;
                                    if (v387){
                                        assert("The read index needs to be in range." && v386);
                                    } else {
                                    }
                                    long v388;
                                    v388 = v292.v[v381];
                                    bool v389;
                                    v389 = v382 >= v388;
                                    long v390;
                                    if (v389){
                                        v390 = v382;
                                    } else {
                                        v390 = v388;
                                    }
                                    v382 = v390;
                                    v381 += 1l ;
                                }
                                array<long,2l> v391;
                                long v392;
                                v392 = 0l;
                                while (while_method_0(v392)){
                                    bool v394;
                                    v394 = 0l <= v392;
                                    bool v396;
                                    if (v394){
                                        bool v395;
                                        v395 = v392 < 2l;
                                        v396 = v395;
                                    } else {
                                        v396 = false;
                                    }
                                    bool v397;
                                    v397 = v396 == false;
                                    if (v397){
                                        assert("The read index needs to be in range." && v396);
                                    } else {
                                    }
                                    v391.v[v392] = v382;
                                    v392 += 1l ;
                                }
                                array<long,2l> v398;
                                long v399;
                                v399 = 0l;
                                while (while_method_0(v399)){
                                    bool v401;
                                    v401 = 0l <= v399;
                                    bool v403;
                                    if (v401){
                                        bool v402;
                                        v402 = v399 < 2l;
                                        v403 = v402;
                                    } else {
                                        v403 = false;
                                    }
                                    bool v404;
                                    v404 = v403 == false;
                                    if (v404){
                                        assert("The read index needs to be in range." && v403);
                                    } else {
                                    }
                                    long v405;
                                    v405 = v391.v[v399];
                                    bool v406;
                                    v406 = v399 == v291;
                                    long v408;
                                    if (v406){
                                        long v407;
                                        v407 = v405 + 2l;
                                        v408 = v407;
                                    } else {
                                        v408 = v405;
                                    }
                                    bool v410;
                                    if (v401){
                                        bool v409;
                                        v409 = v399 < 2l;
                                        v410 = v409;
                                    } else {
                                        v410 = false;
                                    }
                                    bool v411;
                                    v411 = v410 == false;
                                    if (v411){
                                        assert("The read index needs to be in range." && v410);
                                    } else {
                                    }
                                    v398.v[v399] = v408;
                                    v399 += 1l ;
                                }
                                v419 = US6_2(v288, false, v290, v379, v398, v380);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                    break;
                }
                default: { // Some
                    US5 v306 = v288.v.case1.v0;
                    switch (v294.tag) {
                        case 0: { // Call
                            if (v289){
                                bool v308;
                                v308 = v291 == 0l;
                                long v309;
                                if (v308){
                                    v309 = 1l;
                                } else {
                                    v309 = 0l;
                                }
                                v419 = US6_2(v288, false, v290, v309, v292, v293);
                            } else {
                                long v311; long v312;
                                Tuple1 tmp5 = Tuple1(0l, 0l);
                                v311 = tmp5.v0; v312 = tmp5.v1;
                                while (while_method_0(v311)){
                                    bool v314;
                                    v314 = 0l <= v311;
                                    bool v316;
                                    if (v314){
                                        bool v315;
                                        v315 = v311 < 2l;
                                        v316 = v315;
                                    } else {
                                        v316 = false;
                                    }
                                    bool v317;
                                    v317 = v316 == false;
                                    if (v317){
                                        assert("The read index needs to be in range." && v316);
                                    } else {
                                    }
                                    long v318;
                                    v318 = v292.v[v311];
                                    bool v319;
                                    v319 = v312 >= v318;
                                    long v320;
                                    if (v319){
                                        v320 = v312;
                                    } else {
                                        v320 = v318;
                                    }
                                    v312 = v320;
                                    v311 += 1l ;
                                }
                                array<long,2l> v321;
                                long v322;
                                v322 = 0l;
                                while (while_method_0(v322)){
                                    bool v324;
                                    v324 = 0l <= v322;
                                    bool v326;
                                    if (v324){
                                        bool v325;
                                        v325 = v322 < 2l;
                                        v326 = v325;
                                    } else {
                                        v326 = false;
                                    }
                                    bool v327;
                                    v327 = v326 == false;
                                    if (v327){
                                        assert("The read index needs to be in range." && v326);
                                    } else {
                                    }
                                    v321.v[v322] = v312;
                                    v322 += 1l ;
                                }
                                v419 = US6_4(v288, v289, v290, v291, v321, v293);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v419 = US6_5(v288, v289, v290, v291, v292, v293);
                            break;
                        }
                        default: { // Raise
                            bool v330;
                            v330 = v293 > 0l;
                            if (v330){
                                bool v331;
                                v331 = v291 == 0l;
                                long v332;
                                if (v331){
                                    v332 = 1l;
                                } else {
                                    v332 = 0l;
                                }
                                long v333;
                                v333 = -1l + v293;
                                long v334; long v335;
                                Tuple1 tmp6 = Tuple1(0l, 0l);
                                v334 = tmp6.v0; v335 = tmp6.v1;
                                while (while_method_0(v334)){
                                    bool v337;
                                    v337 = 0l <= v334;
                                    bool v339;
                                    if (v337){
                                        bool v338;
                                        v338 = v334 < 2l;
                                        v339 = v338;
                                    } else {
                                        v339 = false;
                                    }
                                    bool v340;
                                    v340 = v339 == false;
                                    if (v340){
                                        assert("The read index needs to be in range." && v339);
                                    } else {
                                    }
                                    long v341;
                                    v341 = v292.v[v334];
                                    bool v342;
                                    v342 = v335 >= v341;
                                    long v343;
                                    if (v342){
                                        v343 = v335;
                                    } else {
                                        v343 = v341;
                                    }
                                    v335 = v343;
                                    v334 += 1l ;
                                }
                                array<long,2l> v344;
                                long v345;
                                v345 = 0l;
                                while (while_method_0(v345)){
                                    bool v347;
                                    v347 = 0l <= v345;
                                    bool v349;
                                    if (v347){
                                        bool v348;
                                        v348 = v345 < 2l;
                                        v349 = v348;
                                    } else {
                                        v349 = false;
                                    }
                                    bool v350;
                                    v350 = v349 == false;
                                    if (v350){
                                        assert("The read index needs to be in range." && v349);
                                    } else {
                                    }
                                    v344.v[v345] = v335;
                                    v345 += 1l ;
                                }
                                array<long,2l> v351;
                                long v352;
                                v352 = 0l;
                                while (while_method_0(v352)){
                                    bool v354;
                                    v354 = 0l <= v352;
                                    bool v356;
                                    if (v354){
                                        bool v355;
                                        v355 = v352 < 2l;
                                        v356 = v355;
                                    } else {
                                        v356 = false;
                                    }
                                    bool v357;
                                    v357 = v356 == false;
                                    if (v357){
                                        assert("The read index needs to be in range." && v356);
                                    } else {
                                    }
                                    long v358;
                                    v358 = v344.v[v352];
                                    bool v359;
                                    v359 = v352 == v291;
                                    long v361;
                                    if (v359){
                                        long v360;
                                        v360 = v358 + 4l;
                                        v361 = v360;
                                    } else {
                                        v361 = v358;
                                    }
                                    bool v363;
                                    if (v354){
                                        bool v362;
                                        v362 = v352 < 2l;
                                        v363 = v362;
                                    } else {
                                        v363 = false;
                                    }
                                    bool v364;
                                    v364 = v363 == false;
                                    if (v364){
                                        assert("The read index needs to be in range." && v363);
                                    } else {
                                    }
                                    v351.v[v352] = v361;
                                    v352 += 1l ;
                                }
                                v419 = US6_2(v288, false, v290, v332, v351, v333);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                }
            }
            return play_loop_inner_1(v0, v1, v2, v3, v4, v419);
            break;
        }
        case 4: { // TerminalCall
            US4 v30 = v5.v.case4.v0; bool v31 = v5.v.case4.v1; array<US5,2l> & v32 = v5.v.case4.v2; long v33 = v5.v.case4.v3; array<long,2l> & v34 = v5.v.case4.v4; long v35 = v5.v.case4.v5;
            bool v36;
            v36 = 0l <= v33;
            bool v38;
            if (v36){
                bool v37;
                v37 = v33 < 2l;
                v38 = v37;
            } else {
                v38 = false;
            }
            bool v39;
            v39 = v38 == false;
            if (v39){
                assert("The read index needs to be in range." && v38);
            } else {
            }
            long v40;
            v40 = v34.v[v33];
            US10 v41;
            v41 = compare_hands_3(v30, v31, v32, v33, v34, v35);
            long v46; long v47;
            switch (v41.tag) {
                case 0: { // Eq
                    v46 = 0l; v47 = -1l;
                    break;
                }
                case 1: { // Gt
                    v46 = v40; v47 = 0l;
                    break;
                }
                default: { // Lt
                    v46 = v40; v47 = 1l;
                }
            }
            long & v48 = v3;
            long v49;
            v49 = 1l + v48;
            v3 = v49;
            bool v50;
            v50 = 0l <= v48;
            bool v53;
            if (v50){
                long & v51 = v3;
                bool v52;
                v52 = v48 < v51;
                v53 = v52;
            } else {
                v53 = false;
            }
            bool v54;
            v54 = v53 == false;
            if (v54){
                assert("The set index needs to be in range." && v53);
            } else {
            }
            bool v56;
            if (v50){
                bool v55;
                v55 = v48 < 32l;
                v56 = v55;
            } else {
                v56 = false;
            }
            bool v57;
            v57 = v56 == false;
            if (v57){
                assert("The read index needs to be in range." && v56);
            } else {
            }
            US8 v58;
            v58 = US8_3(v32, v46, v47);
            v2.v[v48] = v58;
            return v5;
            break;
        }
        default: { // TerminalFold
            US4 v6 = v5.v.case5.v0; bool v7 = v5.v.case5.v1; array<US5,2l> & v8 = v5.v.case5.v2; long v9 = v5.v.case5.v3; array<long,2l> & v10 = v5.v.case5.v4; long v11 = v5.v.case5.v5;
            bool v12;
            v12 = 0l <= v9;
            bool v14;
            if (v12){
                bool v13;
                v13 = v9 < 2l;
                v14 = v13;
            } else {
                v14 = false;
            }
            bool v15;
            v15 = v14 == false;
            if (v15){
                assert("The read index needs to be in range." && v14);
            } else {
            }
            long v16;
            v16 = v10.v[v9];
            bool v17;
            v17 = v9 == 0l;
            long v18;
            if (v17){
                v18 = 1l;
            } else {
                v18 = 0l;
            }
            long & v19 = v3;
            long v20;
            v20 = 1l + v19;
            v3 = v20;
            bool v21;
            v21 = 0l <= v19;
            bool v24;
            if (v21){
                long & v22 = v3;
                bool v23;
                v23 = v19 < v22;
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
            bool v27;
            if (v21){
                bool v26;
                v26 = v19 < 32l;
                v27 = v26;
            } else {
                v27 = false;
            }
            bool v28;
            v28 = v27 == false;
            if (v28){
                assert("The read index needs to be in range." && v27);
            } else {
            }
            US8 v29;
            v29 = US8_3(v8, v16, v18);
            v2.v[v19] = v29;
            return v5;
        }
    }
}
__device__ Tuple0 play_loop_0(US3 v0, array<US7,32l> & v1, array<US2,2l> & v2, US9 v3, array<US5,6l> & v4, long & v5, US6 v6){
    array<US8,32l> v7;
    long v8 = 0l;
    long v9;
    v9 = 0l;
    while (while_method_2(v9)){
        bool v11;
        v11 = 0l <= v9;
        bool v13;
        if (v11){
            bool v12;
            v12 = v9 < 32l;
            v13 = v12;
        } else {
            v13 = false;
        }
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The read index needs to be in range." && v13);
        } else {
        }
        US7 v15;
        v15 = v1.v[v9];
        switch (v15.tag) {
            case 0: { // None
                break;
            }
            default: { // Some
                US8 v16 = v15.v.case1.v0;
                long & v17 = v8;
                long v18;
                v18 = 1l + v17;
                v8 = v18;
                bool v19;
                v19 = 0l <= v17;
                bool v22;
                if (v19){
                    long & v20 = v8;
                    bool v21;
                    v21 = v17 < v20;
                    v22 = v21;
                } else {
                    v22 = false;
                }
                bool v23;
                v23 = v22 == false;
                if (v23){
                    assert("The set index needs to be in range." && v22);
                } else {
                }
                bool v25;
                if (v19){
                    bool v24;
                    v24 = v17 < 32l;
                    v25 = v24;
                } else {
                    v25 = false;
                }
                bool v26;
                v26 = v25 == false;
                if (v26){
                    assert("The read index needs to be in range." && v25);
                } else {
                }
                v7.v[v17] = v16;
            }
        }
        v9 += 1l ;
    }
    US6 v27;
    v27 = play_loop_inner_1(v4, v5, v7, v8, v2, v6);
    switch (v27.tag) {
        case 2: { // Round
            US4 v28 = v27.v.case2.v0; bool v29 = v27.v.case2.v1; array<US5,2l> & v30 = v27.v.case2.v2; long v31 = v27.v.case2.v3; array<long,2l> & v32 = v27.v.case2.v4; long v33 = v27.v.case2.v5;
            array<US4,6l> v34;
            long v35;
            v35 = 0l;
            while (while_method_1(v35)){
                long & v37 = v5;
                bool v38;
                v38 = v35 < v37;
                US4 v50;
                if (v38){
                    bool v39;
                    v39 = 0l <= v35;
                    bool v42;
                    if (v39){
                        long & v40 = v5;
                        bool v41;
                        v41 = v35 < v40;
                        v42 = v41;
                    } else {
                        v42 = false;
                    }
                    bool v43;
                    v43 = v42 == false;
                    if (v43){
                        assert("The read index needs to be in range." && v42);
                    } else {
                    }
                    bool v45;
                    if (v39){
                        bool v44;
                        v44 = v35 < 6l;
                        v45 = v44;
                    } else {
                        v45 = false;
                    }
                    bool v46;
                    v46 = v45 == false;
                    if (v46){
                        assert("The read index needs to be in range." && v45);
                    } else {
                    }
                    US5 v47;
                    v47 = v4.v[v35];
                    v50 = US4_1(v47);
                } else {
                    v50 = US4_0();
                }
                bool v51;
                v51 = 0l <= v35;
                bool v53;
                if (v51){
                    bool v52;
                    v52 = v35 < 6l;
                    v53 = v52;
                } else {
                    v53 = false;
                }
                bool v54;
                v54 = v53 == false;
                if (v54){
                    assert("The read index needs to be in range." && v53);
                } else {
                }
                v34.v[v35] = v50;
                v35 += 1l ;
            }
            US3 v55;
            v55 = US3_1(v34, v27);
            US9 v56;
            v56 = US9_2(v28, v29, v30, v31, v32, v33);
            return Tuple0(v55, v1, v2, v56);
            break;
        }
        case 4: { // TerminalCall
            US4 v57 = v27.v.case4.v0; bool v58 = v27.v.case4.v1; array<US5,2l> & v59 = v27.v.case4.v2; long v60 = v27.v.case4.v3; array<long,2l> & v61 = v27.v.case4.v4; long v62 = v27.v.case4.v5;
            US3 v63;
            v63 = US3_0();
            US9 v64;
            v64 = US9_1(v57, v58, v59, v60, v61, v62);
            return Tuple0(v63, v1, v2, v64);
            break;
        }
        case 5: { // TerminalFold
            US4 v65 = v27.v.case5.v0; bool v66 = v27.v.case5.v1; array<US5,2l> & v67 = v27.v.case5.v2; long v68 = v27.v.case5.v3; array<long,2l> & v69 = v27.v.case5.v4; long v70 = v27.v.case5.v5;
            US3 v71;
            v71 = US3_0();
            US9 v72;
            v72 = US9_1(v65, v66, v67, v68, v69, v70);
            return Tuple0(v71, v1, v2, v72);
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
                array<US2,2l> v18;
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
        US3 v334;
        switch (v39) {
            case 0: {
                v334 = US3_0();
                break;
            }
            case 1: {
                array<US4,6l> v42;
                long v43;
                v43 = 0l;
                while (while_method_1(v43)){
                    unsigned long long v45;
                    v45 = (unsigned long long)v43;
                    unsigned long long v46;
                    v46 = v45 * 8ull;
                    unsigned long long v47;
                    v47 = 8ull + v46;
                    unsigned char * v48;
                    v48 = (unsigned char *)(v0+v47);
                    long * v49;
                    v49 = (long *)(v48+0ull);
                    long v50;
                    v50 = v49[0l];
                    US4 v61;
                    switch (v50) {
                        case 0: {
                            v61 = US4_0();
                            break;
                        }
                        case 1: {
                            long * v53;
                            v53 = (long *)(v48+4ull);
                            long v54;
                            v54 = v53[0l];
                            US5 v59;
                            switch (v54) {
                                case 0: {
                                    v59 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v59 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v59 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v61 = US4_1(v59);
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v62;
                    v62 = 0l <= v43;
                    bool v64;
                    if (v62){
                        bool v63;
                        v63 = v43 < 6l;
                        v64 = v63;
                    } else {
                        v64 = false;
                    }
                    bool v65;
                    v65 = v64 == false;
                    if (v65){
                        assert("The read index needs to be in range." && v64);
                    } else {
                    }
                    v42.v[v43] = v61;
                    v43 += 1l ;
                }
                long * v66;
                v66 = (long *)(v0+56ull);
                long v67;
                v67 = v66[0l];
                US6 v332;
                switch (v67) {
                    case 0: {
                        long * v69;
                        v69 = (long *)(v0+60ull);
                        long v70;
                        v70 = v69[0l];
                        US4 v81;
                        switch (v70) {
                            case 0: {
                                v81 = US4_0();
                                break;
                            }
                            case 1: {
                                long * v73;
                                v73 = (long *)(v0+64ull);
                                long v74;
                                v74 = v73[0l];
                                US5 v79;
                                switch (v74) {
                                    case 0: {
                                        v79 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v79 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v79 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v81 = US4_1(v79);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v82;
                        v82 = (bool *)(v0+68ull);
                        bool v83;
                        v83 = v82[0l];
                        array<US5,2l> v84;
                        long v85;
                        v85 = 0l;
                        while (while_method_0(v85)){
                            unsigned long long v87;
                            v87 = (unsigned long long)v85;
                            unsigned long long v88;
                            v88 = v87 * 4ull;
                            unsigned long long v89;
                            v89 = 72ull + v88;
                            unsigned char * v90;
                            v90 = (unsigned char *)(v0+v89);
                            long * v91;
                            v91 = (long *)(v90+0ull);
                            long v92;
                            v92 = v91[0l];
                            US5 v97;
                            switch (v92) {
                                case 0: {
                                    v97 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v97 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v97 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v98;
                            v98 = 0l <= v85;
                            bool v100;
                            if (v98){
                                bool v99;
                                v99 = v85 < 2l;
                                v100 = v99;
                            } else {
                                v100 = false;
                            }
                            bool v101;
                            v101 = v100 == false;
                            if (v101){
                                assert("The read index needs to be in range." && v100);
                            } else {
                            }
                            v84.v[v85] = v97;
                            v85 += 1l ;
                        }
                        long * v102;
                        v102 = (long *)(v0+80ull);
                        long v103;
                        v103 = v102[0l];
                        array<long,2l> v104;
                        long v105;
                        v105 = 0l;
                        while (while_method_0(v105)){
                            unsigned long long v107;
                            v107 = (unsigned long long)v105;
                            unsigned long long v108;
                            v108 = v107 * 4ull;
                            unsigned long long v109;
                            v109 = 84ull + v108;
                            unsigned char * v110;
                            v110 = (unsigned char *)(v0+v109);
                            long * v111;
                            v111 = (long *)(v110+0ull);
                            long v112;
                            v112 = v111[0l];
                            bool v113;
                            v113 = 0l <= v105;
                            bool v115;
                            if (v113){
                                bool v114;
                                v114 = v105 < 2l;
                                v115 = v114;
                            } else {
                                v115 = false;
                            }
                            bool v116;
                            v116 = v115 == false;
                            if (v116){
                                assert("The read index needs to be in range." && v115);
                            } else {
                            }
                            v104.v[v105] = v112;
                            v105 += 1l ;
                        }
                        long * v117;
                        v117 = (long *)(v0+92ull);
                        long v118;
                        v118 = v117[0l];
                        v332 = US6_0(v81, v83, v84, v103, v104, v118);
                        break;
                    }
                    case 1: {
                        v332 = US6_1();
                        break;
                    }
                    case 2: {
                        long * v121;
                        v121 = (long *)(v0+60ull);
                        long v122;
                        v122 = v121[0l];
                        US4 v133;
                        switch (v122) {
                            case 0: {
                                v133 = US4_0();
                                break;
                            }
                            case 1: {
                                long * v125;
                                v125 = (long *)(v0+64ull);
                                long v126;
                                v126 = v125[0l];
                                US5 v131;
                                switch (v126) {
                                    case 0: {
                                        v131 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v131 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v131 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v133 = US4_1(v131);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v134;
                        v134 = (bool *)(v0+68ull);
                        bool v135;
                        v135 = v134[0l];
                        array<US5,2l> v136;
                        long v137;
                        v137 = 0l;
                        while (while_method_0(v137)){
                            unsigned long long v139;
                            v139 = (unsigned long long)v137;
                            unsigned long long v140;
                            v140 = v139 * 4ull;
                            unsigned long long v141;
                            v141 = 72ull + v140;
                            unsigned char * v142;
                            v142 = (unsigned char *)(v0+v141);
                            long * v143;
                            v143 = (long *)(v142+0ull);
                            long v144;
                            v144 = v143[0l];
                            US5 v149;
                            switch (v144) {
                                case 0: {
                                    v149 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v149 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v149 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v150;
                            v150 = 0l <= v137;
                            bool v152;
                            if (v150){
                                bool v151;
                                v151 = v137 < 2l;
                                v152 = v151;
                            } else {
                                v152 = false;
                            }
                            bool v153;
                            v153 = v152 == false;
                            if (v153){
                                assert("The read index needs to be in range." && v152);
                            } else {
                            }
                            v136.v[v137] = v149;
                            v137 += 1l ;
                        }
                        long * v154;
                        v154 = (long *)(v0+80ull);
                        long v155;
                        v155 = v154[0l];
                        array<long,2l> v156;
                        long v157;
                        v157 = 0l;
                        while (while_method_0(v157)){
                            unsigned long long v159;
                            v159 = (unsigned long long)v157;
                            unsigned long long v160;
                            v160 = v159 * 4ull;
                            unsigned long long v161;
                            v161 = 84ull + v160;
                            unsigned char * v162;
                            v162 = (unsigned char *)(v0+v161);
                            long * v163;
                            v163 = (long *)(v162+0ull);
                            long v164;
                            v164 = v163[0l];
                            bool v165;
                            v165 = 0l <= v157;
                            bool v167;
                            if (v165){
                                bool v166;
                                v166 = v157 < 2l;
                                v167 = v166;
                            } else {
                                v167 = false;
                            }
                            bool v168;
                            v168 = v167 == false;
                            if (v168){
                                assert("The read index needs to be in range." && v167);
                            } else {
                            }
                            v156.v[v157] = v164;
                            v157 += 1l ;
                        }
                        long * v169;
                        v169 = (long *)(v0+92ull);
                        long v170;
                        v170 = v169[0l];
                        v332 = US6_2(v133, v135, v136, v155, v156, v170);
                        break;
                    }
                    case 3: {
                        long * v172;
                        v172 = (long *)(v0+60ull);
                        long v173;
                        v173 = v172[0l];
                        US4 v184;
                        switch (v173) {
                            case 0: {
                                v184 = US4_0();
                                break;
                            }
                            case 1: {
                                long * v176;
                                v176 = (long *)(v0+64ull);
                                long v177;
                                v177 = v176[0l];
                                US5 v182;
                                switch (v177) {
                                    case 0: {
                                        v182 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v182 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v182 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v184 = US4_1(v182);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v185;
                        v185 = (bool *)(v0+68ull);
                        bool v186;
                        v186 = v185[0l];
                        array<US5,2l> v187;
                        long v188;
                        v188 = 0l;
                        while (while_method_0(v188)){
                            unsigned long long v190;
                            v190 = (unsigned long long)v188;
                            unsigned long long v191;
                            v191 = v190 * 4ull;
                            unsigned long long v192;
                            v192 = 72ull + v191;
                            unsigned char * v193;
                            v193 = (unsigned char *)(v0+v192);
                            long * v194;
                            v194 = (long *)(v193+0ull);
                            long v195;
                            v195 = v194[0l];
                            US5 v200;
                            switch (v195) {
                                case 0: {
                                    v200 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v200 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v200 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v201;
                            v201 = 0l <= v188;
                            bool v203;
                            if (v201){
                                bool v202;
                                v202 = v188 < 2l;
                                v203 = v202;
                            } else {
                                v203 = false;
                            }
                            bool v204;
                            v204 = v203 == false;
                            if (v204){
                                assert("The read index needs to be in range." && v203);
                            } else {
                            }
                            v187.v[v188] = v200;
                            v188 += 1l ;
                        }
                        long * v205;
                        v205 = (long *)(v0+80ull);
                        long v206;
                        v206 = v205[0l];
                        array<long,2l> v207;
                        long v208;
                        v208 = 0l;
                        while (while_method_0(v208)){
                            unsigned long long v210;
                            v210 = (unsigned long long)v208;
                            unsigned long long v211;
                            v211 = v210 * 4ull;
                            unsigned long long v212;
                            v212 = 84ull + v211;
                            unsigned char * v213;
                            v213 = (unsigned char *)(v0+v212);
                            long * v214;
                            v214 = (long *)(v213+0ull);
                            long v215;
                            v215 = v214[0l];
                            bool v216;
                            v216 = 0l <= v208;
                            bool v218;
                            if (v216){
                                bool v217;
                                v217 = v208 < 2l;
                                v218 = v217;
                            } else {
                                v218 = false;
                            }
                            bool v219;
                            v219 = v218 == false;
                            if (v219){
                                assert("The read index needs to be in range." && v218);
                            } else {
                            }
                            v207.v[v208] = v215;
                            v208 += 1l ;
                        }
                        long * v220;
                        v220 = (long *)(v0+92ull);
                        long v221;
                        v221 = v220[0l];
                        long * v222;
                        v222 = (long *)(v0+96ull);
                        long v223;
                        v223 = v222[0l];
                        US1 v228;
                        switch (v223) {
                            case 0: {
                                v228 = US1_0();
                                break;
                            }
                            case 1: {
                                v228 = US1_1();
                                break;
                            }
                            case 2: {
                                v228 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v332 = US6_3(v184, v186, v187, v206, v207, v221, v228);
                        break;
                    }
                    case 4: {
                        long * v230;
                        v230 = (long *)(v0+60ull);
                        long v231;
                        v231 = v230[0l];
                        US4 v242;
                        switch (v231) {
                            case 0: {
                                v242 = US4_0();
                                break;
                            }
                            case 1: {
                                long * v234;
                                v234 = (long *)(v0+64ull);
                                long v235;
                                v235 = v234[0l];
                                US5 v240;
                                switch (v235) {
                                    case 0: {
                                        v240 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v240 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v240 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v242 = US4_1(v240);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v243;
                        v243 = (bool *)(v0+68ull);
                        bool v244;
                        v244 = v243[0l];
                        array<US5,2l> v245;
                        long v246;
                        v246 = 0l;
                        while (while_method_0(v246)){
                            unsigned long long v248;
                            v248 = (unsigned long long)v246;
                            unsigned long long v249;
                            v249 = v248 * 4ull;
                            unsigned long long v250;
                            v250 = 72ull + v249;
                            unsigned char * v251;
                            v251 = (unsigned char *)(v0+v250);
                            long * v252;
                            v252 = (long *)(v251+0ull);
                            long v253;
                            v253 = v252[0l];
                            US5 v258;
                            switch (v253) {
                                case 0: {
                                    v258 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v258 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v258 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v259;
                            v259 = 0l <= v246;
                            bool v261;
                            if (v259){
                                bool v260;
                                v260 = v246 < 2l;
                                v261 = v260;
                            } else {
                                v261 = false;
                            }
                            bool v262;
                            v262 = v261 == false;
                            if (v262){
                                assert("The read index needs to be in range." && v261);
                            } else {
                            }
                            v245.v[v246] = v258;
                            v246 += 1l ;
                        }
                        long * v263;
                        v263 = (long *)(v0+80ull);
                        long v264;
                        v264 = v263[0l];
                        array<long,2l> v265;
                        long v266;
                        v266 = 0l;
                        while (while_method_0(v266)){
                            unsigned long long v268;
                            v268 = (unsigned long long)v266;
                            unsigned long long v269;
                            v269 = v268 * 4ull;
                            unsigned long long v270;
                            v270 = 84ull + v269;
                            unsigned char * v271;
                            v271 = (unsigned char *)(v0+v270);
                            long * v272;
                            v272 = (long *)(v271+0ull);
                            long v273;
                            v273 = v272[0l];
                            bool v274;
                            v274 = 0l <= v266;
                            bool v276;
                            if (v274){
                                bool v275;
                                v275 = v266 < 2l;
                                v276 = v275;
                            } else {
                                v276 = false;
                            }
                            bool v277;
                            v277 = v276 == false;
                            if (v277){
                                assert("The read index needs to be in range." && v276);
                            } else {
                            }
                            v265.v[v266] = v273;
                            v266 += 1l ;
                        }
                        long * v278;
                        v278 = (long *)(v0+92ull);
                        long v279;
                        v279 = v278[0l];
                        v332 = US6_4(v242, v244, v245, v264, v265, v279);
                        break;
                    }
                    case 5: {
                        long * v281;
                        v281 = (long *)(v0+60ull);
                        long v282;
                        v282 = v281[0l];
                        US4 v293;
                        switch (v282) {
                            case 0: {
                                v293 = US4_0();
                                break;
                            }
                            case 1: {
                                long * v285;
                                v285 = (long *)(v0+64ull);
                                long v286;
                                v286 = v285[0l];
                                US5 v291;
                                switch (v286) {
                                    case 0: {
                                        v291 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v291 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v291 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v293 = US4_1(v291);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v294;
                        v294 = (bool *)(v0+68ull);
                        bool v295;
                        v295 = v294[0l];
                        array<US5,2l> v296;
                        long v297;
                        v297 = 0l;
                        while (while_method_0(v297)){
                            unsigned long long v299;
                            v299 = (unsigned long long)v297;
                            unsigned long long v300;
                            v300 = v299 * 4ull;
                            unsigned long long v301;
                            v301 = 72ull + v300;
                            unsigned char * v302;
                            v302 = (unsigned char *)(v0+v301);
                            long * v303;
                            v303 = (long *)(v302+0ull);
                            long v304;
                            v304 = v303[0l];
                            US5 v309;
                            switch (v304) {
                                case 0: {
                                    v309 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v309 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v309 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v310;
                            v310 = 0l <= v297;
                            bool v312;
                            if (v310){
                                bool v311;
                                v311 = v297 < 2l;
                                v312 = v311;
                            } else {
                                v312 = false;
                            }
                            bool v313;
                            v313 = v312 == false;
                            if (v313){
                                assert("The read index needs to be in range." && v312);
                            } else {
                            }
                            v296.v[v297] = v309;
                            v297 += 1l ;
                        }
                        long * v314;
                        v314 = (long *)(v0+80ull);
                        long v315;
                        v315 = v314[0l];
                        array<long,2l> v316;
                        long v317;
                        v317 = 0l;
                        while (while_method_0(v317)){
                            unsigned long long v319;
                            v319 = (unsigned long long)v317;
                            unsigned long long v320;
                            v320 = v319 * 4ull;
                            unsigned long long v321;
                            v321 = 84ull + v320;
                            unsigned char * v322;
                            v322 = (unsigned char *)(v0+v321);
                            long * v323;
                            v323 = (long *)(v322+0ull);
                            long v324;
                            v324 = v323[0l];
                            bool v325;
                            v325 = 0l <= v317;
                            bool v327;
                            if (v325){
                                bool v326;
                                v326 = v317 < 2l;
                                v327 = v326;
                            } else {
                                v327 = false;
                            }
                            bool v328;
                            v328 = v327 == false;
                            if (v328){
                                assert("The read index needs to be in range." && v327);
                            } else {
                            }
                            v316.v[v317] = v324;
                            v317 += 1l ;
                        }
                        long * v329;
                        v329 = (long *)(v0+92ull);
                        long v330;
                        v330 = v329[0l];
                        v332 = US6_5(v293, v295, v296, v315, v316, v330);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v334 = US3_1(v42, v332);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        array<US7,32l> v335;
        long v336;
        v336 = 0l;
        while (while_method_2(v336)){
            unsigned long long v338;
            v338 = (unsigned long long)v336;
            unsigned long long v339;
            v339 = v338 * 32ull;
            unsigned long long v340;
            v340 = 112ull + v339;
            unsigned char * v341;
            v341 = (unsigned char *)(v0+v340);
            long * v342;
            v342 = (long *)(v341+0ull);
            long v343;
            v343 = v342[0l];
            US7 v402;
            switch (v343) {
                case 0: {
                    v402 = US7_0();
                    break;
                }
                case 1: {
                    long * v346;
                    v346 = (long *)(v341+4ull);
                    long v347;
                    v347 = v346[0l];
                    US8 v400;
                    switch (v347) {
                        case 0: {
                            long * v349;
                            v349 = (long *)(v341+8ull);
                            long v350;
                            v350 = v349[0l];
                            US5 v355;
                            switch (v350) {
                                case 0: {
                                    v355 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v355 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v355 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v400 = US8_0(v355);
                            break;
                        }
                        case 1: {
                            long * v357;
                            v357 = (long *)(v341+8ull);
                            long v358;
                            v358 = v357[0l];
                            long * v359;
                            v359 = (long *)(v341+12ull);
                            long v360;
                            v360 = v359[0l];
                            US1 v365;
                            switch (v360) {
                                case 0: {
                                    v365 = US1_0();
                                    break;
                                }
                                case 1: {
                                    v365 = US1_1();
                                    break;
                                }
                                case 2: {
                                    v365 = US1_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v400 = US8_1(v358, v365);
                            break;
                        }
                        case 2: {
                            long * v367;
                            v367 = (long *)(v341+8ull);
                            long v368;
                            v368 = v367[0l];
                            long * v369;
                            v369 = (long *)(v341+12ull);
                            long v370;
                            v370 = v369[0l];
                            US5 v375;
                            switch (v370) {
                                case 0: {
                                    v375 = US5_0();
                                    break;
                                }
                                case 1: {
                                    v375 = US5_1();
                                    break;
                                }
                                case 2: {
                                    v375 = US5_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            v400 = US8_2(v368, v375);
                            break;
                        }
                        case 3: {
                            array<US5,2l> v377;
                            long v378;
                            v378 = 0l;
                            while (while_method_0(v378)){
                                unsigned long long v380;
                                v380 = (unsigned long long)v378;
                                unsigned long long v381;
                                v381 = v380 * 4ull;
                                unsigned long long v382;
                                v382 = 8ull + v381;
                                unsigned char * v383;
                                v383 = (unsigned char *)(v341+v382);
                                long * v384;
                                v384 = (long *)(v383+0ull);
                                long v385;
                                v385 = v384[0l];
                                US5 v390;
                                switch (v385) {
                                    case 0: {
                                        v390 = US5_0();
                                        break;
                                    }
                                    case 1: {
                                        v390 = US5_1();
                                        break;
                                    }
                                    case 2: {
                                        v390 = US5_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                bool v391;
                                v391 = 0l <= v378;
                                bool v393;
                                if (v391){
                                    bool v392;
                                    v392 = v378 < 2l;
                                    v393 = v392;
                                } else {
                                    v393 = false;
                                }
                                bool v394;
                                v394 = v393 == false;
                                if (v394){
                                    assert("The read index needs to be in range." && v393);
                                } else {
                                }
                                v377.v[v378] = v390;
                                v378 += 1l ;
                            }
                            long * v395;
                            v395 = (long *)(v341+16ull);
                            long v396;
                            v396 = v395[0l];
                            long * v397;
                            v397 = (long *)(v341+20ull);
                            long v398;
                            v398 = v397[0l];
                            v400 = US8_3(v377, v396, v398);
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v402 = US7_1(v400);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v403;
            v403 = 0l <= v336;
            bool v405;
            if (v403){
                bool v404;
                v404 = v336 < 32l;
                v405 = v404;
            } else {
                v405 = false;
            }
            bool v406;
            v406 = v405 == false;
            if (v406){
                assert("The read index needs to be in range." && v405);
            } else {
            }
            v335.v[v336] = v402;
            v336 += 1l ;
        }
        array<US2,2l> v407;
        long v408;
        v408 = 0l;
        while (while_method_0(v408)){
            unsigned long long v410;
            v410 = (unsigned long long)v408;
            unsigned long long v411;
            v411 = v410 * 4ull;
            unsigned long long v412;
            v412 = 1136ull + v411;
            unsigned char * v413;
            v413 = (unsigned char *)(v0+v412);
            long * v414;
            v414 = (long *)(v413+0ull);
            long v415;
            v415 = v414[0l];
            US2 v419;
            switch (v415) {
                case 0: {
                    v419 = US2_0();
                    break;
                }
                case 1: {
                    v419 = US2_1();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v420;
            v420 = 0l <= v408;
            bool v422;
            if (v420){
                bool v421;
                v421 = v408 < 2l;
                v422 = v421;
            } else {
                v422 = false;
            }
            bool v423;
            v423 = v422 == false;
            if (v423){
                assert("The read index needs to be in range." && v422);
            } else {
            }
            v407.v[v408] = v419;
            v408 += 1l ;
        }
        long * v424;
        v424 = (long *)(v0+1144ull);
        long v425;
        v425 = v424[0l];
        US9 v530;
        switch (v425) {
            case 0: {
                v530 = US9_0();
                break;
            }
            case 1: {
                long * v428;
                v428 = (long *)(v0+1148ull);
                long v429;
                v429 = v428[0l];
                US4 v440;
                switch (v429) {
                    case 0: {
                        v440 = US4_0();
                        break;
                    }
                    case 1: {
                        long * v432;
                        v432 = (long *)(v0+1152ull);
                        long v433;
                        v433 = v432[0l];
                        US5 v438;
                        switch (v433) {
                            case 0: {
                                v438 = US5_0();
                                break;
                            }
                            case 1: {
                                v438 = US5_1();
                                break;
                            }
                            case 2: {
                                v438 = US5_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v440 = US4_1(v438);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v441;
                v441 = (bool *)(v0+1156ull);
                bool v442;
                v442 = v441[0l];
                array<US5,2l> v443;
                long v444;
                v444 = 0l;
                while (while_method_0(v444)){
                    unsigned long long v446;
                    v446 = (unsigned long long)v444;
                    unsigned long long v447;
                    v447 = v446 * 4ull;
                    unsigned long long v448;
                    v448 = 1160ull + v447;
                    unsigned char * v449;
                    v449 = (unsigned char *)(v0+v448);
                    long * v450;
                    v450 = (long *)(v449+0ull);
                    long v451;
                    v451 = v450[0l];
                    US5 v456;
                    switch (v451) {
                        case 0: {
                            v456 = US5_0();
                            break;
                        }
                        case 1: {
                            v456 = US5_1();
                            break;
                        }
                        case 2: {
                            v456 = US5_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v457;
                    v457 = 0l <= v444;
                    bool v459;
                    if (v457){
                        bool v458;
                        v458 = v444 < 2l;
                        v459 = v458;
                    } else {
                        v459 = false;
                    }
                    bool v460;
                    v460 = v459 == false;
                    if (v460){
                        assert("The read index needs to be in range." && v459);
                    } else {
                    }
                    v443.v[v444] = v456;
                    v444 += 1l ;
                }
                long * v461;
                v461 = (long *)(v0+1168ull);
                long v462;
                v462 = v461[0l];
                array<long,2l> v463;
                long v464;
                v464 = 0l;
                while (while_method_0(v464)){
                    unsigned long long v466;
                    v466 = (unsigned long long)v464;
                    unsigned long long v467;
                    v467 = v466 * 4ull;
                    unsigned long long v468;
                    v468 = 1172ull + v467;
                    unsigned char * v469;
                    v469 = (unsigned char *)(v0+v468);
                    long * v470;
                    v470 = (long *)(v469+0ull);
                    long v471;
                    v471 = v470[0l];
                    bool v472;
                    v472 = 0l <= v464;
                    bool v474;
                    if (v472){
                        bool v473;
                        v473 = v464 < 2l;
                        v474 = v473;
                    } else {
                        v474 = false;
                    }
                    bool v475;
                    v475 = v474 == false;
                    if (v475){
                        assert("The read index needs to be in range." && v474);
                    } else {
                    }
                    v463.v[v464] = v471;
                    v464 += 1l ;
                }
                long * v476;
                v476 = (long *)(v0+1180ull);
                long v477;
                v477 = v476[0l];
                v530 = US9_1(v440, v442, v443, v462, v463, v477);
                break;
            }
            case 2: {
                long * v479;
                v479 = (long *)(v0+1148ull);
                long v480;
                v480 = v479[0l];
                US4 v491;
                switch (v480) {
                    case 0: {
                        v491 = US4_0();
                        break;
                    }
                    case 1: {
                        long * v483;
                        v483 = (long *)(v0+1152ull);
                        long v484;
                        v484 = v483[0l];
                        US5 v489;
                        switch (v484) {
                            case 0: {
                                v489 = US5_0();
                                break;
                            }
                            case 1: {
                                v489 = US5_1();
                                break;
                            }
                            case 2: {
                                v489 = US5_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v491 = US4_1(v489);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v492;
                v492 = (bool *)(v0+1156ull);
                bool v493;
                v493 = v492[0l];
                array<US5,2l> v494;
                long v495;
                v495 = 0l;
                while (while_method_0(v495)){
                    unsigned long long v497;
                    v497 = (unsigned long long)v495;
                    unsigned long long v498;
                    v498 = v497 * 4ull;
                    unsigned long long v499;
                    v499 = 1160ull + v498;
                    unsigned char * v500;
                    v500 = (unsigned char *)(v0+v499);
                    long * v501;
                    v501 = (long *)(v500+0ull);
                    long v502;
                    v502 = v501[0l];
                    US5 v507;
                    switch (v502) {
                        case 0: {
                            v507 = US5_0();
                            break;
                        }
                        case 1: {
                            v507 = US5_1();
                            break;
                        }
                        case 2: {
                            v507 = US5_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v508;
                    v508 = 0l <= v495;
                    bool v510;
                    if (v508){
                        bool v509;
                        v509 = v495 < 2l;
                        v510 = v509;
                    } else {
                        v510 = false;
                    }
                    bool v511;
                    v511 = v510 == false;
                    if (v511){
                        assert("The read index needs to be in range." && v510);
                    } else {
                    }
                    v494.v[v495] = v507;
                    v495 += 1l ;
                }
                long * v512;
                v512 = (long *)(v0+1168ull);
                long v513;
                v513 = v512[0l];
                array<long,2l> v514;
                long v515;
                v515 = 0l;
                while (while_method_0(v515)){
                    unsigned long long v517;
                    v517 = (unsigned long long)v515;
                    unsigned long long v518;
                    v518 = v517 * 4ull;
                    unsigned long long v519;
                    v519 = 1172ull + v518;
                    unsigned char * v520;
                    v520 = (unsigned char *)(v0+v519);
                    long * v521;
                    v521 = (long *)(v520+0ull);
                    long v522;
                    v522 = v521[0l];
                    bool v523;
                    v523 = 0l <= v515;
                    bool v525;
                    if (v523){
                        bool v524;
                        v524 = v515 < 2l;
                        v525 = v524;
                    } else {
                        v525 = false;
                    }
                    bool v526;
                    v526 = v525 == false;
                    if (v526){
                        assert("The read index needs to be in range." && v525);
                    } else {
                    }
                    v514.v[v515] = v522;
                    v515 += 1l ;
                }
                long * v527;
                v527 = (long *)(v0+1180ull);
                long v528;
                v528 = v527[0l];
                v530 = US9_2(v491, v493, v494, v513, v514, v528);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        US3 v681; array<US7,32l> & v682; array<US2,2l> & v683; US9 v684;
        switch (v37.tag) {
            case 0: { // ActionSelected
                US1 v623 = v37.v.case0.v0;
                switch (v334.tag) {
                    case 0: { // None
                        v681 = v334; v682 = v335; v683 = v407; v684 = v530;
                        break;
                    }
                    default: { // Some
                        array<US4,6l> & v624 = v334.v.case1.v0; US6 v625 = v334.v.case1.v1;
                        switch (v625.tag) {
                            case 2: { // Round
                                US4 v626 = v625.v.case2.v0; bool v627 = v625.v.case2.v1; array<US5,2l> & v628 = v625.v.case2.v2; long v629 = v625.v.case2.v3; array<long,2l> & v630 = v625.v.case2.v4; long v631 = v625.v.case2.v5;
                                array<US5,6l> v632;
                                long v633 = 0l;
                                long v634;
                                v634 = 0l;
                                while (while_method_1(v634)){
                                    bool v636;
                                    v636 = 0l <= v634;
                                    bool v638;
                                    if (v636){
                                        bool v637;
                                        v637 = v634 < 6l;
                                        v638 = v637;
                                    } else {
                                        v638 = false;
                                    }
                                    bool v639;
                                    v639 = v638 == false;
                                    if (v639){
                                        assert("The read index needs to be in range." && v638);
                                    } else {
                                    }
                                    US4 v640;
                                    v640 = v624.v[v634];
                                    switch (v640.tag) {
                                        case 0: { // None
                                            break;
                                        }
                                        default: { // Some
                                            US5 v641 = v640.v.case1.v0;
                                            long & v642 = v633;
                                            long v643;
                                            v643 = 1l + v642;
                                            v633 = v643;
                                            bool v644;
                                            v644 = 0l <= v642;
                                            bool v647;
                                            if (v644){
                                                long & v645 = v633;
                                                bool v646;
                                                v646 = v642 < v645;
                                                v647 = v646;
                                            } else {
                                                v647 = false;
                                            }
                                            bool v648;
                                            v648 = v647 == false;
                                            if (v648){
                                                assert("The set index needs to be in range." && v647);
                                            } else {
                                            }
                                            bool v650;
                                            if (v644){
                                                bool v649;
                                                v649 = v642 < 6l;
                                                v650 = v649;
                                            } else {
                                                v650 = false;
                                            }
                                            bool v651;
                                            v651 = v650 == false;
                                            if (v651){
                                                assert("The read index needs to be in range." && v650);
                                            } else {
                                            }
                                            v632.v[v642] = v641;
                                        }
                                    }
                                    v634 += 1l ;
                                }
                                US6 v652;
                                v652 = US6_3(v626, v627, v628, v629, v630, v631, v623);
                                Tuple0 tmp9 = play_loop_0(v334, v335, v407, v530, v632, v633, v652);
                                v681 = tmp9.v0; v682 = tmp9.v1; v683 = tmp9.v2; v684 = tmp9.v3;
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
                array<US2,2l> & v622 = v37.v.case1.v0;
                v681 = v334; v682 = v335; v683 = v622; v684 = v530;
                break;
            }
            default: { // StartGame
                array<US2,2l> v531;
                US2 v532;
                v532 = US2_0();
                v531.v[0l] = v532;
                US2 v533;
                v533 = US2_1();
                v531.v[1l] = v533;
                array<US7,32l> v534;
                long v535;
                v535 = 0l;
                while (while_method_2(v535)){
                    bool v537;
                    v537 = 0l <= v535;
                    bool v539;
                    if (v537){
                        bool v538;
                        v538 = v535 < 32l;
                        v539 = v538;
                    } else {
                        v539 = false;
                    }
                    bool v540;
                    v540 = v539 == false;
                    if (v540){
                        assert("The read index needs to be in range." && v539);
                    } else {
                    }
                    US7 v541;
                    v541 = US7_0();
                    v534.v[v535] = v541;
                    v535 += 1l ;
                }
                US3 v542;
                v542 = US3_0();
                US9 v543;
                v543 = US9_0();
                array<US5,6l> v544;
                long v545 = 0l;
                long & v546 = v545;
                v545 = 6l;
                long & v547 = v545;
                bool v548;
                v548 = 0l < v547;
                bool v549;
                v549 = v548 == false;
                if (v549){
                    assert("The set index needs to be in range." && v548);
                } else {
                }
                US5 v550;
                v550 = US5_1();
                v544.v[0l] = v550;
                long & v551 = v545;
                bool v552;
                v552 = 1l < v551;
                bool v553;
                v553 = v552 == false;
                if (v553){
                    assert("The set index needs to be in range." && v552);
                } else {
                }
                US5 v554;
                v554 = US5_1();
                v544.v[1l] = v554;
                long & v555 = v545;
                bool v556;
                v556 = 2l < v555;
                bool v557;
                v557 = v556 == false;
                if (v557){
                    assert("The set index needs to be in range." && v556);
                } else {
                }
                US5 v558;
                v558 = US5_2();
                v544.v[2l] = v558;
                long & v559 = v545;
                bool v560;
                v560 = 3l < v559;
                bool v561;
                v561 = v560 == false;
                if (v561){
                    assert("The set index needs to be in range." && v560);
                } else {
                }
                US5 v562;
                v562 = US5_2();
                v544.v[3l] = v562;
                long & v563 = v545;
                bool v564;
                v564 = 4l < v563;
                bool v565;
                v565 = v564 == false;
                if (v565){
                    assert("The set index needs to be in range." && v564);
                } else {
                }
                US5 v566;
                v566 = US5_0();
                v544.v[4l] = v566;
                long & v567 = v545;
                bool v568;
                v568 = 5l < v567;
                bool v569;
                v569 = v568 == false;
                if (v569){
                    assert("The set index needs to be in range." && v568);
                } else {
                }
                US5 v570;
                v570 = US5_0();
                v544.v[5l] = v570;
                unsigned long long v571;
                v571 = clock64();
                curandStatePhilox4_32_10_t v572;
                curandStatePhilox4_32_10_t * v573 = &v572;
                curand_init(v571,0ull,0ull,v573);
                long & v574 = v545;
                long v575;
                v575 = v574 - 1l;
                long v576;
                v576 = 0l;
                while (while_method_3(v575, v576)){
                    long & v578 = v545;
                    long v579;
                    v579 = v578 - v576;
                    unsigned long v580;
                    v580 = (unsigned long)v579;
                    unsigned long v581;
                    v581 = loop_2(v580, v573);
                    unsigned long v582;
                    v582 = (unsigned long)v576;
                    unsigned long v583;
                    v583 = v581 - v582;
                    long v584;
                    v584 = (long)v583;
                    bool v585;
                    v585 = 0l <= v576;
                    bool v588;
                    if (v585){
                        long & v586 = v545;
                        bool v587;
                        v587 = v576 < v586;
                        v588 = v587;
                    } else {
                        v588 = false;
                    }
                    bool v589;
                    v589 = v588 == false;
                    if (v589){
                        assert("The read index needs to be in range." && v588);
                    } else {
                    }
                    bool v591;
                    if (v585){
                        bool v590;
                        v590 = v576 < 6l;
                        v591 = v590;
                    } else {
                        v591 = false;
                    }
                    bool v592;
                    v592 = v591 == false;
                    if (v592){
                        assert("The read index needs to be in range." && v591);
                    } else {
                    }
                    US5 v593;
                    v593 = v544.v[v576];
                    bool v594;
                    v594 = 0l <= v584;
                    bool v597;
                    if (v594){
                        long & v595 = v545;
                        bool v596;
                        v596 = v584 < v595;
                        v597 = v596;
                    } else {
                        v597 = false;
                    }
                    bool v598;
                    v598 = v597 == false;
                    if (v598){
                        assert("The read index needs to be in range." && v597);
                    } else {
                    }
                    bool v600;
                    if (v594){
                        bool v599;
                        v599 = v584 < 6l;
                        v600 = v599;
                    } else {
                        v600 = false;
                    }
                    bool v601;
                    v601 = v600 == false;
                    if (v601){
                        assert("The read index needs to be in range." && v600);
                    } else {
                    }
                    US5 v602;
                    v602 = v544.v[v584];
                    bool v605;
                    if (v585){
                        long & v603 = v545;
                        bool v604;
                        v604 = v576 < v603;
                        v605 = v604;
                    } else {
                        v605 = false;
                    }
                    bool v606;
                    v606 = v605 == false;
                    if (v606){
                        assert("The set index needs to be in range." && v605);
                    } else {
                    }
                    bool v608;
                    if (v585){
                        bool v607;
                        v607 = v576 < 6l;
                        v608 = v607;
                    } else {
                        v608 = false;
                    }
                    bool v609;
                    v609 = v608 == false;
                    if (v609){
                        assert("The read index needs to be in range." && v608);
                    } else {
                    }
                    v544.v[v576] = v602;
                    bool v612;
                    if (v594){
                        long & v610 = v545;
                        bool v611;
                        v611 = v584 < v610;
                        v612 = v611;
                    } else {
                        v612 = false;
                    }
                    bool v613;
                    v613 = v612 == false;
                    if (v613){
                        assert("The set index needs to be in range." && v612);
                    } else {
                    }
                    bool v615;
                    if (v594){
                        bool v614;
                        v614 = v584 < 6l;
                        v615 = v614;
                    } else {
                        v615 = false;
                    }
                    bool v616;
                    v616 = v615 == false;
                    if (v616){
                        assert("The read index needs to be in range." && v615);
                    } else {
                    }
                    v544.v[v584] = v593;
                    v576 += 1l ;
                }
                US6 v617;
                v617 = US6_1();
                Tuple0 tmp10 = play_loop_0(v542, v534, v531, v543, v544, v545, v617);
                v681 = tmp10.v0; v682 = tmp10.v1; v683 = tmp10.v2; v684 = tmp10.v3;
            }
        }
        long v685;
        v685 = v681.tag;
        long * v686;
        v686 = (long *)(v0+0ull);
        v686[0l] = v685;
        switch (v681.tag) {
            case 0: { // None
                break;
            }
            default: { // Some
                array<US4,6l> & v687 = v681.v.case1.v0; US6 v688 = v681.v.case1.v1;
                long v689;
                v689 = 0l;
                while (while_method_1(v689)){
                    unsigned long long v691;
                    v691 = (unsigned long long)v689;
                    unsigned long long v692;
                    v692 = v691 * 8ull;
                    unsigned long long v693;
                    v693 = 8ull + v692;
                    unsigned char * v694;
                    v694 = (unsigned char *)(v0+v693);
                    bool v695;
                    v695 = 0l <= v689;
                    bool v697;
                    if (v695){
                        bool v696;
                        v696 = v689 < 6l;
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
                    US4 v699;
                    v699 = v687.v[v689];
                    long v700;
                    v700 = v699.tag;
                    long * v701;
                    v701 = (long *)(v694+0ull);
                    v701[0l] = v700;
                    switch (v699.tag) {
                        case 0: { // None
                            break;
                        }
                        default: { // Some
                            US5 v702 = v699.v.case1.v0;
                            long v703;
                            v703 = v702.tag;
                            long * v704;
                            v704 = (long *)(v694+4ull);
                            v704[0l] = v703;
                            switch (v702.tag) {
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
                    v689 += 1l ;
                }
                long v705;
                v705 = v688.tag;
                long * v706;
                v706 = (long *)(v0+56ull);
                v706[0l] = v705;
                switch (v688.tag) {
                    case 0: { // ChanceCommunityCard
                        US4 v707 = v688.v.case0.v0; bool v708 = v688.v.case0.v1; array<US5,2l> & v709 = v688.v.case0.v2; long v710 = v688.v.case0.v3; array<long,2l> & v711 = v688.v.case0.v4; long v712 = v688.v.case0.v5;
                        long v713;
                        v713 = v707.tag;
                        long * v714;
                        v714 = (long *)(v0+60ull);
                        v714[0l] = v713;
                        switch (v707.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US5 v715 = v707.v.case1.v0;
                                long v716;
                                v716 = v715.tag;
                                long * v717;
                                v717 = (long *)(v0+64ull);
                                v717[0l] = v716;
                                switch (v715.tag) {
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
                        bool * v718;
                        v718 = (bool *)(v0+68ull);
                        v718[0l] = v708;
                        long v719;
                        v719 = 0l;
                        while (while_method_0(v719)){
                            unsigned long long v721;
                            v721 = (unsigned long long)v719;
                            unsigned long long v722;
                            v722 = v721 * 4ull;
                            unsigned long long v723;
                            v723 = 72ull + v722;
                            unsigned char * v724;
                            v724 = (unsigned char *)(v0+v723);
                            bool v725;
                            v725 = 0l <= v719;
                            bool v727;
                            if (v725){
                                bool v726;
                                v726 = v719 < 2l;
                                v727 = v726;
                            } else {
                                v727 = false;
                            }
                            bool v728;
                            v728 = v727 == false;
                            if (v728){
                                assert("The read index needs to be in range." && v727);
                            } else {
                            }
                            US5 v729;
                            v729 = v709.v[v719];
                            long v730;
                            v730 = v729.tag;
                            long * v731;
                            v731 = (long *)(v724+0ull);
                            v731[0l] = v730;
                            switch (v729.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v719 += 1l ;
                        }
                        long * v732;
                        v732 = (long *)(v0+80ull);
                        v732[0l] = v710;
                        long v733;
                        v733 = 0l;
                        while (while_method_0(v733)){
                            unsigned long long v735;
                            v735 = (unsigned long long)v733;
                            unsigned long long v736;
                            v736 = v735 * 4ull;
                            unsigned long long v737;
                            v737 = 84ull + v736;
                            unsigned char * v738;
                            v738 = (unsigned char *)(v0+v737);
                            bool v739;
                            v739 = 0l <= v733;
                            bool v741;
                            if (v739){
                                bool v740;
                                v740 = v733 < 2l;
                                v741 = v740;
                            } else {
                                v741 = false;
                            }
                            bool v742;
                            v742 = v741 == false;
                            if (v742){
                                assert("The read index needs to be in range." && v741);
                            } else {
                            }
                            long v743;
                            v743 = v711.v[v733];
                            long * v744;
                            v744 = (long *)(v738+0ull);
                            v744[0l] = v743;
                            v733 += 1l ;
                        }
                        long * v745;
                        v745 = (long *)(v0+92ull);
                        v745[0l] = v712;
                        break;
                    }
                    case 1: { // ChanceInit
                        break;
                    }
                    case 2: { // Round
                        US4 v746 = v688.v.case2.v0; bool v747 = v688.v.case2.v1; array<US5,2l> & v748 = v688.v.case2.v2; long v749 = v688.v.case2.v3; array<long,2l> & v750 = v688.v.case2.v4; long v751 = v688.v.case2.v5;
                        long v752;
                        v752 = v746.tag;
                        long * v753;
                        v753 = (long *)(v0+60ull);
                        v753[0l] = v752;
                        switch (v746.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US5 v754 = v746.v.case1.v0;
                                long v755;
                                v755 = v754.tag;
                                long * v756;
                                v756 = (long *)(v0+64ull);
                                v756[0l] = v755;
                                switch (v754.tag) {
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
                        bool * v757;
                        v757 = (bool *)(v0+68ull);
                        v757[0l] = v747;
                        long v758;
                        v758 = 0l;
                        while (while_method_0(v758)){
                            unsigned long long v760;
                            v760 = (unsigned long long)v758;
                            unsigned long long v761;
                            v761 = v760 * 4ull;
                            unsigned long long v762;
                            v762 = 72ull + v761;
                            unsigned char * v763;
                            v763 = (unsigned char *)(v0+v762);
                            bool v764;
                            v764 = 0l <= v758;
                            bool v766;
                            if (v764){
                                bool v765;
                                v765 = v758 < 2l;
                                v766 = v765;
                            } else {
                                v766 = false;
                            }
                            bool v767;
                            v767 = v766 == false;
                            if (v767){
                                assert("The read index needs to be in range." && v766);
                            } else {
                            }
                            US5 v768;
                            v768 = v748.v[v758];
                            long v769;
                            v769 = v768.tag;
                            long * v770;
                            v770 = (long *)(v763+0ull);
                            v770[0l] = v769;
                            switch (v768.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v758 += 1l ;
                        }
                        long * v771;
                        v771 = (long *)(v0+80ull);
                        v771[0l] = v749;
                        long v772;
                        v772 = 0l;
                        while (while_method_0(v772)){
                            unsigned long long v774;
                            v774 = (unsigned long long)v772;
                            unsigned long long v775;
                            v775 = v774 * 4ull;
                            unsigned long long v776;
                            v776 = 84ull + v775;
                            unsigned char * v777;
                            v777 = (unsigned char *)(v0+v776);
                            bool v778;
                            v778 = 0l <= v772;
                            bool v780;
                            if (v778){
                                bool v779;
                                v779 = v772 < 2l;
                                v780 = v779;
                            } else {
                                v780 = false;
                            }
                            bool v781;
                            v781 = v780 == false;
                            if (v781){
                                assert("The read index needs to be in range." && v780);
                            } else {
                            }
                            long v782;
                            v782 = v750.v[v772];
                            long * v783;
                            v783 = (long *)(v777+0ull);
                            v783[0l] = v782;
                            v772 += 1l ;
                        }
                        long * v784;
                        v784 = (long *)(v0+92ull);
                        v784[0l] = v751;
                        break;
                    }
                    case 3: { // RoundWithAction
                        US4 v785 = v688.v.case3.v0; bool v786 = v688.v.case3.v1; array<US5,2l> & v787 = v688.v.case3.v2; long v788 = v688.v.case3.v3; array<long,2l> & v789 = v688.v.case3.v4; long v790 = v688.v.case3.v5; US1 v791 = v688.v.case3.v6;
                        long v792;
                        v792 = v785.tag;
                        long * v793;
                        v793 = (long *)(v0+60ull);
                        v793[0l] = v792;
                        switch (v785.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US5 v794 = v785.v.case1.v0;
                                long v795;
                                v795 = v794.tag;
                                long * v796;
                                v796 = (long *)(v0+64ull);
                                v796[0l] = v795;
                                switch (v794.tag) {
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
                        bool * v797;
                        v797 = (bool *)(v0+68ull);
                        v797[0l] = v786;
                        long v798;
                        v798 = 0l;
                        while (while_method_0(v798)){
                            unsigned long long v800;
                            v800 = (unsigned long long)v798;
                            unsigned long long v801;
                            v801 = v800 * 4ull;
                            unsigned long long v802;
                            v802 = 72ull + v801;
                            unsigned char * v803;
                            v803 = (unsigned char *)(v0+v802);
                            bool v804;
                            v804 = 0l <= v798;
                            bool v806;
                            if (v804){
                                bool v805;
                                v805 = v798 < 2l;
                                v806 = v805;
                            } else {
                                v806 = false;
                            }
                            bool v807;
                            v807 = v806 == false;
                            if (v807){
                                assert("The read index needs to be in range." && v806);
                            } else {
                            }
                            US5 v808;
                            v808 = v787.v[v798];
                            long v809;
                            v809 = v808.tag;
                            long * v810;
                            v810 = (long *)(v803+0ull);
                            v810[0l] = v809;
                            switch (v808.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v798 += 1l ;
                        }
                        long * v811;
                        v811 = (long *)(v0+80ull);
                        v811[0l] = v788;
                        long v812;
                        v812 = 0l;
                        while (while_method_0(v812)){
                            unsigned long long v814;
                            v814 = (unsigned long long)v812;
                            unsigned long long v815;
                            v815 = v814 * 4ull;
                            unsigned long long v816;
                            v816 = 84ull + v815;
                            unsigned char * v817;
                            v817 = (unsigned char *)(v0+v816);
                            bool v818;
                            v818 = 0l <= v812;
                            bool v820;
                            if (v818){
                                bool v819;
                                v819 = v812 < 2l;
                                v820 = v819;
                            } else {
                                v820 = false;
                            }
                            bool v821;
                            v821 = v820 == false;
                            if (v821){
                                assert("The read index needs to be in range." && v820);
                            } else {
                            }
                            long v822;
                            v822 = v789.v[v812];
                            long * v823;
                            v823 = (long *)(v817+0ull);
                            v823[0l] = v822;
                            v812 += 1l ;
                        }
                        long * v824;
                        v824 = (long *)(v0+92ull);
                        v824[0l] = v790;
                        long v825;
                        v825 = v791.tag;
                        long * v826;
                        v826 = (long *)(v0+96ull);
                        v826[0l] = v825;
                        switch (v791.tag) {
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
                        US4 v827 = v688.v.case4.v0; bool v828 = v688.v.case4.v1; array<US5,2l> & v829 = v688.v.case4.v2; long v830 = v688.v.case4.v3; array<long,2l> & v831 = v688.v.case4.v4; long v832 = v688.v.case4.v5;
                        long v833;
                        v833 = v827.tag;
                        long * v834;
                        v834 = (long *)(v0+60ull);
                        v834[0l] = v833;
                        switch (v827.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US5 v835 = v827.v.case1.v0;
                                long v836;
                                v836 = v835.tag;
                                long * v837;
                                v837 = (long *)(v0+64ull);
                                v837[0l] = v836;
                                switch (v835.tag) {
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
                        bool * v838;
                        v838 = (bool *)(v0+68ull);
                        v838[0l] = v828;
                        long v839;
                        v839 = 0l;
                        while (while_method_0(v839)){
                            unsigned long long v841;
                            v841 = (unsigned long long)v839;
                            unsigned long long v842;
                            v842 = v841 * 4ull;
                            unsigned long long v843;
                            v843 = 72ull + v842;
                            unsigned char * v844;
                            v844 = (unsigned char *)(v0+v843);
                            bool v845;
                            v845 = 0l <= v839;
                            bool v847;
                            if (v845){
                                bool v846;
                                v846 = v839 < 2l;
                                v847 = v846;
                            } else {
                                v847 = false;
                            }
                            bool v848;
                            v848 = v847 == false;
                            if (v848){
                                assert("The read index needs to be in range." && v847);
                            } else {
                            }
                            US5 v849;
                            v849 = v829.v[v839];
                            long v850;
                            v850 = v849.tag;
                            long * v851;
                            v851 = (long *)(v844+0ull);
                            v851[0l] = v850;
                            switch (v849.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v839 += 1l ;
                        }
                        long * v852;
                        v852 = (long *)(v0+80ull);
                        v852[0l] = v830;
                        long v853;
                        v853 = 0l;
                        while (while_method_0(v853)){
                            unsigned long long v855;
                            v855 = (unsigned long long)v853;
                            unsigned long long v856;
                            v856 = v855 * 4ull;
                            unsigned long long v857;
                            v857 = 84ull + v856;
                            unsigned char * v858;
                            v858 = (unsigned char *)(v0+v857);
                            bool v859;
                            v859 = 0l <= v853;
                            bool v861;
                            if (v859){
                                bool v860;
                                v860 = v853 < 2l;
                                v861 = v860;
                            } else {
                                v861 = false;
                            }
                            bool v862;
                            v862 = v861 == false;
                            if (v862){
                                assert("The read index needs to be in range." && v861);
                            } else {
                            }
                            long v863;
                            v863 = v831.v[v853];
                            long * v864;
                            v864 = (long *)(v858+0ull);
                            v864[0l] = v863;
                            v853 += 1l ;
                        }
                        long * v865;
                        v865 = (long *)(v0+92ull);
                        v865[0l] = v832;
                        break;
                    }
                    default: { // TerminalFold
                        US4 v866 = v688.v.case5.v0; bool v867 = v688.v.case5.v1; array<US5,2l> & v868 = v688.v.case5.v2; long v869 = v688.v.case5.v3; array<long,2l> & v870 = v688.v.case5.v4; long v871 = v688.v.case5.v5;
                        long v872;
                        v872 = v866.tag;
                        long * v873;
                        v873 = (long *)(v0+60ull);
                        v873[0l] = v872;
                        switch (v866.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US5 v874 = v866.v.case1.v0;
                                long v875;
                                v875 = v874.tag;
                                long * v876;
                                v876 = (long *)(v0+64ull);
                                v876[0l] = v875;
                                switch (v874.tag) {
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
                        bool * v877;
                        v877 = (bool *)(v0+68ull);
                        v877[0l] = v867;
                        long v878;
                        v878 = 0l;
                        while (while_method_0(v878)){
                            unsigned long long v880;
                            v880 = (unsigned long long)v878;
                            unsigned long long v881;
                            v881 = v880 * 4ull;
                            unsigned long long v882;
                            v882 = 72ull + v881;
                            unsigned char * v883;
                            v883 = (unsigned char *)(v0+v882);
                            bool v884;
                            v884 = 0l <= v878;
                            bool v886;
                            if (v884){
                                bool v885;
                                v885 = v878 < 2l;
                                v886 = v885;
                            } else {
                                v886 = false;
                            }
                            bool v887;
                            v887 = v886 == false;
                            if (v887){
                                assert("The read index needs to be in range." && v886);
                            } else {
                            }
                            US5 v888;
                            v888 = v868.v[v878];
                            long v889;
                            v889 = v888.tag;
                            long * v890;
                            v890 = (long *)(v883+0ull);
                            v890[0l] = v889;
                            switch (v888.tag) {
                                case 0: { // Jack
                                    break;
                                }
                                case 1: { // King
                                    break;
                                }
                                default: { // Queen
                                }
                            }
                            v878 += 1l ;
                        }
                        long * v891;
                        v891 = (long *)(v0+80ull);
                        v891[0l] = v869;
                        long v892;
                        v892 = 0l;
                        while (while_method_0(v892)){
                            unsigned long long v894;
                            v894 = (unsigned long long)v892;
                            unsigned long long v895;
                            v895 = v894 * 4ull;
                            unsigned long long v896;
                            v896 = 84ull + v895;
                            unsigned char * v897;
                            v897 = (unsigned char *)(v0+v896);
                            bool v898;
                            v898 = 0l <= v892;
                            bool v900;
                            if (v898){
                                bool v899;
                                v899 = v892 < 2l;
                                v900 = v899;
                            } else {
                                v900 = false;
                            }
                            bool v901;
                            v901 = v900 == false;
                            if (v901){
                                assert("The read index needs to be in range." && v900);
                            } else {
                            }
                            long v902;
                            v902 = v870.v[v892];
                            long * v903;
                            v903 = (long *)(v897+0ull);
                            v903[0l] = v902;
                            v892 += 1l ;
                        }
                        long * v904;
                        v904 = (long *)(v0+92ull);
                        v904[0l] = v871;
                    }
                }
            }
        }
        long v905;
        v905 = 0l;
        while (while_method_2(v905)){
            unsigned long long v907;
            v907 = (unsigned long long)v905;
            unsigned long long v908;
            v908 = v907 * 32ull;
            unsigned long long v909;
            v909 = 112ull + v908;
            unsigned char * v910;
            v910 = (unsigned char *)(v0+v909);
            bool v911;
            v911 = 0l <= v905;
            bool v913;
            if (v911){
                bool v912;
                v912 = v905 < 32l;
                v913 = v912;
            } else {
                v913 = false;
            }
            bool v914;
            v914 = v913 == false;
            if (v914){
                assert("The read index needs to be in range." && v913);
            } else {
            }
            US7 v915;
            v915 = v682.v[v905];
            long v916;
            v916 = v915.tag;
            long * v917;
            v917 = (long *)(v910+0ull);
            v917[0l] = v916;
            switch (v915.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    US8 v918 = v915.v.case1.v0;
                    long v919;
                    v919 = v918.tag;
                    long * v920;
                    v920 = (long *)(v910+4ull);
                    v920[0l] = v919;
                    switch (v918.tag) {
                        case 0: { // CommunityCardIs
                            US5 v921 = v918.v.case0.v0;
                            long v922;
                            v922 = v921.tag;
                            long * v923;
                            v923 = (long *)(v910+8ull);
                            v923[0l] = v922;
                            switch (v921.tag) {
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
                            long v924 = v918.v.case1.v0; US1 v925 = v918.v.case1.v1;
                            long * v926;
                            v926 = (long *)(v910+8ull);
                            v926[0l] = v924;
                            long v927;
                            v927 = v925.tag;
                            long * v928;
                            v928 = (long *)(v910+12ull);
                            v928[0l] = v927;
                            switch (v925.tag) {
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
                            long v929 = v918.v.case2.v0; US5 v930 = v918.v.case2.v1;
                            long * v931;
                            v931 = (long *)(v910+8ull);
                            v931[0l] = v929;
                            long v932;
                            v932 = v930.tag;
                            long * v933;
                            v933 = (long *)(v910+12ull);
                            v933[0l] = v932;
                            switch (v930.tag) {
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
                            array<US5,2l> & v934 = v918.v.case3.v0; long v935 = v918.v.case3.v1; long v936 = v918.v.case3.v2;
                            long v937;
                            v937 = 0l;
                            while (while_method_0(v937)){
                                unsigned long long v939;
                                v939 = (unsigned long long)v937;
                                unsigned long long v940;
                                v940 = v939 * 4ull;
                                unsigned long long v941;
                                v941 = 8ull + v940;
                                unsigned char * v942;
                                v942 = (unsigned char *)(v910+v941);
                                bool v943;
                                v943 = 0l <= v937;
                                bool v945;
                                if (v943){
                                    bool v944;
                                    v944 = v937 < 2l;
                                    v945 = v944;
                                } else {
                                    v945 = false;
                                }
                                bool v946;
                                v946 = v945 == false;
                                if (v946){
                                    assert("The read index needs to be in range." && v945);
                                } else {
                                }
                                US5 v947;
                                v947 = v934.v[v937];
                                long v948;
                                v948 = v947.tag;
                                long * v949;
                                v949 = (long *)(v942+0ull);
                                v949[0l] = v948;
                                switch (v947.tag) {
                                    case 0: { // Jack
                                        break;
                                    }
                                    case 1: { // King
                                        break;
                                    }
                                    default: { // Queen
                                    }
                                }
                                v937 += 1l ;
                            }
                            long * v950;
                            v950 = (long *)(v910+16ull);
                            v950[0l] = v935;
                            long * v951;
                            v951 = (long *)(v910+20ull);
                            v951[0l] = v936;
                        }
                    }
                }
            }
            v905 += 1l ;
        }
        long v952;
        v952 = 0l;
        while (while_method_0(v952)){
            unsigned long long v954;
            v954 = (unsigned long long)v952;
            unsigned long long v955;
            v955 = v954 * 4ull;
            unsigned long long v956;
            v956 = 1136ull + v955;
            unsigned char * v957;
            v957 = (unsigned char *)(v0+v956);
            bool v958;
            v958 = 0l <= v952;
            bool v960;
            if (v958){
                bool v959;
                v959 = v952 < 2l;
                v960 = v959;
            } else {
                v960 = false;
            }
            bool v961;
            v961 = v960 == false;
            if (v961){
                assert("The read index needs to be in range." && v960);
            } else {
            }
            US2 v962;
            v962 = v683.v[v952];
            long v963;
            v963 = v962.tag;
            long * v964;
            v964 = (long *)(v957+0ull);
            v964[0l] = v963;
            switch (v962.tag) {
                case 0: { // Computer
                    break;
                }
                default: { // Human
                }
            }
            v952 += 1l ;
        }
        long v965;
        v965 = v684.tag;
        long * v966;
        v966 = (long *)(v0+1144ull);
        v966[0l] = v965;
        switch (v684.tag) {
            case 0: { // GameNotStarted
                return ;
                break;
            }
            case 1: { // GameOver
                US4 v967 = v684.v.case1.v0; bool v968 = v684.v.case1.v1; array<US5,2l> & v969 = v684.v.case1.v2; long v970 = v684.v.case1.v3; array<long,2l> & v971 = v684.v.case1.v4; long v972 = v684.v.case1.v5;
                long v973;
                v973 = v967.tag;
                long * v974;
                v974 = (long *)(v0+1148ull);
                v974[0l] = v973;
                switch (v967.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US5 v975 = v967.v.case1.v0;
                        long v976;
                        v976 = v975.tag;
                        long * v977;
                        v977 = (long *)(v0+1152ull);
                        v977[0l] = v976;
                        switch (v975.tag) {
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
                bool * v978;
                v978 = (bool *)(v0+1156ull);
                v978[0l] = v968;
                long v979;
                v979 = 0l;
                while (while_method_0(v979)){
                    unsigned long long v981;
                    v981 = (unsigned long long)v979;
                    unsigned long long v982;
                    v982 = v981 * 4ull;
                    unsigned long long v983;
                    v983 = 1160ull + v982;
                    unsigned char * v984;
                    v984 = (unsigned char *)(v0+v983);
                    bool v985;
                    v985 = 0l <= v979;
                    bool v987;
                    if (v985){
                        bool v986;
                        v986 = v979 < 2l;
                        v987 = v986;
                    } else {
                        v987 = false;
                    }
                    bool v988;
                    v988 = v987 == false;
                    if (v988){
                        assert("The read index needs to be in range." && v987);
                    } else {
                    }
                    US5 v989;
                    v989 = v969.v[v979];
                    long v990;
                    v990 = v989.tag;
                    long * v991;
                    v991 = (long *)(v984+0ull);
                    v991[0l] = v990;
                    switch (v989.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v979 += 1l ;
                }
                long * v992;
                v992 = (long *)(v0+1168ull);
                v992[0l] = v970;
                long v993;
                v993 = 0l;
                while (while_method_0(v993)){
                    unsigned long long v995;
                    v995 = (unsigned long long)v993;
                    unsigned long long v996;
                    v996 = v995 * 4ull;
                    unsigned long long v997;
                    v997 = 1172ull + v996;
                    unsigned char * v998;
                    v998 = (unsigned char *)(v0+v997);
                    bool v999;
                    v999 = 0l <= v993;
                    bool v1001;
                    if (v999){
                        bool v1000;
                        v1000 = v993 < 2l;
                        v1001 = v1000;
                    } else {
                        v1001 = false;
                    }
                    bool v1002;
                    v1002 = v1001 == false;
                    if (v1002){
                        assert("The read index needs to be in range." && v1001);
                    } else {
                    }
                    long v1003;
                    v1003 = v971.v[v993];
                    long * v1004;
                    v1004 = (long *)(v998+0ull);
                    v1004[0l] = v1003;
                    v993 += 1l ;
                }
                long * v1005;
                v1005 = (long *)(v0+1180ull);
                v1005[0l] = v972;
                return ;
                break;
            }
            default: { // WaitingForActionFromPlayerId
                US4 v1006 = v684.v.case2.v0; bool v1007 = v684.v.case2.v1; array<US5,2l> & v1008 = v684.v.case2.v2; long v1009 = v684.v.case2.v3; array<long,2l> & v1010 = v684.v.case2.v4; long v1011 = v684.v.case2.v5;
                long v1012;
                v1012 = v1006.tag;
                long * v1013;
                v1013 = (long *)(v0+1148ull);
                v1013[0l] = v1012;
                switch (v1006.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US5 v1014 = v1006.v.case1.v0;
                        long v1015;
                        v1015 = v1014.tag;
                        long * v1016;
                        v1016 = (long *)(v0+1152ull);
                        v1016[0l] = v1015;
                        switch (v1014.tag) {
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
                bool * v1017;
                v1017 = (bool *)(v0+1156ull);
                v1017[0l] = v1007;
                long v1018;
                v1018 = 0l;
                while (while_method_0(v1018)){
                    unsigned long long v1020;
                    v1020 = (unsigned long long)v1018;
                    unsigned long long v1021;
                    v1021 = v1020 * 4ull;
                    unsigned long long v1022;
                    v1022 = 1160ull + v1021;
                    unsigned char * v1023;
                    v1023 = (unsigned char *)(v0+v1022);
                    bool v1024;
                    v1024 = 0l <= v1018;
                    bool v1026;
                    if (v1024){
                        bool v1025;
                        v1025 = v1018 < 2l;
                        v1026 = v1025;
                    } else {
                        v1026 = false;
                    }
                    bool v1027;
                    v1027 = v1026 == false;
                    if (v1027){
                        assert("The read index needs to be in range." && v1026);
                    } else {
                    }
                    US5 v1028;
                    v1028 = v1008.v[v1018];
                    long v1029;
                    v1029 = v1028.tag;
                    long * v1030;
                    v1030 = (long *)(v1023+0ull);
                    v1030[0l] = v1029;
                    switch (v1028.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v1018 += 1l ;
                }
                long * v1031;
                v1031 = (long *)(v0+1168ull);
                v1031[0l] = v1009;
                long v1032;
                v1032 = 0l;
                while (while_method_0(v1032)){
                    unsigned long long v1034;
                    v1034 = (unsigned long long)v1032;
                    unsigned long long v1035;
                    v1035 = v1034 * 4ull;
                    unsigned long long v1036;
                    v1036 = 1172ull + v1035;
                    unsigned char * v1037;
                    v1037 = (unsigned char *)(v0+v1036);
                    bool v1038;
                    v1038 = 0l <= v1032;
                    bool v1040;
                    if (v1038){
                        bool v1039;
                        v1039 = v1032 < 2l;
                        v1040 = v1039;
                    } else {
                        v1040 = false;
                    }
                    bool v1041;
                    v1041 = v1040 == false;
                    if (v1041){
                        assert("The read index needs to be in range." && v1040);
                    } else {
                    }
                    long v1042;
                    v1042 = v1010.v[v1032];
                    long * v1043;
                    v1043 = (long *)(v1037+0ull);
                    v1043[0l] = v1042;
                    v1032 += 1l ;
                }
                long * v1044;
                v1044 = (long *)(v0+1180ull);
                v1044[0l] = v1011;
                return ;
            }
        }
    } else {
        return ;
    }
}
"""
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
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US0_0(NamedTuple): # ActionSelected
    v0 : US1
    tag = 0
class US0_1(NamedTuple): # PlayerChanged
    v0 : list[US2]
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US5_0(NamedTuple): # Jack
    tag = 0
class US5_1(NamedTuple): # King
    tag = 1
class US5_2(NamedTuple): # Queen
    tag = 2
US5 = Union[US5_0, US5_1, US5_2]
class US4_0(NamedTuple): # None
    tag = 0
class US4_1(NamedTuple): # Some
    v0 : US5
    tag = 1
US4 = Union[US4_0, US4_1]
class US6_0(NamedTuple): # ChanceCommunityCard
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 0
class US6_1(NamedTuple): # ChanceInit
    tag = 1
class US6_2(NamedTuple): # Round
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
class US6_3(NamedTuple): # RoundWithAction
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    v6 : US1
    tag = 3
class US6_4(NamedTuple): # TerminalCall
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 4
class US6_5(NamedTuple): # TerminalFold
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 5
US6 = Union[US6_0, US6_1, US6_2, US6_3, US6_4, US6_5]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : list[US4]
    v1 : US6
    tag = 1
US3 = Union[US3_0, US3_1]
class US8_0(NamedTuple): # CommunityCardIs
    v0 : US5
    tag = 0
class US8_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US8_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US5
    tag = 2
class US8_3(NamedTuple): # Showdown
    v0 : list[US5]
    v1 : i32
    v2 : i32
    tag = 3
US8 = Union[US8_0, US8_1, US8_2, US8_3]
class US7_0(NamedTuple): # None
    tag = 0
class US7_1(NamedTuple): # Some
    v0 : US8
    tag = 1
US7 = Union[US7_0, US7_1]
class US9_0(NamedTuple): # GameNotStarted
    tag = 0
class US9_1(NamedTuple): # GameOver
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 1
class US9_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
US9 = Union[US9_0, US9_1, US9_2]
class US10_0(NamedTuple): # Eq
    tag = 0
class US10_1(NamedTuple): # Gt
    tag = 1
class US10_2(NamedTuple): # Lt
    tag = 2
US10 = Union[US10_0, US10_1, US10_2]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6 = method5(v1)
        match v2:
            case US0_0(v63): # ActionSelected
                match v3:
                    case US3_0(): # None
                        del v63
                        v124, v125, v126, v127 = v3, v4, v5, v6
                    case US3_1(v64, v65): # Some
                        match v65:
                            case US6_2(v66, v67, v68, v69, v70, v71): # Round
                                del v65
                                v72 = [None] * 6
                                v73 = [0]
                                v74 = 0
                                while method13(v74):
                                    v76 = 0 <= v74
                                    if v76:
                                        v77 = v74 < 6
                                        v78 = v77
                                    else:
                                        v78 = False
                                    del v76
                                    v79 = v78 == False
                                    if v79:
                                        v80 = "The read index needs to be in range."
                                        assert v78, v80
                                        del v80
                                    else:
                                        pass
                                    del v78, v79
                                    v81 = v64[v74]
                                    match v81:
                                        case US4_0(): # None
                                            pass
                                        case US4_1(v82): # Some
                                            v83 = v73[0]
                                            v84 = 1 + v83
                                            v73[0] = v84
                                            del v84
                                            v85 = 0 <= v83
                                            if v85:
                                                v86 = v73[0]
                                                v87 = v83 < v86
                                                del v86
                                                v88 = v87
                                            else:
                                                v88 = False
                                            v89 = v88 == False
                                            if v89:
                                                v90 = "The set index needs to be in range."
                                                assert v88, v90
                                                del v90
                                            else:
                                                pass
                                            del v88, v89
                                            if v85:
                                                v91 = v83 < 6
                                                v92 = v91
                                            else:
                                                v92 = False
                                            del v85
                                            v93 = v92 == False
                                            if v93:
                                                v94 = "The read index needs to be in range."
                                                assert v92, v94
                                                del v94
                                            else:
                                                pass
                                            del v92, v93
                                            v72[v83] = v82
                                            del v82, v83
                                        case _:
                                            raise Exception('Pattern matching miss.')
                                    del v81
                                    v74 += 1 
                                del v64, v74
                                v95 = US6_3(v66, v67, v68, v69, v70, v71, v63)
                                del v63, v66, v67, v68, v69, v70, v71
                                v124, v125, v126, v127 = method14(v3, v4, v5, v6, v72, v73, v95)
                            case _:
                                del v63, v64, v65
                                raise Exception("Unexpected game node in ActionSelected.")
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v62): # PlayerChanged
                v124, v125, v126, v127 = v3, v4, v62, v6
            case US0_2(): # StartGame
                v7 = [None] * 2
                v8 = US2_0()
                v7[0] = v8
                del v8
                v9 = US2_1()
                v7[1] = v9
                del v9
                v10 = [None] * 32
                v11 = 0
                while method15(v11):
                    v13 = 0 <= v11
                    if v13:
                        v14 = v11 < 32
                        v15 = v14
                    else:
                        v15 = False
                    del v13
                    v16 = v15 == False
                    if v16:
                        v17 = "The read index needs to be in range."
                        assert v15, v17
                        del v17
                    else:
                        pass
                    del v15, v16
                    v18 = US7_0()
                    v10[v11] = v18
                    del v18
                    v11 += 1 
                del v11
                v19 = US3_0()
                v20 = US9_0()
                v21 = [None] * 6
                v22 = [0]
                v23 = v22[0]
                del v23
                v22[0] = 6
                v24 = v22[0]
                v25 = 0 < v24
                del v24
                v26 = v25 == False
                if v26:
                    v27 = "The set index needs to be in range."
                    assert v25, v27
                    del v27
                else:
                    pass
                del v25, v26
                v28 = US5_1()
                v21[0] = v28
                del v28
                v29 = v22[0]
                v30 = 1 < v29
                del v29
                v31 = v30 == False
                if v31:
                    v32 = "The set index needs to be in range."
                    assert v30, v32
                    del v32
                else:
                    pass
                del v30, v31
                v33 = US5_1()
                v21[1] = v33
                del v33
                v34 = v22[0]
                v35 = 2 < v34
                del v34
                v36 = v35 == False
                if v36:
                    v37 = "The set index needs to be in range."
                    assert v35, v37
                    del v37
                else:
                    pass
                del v35, v36
                v38 = US5_2()
                v21[2] = v38
                del v38
                v39 = v22[0]
                v40 = 3 < v39
                del v39
                v41 = v40 == False
                if v41:
                    v42 = "The set index needs to be in range."
                    assert v40, v42
                    del v42
                else:
                    pass
                del v40, v41
                v43 = US5_2()
                v21[3] = v43
                del v43
                v44 = v22[0]
                v45 = 4 < v44
                del v44
                v46 = v45 == False
                if v46:
                    v47 = "The set index needs to be in range."
                    assert v45, v47
                    del v47
                else:
                    pass
                del v45, v46
                v48 = US5_0()
                v21[4] = v48
                del v48
                v49 = v22[0]
                v50 = 5 < v49
                del v49
                v51 = v50 == False
                if v51:
                    v52 = "The set index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = US5_0()
                v21[5] = v53
                del v53
                v54 = v22[0]
                v55 = v21[:v54]
                del v54
                random.shuffle(v55)
                v56 = v22[0]
                v21[:v56] = v55
                del v55, v56
                v57 = US6_1()
                v124, v125, v126, v127 = method14(v19, v10, v7, v20, v21, v22, v57)
            case _:
                raise Exception('Pattern matching miss.')
        del v2, v3, v4, v5, v6
        return method22(v124, v125, v126, v127)
    return inner
def Closure1():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(1184,dtype=cp.uint8)
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
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v14): # PlayerChanged
                v15 = 0
                while method17(v15):
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
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v26
                    v15 += 1 
                del v14, v15
            case US0_2(): # StartGame
                pass
            case _:
                raise Exception('Pattern matching miss.')
        del v4
        v29 = v5.tag
        v30 = v3[0:].view(cp.int32)
        v30[0] = v29
        del v29, v30
        match v5:
            case US3_0(): # None
                pass
            case US3_1(v31, v32): # Some
                v33 = 0
                while method13(v33):
                    v35 = u64(v33)
                    v36 = v35 * 8
                    del v35
                    v37 = 8 + v36
                    del v36
                    v38 = v3[v37:].view(cp.uint8)
                    del v37
                    v39 = 0 <= v33
                    if v39:
                        v40 = v33 < 6
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
                    v44 = v31[v33]
                    v45 = v44.tag
                    v46 = v38[0:].view(cp.int32)
                    v46[0] = v45
                    del v45, v46
                    match v44:
                        case US4_0(): # None
                            pass
                        case US4_1(v47): # Some
                            v48 = v47.tag
                            v49 = v38[4:].view(cp.int32)
                            v49[0] = v48
                            del v48, v49
                            match v47:
                                case US5_0(): # Jack
                                    del v47
                                case US5_1(): # King
                                    del v47
                                case US5_2(): # Queen
                                    del v47
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v38, v44
                    v33 += 1 
                del v31, v33
                v50 = v32.tag
                v51 = v3[56:].view(cp.int32)
                v51[0] = v50
                del v50, v51
                match v32:
                    case US6_0(v52, v53, v54, v55, v56, v57): # ChanceCommunityCard
                        del v32
                        v58 = v52.tag
                        v59 = v3[60:].view(cp.int32)
                        v59[0] = v58
                        del v58, v59
                        match v52:
                            case US4_0(): # None
                                pass
                            case US4_1(v60): # Some
                                v61 = v60.tag
                                v62 = v3[64:].view(cp.int32)
                                v62[0] = v61
                                del v61, v62
                                match v60:
                                    case US5_0(): # Jack
                                        del v60
                                    case US5_1(): # King
                                        del v60
                                    case US5_2(): # Queen
                                        del v60
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v52
                        v63 = v3[68:].view(cp.int8)
                        v63[0] = v53
                        del v53, v63
                        v64 = 0
                        while method17(v64):
                            v66 = u64(v64)
                            v67 = v66 * 4
                            del v66
                            v68 = 72 + v67
                            del v67
                            v69 = v3[v68:].view(cp.uint8)
                            del v68
                            v70 = 0 <= v64
                            if v70:
                                v71 = v64 < 2
                                v72 = v71
                            else:
                                v72 = False
                            del v70
                            v73 = v72 == False
                            if v73:
                                v74 = "The read index needs to be in range."
                                assert v72, v74
                                del v74
                            else:
                                pass
                            del v72, v73
                            v75 = v54[v64]
                            v76 = v75.tag
                            v77 = v69[0:].view(cp.int32)
                            del v69
                            v77[0] = v76
                            del v76, v77
                            match v75:
                                case US5_0(): # Jack
                                    pass
                                case US5_1(): # King
                                    pass
                                case US5_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v75
                            v64 += 1 
                        del v54, v64
                        v78 = v3[80:].view(cp.int32)
                        v78[0] = v55
                        del v55, v78
                        v79 = 0
                        while method17(v79):
                            v81 = u64(v79)
                            v82 = v81 * 4
                            del v81
                            v83 = 84 + v82
                            del v82
                            v84 = v3[v83:].view(cp.uint8)
                            del v83
                            v85 = 0 <= v79
                            if v85:
                                v86 = v79 < 2
                                v87 = v86
                            else:
                                v87 = False
                            del v85
                            v88 = v87 == False
                            if v88:
                                v89 = "The read index needs to be in range."
                                assert v87, v89
                                del v89
                            else:
                                pass
                            del v87, v88
                            v90 = v56[v79]
                            v91 = v84[0:].view(cp.int32)
                            del v84
                            v91[0] = v90
                            del v90, v91
                            v79 += 1 
                        del v56, v79
                        v92 = v3[92:].view(cp.int32)
                        v92[0] = v57
                        del v57, v92
                    case US6_1(): # ChanceInit
                        del v32
                    case US6_2(v93, v94, v95, v96, v97, v98): # Round
                        del v32
                        v99 = v93.tag
                        v100 = v3[60:].view(cp.int32)
                        v100[0] = v99
                        del v99, v100
                        match v93:
                            case US4_0(): # None
                                pass
                            case US4_1(v101): # Some
                                v102 = v101.tag
                                v103 = v3[64:].view(cp.int32)
                                v103[0] = v102
                                del v102, v103
                                match v101:
                                    case US5_0(): # Jack
                                        del v101
                                    case US5_1(): # King
                                        del v101
                                    case US5_2(): # Queen
                                        del v101
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v93
                        v104 = v3[68:].view(cp.int8)
                        v104[0] = v94
                        del v94, v104
                        v105 = 0
                        while method17(v105):
                            v107 = u64(v105)
                            v108 = v107 * 4
                            del v107
                            v109 = 72 + v108
                            del v108
                            v110 = v3[v109:].view(cp.uint8)
                            del v109
                            v111 = 0 <= v105
                            if v111:
                                v112 = v105 < 2
                                v113 = v112
                            else:
                                v113 = False
                            del v111
                            v114 = v113 == False
                            if v114:
                                v115 = "The read index needs to be in range."
                                assert v113, v115
                                del v115
                            else:
                                pass
                            del v113, v114
                            v116 = v95[v105]
                            v117 = v116.tag
                            v118 = v110[0:].view(cp.int32)
                            del v110
                            v118[0] = v117
                            del v117, v118
                            match v116:
                                case US5_0(): # Jack
                                    pass
                                case US5_1(): # King
                                    pass
                                case US5_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v116
                            v105 += 1 
                        del v95, v105
                        v119 = v3[80:].view(cp.int32)
                        v119[0] = v96
                        del v96, v119
                        v120 = 0
                        while method17(v120):
                            v122 = u64(v120)
                            v123 = v122 * 4
                            del v122
                            v124 = 84 + v123
                            del v123
                            v125 = v3[v124:].view(cp.uint8)
                            del v124
                            v126 = 0 <= v120
                            if v126:
                                v127 = v120 < 2
                                v128 = v127
                            else:
                                v128 = False
                            del v126
                            v129 = v128 == False
                            if v129:
                                v130 = "The read index needs to be in range."
                                assert v128, v130
                                del v130
                            else:
                                pass
                            del v128, v129
                            v131 = v97[v120]
                            v132 = v125[0:].view(cp.int32)
                            del v125
                            v132[0] = v131
                            del v131, v132
                            v120 += 1 
                        del v97, v120
                        v133 = v3[92:].view(cp.int32)
                        v133[0] = v98
                        del v98, v133
                    case US6_3(v134, v135, v136, v137, v138, v139, v140): # RoundWithAction
                        del v32
                        v141 = v134.tag
                        v142 = v3[60:].view(cp.int32)
                        v142[0] = v141
                        del v141, v142
                        match v134:
                            case US4_0(): # None
                                pass
                            case US4_1(v143): # Some
                                v144 = v143.tag
                                v145 = v3[64:].view(cp.int32)
                                v145[0] = v144
                                del v144, v145
                                match v143:
                                    case US5_0(): # Jack
                                        del v143
                                    case US5_1(): # King
                                        del v143
                                    case US5_2(): # Queen
                                        del v143
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v134
                        v146 = v3[68:].view(cp.int8)
                        v146[0] = v135
                        del v135, v146
                        v147 = 0
                        while method17(v147):
                            v149 = u64(v147)
                            v150 = v149 * 4
                            del v149
                            v151 = 72 + v150
                            del v150
                            v152 = v3[v151:].view(cp.uint8)
                            del v151
                            v153 = 0 <= v147
                            if v153:
                                v154 = v147 < 2
                                v155 = v154
                            else:
                                v155 = False
                            del v153
                            v156 = v155 == False
                            if v156:
                                v157 = "The read index needs to be in range."
                                assert v155, v157
                                del v157
                            else:
                                pass
                            del v155, v156
                            v158 = v136[v147]
                            v159 = v158.tag
                            v160 = v152[0:].view(cp.int32)
                            del v152
                            v160[0] = v159
                            del v159, v160
                            match v158:
                                case US5_0(): # Jack
                                    pass
                                case US5_1(): # King
                                    pass
                                case US5_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v158
                            v147 += 1 
                        del v136, v147
                        v161 = v3[80:].view(cp.int32)
                        v161[0] = v137
                        del v137, v161
                        v162 = 0
                        while method17(v162):
                            v164 = u64(v162)
                            v165 = v164 * 4
                            del v164
                            v166 = 84 + v165
                            del v165
                            v167 = v3[v166:].view(cp.uint8)
                            del v166
                            v168 = 0 <= v162
                            if v168:
                                v169 = v162 < 2
                                v170 = v169
                            else:
                                v170 = False
                            del v168
                            v171 = v170 == False
                            if v171:
                                v172 = "The read index needs to be in range."
                                assert v170, v172
                                del v172
                            else:
                                pass
                            del v170, v171
                            v173 = v138[v162]
                            v174 = v167[0:].view(cp.int32)
                            del v167
                            v174[0] = v173
                            del v173, v174
                            v162 += 1 
                        del v138, v162
                        v175 = v3[92:].view(cp.int32)
                        v175[0] = v139
                        del v139, v175
                        v176 = v140.tag
                        v177 = v3[96:].view(cp.int32)
                        v177[0] = v176
                        del v176, v177
                        match v140:
                            case US1_0(): # Call
                                del v140
                            case US1_1(): # Fold
                                del v140
                            case US1_2(): # Raise
                                del v140
                            case _:
                                raise Exception('Pattern matching miss.')
                    case US6_4(v178, v179, v180, v181, v182, v183): # TerminalCall
                        del v32
                        v184 = v178.tag
                        v185 = v3[60:].view(cp.int32)
                        v185[0] = v184
                        del v184, v185
                        match v178:
                            case US4_0(): # None
                                pass
                            case US4_1(v186): # Some
                                v187 = v186.tag
                                v188 = v3[64:].view(cp.int32)
                                v188[0] = v187
                                del v187, v188
                                match v186:
                                    case US5_0(): # Jack
                                        del v186
                                    case US5_1(): # King
                                        del v186
                                    case US5_2(): # Queen
                                        del v186
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v178
                        v189 = v3[68:].view(cp.int8)
                        v189[0] = v179
                        del v179, v189
                        v190 = 0
                        while method17(v190):
                            v192 = u64(v190)
                            v193 = v192 * 4
                            del v192
                            v194 = 72 + v193
                            del v193
                            v195 = v3[v194:].view(cp.uint8)
                            del v194
                            v196 = 0 <= v190
                            if v196:
                                v197 = v190 < 2
                                v198 = v197
                            else:
                                v198 = False
                            del v196
                            v199 = v198 == False
                            if v199:
                                v200 = "The read index needs to be in range."
                                assert v198, v200
                                del v200
                            else:
                                pass
                            del v198, v199
                            v201 = v180[v190]
                            v202 = v201.tag
                            v203 = v195[0:].view(cp.int32)
                            del v195
                            v203[0] = v202
                            del v202, v203
                            match v201:
                                case US5_0(): # Jack
                                    pass
                                case US5_1(): # King
                                    pass
                                case US5_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v201
                            v190 += 1 
                        del v180, v190
                        v204 = v3[80:].view(cp.int32)
                        v204[0] = v181
                        del v181, v204
                        v205 = 0
                        while method17(v205):
                            v207 = u64(v205)
                            v208 = v207 * 4
                            del v207
                            v209 = 84 + v208
                            del v208
                            v210 = v3[v209:].view(cp.uint8)
                            del v209
                            v211 = 0 <= v205
                            if v211:
                                v212 = v205 < 2
                                v213 = v212
                            else:
                                v213 = False
                            del v211
                            v214 = v213 == False
                            if v214:
                                v215 = "The read index needs to be in range."
                                assert v213, v215
                                del v215
                            else:
                                pass
                            del v213, v214
                            v216 = v182[v205]
                            v217 = v210[0:].view(cp.int32)
                            del v210
                            v217[0] = v216
                            del v216, v217
                            v205 += 1 
                        del v182, v205
                        v218 = v3[92:].view(cp.int32)
                        v218[0] = v183
                        del v183, v218
                    case US6_5(v219, v220, v221, v222, v223, v224): # TerminalFold
                        del v32
                        v225 = v219.tag
                        v226 = v3[60:].view(cp.int32)
                        v226[0] = v225
                        del v225, v226
                        match v219:
                            case US4_0(): # None
                                pass
                            case US4_1(v227): # Some
                                v228 = v227.tag
                                v229 = v3[64:].view(cp.int32)
                                v229[0] = v228
                                del v228, v229
                                match v227:
                                    case US5_0(): # Jack
                                        del v227
                                    case US5_1(): # King
                                        del v227
                                    case US5_2(): # Queen
                                        del v227
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v219
                        v230 = v3[68:].view(cp.int8)
                        v230[0] = v220
                        del v220, v230
                        v231 = 0
                        while method17(v231):
                            v233 = u64(v231)
                            v234 = v233 * 4
                            del v233
                            v235 = 72 + v234
                            del v234
                            v236 = v3[v235:].view(cp.uint8)
                            del v235
                            v237 = 0 <= v231
                            if v237:
                                v238 = v231 < 2
                                v239 = v238
                            else:
                                v239 = False
                            del v237
                            v240 = v239 == False
                            if v240:
                                v241 = "The read index needs to be in range."
                                assert v239, v241
                                del v241
                            else:
                                pass
                            del v239, v240
                            v242 = v221[v231]
                            v243 = v242.tag
                            v244 = v236[0:].view(cp.int32)
                            del v236
                            v244[0] = v243
                            del v243, v244
                            match v242:
                                case US5_0(): # Jack
                                    pass
                                case US5_1(): # King
                                    pass
                                case US5_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v242
                            v231 += 1 
                        del v221, v231
                        v245 = v3[80:].view(cp.int32)
                        v245[0] = v222
                        del v222, v245
                        v246 = 0
                        while method17(v246):
                            v248 = u64(v246)
                            v249 = v248 * 4
                            del v248
                            v250 = 84 + v249
                            del v249
                            v251 = v3[v250:].view(cp.uint8)
                            del v250
                            v252 = 0 <= v246
                            if v252:
                                v253 = v246 < 2
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
                            v257 = v223[v246]
                            v258 = v251[0:].view(cp.int32)
                            del v251
                            v258[0] = v257
                            del v257, v258
                            v246 += 1 
                        del v223, v246
                        v259 = v3[92:].view(cp.int32)
                        v259[0] = v224
                        del v224, v259
                    case _:
                        raise Exception('Pattern matching miss.')
            case _:
                raise Exception('Pattern matching miss.')
        del v5
        v260 = 0
        while method15(v260):
            v262 = u64(v260)
            v263 = v262 * 32
            del v262
            v264 = 112 + v263
            del v263
            v265 = v3[v264:].view(cp.uint8)
            del v264
            v266 = 0 <= v260
            if v266:
                v267 = v260 < 32
                v268 = v267
            else:
                v268 = False
            del v266
            v269 = v268 == False
            if v269:
                v270 = "The read index needs to be in range."
                assert v268, v270
                del v270
            else:
                pass
            del v268, v269
            v271 = v6[v260]
            v272 = v271.tag
            v273 = v265[0:].view(cp.int32)
            v273[0] = v272
            del v272, v273
            match v271:
                case US7_0(): # None
                    pass
                case US7_1(v274): # Some
                    v275 = v274.tag
                    v276 = v265[4:].view(cp.int32)
                    v276[0] = v275
                    del v275, v276
                    match v274:
                        case US8_0(v277): # CommunityCardIs
                            del v274
                            v278 = v277.tag
                            v279 = v265[8:].view(cp.int32)
                            v279[0] = v278
                            del v278, v279
                            match v277:
                                case US5_0(): # Jack
                                    del v277
                                case US5_1(): # King
                                    del v277
                                case US5_2(): # Queen
                                    del v277
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US8_1(v280, v281): # PlayerAction
                            del v274
                            v282 = v265[8:].view(cp.int32)
                            v282[0] = v280
                            del v280, v282
                            v283 = v281.tag
                            v284 = v265[12:].view(cp.int32)
                            v284[0] = v283
                            del v283, v284
                            match v281:
                                case US1_0(): # Call
                                    del v281
                                case US1_1(): # Fold
                                    del v281
                                case US1_2(): # Raise
                                    del v281
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US8_2(v285, v286): # PlayerGotCard
                            del v274
                            v287 = v265[8:].view(cp.int32)
                            v287[0] = v285
                            del v285, v287
                            v288 = v286.tag
                            v289 = v265[12:].view(cp.int32)
                            v289[0] = v288
                            del v288, v289
                            match v286:
                                case US5_0(): # Jack
                                    del v286
                                case US5_1(): # King
                                    del v286
                                case US5_2(): # Queen
                                    del v286
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US8_3(v290, v291, v292): # Showdown
                            del v274
                            v293 = 0
                            while method17(v293):
                                v295 = u64(v293)
                                v296 = v295 * 4
                                del v295
                                v297 = 8 + v296
                                del v296
                                v298 = v265[v297:].view(cp.uint8)
                                del v297
                                v299 = 0 <= v293
                                if v299:
                                    v300 = v293 < 2
                                    v301 = v300
                                else:
                                    v301 = False
                                del v299
                                v302 = v301 == False
                                if v302:
                                    v303 = "The read index needs to be in range."
                                    assert v301, v303
                                    del v303
                                else:
                                    pass
                                del v301, v302
                                v304 = v290[v293]
                                v305 = v304.tag
                                v306 = v298[0:].view(cp.int32)
                                del v298
                                v306[0] = v305
                                del v305, v306
                                match v304:
                                    case US5_0(): # Jack
                                        pass
                                    case US5_1(): # King
                                        pass
                                    case US5_2(): # Queen
                                        pass
                                    case _:
                                        raise Exception('Pattern matching miss.')
                                del v304
                                v293 += 1 
                            del v290, v293
                            v307 = v265[16:].view(cp.int32)
                            v307[0] = v291
                            del v291, v307
                            v308 = v265[20:].view(cp.int32)
                            v308[0] = v292
                            del v292, v308
                        case _:
                            raise Exception('Pattern matching miss.')
                case _:
                    raise Exception('Pattern matching miss.')
            del v265, v271
            v260 += 1 
        del v6, v260
        v309 = 0
        while method17(v309):
            v311 = u64(v309)
            v312 = v311 * 4
            del v311
            v313 = 1136 + v312
            del v312
            v314 = v3[v313:].view(cp.uint8)
            del v313
            v315 = 0 <= v309
            if v315:
                v316 = v309 < 2
                v317 = v316
            else:
                v317 = False
            del v315
            v318 = v317 == False
            if v318:
                v319 = "The read index needs to be in range."
                assert v317, v319
                del v319
            else:
                pass
            del v317, v318
            v320 = v7[v309]
            v321 = v320.tag
            v322 = v314[0:].view(cp.int32)
            del v314
            v322[0] = v321
            del v321, v322
            match v320:
                case US2_0(): # Computer
                    pass
                case US2_1(): # Human
                    pass
                case _:
                    raise Exception('Pattern matching miss.')
            del v320
            v309 += 1 
        del v7, v309
        v323 = v8.tag
        v324 = v3[1144:].view(cp.int32)
        v324[0] = v323
        del v323, v324
        match v8:
            case US9_0(): # GameNotStarted
                pass
            case US9_1(v325, v326, v327, v328, v329, v330): # GameOver
                v331 = v325.tag
                v332 = v3[1148:].view(cp.int32)
                v332[0] = v331
                del v331, v332
                match v325:
                    case US4_0(): # None
                        pass
                    case US4_1(v333): # Some
                        v334 = v333.tag
                        v335 = v3[1152:].view(cp.int32)
                        v335[0] = v334
                        del v334, v335
                        match v333:
                            case US5_0(): # Jack
                                del v333
                            case US5_1(): # King
                                del v333
                            case US5_2(): # Queen
                                del v333
                            case _:
                                raise Exception('Pattern matching miss.')
                    case _:
                        raise Exception('Pattern matching miss.')
                del v325
                v336 = v3[1156:].view(cp.int8)
                v336[0] = v326
                del v326, v336
                v337 = 0
                while method17(v337):
                    v339 = u64(v337)
                    v340 = v339 * 4
                    del v339
                    v341 = 1160 + v340
                    del v340
                    v342 = v3[v341:].view(cp.uint8)
                    del v341
                    v343 = 0 <= v337
                    if v343:
                        v344 = v337 < 2
                        v345 = v344
                    else:
                        v345 = False
                    del v343
                    v346 = v345 == False
                    if v346:
                        v347 = "The read index needs to be in range."
                        assert v345, v347
                        del v347
                    else:
                        pass
                    del v345, v346
                    v348 = v327[v337]
                    v349 = v348.tag
                    v350 = v342[0:].view(cp.int32)
                    del v342
                    v350[0] = v349
                    del v349, v350
                    match v348:
                        case US5_0(): # Jack
                            pass
                        case US5_1(): # King
                            pass
                        case US5_2(): # Queen
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v348
                    v337 += 1 
                del v327, v337
                v351 = v3[1168:].view(cp.int32)
                v351[0] = v328
                del v328, v351
                v352 = 0
                while method17(v352):
                    v354 = u64(v352)
                    v355 = v354 * 4
                    del v354
                    v356 = 1172 + v355
                    del v355
                    v357 = v3[v356:].view(cp.uint8)
                    del v356
                    v358 = 0 <= v352
                    if v358:
                        v359 = v352 < 2
                        v360 = v359
                    else:
                        v360 = False
                    del v358
                    v361 = v360 == False
                    if v361:
                        v362 = "The read index needs to be in range."
                        assert v360, v362
                        del v362
                    else:
                        pass
                    del v360, v361
                    v363 = v329[v352]
                    v364 = v357[0:].view(cp.int32)
                    del v357
                    v364[0] = v363
                    del v363, v364
                    v352 += 1 
                del v329, v352
                v365 = v3[1180:].view(cp.int32)
                v365[0] = v330
                del v330, v365
            case US9_2(v366, v367, v368, v369, v370, v371): # WaitingForActionFromPlayerId
                v372 = v366.tag
                v373 = v3[1148:].view(cp.int32)
                v373[0] = v372
                del v372, v373
                match v366:
                    case US4_0(): # None
                        pass
                    case US4_1(v374): # Some
                        v375 = v374.tag
                        v376 = v3[1152:].view(cp.int32)
                        v376[0] = v375
                        del v375, v376
                        match v374:
                            case US5_0(): # Jack
                                del v374
                            case US5_1(): # King
                                del v374
                            case US5_2(): # Queen
                                del v374
                            case _:
                                raise Exception('Pattern matching miss.')
                    case _:
                        raise Exception('Pattern matching miss.')
                del v366
                v377 = v3[1156:].view(cp.int8)
                v377[0] = v367
                del v367, v377
                v378 = 0
                while method17(v378):
                    v380 = u64(v378)
                    v381 = v380 * 4
                    del v380
                    v382 = 1160 + v381
                    del v381
                    v383 = v3[v382:].view(cp.uint8)
                    del v382
                    v384 = 0 <= v378
                    if v384:
                        v385 = v378 < 2
                        v386 = v385
                    else:
                        v386 = False
                    del v384
                    v387 = v386 == False
                    if v387:
                        v388 = "The read index needs to be in range."
                        assert v386, v388
                        del v388
                    else:
                        pass
                    del v386, v387
                    v389 = v368[v378]
                    v390 = v389.tag
                    v391 = v383[0:].view(cp.int32)
                    del v383
                    v391[0] = v390
                    del v390, v391
                    match v389:
                        case US5_0(): # Jack
                            pass
                        case US5_1(): # King
                            pass
                        case US5_2(): # Queen
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v389
                    v378 += 1 
                del v368, v378
                v392 = v3[1168:].view(cp.int32)
                v392[0] = v369
                del v369, v392
                v393 = 0
                while method17(v393):
                    v395 = u64(v393)
                    v396 = v395 * 4
                    del v395
                    v397 = 1172 + v396
                    del v396
                    v398 = v3[v397:].view(cp.uint8)
                    del v397
                    v399 = 0 <= v393
                    if v399:
                        v400 = v393 < 2
                        v401 = v400
                    else:
                        v401 = False
                    del v399
                    v402 = v401 == False
                    if v402:
                        v403 = "The read index needs to be in range."
                        assert v401, v403
                        del v403
                    else:
                        pass
                    del v401, v402
                    v404 = v370[v393]
                    v405 = v398[0:].view(cp.int32)
                    del v398
                    v405[0] = v404
                    del v404, v405
                    v393 += 1 
                del v370, v393
                v406 = v3[1180:].view(cp.int32)
                v406[0] = v371
                del v371, v406
            case _:
                raise Exception('Pattern matching miss.')
        del v8
        v407 = 0
        v408 = raw_module.get_function(f"entry{v407}")
        del v407
        v408.max_dynamic_shared_size_bytes = 0 
        v408((1,),(512,),(v3, v2),shared_mem=0)
        del v2, v408
        v409 = v3[0:].view(cp.int32)
        v410 = v409[0].item()
        del v409
        if v410 == 0:
            v716 = US3_0()
        elif v410 == 1:
            v413 = [None] * 6
            v414 = 0
            while method13(v414):
                v416 = u64(v414)
                v417 = v416 * 8
                del v416
                v418 = 8 + v417
                del v417
                v419 = v3[v418:].view(cp.uint8)
                del v418
                v420 = v419[0:].view(cp.int32)
                v421 = v420[0].item()
                del v420
                if v421 == 0:
                    v432 = US4_0()
                elif v421 == 1:
                    v424 = v419[4:].view(cp.int32)
                    v425 = v424[0].item()
                    del v424
                    if v425 == 0:
                        v430 = US5_0()
                    elif v425 == 1:
                        v430 = US5_1()
                    elif v425 == 2:
                        v430 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v425
                    v432 = US4_1(v430)
                else:
                    raise Exception("Invalid tag.")
                del v419, v421
                v433 = 0 <= v414
                if v433:
                    v434 = v414 < 6
                    v435 = v434
                else:
                    v435 = False
                del v433
                v436 = v435 == False
                if v436:
                    v437 = "The read index needs to be in range."
                    assert v435, v437
                    del v437
                else:
                    pass
                del v435, v436
                v413[v414] = v432
                del v432
                v414 += 1 
            del v414
            v438 = v3[56:].view(cp.int32)
            v439 = v438[0].item()
            del v438
            if v439 == 0:
                v441 = v3[60:].view(cp.int32)
                v442 = v441[0].item()
                del v441
                if v442 == 0:
                    v453 = US4_0()
                elif v442 == 1:
                    v445 = v3[64:].view(cp.int32)
                    v446 = v445[0].item()
                    del v445
                    if v446 == 0:
                        v451 = US5_0()
                    elif v446 == 1:
                        v451 = US5_1()
                    elif v446 == 2:
                        v451 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v446
                    v453 = US4_1(v451)
                else:
                    raise Exception("Invalid tag.")
                del v442
                v454 = v3[68:].view(cp.int8)
                v455 = v454[0].item()
                del v454
                v456 = [None] * 2
                v457 = 0
                while method17(v457):
                    v459 = u64(v457)
                    v460 = v459 * 4
                    del v459
                    v461 = 72 + v460
                    del v460
                    v462 = v3[v461:].view(cp.uint8)
                    del v461
                    v463 = v462[0:].view(cp.int32)
                    del v462
                    v464 = v463[0].item()
                    del v463
                    if v464 == 0:
                        v469 = US5_0()
                    elif v464 == 1:
                        v469 = US5_1()
                    elif v464 == 2:
                        v469 = US5_2()
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
                v475 = v3[80:].view(cp.int32)
                v476 = v475[0].item()
                del v475
                v477 = [None] * 2
                v478 = 0
                while method17(v478):
                    v480 = u64(v478)
                    v481 = v480 * 4
                    del v480
                    v482 = 84 + v481
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
                v491 = v3[92:].view(cp.int32)
                v492 = v491[0].item()
                del v491
                v714 = US6_0(v453, v455, v456, v476, v477, v492)
            elif v439 == 1:
                v714 = US6_1()
            elif v439 == 2:
                v495 = v3[60:].view(cp.int32)
                v496 = v495[0].item()
                del v495
                if v496 == 0:
                    v507 = US4_0()
                elif v496 == 1:
                    v499 = v3[64:].view(cp.int32)
                    v500 = v499[0].item()
                    del v499
                    if v500 == 0:
                        v505 = US5_0()
                    elif v500 == 1:
                        v505 = US5_1()
                    elif v500 == 2:
                        v505 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v500
                    v507 = US4_1(v505)
                else:
                    raise Exception("Invalid tag.")
                del v496
                v508 = v3[68:].view(cp.int8)
                v509 = v508[0].item()
                del v508
                v510 = [None] * 2
                v511 = 0
                while method17(v511):
                    v513 = u64(v511)
                    v514 = v513 * 4
                    del v513
                    v515 = 72 + v514
                    del v514
                    v516 = v3[v515:].view(cp.uint8)
                    del v515
                    v517 = v516[0:].view(cp.int32)
                    del v516
                    v518 = v517[0].item()
                    del v517
                    if v518 == 0:
                        v523 = US5_0()
                    elif v518 == 1:
                        v523 = US5_1()
                    elif v518 == 2:
                        v523 = US5_2()
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
                v529 = v3[80:].view(cp.int32)
                v530 = v529[0].item()
                del v529
                v531 = [None] * 2
                v532 = 0
                while method17(v532):
                    v534 = u64(v532)
                    v535 = v534 * 4
                    del v534
                    v536 = 84 + v535
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
                v545 = v3[92:].view(cp.int32)
                v546 = v545[0].item()
                del v545
                v714 = US6_2(v507, v509, v510, v530, v531, v546)
            elif v439 == 3:
                v548 = v3[60:].view(cp.int32)
                v549 = v548[0].item()
                del v548
                if v549 == 0:
                    v560 = US4_0()
                elif v549 == 1:
                    v552 = v3[64:].view(cp.int32)
                    v553 = v552[0].item()
                    del v552
                    if v553 == 0:
                        v558 = US5_0()
                    elif v553 == 1:
                        v558 = US5_1()
                    elif v553 == 2:
                        v558 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v553
                    v560 = US4_1(v558)
                else:
                    raise Exception("Invalid tag.")
                del v549
                v561 = v3[68:].view(cp.int8)
                v562 = v561[0].item()
                del v561
                v563 = [None] * 2
                v564 = 0
                while method17(v564):
                    v566 = u64(v564)
                    v567 = v566 * 4
                    del v566
                    v568 = 72 + v567
                    del v567
                    v569 = v3[v568:].view(cp.uint8)
                    del v568
                    v570 = v569[0:].view(cp.int32)
                    del v569
                    v571 = v570[0].item()
                    del v570
                    if v571 == 0:
                        v576 = US5_0()
                    elif v571 == 1:
                        v576 = US5_1()
                    elif v571 == 2:
                        v576 = US5_2()
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
                v582 = v3[80:].view(cp.int32)
                v583 = v582[0].item()
                del v582
                v584 = [None] * 2
                v585 = 0
                while method17(v585):
                    v587 = u64(v585)
                    v588 = v587 * 4
                    del v587
                    v589 = 84 + v588
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
                v598 = v3[92:].view(cp.int32)
                v599 = v598[0].item()
                del v598
                v600 = v3[96:].view(cp.int32)
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
                v714 = US6_3(v560, v562, v563, v583, v584, v599, v606)
            elif v439 == 4:
                v608 = v3[60:].view(cp.int32)
                v609 = v608[0].item()
                del v608
                if v609 == 0:
                    v620 = US4_0()
                elif v609 == 1:
                    v612 = v3[64:].view(cp.int32)
                    v613 = v612[0].item()
                    del v612
                    if v613 == 0:
                        v618 = US5_0()
                    elif v613 == 1:
                        v618 = US5_1()
                    elif v613 == 2:
                        v618 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v613
                    v620 = US4_1(v618)
                else:
                    raise Exception("Invalid tag.")
                del v609
                v621 = v3[68:].view(cp.int8)
                v622 = v621[0].item()
                del v621
                v623 = [None] * 2
                v624 = 0
                while method17(v624):
                    v626 = u64(v624)
                    v627 = v626 * 4
                    del v626
                    v628 = 72 + v627
                    del v627
                    v629 = v3[v628:].view(cp.uint8)
                    del v628
                    v630 = v629[0:].view(cp.int32)
                    del v629
                    v631 = v630[0].item()
                    del v630
                    if v631 == 0:
                        v636 = US5_0()
                    elif v631 == 1:
                        v636 = US5_1()
                    elif v631 == 2:
                        v636 = US5_2()
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
                v642 = v3[80:].view(cp.int32)
                v643 = v642[0].item()
                del v642
                v644 = [None] * 2
                v645 = 0
                while method17(v645):
                    v647 = u64(v645)
                    v648 = v647 * 4
                    del v647
                    v649 = 84 + v648
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
                v658 = v3[92:].view(cp.int32)
                v659 = v658[0].item()
                del v658
                v714 = US6_4(v620, v622, v623, v643, v644, v659)
            elif v439 == 5:
                v661 = v3[60:].view(cp.int32)
                v662 = v661[0].item()
                del v661
                if v662 == 0:
                    v673 = US4_0()
                elif v662 == 1:
                    v665 = v3[64:].view(cp.int32)
                    v666 = v665[0].item()
                    del v665
                    if v666 == 0:
                        v671 = US5_0()
                    elif v666 == 1:
                        v671 = US5_1()
                    elif v666 == 2:
                        v671 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v666
                    v673 = US4_1(v671)
                else:
                    raise Exception("Invalid tag.")
                del v662
                v674 = v3[68:].view(cp.int8)
                v675 = v674[0].item()
                del v674
                v676 = [None] * 2
                v677 = 0
                while method17(v677):
                    v679 = u64(v677)
                    v680 = v679 * 4
                    del v679
                    v681 = 72 + v680
                    del v680
                    v682 = v3[v681:].view(cp.uint8)
                    del v681
                    v683 = v682[0:].view(cp.int32)
                    del v682
                    v684 = v683[0].item()
                    del v683
                    if v684 == 0:
                        v689 = US5_0()
                    elif v684 == 1:
                        v689 = US5_1()
                    elif v684 == 2:
                        v689 = US5_2()
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
                v695 = v3[80:].view(cp.int32)
                v696 = v695[0].item()
                del v695
                v697 = [None] * 2
                v698 = 0
                while method17(v698):
                    v700 = u64(v698)
                    v701 = v700 * 4
                    del v700
                    v702 = 84 + v701
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
                v711 = v3[92:].view(cp.int32)
                v712 = v711[0].item()
                del v711
                v714 = US6_5(v673, v675, v676, v696, v697, v712)
            else:
                raise Exception("Invalid tag.")
            del v439
            v716 = US3_1(v413, v714)
        else:
            raise Exception("Invalid tag.")
        del v410
        v717 = [None] * 32
        v718 = 0
        while method15(v718):
            v720 = u64(v718)
            v721 = v720 * 32
            del v720
            v722 = 112 + v721
            del v721
            v723 = v3[v722:].view(cp.uint8)
            del v722
            v724 = v723[0:].view(cp.int32)
            v725 = v724[0].item()
            del v724
            if v725 == 0:
                v785 = US7_0()
            elif v725 == 1:
                v728 = v723[4:].view(cp.int32)
                v729 = v728[0].item()
                del v728
                if v729 == 0:
                    v731 = v723[8:].view(cp.int32)
                    v732 = v731[0].item()
                    del v731
                    if v732 == 0:
                        v737 = US5_0()
                    elif v732 == 1:
                        v737 = US5_1()
                    elif v732 == 2:
                        v737 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v732
                    v783 = US8_0(v737)
                elif v729 == 1:
                    v739 = v723[8:].view(cp.int32)
                    v740 = v739[0].item()
                    del v739
                    v741 = v723[12:].view(cp.int32)
                    v742 = v741[0].item()
                    del v741
                    if v742 == 0:
                        v747 = US1_0()
                    elif v742 == 1:
                        v747 = US1_1()
                    elif v742 == 2:
                        v747 = US1_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v742
                    v783 = US8_1(v740, v747)
                elif v729 == 2:
                    v749 = v723[8:].view(cp.int32)
                    v750 = v749[0].item()
                    del v749
                    v751 = v723[12:].view(cp.int32)
                    v752 = v751[0].item()
                    del v751
                    if v752 == 0:
                        v757 = US5_0()
                    elif v752 == 1:
                        v757 = US5_1()
                    elif v752 == 2:
                        v757 = US5_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v752
                    v783 = US8_2(v750, v757)
                elif v729 == 3:
                    v759 = [None] * 2
                    v760 = 0
                    while method17(v760):
                        v762 = u64(v760)
                        v763 = v762 * 4
                        del v762
                        v764 = 8 + v763
                        del v763
                        v765 = v723[v764:].view(cp.uint8)
                        del v764
                        v766 = v765[0:].view(cp.int32)
                        del v765
                        v767 = v766[0].item()
                        del v766
                        if v767 == 0:
                            v772 = US5_0()
                        elif v767 == 1:
                            v772 = US5_1()
                        elif v767 == 2:
                            v772 = US5_2()
                        else:
                            raise Exception("Invalid tag.")
                        del v767
                        v773 = 0 <= v760
                        if v773:
                            v774 = v760 < 2
                            v775 = v774
                        else:
                            v775 = False
                        del v773
                        v776 = v775 == False
                        if v776:
                            v777 = "The read index needs to be in range."
                            assert v775, v777
                            del v777
                        else:
                            pass
                        del v775, v776
                        v759[v760] = v772
                        del v772
                        v760 += 1 
                    del v760
                    v778 = v723[16:].view(cp.int32)
                    v779 = v778[0].item()
                    del v778
                    v780 = v723[20:].view(cp.int32)
                    v781 = v780[0].item()
                    del v780
                    v783 = US8_3(v759, v779, v781)
                else:
                    raise Exception("Invalid tag.")
                del v729
                v785 = US7_1(v783)
            else:
                raise Exception("Invalid tag.")
            del v723, v725
            v786 = 0 <= v718
            if v786:
                v787 = v718 < 32
                v788 = v787
            else:
                v788 = False
            del v786
            v789 = v788 == False
            if v789:
                v790 = "The read index needs to be in range."
                assert v788, v790
                del v790
            else:
                pass
            del v788, v789
            v717[v718] = v785
            del v785
            v718 += 1 
        del v718
        v791 = [None] * 2
        v792 = 0
        while method17(v792):
            v794 = u64(v792)
            v795 = v794 * 4
            del v794
            v796 = 1136 + v795
            del v795
            v797 = v3[v796:].view(cp.uint8)
            del v796
            v798 = v797[0:].view(cp.int32)
            del v797
            v799 = v798[0].item()
            del v798
            if v799 == 0:
                v803 = US2_0()
            elif v799 == 1:
                v803 = US2_1()
            else:
                raise Exception("Invalid tag.")
            del v799
            v804 = 0 <= v792
            if v804:
                v805 = v792 < 2
                v806 = v805
            else:
                v806 = False
            del v804
            v807 = v806 == False
            if v807:
                v808 = "The read index needs to be in range."
                assert v806, v808
                del v808
            else:
                pass
            del v806, v807
            v791[v792] = v803
            del v803
            v792 += 1 
        del v792
        v809 = v3[1144:].view(cp.int32)
        v810 = v809[0].item()
        del v809
        if v810 == 0:
            v919 = US9_0()
        elif v810 == 1:
            v813 = v3[1148:].view(cp.int32)
            v814 = v813[0].item()
            del v813
            if v814 == 0:
                v825 = US4_0()
            elif v814 == 1:
                v817 = v3[1152:].view(cp.int32)
                v818 = v817[0].item()
                del v817
                if v818 == 0:
                    v823 = US5_0()
                elif v818 == 1:
                    v823 = US5_1()
                elif v818 == 2:
                    v823 = US5_2()
                else:
                    raise Exception("Invalid tag.")
                del v818
                v825 = US4_1(v823)
            else:
                raise Exception("Invalid tag.")
            del v814
            v826 = v3[1156:].view(cp.int8)
            v827 = v826[0].item()
            del v826
            v828 = [None] * 2
            v829 = 0
            while method17(v829):
                v831 = u64(v829)
                v832 = v831 * 4
                del v831
                v833 = 1160 + v832
                del v832
                v834 = v3[v833:].view(cp.uint8)
                del v833
                v835 = v834[0:].view(cp.int32)
                del v834
                v836 = v835[0].item()
                del v835
                if v836 == 0:
                    v841 = US5_0()
                elif v836 == 1:
                    v841 = US5_1()
                elif v836 == 2:
                    v841 = US5_2()
                else:
                    raise Exception("Invalid tag.")
                del v836
                v842 = 0 <= v829
                if v842:
                    v843 = v829 < 2
                    v844 = v843
                else:
                    v844 = False
                del v842
                v845 = v844 == False
                if v845:
                    v846 = "The read index needs to be in range."
                    assert v844, v846
                    del v846
                else:
                    pass
                del v844, v845
                v828[v829] = v841
                del v841
                v829 += 1 
            del v829
            v847 = v3[1168:].view(cp.int32)
            v848 = v847[0].item()
            del v847
            v849 = [None] * 2
            v850 = 0
            while method17(v850):
                v852 = u64(v850)
                v853 = v852 * 4
                del v852
                v854 = 1172 + v853
                del v853
                v855 = v3[v854:].view(cp.uint8)
                del v854
                v856 = v855[0:].view(cp.int32)
                del v855
                v857 = v856[0].item()
                del v856
                v858 = 0 <= v850
                if v858:
                    v859 = v850 < 2
                    v860 = v859
                else:
                    v860 = False
                del v858
                v861 = v860 == False
                if v861:
                    v862 = "The read index needs to be in range."
                    assert v860, v862
                    del v862
                else:
                    pass
                del v860, v861
                v849[v850] = v857
                del v857
                v850 += 1 
            del v850
            v863 = v3[1180:].view(cp.int32)
            v864 = v863[0].item()
            del v863
            v919 = US9_1(v825, v827, v828, v848, v849, v864)
        elif v810 == 2:
            v866 = v3[1148:].view(cp.int32)
            v867 = v866[0].item()
            del v866
            if v867 == 0:
                v878 = US4_0()
            elif v867 == 1:
                v870 = v3[1152:].view(cp.int32)
                v871 = v870[0].item()
                del v870
                if v871 == 0:
                    v876 = US5_0()
                elif v871 == 1:
                    v876 = US5_1()
                elif v871 == 2:
                    v876 = US5_2()
                else:
                    raise Exception("Invalid tag.")
                del v871
                v878 = US4_1(v876)
            else:
                raise Exception("Invalid tag.")
            del v867
            v879 = v3[1156:].view(cp.int8)
            v880 = v879[0].item()
            del v879
            v881 = [None] * 2
            v882 = 0
            while method17(v882):
                v884 = u64(v882)
                v885 = v884 * 4
                del v884
                v886 = 1160 + v885
                del v885
                v887 = v3[v886:].view(cp.uint8)
                del v886
                v888 = v887[0:].view(cp.int32)
                del v887
                v889 = v888[0].item()
                del v888
                if v889 == 0:
                    v894 = US5_0()
                elif v889 == 1:
                    v894 = US5_1()
                elif v889 == 2:
                    v894 = US5_2()
                else:
                    raise Exception("Invalid tag.")
                del v889
                v895 = 0 <= v882
                if v895:
                    v896 = v882 < 2
                    v897 = v896
                else:
                    v897 = False
                del v895
                v898 = v897 == False
                if v898:
                    v899 = "The read index needs to be in range."
                    assert v897, v899
                    del v899
                else:
                    pass
                del v897, v898
                v881[v882] = v894
                del v894
                v882 += 1 
            del v882
            v900 = v3[1168:].view(cp.int32)
            v901 = v900[0].item()
            del v900
            v902 = [None] * 2
            v903 = 0
            while method17(v903):
                v905 = u64(v903)
                v906 = v905 * 4
                del v905
                v907 = 1172 + v906
                del v906
                v908 = v3[v907:].view(cp.uint8)
                del v907
                v909 = v908[0:].view(cp.int32)
                del v908
                v910 = v909[0].item()
                del v909
                v911 = 0 <= v903
                if v911:
                    v912 = v903 < 2
                    v913 = v912
                else:
                    v913 = False
                del v911
                v914 = v913 == False
                if v914:
                    v915 = "The read index needs to be in range."
                    assert v913, v915
                    del v915
                else:
                    pass
                del v913, v914
                v902[v903] = v910
                del v910
                v903 += 1 
            del v903
            v916 = v3[1180:].view(cp.int32)
            v917 = v916[0].item()
            del v916
            v919 = US9_2(v878, v880, v881, v901, v902, v917)
        else:
            raise Exception("Invalid tag.")
        del v3, v810
        return method22(v716, v717, v791, v919)
    return inner
def Closure2():
    def inner() -> object:
        v0 = [None] * 2
        v1 = US2_0()
        v0[0] = v1
        del v1
        v2 = US2_1()
        v0[1] = v2
        del v2
        v3 = [None] * 32
        v4 = 0
        while method15(v4):
            v6 = 0 <= v4
            if v6:
                v7 = v4 < 32
                v8 = v7
            else:
                v8 = False
            del v6
            v9 = v8 == False
            if v9:
                v10 = "The read index needs to be in range."
                assert v8, v10
                del v10
            else:
                pass
            del v8, v9
            v11 = US7_0()
            v3[v4] = v11
            del v11
            v4 += 1 
        del v4
        v12 = US3_0()
        v13 = US9_0()
        return method22(v12, v3, v0, v13)
    return inner
def method2(v0 : object) -> US1:
    v1 = v0[0]
    v2 = v0[1]
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
    v1 = v0[0]
    v2 = v0[1]
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
    v1 = v0[0]
    v2 = v0[1]
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
            v13 = [None] * 2
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
def method8(v0 : object) -> US5:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US5_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US5_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US5_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method7(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method8(v2)
            del v2
            return US4_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method9(v0 : object) -> US6:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5 = "community_card"
        v6 = v2[v5]
        del v5
        v7 = method7(v6)
        del v6
        v8 = "is_button_s_first_move"
        v9 = v2[v8]
        del v8
        assert isinstance(v9,bool), f'The object needs to be the right primitive type. Got: {v9}'
        v10 = v9
        del v9
        v11 = "pl_card"
        v12 = v2[v11]
        del v11
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
        v17 = [None] * 2
        v18 = 0
        while method3(v13, v18):
            v20 = v12[v18]
            v21 = method8(v20)
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
        v27 = "player_turn"
        v28 = v2[v27]
        del v27
        assert isinstance(v28,i32), f'The object needs to be the right primitive type. Got: {v28}'
        v29 = v28
        del v28
        v30 = "pot"
        v31 = v2[v30]
        del v30
        assert isinstance(v31,list), f'The object needs to be a Python list. Got: {v31}'
        v32 = len(v31)
        v33 = 2 == v32
        v34 = v33 == False
        if v34:
            v35 = "The type level dimension has to equal the value passed at runtime into create."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        v36 = [None] * 2
        v37 = 0
        while method3(v32, v37):
            v39 = v31[v37]
            assert isinstance(v39,i32), f'The object needs to be the right primitive type. Got: {v39}'
            v40 = v39
            del v39
            v41 = 0 <= v37
            if v41:
                v42 = v37 < 2
                v43 = v42
            else:
                v43 = False
            del v41
            v44 = v43 == False
            if v44:
                v45 = "The read index needs to be in range."
                assert v43, v45
                del v45
            else:
                pass
            del v43, v44
            v36[v37] = v40
            del v40
            v37 += 1 
        del v31, v32, v37
        v46 = "raises_left"
        v47 = v2[v46]
        del v2, v46
        assert isinstance(v47,i32), f'The object needs to be the right primitive type. Got: {v47}'
        v48 = v47
        del v47
        return US6_0(v7, v10, v17, v29, v36, v48)
    else:
        del v4
        v51 = "ChanceInit" == v1
        if v51:
            del v1, v51
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US6_1()
        else:
            del v51
            v54 = "Round" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method7(v56)
                del v56
                v58 = "is_button_s_first_move"
                v59 = v2[v58]
                del v58
                assert isinstance(v59,bool), f'The object needs to be the right primitive type. Got: {v59}'
                v60 = v59
                del v59
                v61 = "pl_card"
                v62 = v2[v61]
                del v61
                assert isinstance(v62,list), f'The object needs to be a Python list. Got: {v62}'
                v63 = len(v62)
                v64 = 2 == v63
                v65 = v64 == False
                if v65:
                    v66 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v64, v66
                    del v66
                else:
                    pass
                del v64, v65
                v67 = [None] * 2
                v68 = 0
                while method3(v63, v68):
                    v70 = v62[v68]
                    v71 = method8(v70)
                    del v70
                    v72 = 0 <= v68
                    if v72:
                        v73 = v68 < 2
                        v74 = v73
                    else:
                        v74 = False
                    del v72
                    v75 = v74 == False
                    if v75:
                        v76 = "The read index needs to be in range."
                        assert v74, v76
                        del v76
                    else:
                        pass
                    del v74, v75
                    v67[v68] = v71
                    del v71
                    v68 += 1 
                del v62, v63, v68
                v77 = "player_turn"
                v78 = v2[v77]
                del v77
                assert isinstance(v78,i32), f'The object needs to be the right primitive type. Got: {v78}'
                v79 = v78
                del v78
                v80 = "pot"
                v81 = v2[v80]
                del v80
                assert isinstance(v81,list), f'The object needs to be a Python list. Got: {v81}'
                v82 = len(v81)
                v83 = 2 == v82
                v84 = v83 == False
                if v84:
                    v85 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v83, v85
                    del v85
                else:
                    pass
                del v83, v84
                v86 = [None] * 2
                v87 = 0
                while method3(v82, v87):
                    v89 = v81[v87]
                    assert isinstance(v89,i32), f'The object needs to be the right primitive type. Got: {v89}'
                    v90 = v89
                    del v89
                    v91 = 0 <= v87
                    if v91:
                        v92 = v87 < 2
                        v93 = v92
                    else:
                        v93 = False
                    del v91
                    v94 = v93 == False
                    if v94:
                        v95 = "The read index needs to be in range."
                        assert v93, v95
                        del v95
                    else:
                        pass
                    del v93, v94
                    v86[v87] = v90
                    del v90
                    v87 += 1 
                del v81, v82, v87
                v96 = "raises_left"
                v97 = v2[v96]
                del v2, v96
                assert isinstance(v97,i32), f'The object needs to be the right primitive type. Got: {v97}'
                v98 = v97
                del v97
                return US6_2(v57, v60, v67, v79, v86, v98)
            else:
                del v54
                v101 = "RoundWithAction" == v1
                if v101:
                    del v1, v101
                    v102 = v2[0]
                    v103 = "community_card"
                    v104 = v102[v103]
                    del v103
                    v105 = method7(v104)
                    del v104
                    v106 = "is_button_s_first_move"
                    v107 = v102[v106]
                    del v106
                    assert isinstance(v107,bool), f'The object needs to be the right primitive type. Got: {v107}'
                    v108 = v107
                    del v107
                    v109 = "pl_card"
                    v110 = v102[v109]
                    del v109
                    assert isinstance(v110,list), f'The object needs to be a Python list. Got: {v110}'
                    v111 = len(v110)
                    v112 = 2 == v111
                    v113 = v112 == False
                    if v113:
                        v114 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v112, v114
                        del v114
                    else:
                        pass
                    del v112, v113
                    v115 = [None] * 2
                    v116 = 0
                    while method3(v111, v116):
                        v118 = v110[v116]
                        v119 = method8(v118)
                        del v118
                        v120 = 0 <= v116
                        if v120:
                            v121 = v116 < 2
                            v122 = v121
                        else:
                            v122 = False
                        del v120
                        v123 = v122 == False
                        if v123:
                            v124 = "The read index needs to be in range."
                            assert v122, v124
                            del v124
                        else:
                            pass
                        del v122, v123
                        v115[v116] = v119
                        del v119
                        v116 += 1 
                    del v110, v111, v116
                    v125 = "player_turn"
                    v126 = v102[v125]
                    del v125
                    assert isinstance(v126,i32), f'The object needs to be the right primitive type. Got: {v126}'
                    v127 = v126
                    del v126
                    v128 = "pot"
                    v129 = v102[v128]
                    del v128
                    assert isinstance(v129,list), f'The object needs to be a Python list. Got: {v129}'
                    v130 = len(v129)
                    v131 = 2 == v130
                    v132 = v131 == False
                    if v132:
                        v133 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v131, v133
                        del v133
                    else:
                        pass
                    del v131, v132
                    v134 = [None] * 2
                    v135 = 0
                    while method3(v130, v135):
                        v137 = v129[v135]
                        assert isinstance(v137,i32), f'The object needs to be the right primitive type. Got: {v137}'
                        v138 = v137
                        del v137
                        v139 = 0 <= v135
                        if v139:
                            v140 = v135 < 2
                            v141 = v140
                        else:
                            v141 = False
                        del v139
                        v142 = v141 == False
                        if v142:
                            v143 = "The read index needs to be in range."
                            assert v141, v143
                            del v143
                        else:
                            pass
                        del v141, v142
                        v134[v135] = v138
                        del v138
                        v135 += 1 
                    del v129, v130, v135
                    v144 = "raises_left"
                    v145 = v102[v144]
                    del v102, v144
                    assert isinstance(v145,i32), f'The object needs to be the right primitive type. Got: {v145}'
                    v146 = v145
                    del v145
                    v147 = v2[1]
                    del v2
                    v148 = method2(v147)
                    del v147
                    return US6_3(v105, v108, v115, v127, v134, v146, v148)
                else:
                    del v101
                    v151 = "TerminalCall" == v1
                    if v151:
                        del v1, v151
                        v152 = "community_card"
                        v153 = v2[v152]
                        del v152
                        v154 = method7(v153)
                        del v153
                        v155 = "is_button_s_first_move"
                        v156 = v2[v155]
                        del v155
                        assert isinstance(v156,bool), f'The object needs to be the right primitive type. Got: {v156}'
                        v157 = v156
                        del v156
                        v158 = "pl_card"
                        v159 = v2[v158]
                        del v158
                        assert isinstance(v159,list), f'The object needs to be a Python list. Got: {v159}'
                        v160 = len(v159)
                        v161 = 2 == v160
                        v162 = v161 == False
                        if v162:
                            v163 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v161, v163
                            del v163
                        else:
                            pass
                        del v161, v162
                        v164 = [None] * 2
                        v165 = 0
                        while method3(v160, v165):
                            v167 = v159[v165]
                            v168 = method8(v167)
                            del v167
                            v169 = 0 <= v165
                            if v169:
                                v170 = v165 < 2
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
                            v164[v165] = v168
                            del v168
                            v165 += 1 
                        del v159, v160, v165
                        v174 = "player_turn"
                        v175 = v2[v174]
                        del v174
                        assert isinstance(v175,i32), f'The object needs to be the right primitive type. Got: {v175}'
                        v176 = v175
                        del v175
                        v177 = "pot"
                        v178 = v2[v177]
                        del v177
                        assert isinstance(v178,list), f'The object needs to be a Python list. Got: {v178}'
                        v179 = len(v178)
                        v180 = 2 == v179
                        v181 = v180 == False
                        if v181:
                            v182 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v180, v182
                            del v182
                        else:
                            pass
                        del v180, v181
                        v183 = [None] * 2
                        v184 = 0
                        while method3(v179, v184):
                            v186 = v178[v184]
                            assert isinstance(v186,i32), f'The object needs to be the right primitive type. Got: {v186}'
                            v187 = v186
                            del v186
                            v188 = 0 <= v184
                            if v188:
                                v189 = v184 < 2
                                v190 = v189
                            else:
                                v190 = False
                            del v188
                            v191 = v190 == False
                            if v191:
                                v192 = "The read index needs to be in range."
                                assert v190, v192
                                del v192
                            else:
                                pass
                            del v190, v191
                            v183[v184] = v187
                            del v187
                            v184 += 1 
                        del v178, v179, v184
                        v193 = "raises_left"
                        v194 = v2[v193]
                        del v2, v193
                        assert isinstance(v194,i32), f'The object needs to be the right primitive type. Got: {v194}'
                        v195 = v194
                        del v194
                        return US6_4(v154, v157, v164, v176, v183, v195)
                    else:
                        del v151
                        v198 = "TerminalFold" == v1
                        if v198:
                            del v1, v198
                            v199 = "community_card"
                            v200 = v2[v199]
                            del v199
                            v201 = method7(v200)
                            del v200
                            v202 = "is_button_s_first_move"
                            v203 = v2[v202]
                            del v202
                            assert isinstance(v203,bool), f'The object needs to be the right primitive type. Got: {v203}'
                            v204 = v203
                            del v203
                            v205 = "pl_card"
                            v206 = v2[v205]
                            del v205
                            assert isinstance(v206,list), f'The object needs to be a Python list. Got: {v206}'
                            v207 = len(v206)
                            v208 = 2 == v207
                            v209 = v208 == False
                            if v209:
                                v210 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v208, v210
                                del v210
                            else:
                                pass
                            del v208, v209
                            v211 = [None] * 2
                            v212 = 0
                            while method3(v207, v212):
                                v214 = v206[v212]
                                v215 = method8(v214)
                                del v214
                                v216 = 0 <= v212
                                if v216:
                                    v217 = v212 < 2
                                    v218 = v217
                                else:
                                    v218 = False
                                del v216
                                v219 = v218 == False
                                if v219:
                                    v220 = "The read index needs to be in range."
                                    assert v218, v220
                                    del v220
                                else:
                                    pass
                                del v218, v219
                                v211[v212] = v215
                                del v215
                                v212 += 1 
                            del v206, v207, v212
                            v221 = "player_turn"
                            v222 = v2[v221]
                            del v221
                            assert isinstance(v222,i32), f'The object needs to be the right primitive type. Got: {v222}'
                            v223 = v222
                            del v222
                            v224 = "pot"
                            v225 = v2[v224]
                            del v224
                            assert isinstance(v225,list), f'The object needs to be a Python list. Got: {v225}'
                            v226 = len(v225)
                            v227 = 2 == v226
                            v228 = v227 == False
                            if v228:
                                v229 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v227, v229
                                del v229
                            else:
                                pass
                            del v227, v228
                            v230 = [None] * 2
                            v231 = 0
                            while method3(v226, v231):
                                v233 = v225[v231]
                                assert isinstance(v233,i32), f'The object needs to be the right primitive type. Got: {v233}'
                                v234 = v233
                                del v233
                                v235 = 0 <= v231
                                if v235:
                                    v236 = v231 < 2
                                    v237 = v236
                                else:
                                    v237 = False
                                del v235
                                v238 = v237 == False
                                if v238:
                                    v239 = "The read index needs to be in range."
                                    assert v237, v239
                                    del v239
                                else:
                                    pass
                                del v237, v238
                                v230[v231] = v234
                                del v234
                                v231 += 1 
                            del v225, v226, v231
                            v240 = "raises_left"
                            v241 = v2[v240]
                            del v2, v240
                            assert isinstance(v241,i32), f'The object needs to be the right primitive type. Got: {v241}'
                            v242 = v241
                            del v241
                            return US6_5(v201, v204, v211, v223, v230, v242)
                        else:
                            del v2, v198
                            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                            del v1
                            raise Exception("Error")
def method6(v0 : object) -> US3:
    v1 = v0[0]
    v2 = v0[1]
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
            v8 = "deck"
            v9 = v2[v8]
            del v8
            assert isinstance(v9,list), f'The object needs to be a Python list. Got: {v9}'
            v10 = len(v9)
            v11 = 6 == v10
            v12 = v11 == False
            if v12:
                v13 = "The type level dimension has to equal the value passed at runtime into create."
                assert v11, v13
                del v13
            else:
                pass
            del v11, v12
            v14 = [None] * 6
            v15 = 0
            while method3(v10, v15):
                v17 = v9[v15]
                v18 = method7(v17)
                del v17
                v19 = 0 <= v15
                if v19:
                    v20 = v15 < 6
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
            v24 = "game"
            v25 = v2[v24]
            del v2, v24
            v26 = method9(v25)
            del v25
            return US3_1(v14, v26)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method11(v0 : object) -> US8:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method8(v2)
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
                v19 = method8(v18)
                del v18
                return US8_2(v17, v19)
            else:
                del v15
                v22 = "Showdown" == v1
                if v22:
                    del v1, v22
                    v23 = "cards_shown"
                    v24 = v2[v23]
                    del v23
                    assert isinstance(v24,list), f'The object needs to be a Python list. Got: {v24}'
                    v25 = len(v24)
                    v26 = 2 == v25
                    v27 = v26 == False
                    if v27:
                        v28 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v26, v28
                        del v28
                    else:
                        pass
                    del v26, v27
                    v29 = [None] * 2
                    v30 = 0
                    while method3(v25, v30):
                        v32 = v24[v30]
                        v33 = method8(v32)
                        del v32
                        v34 = 0 <= v30
                        if v34:
                            v35 = v30 < 2
                            v36 = v35
                        else:
                            v36 = False
                        del v34
                        v37 = v36 == False
                        if v37:
                            v38 = "The read index needs to be in range."
                            assert v36, v38
                            del v38
                        else:
                            pass
                        del v36, v37
                        v29[v30] = v33
                        del v33
                        v30 += 1 
                    del v24, v25, v30
                    v39 = "chips_won"
                    v40 = v2[v39]
                    del v39
                    assert isinstance(v40,i32), f'The object needs to be the right primitive type. Got: {v40}'
                    v41 = v40
                    del v40
                    v42 = "winner_id"
                    v43 = v2[v42]
                    del v2, v42
                    assert isinstance(v43,i32), f'The object needs to be the right primitive type. Got: {v43}'
                    v44 = v43
                    del v43
                    return US8_3(v29, v41, v44)
                else:
                    del v2, v22
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method10(v0 : object) -> US7:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US7_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method11(v2)
            del v2
            return US7_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method12(v0 : object) -> US9:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US9_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = "community_card"
            v9 = v2[v8]
            del v8
            v10 = method7(v9)
            del v9
            v11 = "is_button_s_first_move"
            v12 = v2[v11]
            del v11
            assert isinstance(v12,bool), f'The object needs to be the right primitive type. Got: {v12}'
            v13 = v12
            del v12
            v14 = "pl_card"
            v15 = v2[v14]
            del v14
            assert isinstance(v15,list), f'The object needs to be a Python list. Got: {v15}'
            v16 = len(v15)
            v17 = 2 == v16
            v18 = v17 == False
            if v18:
                v19 = "The type level dimension has to equal the value passed at runtime into create."
                assert v17, v19
                del v19
            else:
                pass
            del v17, v18
            v20 = [None] * 2
            v21 = 0
            while method3(v16, v21):
                v23 = v15[v21]
                v24 = method8(v23)
                del v23
                v25 = 0 <= v21
                if v25:
                    v26 = v21 < 2
                    v27 = v26
                else:
                    v27 = False
                del v25
                v28 = v27 == False
                if v28:
                    v29 = "The read index needs to be in range."
                    assert v27, v29
                    del v29
                else:
                    pass
                del v27, v28
                v20[v21] = v24
                del v24
                v21 += 1 
            del v15, v16, v21
            v30 = "player_turn"
            v31 = v2[v30]
            del v30
            assert isinstance(v31,i32), f'The object needs to be the right primitive type. Got: {v31}'
            v32 = v31
            del v31
            v33 = "pot"
            v34 = v2[v33]
            del v33
            assert isinstance(v34,list), f'The object needs to be a Python list. Got: {v34}'
            v35 = len(v34)
            v36 = 2 == v35
            v37 = v36 == False
            if v37:
                v38 = "The type level dimension has to equal the value passed at runtime into create."
                assert v36, v38
                del v38
            else:
                pass
            del v36, v37
            v39 = [None] * 2
            v40 = 0
            while method3(v35, v40):
                v42 = v34[v40]
                assert isinstance(v42,i32), f'The object needs to be the right primitive type. Got: {v42}'
                v43 = v42
                del v42
                v44 = 0 <= v40
                if v44:
                    v45 = v40 < 2
                    v46 = v45
                else:
                    v46 = False
                del v44
                v47 = v46 == False
                if v47:
                    v48 = "The read index needs to be in range."
                    assert v46, v48
                    del v48
                else:
                    pass
                del v46, v47
                v39[v40] = v43
                del v43
                v40 += 1 
            del v34, v35, v40
            v49 = "raises_left"
            v50 = v2[v49]
            del v2, v49
            assert isinstance(v50,i32), f'The object needs to be the right primitive type. Got: {v50}'
            v51 = v50
            del v50
            return US9_1(v10, v13, v20, v32, v39, v51)
        else:
            del v7
            v54 = "WaitingForActionFromPlayerId" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method7(v56)
                del v56
                v58 = "is_button_s_first_move"
                v59 = v2[v58]
                del v58
                assert isinstance(v59,bool), f'The object needs to be the right primitive type. Got: {v59}'
                v60 = v59
                del v59
                v61 = "pl_card"
                v62 = v2[v61]
                del v61
                assert isinstance(v62,list), f'The object needs to be a Python list. Got: {v62}'
                v63 = len(v62)
                v64 = 2 == v63
                v65 = v64 == False
                if v65:
                    v66 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v64, v66
                    del v66
                else:
                    pass
                del v64, v65
                v67 = [None] * 2
                v68 = 0
                while method3(v63, v68):
                    v70 = v62[v68]
                    v71 = method8(v70)
                    del v70
                    v72 = 0 <= v68
                    if v72:
                        v73 = v68 < 2
                        v74 = v73
                    else:
                        v74 = False
                    del v72
                    v75 = v74 == False
                    if v75:
                        v76 = "The read index needs to be in range."
                        assert v74, v76
                        del v76
                    else:
                        pass
                    del v74, v75
                    v67[v68] = v71
                    del v71
                    v68 += 1 
                del v62, v63, v68
                v77 = "player_turn"
                v78 = v2[v77]
                del v77
                assert isinstance(v78,i32), f'The object needs to be the right primitive type. Got: {v78}'
                v79 = v78
                del v78
                v80 = "pot"
                v81 = v2[v80]
                del v80
                assert isinstance(v81,list), f'The object needs to be a Python list. Got: {v81}'
                v82 = len(v81)
                v83 = 2 == v82
                v84 = v83 == False
                if v84:
                    v85 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v83, v85
                    del v85
                else:
                    pass
                del v83, v84
                v86 = [None] * 2
                v87 = 0
                while method3(v82, v87):
                    v89 = v81[v87]
                    assert isinstance(v89,i32), f'The object needs to be the right primitive type. Got: {v89}'
                    v90 = v89
                    del v89
                    v91 = 0 <= v87
                    if v91:
                        v92 = v87 < 2
                        v93 = v92
                    else:
                        v93 = False
                    del v91
                    v94 = v93 == False
                    if v94:
                        v95 = "The read index needs to be in range."
                        assert v93, v95
                        del v95
                    else:
                        pass
                    del v93, v94
                    v86[v87] = v90
                    del v90
                    v87 += 1 
                del v81, v82, v87
                v96 = "raises_left"
                v97 = v2[v96]
                del v2, v96
                assert isinstance(v97,i32), f'The object needs to be the right primitive type. Got: {v97}'
                v98 = v97
                del v97
                return US9_2(v57, v60, v67, v79, v86, v98)
            else:
                del v2, v54
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : object) -> Tuple[US3, list[US7], list[US2], US9]:
    v1 = "game_state"
    v2 = v0[v1]
    del v1
    v3 = method6(v2)
    del v2
    v4 = "ui_state"
    v5 = v0[v4]
    del v0, v4
    v6 = "messages"
    v7 = v5[v6]
    del v6
    assert isinstance(v7,list), f'The object needs to be a Python list. Got: {v7}'
    v8 = len(v7)
    v9 = 32 == v8
    v10 = v9 == False
    if v10:
        v11 = "The type level dimension has to equal the value passed at runtime into create."
        assert v9, v11
        del v11
    else:
        pass
    del v9, v10
    v12 = [None] * 32
    v13 = 0
    while method3(v8, v13):
        v15 = v7[v13]
        v16 = method10(v15)
        del v15
        v17 = 0 <= v13
        if v17:
            v18 = v13 < 32
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v12[v13] = v16
        del v16
        v13 += 1 
    del v7, v8, v13
    v22 = "pl_type"
    v23 = v5[v22]
    del v22
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
    v28 = [None] * 2
    v29 = 0
    while method3(v24, v29):
        v31 = v23[v29]
        v32 = method4(v31)
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
    v38 = "ui_game_state"
    v39 = v5[v38]
    del v5, v38
    v40 = method12(v39)
    del v39
    return v3, v12, v28, v40
def method13(v0 : i32) -> bool:
    v1 = v0 < 6
    del v0
    return v1
def method15(v0 : i32) -> bool:
    v1 = v0 < 32
    del v0
    return v1
def method17(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method19(v0 : US5) -> i32:
    match v0:
        case US5_0(): # Jack
            del v0
            return 0
        case US5_1(): # King
            del v0
            return 2
        case US5_2(): # Queen
            del v0
            return 1
        case _:
            raise Exception('Pattern matching miss.')
def method20(v0 : i32, v1 : i32) -> bool:
    v2 = v1 == v0
    del v0, v1
    return v2
def method21(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    v2 = v1 > v0
    if v2:
        del v2
        return v1, v0
    else:
        del v2
        return v0, v1
def method18(v0 : US4, v1 : bool, v2 : list[US5], v3 : i32, v4 : list[i32], v5 : i32) -> US10:
    del v1, v3, v4, v5
    match v0:
        case US4_0(): # None
            del v0, v2
            raise Exception("Expected the community card to be present in the table.")
        case US4_1(v7): # Some
            del v0
            v8 = method19(v7)
            del v7
            v9 = v2[0]
            v10 = method19(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method19(v11)
            del v11
            v13 = method20(v8, v10)
            v14 = method20(v8, v12)
            if v13:
                del v8, v13
                if v14:
                    del v14
                    v15 = v10 < v12
                    if v15:
                        del v10, v12, v15
                        return US10_2()
                    else:
                        del v15
                        v17 = v10 > v12
                        del v10, v12
                        if v17:
                            del v17
                            return US10_1()
                        else:
                            del v17
                            return US10_0()
                else:
                    del v10, v12, v14
                    return US10_1()
            else:
                del v13
                if v14:
                    del v8, v10, v12, v14
                    return US10_2()
                else:
                    del v14
                    v25, v26 = method21(v8, v10)
                    del v10
                    v27, v28 = method21(v8, v12)
                    del v8, v12
                    v29 = v25 < v27
                    if v29:
                        v35 = US10_2()
                    else:
                        v31 = v25 > v27
                        if v31:
                            del v31
                            v35 = US10_1()
                        else:
                            del v31
                            v35 = US10_0()
                    del v25, v27, v29
                    match v35:
                        case US10_0(): # Eq
                            v36 = True
                        case _:
                            v36 = False
                    if v36:
                        del v35, v36
                        v37 = v26 < v28
                        if v37:
                            del v26, v28, v37
                            return US10_2()
                        else:
                            del v37
                            v39 = v26 > v28
                            del v26, v28
                            if v39:
                                del v39
                                return US10_1()
                            else:
                                del v39
                                return US10_0()
                    else:
                        del v26, v28, v36
                        return v35
        case _:
            raise Exception('Pattern matching miss.')
def method16(v0 : list[US5], v1 : list, v2 : list[US8], v3 : list, v4 : list[US2], v5 : US6) -> US6:
    match v5:
        case US6_0(_, _, v418, _, v420, _): # ChanceCommunityCard
            del v5
            v422 = v1[0]
            v423 = v422 - 1
            del v422
            v424 = 0 <= v423
            if v424:
                v425 = v1[0]
                v426 = v423 < v425
                del v425
                v427 = v426
            else:
                v427 = False
            v428 = v427 == False
            if v428:
                v429 = "The read index needs to be in range."
                assert v427, v429
                del v429
            else:
                pass
            del v427, v428
            if v424:
                v430 = v423 < 6
                v431 = v430
            else:
                v431 = False
            del v424
            v432 = v431 == False
            if v432:
                v433 = "The read index needs to be in range."
                assert v431, v433
                del v433
            else:
                pass
            del v431, v432
            v434 = v0[v423]
            v435 = v1[0]
            del v435
            v1[0] = v423
            del v423
            v436 = v3[0]
            v437 = 1 + v436
            v3[0] = v437
            del v437
            v438 = 0 <= v436
            if v438:
                v439 = v3[0]
                v440 = v436 < v439
                del v439
                v441 = v440
            else:
                v441 = False
            v442 = v441 == False
            if v442:
                v443 = "The set index needs to be in range."
                assert v441, v443
                del v443
            else:
                pass
            del v441, v442
            if v438:
                v444 = v436 < 32
                v445 = v444
            else:
                v445 = False
            del v438
            v446 = v445 == False
            if v446:
                v447 = "The read index needs to be in range."
                assert v445, v447
                del v447
            else:
                pass
            del v445, v446
            v448 = US8_0(v434)
            v2[v436] = v448
            del v436, v448
            v449 = 2
            v450, v451 = (0, 0)
            while method17(v450):
                v453 = 0 <= v450
                if v453:
                    v454 = v450 < 2
                    v455 = v454
                else:
                    v455 = False
                del v453
                v456 = v455 == False
                if v456:
                    v457 = "The read index needs to be in range."
                    assert v455, v457
                    del v457
                else:
                    pass
                del v455, v456
                v458 = v420[v450]
                v459 = v451 >= v458
                if v459:
                    v460 = v451
                else:
                    v460 = v458
                del v458, v459
                v451 = v460
                del v460
                v450 += 1 
            del v420, v450
            v461 = [None] * 2
            v462 = 0
            while method17(v462):
                v464 = 0 <= v462
                if v464:
                    v465 = v462 < 2
                    v466 = v465
                else:
                    v466 = False
                del v464
                v467 = v466 == False
                if v467:
                    v468 = "The read index needs to be in range."
                    assert v466, v468
                    del v468
                else:
                    pass
                del v466, v467
                v461[v462] = v451
                v462 += 1 
            del v451, v462
            v469 = US4_1(v434)
            del v434
            v470 = True
            v471 = 0
            v472 = US6_2(v469, v470, v418, v471, v461, v449)
            del v418, v449, v461, v469, v470, v471
            return method16(v0, v1, v2, v3, v4, v472)
        case US6_1(): # ChanceInit
            del v5
            v474 = v1[0]
            v475 = v474 - 1
            del v474
            v476 = 0 <= v475
            if v476:
                v477 = v1[0]
                v478 = v475 < v477
                del v477
                v479 = v478
            else:
                v479 = False
            v480 = v479 == False
            if v480:
                v481 = "The read index needs to be in range."
                assert v479, v481
                del v481
            else:
                pass
            del v479, v480
            if v476:
                v482 = v475 < 6
                v483 = v482
            else:
                v483 = False
            del v476
            v484 = v483 == False
            if v484:
                v485 = "The read index needs to be in range."
                assert v483, v485
                del v485
            else:
                pass
            del v483, v484
            v486 = v0[v475]
            v487 = v1[0]
            del v487
            v1[0] = v475
            del v475
            v488 = v1[0]
            v489 = v488 - 1
            del v488
            v490 = 0 <= v489
            if v490:
                v491 = v1[0]
                v492 = v489 < v491
                del v491
                v493 = v492
            else:
                v493 = False
            v494 = v493 == False
            if v494:
                v495 = "The read index needs to be in range."
                assert v493, v495
                del v495
            else:
                pass
            del v493, v494
            if v490:
                v496 = v489 < 6
                v497 = v496
            else:
                v497 = False
            del v490
            v498 = v497 == False
            if v498:
                v499 = "The read index needs to be in range."
                assert v497, v499
                del v499
            else:
                pass
            del v497, v498
            v500 = v0[v489]
            v501 = v1[0]
            del v501
            v1[0] = v489
            del v489
            v502 = v3[0]
            v503 = 1 + v502
            v3[0] = v503
            del v503
            v504 = 0 <= v502
            if v504:
                v505 = v3[0]
                v506 = v502 < v505
                del v505
                v507 = v506
            else:
                v507 = False
            v508 = v507 == False
            if v508:
                v509 = "The set index needs to be in range."
                assert v507, v509
                del v509
            else:
                pass
            del v507, v508
            if v504:
                v510 = v502 < 32
                v511 = v510
            else:
                v511 = False
            del v504
            v512 = v511 == False
            if v512:
                v513 = "The read index needs to be in range."
                assert v511, v513
                del v513
            else:
                pass
            del v511, v512
            v514 = US8_2(0, v486)
            v2[v502] = v514
            del v502, v514
            v515 = v3[0]
            v516 = 1 + v515
            v3[0] = v516
            del v516
            v517 = 0 <= v515
            if v517:
                v518 = v3[0]
                v519 = v515 < v518
                del v518
                v520 = v519
            else:
                v520 = False
            v521 = v520 == False
            if v521:
                v522 = "The set index needs to be in range."
                assert v520, v522
                del v522
            else:
                pass
            del v520, v521
            if v517:
                v523 = v515 < 32
                v524 = v523
            else:
                v524 = False
            del v517
            v525 = v524 == False
            if v525:
                v526 = "The read index needs to be in range."
                assert v524, v526
                del v526
            else:
                pass
            del v524, v525
            v527 = US8_2(1, v500)
            v2[v515] = v527
            del v515, v527
            v528 = 2
            v529 = [None] * 2
            v529[0] = 1
            v529[1] = 1
            v530 = [None] * 2
            v530[0] = v486
            del v486
            v530[1] = v500
            del v500
            v531 = US4_0()
            v532 = True
            v533 = 0
            v534 = US6_2(v531, v532, v530, v533, v529, v528)
            del v528, v529, v530, v531, v532, v533
            return method16(v0, v1, v2, v3, v4, v534)
        case US6_2(v65, v66, v67, v68, v69, v70): # Round
            v71 = 0 <= v68
            if v71:
                v72 = v68 < 2
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
            v76 = v4[v68]
            match v76:
                case US2_0(): # Computer
                    del v5, v76
                    v77 = [None] * 3
                    v78 = [0]
                    v79 = v78[0]
                    del v79
                    v78[0] = 1
                    v80 = v78[0]
                    v81 = 0 < v80
                    del v80
                    v82 = v81 == False
                    if v82:
                        v83 = "The set index needs to be in range."
                        assert v81, v83
                        del v83
                    else:
                        pass
                    del v81, v82
                    v84 = US1_0()
                    v77[0] = v84
                    del v84
                    v85 = v69[0]
                    v86 = v69[1]
                    v87 = v85 == v86
                    del v85, v86
                    v88 = v87 != True
                    del v87
                    if v88:
                        v89 = v78[0]
                        v90 = 1 + v89
                        v78[0] = v90
                        del v90
                        v91 = 0 <= v89
                        if v91:
                            v92 = v78[0]
                            v93 = v89 < v92
                            del v92
                            v94 = v93
                        else:
                            v94 = False
                        v95 = v94 == False
                        if v95:
                            v96 = "The set index needs to be in range."
                            assert v94, v96
                            del v96
                        else:
                            pass
                        del v94, v95
                        if v91:
                            v97 = v89 < 3
                            v98 = v97
                        else:
                            v98 = False
                        del v91
                        v99 = v98 == False
                        if v99:
                            v100 = "The read index needs to be in range."
                            assert v98, v100
                            del v100
                        else:
                            pass
                        del v98, v99
                        v101 = US1_1()
                        v77[v89] = v101
                        del v89, v101
                    else:
                        pass
                    del v88
                    v102 = v70 > 0
                    if v102:
                        v103 = v78[0]
                        v104 = 1 + v103
                        v78[0] = v104
                        del v104
                        v105 = 0 <= v103
                        if v105:
                            v106 = v78[0]
                            v107 = v103 < v106
                            del v106
                            v108 = v107
                        else:
                            v108 = False
                        v109 = v108 == False
                        if v109:
                            v110 = "The set index needs to be in range."
                            assert v108, v110
                            del v110
                        else:
                            pass
                        del v108, v109
                        if v105:
                            v111 = v103 < 3
                            v112 = v111
                        else:
                            v112 = False
                        del v105
                        v113 = v112 == False
                        if v113:
                            v114 = "The read index needs to be in range."
                            assert v112, v114
                            del v114
                        else:
                            pass
                        del v112, v113
                        v115 = US1_2()
                        v77[v103] = v115
                        del v103, v115
                    else:
                        pass
                    v116 = v78[0]
                    v117 = v77[:v116]
                    del v116
                    random.shuffle(v117)
                    v118 = v78[0]
                    v77[:v118] = v117
                    del v117, v118
                    v119 = v78[0]
                    v120 = v119 - 1
                    del v119
                    v121 = 0 <= v120
                    if v121:
                        v122 = v78[0]
                        v123 = v120 < v122
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
                    if v121:
                        v127 = v120 < 3
                        v128 = v127
                    else:
                        v128 = False
                    del v121
                    v129 = v128 == False
                    if v129:
                        v130 = "The read index needs to be in range."
                        assert v128, v130
                        del v130
                    else:
                        pass
                    del v128, v129
                    v131 = v77[v120]
                    del v77
                    v132 = v78[0]
                    del v132
                    v78[0] = v120
                    del v78, v120
                    v133 = v3[0]
                    v134 = 1 + v133
                    v3[0] = v134
                    del v134
                    v135 = 0 <= v133
                    if v135:
                        v136 = v3[0]
                        v137 = v133 < v136
                        del v136
                        v138 = v137
                    else:
                        v138 = False
                    v139 = v138 == False
                    if v139:
                        v140 = "The set index needs to be in range."
                        assert v138, v140
                        del v140
                    else:
                        pass
                    del v138, v139
                    if v135:
                        v141 = v133 < 32
                        v142 = v141
                    else:
                        v142 = False
                    del v135
                    v143 = v142 == False
                    if v143:
                        v144 = "The read index needs to be in range."
                        assert v142, v144
                        del v144
                    else:
                        pass
                    del v142, v143
                    v145 = US8_1(v68, v131)
                    v2[v133] = v145
                    del v133, v145
                    match v65:
                        case US4_0(): # None
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v217 = v68 == 0
                                        if v217:
                                            v218 = 1
                                        else:
                                            v218 = 0
                                        del v217
                                        v267 = US6_2(v65, False, v67, v218, v69, v70)
                                    else:
                                        v267 = US6_0(v65, v66, v67, v68, v69, v70)
                                case US1_1(): # Fold
                                    v267 = US6_5(v65, v66, v67, v68, v69, v70)
                                case US1_2(): # Raise
                                    if v102:
                                        v222 = v68 == 0
                                        if v222:
                                            v223 = 1
                                        else:
                                            v223 = 0
                                        del v222
                                        v224 = -1 + v70
                                        v225, v226 = (0, 0)
                                        while method17(v225):
                                            v228 = 0 <= v225
                                            if v228:
                                                v229 = v225 < 2
                                                v230 = v229
                                            else:
                                                v230 = False
                                            del v228
                                            v231 = v230 == False
                                            if v231:
                                                v232 = "The read index needs to be in range."
                                                assert v230, v232
                                                del v232
                                            else:
                                                pass
                                            del v230, v231
                                            v233 = v69[v225]
                                            v234 = v226 >= v233
                                            if v234:
                                                v235 = v226
                                            else:
                                                v235 = v233
                                            del v233, v234
                                            v226 = v235
                                            del v235
                                            v225 += 1 
                                        del v225
                                        v236 = [None] * 2
                                        v237 = 0
                                        while method17(v237):
                                            v239 = 0 <= v237
                                            if v239:
                                                v240 = v237 < 2
                                                v241 = v240
                                            else:
                                                v241 = False
                                            del v239
                                            v242 = v241 == False
                                            if v242:
                                                v243 = "The read index needs to be in range."
                                                assert v241, v243
                                                del v243
                                            else:
                                                pass
                                            del v241, v242
                                            v236[v237] = v226
                                            v237 += 1 
                                        del v226, v237
                                        v244 = [None] * 2
                                        v245 = 0
                                        while method17(v245):
                                            v247 = 0 <= v245
                                            if v247:
                                                v248 = v245 < 2
                                                v249 = v248
                                            else:
                                                v249 = False
                                            v250 = v249 == False
                                            if v250:
                                                v251 = "The read index needs to be in range."
                                                assert v249, v251
                                                del v251
                                            else:
                                                pass
                                            del v249, v250
                                            v252 = v236[v245]
                                            v253 = v245 == v68
                                            if v253:
                                                v254 = v252 + 2
                                                v255 = v254
                                            else:
                                                v255 = v252
                                            del v252, v253
                                            if v247:
                                                v256 = v245 < 2
                                                v257 = v256
                                            else:
                                                v257 = False
                                            del v247
                                            v258 = v257 == False
                                            if v258:
                                                v259 = "The read index needs to be in range."
                                                assert v257, v259
                                                del v259
                                            else:
                                                pass
                                            del v257, v258
                                            v244[v245] = v255
                                            del v255
                                            v245 += 1 
                                        del v236, v245
                                        v267 = US6_2(v65, False, v67, v223, v244, v224)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US4_1(_): # Some
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v148 = v68 == 0
                                        if v148:
                                            v149 = 1
                                        else:
                                            v149 = 0
                                        del v148
                                        v267 = US6_2(v65, False, v67, v149, v69, v70)
                                    else:
                                        v151, v152 = (0, 0)
                                        while method17(v151):
                                            v154 = 0 <= v151
                                            if v154:
                                                v155 = v151 < 2
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
                                            v159 = v69[v151]
                                            v160 = v152 >= v159
                                            if v160:
                                                v161 = v152
                                            else:
                                                v161 = v159
                                            del v159, v160
                                            v152 = v161
                                            del v161
                                            v151 += 1 
                                        del v151
                                        v162 = [None] * 2
                                        v163 = 0
                                        while method17(v163):
                                            v165 = 0 <= v163
                                            if v165:
                                                v166 = v163 < 2
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
                                            v162[v163] = v152
                                            v163 += 1 
                                        del v152, v163
                                        v267 = US6_4(v65, v66, v67, v68, v162, v70)
                                case US1_1(): # Fold
                                    v267 = US6_5(v65, v66, v67, v68, v69, v70)
                                case US1_2(): # Raise
                                    if v102:
                                        v172 = v68 == 0
                                        if v172:
                                            v173 = 1
                                        else:
                                            v173 = 0
                                        del v172
                                        v174 = -1 + v70
                                        v175, v176 = (0, 0)
                                        while method17(v175):
                                            v178 = 0 <= v175
                                            if v178:
                                                v179 = v175 < 2
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
                                            v183 = v69[v175]
                                            v184 = v176 >= v183
                                            if v184:
                                                v185 = v176
                                            else:
                                                v185 = v183
                                            del v183, v184
                                            v176 = v185
                                            del v185
                                            v175 += 1 
                                        del v175
                                        v186 = [None] * 2
                                        v187 = 0
                                        while method17(v187):
                                            v189 = 0 <= v187
                                            if v189:
                                                v190 = v187 < 2
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
                                            v186[v187] = v176
                                            v187 += 1 
                                        del v176, v187
                                        v194 = [None] * 2
                                        v195 = 0
                                        while method17(v195):
                                            v197 = 0 <= v195
                                            if v197:
                                                v198 = v195 < 2
                                                v199 = v198
                                            else:
                                                v199 = False
                                            v200 = v199 == False
                                            if v200:
                                                v201 = "The read index needs to be in range."
                                                assert v199, v201
                                                del v201
                                            else:
                                                pass
                                            del v199, v200
                                            v202 = v186[v195]
                                            v203 = v195 == v68
                                            if v203:
                                                v204 = v202 + 4
                                                v205 = v204
                                            else:
                                                v205 = v202
                                            del v202, v203
                                            if v197:
                                                v206 = v195 < 2
                                                v207 = v206
                                            else:
                                                v207 = False
                                            del v197
                                            v208 = v207 == False
                                            if v208:
                                                v209 = "The read index needs to be in range."
                                                assert v207, v209
                                                del v209
                                            else:
                                                pass
                                            del v207, v208
                                            v194[v195] = v205
                                            del v205
                                            v195 += 1 
                                        del v186, v195
                                        v267 = US6_2(v65, False, v67, v173, v194, v174)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v65, v66, v67, v68, v69, v70, v102, v131
                    return method16(v0, v1, v2, v3, v4, v267)
                case US2_1(): # Human
                    del v0, v1, v2, v3, v4, v65, v66, v67, v68, v69, v70, v76
                    return v5
                case _:
                    raise Exception('Pattern matching miss.')
        case US6_3(v271, v272, v273, v274, v275, v276, v277): # RoundWithAction
            del v5
            v278 = v3[0]
            v279 = 1 + v278
            v3[0] = v279
            del v279
            v280 = 0 <= v278
            if v280:
                v281 = v3[0]
                v282 = v278 < v281
                del v281
                v283 = v282
            else:
                v283 = False
            v284 = v283 == False
            if v284:
                v285 = "The set index needs to be in range."
                assert v283, v285
                del v285
            else:
                pass
            del v283, v284
            if v280:
                v286 = v278 < 32
                v287 = v286
            else:
                v287 = False
            del v280
            v288 = v287 == False
            if v288:
                v289 = "The read index needs to be in range."
                assert v287, v289
                del v289
            else:
                pass
            del v287, v288
            v290 = US8_1(v274, v277)
            v2[v278] = v290
            del v278, v290
            match v271:
                case US4_0(): # None
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v363 = v274 == 0
                                if v363:
                                    v364 = 1
                                else:
                                    v364 = 0
                                del v363
                                v414 = US6_2(v271, False, v273, v364, v275, v276)
                            else:
                                v414 = US6_0(v271, v272, v273, v274, v275, v276)
                        case US1_1(): # Fold
                            v414 = US6_5(v271, v272, v273, v274, v275, v276)
                        case US1_2(): # Raise
                            v368 = v276 > 0
                            if v368:
                                del v368
                                v369 = v274 == 0
                                if v369:
                                    v370 = 1
                                else:
                                    v370 = 0
                                del v369
                                v371 = -1 + v276
                                v372, v373 = (0, 0)
                                while method17(v372):
                                    v375 = 0 <= v372
                                    if v375:
                                        v376 = v372 < 2
                                        v377 = v376
                                    else:
                                        v377 = False
                                    del v375
                                    v378 = v377 == False
                                    if v378:
                                        v379 = "The read index needs to be in range."
                                        assert v377, v379
                                        del v379
                                    else:
                                        pass
                                    del v377, v378
                                    v380 = v275[v372]
                                    v381 = v373 >= v380
                                    if v381:
                                        v382 = v373
                                    else:
                                        v382 = v380
                                    del v380, v381
                                    v373 = v382
                                    del v382
                                    v372 += 1 
                                del v372
                                v383 = [None] * 2
                                v384 = 0
                                while method17(v384):
                                    v386 = 0 <= v384
                                    if v386:
                                        v387 = v384 < 2
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
                                    v383[v384] = v373
                                    v384 += 1 
                                del v373, v384
                                v391 = [None] * 2
                                v392 = 0
                                while method17(v392):
                                    v394 = 0 <= v392
                                    if v394:
                                        v395 = v392 < 2
                                        v396 = v395
                                    else:
                                        v396 = False
                                    v397 = v396 == False
                                    if v397:
                                        v398 = "The read index needs to be in range."
                                        assert v396, v398
                                        del v398
                                    else:
                                        pass
                                    del v396, v397
                                    v399 = v383[v392]
                                    v400 = v392 == v274
                                    if v400:
                                        v401 = v399 + 2
                                        v402 = v401
                                    else:
                                        v402 = v399
                                    del v399, v400
                                    if v394:
                                        v403 = v392 < 2
                                        v404 = v403
                                    else:
                                        v404 = False
                                    del v394
                                    v405 = v404 == False
                                    if v405:
                                        v406 = "The read index needs to be in range."
                                        assert v404, v406
                                        del v406
                                    else:
                                        pass
                                    del v404, v405
                                    v391[v392] = v402
                                    del v402
                                    v392 += 1 
                                del v383, v392
                                v414 = US6_2(v271, False, v273, v370, v391, v371)
                            else:
                                del v368
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case US4_1(_): # Some
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v293 = v274 == 0
                                if v293:
                                    v294 = 1
                                else:
                                    v294 = 0
                                del v293
                                v414 = US6_2(v271, False, v273, v294, v275, v276)
                            else:
                                v296, v297 = (0, 0)
                                while method17(v296):
                                    v299 = 0 <= v296
                                    if v299:
                                        v300 = v296 < 2
                                        v301 = v300
                                    else:
                                        v301 = False
                                    del v299
                                    v302 = v301 == False
                                    if v302:
                                        v303 = "The read index needs to be in range."
                                        assert v301, v303
                                        del v303
                                    else:
                                        pass
                                    del v301, v302
                                    v304 = v275[v296]
                                    v305 = v297 >= v304
                                    if v305:
                                        v306 = v297
                                    else:
                                        v306 = v304
                                    del v304, v305
                                    v297 = v306
                                    del v306
                                    v296 += 1 
                                del v296
                                v307 = [None] * 2
                                v308 = 0
                                while method17(v308):
                                    v310 = 0 <= v308
                                    if v310:
                                        v311 = v308 < 2
                                        v312 = v311
                                    else:
                                        v312 = False
                                    del v310
                                    v313 = v312 == False
                                    if v313:
                                        v314 = "The read index needs to be in range."
                                        assert v312, v314
                                        del v314
                                    else:
                                        pass
                                    del v312, v313
                                    v307[v308] = v297
                                    v308 += 1 
                                del v297, v308
                                v414 = US6_4(v271, v272, v273, v274, v307, v276)
                        case US1_1(): # Fold
                            v414 = US6_5(v271, v272, v273, v274, v275, v276)
                        case US1_2(): # Raise
                            v317 = v276 > 0
                            if v317:
                                del v317
                                v318 = v274 == 0
                                if v318:
                                    v319 = 1
                                else:
                                    v319 = 0
                                del v318
                                v320 = -1 + v276
                                v321, v322 = (0, 0)
                                while method17(v321):
                                    v324 = 0 <= v321
                                    if v324:
                                        v325 = v321 < 2
                                        v326 = v325
                                    else:
                                        v326 = False
                                    del v324
                                    v327 = v326 == False
                                    if v327:
                                        v328 = "The read index needs to be in range."
                                        assert v326, v328
                                        del v328
                                    else:
                                        pass
                                    del v326, v327
                                    v329 = v275[v321]
                                    v330 = v322 >= v329
                                    if v330:
                                        v331 = v322
                                    else:
                                        v331 = v329
                                    del v329, v330
                                    v322 = v331
                                    del v331
                                    v321 += 1 
                                del v321
                                v332 = [None] * 2
                                v333 = 0
                                while method17(v333):
                                    v335 = 0 <= v333
                                    if v335:
                                        v336 = v333 < 2
                                        v337 = v336
                                    else:
                                        v337 = False
                                    del v335
                                    v338 = v337 == False
                                    if v338:
                                        v339 = "The read index needs to be in range."
                                        assert v337, v339
                                        del v339
                                    else:
                                        pass
                                    del v337, v338
                                    v332[v333] = v322
                                    v333 += 1 
                                del v322, v333
                                v340 = [None] * 2
                                v341 = 0
                                while method17(v341):
                                    v343 = 0 <= v341
                                    if v343:
                                        v344 = v341 < 2
                                        v345 = v344
                                    else:
                                        v345 = False
                                    v346 = v345 == False
                                    if v346:
                                        v347 = "The read index needs to be in range."
                                        assert v345, v347
                                        del v347
                                    else:
                                        pass
                                    del v345, v346
                                    v348 = v332[v341]
                                    v349 = v341 == v274
                                    if v349:
                                        v350 = v348 + 4
                                        v351 = v350
                                    else:
                                        v351 = v348
                                    del v348, v349
                                    if v343:
                                        v352 = v341 < 2
                                        v353 = v352
                                    else:
                                        v353 = False
                                    del v343
                                    v354 = v353 == False
                                    if v354:
                                        v355 = "The read index needs to be in range."
                                        assert v353, v355
                                        del v355
                                    else:
                                        pass
                                    del v353, v354
                                    v340[v341] = v351
                                    del v351
                                    v341 += 1 
                                del v332, v341
                                v414 = US6_2(v271, False, v273, v319, v340, v320)
                            else:
                                del v317
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case _:
                    raise Exception('Pattern matching miss.')
            del v271, v272, v273, v274, v275, v276, v277
            return method16(v0, v1, v2, v3, v4, v414)
        case US6_4(v33, v34, v35, v36, v37, v38): # TerminalCall
            del v0, v1, v4
            v39 = 0 <= v36
            if v39:
                v40 = v36 < 2
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
            v44 = v37[v36]
            v45 = method18(v33, v34, v35, v36, v37, v38)
            del v33, v34, v36, v37, v38
            match v45:
                case US10_0(): # Eq
                    v50, v51 = 0, -1
                case US10_1(): # Gt
                    v50, v51 = v44, 0
                case US10_2(): # Lt
                    v50, v51 = v44, 1
                case _:
                    raise Exception('Pattern matching miss.')
            del v44, v45
            v52 = v3[0]
            v53 = 1 + v52
            v3[0] = v53
            del v53
            v54 = 0 <= v52
            if v54:
                v55 = v3[0]
                v56 = v52 < v55
                del v55
                v57 = v56
            else:
                v57 = False
            del v3
            v58 = v57 == False
            if v58:
                v59 = "The set index needs to be in range."
                assert v57, v59
                del v59
            else:
                pass
            del v57, v58
            if v54:
                v60 = v52 < 32
                v61 = v60
            else:
                v61 = False
            del v54
            v62 = v61 == False
            if v62:
                v63 = "The read index needs to be in range."
                assert v61, v63
                del v63
            else:
                pass
            del v61, v62
            v64 = US8_3(v35, v50, v51)
            del v35, v50, v51
            v2[v52] = v64
            del v2, v52, v64
            return v5
        case US6_5(_, _, v8, v9, v10, _): # TerminalFold
            del v0, v1, v4
            v12 = 0 <= v9
            if v12:
                v13 = v9 < 2
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
            v17 = v10[v9]
            del v10
            v18 = v9 == 0
            del v9
            if v18:
                v19 = 1
            else:
                v19 = 0
            del v18
            v20 = v3[0]
            v21 = 1 + v20
            v3[0] = v21
            del v21
            v22 = 0 <= v20
            if v22:
                v23 = v3[0]
                v24 = v20 < v23
                del v23
                v25 = v24
            else:
                v25 = False
            del v3
            v26 = v25 == False
            if v26:
                v27 = "The set index needs to be in range."
                assert v25, v27
                del v27
            else:
                pass
            del v25, v26
            if v22:
                v28 = v20 < 32
                v29 = v28
            else:
                v29 = False
            del v22
            v30 = v29 == False
            if v30:
                v31 = "The read index needs to be in range."
                assert v29, v31
                del v31
            else:
                pass
            del v29, v30
            v32 = US8_3(v8, v17, v19)
            del v8, v17, v19
            v2[v20] = v32
            del v2, v20, v32
            return v5
        case _:
            raise Exception('Pattern matching miss.')
def method14(v0 : US3, v1 : list[US7], v2 : list[US2], v3 : US9, v4 : list[US5], v5 : list, v6 : US6) -> Tuple[US3, list[US7], list[US2], US9]:
    del v0, v3
    v7 = [None] * 32
    v8 = [0]
    v9 = 0
    while method15(v9):
        v11 = 0 <= v9
        if v11:
            v12 = v9 < 32
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v16 = v1[v9]
        match v16:
            case US7_0(): # None
                pass
            case US7_1(v17): # Some
                v18 = v8[0]
                v19 = 1 + v18
                v8[0] = v19
                del v19
                v20 = 0 <= v18
                if v20:
                    v21 = v8[0]
                    v22 = v18 < v21
                    del v21
                    v23 = v22
                else:
                    v23 = False
                v24 = v23 == False
                if v24:
                    v25 = "The set index needs to be in range."
                    assert v23, v25
                    del v25
                else:
                    pass
                del v23, v24
                if v20:
                    v26 = v18 < 32
                    v27 = v26
                else:
                    v27 = False
                del v20
                v28 = v27 == False
                if v28:
                    v29 = "The read index needs to be in range."
                    assert v27, v29
                    del v29
                else:
                    pass
                del v27, v28
                v7[v18] = v17
                del v17, v18
            case _:
                raise Exception('Pattern matching miss.')
        del v16
        v9 += 1 
    del v9
    v30 = method16(v4, v5, v7, v8, v2, v6)
    del v6, v7, v8
    match v30:
        case US6_2(v31, v32, v33, v34, v35, v36): # Round
            v37 = [None] * 6
            v38 = 0
            while method13(v38):
                v40 = v5[0]
                v41 = v38 < v40
                del v40
                if v41:
                    v42 = 0 <= v38
                    if v42:
                        v43 = v5[0]
                        v44 = v38 < v43
                        del v43
                        v45 = v44
                    else:
                        v45 = False
                    v46 = v45 == False
                    if v46:
                        v47 = "The read index needs to be in range."
                        assert v45, v47
                        del v47
                    else:
                        pass
                    del v45, v46
                    if v42:
                        v48 = v38 < 6
                        v49 = v48
                    else:
                        v49 = False
                    del v42
                    v50 = v49 == False
                    if v50:
                        v51 = "The read index needs to be in range."
                        assert v49, v51
                        del v51
                    else:
                        pass
                    del v49, v50
                    v52 = v4[v38]
                    v55 = US4_1(v52)
                else:
                    v55 = US4_0()
                del v41
                v56 = 0 <= v38
                if v56:
                    v57 = v38 < 6
                    v58 = v57
                else:
                    v58 = False
                del v56
                v59 = v58 == False
                if v59:
                    v60 = "The read index needs to be in range."
                    assert v58, v60
                    del v60
                else:
                    pass
                del v58, v59
                v37[v38] = v55
                del v55
                v38 += 1 
            del v4, v5, v38
            v61 = US3_1(v37, v30)
            del v30, v37
            v62 = US9_2(v31, v32, v33, v34, v35, v36)
            del v31, v32, v33, v34, v35, v36
            return v61, v1, v2, v62
        case US6_4(v63, v64, v65, v66, v67, v68): # TerminalCall
            del v4, v5, v30
            v69 = US3_0()
            v70 = US9_1(v63, v64, v65, v66, v67, v68)
            del v63, v64, v65, v66, v67, v68
            return v69, v1, v2, v70
        case US6_5(v71, v72, v73, v74, v75, v76): # TerminalFold
            del v4, v5, v30
            v77 = US3_0()
            v78 = US9_1(v71, v72, v73, v74, v75, v76)
            del v71, v72, v73, v74, v75, v76
            return v77, v1, v2, v78
        case _:
            del v1, v2, v4, v5, v30
            raise Exception("Unexpected node received in play_loop.")
def method25(v0 : US5) -> object:
    match v0:
        case US5_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US5_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US5_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case _:
            raise Exception('Pattern matching miss.')
def method24(v0 : US4) -> object:
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
            v5 = method25(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case _:
            raise Exception('Pattern matching miss.')
def method27(v0 : US1) -> object:
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
        case _:
            raise Exception('Pattern matching miss.')
def method26(v0 : US6) -> object:
    match v0:
        case US6_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method24(v1)
            del v1
            v8 = v2
            del v2
            v9 = []
            v10 = 0
            while method17(v10):
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
                v18 = method25(v17)
                del v17
                v9.append(v18)
                del v18
                v10 += 1 
            del v3, v10
            v19 = v4
            del v4
            v20 = []
            v21 = 0
            while method17(v21):
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
        case US6_1(): # ChanceInit
            del v0
            v34 = []
            v35 = "ChanceInit"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US6_2(v37, v38, v39, v40, v41, v42): # Round
            del v0
            v43 = method24(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method17(v46):
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
                v54 = method25(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method17(v57):
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
        case US6_3(v70, v71, v72, v73, v74, v75, v76): # RoundWithAction
            del v0
            v77 = []
            v78 = method24(v70)
            del v70
            v79 = v71
            del v71
            v80 = []
            v81 = 0
            while method17(v81):
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
                v89 = method25(v88)
                del v88
                v80.append(v89)
                del v89
                v81 += 1 
            del v72, v81
            v90 = v73
            del v73
            v91 = []
            v92 = 0
            while method17(v92):
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
            v103 = method27(v76)
            del v76
            v77.append(v103)
            del v103
            v104 = v77
            del v77
            v105 = "RoundWithAction"
            v106 = [v105,v104]
            del v104, v105
            return v106
        case US6_4(v107, v108, v109, v110, v111, v112): # TerminalCall
            del v0
            v113 = method24(v107)
            del v107
            v114 = v108
            del v108
            v115 = []
            v116 = 0
            while method17(v116):
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
                v124 = method25(v123)
                del v123
                v115.append(v124)
                del v124
                v116 += 1 
            del v109, v116
            v125 = v110
            del v110
            v126 = []
            v127 = 0
            while method17(v127):
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
        case US6_5(v140, v141, v142, v143, v144, v145): # TerminalFold
            del v0
            v146 = method24(v140)
            del v140
            v147 = v141
            del v141
            v148 = []
            v149 = 0
            while method17(v149):
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
                v157 = method25(v156)
                del v156
                v148.append(v157)
                del v157
                v149 += 1 
            del v142, v149
            v158 = v143
            del v143
            v159 = []
            v160 = 0
            while method17(v160):
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
        case _:
            raise Exception('Pattern matching miss.')
def method23(v0 : US3) -> object:
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
            v7 = 0
            while method13(v7):
                v9 = 0 <= v7
                if v9:
                    v10 = v7 < 6
                    v11 = v10
                else:
                    v11 = False
                del v9
                v12 = v11 == False
                if v12:
                    v13 = "The read index needs to be in range."
                    assert v11, v13
                    del v13
                else:
                    pass
                del v11, v12
                v14 = v4[v7]
                v15 = method24(v14)
                del v14
                v6.append(v15)
                del v15
                v7 += 1 
            del v4, v7
            v16 = method26(v5)
            del v5
            v17 = {'deck': v6, 'game': v16}
            del v6, v16
            v18 = "Some"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case _:
            raise Exception('Pattern matching miss.')
def method29(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method25(v1)
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
            v9 = method27(v6)
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
            v17 = method25(v14)
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
            while method17(v25):
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
                v33 = method25(v32)
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
        case _:
            raise Exception('Pattern matching miss.')
def method28(v0 : US7) -> object:
    match v0:
        case US7_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US7_1(v4): # Some
            del v0
            v5 = method29(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case _:
            raise Exception('Pattern matching miss.')
def method30(v0 : US2) -> object:
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
        case _:
            raise Exception('Pattern matching miss.')
def method31(v0 : US9) -> object:
    match v0:
        case US9_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US9_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method24(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method17(v13):
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
                v21 = method25(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method17(v24):
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
        case US9_2(v37, v38, v39, v40, v41, v42): # WaitingForActionFromPlayerId
            del v0
            v43 = method24(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method17(v46):
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
                v54 = method25(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method17(v57):
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
        case _:
            raise Exception('Pattern matching miss.')
def method22(v0 : US3, v1 : list[US7], v2 : list[US2], v3 : US9) -> object:
    v4 = method23(v0)
    del v0
    v5 = []
    v6 = 0
    while method15(v6):
        v8 = 0 <= v6
        if v8:
            v9 = v6 < 32
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v6]
        v14 = method28(v13)
        del v13
        v5.append(v14)
        del v14
        v6 += 1 
    del v1, v6
    v15 = []
    v16 = 0
    while method17(v16):
        v18 = 0 <= v16
        if v18:
            v19 = v16 < 2
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
        v23 = v2[v16]
        v24 = method30(v23)
        del v23
        v15.append(v24)
        del v24
        v16 += 1 
    del v2, v16
    v25 = method31(v3)
    del v3
    v26 = {'messages': v5, 'pl_type': v15, 'ui_game_state': v25}
    del v5, v15, v25
    v27 = {'game_state': v4, 'ui_state': v26}
    del v4, v26
    return v27
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = Closure2()
    v3 = collections.namedtuple("Leduc_Game",['event_loop_cpu', 'event_loop_gpu', 'init'])(v0, v1, v2)
    del v0, v1, v2
    return v3

if __name__ == '__main__': print(main())
