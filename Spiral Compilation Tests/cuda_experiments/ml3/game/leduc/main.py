kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
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
__device__ US9 compare_hands_3(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5);
__device__ US5 play_loop_inner_1(array<US4,6l> v0, long & v1, array<US7,32l> v2, long & v3, array<US2,2l> v4, US5 v5);
__device__ Tuple0 play_loop_0(US3 v0, array<US7,32l> v1, long & v2, array<US2,2l> v3, US8 v4, array<US4,6l> v5, long & v6, US5 v7);
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
            array<US2,2l> v0;
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
            array<US4,2l> v2;
            array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case0; // ChanceCommunityCard
        struct {
            US6 v0;
            array<US4,2l> v2;
            array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // Round
        struct {
            US6 v0;
            array<US4,2l> v2;
            array<long,2l> v4;
            US1 v6;
            long v3;
            long v5;
            bool v1;
        } case3; // RoundWithAction
        struct {
            US6 v0;
            array<US4,2l> v2;
            array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case4; // TerminalCall
        struct {
            US6 v0;
            array<US4,2l> v2;
            array<long,2l> v4;
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
            array<US4,6l> v0;
            long & v1;
            US5 v2;
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
            array<US4,2l> v0;
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
            array<US4,2l> v2;
            array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case1; // GameOver
        struct {
            US6 v0;
            array<US4,2l> v2;
            array<long,2l> v4;
            long v3;
            long v5;
            bool v1;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US3 v0;
    array<US7,32l> v1;
    long & v2;
    array<US2,2l> v3;
    US8 v4;
    __device__ Tuple0(US3 t0, array<US7,32l> t1, long & t2, array<US2,2l> t3, US8 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
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
__device__ US0 US0_1(array<US2,2l> v0) { // PlayerChanged
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
__device__ US5 US5_0(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // ChanceCommunityCard
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
__device__ US5 US5_2(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // Round
    US5 x;
    x.tag = 2;
    x.v.case2.v0 = v0; x.v.case2.v1 = v1; x.v.case2.v2 = v2; x.v.case2.v3 = v3; x.v.case2.v4 = v4; x.v.case2.v5 = v5;
    return x;
}
__device__ US5 US5_3(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5, US1 v6) { // RoundWithAction
    US5 x;
    x.tag = 3;
    x.v.case3.v0 = v0; x.v.case3.v1 = v1; x.v.case3.v2 = v2; x.v.case3.v3 = v3; x.v.case3.v4 = v4; x.v.case3.v5 = v5; x.v.case3.v6 = v6;
    return x;
}
__device__ US5 US5_4(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // TerminalCall
    US5 x;
    x.tag = 4;
    x.v.case4.v0 = v0; x.v.case4.v1 = v1; x.v.case4.v2 = v2; x.v.case4.v3 = v3; x.v.case4.v4 = v4; x.v.case4.v5 = v5;
    return x;
}
__device__ US5 US5_5(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // TerminalFold
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
__device__ US3 US3_1(array<US4,6l> v0, long & v1, US5 v2) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2;
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
__device__ US7 US7_3(array<US4,2l> v0, long v1, long v2) { // Showdown
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
__device__ US8 US8_1(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // GameOver
    US8 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1; x.v.case1.v2 = v2; x.v.case1.v3 = v3; x.v.case1.v4 = v4; x.v.case1.v5 = v5;
    return x;
}
__device__ US8 US8_2(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5) { // WaitingForActionFromPlayerId
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
__device__ US9 compare_hands_3(US6 v0, bool v1, array<US4,2l> v2, long v3, array<long,2l> v4, long v5){
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
__device__ US5 play_loop_inner_1(array<US4,6l> v0, long & v1, array<US7,32l> v2, long & v3, array<US2,2l> v4, US5 v5){
    switch (v5.tag) {
        case 0: { // ChanceCommunityCard
            US6 v421 = v5.v.case0.v0; bool v422 = v5.v.case0.v1; array<US4,2l> v423 = v5.v.case0.v2; long v424 = v5.v.case0.v3; array<long,2l> v425 = v5.v.case0.v4; long v426 = v5.v.case0.v5;
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
            US4 v437;
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
            US7 v449;
            v449 = US7_0(v437);
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
            US6 v468;
            v468 = US6_1(v437);
            bool v469;
            v469 = true;
            long v470;
            v470 = 0l;
            US5 v471;
            v471 = US5_2(v468, v469, v423, v470, v461, v450);
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
            US4 v483;
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
            US4 v495;
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
            US7 v507;
            v507 = US7_2(0l, v483);
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
            US7 v518;
            v518 = US7_2(1l, v495);
            v2.v[v508] = v518;
            long v519;
            v519 = 2l;
            array<long,2l> v520;
            v520.v[0l] = 1l;
            v520.v[1l] = 1l;
            array<US4,2l> v521;
            v521.v[0l] = v483;
            v521.v[1l] = v495;
            US6 v522;
            v522 = US6_0();
            bool v523;
            v523 = true;
            long v524;
            v524 = 0l;
            US5 v525;
            v525 = US5_2(v522, v523, v521, v524, v520, v519);
            return play_loop_inner_1(v0, v1, v2, v3, v4, v525);
            break;
        }
        case 2: { // Round
            US6 v59 = v5.v.case2.v0; bool v60 = v5.v.case2.v1; array<US4,2l> v61 = v5.v.case2.v2; long v62 = v5.v.case2.v3; array<long,2l> v63 = v5.v.case2.v4; long v64 = v5.v.case2.v5;
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
                    while (while_method_1(v108, v109)){
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
                    US7 v172;
                    v172 = US7_1(v62, v160);
                    v2.v[v162] = v172;
                    US5 v284;
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
                                        v284 = US5_2(v59, false, v61, v239, v63, v64);
                                    } else {
                                        v284 = US5_0(v59, v60, v61, v62, v63, v64);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v284 = US5_5(v59, v60, v61, v62, v63, v64);
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
                                        v284 = US5_2(v59, false, v61, v244, v263, v245);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                            break;
                        }
                        default: { // Some
                            US4 v173 = v59.v.case1.v0;
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
                                        v284 = US5_2(v59, false, v61, v176, v63, v64);
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
                                        v284 = US5_4(v59, v60, v61, v62, v188, v64);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v284 = US5_5(v59, v60, v61, v62, v63, v64);
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
                                        v284 = US5_2(v59, false, v61, v198, v217, v199);
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
            US6 v288 = v5.v.case3.v0; bool v289 = v5.v.case3.v1; array<US4,2l> v290 = v5.v.case3.v2; long v291 = v5.v.case3.v3; array<long,2l> v292 = v5.v.case3.v4; long v293 = v5.v.case3.v5; US1 v294 = v5.v.case3.v6;
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
            US7 v305;
            v305 = US7_1(v291, v294);
            v2.v[v295] = v305;
            US5 v419;
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
                                v419 = US5_2(v288, false, v290, v373, v292, v293);
                            } else {
                                v419 = US5_0(v288, v289, v290, v291, v292, v293);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v419 = US5_5(v288, v289, v290, v291, v292, v293);
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
                                v419 = US5_2(v288, false, v290, v379, v398, v380);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                    break;
                }
                default: { // Some
                    US4 v306 = v288.v.case1.v0;
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
                                v419 = US5_2(v288, false, v290, v309, v292, v293);
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
                                v419 = US5_4(v288, v289, v290, v291, v321, v293);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v419 = US5_5(v288, v289, v290, v291, v292, v293);
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
                                v419 = US5_2(v288, false, v290, v332, v351, v333);
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
            US6 v30 = v5.v.case4.v0; bool v31 = v5.v.case4.v1; array<US4,2l> v32 = v5.v.case4.v2; long v33 = v5.v.case4.v3; array<long,2l> v34 = v5.v.case4.v4; long v35 = v5.v.case4.v5;
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
            US9 v41;
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
            US7 v58;
            v58 = US7_3(v32, v46, v47);
            v2.v[v48] = v58;
            return v5;
            break;
        }
        default: { // TerminalFold
            US6 v6 = v5.v.case5.v0; bool v7 = v5.v.case5.v1; array<US4,2l> v8 = v5.v.case5.v2; long v9 = v5.v.case5.v3; array<long,2l> v10 = v5.v.case5.v4; long v11 = v5.v.case5.v5;
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
            US7 v29;
            v29 = US7_3(v8, v16, v18);
            v2.v[v19] = v29;
            return v5;
        }
    }
}
__device__ Tuple0 play_loop_0(US3 v0, array<US7,32l> v1, long & v2, array<US2,2l> v3, US8 v4, array<US4,6l> v5, long & v6, US5 v7){
    US5 v8;
    v8 = play_loop_inner_1(v5, v6, v1, v2, v3, v7);
    switch (v8.tag) {
        case 2: { // Round
            US6 v9 = v8.v.case2.v0; bool v10 = v8.v.case2.v1; array<US4,2l> v11 = v8.v.case2.v2; long v12 = v8.v.case2.v3; array<long,2l> v13 = v8.v.case2.v4; long v14 = v8.v.case2.v5;
            US3 v15;
            v15 = US3_1(v5, v6, v8);
            US8 v16;
            v16 = US8_2(v9, v10, v11, v12, v13, v14);
            return Tuple0(v15, v1, v2, v3, v16);
            break;
        }
        case 4: { // TerminalCall
            US6 v17 = v8.v.case4.v0; bool v18 = v8.v.case4.v1; array<US4,2l> v19 = v8.v.case4.v2; long v20 = v8.v.case4.v3; array<long,2l> v21 = v8.v.case4.v4; long v22 = v8.v.case4.v5;
            US3 v23;
            v23 = US3_0();
            US8 v24;
            v24 = US8_1(v17, v18, v19, v20, v21, v22);
            return Tuple0(v23, v1, v2, v3, v24);
            break;
        }
        case 5: { // TerminalFold
            US6 v25 = v8.v.case5.v0; bool v26 = v8.v.case5.v1; array<US4,2l> v27 = v8.v.case5.v2; long v28 = v8.v.case5.v3; array<long,2l> v29 = v8.v.case5.v4; long v30 = v8.v.case5.v5;
            US3 v31;
            v31 = US3_0();
            US8 v32;
            v32 = US8_1(v25, v26, v27, v28, v29, v30);
            return Tuple0(v31, v1, v2, v3, v32);
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
        US3 v337;
        switch (v39) {
            case 0: {
                v337 = US3_0();
                break;
            }
            case 1: {
                array<US4,6l> v42;
                long v43 = 0l;
                long * v44;
                v44 = (long *)(v0+4ull);
                long v45;
                v45 = v44[0l];
                long & v46 = v43;
                v43 = v45;
                long & v47 = v43;
                long v48;
                v48 = 0l;
                while (while_method_1(v47, v48)){
                    unsigned long long v50;
                    v50 = (unsigned long long)v48;
                    unsigned long long v51;
                    v51 = v50 * 4ull;
                    unsigned long long v52;
                    v52 = 8ull + v51;
                    unsigned char * v53;
                    v53 = (unsigned char *)(v0+v52);
                    long * v54;
                    v54 = (long *)(v53+0ull);
                    long v55;
                    v55 = v54[0l];
                    US4 v60;
                    switch (v55) {
                        case 0: {
                            v60 = US4_0();
                            break;
                        }
                        case 1: {
                            v60 = US4_1();
                            break;
                        }
                        case 2: {
                            v60 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v61;
                    v61 = 0l <= v48;
                    bool v64;
                    if (v61){
                        long & v62 = v43;
                        bool v63;
                        v63 = v48 < v62;
                        v64 = v63;
                    } else {
                        v64 = false;
                    }
                    bool v65;
                    v65 = v64 == false;
                    if (v65){
                        assert("The set index needs to be in range." && v64);
                    } else {
                    }
                    bool v67;
                    if (v61){
                        bool v66;
                        v66 = v48 < 6l;
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
                    v42.v[v48] = v60;
                    v48 += 1l ;
                }
                long * v69;
                v69 = (long *)(v0+32ull);
                long v70;
                v70 = v69[0l];
                US5 v335;
                switch (v70) {
                    case 0: {
                        long * v72;
                        v72 = (long *)(v0+36ull);
                        long v73;
                        v73 = v72[0l];
                        US6 v84;
                        switch (v73) {
                            case 0: {
                                v84 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v76;
                                v76 = (long *)(v0+40ull);
                                long v77;
                                v77 = v76[0l];
                                US4 v82;
                                switch (v77) {
                                    case 0: {
                                        v82 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v82 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v82 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v84 = US6_1(v82);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v85;
                        v85 = (bool *)(v0+44ull);
                        bool v86;
                        v86 = v85[0l];
                        array<US4,2l> v87;
                        long v88;
                        v88 = 0l;
                        while (while_method_0(v88)){
                            unsigned long long v90;
                            v90 = (unsigned long long)v88;
                            unsigned long long v91;
                            v91 = v90 * 4ull;
                            unsigned long long v92;
                            v92 = 48ull + v91;
                            unsigned char * v93;
                            v93 = (unsigned char *)(v0+v92);
                            long * v94;
                            v94 = (long *)(v93+0ull);
                            long v95;
                            v95 = v94[0l];
                            US4 v100;
                            switch (v95) {
                                case 0: {
                                    v100 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v100 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v100 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v101;
                            v101 = 0l <= v88;
                            bool v103;
                            if (v101){
                                bool v102;
                                v102 = v88 < 2l;
                                v103 = v102;
                            } else {
                                v103 = false;
                            }
                            bool v104;
                            v104 = v103 == false;
                            if (v104){
                                assert("The read index needs to be in range." && v103);
                            } else {
                            }
                            v87.v[v88] = v100;
                            v88 += 1l ;
                        }
                        long * v105;
                        v105 = (long *)(v0+56ull);
                        long v106;
                        v106 = v105[0l];
                        array<long,2l> v107;
                        long v108;
                        v108 = 0l;
                        while (while_method_0(v108)){
                            unsigned long long v110;
                            v110 = (unsigned long long)v108;
                            unsigned long long v111;
                            v111 = v110 * 4ull;
                            unsigned long long v112;
                            v112 = 60ull + v111;
                            unsigned char * v113;
                            v113 = (unsigned char *)(v0+v112);
                            long * v114;
                            v114 = (long *)(v113+0ull);
                            long v115;
                            v115 = v114[0l];
                            bool v116;
                            v116 = 0l <= v108;
                            bool v118;
                            if (v116){
                                bool v117;
                                v117 = v108 < 2l;
                                v118 = v117;
                            } else {
                                v118 = false;
                            }
                            bool v119;
                            v119 = v118 == false;
                            if (v119){
                                assert("The read index needs to be in range." && v118);
                            } else {
                            }
                            v107.v[v108] = v115;
                            v108 += 1l ;
                        }
                        long * v120;
                        v120 = (long *)(v0+68ull);
                        long v121;
                        v121 = v120[0l];
                        v335 = US5_0(v84, v86, v87, v106, v107, v121);
                        break;
                    }
                    case 1: {
                        v335 = US5_1();
                        break;
                    }
                    case 2: {
                        long * v124;
                        v124 = (long *)(v0+36ull);
                        long v125;
                        v125 = v124[0l];
                        US6 v136;
                        switch (v125) {
                            case 0: {
                                v136 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v128;
                                v128 = (long *)(v0+40ull);
                                long v129;
                                v129 = v128[0l];
                                US4 v134;
                                switch (v129) {
                                    case 0: {
                                        v134 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v134 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v134 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v136 = US6_1(v134);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v137;
                        v137 = (bool *)(v0+44ull);
                        bool v138;
                        v138 = v137[0l];
                        array<US4,2l> v139;
                        long v140;
                        v140 = 0l;
                        while (while_method_0(v140)){
                            unsigned long long v142;
                            v142 = (unsigned long long)v140;
                            unsigned long long v143;
                            v143 = v142 * 4ull;
                            unsigned long long v144;
                            v144 = 48ull + v143;
                            unsigned char * v145;
                            v145 = (unsigned char *)(v0+v144);
                            long * v146;
                            v146 = (long *)(v145+0ull);
                            long v147;
                            v147 = v146[0l];
                            US4 v152;
                            switch (v147) {
                                case 0: {
                                    v152 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v152 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v152 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v153;
                            v153 = 0l <= v140;
                            bool v155;
                            if (v153){
                                bool v154;
                                v154 = v140 < 2l;
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
                            v139.v[v140] = v152;
                            v140 += 1l ;
                        }
                        long * v157;
                        v157 = (long *)(v0+56ull);
                        long v158;
                        v158 = v157[0l];
                        array<long,2l> v159;
                        long v160;
                        v160 = 0l;
                        while (while_method_0(v160)){
                            unsigned long long v162;
                            v162 = (unsigned long long)v160;
                            unsigned long long v163;
                            v163 = v162 * 4ull;
                            unsigned long long v164;
                            v164 = 60ull + v163;
                            unsigned char * v165;
                            v165 = (unsigned char *)(v0+v164);
                            long * v166;
                            v166 = (long *)(v165+0ull);
                            long v167;
                            v167 = v166[0l];
                            bool v168;
                            v168 = 0l <= v160;
                            bool v170;
                            if (v168){
                                bool v169;
                                v169 = v160 < 2l;
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
                            v159.v[v160] = v167;
                            v160 += 1l ;
                        }
                        long * v172;
                        v172 = (long *)(v0+68ull);
                        long v173;
                        v173 = v172[0l];
                        v335 = US5_2(v136, v138, v139, v158, v159, v173);
                        break;
                    }
                    case 3: {
                        long * v175;
                        v175 = (long *)(v0+36ull);
                        long v176;
                        v176 = v175[0l];
                        US6 v187;
                        switch (v176) {
                            case 0: {
                                v187 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v179;
                                v179 = (long *)(v0+40ull);
                                long v180;
                                v180 = v179[0l];
                                US4 v185;
                                switch (v180) {
                                    case 0: {
                                        v185 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v185 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v185 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v187 = US6_1(v185);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v188;
                        v188 = (bool *)(v0+44ull);
                        bool v189;
                        v189 = v188[0l];
                        array<US4,2l> v190;
                        long v191;
                        v191 = 0l;
                        while (while_method_0(v191)){
                            unsigned long long v193;
                            v193 = (unsigned long long)v191;
                            unsigned long long v194;
                            v194 = v193 * 4ull;
                            unsigned long long v195;
                            v195 = 48ull + v194;
                            unsigned char * v196;
                            v196 = (unsigned char *)(v0+v195);
                            long * v197;
                            v197 = (long *)(v196+0ull);
                            long v198;
                            v198 = v197[0l];
                            US4 v203;
                            switch (v198) {
                                case 0: {
                                    v203 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v203 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v203 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v204;
                            v204 = 0l <= v191;
                            bool v206;
                            if (v204){
                                bool v205;
                                v205 = v191 < 2l;
                                v206 = v205;
                            } else {
                                v206 = false;
                            }
                            bool v207;
                            v207 = v206 == false;
                            if (v207){
                                assert("The read index needs to be in range." && v206);
                            } else {
                            }
                            v190.v[v191] = v203;
                            v191 += 1l ;
                        }
                        long * v208;
                        v208 = (long *)(v0+56ull);
                        long v209;
                        v209 = v208[0l];
                        array<long,2l> v210;
                        long v211;
                        v211 = 0l;
                        while (while_method_0(v211)){
                            unsigned long long v213;
                            v213 = (unsigned long long)v211;
                            unsigned long long v214;
                            v214 = v213 * 4ull;
                            unsigned long long v215;
                            v215 = 60ull + v214;
                            unsigned char * v216;
                            v216 = (unsigned char *)(v0+v215);
                            long * v217;
                            v217 = (long *)(v216+0ull);
                            long v218;
                            v218 = v217[0l];
                            bool v219;
                            v219 = 0l <= v211;
                            bool v221;
                            if (v219){
                                bool v220;
                                v220 = v211 < 2l;
                                v221 = v220;
                            } else {
                                v221 = false;
                            }
                            bool v222;
                            v222 = v221 == false;
                            if (v222){
                                assert("The read index needs to be in range." && v221);
                            } else {
                            }
                            v210.v[v211] = v218;
                            v211 += 1l ;
                        }
                        long * v223;
                        v223 = (long *)(v0+68ull);
                        long v224;
                        v224 = v223[0l];
                        long * v225;
                        v225 = (long *)(v0+72ull);
                        long v226;
                        v226 = v225[0l];
                        US1 v231;
                        switch (v226) {
                            case 0: {
                                v231 = US1_0();
                                break;
                            }
                            case 1: {
                                v231 = US1_1();
                                break;
                            }
                            case 2: {
                                v231 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v335 = US5_3(v187, v189, v190, v209, v210, v224, v231);
                        break;
                    }
                    case 4: {
                        long * v233;
                        v233 = (long *)(v0+36ull);
                        long v234;
                        v234 = v233[0l];
                        US6 v245;
                        switch (v234) {
                            case 0: {
                                v245 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v237;
                                v237 = (long *)(v0+40ull);
                                long v238;
                                v238 = v237[0l];
                                US4 v243;
                                switch (v238) {
                                    case 0: {
                                        v243 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v243 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v243 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v245 = US6_1(v243);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v246;
                        v246 = (bool *)(v0+44ull);
                        bool v247;
                        v247 = v246[0l];
                        array<US4,2l> v248;
                        long v249;
                        v249 = 0l;
                        while (while_method_0(v249)){
                            unsigned long long v251;
                            v251 = (unsigned long long)v249;
                            unsigned long long v252;
                            v252 = v251 * 4ull;
                            unsigned long long v253;
                            v253 = 48ull + v252;
                            unsigned char * v254;
                            v254 = (unsigned char *)(v0+v253);
                            long * v255;
                            v255 = (long *)(v254+0ull);
                            long v256;
                            v256 = v255[0l];
                            US4 v261;
                            switch (v256) {
                                case 0: {
                                    v261 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v261 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v261 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v262;
                            v262 = 0l <= v249;
                            bool v264;
                            if (v262){
                                bool v263;
                                v263 = v249 < 2l;
                                v264 = v263;
                            } else {
                                v264 = false;
                            }
                            bool v265;
                            v265 = v264 == false;
                            if (v265){
                                assert("The read index needs to be in range." && v264);
                            } else {
                            }
                            v248.v[v249] = v261;
                            v249 += 1l ;
                        }
                        long * v266;
                        v266 = (long *)(v0+56ull);
                        long v267;
                        v267 = v266[0l];
                        array<long,2l> v268;
                        long v269;
                        v269 = 0l;
                        while (while_method_0(v269)){
                            unsigned long long v271;
                            v271 = (unsigned long long)v269;
                            unsigned long long v272;
                            v272 = v271 * 4ull;
                            unsigned long long v273;
                            v273 = 60ull + v272;
                            unsigned char * v274;
                            v274 = (unsigned char *)(v0+v273);
                            long * v275;
                            v275 = (long *)(v274+0ull);
                            long v276;
                            v276 = v275[0l];
                            bool v277;
                            v277 = 0l <= v269;
                            bool v279;
                            if (v277){
                                bool v278;
                                v278 = v269 < 2l;
                                v279 = v278;
                            } else {
                                v279 = false;
                            }
                            bool v280;
                            v280 = v279 == false;
                            if (v280){
                                assert("The read index needs to be in range." && v279);
                            } else {
                            }
                            v268.v[v269] = v276;
                            v269 += 1l ;
                        }
                        long * v281;
                        v281 = (long *)(v0+68ull);
                        long v282;
                        v282 = v281[0l];
                        v335 = US5_4(v245, v247, v248, v267, v268, v282);
                        break;
                    }
                    case 5: {
                        long * v284;
                        v284 = (long *)(v0+36ull);
                        long v285;
                        v285 = v284[0l];
                        US6 v296;
                        switch (v285) {
                            case 0: {
                                v296 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v288;
                                v288 = (long *)(v0+40ull);
                                long v289;
                                v289 = v288[0l];
                                US4 v294;
                                switch (v289) {
                                    case 0: {
                                        v294 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v294 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v294 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v296 = US6_1(v294);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v297;
                        v297 = (bool *)(v0+44ull);
                        bool v298;
                        v298 = v297[0l];
                        array<US4,2l> v299;
                        long v300;
                        v300 = 0l;
                        while (while_method_0(v300)){
                            unsigned long long v302;
                            v302 = (unsigned long long)v300;
                            unsigned long long v303;
                            v303 = v302 * 4ull;
                            unsigned long long v304;
                            v304 = 48ull + v303;
                            unsigned char * v305;
                            v305 = (unsigned char *)(v0+v304);
                            long * v306;
                            v306 = (long *)(v305+0ull);
                            long v307;
                            v307 = v306[0l];
                            US4 v312;
                            switch (v307) {
                                case 0: {
                                    v312 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v312 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v312 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v313;
                            v313 = 0l <= v300;
                            bool v315;
                            if (v313){
                                bool v314;
                                v314 = v300 < 2l;
                                v315 = v314;
                            } else {
                                v315 = false;
                            }
                            bool v316;
                            v316 = v315 == false;
                            if (v316){
                                assert("The read index needs to be in range." && v315);
                            } else {
                            }
                            v299.v[v300] = v312;
                            v300 += 1l ;
                        }
                        long * v317;
                        v317 = (long *)(v0+56ull);
                        long v318;
                        v318 = v317[0l];
                        array<long,2l> v319;
                        long v320;
                        v320 = 0l;
                        while (while_method_0(v320)){
                            unsigned long long v322;
                            v322 = (unsigned long long)v320;
                            unsigned long long v323;
                            v323 = v322 * 4ull;
                            unsigned long long v324;
                            v324 = 60ull + v323;
                            unsigned char * v325;
                            v325 = (unsigned char *)(v0+v324);
                            long * v326;
                            v326 = (long *)(v325+0ull);
                            long v327;
                            v327 = v326[0l];
                            bool v328;
                            v328 = 0l <= v320;
                            bool v330;
                            if (v328){
                                bool v329;
                                v329 = v320 < 2l;
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
                            v319.v[v320] = v327;
                            v320 += 1l ;
                        }
                        long * v332;
                        v332 = (long *)(v0+68ull);
                        long v333;
                        v333 = v332[0l];
                        v335 = US5_5(v296, v298, v299, v318, v319, v333);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v337 = US3_1(v42, v43, v335);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        array<US7,32l> v338;
        long v339 = 0l;
        long * v340;
        v340 = (long *)(v0+76ull);
        long v341;
        v341 = v340[0l];
        long & v342 = v339;
        v339 = v341;
        long & v343 = v339;
        long v344;
        v344 = 0l;
        while (while_method_1(v343, v344)){
            unsigned long long v346;
            v346 = (unsigned long long)v344;
            unsigned long long v347;
            v347 = v346 * 32ull;
            unsigned long long v348;
            v348 = 80ull + v347;
            unsigned char * v349;
            v349 = (unsigned char *)(v0+v348);
            long * v350;
            v350 = (long *)(v349+0ull);
            long v351;
            v351 = v350[0l];
            US7 v404;
            switch (v351) {
                case 0: {
                    long * v353;
                    v353 = (long *)(v349+4ull);
                    long v354;
                    v354 = v353[0l];
                    US4 v359;
                    switch (v354) {
                        case 0: {
                            v359 = US4_0();
                            break;
                        }
                        case 1: {
                            v359 = US4_1();
                            break;
                        }
                        case 2: {
                            v359 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v404 = US7_0(v359);
                    break;
                }
                case 1: {
                    long * v361;
                    v361 = (long *)(v349+4ull);
                    long v362;
                    v362 = v361[0l];
                    long * v363;
                    v363 = (long *)(v349+8ull);
                    long v364;
                    v364 = v363[0l];
                    US1 v369;
                    switch (v364) {
                        case 0: {
                            v369 = US1_0();
                            break;
                        }
                        case 1: {
                            v369 = US1_1();
                            break;
                        }
                        case 2: {
                            v369 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v404 = US7_1(v362, v369);
                    break;
                }
                case 2: {
                    long * v371;
                    v371 = (long *)(v349+4ull);
                    long v372;
                    v372 = v371[0l];
                    long * v373;
                    v373 = (long *)(v349+8ull);
                    long v374;
                    v374 = v373[0l];
                    US4 v379;
                    switch (v374) {
                        case 0: {
                            v379 = US4_0();
                            break;
                        }
                        case 1: {
                            v379 = US4_1();
                            break;
                        }
                        case 2: {
                            v379 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v404 = US7_2(v372, v379);
                    break;
                }
                case 3: {
                    array<US4,2l> v381;
                    long v382;
                    v382 = 0l;
                    while (while_method_0(v382)){
                        unsigned long long v384;
                        v384 = (unsigned long long)v382;
                        unsigned long long v385;
                        v385 = v384 * 4ull;
                        unsigned long long v386;
                        v386 = 4ull + v385;
                        unsigned char * v387;
                        v387 = (unsigned char *)(v349+v386);
                        long * v388;
                        v388 = (long *)(v387+0ull);
                        long v389;
                        v389 = v388[0l];
                        US4 v394;
                        switch (v389) {
                            case 0: {
                                v394 = US4_0();
                                break;
                            }
                            case 1: {
                                v394 = US4_1();
                                break;
                            }
                            case 2: {
                                v394 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool v395;
                        v395 = 0l <= v382;
                        bool v397;
                        if (v395){
                            bool v396;
                            v396 = v382 < 2l;
                            v397 = v396;
                        } else {
                            v397 = false;
                        }
                        bool v398;
                        v398 = v397 == false;
                        if (v398){
                            assert("The read index needs to be in range." && v397);
                        } else {
                        }
                        v381.v[v382] = v394;
                        v382 += 1l ;
                    }
                    long * v399;
                    v399 = (long *)(v349+12ull);
                    long v400;
                    v400 = v399[0l];
                    long * v401;
                    v401 = (long *)(v349+16ull);
                    long v402;
                    v402 = v401[0l];
                    v404 = US7_3(v381, v400, v402);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v405;
            v405 = 0l <= v344;
            bool v408;
            if (v405){
                long & v406 = v339;
                bool v407;
                v407 = v344 < v406;
                v408 = v407;
            } else {
                v408 = false;
            }
            bool v409;
            v409 = v408 == false;
            if (v409){
                assert("The set index needs to be in range." && v408);
            } else {
            }
            bool v411;
            if (v405){
                bool v410;
                v410 = v344 < 32l;
                v411 = v410;
            } else {
                v411 = false;
            }
            bool v412;
            v412 = v411 == false;
            if (v412){
                assert("The read index needs to be in range." && v411);
            } else {
            }
            v338.v[v344] = v404;
            v344 += 1l ;
        }
        array<US2,2l> v413;
        long v414;
        v414 = 0l;
        while (while_method_0(v414)){
            unsigned long long v416;
            v416 = (unsigned long long)v414;
            unsigned long long v417;
            v417 = v416 * 4ull;
            unsigned long long v418;
            v418 = 1104ull + v417;
            unsigned char * v419;
            v419 = (unsigned char *)(v0+v418);
            long * v420;
            v420 = (long *)(v419+0ull);
            long v421;
            v421 = v420[0l];
            US2 v425;
            switch (v421) {
                case 0: {
                    v425 = US2_0();
                    break;
                }
                case 1: {
                    v425 = US2_1();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v426;
            v426 = 0l <= v414;
            bool v428;
            if (v426){
                bool v427;
                v427 = v414 < 2l;
                v428 = v427;
            } else {
                v428 = false;
            }
            bool v429;
            v429 = v428 == false;
            if (v429){
                assert("The read index needs to be in range." && v428);
            } else {
            }
            v413.v[v414] = v425;
            v414 += 1l ;
        }
        long * v430;
        v430 = (long *)(v0+1112ull);
        long v431;
        v431 = v430[0l];
        US8 v536;
        switch (v431) {
            case 0: {
                v536 = US8_0();
                break;
            }
            case 1: {
                long * v434;
                v434 = (long *)(v0+1116ull);
                long v435;
                v435 = v434[0l];
                US6 v446;
                switch (v435) {
                    case 0: {
                        v446 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v438;
                        v438 = (long *)(v0+1120ull);
                        long v439;
                        v439 = v438[0l];
                        US4 v444;
                        switch (v439) {
                            case 0: {
                                v444 = US4_0();
                                break;
                            }
                            case 1: {
                                v444 = US4_1();
                                break;
                            }
                            case 2: {
                                v444 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v446 = US6_1(v444);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v447;
                v447 = (bool *)(v0+1124ull);
                bool v448;
                v448 = v447[0l];
                array<US4,2l> v449;
                long v450;
                v450 = 0l;
                while (while_method_0(v450)){
                    unsigned long long v452;
                    v452 = (unsigned long long)v450;
                    unsigned long long v453;
                    v453 = v452 * 4ull;
                    unsigned long long v454;
                    v454 = 1128ull + v453;
                    unsigned char * v455;
                    v455 = (unsigned char *)(v0+v454);
                    long * v456;
                    v456 = (long *)(v455+0ull);
                    long v457;
                    v457 = v456[0l];
                    US4 v462;
                    switch (v457) {
                        case 0: {
                            v462 = US4_0();
                            break;
                        }
                        case 1: {
                            v462 = US4_1();
                            break;
                        }
                        case 2: {
                            v462 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v463;
                    v463 = 0l <= v450;
                    bool v465;
                    if (v463){
                        bool v464;
                        v464 = v450 < 2l;
                        v465 = v464;
                    } else {
                        v465 = false;
                    }
                    bool v466;
                    v466 = v465 == false;
                    if (v466){
                        assert("The read index needs to be in range." && v465);
                    } else {
                    }
                    v449.v[v450] = v462;
                    v450 += 1l ;
                }
                long * v467;
                v467 = (long *)(v0+1136ull);
                long v468;
                v468 = v467[0l];
                array<long,2l> v469;
                long v470;
                v470 = 0l;
                while (while_method_0(v470)){
                    unsigned long long v472;
                    v472 = (unsigned long long)v470;
                    unsigned long long v473;
                    v473 = v472 * 4ull;
                    unsigned long long v474;
                    v474 = 1140ull + v473;
                    unsigned char * v475;
                    v475 = (unsigned char *)(v0+v474);
                    long * v476;
                    v476 = (long *)(v475+0ull);
                    long v477;
                    v477 = v476[0l];
                    bool v478;
                    v478 = 0l <= v470;
                    bool v480;
                    if (v478){
                        bool v479;
                        v479 = v470 < 2l;
                        v480 = v479;
                    } else {
                        v480 = false;
                    }
                    bool v481;
                    v481 = v480 == false;
                    if (v481){
                        assert("The read index needs to be in range." && v480);
                    } else {
                    }
                    v469.v[v470] = v477;
                    v470 += 1l ;
                }
                long * v482;
                v482 = (long *)(v0+1148ull);
                long v483;
                v483 = v482[0l];
                v536 = US8_1(v446, v448, v449, v468, v469, v483);
                break;
            }
            case 2: {
                long * v485;
                v485 = (long *)(v0+1116ull);
                long v486;
                v486 = v485[0l];
                US6 v497;
                switch (v486) {
                    case 0: {
                        v497 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v489;
                        v489 = (long *)(v0+1120ull);
                        long v490;
                        v490 = v489[0l];
                        US4 v495;
                        switch (v490) {
                            case 0: {
                                v495 = US4_0();
                                break;
                            }
                            case 1: {
                                v495 = US4_1();
                                break;
                            }
                            case 2: {
                                v495 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v497 = US6_1(v495);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v498;
                v498 = (bool *)(v0+1124ull);
                bool v499;
                v499 = v498[0l];
                array<US4,2l> v500;
                long v501;
                v501 = 0l;
                while (while_method_0(v501)){
                    unsigned long long v503;
                    v503 = (unsigned long long)v501;
                    unsigned long long v504;
                    v504 = v503 * 4ull;
                    unsigned long long v505;
                    v505 = 1128ull + v504;
                    unsigned char * v506;
                    v506 = (unsigned char *)(v0+v505);
                    long * v507;
                    v507 = (long *)(v506+0ull);
                    long v508;
                    v508 = v507[0l];
                    US4 v513;
                    switch (v508) {
                        case 0: {
                            v513 = US4_0();
                            break;
                        }
                        case 1: {
                            v513 = US4_1();
                            break;
                        }
                        case 2: {
                            v513 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v514;
                    v514 = 0l <= v501;
                    bool v516;
                    if (v514){
                        bool v515;
                        v515 = v501 < 2l;
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
                    v500.v[v501] = v513;
                    v501 += 1l ;
                }
                long * v518;
                v518 = (long *)(v0+1136ull);
                long v519;
                v519 = v518[0l];
                array<long,2l> v520;
                long v521;
                v521 = 0l;
                while (while_method_0(v521)){
                    unsigned long long v523;
                    v523 = (unsigned long long)v521;
                    unsigned long long v524;
                    v524 = v523 * 4ull;
                    unsigned long long v525;
                    v525 = 1140ull + v524;
                    unsigned char * v526;
                    v526 = (unsigned char *)(v0+v525);
                    long * v527;
                    v527 = (long *)(v526+0ull);
                    long v528;
                    v528 = v527[0l];
                    bool v529;
                    v529 = 0l <= v521;
                    bool v531;
                    if (v529){
                        bool v530;
                        v530 = v521 < 2l;
                        v531 = v530;
                    } else {
                        v531 = false;
                    }
                    bool v532;
                    v532 = v531 == false;
                    if (v532){
                        assert("The read index needs to be in range." && v531);
                    } else {
                    }
                    v520.v[v521] = v528;
                    v521 += 1l ;
                }
                long * v533;
                v533 = (long *)(v0+1148ull);
                long v534;
                v534 = v533[0l];
                v536 = US8_2(v497, v499, v500, v519, v520, v534);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        US3 v670; array<US7,32l> v671; long & v672; array<US2,2l> v673; US8 v674;
        switch (v37.tag) {
            case 0: { // ActionSelected
                US1 v624 = v37.v.case0.v0;
                switch (v337.tag) {
                    case 0: { // None
                        v670 = v337; v671 = v338; v672 = v339; v673 = v413; v674 = v536;
                        break;
                    }
                    default: { // Some
                        array<US4,6l> v625 = v337.v.case1.v0; long & v626 = v337.v.case1.v1; US5 v627 = v337.v.case1.v2;
                        switch (v627.tag) {
                            case 2: { // Round
                                US6 v628 = v627.v.case2.v0; bool v629 = v627.v.case2.v1; array<US4,2l> v630 = v627.v.case2.v2; long v631 = v627.v.case2.v3; array<long,2l> v632 = v627.v.case2.v4; long v633 = v627.v.case2.v5;
                                US5 v634;
                                v634 = US5_3(v628, v629, v630, v631, v632, v633, v624);
                                Tuple0 tmp9 = play_loop_0(v337, v338, v339, v413, v536, v625, v626, v634);
                                v670 = tmp9.v0; v671 = tmp9.v1; v672 = tmp9.v2; v673 = tmp9.v3; v674 = tmp9.v4;
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
                array<US2,2l> v623 = v37.v.case1.v0;
                v670 = v337; v671 = v338; v672 = v339; v673 = v623; v674 = v536;
                break;
            }
            default: { // StartGame
                array<US2,2l> v537;
                US2 v538;
                v538 = US2_0();
                v537.v[0l] = v538;
                US2 v539;
                v539 = US2_1();
                v537.v[1l] = v539;
                array<US7,32l> v540;
                long v541 = 0l;
                US3 v542;
                v542 = US3_0();
                US8 v543;
                v543 = US8_0();
                array<US4,6l> v544;
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
                US4 v550;
                v550 = US4_1();
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
                US4 v554;
                v554 = US4_1();
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
                US4 v558;
                v558 = US4_2();
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
                US4 v562;
                v562 = US4_2();
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
                US4 v566;
                v566 = US4_0();
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
                US4 v570;
                v570 = US4_0();
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
                while (while_method_1(v575, v576)){
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
                    US4 v593;
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
                    US4 v602;
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
                US5 v617;
                v617 = US5_1();
                Tuple0 tmp10 = play_loop_0(v542, v540, v541, v537, v543, v544, v545, v617);
                v670 = tmp10.v0; v671 = tmp10.v1; v672 = tmp10.v2; v673 = tmp10.v3; v674 = tmp10.v4;
            }
        }
        long v675;
        v675 = v670.tag;
        long * v676;
        v676 = (long *)(v0+0ull);
        v676[0l] = v675;
        switch (v670.tag) {
            case 0: { // None
                break;
            }
            default: { // Some
                array<US4,6l> v677 = v670.v.case1.v0; long & v678 = v670.v.case1.v1; US5 v679 = v670.v.case1.v2;
                long & v680 = v678;
                long * v681;
                v681 = (long *)(v0+4ull);
                v681[0l] = v680;
                long & v682 = v678;
                long v683;
                v683 = 0l;
                while (while_method_1(v682, v683)){
                    unsigned long long v685;
                    v685 = (unsigned long long)v683;
                    unsigned long long v686;
                    v686 = v685 * 4ull;
                    unsigned long long v687;
                    v687 = 8ull + v686;
                    unsigned char * v688;
                    v688 = (unsigned char *)(v0+v687);
                    bool v689;
                    v689 = 0l <= v683;
                    bool v692;
                    if (v689){
                        long & v690 = v678;
                        bool v691;
                        v691 = v683 < v690;
                        v692 = v691;
                    } else {
                        v692 = false;
                    }
                    bool v693;
                    v693 = v692 == false;
                    if (v693){
                        assert("The read index needs to be in range." && v692);
                    } else {
                    }
                    bool v695;
                    if (v689){
                        bool v694;
                        v694 = v683 < 6l;
                        v695 = v694;
                    } else {
                        v695 = false;
                    }
                    bool v696;
                    v696 = v695 == false;
                    if (v696){
                        assert("The read index needs to be in range." && v695);
                    } else {
                    }
                    US4 v697;
                    v697 = v677.v[v683];
                    long v698;
                    v698 = v697.tag;
                    long * v699;
                    v699 = (long *)(v688+0ull);
                    v699[0l] = v698;
                    switch (v697.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v683 += 1l ;
                }
                long v700;
                v700 = v679.tag;
                long * v701;
                v701 = (long *)(v0+32ull);
                v701[0l] = v700;
                switch (v679.tag) {
                    case 0: { // ChanceCommunityCard
                        US6 v702 = v679.v.case0.v0; bool v703 = v679.v.case0.v1; array<US4,2l> v704 = v679.v.case0.v2; long v705 = v679.v.case0.v3; array<long,2l> v706 = v679.v.case0.v4; long v707 = v679.v.case0.v5;
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
                    case 1: { // ChanceInit
                        break;
                    }
                    case 2: { // Round
                        US6 v741 = v679.v.case2.v0; bool v742 = v679.v.case2.v1; array<US4,2l> v743 = v679.v.case2.v2; long v744 = v679.v.case2.v3; array<long,2l> v745 = v679.v.case2.v4; long v746 = v679.v.case2.v5;
                        long v747;
                        v747 = v741.tag;
                        long * v748;
                        v748 = (long *)(v0+36ull);
                        v748[0l] = v747;
                        switch (v741.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v749 = v741.v.case1.v0;
                                long v750;
                                v750 = v749.tag;
                                long * v751;
                                v751 = (long *)(v0+40ull);
                                v751[0l] = v750;
                                switch (v749.tag) {
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
                        bool * v752;
                        v752 = (bool *)(v0+44ull);
                        v752[0l] = v742;
                        long v753;
                        v753 = 0l;
                        while (while_method_0(v753)){
                            unsigned long long v755;
                            v755 = (unsigned long long)v753;
                            unsigned long long v756;
                            v756 = v755 * 4ull;
                            unsigned long long v757;
                            v757 = 48ull + v756;
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
                                assert("The read index needs to be in range." && v761);
                            } else {
                            }
                            US4 v763;
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
                                default: { // Queen
                                }
                            }
                            v753 += 1l ;
                        }
                        long * v766;
                        v766 = (long *)(v0+56ull);
                        v766[0l] = v744;
                        long v767;
                        v767 = 0l;
                        while (while_method_0(v767)){
                            unsigned long long v769;
                            v769 = (unsigned long long)v767;
                            unsigned long long v770;
                            v770 = v769 * 4ull;
                            unsigned long long v771;
                            v771 = 60ull + v770;
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
                                assert("The read index needs to be in range." && v775);
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
                        v779 = (long *)(v0+68ull);
                        v779[0l] = v746;
                        break;
                    }
                    case 3: { // RoundWithAction
                        US6 v780 = v679.v.case3.v0; bool v781 = v679.v.case3.v1; array<US4,2l> v782 = v679.v.case3.v2; long v783 = v679.v.case3.v3; array<long,2l> v784 = v679.v.case3.v4; long v785 = v679.v.case3.v5; US1 v786 = v679.v.case3.v6;
                        long v787;
                        v787 = v780.tag;
                        long * v788;
                        v788 = (long *)(v0+36ull);
                        v788[0l] = v787;
                        switch (v780.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v789 = v780.v.case1.v0;
                                long v790;
                                v790 = v789.tag;
                                long * v791;
                                v791 = (long *)(v0+40ull);
                                v791[0l] = v790;
                                switch (v789.tag) {
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
                        bool * v792;
                        v792 = (bool *)(v0+44ull);
                        v792[0l] = v781;
                        long v793;
                        v793 = 0l;
                        while (while_method_0(v793)){
                            unsigned long long v795;
                            v795 = (unsigned long long)v793;
                            unsigned long long v796;
                            v796 = v795 * 4ull;
                            unsigned long long v797;
                            v797 = 48ull + v796;
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
                                assert("The read index needs to be in range." && v801);
                            } else {
                            }
                            US4 v803;
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
                                default: { // Queen
                                }
                            }
                            v793 += 1l ;
                        }
                        long * v806;
                        v806 = (long *)(v0+56ull);
                        v806[0l] = v783;
                        long v807;
                        v807 = 0l;
                        while (while_method_0(v807)){
                            unsigned long long v809;
                            v809 = (unsigned long long)v807;
                            unsigned long long v810;
                            v810 = v809 * 4ull;
                            unsigned long long v811;
                            v811 = 60ull + v810;
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
                                assert("The read index needs to be in range." && v815);
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
                        v819 = (long *)(v0+68ull);
                        v819[0l] = v785;
                        long v820;
                        v820 = v786.tag;
                        long * v821;
                        v821 = (long *)(v0+72ull);
                        v821[0l] = v820;
                        switch (v786.tag) {
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
                        US6 v822 = v679.v.case4.v0; bool v823 = v679.v.case4.v1; array<US4,2l> v824 = v679.v.case4.v2; long v825 = v679.v.case4.v3; array<long,2l> v826 = v679.v.case4.v4; long v827 = v679.v.case4.v5;
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
                        break;
                    }
                    default: { // TerminalFold
                        US6 v861 = v679.v.case5.v0; bool v862 = v679.v.case5.v1; array<US4,2l> v863 = v679.v.case5.v2; long v864 = v679.v.case5.v3; array<long,2l> v865 = v679.v.case5.v4; long v866 = v679.v.case5.v5;
                        long v867;
                        v867 = v861.tag;
                        long * v868;
                        v868 = (long *)(v0+36ull);
                        v868[0l] = v867;
                        switch (v861.tag) {
                            case 0: { // None
                                break;
                            }
                            default: { // Some
                                US4 v869 = v861.v.case1.v0;
                                long v870;
                                v870 = v869.tag;
                                long * v871;
                                v871 = (long *)(v0+40ull);
                                v871[0l] = v870;
                                switch (v869.tag) {
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
                        bool * v872;
                        v872 = (bool *)(v0+44ull);
                        v872[0l] = v862;
                        long v873;
                        v873 = 0l;
                        while (while_method_0(v873)){
                            unsigned long long v875;
                            v875 = (unsigned long long)v873;
                            unsigned long long v876;
                            v876 = v875 * 4ull;
                            unsigned long long v877;
                            v877 = 48ull + v876;
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
                                assert("The read index needs to be in range." && v881);
                            } else {
                            }
                            US4 v883;
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
                                default: { // Queen
                                }
                            }
                            v873 += 1l ;
                        }
                        long * v886;
                        v886 = (long *)(v0+56ull);
                        v886[0l] = v864;
                        long v887;
                        v887 = 0l;
                        while (while_method_0(v887)){
                            unsigned long long v889;
                            v889 = (unsigned long long)v887;
                            unsigned long long v890;
                            v890 = v889 * 4ull;
                            unsigned long long v891;
                            v891 = 60ull + v890;
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
                                assert("The read index needs to be in range." && v895);
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
                        v899 = (long *)(v0+68ull);
                        v899[0l] = v866;
                    }
                }
            }
        }
        long & v900 = v672;
        long * v901;
        v901 = (long *)(v0+76ull);
        v901[0l] = v900;
        long & v902 = v672;
        long v903;
        v903 = 0l;
        while (while_method_1(v902, v903)){
            unsigned long long v905;
            v905 = (unsigned long long)v903;
            unsigned long long v906;
            v906 = v905 * 32ull;
            unsigned long long v907;
            v907 = 80ull + v906;
            unsigned char * v908;
            v908 = (unsigned char *)(v0+v907);
            bool v909;
            v909 = 0l <= v903;
            bool v912;
            if (v909){
                long & v910 = v672;
                bool v911;
                v911 = v903 < v910;
                v912 = v911;
            } else {
                v912 = false;
            }
            bool v913;
            v913 = v912 == false;
            if (v913){
                assert("The read index needs to be in range." && v912);
            } else {
            }
            bool v915;
            if (v909){
                bool v914;
                v914 = v903 < 32l;
                v915 = v914;
            } else {
                v915 = false;
            }
            bool v916;
            v916 = v915 == false;
            if (v916){
                assert("The read index needs to be in range." && v915);
            } else {
            }
            US7 v917;
            v917 = v671.v[v903];
            long v918;
            v918 = v917.tag;
            long * v919;
            v919 = (long *)(v908+0ull);
            v919[0l] = v918;
            switch (v917.tag) {
                case 0: { // CommunityCardIs
                    US4 v920 = v917.v.case0.v0;
                    long v921;
                    v921 = v920.tag;
                    long * v922;
                    v922 = (long *)(v908+4ull);
                    v922[0l] = v921;
                    switch (v920.tag) {
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
                    long v923 = v917.v.case1.v0; US1 v924 = v917.v.case1.v1;
                    long * v925;
                    v925 = (long *)(v908+4ull);
                    v925[0l] = v923;
                    long v926;
                    v926 = v924.tag;
                    long * v927;
                    v927 = (long *)(v908+8ull);
                    v927[0l] = v926;
                    switch (v924.tag) {
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
                    long v928 = v917.v.case2.v0; US4 v929 = v917.v.case2.v1;
                    long * v930;
                    v930 = (long *)(v908+4ull);
                    v930[0l] = v928;
                    long v931;
                    v931 = v929.tag;
                    long * v932;
                    v932 = (long *)(v908+8ull);
                    v932[0l] = v931;
                    switch (v929.tag) {
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
                    array<US4,2l> v933 = v917.v.case3.v0; long v934 = v917.v.case3.v1; long v935 = v917.v.case3.v2;
                    long v936;
                    v936 = 0l;
                    while (while_method_0(v936)){
                        unsigned long long v938;
                        v938 = (unsigned long long)v936;
                        unsigned long long v939;
                        v939 = v938 * 4ull;
                        unsigned long long v940;
                        v940 = 4ull + v939;
                        unsigned char * v941;
                        v941 = (unsigned char *)(v908+v940);
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
                        v946 = v933.v[v936];
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
                    v949 = (long *)(v908+12ull);
                    v949[0l] = v934;
                    long * v950;
                    v950 = (long *)(v908+16ull);
                    v950[0l] = v935;
                }
            }
            v903 += 1l ;
        }
        long v951;
        v951 = 0l;
        while (while_method_0(v951)){
            unsigned long long v953;
            v953 = (unsigned long long)v951;
            unsigned long long v954;
            v954 = v953 * 4ull;
            unsigned long long v955;
            v955 = 1104ull + v954;
            unsigned char * v956;
            v956 = (unsigned char *)(v0+v955);
            bool v957;
            v957 = 0l <= v951;
            bool v959;
            if (v957){
                bool v958;
                v958 = v951 < 2l;
                v959 = v958;
            } else {
                v959 = false;
            }
            bool v960;
            v960 = v959 == false;
            if (v960){
                assert("The read index needs to be in range." && v959);
            } else {
            }
            US2 v961;
            v961 = v673.v[v951];
            long v962;
            v962 = v961.tag;
            long * v963;
            v963 = (long *)(v956+0ull);
            v963[0l] = v962;
            switch (v961.tag) {
                case 0: { // Computer
                    break;
                }
                default: { // Human
                }
            }
            v951 += 1l ;
        }
        long v964;
        v964 = v674.tag;
        long * v965;
        v965 = (long *)(v0+1112ull);
        v965[0l] = v964;
        switch (v674.tag) {
            case 0: { // GameNotStarted
                return ;
                break;
            }
            case 1: { // GameOver
                US6 v966 = v674.v.case1.v0; bool v967 = v674.v.case1.v1; array<US4,2l> v968 = v674.v.case1.v2; long v969 = v674.v.case1.v3; array<long,2l> v970 = v674.v.case1.v4; long v971 = v674.v.case1.v5;
                long v972;
                v972 = v966.tag;
                long * v973;
                v973 = (long *)(v0+1116ull);
                v973[0l] = v972;
                switch (v966.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US4 v974 = v966.v.case1.v0;
                        long v975;
                        v975 = v974.tag;
                        long * v976;
                        v976 = (long *)(v0+1120ull);
                        v976[0l] = v975;
                        switch (v974.tag) {
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
                bool * v977;
                v977 = (bool *)(v0+1124ull);
                v977[0l] = v967;
                long v978;
                v978 = 0l;
                while (while_method_0(v978)){
                    unsigned long long v980;
                    v980 = (unsigned long long)v978;
                    unsigned long long v981;
                    v981 = v980 * 4ull;
                    unsigned long long v982;
                    v982 = 1128ull + v981;
                    unsigned char * v983;
                    v983 = (unsigned char *)(v0+v982);
                    bool v984;
                    v984 = 0l <= v978;
                    bool v986;
                    if (v984){
                        bool v985;
                        v985 = v978 < 2l;
                        v986 = v985;
                    } else {
                        v986 = false;
                    }
                    bool v987;
                    v987 = v986 == false;
                    if (v987){
                        assert("The read index needs to be in range." && v986);
                    } else {
                    }
                    US4 v988;
                    v988 = v968.v[v978];
                    long v989;
                    v989 = v988.tag;
                    long * v990;
                    v990 = (long *)(v983+0ull);
                    v990[0l] = v989;
                    switch (v988.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v978 += 1l ;
                }
                long * v991;
                v991 = (long *)(v0+1136ull);
                v991[0l] = v969;
                long v992;
                v992 = 0l;
                while (while_method_0(v992)){
                    unsigned long long v994;
                    v994 = (unsigned long long)v992;
                    unsigned long long v995;
                    v995 = v994 * 4ull;
                    unsigned long long v996;
                    v996 = 1140ull + v995;
                    unsigned char * v997;
                    v997 = (unsigned char *)(v0+v996);
                    bool v998;
                    v998 = 0l <= v992;
                    bool v1000;
                    if (v998){
                        bool v999;
                        v999 = v992 < 2l;
                        v1000 = v999;
                    } else {
                        v1000 = false;
                    }
                    bool v1001;
                    v1001 = v1000 == false;
                    if (v1001){
                        assert("The read index needs to be in range." && v1000);
                    } else {
                    }
                    long v1002;
                    v1002 = v970.v[v992];
                    long * v1003;
                    v1003 = (long *)(v997+0ull);
                    v1003[0l] = v1002;
                    v992 += 1l ;
                }
                long * v1004;
                v1004 = (long *)(v0+1148ull);
                v1004[0l] = v971;
                return ;
                break;
            }
            default: { // WaitingForActionFromPlayerId
                US6 v1005 = v674.v.case2.v0; bool v1006 = v674.v.case2.v1; array<US4,2l> v1007 = v674.v.case2.v2; long v1008 = v674.v.case2.v3; array<long,2l> v1009 = v674.v.case2.v4; long v1010 = v674.v.case2.v5;
                long v1011;
                v1011 = v1005.tag;
                long * v1012;
                v1012 = (long *)(v0+1116ull);
                v1012[0l] = v1011;
                switch (v1005.tag) {
                    case 0: { // None
                        break;
                    }
                    default: { // Some
                        US4 v1013 = v1005.v.case1.v0;
                        long v1014;
                        v1014 = v1013.tag;
                        long * v1015;
                        v1015 = (long *)(v0+1120ull);
                        v1015[0l] = v1014;
                        switch (v1013.tag) {
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
                bool * v1016;
                v1016 = (bool *)(v0+1124ull);
                v1016[0l] = v1006;
                long v1017;
                v1017 = 0l;
                while (while_method_0(v1017)){
                    unsigned long long v1019;
                    v1019 = (unsigned long long)v1017;
                    unsigned long long v1020;
                    v1020 = v1019 * 4ull;
                    unsigned long long v1021;
                    v1021 = 1128ull + v1020;
                    unsigned char * v1022;
                    v1022 = (unsigned char *)(v0+v1021);
                    bool v1023;
                    v1023 = 0l <= v1017;
                    bool v1025;
                    if (v1023){
                        bool v1024;
                        v1024 = v1017 < 2l;
                        v1025 = v1024;
                    } else {
                        v1025 = false;
                    }
                    bool v1026;
                    v1026 = v1025 == false;
                    if (v1026){
                        assert("The read index needs to be in range." && v1025);
                    } else {
                    }
                    US4 v1027;
                    v1027 = v1007.v[v1017];
                    long v1028;
                    v1028 = v1027.tag;
                    long * v1029;
                    v1029 = (long *)(v1022+0ull);
                    v1029[0l] = v1028;
                    switch (v1027.tag) {
                        case 0: { // Jack
                            break;
                        }
                        case 1: { // King
                            break;
                        }
                        default: { // Queen
                        }
                    }
                    v1017 += 1l ;
                }
                long * v1030;
                v1030 = (long *)(v0+1136ull);
                v1030[0l] = v1008;
                long v1031;
                v1031 = 0l;
                while (while_method_0(v1031)){
                    unsigned long long v1033;
                    v1033 = (unsigned long long)v1031;
                    unsigned long long v1034;
                    v1034 = v1033 * 4ull;
                    unsigned long long v1035;
                    v1035 = 1140ull + v1034;
                    unsigned char * v1036;
                    v1036 = (unsigned char *)(v0+v1035);
                    bool v1037;
                    v1037 = 0l <= v1031;
                    bool v1039;
                    if (v1037){
                        bool v1038;
                        v1038 = v1031 < 2l;
                        v1039 = v1038;
                    } else {
                        v1039 = false;
                    }
                    bool v1040;
                    v1040 = v1039 == false;
                    if (v1040){
                        assert("The read index needs to be in range." && v1039);
                    } else {
                    }
                    long v1041;
                    v1041 = v1009.v[v1031];
                    long * v1042;
                    v1042 = (long *)(v1036+0ull);
                    v1042[0l] = v1041;
                    v1031 += 1l ;
                }
                long * v1043;
                v1043 = (long *)(v0+1148ull);
                v1043[0l] = v1010;
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
class US4_0(NamedTuple): # Jack
    tag = 0
class US4_1(NamedTuple): # King
    tag = 1
class US4_2(NamedTuple): # Queen
    tag = 2
US4 = Union[US4_0, US4_1, US4_2]
class US6_0(NamedTuple): # None
    tag = 0
class US6_1(NamedTuple): # Some
    v0 : US4
    tag = 1
US6 = Union[US6_0, US6_1]
class US5_0(NamedTuple): # ChanceCommunityCard
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 0
class US5_1(NamedTuple): # ChanceInit
    tag = 1
class US5_2(NamedTuple): # Round
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
class US5_3(NamedTuple): # RoundWithAction
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    v6 : US1
    tag = 3
class US5_4(NamedTuple): # TerminalCall
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 4
class US5_5(NamedTuple): # TerminalFold
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 5
US5 = Union[US5_0, US5_1, US5_2, US5_3, US5_4, US5_5]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : list[US4]
    v1 : list
    v2 : US5
    tag = 1
US3 = Union[US3_0, US3_1]
class US7_0(NamedTuple): # CommunityCardIs
    v0 : US4
    tag = 0
class US7_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US7_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US4
    tag = 2
class US7_3(NamedTuple): # Showdown
    v0 : list[US4]
    v1 : i32
    v2 : i32
    tag = 3
US7 = Union[US7_0, US7_1, US7_2, US7_3]
class US8_0(NamedTuple): # GameNotStarted
    tag = 0
class US8_1(NamedTuple): # GameOver
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 1
class US8_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
US8 = Union[US8_0, US8_1, US8_2]
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
        v3, v4, v5, v6, v7 = method5(v1)
        match v2:
            case US0_0(v58): # ActionSelected
                match v3:
                    case US3_0(): # None
                        del v58
                        v104, v105, v106, v107, v108 = v3, v4, v5, v6, v7
                    case US3_1(v59, v60, v61): # Some
                        match v61:
                            case US5_2(v62, v63, v64, v65, v66, v67): # Round
                                del v61
                                v68 = US5_3(v62, v63, v64, v65, v66, v67, v58)
                                del v58, v62, v63, v64, v65, v66, v67
                                v104, v105, v106, v107, v108 = method12(v3, v4, v5, v6, v7, v59, v60, v68)
                            case _:
                                del v58, v59, v60, v61
                                raise Exception("Unexpected game node in ActionSelected.")
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v57): # PlayerChanged
                v104, v105, v106, v107, v108 = v3, v4, v5, v57, v7
            case US0_2(): # StartGame
                v8 = [None] * 2
                v9 = US2_0()
                v8[0] = v9
                del v9
                v10 = US2_1()
                v8[1] = v10
                del v10
                v11 = [None] * 32
                v12 = [0]
                v13 = US3_0()
                v14 = US8_0()
                v15 = [None] * 6
                v16 = [0]
                v17 = v16[0]
                del v17
                v16[0] = 6
                v18 = v16[0]
                v19 = 0 < v18
                del v18
                v20 = v19 == False
                if v20:
                    v21 = "The set index needs to be in range."
                    assert v19, v21
                    del v21
                else:
                    pass
                del v19, v20
                v22 = US4_1()
                v15[0] = v22
                del v22
                v23 = v16[0]
                v24 = 1 < v23
                del v23
                v25 = v24 == False
                if v25:
                    v26 = "The set index needs to be in range."
                    assert v24, v26
                    del v26
                else:
                    pass
                del v24, v25
                v27 = US4_1()
                v15[1] = v27
                del v27
                v28 = v16[0]
                v29 = 2 < v28
                del v28
                v30 = v29 == False
                if v30:
                    v31 = "The set index needs to be in range."
                    assert v29, v31
                    del v31
                else:
                    pass
                del v29, v30
                v32 = US4_2()
                v15[2] = v32
                del v32
                v33 = v16[0]
                v34 = 3 < v33
                del v33
                v35 = v34 == False
                if v35:
                    v36 = "The set index needs to be in range."
                    assert v34, v36
                    del v36
                else:
                    pass
                del v34, v35
                v37 = US4_2()
                v15[3] = v37
                del v37
                v38 = v16[0]
                v39 = 4 < v38
                del v38
                v40 = v39 == False
                if v40:
                    v41 = "The set index needs to be in range."
                    assert v39, v41
                    del v41
                else:
                    pass
                del v39, v40
                v42 = US4_0()
                v15[4] = v42
                del v42
                v43 = v16[0]
                v44 = 5 < v43
                del v43
                v45 = v44 == False
                if v45:
                    v46 = "The set index needs to be in range."
                    assert v44, v46
                    del v46
                else:
                    pass
                del v44, v45
                v47 = US4_0()
                v15[5] = v47
                del v47
                v48 = v16[0]
                v49 = v15[:v48]
                del v48
                random.shuffle(v49)
                v50 = v16[0]
                v15[:v50] = v49
                del v49, v50
                v51 = US5_1()
                v104, v105, v106, v107, v108 = method12(v13, v11, v12, v8, v14, v15, v16, v51)
            case _:
                raise Exception('Pattern matching miss.')
        del v2, v3, v4, v5, v6, v7
        return method19(v104, v105, v106, v107, v108)
    return inner
def Closure1():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(1152,dtype=cp.uint8)
        v4 = method0(v0)
        v5, v6, v7, v8, v9 = method5(v1)
        v10 = v4.tag
        v11 = v2[0:].view(cp.int32)
        v11[0] = v10
        del v10, v11
        match v4:
            case US0_0(v12): # ActionSelected
                v13 = v12.tag
                v14 = v2[4:].view(cp.int32)
                v14[0] = v13
                del v13, v14
                match v12:
                    case US1_0(): # Call
                        del v12
                    case US1_1(): # Fold
                        del v12
                    case US1_2(): # Raise
                        del v12
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v15): # PlayerChanged
                v16 = 0
                while method14(v16):
                    v18 = u64(v16)
                    v19 = v18 * 4
                    del v18
                    v20 = 4 + v19
                    del v19
                    v21 = v2[v20:].view(cp.uint8)
                    del v20
                    v22 = 0 <= v16
                    if v22:
                        v23 = v16 < 2
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
                    v27 = v15[v16]
                    v28 = v27.tag
                    v29 = v21[0:].view(cp.int32)
                    del v21
                    v29[0] = v28
                    del v28, v29
                    match v27:
                        case US2_0(): # Computer
                            pass
                        case US2_1(): # Human
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v27
                    v16 += 1 
                del v15, v16
            case US0_2(): # StartGame
                pass
            case _:
                raise Exception('Pattern matching miss.')
        del v4
        v30 = v5.tag
        v31 = v3[0:].view(cp.int32)
        v31[0] = v30
        del v30, v31
        match v5:
            case US3_0(): # None
                pass
            case US3_1(v32, v33, v34): # Some
                v35 = v33[0]
                v36 = v3[4:].view(cp.int32)
                v36[0] = v35
                del v35, v36
                v37 = v33[0]
                v38 = 0
                while method3(v37, v38):
                    v40 = u64(v38)
                    v41 = v40 * 4
                    del v40
                    v42 = 8 + v41
                    del v41
                    v43 = v3[v42:].view(cp.uint8)
                    del v42
                    v44 = 0 <= v38
                    if v44:
                        v45 = v33[0]
                        v46 = v38 < v45
                        del v45
                        v47 = v46
                    else:
                        v47 = False
                    v48 = v47 == False
                    if v48:
                        v49 = "The read index needs to be in range."
                        assert v47, v49
                        del v49
                    else:
                        pass
                    del v47, v48
                    if v44:
                        v50 = v38 < 6
                        v51 = v50
                    else:
                        v51 = False
                    del v44
                    v52 = v51 == False
                    if v52:
                        v53 = "The read index needs to be in range."
                        assert v51, v53
                        del v53
                    else:
                        pass
                    del v51, v52
                    v54 = v32[v38]
                    v55 = v54.tag
                    v56 = v43[0:].view(cp.int32)
                    del v43
                    v56[0] = v55
                    del v55, v56
                    match v54:
                        case US4_0(): # Jack
                            pass
                        case US4_1(): # King
                            pass
                        case US4_2(): # Queen
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v54
                    v38 += 1 
                del v32, v33, v37, v38
                v57 = v34.tag
                v58 = v3[32:].view(cp.int32)
                v58[0] = v57
                del v57, v58
                match v34:
                    case US5_0(v59, v60, v61, v62, v63, v64): # ChanceCommunityCard
                        del v34
                        v65 = v59.tag
                        v66 = v3[36:].view(cp.int32)
                        v66[0] = v65
                        del v65, v66
                        match v59:
                            case US6_0(): # None
                                pass
                            case US6_1(v67): # Some
                                v68 = v67.tag
                                v69 = v3[40:].view(cp.int32)
                                v69[0] = v68
                                del v68, v69
                                match v67:
                                    case US4_0(): # Jack
                                        del v67
                                    case US4_1(): # King
                                        del v67
                                    case US4_2(): # Queen
                                        del v67
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v59
                        v70 = v3[44:].view(cp.int8)
                        v70[0] = v60
                        del v60, v70
                        v71 = 0
                        while method14(v71):
                            v73 = u64(v71)
                            v74 = v73 * 4
                            del v73
                            v75 = 48 + v74
                            del v74
                            v76 = v3[v75:].view(cp.uint8)
                            del v75
                            v77 = 0 <= v71
                            if v77:
                                v78 = v71 < 2
                                v79 = v78
                            else:
                                v79 = False
                            del v77
                            v80 = v79 == False
                            if v80:
                                v81 = "The read index needs to be in range."
                                assert v79, v81
                                del v81
                            else:
                                pass
                            del v79, v80
                            v82 = v61[v71]
                            v83 = v82.tag
                            v84 = v76[0:].view(cp.int32)
                            del v76
                            v84[0] = v83
                            del v83, v84
                            match v82:
                                case US4_0(): # Jack
                                    pass
                                case US4_1(): # King
                                    pass
                                case US4_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v82
                            v71 += 1 
                        del v61, v71
                        v85 = v3[56:].view(cp.int32)
                        v85[0] = v62
                        del v62, v85
                        v86 = 0
                        while method14(v86):
                            v88 = u64(v86)
                            v89 = v88 * 4
                            del v88
                            v90 = 60 + v89
                            del v89
                            v91 = v3[v90:].view(cp.uint8)
                            del v90
                            v92 = 0 <= v86
                            if v92:
                                v93 = v86 < 2
                                v94 = v93
                            else:
                                v94 = False
                            del v92
                            v95 = v94 == False
                            if v95:
                                v96 = "The read index needs to be in range."
                                assert v94, v96
                                del v96
                            else:
                                pass
                            del v94, v95
                            v97 = v63[v86]
                            v98 = v91[0:].view(cp.int32)
                            del v91
                            v98[0] = v97
                            del v97, v98
                            v86 += 1 
                        del v63, v86
                        v99 = v3[68:].view(cp.int32)
                        v99[0] = v64
                        del v64, v99
                    case US5_1(): # ChanceInit
                        del v34
                    case US5_2(v100, v101, v102, v103, v104, v105): # Round
                        del v34
                        v106 = v100.tag
                        v107 = v3[36:].view(cp.int32)
                        v107[0] = v106
                        del v106, v107
                        match v100:
                            case US6_0(): # None
                                pass
                            case US6_1(v108): # Some
                                v109 = v108.tag
                                v110 = v3[40:].view(cp.int32)
                                v110[0] = v109
                                del v109, v110
                                match v108:
                                    case US4_0(): # Jack
                                        del v108
                                    case US4_1(): # King
                                        del v108
                                    case US4_2(): # Queen
                                        del v108
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v100
                        v111 = v3[44:].view(cp.int8)
                        v111[0] = v101
                        del v101, v111
                        v112 = 0
                        while method14(v112):
                            v114 = u64(v112)
                            v115 = v114 * 4
                            del v114
                            v116 = 48 + v115
                            del v115
                            v117 = v3[v116:].view(cp.uint8)
                            del v116
                            v118 = 0 <= v112
                            if v118:
                                v119 = v112 < 2
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
                            v123 = v102[v112]
                            v124 = v123.tag
                            v125 = v117[0:].view(cp.int32)
                            del v117
                            v125[0] = v124
                            del v124, v125
                            match v123:
                                case US4_0(): # Jack
                                    pass
                                case US4_1(): # King
                                    pass
                                case US4_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v123
                            v112 += 1 
                        del v102, v112
                        v126 = v3[56:].view(cp.int32)
                        v126[0] = v103
                        del v103, v126
                        v127 = 0
                        while method14(v127):
                            v129 = u64(v127)
                            v130 = v129 * 4
                            del v129
                            v131 = 60 + v130
                            del v130
                            v132 = v3[v131:].view(cp.uint8)
                            del v131
                            v133 = 0 <= v127
                            if v133:
                                v134 = v127 < 2
                                v135 = v134
                            else:
                                v135 = False
                            del v133
                            v136 = v135 == False
                            if v136:
                                v137 = "The read index needs to be in range."
                                assert v135, v137
                                del v137
                            else:
                                pass
                            del v135, v136
                            v138 = v104[v127]
                            v139 = v132[0:].view(cp.int32)
                            del v132
                            v139[0] = v138
                            del v138, v139
                            v127 += 1 
                        del v104, v127
                        v140 = v3[68:].view(cp.int32)
                        v140[0] = v105
                        del v105, v140
                    case US5_3(v141, v142, v143, v144, v145, v146, v147): # RoundWithAction
                        del v34
                        v148 = v141.tag
                        v149 = v3[36:].view(cp.int32)
                        v149[0] = v148
                        del v148, v149
                        match v141:
                            case US6_0(): # None
                                pass
                            case US6_1(v150): # Some
                                v151 = v150.tag
                                v152 = v3[40:].view(cp.int32)
                                v152[0] = v151
                                del v151, v152
                                match v150:
                                    case US4_0(): # Jack
                                        del v150
                                    case US4_1(): # King
                                        del v150
                                    case US4_2(): # Queen
                                        del v150
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v141
                        v153 = v3[44:].view(cp.int8)
                        v153[0] = v142
                        del v142, v153
                        v154 = 0
                        while method14(v154):
                            v156 = u64(v154)
                            v157 = v156 * 4
                            del v156
                            v158 = 48 + v157
                            del v157
                            v159 = v3[v158:].view(cp.uint8)
                            del v158
                            v160 = 0 <= v154
                            if v160:
                                v161 = v154 < 2
                                v162 = v161
                            else:
                                v162 = False
                            del v160
                            v163 = v162 == False
                            if v163:
                                v164 = "The read index needs to be in range."
                                assert v162, v164
                                del v164
                            else:
                                pass
                            del v162, v163
                            v165 = v143[v154]
                            v166 = v165.tag
                            v167 = v159[0:].view(cp.int32)
                            del v159
                            v167[0] = v166
                            del v166, v167
                            match v165:
                                case US4_0(): # Jack
                                    pass
                                case US4_1(): # King
                                    pass
                                case US4_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v165
                            v154 += 1 
                        del v143, v154
                        v168 = v3[56:].view(cp.int32)
                        v168[0] = v144
                        del v144, v168
                        v169 = 0
                        while method14(v169):
                            v171 = u64(v169)
                            v172 = v171 * 4
                            del v171
                            v173 = 60 + v172
                            del v172
                            v174 = v3[v173:].view(cp.uint8)
                            del v173
                            v175 = 0 <= v169
                            if v175:
                                v176 = v169 < 2
                                v177 = v176
                            else:
                                v177 = False
                            del v175
                            v178 = v177 == False
                            if v178:
                                v179 = "The read index needs to be in range."
                                assert v177, v179
                                del v179
                            else:
                                pass
                            del v177, v178
                            v180 = v145[v169]
                            v181 = v174[0:].view(cp.int32)
                            del v174
                            v181[0] = v180
                            del v180, v181
                            v169 += 1 
                        del v145, v169
                        v182 = v3[68:].view(cp.int32)
                        v182[0] = v146
                        del v146, v182
                        v183 = v147.tag
                        v184 = v3[72:].view(cp.int32)
                        v184[0] = v183
                        del v183, v184
                        match v147:
                            case US1_0(): # Call
                                del v147
                            case US1_1(): # Fold
                                del v147
                            case US1_2(): # Raise
                                del v147
                            case _:
                                raise Exception('Pattern matching miss.')
                    case US5_4(v185, v186, v187, v188, v189, v190): # TerminalCall
                        del v34
                        v191 = v185.tag
                        v192 = v3[36:].view(cp.int32)
                        v192[0] = v191
                        del v191, v192
                        match v185:
                            case US6_0(): # None
                                pass
                            case US6_1(v193): # Some
                                v194 = v193.tag
                                v195 = v3[40:].view(cp.int32)
                                v195[0] = v194
                                del v194, v195
                                match v193:
                                    case US4_0(): # Jack
                                        del v193
                                    case US4_1(): # King
                                        del v193
                                    case US4_2(): # Queen
                                        del v193
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v185
                        v196 = v3[44:].view(cp.int8)
                        v196[0] = v186
                        del v186, v196
                        v197 = 0
                        while method14(v197):
                            v199 = u64(v197)
                            v200 = v199 * 4
                            del v199
                            v201 = 48 + v200
                            del v200
                            v202 = v3[v201:].view(cp.uint8)
                            del v201
                            v203 = 0 <= v197
                            if v203:
                                v204 = v197 < 2
                                v205 = v204
                            else:
                                v205 = False
                            del v203
                            v206 = v205 == False
                            if v206:
                                v207 = "The read index needs to be in range."
                                assert v205, v207
                                del v207
                            else:
                                pass
                            del v205, v206
                            v208 = v187[v197]
                            v209 = v208.tag
                            v210 = v202[0:].view(cp.int32)
                            del v202
                            v210[0] = v209
                            del v209, v210
                            match v208:
                                case US4_0(): # Jack
                                    pass
                                case US4_1(): # King
                                    pass
                                case US4_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v208
                            v197 += 1 
                        del v187, v197
                        v211 = v3[56:].view(cp.int32)
                        v211[0] = v188
                        del v188, v211
                        v212 = 0
                        while method14(v212):
                            v214 = u64(v212)
                            v215 = v214 * 4
                            del v214
                            v216 = 60 + v215
                            del v215
                            v217 = v3[v216:].view(cp.uint8)
                            del v216
                            v218 = 0 <= v212
                            if v218:
                                v219 = v212 < 2
                                v220 = v219
                            else:
                                v220 = False
                            del v218
                            v221 = v220 == False
                            if v221:
                                v222 = "The read index needs to be in range."
                                assert v220, v222
                                del v222
                            else:
                                pass
                            del v220, v221
                            v223 = v189[v212]
                            v224 = v217[0:].view(cp.int32)
                            del v217
                            v224[0] = v223
                            del v223, v224
                            v212 += 1 
                        del v189, v212
                        v225 = v3[68:].view(cp.int32)
                        v225[0] = v190
                        del v190, v225
                    case US5_5(v226, v227, v228, v229, v230, v231): # TerminalFold
                        del v34
                        v232 = v226.tag
                        v233 = v3[36:].view(cp.int32)
                        v233[0] = v232
                        del v232, v233
                        match v226:
                            case US6_0(): # None
                                pass
                            case US6_1(v234): # Some
                                v235 = v234.tag
                                v236 = v3[40:].view(cp.int32)
                                v236[0] = v235
                                del v235, v236
                                match v234:
                                    case US4_0(): # Jack
                                        del v234
                                    case US4_1(): # King
                                        del v234
                                    case US4_2(): # Queen
                                        del v234
                                    case _:
                                        raise Exception('Pattern matching miss.')
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v226
                        v237 = v3[44:].view(cp.int8)
                        v237[0] = v227
                        del v227, v237
                        v238 = 0
                        while method14(v238):
                            v240 = u64(v238)
                            v241 = v240 * 4
                            del v240
                            v242 = 48 + v241
                            del v241
                            v243 = v3[v242:].view(cp.uint8)
                            del v242
                            v244 = 0 <= v238
                            if v244:
                                v245 = v238 < 2
                                v246 = v245
                            else:
                                v246 = False
                            del v244
                            v247 = v246 == False
                            if v247:
                                v248 = "The read index needs to be in range."
                                assert v246, v248
                                del v248
                            else:
                                pass
                            del v246, v247
                            v249 = v228[v238]
                            v250 = v249.tag
                            v251 = v243[0:].view(cp.int32)
                            del v243
                            v251[0] = v250
                            del v250, v251
                            match v249:
                                case US4_0(): # Jack
                                    pass
                                case US4_1(): # King
                                    pass
                                case US4_2(): # Queen
                                    pass
                                case _:
                                    raise Exception('Pattern matching miss.')
                            del v249
                            v238 += 1 
                        del v228, v238
                        v252 = v3[56:].view(cp.int32)
                        v252[0] = v229
                        del v229, v252
                        v253 = 0
                        while method14(v253):
                            v255 = u64(v253)
                            v256 = v255 * 4
                            del v255
                            v257 = 60 + v256
                            del v256
                            v258 = v3[v257:].view(cp.uint8)
                            del v257
                            v259 = 0 <= v253
                            if v259:
                                v260 = v253 < 2
                                v261 = v260
                            else:
                                v261 = False
                            del v259
                            v262 = v261 == False
                            if v262:
                                v263 = "The read index needs to be in range."
                                assert v261, v263
                                del v263
                            else:
                                pass
                            del v261, v262
                            v264 = v230[v253]
                            v265 = v258[0:].view(cp.int32)
                            del v258
                            v265[0] = v264
                            del v264, v265
                            v253 += 1 
                        del v230, v253
                        v266 = v3[68:].view(cp.int32)
                        v266[0] = v231
                        del v231, v266
                    case _:
                        raise Exception('Pattern matching miss.')
            case _:
                raise Exception('Pattern matching miss.')
        del v5
        v267 = v7[0]
        v268 = v3[76:].view(cp.int32)
        v268[0] = v267
        del v267, v268
        v269 = v7[0]
        v270 = 0
        while method3(v269, v270):
            v272 = u64(v270)
            v273 = v272 * 32
            del v272
            v274 = 80 + v273
            del v273
            v275 = v3[v274:].view(cp.uint8)
            del v274
            v276 = 0 <= v270
            if v276:
                v277 = v7[0]
                v278 = v270 < v277
                del v277
                v279 = v278
            else:
                v279 = False
            v280 = v279 == False
            if v280:
                v281 = "The read index needs to be in range."
                assert v279, v281
                del v281
            else:
                pass
            del v279, v280
            if v276:
                v282 = v270 < 32
                v283 = v282
            else:
                v283 = False
            del v276
            v284 = v283 == False
            if v284:
                v285 = "The read index needs to be in range."
                assert v283, v285
                del v285
            else:
                pass
            del v283, v284
            v286 = v6[v270]
            v287 = v286.tag
            v288 = v275[0:].view(cp.int32)
            v288[0] = v287
            del v287, v288
            match v286:
                case US7_0(v289): # CommunityCardIs
                    v290 = v289.tag
                    v291 = v275[4:].view(cp.int32)
                    v291[0] = v290
                    del v290, v291
                    match v289:
                        case US4_0(): # Jack
                            del v289
                        case US4_1(): # King
                            del v289
                        case US4_2(): # Queen
                            del v289
                        case _:
                            raise Exception('Pattern matching miss.')
                case US7_1(v292, v293): # PlayerAction
                    v294 = v275[4:].view(cp.int32)
                    v294[0] = v292
                    del v292, v294
                    v295 = v293.tag
                    v296 = v275[8:].view(cp.int32)
                    v296[0] = v295
                    del v295, v296
                    match v293:
                        case US1_0(): # Call
                            del v293
                        case US1_1(): # Fold
                            del v293
                        case US1_2(): # Raise
                            del v293
                        case _:
                            raise Exception('Pattern matching miss.')
                case US7_2(v297, v298): # PlayerGotCard
                    v299 = v275[4:].view(cp.int32)
                    v299[0] = v297
                    del v297, v299
                    v300 = v298.tag
                    v301 = v275[8:].view(cp.int32)
                    v301[0] = v300
                    del v300, v301
                    match v298:
                        case US4_0(): # Jack
                            del v298
                        case US4_1(): # King
                            del v298
                        case US4_2(): # Queen
                            del v298
                        case _:
                            raise Exception('Pattern matching miss.')
                case US7_3(v302, v303, v304): # Showdown
                    v305 = 0
                    while method14(v305):
                        v307 = u64(v305)
                        v308 = v307 * 4
                        del v307
                        v309 = 4 + v308
                        del v308
                        v310 = v275[v309:].view(cp.uint8)
                        del v309
                        v311 = 0 <= v305
                        if v311:
                            v312 = v305 < 2
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
                        v316 = v302[v305]
                        v317 = v316.tag
                        v318 = v310[0:].view(cp.int32)
                        del v310
                        v318[0] = v317
                        del v317, v318
                        match v316:
                            case US4_0(): # Jack
                                pass
                            case US4_1(): # King
                                pass
                            case US4_2(): # Queen
                                pass
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v316
                        v305 += 1 
                    del v302, v305
                    v319 = v275[12:].view(cp.int32)
                    v319[0] = v303
                    del v303, v319
                    v320 = v275[16:].view(cp.int32)
                    v320[0] = v304
                    del v304, v320
                case _:
                    raise Exception('Pattern matching miss.')
            del v275, v286
            v270 += 1 
        del v6, v7, v269, v270
        v321 = 0
        while method14(v321):
            v323 = u64(v321)
            v324 = v323 * 4
            del v323
            v325 = 1104 + v324
            del v324
            v326 = v3[v325:].view(cp.uint8)
            del v325
            v327 = 0 <= v321
            if v327:
                v328 = v321 < 2
                v329 = v328
            else:
                v329 = False
            del v327
            v330 = v329 == False
            if v330:
                v331 = "The read index needs to be in range."
                assert v329, v331
                del v331
            else:
                pass
            del v329, v330
            v332 = v8[v321]
            v333 = v332.tag
            v334 = v326[0:].view(cp.int32)
            del v326
            v334[0] = v333
            del v333, v334
            match v332:
                case US2_0(): # Computer
                    pass
                case US2_1(): # Human
                    pass
                case _:
                    raise Exception('Pattern matching miss.')
            del v332
            v321 += 1 
        del v8, v321
        v335 = v9.tag
        v336 = v3[1112:].view(cp.int32)
        v336[0] = v335
        del v335, v336
        match v9:
            case US8_0(): # GameNotStarted
                pass
            case US8_1(v337, v338, v339, v340, v341, v342): # GameOver
                v343 = v337.tag
                v344 = v3[1116:].view(cp.int32)
                v344[0] = v343
                del v343, v344
                match v337:
                    case US6_0(): # None
                        pass
                    case US6_1(v345): # Some
                        v346 = v345.tag
                        v347 = v3[1120:].view(cp.int32)
                        v347[0] = v346
                        del v346, v347
                        match v345:
                            case US4_0(): # Jack
                                del v345
                            case US4_1(): # King
                                del v345
                            case US4_2(): # Queen
                                del v345
                            case _:
                                raise Exception('Pattern matching miss.')
                    case _:
                        raise Exception('Pattern matching miss.')
                del v337
                v348 = v3[1124:].view(cp.int8)
                v348[0] = v338
                del v338, v348
                v349 = 0
                while method14(v349):
                    v351 = u64(v349)
                    v352 = v351 * 4
                    del v351
                    v353 = 1128 + v352
                    del v352
                    v354 = v3[v353:].view(cp.uint8)
                    del v353
                    v355 = 0 <= v349
                    if v355:
                        v356 = v349 < 2
                        v357 = v356
                    else:
                        v357 = False
                    del v355
                    v358 = v357 == False
                    if v358:
                        v359 = "The read index needs to be in range."
                        assert v357, v359
                        del v359
                    else:
                        pass
                    del v357, v358
                    v360 = v339[v349]
                    v361 = v360.tag
                    v362 = v354[0:].view(cp.int32)
                    del v354
                    v362[0] = v361
                    del v361, v362
                    match v360:
                        case US4_0(): # Jack
                            pass
                        case US4_1(): # King
                            pass
                        case US4_2(): # Queen
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v360
                    v349 += 1 
                del v339, v349
                v363 = v3[1136:].view(cp.int32)
                v363[0] = v340
                del v340, v363
                v364 = 0
                while method14(v364):
                    v366 = u64(v364)
                    v367 = v366 * 4
                    del v366
                    v368 = 1140 + v367
                    del v367
                    v369 = v3[v368:].view(cp.uint8)
                    del v368
                    v370 = 0 <= v364
                    if v370:
                        v371 = v364 < 2
                        v372 = v371
                    else:
                        v372 = False
                    del v370
                    v373 = v372 == False
                    if v373:
                        v374 = "The read index needs to be in range."
                        assert v372, v374
                        del v374
                    else:
                        pass
                    del v372, v373
                    v375 = v341[v364]
                    v376 = v369[0:].view(cp.int32)
                    del v369
                    v376[0] = v375
                    del v375, v376
                    v364 += 1 
                del v341, v364
                v377 = v3[1148:].view(cp.int32)
                v377[0] = v342
                del v342, v377
            case US8_2(v378, v379, v380, v381, v382, v383): # WaitingForActionFromPlayerId
                v384 = v378.tag
                v385 = v3[1116:].view(cp.int32)
                v385[0] = v384
                del v384, v385
                match v378:
                    case US6_0(): # None
                        pass
                    case US6_1(v386): # Some
                        v387 = v386.tag
                        v388 = v3[1120:].view(cp.int32)
                        v388[0] = v387
                        del v387, v388
                        match v386:
                            case US4_0(): # Jack
                                del v386
                            case US4_1(): # King
                                del v386
                            case US4_2(): # Queen
                                del v386
                            case _:
                                raise Exception('Pattern matching miss.')
                    case _:
                        raise Exception('Pattern matching miss.')
                del v378
                v389 = v3[1124:].view(cp.int8)
                v389[0] = v379
                del v379, v389
                v390 = 0
                while method14(v390):
                    v392 = u64(v390)
                    v393 = v392 * 4
                    del v392
                    v394 = 1128 + v393
                    del v393
                    v395 = v3[v394:].view(cp.uint8)
                    del v394
                    v396 = 0 <= v390
                    if v396:
                        v397 = v390 < 2
                        v398 = v397
                    else:
                        v398 = False
                    del v396
                    v399 = v398 == False
                    if v399:
                        v400 = "The read index needs to be in range."
                        assert v398, v400
                        del v400
                    else:
                        pass
                    del v398, v399
                    v401 = v380[v390]
                    v402 = v401.tag
                    v403 = v395[0:].view(cp.int32)
                    del v395
                    v403[0] = v402
                    del v402, v403
                    match v401:
                        case US4_0(): # Jack
                            pass
                        case US4_1(): # King
                            pass
                        case US4_2(): # Queen
                            pass
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v401
                    v390 += 1 
                del v380, v390
                v404 = v3[1136:].view(cp.int32)
                v404[0] = v381
                del v381, v404
                v405 = 0
                while method14(v405):
                    v407 = u64(v405)
                    v408 = v407 * 4
                    del v407
                    v409 = 1140 + v408
                    del v408
                    v410 = v3[v409:].view(cp.uint8)
                    del v409
                    v411 = 0 <= v405
                    if v411:
                        v412 = v405 < 2
                        v413 = v412
                    else:
                        v413 = False
                    del v411
                    v414 = v413 == False
                    if v414:
                        v415 = "The read index needs to be in range."
                        assert v413, v415
                        del v415
                    else:
                        pass
                    del v413, v414
                    v416 = v382[v405]
                    v417 = v410[0:].view(cp.int32)
                    del v410
                    v417[0] = v416
                    del v416, v417
                    v405 += 1 
                del v382, v405
                v418 = v3[1148:].view(cp.int32)
                v418[0] = v383
                del v383, v418
            case _:
                raise Exception('Pattern matching miss.')
        del v9
        v419 = 0
        v420 = raw_module.get_function(f"entry{v419}")
        del v419
        v420.max_dynamic_shared_size_bytes = 0 
        v420((1,),(512,),(v3, v2),shared_mem=0)
        del v2, v420
        v421 = v3[0:].view(cp.int32)
        v422 = v421[0].item()
        del v421
        if v422 == 0:
            v732 = US3_0()
        elif v422 == 1:
            v425 = [None] * 6
            v426 = [0]
            v427 = v3[4:].view(cp.int32)
            v428 = v427[0].item()
            del v427
            v429 = v426[0]
            del v429
            v426[0] = v428
            del v428
            v430 = v426[0]
            v431 = 0
            while method3(v430, v431):
                v433 = u64(v431)
                v434 = v433 * 4
                del v433
                v435 = 8 + v434
                del v434
                v436 = v3[v435:].view(cp.uint8)
                del v435
                v437 = v436[0:].view(cp.int32)
                del v436
                v438 = v437[0].item()
                del v437
                if v438 == 0:
                    v443 = US4_0()
                elif v438 == 1:
                    v443 = US4_1()
                elif v438 == 2:
                    v443 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v438
                v444 = 0 <= v431
                if v444:
                    v445 = v426[0]
                    v446 = v431 < v445
                    del v445
                    v447 = v446
                else:
                    v447 = False
                v448 = v447 == False
                if v448:
                    v449 = "The set index needs to be in range."
                    assert v447, v449
                    del v449
                else:
                    pass
                del v447, v448
                if v444:
                    v450 = v431 < 6
                    v451 = v450
                else:
                    v451 = False
                del v444
                v452 = v451 == False
                if v452:
                    v453 = "The read index needs to be in range."
                    assert v451, v453
                    del v453
                else:
                    pass
                del v451, v452
                v425[v431] = v443
                del v443
                v431 += 1 
            del v430, v431
            v454 = v3[32:].view(cp.int32)
            v455 = v454[0].item()
            del v454
            if v455 == 0:
                v457 = v3[36:].view(cp.int32)
                v458 = v457[0].item()
                del v457
                if v458 == 0:
                    v469 = US6_0()
                elif v458 == 1:
                    v461 = v3[40:].view(cp.int32)
                    v462 = v461[0].item()
                    del v461
                    if v462 == 0:
                        v467 = US4_0()
                    elif v462 == 1:
                        v467 = US4_1()
                    elif v462 == 2:
                        v467 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v462
                    v469 = US6_1(v467)
                else:
                    raise Exception("Invalid tag.")
                del v458
                v470 = v3[44:].view(cp.int8)
                v471 = v470[0].item()
                del v470
                v472 = [None] * 2
                v473 = 0
                while method14(v473):
                    v475 = u64(v473)
                    v476 = v475 * 4
                    del v475
                    v477 = 48 + v476
                    del v476
                    v478 = v3[v477:].view(cp.uint8)
                    del v477
                    v479 = v478[0:].view(cp.int32)
                    del v478
                    v480 = v479[0].item()
                    del v479
                    if v480 == 0:
                        v485 = US4_0()
                    elif v480 == 1:
                        v485 = US4_1()
                    elif v480 == 2:
                        v485 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v480
                    v486 = 0 <= v473
                    if v486:
                        v487 = v473 < 2
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
                    v472[v473] = v485
                    del v485
                    v473 += 1 
                del v473
                v491 = v3[56:].view(cp.int32)
                v492 = v491[0].item()
                del v491
                v493 = [None] * 2
                v494 = 0
                while method14(v494):
                    v496 = u64(v494)
                    v497 = v496 * 4
                    del v496
                    v498 = 60 + v497
                    del v497
                    v499 = v3[v498:].view(cp.uint8)
                    del v498
                    v500 = v499[0:].view(cp.int32)
                    del v499
                    v501 = v500[0].item()
                    del v500
                    v502 = 0 <= v494
                    if v502:
                        v503 = v494 < 2
                        v504 = v503
                    else:
                        v504 = False
                    del v502
                    v505 = v504 == False
                    if v505:
                        v506 = "The read index needs to be in range."
                        assert v504, v506
                        del v506
                    else:
                        pass
                    del v504, v505
                    v493[v494] = v501
                    del v501
                    v494 += 1 
                del v494
                v507 = v3[68:].view(cp.int32)
                v508 = v507[0].item()
                del v507
                v730 = US5_0(v469, v471, v472, v492, v493, v508)
            elif v455 == 1:
                v730 = US5_1()
            elif v455 == 2:
                v511 = v3[36:].view(cp.int32)
                v512 = v511[0].item()
                del v511
                if v512 == 0:
                    v523 = US6_0()
                elif v512 == 1:
                    v515 = v3[40:].view(cp.int32)
                    v516 = v515[0].item()
                    del v515
                    if v516 == 0:
                        v521 = US4_0()
                    elif v516 == 1:
                        v521 = US4_1()
                    elif v516 == 2:
                        v521 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v516
                    v523 = US6_1(v521)
                else:
                    raise Exception("Invalid tag.")
                del v512
                v524 = v3[44:].view(cp.int8)
                v525 = v524[0].item()
                del v524
                v526 = [None] * 2
                v527 = 0
                while method14(v527):
                    v529 = u64(v527)
                    v530 = v529 * 4
                    del v529
                    v531 = 48 + v530
                    del v530
                    v532 = v3[v531:].view(cp.uint8)
                    del v531
                    v533 = v532[0:].view(cp.int32)
                    del v532
                    v534 = v533[0].item()
                    del v533
                    if v534 == 0:
                        v539 = US4_0()
                    elif v534 == 1:
                        v539 = US4_1()
                    elif v534 == 2:
                        v539 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v534
                    v540 = 0 <= v527
                    if v540:
                        v541 = v527 < 2
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
                    v526[v527] = v539
                    del v539
                    v527 += 1 
                del v527
                v545 = v3[56:].view(cp.int32)
                v546 = v545[0].item()
                del v545
                v547 = [None] * 2
                v548 = 0
                while method14(v548):
                    v550 = u64(v548)
                    v551 = v550 * 4
                    del v550
                    v552 = 60 + v551
                    del v551
                    v553 = v3[v552:].view(cp.uint8)
                    del v552
                    v554 = v553[0:].view(cp.int32)
                    del v553
                    v555 = v554[0].item()
                    del v554
                    v556 = 0 <= v548
                    if v556:
                        v557 = v548 < 2
                        v558 = v557
                    else:
                        v558 = False
                    del v556
                    v559 = v558 == False
                    if v559:
                        v560 = "The read index needs to be in range."
                        assert v558, v560
                        del v560
                    else:
                        pass
                    del v558, v559
                    v547[v548] = v555
                    del v555
                    v548 += 1 
                del v548
                v561 = v3[68:].view(cp.int32)
                v562 = v561[0].item()
                del v561
                v730 = US5_2(v523, v525, v526, v546, v547, v562)
            elif v455 == 3:
                v564 = v3[36:].view(cp.int32)
                v565 = v564[0].item()
                del v564
                if v565 == 0:
                    v576 = US6_0()
                elif v565 == 1:
                    v568 = v3[40:].view(cp.int32)
                    v569 = v568[0].item()
                    del v568
                    if v569 == 0:
                        v574 = US4_0()
                    elif v569 == 1:
                        v574 = US4_1()
                    elif v569 == 2:
                        v574 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v569
                    v576 = US6_1(v574)
                else:
                    raise Exception("Invalid tag.")
                del v565
                v577 = v3[44:].view(cp.int8)
                v578 = v577[0].item()
                del v577
                v579 = [None] * 2
                v580 = 0
                while method14(v580):
                    v582 = u64(v580)
                    v583 = v582 * 4
                    del v582
                    v584 = 48 + v583
                    del v583
                    v585 = v3[v584:].view(cp.uint8)
                    del v584
                    v586 = v585[0:].view(cp.int32)
                    del v585
                    v587 = v586[0].item()
                    del v586
                    if v587 == 0:
                        v592 = US4_0()
                    elif v587 == 1:
                        v592 = US4_1()
                    elif v587 == 2:
                        v592 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v587
                    v593 = 0 <= v580
                    if v593:
                        v594 = v580 < 2
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
                    v579[v580] = v592
                    del v592
                    v580 += 1 
                del v580
                v598 = v3[56:].view(cp.int32)
                v599 = v598[0].item()
                del v598
                v600 = [None] * 2
                v601 = 0
                while method14(v601):
                    v603 = u64(v601)
                    v604 = v603 * 4
                    del v603
                    v605 = 60 + v604
                    del v604
                    v606 = v3[v605:].view(cp.uint8)
                    del v605
                    v607 = v606[0:].view(cp.int32)
                    del v606
                    v608 = v607[0].item()
                    del v607
                    v609 = 0 <= v601
                    if v609:
                        v610 = v601 < 2
                        v611 = v610
                    else:
                        v611 = False
                    del v609
                    v612 = v611 == False
                    if v612:
                        v613 = "The read index needs to be in range."
                        assert v611, v613
                        del v613
                    else:
                        pass
                    del v611, v612
                    v600[v601] = v608
                    del v608
                    v601 += 1 
                del v601
                v614 = v3[68:].view(cp.int32)
                v615 = v614[0].item()
                del v614
                v616 = v3[72:].view(cp.int32)
                v617 = v616[0].item()
                del v616
                if v617 == 0:
                    v622 = US1_0()
                elif v617 == 1:
                    v622 = US1_1()
                elif v617 == 2:
                    v622 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v617
                v730 = US5_3(v576, v578, v579, v599, v600, v615, v622)
            elif v455 == 4:
                v624 = v3[36:].view(cp.int32)
                v625 = v624[0].item()
                del v624
                if v625 == 0:
                    v636 = US6_0()
                elif v625 == 1:
                    v628 = v3[40:].view(cp.int32)
                    v629 = v628[0].item()
                    del v628
                    if v629 == 0:
                        v634 = US4_0()
                    elif v629 == 1:
                        v634 = US4_1()
                    elif v629 == 2:
                        v634 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v629
                    v636 = US6_1(v634)
                else:
                    raise Exception("Invalid tag.")
                del v625
                v637 = v3[44:].view(cp.int8)
                v638 = v637[0].item()
                del v637
                v639 = [None] * 2
                v640 = 0
                while method14(v640):
                    v642 = u64(v640)
                    v643 = v642 * 4
                    del v642
                    v644 = 48 + v643
                    del v643
                    v645 = v3[v644:].view(cp.uint8)
                    del v644
                    v646 = v645[0:].view(cp.int32)
                    del v645
                    v647 = v646[0].item()
                    del v646
                    if v647 == 0:
                        v652 = US4_0()
                    elif v647 == 1:
                        v652 = US4_1()
                    elif v647 == 2:
                        v652 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v647
                    v653 = 0 <= v640
                    if v653:
                        v654 = v640 < 2
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
                    v639[v640] = v652
                    del v652
                    v640 += 1 
                del v640
                v658 = v3[56:].view(cp.int32)
                v659 = v658[0].item()
                del v658
                v660 = [None] * 2
                v661 = 0
                while method14(v661):
                    v663 = u64(v661)
                    v664 = v663 * 4
                    del v663
                    v665 = 60 + v664
                    del v664
                    v666 = v3[v665:].view(cp.uint8)
                    del v665
                    v667 = v666[0:].view(cp.int32)
                    del v666
                    v668 = v667[0].item()
                    del v667
                    v669 = 0 <= v661
                    if v669:
                        v670 = v661 < 2
                        v671 = v670
                    else:
                        v671 = False
                    del v669
                    v672 = v671 == False
                    if v672:
                        v673 = "The read index needs to be in range."
                        assert v671, v673
                        del v673
                    else:
                        pass
                    del v671, v672
                    v660[v661] = v668
                    del v668
                    v661 += 1 
                del v661
                v674 = v3[68:].view(cp.int32)
                v675 = v674[0].item()
                del v674
                v730 = US5_4(v636, v638, v639, v659, v660, v675)
            elif v455 == 5:
                v677 = v3[36:].view(cp.int32)
                v678 = v677[0].item()
                del v677
                if v678 == 0:
                    v689 = US6_0()
                elif v678 == 1:
                    v681 = v3[40:].view(cp.int32)
                    v682 = v681[0].item()
                    del v681
                    if v682 == 0:
                        v687 = US4_0()
                    elif v682 == 1:
                        v687 = US4_1()
                    elif v682 == 2:
                        v687 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v682
                    v689 = US6_1(v687)
                else:
                    raise Exception("Invalid tag.")
                del v678
                v690 = v3[44:].view(cp.int8)
                v691 = v690[0].item()
                del v690
                v692 = [None] * 2
                v693 = 0
                while method14(v693):
                    v695 = u64(v693)
                    v696 = v695 * 4
                    del v695
                    v697 = 48 + v696
                    del v696
                    v698 = v3[v697:].view(cp.uint8)
                    del v697
                    v699 = v698[0:].view(cp.int32)
                    del v698
                    v700 = v699[0].item()
                    del v699
                    if v700 == 0:
                        v705 = US4_0()
                    elif v700 == 1:
                        v705 = US4_1()
                    elif v700 == 2:
                        v705 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v700
                    v706 = 0 <= v693
                    if v706:
                        v707 = v693 < 2
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
                    v692[v693] = v705
                    del v705
                    v693 += 1 
                del v693
                v711 = v3[56:].view(cp.int32)
                v712 = v711[0].item()
                del v711
                v713 = [None] * 2
                v714 = 0
                while method14(v714):
                    v716 = u64(v714)
                    v717 = v716 * 4
                    del v716
                    v718 = 60 + v717
                    del v717
                    v719 = v3[v718:].view(cp.uint8)
                    del v718
                    v720 = v719[0:].view(cp.int32)
                    del v719
                    v721 = v720[0].item()
                    del v720
                    v722 = 0 <= v714
                    if v722:
                        v723 = v714 < 2
                        v724 = v723
                    else:
                        v724 = False
                    del v722
                    v725 = v724 == False
                    if v725:
                        v726 = "The read index needs to be in range."
                        assert v724, v726
                        del v726
                    else:
                        pass
                    del v724, v725
                    v713[v714] = v721
                    del v721
                    v714 += 1 
                del v714
                v727 = v3[68:].view(cp.int32)
                v728 = v727[0].item()
                del v727
                v730 = US5_5(v689, v691, v692, v712, v713, v728)
            else:
                raise Exception("Invalid tag.")
            del v455
            v732 = US3_1(v425, v426, v730)
        else:
            raise Exception("Invalid tag.")
        del v422
        v733 = [None] * 32
        v734 = [0]
        v735 = v3[76:].view(cp.int32)
        v736 = v735[0].item()
        del v735
        v737 = v734[0]
        del v737
        v734[0] = v736
        del v736
        v738 = v734[0]
        v739 = 0
        while method3(v738, v739):
            v741 = u64(v739)
            v742 = v741 * 32
            del v741
            v743 = 80 + v742
            del v742
            v744 = v3[v743:].view(cp.uint8)
            del v743
            v745 = v744[0:].view(cp.int32)
            v746 = v745[0].item()
            del v745
            if v746 == 0:
                v748 = v744[4:].view(cp.int32)
                v749 = v748[0].item()
                del v748
                if v749 == 0:
                    v754 = US4_0()
                elif v749 == 1:
                    v754 = US4_1()
                elif v749 == 2:
                    v754 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v749
                v800 = US7_0(v754)
            elif v746 == 1:
                v756 = v744[4:].view(cp.int32)
                v757 = v756[0].item()
                del v756
                v758 = v744[8:].view(cp.int32)
                v759 = v758[0].item()
                del v758
                if v759 == 0:
                    v764 = US1_0()
                elif v759 == 1:
                    v764 = US1_1()
                elif v759 == 2:
                    v764 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v759
                v800 = US7_1(v757, v764)
            elif v746 == 2:
                v766 = v744[4:].view(cp.int32)
                v767 = v766[0].item()
                del v766
                v768 = v744[8:].view(cp.int32)
                v769 = v768[0].item()
                del v768
                if v769 == 0:
                    v774 = US4_0()
                elif v769 == 1:
                    v774 = US4_1()
                elif v769 == 2:
                    v774 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v769
                v800 = US7_2(v767, v774)
            elif v746 == 3:
                v776 = [None] * 2
                v777 = 0
                while method14(v777):
                    v779 = u64(v777)
                    v780 = v779 * 4
                    del v779
                    v781 = 4 + v780
                    del v780
                    v782 = v744[v781:].view(cp.uint8)
                    del v781
                    v783 = v782[0:].view(cp.int32)
                    del v782
                    v784 = v783[0].item()
                    del v783
                    if v784 == 0:
                        v789 = US4_0()
                    elif v784 == 1:
                        v789 = US4_1()
                    elif v784 == 2:
                        v789 = US4_2()
                    else:
                        raise Exception("Invalid tag.")
                    del v784
                    v790 = 0 <= v777
                    if v790:
                        v791 = v777 < 2
                        v792 = v791
                    else:
                        v792 = False
                    del v790
                    v793 = v792 == False
                    if v793:
                        v794 = "The read index needs to be in range."
                        assert v792, v794
                        del v794
                    else:
                        pass
                    del v792, v793
                    v776[v777] = v789
                    del v789
                    v777 += 1 
                del v777
                v795 = v744[12:].view(cp.int32)
                v796 = v795[0].item()
                del v795
                v797 = v744[16:].view(cp.int32)
                v798 = v797[0].item()
                del v797
                v800 = US7_3(v776, v796, v798)
            else:
                raise Exception("Invalid tag.")
            del v744, v746
            v801 = 0 <= v739
            if v801:
                v802 = v734[0]
                v803 = v739 < v802
                del v802
                v804 = v803
            else:
                v804 = False
            v805 = v804 == False
            if v805:
                v806 = "The set index needs to be in range."
                assert v804, v806
                del v806
            else:
                pass
            del v804, v805
            if v801:
                v807 = v739 < 32
                v808 = v807
            else:
                v808 = False
            del v801
            v809 = v808 == False
            if v809:
                v810 = "The read index needs to be in range."
                assert v808, v810
                del v810
            else:
                pass
            del v808, v809
            v733[v739] = v800
            del v800
            v739 += 1 
        del v738, v739
        v811 = [None] * 2
        v812 = 0
        while method14(v812):
            v814 = u64(v812)
            v815 = v814 * 4
            del v814
            v816 = 1104 + v815
            del v815
            v817 = v3[v816:].view(cp.uint8)
            del v816
            v818 = v817[0:].view(cp.int32)
            del v817
            v819 = v818[0].item()
            del v818
            if v819 == 0:
                v823 = US2_0()
            elif v819 == 1:
                v823 = US2_1()
            else:
                raise Exception("Invalid tag.")
            del v819
            v824 = 0 <= v812
            if v824:
                v825 = v812 < 2
                v826 = v825
            else:
                v826 = False
            del v824
            v827 = v826 == False
            if v827:
                v828 = "The read index needs to be in range."
                assert v826, v828
                del v828
            else:
                pass
            del v826, v827
            v811[v812] = v823
            del v823
            v812 += 1 
        del v812
        v829 = v3[1112:].view(cp.int32)
        v830 = v829[0].item()
        del v829
        if v830 == 0:
            v939 = US8_0()
        elif v830 == 1:
            v833 = v3[1116:].view(cp.int32)
            v834 = v833[0].item()
            del v833
            if v834 == 0:
                v845 = US6_0()
            elif v834 == 1:
                v837 = v3[1120:].view(cp.int32)
                v838 = v837[0].item()
                del v837
                if v838 == 0:
                    v843 = US4_0()
                elif v838 == 1:
                    v843 = US4_1()
                elif v838 == 2:
                    v843 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v838
                v845 = US6_1(v843)
            else:
                raise Exception("Invalid tag.")
            del v834
            v846 = v3[1124:].view(cp.int8)
            v847 = v846[0].item()
            del v846
            v848 = [None] * 2
            v849 = 0
            while method14(v849):
                v851 = u64(v849)
                v852 = v851 * 4
                del v851
                v853 = 1128 + v852
                del v852
                v854 = v3[v853:].view(cp.uint8)
                del v853
                v855 = v854[0:].view(cp.int32)
                del v854
                v856 = v855[0].item()
                del v855
                if v856 == 0:
                    v861 = US4_0()
                elif v856 == 1:
                    v861 = US4_1()
                elif v856 == 2:
                    v861 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v856
                v862 = 0 <= v849
                if v862:
                    v863 = v849 < 2
                    v864 = v863
                else:
                    v864 = False
                del v862
                v865 = v864 == False
                if v865:
                    v866 = "The read index needs to be in range."
                    assert v864, v866
                    del v866
                else:
                    pass
                del v864, v865
                v848[v849] = v861
                del v861
                v849 += 1 
            del v849
            v867 = v3[1136:].view(cp.int32)
            v868 = v867[0].item()
            del v867
            v869 = [None] * 2
            v870 = 0
            while method14(v870):
                v872 = u64(v870)
                v873 = v872 * 4
                del v872
                v874 = 1140 + v873
                del v873
                v875 = v3[v874:].view(cp.uint8)
                del v874
                v876 = v875[0:].view(cp.int32)
                del v875
                v877 = v876[0].item()
                del v876
                v878 = 0 <= v870
                if v878:
                    v879 = v870 < 2
                    v880 = v879
                else:
                    v880 = False
                del v878
                v881 = v880 == False
                if v881:
                    v882 = "The read index needs to be in range."
                    assert v880, v882
                    del v882
                else:
                    pass
                del v880, v881
                v869[v870] = v877
                del v877
                v870 += 1 
            del v870
            v883 = v3[1148:].view(cp.int32)
            v884 = v883[0].item()
            del v883
            v939 = US8_1(v845, v847, v848, v868, v869, v884)
        elif v830 == 2:
            v886 = v3[1116:].view(cp.int32)
            v887 = v886[0].item()
            del v886
            if v887 == 0:
                v898 = US6_0()
            elif v887 == 1:
                v890 = v3[1120:].view(cp.int32)
                v891 = v890[0].item()
                del v890
                if v891 == 0:
                    v896 = US4_0()
                elif v891 == 1:
                    v896 = US4_1()
                elif v891 == 2:
                    v896 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v891
                v898 = US6_1(v896)
            else:
                raise Exception("Invalid tag.")
            del v887
            v899 = v3[1124:].view(cp.int8)
            v900 = v899[0].item()
            del v899
            v901 = [None] * 2
            v902 = 0
            while method14(v902):
                v904 = u64(v902)
                v905 = v904 * 4
                del v904
                v906 = 1128 + v905
                del v905
                v907 = v3[v906:].view(cp.uint8)
                del v906
                v908 = v907[0:].view(cp.int32)
                del v907
                v909 = v908[0].item()
                del v908
                if v909 == 0:
                    v914 = US4_0()
                elif v909 == 1:
                    v914 = US4_1()
                elif v909 == 2:
                    v914 = US4_2()
                else:
                    raise Exception("Invalid tag.")
                del v909
                v915 = 0 <= v902
                if v915:
                    v916 = v902 < 2
                    v917 = v916
                else:
                    v917 = False
                del v915
                v918 = v917 == False
                if v918:
                    v919 = "The read index needs to be in range."
                    assert v917, v919
                    del v919
                else:
                    pass
                del v917, v918
                v901[v902] = v914
                del v914
                v902 += 1 
            del v902
            v920 = v3[1136:].view(cp.int32)
            v921 = v920[0].item()
            del v920
            v922 = [None] * 2
            v923 = 0
            while method14(v923):
                v925 = u64(v923)
                v926 = v925 * 4
                del v925
                v927 = 1140 + v926
                del v926
                v928 = v3[v927:].view(cp.uint8)
                del v927
                v929 = v928[0:].view(cp.int32)
                del v928
                v930 = v929[0].item()
                del v929
                v931 = 0 <= v923
                if v931:
                    v932 = v923 < 2
                    v933 = v932
                else:
                    v933 = False
                del v931
                v934 = v933 == False
                if v934:
                    v935 = "The read index needs to be in range."
                    assert v933, v935
                    del v935
                else:
                    pass
                del v933, v934
                v922[v923] = v930
                del v930
                v923 += 1 
            del v923
            v936 = v3[1148:].view(cp.int32)
            v937 = v936[0].item()
            del v936
            v939 = US8_2(v898, v900, v901, v921, v922, v937)
        else:
            raise Exception("Invalid tag.")
        del v3, v830
        return method19(v732, v733, v734, v811, v939)
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
        v4 = [0]
        v5 = US3_0()
        v6 = US8_0()
        return method19(v5, v3, v4, v0, v6)
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
def method7(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US4_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US4_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method9(v0 : object) -> US6:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US6_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method7(v2)
            del v2
            return US6_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method8(v0 : object) -> US5:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5 = "community_card"
        v6 = v2[v5]
        del v5
        v7 = method9(v6)
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
        return US5_0(v7, v10, v17, v29, v36, v48)
    else:
        del v4
        v51 = "ChanceInit" == v1
        if v51:
            del v1, v51
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US5_1()
        else:
            del v51
            v54 = "Round" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method9(v56)
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
                    v71 = method7(v70)
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
                return US5_2(v57, v60, v67, v79, v86, v98)
            else:
                del v54
                v101 = "RoundWithAction" == v1
                if v101:
                    del v1, v101
                    v102 = v2[0]
                    v103 = "community_card"
                    v104 = v102[v103]
                    del v103
                    v105 = method9(v104)
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
                        v119 = method7(v118)
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
                    return US5_3(v105, v108, v115, v127, v134, v146, v148)
                else:
                    del v101
                    v151 = "TerminalCall" == v1
                    if v151:
                        del v1, v151
                        v152 = "community_card"
                        v153 = v2[v152]
                        del v152
                        v154 = method9(v153)
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
                            v168 = method7(v167)
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
                        return US5_4(v154, v157, v164, v176, v183, v195)
                    else:
                        del v151
                        v198 = "TerminalFold" == v1
                        if v198:
                            del v1, v198
                            v199 = "community_card"
                            v200 = v2[v199]
                            del v199
                            v201 = method9(v200)
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
                                v215 = method7(v214)
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
                            return US5_5(v201, v204, v211, v223, v230, v242)
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
            v10 = len(v9)
            assert (6 >= v10), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v10} '
            del v10
            assert isinstance(v9,list), f'The object needs to be a Python list. Got: {v9}'
            v11 = len(v9)
            v12 = 6 >= v11
            v13 = v12 == False
            if v13:
                v14 = "The type level dimension has to equal the value passed at runtime into create."
                assert v12, v14
                del v14
            else:
                pass
            del v12, v13
            v15 = [None] * 6
            v16 = [0]
            v17 = v16[0]
            del v17
            v16[0] = v11
            v18 = 0
            while method3(v11, v18):
                v20 = v9[v18]
                v21 = method7(v20)
                del v20
                v22 = 0 <= v18
                if v22:
                    v23 = v16[0]
                    v24 = v18 < v23
                    del v23
                    v25 = v24
                else:
                    v25 = False
                v26 = v25 == False
                if v26:
                    v27 = "The set index needs to be in range."
                    assert v25, v27
                    del v27
                else:
                    pass
                del v25, v26
                if v22:
                    v28 = v18 < 6
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
                v15[v18] = v21
                del v21
                v18 += 1 
            del v9, v11, v18
            v32 = "game"
            v33 = v2[v32]
            del v2, v32
            v34 = method8(v33)
            del v33
            return US3_1(v15, v16, v34)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method10(v0 : object) -> US7:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method7(v2)
        del v2
        return US7_0(v5)
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
            return US7_1(v10, v12)
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
                return US7_2(v17, v19)
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
                        v33 = method7(v32)
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
                    return US7_3(v29, v41, v44)
                else:
                    del v2, v22
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method11(v0 : object) -> US8:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US8_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = "community_card"
            v9 = v2[v8]
            del v8
            v10 = method9(v9)
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
                v24 = method7(v23)
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
            return US8_1(v10, v13, v20, v32, v39, v51)
        else:
            del v7
            v54 = "WaitingForActionFromPlayerId" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method9(v56)
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
                    v71 = method7(v70)
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
                return US8_2(v57, v60, v67, v79, v86, v98)
            else:
                del v2, v54
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : object) -> Tuple[US3, list[US7], list, list[US2], US8]:
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
    v8 = len(v7)
    assert (32 >= v8), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v8} '
    del v8
    assert isinstance(v7,list), f'The object needs to be a Python list. Got: {v7}'
    v9 = len(v7)
    v10 = 32 >= v9
    v11 = v10 == False
    if v11:
        v12 = "The type level dimension has to equal the value passed at runtime into create."
        assert v10, v12
        del v12
    else:
        pass
    del v10, v11
    v13 = [None] * 32
    v14 = [0]
    v15 = v14[0]
    del v15
    v14[0] = v9
    v16 = 0
    while method3(v9, v16):
        v18 = v7[v16]
        v19 = method10(v18)
        del v18
        v20 = 0 <= v16
        if v20:
            v21 = v14[0]
            v22 = v16 < v21
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
            v26 = v16 < 32
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
        v13[v16] = v19
        del v19
        v16 += 1 
    del v7, v9, v16
    v30 = "pl_type"
    v31 = v5[v30]
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
        v40 = method4(v39)
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
    v46 = "ui_game_state"
    v47 = v5[v46]
    del v5, v46
    v48 = method11(v47)
    del v47
    return v3, v13, v14, v36, v48
def method14(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method16(v0 : US4) -> i32:
    match v0:
        case US4_0(): # Jack
            del v0
            return 0
        case US4_1(): # King
            del v0
            return 2
        case US4_2(): # Queen
            del v0
            return 1
        case _:
            raise Exception('Pattern matching miss.')
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
def method15(v0 : US6, v1 : bool, v2 : list[US4], v3 : i32, v4 : list[i32], v5 : i32) -> US9:
    del v1, v3, v4, v5
    match v0:
        case US6_0(): # None
            del v0, v2
            raise Exception("Expected the community card to be present in the table.")
        case US6_1(v7): # Some
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
                        case _:
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
        case _:
            raise Exception('Pattern matching miss.')
def method13(v0 : list[US4], v1 : list, v2 : list[US7], v3 : list, v4 : list[US2], v5 : US5) -> US5:
    match v5:
        case US5_0(_, _, v418, _, v420, _): # ChanceCommunityCard
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
            v448 = US7_0(v434)
            v2[v436] = v448
            del v436, v448
            v449 = 2
            v450, v451 = (0, 0)
            while method14(v450):
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
            while method14(v462):
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
            v469 = US6_1(v434)
            del v434
            v470 = True
            v471 = 0
            v472 = US5_2(v469, v470, v418, v471, v461, v449)
            del v418, v449, v461, v469, v470, v471
            return method13(v0, v1, v2, v3, v4, v472)
        case US5_1(): # ChanceInit
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
            v514 = US7_2(0, v486)
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
            v527 = US7_2(1, v500)
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
            v531 = US6_0()
            v532 = True
            v533 = 0
            v534 = US5_2(v531, v532, v530, v533, v529, v528)
            del v528, v529, v530, v531, v532, v533
            return method13(v0, v1, v2, v3, v4, v534)
        case US5_2(v65, v66, v67, v68, v69, v70): # Round
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
                    v145 = US7_1(v68, v131)
                    v2[v133] = v145
                    del v133, v145
                    match v65:
                        case US6_0(): # None
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v217 = v68 == 0
                                        if v217:
                                            v218 = 1
                                        else:
                                            v218 = 0
                                        del v217
                                        v267 = US5_2(v65, False, v67, v218, v69, v70)
                                    else:
                                        v267 = US5_0(v65, v66, v67, v68, v69, v70)
                                case US1_1(): # Fold
                                    v267 = US5_5(v65, v66, v67, v68, v69, v70)
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
                                        while method14(v225):
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
                                        while method14(v237):
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
                                        while method14(v245):
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
                                        v267 = US5_2(v65, False, v67, v223, v244, v224)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US6_1(_): # Some
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v148 = v68 == 0
                                        if v148:
                                            v149 = 1
                                        else:
                                            v149 = 0
                                        del v148
                                        v267 = US5_2(v65, False, v67, v149, v69, v70)
                                    else:
                                        v151, v152 = (0, 0)
                                        while method14(v151):
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
                                        while method14(v163):
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
                                        v267 = US5_4(v65, v66, v67, v68, v162, v70)
                                case US1_1(): # Fold
                                    v267 = US5_5(v65, v66, v67, v68, v69, v70)
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
                                        while method14(v175):
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
                                        while method14(v187):
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
                                        while method14(v195):
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
                                        v267 = US5_2(v65, False, v67, v173, v194, v174)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v65, v66, v67, v68, v69, v70, v102, v131
                    return method13(v0, v1, v2, v3, v4, v267)
                case US2_1(): # Human
                    del v0, v1, v2, v3, v4, v65, v66, v67, v68, v69, v70, v76
                    return v5
                case _:
                    raise Exception('Pattern matching miss.')
        case US5_3(v271, v272, v273, v274, v275, v276, v277): # RoundWithAction
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
            v290 = US7_1(v274, v277)
            v2[v278] = v290
            del v278, v290
            match v271:
                case US6_0(): # None
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v363 = v274 == 0
                                if v363:
                                    v364 = 1
                                else:
                                    v364 = 0
                                del v363
                                v414 = US5_2(v271, False, v273, v364, v275, v276)
                            else:
                                v414 = US5_0(v271, v272, v273, v274, v275, v276)
                        case US1_1(): # Fold
                            v414 = US5_5(v271, v272, v273, v274, v275, v276)
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
                                while method14(v372):
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
                                while method14(v384):
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
                                while method14(v392):
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
                                v414 = US5_2(v271, False, v273, v370, v391, v371)
                            else:
                                del v368
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case US6_1(_): # Some
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v293 = v274 == 0
                                if v293:
                                    v294 = 1
                                else:
                                    v294 = 0
                                del v293
                                v414 = US5_2(v271, False, v273, v294, v275, v276)
                            else:
                                v296, v297 = (0, 0)
                                while method14(v296):
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
                                while method14(v308):
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
                                v414 = US5_4(v271, v272, v273, v274, v307, v276)
                        case US1_1(): # Fold
                            v414 = US5_5(v271, v272, v273, v274, v275, v276)
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
                                while method14(v321):
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
                                while method14(v333):
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
                                while method14(v341):
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
                                v414 = US5_2(v271, False, v273, v319, v340, v320)
                            else:
                                del v317
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case _:
                    raise Exception('Pattern matching miss.')
            del v271, v272, v273, v274, v275, v276, v277
            return method13(v0, v1, v2, v3, v4, v414)
        case US5_4(v33, v34, v35, v36, v37, v38): # TerminalCall
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
            v45 = method15(v33, v34, v35, v36, v37, v38)
            del v33, v34, v36, v37, v38
            match v45:
                case US9_0(): # Eq
                    v50, v51 = 0, -1
                case US9_1(): # Gt
                    v50, v51 = v44, 0
                case US9_2(): # Lt
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
            v64 = US7_3(v35, v50, v51)
            del v35, v50, v51
            v2[v52] = v64
            del v2, v52, v64
            return v5
        case US5_5(_, _, v8, v9, v10, _): # TerminalFold
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
            v32 = US7_3(v8, v17, v19)
            del v8, v17, v19
            v2[v20] = v32
            del v2, v20, v32
            return v5
        case _:
            raise Exception('Pattern matching miss.')
def method12(v0 : US3, v1 : list[US7], v2 : list, v3 : list[US2], v4 : US8, v5 : list[US4], v6 : list, v7 : US5) -> Tuple[US3, list[US7], list, list[US2], US8]:
    del v0, v4
    v8 = method13(v5, v6, v1, v2, v3, v7)
    del v7
    match v8:
        case US5_2(v9, v10, v11, v12, v13, v14): # Round
            v15 = US3_1(v5, v6, v8)
            del v5, v6, v8
            v16 = US8_2(v9, v10, v11, v12, v13, v14)
            del v9, v10, v11, v12, v13, v14
            return v15, v1, v2, v3, v16
        case US5_4(v17, v18, v19, v20, v21, v22): # TerminalCall
            del v5, v6, v8
            v23 = US3_0()
            v24 = US8_1(v17, v18, v19, v20, v21, v22)
            del v17, v18, v19, v20, v21, v22
            return v23, v1, v2, v3, v24
        case US5_5(v25, v26, v27, v28, v29, v30): # TerminalFold
            del v5, v6, v8
            v31 = US3_0()
            v32 = US8_1(v25, v26, v27, v28, v29, v30)
            del v25, v26, v27, v28, v29, v30
            return v31, v1, v2, v3, v32
        case _:
            del v1, v2, v3, v5, v6, v8
            raise Exception("Unexpected node received in play_loop.")
def method21(v0 : US4) -> object:
    match v0:
        case US4_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US4_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case _:
            raise Exception('Pattern matching miss.')
def method23(v0 : US6) -> object:
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
            v5 = method21(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case _:
            raise Exception('Pattern matching miss.')
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
        case _:
            raise Exception('Pattern matching miss.')
def method22(v0 : US5) -> object:
    match v0:
        case US5_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
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
        case US5_1(): # ChanceInit
            del v0
            v34 = []
            v35 = "ChanceInit"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US5_2(v37, v38, v39, v40, v41, v42): # Round
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
        case US5_3(v70, v71, v72, v73, v74, v75, v76): # RoundWithAction
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
        case US5_4(v107, v108, v109, v110, v111, v112): # TerminalCall
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
        case US5_5(v140, v141, v142, v143, v144, v145): # TerminalFold
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
        case _:
            raise Exception('Pattern matching miss.')
def method20(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4, v5, v6): # Some
            del v0
            v7 = []
            v8 = v5[0]
            v9 = 0
            while method3(v8, v9):
                v11 = 0 <= v9
                if v11:
                    v12 = v5[0]
                    v13 = v9 < v12
                    del v12
                    v14 = v13
                else:
                    v14 = False
                v15 = v14 == False
                if v15:
                    v16 = "The read index needs to be in range."
                    assert v14, v16
                    del v16
                else:
                    pass
                del v14, v15
                if v11:
                    v17 = v9 < 6
                    v18 = v17
                else:
                    v18 = False
                del v11
                v19 = v18 == False
                if v19:
                    v20 = "The read index needs to be in range."
                    assert v18, v20
                    del v20
                else:
                    pass
                del v18, v19
                v21 = v4[v9]
                v22 = method21(v21)
                del v21
                v7.append(v22)
                del v22
                v9 += 1 
            del v4, v5, v8, v9
            v23 = method22(v6)
            del v6
            v24 = {'deck': v7, 'game': v23}
            del v7, v23
            v25 = "Some"
            v26 = [v25,v24]
            del v24, v25
            return v26
        case _:
            raise Exception('Pattern matching miss.')
def method25(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardIs
            del v0
            v2 = method21(v1)
            del v1
            v3 = "CommunityCardIs"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # PlayerAction
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
        case US7_2(v13, v14): # PlayerGotCard
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
        case US7_3(v21, v22, v23): # Showdown
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
        case _:
            raise Exception('Pattern matching miss.')
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
        case _:
            raise Exception('Pattern matching miss.')
def method27(v0 : US8) -> object:
    match v0:
        case US8_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US8_1(v4, v5, v6, v7, v8, v9): # GameOver
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
        case US8_2(v37, v38, v39, v40, v41, v42): # WaitingForActionFromPlayerId
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
        case _:
            raise Exception('Pattern matching miss.')
def method19(v0 : US3, v1 : list[US7], v2 : list, v3 : list[US2], v4 : US8) -> object:
    v5 = method20(v0)
    del v0
    v6 = []
    v7 = v2[0]
    v8 = 0
    while method3(v7, v8):
        v10 = 0 <= v8
        if v10:
            v11 = v2[0]
            v12 = v8 < v11
            del v11
            v13 = v12
        else:
            v13 = False
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        if v10:
            v16 = v8 < 32
            v17 = v16
        else:
            v17 = False
        del v10
        v18 = v17 == False
        if v18:
            v19 = "The read index needs to be in range."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        v20 = v1[v8]
        v21 = method25(v20)
        del v20
        v6.append(v21)
        del v21
        v8 += 1 
    del v1, v2, v7, v8
    v22 = []
    v23 = 0
    while method14(v23):
        v25 = 0 <= v23
        if v25:
            v26 = v23 < 2
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
        v30 = v3[v23]
        v31 = method26(v30)
        del v30
        v22.append(v31)
        del v31
        v23 += 1 
    del v3, v23
    v32 = method27(v4)
    del v4
    v33 = {'messages': v6, 'pl_type': v22, 'ui_game_state': v32}
    del v6, v22, v32
    v34 = {'game_state': v5, 'ui_state': v33}
    del v5, v33
    return v34
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = Closure2()
    v3 = collections.namedtuple("Leduc_Game",['event_loop_cpu', 'event_loop_gpu', 'init'])(v0, v1, v2)
    del v0, v1, v2
    return v3

if __name__ == '__main__': print(main())
