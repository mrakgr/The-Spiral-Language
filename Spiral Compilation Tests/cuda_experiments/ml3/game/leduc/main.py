kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
#include <assert.h>
#include <stdio.h>
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
__device__ US5 play_loop_inner_1(static_array_list<US4,6l,long> & v0, static_array_list<US7,32l,long> & v1, static_array<US2,2l> v2, US5 v3);
__device__ Tuple0 play_loop_0(US3 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US7,32l,long> & v3, static_array_list<US4,6l,long> & v4, US5 v5);
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
    static_array<US2,2l> v1;
    US8 v2;
    __device__ Tuple0(US3 t0, static_array<US2,2l> t1, US8 t2) : v0(t0), v1(t1), v2(t2) {}
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
__device__ US5 play_loop_inner_1(static_array_list<US4,6l,long> & v0, static_array_list<US7,32l,long> & v1, static_array<US2,2l> v2, US5 v3){
    const char * v4;
    v4 = "%s";
    const char * v5;
    v5 = "in inner";
    printf(v4,v5);
    printf("\n");
    static_array_list<US7,32l,long> & v6 = v1;
    switch (v3.tag) {
        case 0: { // ChanceCommunityCard
            US6 v399 = v3.v.case0.v0; bool v400 = v3.v.case0.v1; static_array<US4,2l> v401 = v3.v.case0.v2; long v402 = v3.v.case0.v3; static_array<long,2l> v403 = v3.v.case0.v4; long v404 = v3.v.case0.v5;
            static_array_list<US4,6l,long> & v405 = v0;
            long v406;
            v406 = v405.length;
            long v407;
            v407 = v406 - 1l;
            bool v408;
            v408 = 0l <= v407;
            bool v411;
            if (v408){
                long v409;
                v409 = v405.length;
                bool v410;
                v410 = v407 < v409;
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
            US4 v413;
            v413 = v405.v[v407];
            v405.length = v407;
            long v414;
            v414 = v6.length;
            bool v415;
            v415 = v414 < 32l;
            bool v416;
            v416 = v415 == false;
            if (v416){
                assert("The length has to be less than the maximum length of the array." && v415);
            } else {
            }
            long v417;
            v417 = v414 + 1l;
            v6.length = v417;
            bool v418;
            v418 = 0l <= v414;
            bool v421;
            if (v418){
                long v419;
                v419 = v6.length;
                bool v420;
                v420 = v414 < v419;
                v421 = v420;
            } else {
                v421 = false;
            }
            bool v422;
            v422 = v421 == false;
            if (v422){
                assert("The set index needs to be in range." && v421);
            } else {
            }
            US7 v423;
            v423 = US7_0(v413);
            v6.v[v414] = v423;
            long v424;
            v424 = 2l;
            long v425; long v426;
            Tuple1 tmp0 = Tuple1(0l, 0l);
            v425 = tmp0.v0; v426 = tmp0.v1;
            while (while_method_0(v425)){
                bool v428;
                v428 = 0l <= v425;
                bool v430;
                if (v428){
                    bool v429;
                    v429 = v425 < 2l;
                    v430 = v429;
                } else {
                    v430 = false;
                }
                bool v431;
                v431 = v430 == false;
                if (v431){
                    assert("The read index needs to be in range." && v430);
                } else {
                }
                long v432;
                v432 = v403.v[v425];
                bool v433;
                v433 = v426 >= v432;
                long v434;
                if (v433){
                    v434 = v426;
                } else {
                    v434 = v432;
                }
                v426 = v434;
                v425 += 1l ;
            }
            static_array<long,2l> v435;
            long v436;
            v436 = 0l;
            while (while_method_0(v436)){
                bool v438;
                v438 = 0l <= v436;
                bool v440;
                if (v438){
                    bool v439;
                    v439 = v436 < 2l;
                    v440 = v439;
                } else {
                    v440 = false;
                }
                bool v441;
                v441 = v440 == false;
                if (v441){
                    assert("The read index needs to be in range." && v440);
                } else {
                }
                v435.v[v436] = v426;
                v436 += 1l ;
            }
            US6 v442;
            v442 = US6_1(v413);
            bool v443;
            v443 = true;
            long v444;
            v444 = 0l;
            US5 v445;
            v445 = US5_2(v442, v443, v401, v444, v435, v424);
            return play_loop_inner_1(v0, v1, v2, v445);
            break;
        }
        case 1: { // ChanceInit
            const char * v447;
            v447 = "in chance_init";
            printf(v4,v447);
            printf("\n");
            static_array_list<US4,6l,long> & v448 = v0;
            long v449;
            v449 = v448.length;
            long v450;
            v450 = v449 - 1l;
            bool v451;
            v451 = 0l <= v450;
            bool v454;
            if (v451){
                long v452;
                v452 = v448.length;
                bool v453;
                v453 = v450 < v452;
                v454 = v453;
            } else {
                v454 = false;
            }
            bool v455;
            v455 = v454 == false;
            if (v455){
                assert("The read index needs to be in range." && v454);
            } else {
            }
            US4 v456;
            v456 = v448.v[v450];
            v448.length = v450;
            static_array_list<US4,6l,long> & v457 = v0;
            long v458;
            v458 = v457.length;
            long v459;
            v459 = v458 - 1l;
            bool v460;
            v460 = 0l <= v459;
            bool v463;
            if (v460){
                long v461;
                v461 = v457.length;
                bool v462;
                v462 = v459 < v461;
                v463 = v462;
            } else {
                v463 = false;
            }
            bool v464;
            v464 = v463 == false;
            if (v464){
                assert("The read index needs to be in range." && v463);
            } else {
            }
            US4 v465;
            v465 = v457.v[v459];
            v457.length = v459;
            long v466;
            v466 = v6.length;
            bool v467;
            v467 = v466 < 32l;
            bool v468;
            v468 = v467 == false;
            if (v468){
                assert("The length has to be less than the maximum length of the array." && v467);
            } else {
            }
            long v469;
            v469 = v466 + 1l;
            v6.length = v469;
            bool v470;
            v470 = 0l <= v466;
            bool v473;
            if (v470){
                long v471;
                v471 = v6.length;
                bool v472;
                v472 = v466 < v471;
                v473 = v472;
            } else {
                v473 = false;
            }
            bool v474;
            v474 = v473 == false;
            if (v474){
                assert("The set index needs to be in range." && v473);
            } else {
            }
            US7 v475;
            v475 = US7_2(0l, v456);
            v6.v[v466] = v475;
            long v476;
            v476 = v6.length;
            bool v477;
            v477 = v476 < 32l;
            bool v478;
            v478 = v477 == false;
            if (v478){
                assert("The length has to be less than the maximum length of the array." && v477);
            } else {
            }
            long v479;
            v479 = v476 + 1l;
            v6.length = v479;
            bool v480;
            v480 = 0l <= v476;
            bool v483;
            if (v480){
                long v481;
                v481 = v6.length;
                bool v482;
                v482 = v476 < v481;
                v483 = v482;
            } else {
                v483 = false;
            }
            bool v484;
            v484 = v483 == false;
            if (v484){
                assert("The set index needs to be in range." && v483);
            } else {
            }
            US7 v485;
            v485 = US7_2(1l, v465);
            v6.v[v476] = v485;
            long v486;
            v486 = 2l;
            static_array<long,2l> v487;
            v487.v[0l] = 1l;
            v487.v[1l] = 1l;
            static_array<US4,2l> v488;
            v488.v[0l] = v456;
            v488.v[1l] = v465;
            US6 v489;
            v489 = US6_0();
            bool v490;
            v490 = true;
            long v491;
            v491 = 0l;
            US5 v492;
            v492 = US5_2(v489, v490, v488, v491, v487, v486);
            return play_loop_inner_1(v0, v1, v2, v492);
            break;
        }
        case 2: { // Round
            US6 v58 = v3.v.case2.v0; bool v59 = v3.v.case2.v1; static_array<US4,2l> v60 = v3.v.case2.v2; long v61 = v3.v.case2.v3; static_array<long,2l> v62 = v3.v.case2.v4; long v63 = v3.v.case2.v5;
            const char * v64;
            v64 = "in round";
            printf(v4,v64);
            printf("\n");
            bool v65;
            v65 = 0l <= v61;
            bool v67;
            if (v65){
                bool v66;
                v66 = v61 < 2l;
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
            v69 = v2.v[v61];
            switch (v69.tag) {
                case 0: { // Computer
                    static_array_list<US1,3l,long> v70;
                    v70.length = 0;
                    v70.length = 1l;
                    long v71;
                    v71 = v70.length;
                    bool v72;
                    v72 = 0l < v71;
                    bool v73;
                    v73 = v72 == false;
                    if (v73){
                        assert("The set index needs to be in range." && v72);
                    } else {
                    }
                    US1 v74;
                    v74 = US1_0();
                    v70.v[0l] = v74;
                    long v75;
                    v75 = v62.v[0l];
                    long v76;
                    v76 = v62.v[1l];
                    bool v77;
                    v77 = v75 == v76;
                    bool v78;
                    v78 = v77 != true;
                    if (v78){
                        long v79;
                        v79 = v70.length;
                        bool v80;
                        v80 = v79 < 3l;
                        bool v81;
                        v81 = v80 == false;
                        if (v81){
                            assert("The length has to be less than the maximum length of the array." && v80);
                        } else {
                        }
                        long v82;
                        v82 = v79 + 1l;
                        v70.length = v82;
                        bool v83;
                        v83 = 0l <= v79;
                        bool v86;
                        if (v83){
                            long v84;
                            v84 = v70.length;
                            bool v85;
                            v85 = v79 < v84;
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
                        US1 v88;
                        v88 = US1_1();
                        v70.v[v79] = v88;
                    } else {
                    }
                    bool v89;
                    v89 = v63 > 0l;
                    if (v89){
                        long v90;
                        v90 = v70.length;
                        bool v91;
                        v91 = v90 < 3l;
                        bool v92;
                        v92 = v91 == false;
                        if (v92){
                            assert("The length has to be less than the maximum length of the array." && v91);
                        } else {
                        }
                        long v93;
                        v93 = v90 + 1l;
                        v70.length = v93;
                        bool v94;
                        v94 = 0l <= v90;
                        bool v97;
                        if (v94){
                            long v95;
                            v95 = v70.length;
                            bool v96;
                            v96 = v90 < v95;
                            v97 = v96;
                        } else {
                            v97 = false;
                        }
                        bool v98;
                        v98 = v97 == false;
                        if (v98){
                            assert("The set index needs to be in range." && v97);
                        } else {
                        }
                        US1 v99;
                        v99 = US1_2();
                        v70.v[v90] = v99;
                    } else {
                    }
                    unsigned long long v100;
                    v100 = clock64();
                    curandStatePhilox4_32_10_t v101;
                    curandStatePhilox4_32_10_t * v102 = &v101;
                    curand_init(v100,0ull,0ull,v102);
                    long v103;
                    v103 = v70.length;
                    long v104;
                    v104 = v103 - 1l;
                    long v105;
                    v105 = 0l;
                    while (while_method_1(v104, v105)){
                        long v107;
                        v107 = v70.length;
                        long v108;
                        v108 = v107 - v105;
                        unsigned long v109;
                        v109 = (unsigned long)v108;
                        unsigned long v110;
                        v110 = loop_2(v109, v102);
                        unsigned long v111;
                        v111 = (unsigned long)v105;
                        unsigned long v112;
                        v112 = v110 - v111;
                        long v113;
                        v113 = (long)v112;
                        bool v114;
                        v114 = 0l <= v105;
                        bool v117;
                        if (v114){
                            long v115;
                            v115 = v70.length;
                            bool v116;
                            v116 = v105 < v115;
                            v117 = v116;
                        } else {
                            v117 = false;
                        }
                        bool v118;
                        v118 = v117 == false;
                        if (v118){
                            assert("The read index needs to be in range." && v117);
                        } else {
                        }
                        US1 v119;
                        v119 = v70.v[v105];
                        bool v120;
                        v120 = 0l <= v113;
                        bool v123;
                        if (v120){
                            long v121;
                            v121 = v70.length;
                            bool v122;
                            v122 = v113 < v121;
                            v123 = v122;
                        } else {
                            v123 = false;
                        }
                        bool v124;
                        v124 = v123 == false;
                        if (v124){
                            assert("The read index needs to be in range." && v123);
                        } else {
                        }
                        US1 v125;
                        v125 = v70.v[v113];
                        bool v128;
                        if (v114){
                            long v126;
                            v126 = v70.length;
                            bool v127;
                            v127 = v105 < v126;
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
                        v70.v[v105] = v125;
                        bool v132;
                        if (v120){
                            long v130;
                            v130 = v70.length;
                            bool v131;
                            v131 = v113 < v130;
                            v132 = v131;
                        } else {
                            v132 = false;
                        }
                        bool v133;
                        v133 = v132 == false;
                        if (v133){
                            assert("The set index needs to be in range." && v132);
                        } else {
                        }
                        v70.v[v113] = v119;
                        v105 += 1l ;
                    }
                    long v134;
                    v134 = v70.length;
                    long v135;
                    v135 = v134 - 1l;
                    bool v136;
                    v136 = 0l <= v135;
                    bool v139;
                    if (v136){
                        long v137;
                        v137 = v70.length;
                        bool v138;
                        v138 = v135 < v137;
                        v139 = v138;
                    } else {
                        v139 = false;
                    }
                    bool v140;
                    v140 = v139 == false;
                    if (v140){
                        assert("The read index needs to be in range." && v139);
                    } else {
                    }
                    US1 v141;
                    v141 = v70.v[v135];
                    v70.length = v135;
                    long v142;
                    v142 = v6.length;
                    bool v143;
                    v143 = v142 < 32l;
                    bool v144;
                    v144 = v143 == false;
                    if (v144){
                        assert("The length has to be less than the maximum length of the array." && v143);
                    } else {
                    }
                    long v145;
                    v145 = v142 + 1l;
                    v6.length = v145;
                    bool v146;
                    v146 = 0l <= v142;
                    bool v149;
                    if (v146){
                        long v147;
                        v147 = v6.length;
                        bool v148;
                        v148 = v142 < v147;
                        v149 = v148;
                    } else {
                        v149 = false;
                    }
                    bool v150;
                    v150 = v149 == false;
                    if (v150){
                        assert("The set index needs to be in range." && v149);
                    } else {
                    }
                    US7 v151;
                    v151 = US7_1(v61, v141);
                    v6.v[v142] = v151;
                    US5 v263;
                    switch (v58.tag) {
                        case 0: { // None
                            switch (v141.tag) {
                                case 0: { // Call
                                    if (v59){
                                        bool v217;
                                        v217 = v61 == 0l;
                                        long v218;
                                        if (v217){
                                            v218 = 1l;
                                        } else {
                                            v218 = 0l;
                                        }
                                        v263 = US5_2(v58, false, v60, v218, v62, v63);
                                    } else {
                                        v263 = US5_0(v58, v59, v60, v61, v62, v63);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v263 = US5_5(v58, v59, v60, v61, v62, v63);
                                    break;
                                }
                                default: { // Raise
                                    if (v89){
                                        bool v222;
                                        v222 = v61 == 0l;
                                        long v223;
                                        if (v222){
                                            v223 = 1l;
                                        } else {
                                            v223 = 0l;
                                        }
                                        long v224;
                                        v224 = -1l + v63;
                                        long v225; long v226;
                                        Tuple1 tmp1 = Tuple1(0l, 0l);
                                        v225 = tmp1.v0; v226 = tmp1.v1;
                                        while (while_method_0(v225)){
                                            bool v228;
                                            v228 = 0l <= v225;
                                            bool v230;
                                            if (v228){
                                                bool v229;
                                                v229 = v225 < 2l;
                                                v230 = v229;
                                            } else {
                                                v230 = false;
                                            }
                                            bool v231;
                                            v231 = v230 == false;
                                            if (v231){
                                                assert("The read index needs to be in range." && v230);
                                            } else {
                                            }
                                            long v232;
                                            v232 = v62.v[v225];
                                            bool v233;
                                            v233 = v226 >= v232;
                                            long v234;
                                            if (v233){
                                                v234 = v226;
                                            } else {
                                                v234 = v232;
                                            }
                                            v226 = v234;
                                            v225 += 1l ;
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
                                                assert("The read index needs to be in range." && v240);
                                            } else {
                                            }
                                            v235.v[v236] = v226;
                                            v236 += 1l ;
                                        }
                                        static_array<long,2l> v242;
                                        long v243;
                                        v243 = 0l;
                                        while (while_method_0(v243)){
                                            bool v245;
                                            v245 = 0l <= v243;
                                            bool v247;
                                            if (v245){
                                                bool v246;
                                                v246 = v243 < 2l;
                                                v247 = v246;
                                            } else {
                                                v247 = false;
                                            }
                                            bool v248;
                                            v248 = v247 == false;
                                            if (v248){
                                                assert("The read index needs to be in range." && v247);
                                            } else {
                                            }
                                            long v249;
                                            v249 = v235.v[v243];
                                            bool v250;
                                            v250 = v243 == v61;
                                            long v252;
                                            if (v250){
                                                long v251;
                                                v251 = v249 + 2l;
                                                v252 = v251;
                                            } else {
                                                v252 = v249;
                                            }
                                            bool v254;
                                            if (v245){
                                                bool v253;
                                                v253 = v243 < 2l;
                                                v254 = v253;
                                            } else {
                                                v254 = false;
                                            }
                                            bool v255;
                                            v255 = v254 == false;
                                            if (v255){
                                                assert("The read index needs to be in range." && v254);
                                            } else {
                                            }
                                            v242.v[v243] = v252;
                                            v243 += 1l ;
                                        }
                                        v263 = US5_2(v58, false, v60, v223, v242, v224);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                            break;
                        }
                        default: { // Some
                            US4 v152 = v58.v.case1.v0;
                            switch (v141.tag) {
                                case 0: { // Call
                                    if (v59){
                                        bool v154;
                                        v154 = v61 == 0l;
                                        long v155;
                                        if (v154){
                                            v155 = 1l;
                                        } else {
                                            v155 = 0l;
                                        }
                                        v263 = US5_2(v58, false, v60, v155, v62, v63);
                                    } else {
                                        long v157; long v158;
                                        Tuple1 tmp2 = Tuple1(0l, 0l);
                                        v157 = tmp2.v0; v158 = tmp2.v1;
                                        while (while_method_0(v157)){
                                            bool v160;
                                            v160 = 0l <= v157;
                                            bool v162;
                                            if (v160){
                                                bool v161;
                                                v161 = v157 < 2l;
                                                v162 = v161;
                                            } else {
                                                v162 = false;
                                            }
                                            bool v163;
                                            v163 = v162 == false;
                                            if (v163){
                                                assert("The read index needs to be in range." && v162);
                                            } else {
                                            }
                                            long v164;
                                            v164 = v62.v[v157];
                                            bool v165;
                                            v165 = v158 >= v164;
                                            long v166;
                                            if (v165){
                                                v166 = v158;
                                            } else {
                                                v166 = v164;
                                            }
                                            v158 = v166;
                                            v157 += 1l ;
                                        }
                                        static_array<long,2l> v167;
                                        long v168;
                                        v168 = 0l;
                                        while (while_method_0(v168)){
                                            bool v170;
                                            v170 = 0l <= v168;
                                            bool v172;
                                            if (v170){
                                                bool v171;
                                                v171 = v168 < 2l;
                                                v172 = v171;
                                            } else {
                                                v172 = false;
                                            }
                                            bool v173;
                                            v173 = v172 == false;
                                            if (v173){
                                                assert("The read index needs to be in range." && v172);
                                            } else {
                                            }
                                            v167.v[v168] = v158;
                                            v168 += 1l ;
                                        }
                                        v263 = US5_4(v58, v59, v60, v61, v167, v63);
                                    }
                                    break;
                                }
                                case 1: { // Fold
                                    v263 = US5_5(v58, v59, v60, v61, v62, v63);
                                    break;
                                }
                                default: { // Raise
                                    if (v89){
                                        bool v176;
                                        v176 = v61 == 0l;
                                        long v177;
                                        if (v176){
                                            v177 = 1l;
                                        } else {
                                            v177 = 0l;
                                        }
                                        long v178;
                                        v178 = -1l + v63;
                                        long v179; long v180;
                                        Tuple1 tmp3 = Tuple1(0l, 0l);
                                        v179 = tmp3.v0; v180 = tmp3.v1;
                                        while (while_method_0(v179)){
                                            bool v182;
                                            v182 = 0l <= v179;
                                            bool v184;
                                            if (v182){
                                                bool v183;
                                                v183 = v179 < 2l;
                                                v184 = v183;
                                            } else {
                                                v184 = false;
                                            }
                                            bool v185;
                                            v185 = v184 == false;
                                            if (v185){
                                                assert("The read index needs to be in range." && v184);
                                            } else {
                                            }
                                            long v186;
                                            v186 = v62.v[v179];
                                            bool v187;
                                            v187 = v180 >= v186;
                                            long v188;
                                            if (v187){
                                                v188 = v180;
                                            } else {
                                                v188 = v186;
                                            }
                                            v180 = v188;
                                            v179 += 1l ;
                                        }
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
                                                assert("The read index needs to be in range." && v194);
                                            } else {
                                            }
                                            v189.v[v190] = v180;
                                            v190 += 1l ;
                                        }
                                        static_array<long,2l> v196;
                                        long v197;
                                        v197 = 0l;
                                        while (while_method_0(v197)){
                                            bool v199;
                                            v199 = 0l <= v197;
                                            bool v201;
                                            if (v199){
                                                bool v200;
                                                v200 = v197 < 2l;
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
                                            long v203;
                                            v203 = v189.v[v197];
                                            bool v204;
                                            v204 = v197 == v61;
                                            long v206;
                                            if (v204){
                                                long v205;
                                                v205 = v203 + 4l;
                                                v206 = v205;
                                            } else {
                                                v206 = v203;
                                            }
                                            bool v208;
                                            if (v199){
                                                bool v207;
                                                v207 = v197 < 2l;
                                                v208 = v207;
                                            } else {
                                                v208 = false;
                                            }
                                            bool v209;
                                            v209 = v208 == false;
                                            if (v209){
                                                assert("The read index needs to be in range." && v208);
                                            } else {
                                            }
                                            v196.v[v197] = v206;
                                            v197 += 1l ;
                                        }
                                        v263 = US5_2(v58, false, v60, v177, v196, v178);
                                    } else {
                                        printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                        asm("exit;");
                                    }
                                }
                            }
                        }
                    }
                    return play_loop_inner_1(v0, v1, v2, v263);
                    break;
                }
                default: { // Human
                    return v3;
                }
            }
            break;
        }
        case 3: { // RoundWithAction
            US6 v267 = v3.v.case3.v0; bool v268 = v3.v.case3.v1; static_array<US4,2l> v269 = v3.v.case3.v2; long v270 = v3.v.case3.v3; static_array<long,2l> v271 = v3.v.case3.v4; long v272 = v3.v.case3.v5; US1 v273 = v3.v.case3.v6;
            long v274;
            v274 = v6.length;
            bool v275;
            v275 = v274 < 32l;
            bool v276;
            v276 = v275 == false;
            if (v276){
                assert("The length has to be less than the maximum length of the array." && v275);
            } else {
            }
            long v277;
            v277 = v274 + 1l;
            v6.length = v277;
            bool v278;
            v278 = 0l <= v274;
            bool v281;
            if (v278){
                long v279;
                v279 = v6.length;
                bool v280;
                v280 = v274 < v279;
                v281 = v280;
            } else {
                v281 = false;
            }
            bool v282;
            v282 = v281 == false;
            if (v282){
                assert("The set index needs to be in range." && v281);
            } else {
            }
            US7 v283;
            v283 = US7_1(v270, v273);
            v6.v[v274] = v283;
            US5 v397;
            switch (v267.tag) {
                case 0: { // None
                    switch (v273.tag) {
                        case 0: { // Call
                            if (v268){
                                bool v350;
                                v350 = v270 == 0l;
                                long v351;
                                if (v350){
                                    v351 = 1l;
                                } else {
                                    v351 = 0l;
                                }
                                v397 = US5_2(v267, false, v269, v351, v271, v272);
                            } else {
                                v397 = US5_0(v267, v268, v269, v270, v271, v272);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v397 = US5_5(v267, v268, v269, v270, v271, v272);
                            break;
                        }
                        default: { // Raise
                            bool v355;
                            v355 = v272 > 0l;
                            if (v355){
                                bool v356;
                                v356 = v270 == 0l;
                                long v357;
                                if (v356){
                                    v357 = 1l;
                                } else {
                                    v357 = 0l;
                                }
                                long v358;
                                v358 = -1l + v272;
                                long v359; long v360;
                                Tuple1 tmp4 = Tuple1(0l, 0l);
                                v359 = tmp4.v0; v360 = tmp4.v1;
                                while (while_method_0(v359)){
                                    bool v362;
                                    v362 = 0l <= v359;
                                    bool v364;
                                    if (v362){
                                        bool v363;
                                        v363 = v359 < 2l;
                                        v364 = v363;
                                    } else {
                                        v364 = false;
                                    }
                                    bool v365;
                                    v365 = v364 == false;
                                    if (v365){
                                        assert("The read index needs to be in range." && v364);
                                    } else {
                                    }
                                    long v366;
                                    v366 = v271.v[v359];
                                    bool v367;
                                    v367 = v360 >= v366;
                                    long v368;
                                    if (v367){
                                        v368 = v360;
                                    } else {
                                        v368 = v366;
                                    }
                                    v360 = v368;
                                    v359 += 1l ;
                                }
                                static_array<long,2l> v369;
                                long v370;
                                v370 = 0l;
                                while (while_method_0(v370)){
                                    bool v372;
                                    v372 = 0l <= v370;
                                    bool v374;
                                    if (v372){
                                        bool v373;
                                        v373 = v370 < 2l;
                                        v374 = v373;
                                    } else {
                                        v374 = false;
                                    }
                                    bool v375;
                                    v375 = v374 == false;
                                    if (v375){
                                        assert("The read index needs to be in range." && v374);
                                    } else {
                                    }
                                    v369.v[v370] = v360;
                                    v370 += 1l ;
                                }
                                static_array<long,2l> v376;
                                long v377;
                                v377 = 0l;
                                while (while_method_0(v377)){
                                    bool v379;
                                    v379 = 0l <= v377;
                                    bool v381;
                                    if (v379){
                                        bool v380;
                                        v380 = v377 < 2l;
                                        v381 = v380;
                                    } else {
                                        v381 = false;
                                    }
                                    bool v382;
                                    v382 = v381 == false;
                                    if (v382){
                                        assert("The read index needs to be in range." && v381);
                                    } else {
                                    }
                                    long v383;
                                    v383 = v369.v[v377];
                                    bool v384;
                                    v384 = v377 == v270;
                                    long v386;
                                    if (v384){
                                        long v385;
                                        v385 = v383 + 2l;
                                        v386 = v385;
                                    } else {
                                        v386 = v383;
                                    }
                                    bool v388;
                                    if (v379){
                                        bool v387;
                                        v387 = v377 < 2l;
                                        v388 = v387;
                                    } else {
                                        v388 = false;
                                    }
                                    bool v389;
                                    v389 = v388 == false;
                                    if (v389){
                                        assert("The read index needs to be in range." && v388);
                                    } else {
                                    }
                                    v376.v[v377] = v386;
                                    v377 += 1l ;
                                }
                                v397 = US5_2(v267, false, v269, v357, v376, v358);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                    break;
                }
                default: { // Some
                    US4 v284 = v267.v.case1.v0;
                    switch (v273.tag) {
                        case 0: { // Call
                            if (v268){
                                bool v286;
                                v286 = v270 == 0l;
                                long v287;
                                if (v286){
                                    v287 = 1l;
                                } else {
                                    v287 = 0l;
                                }
                                v397 = US5_2(v267, false, v269, v287, v271, v272);
                            } else {
                                long v289; long v290;
                                Tuple1 tmp5 = Tuple1(0l, 0l);
                                v289 = tmp5.v0; v290 = tmp5.v1;
                                while (while_method_0(v289)){
                                    bool v292;
                                    v292 = 0l <= v289;
                                    bool v294;
                                    if (v292){
                                        bool v293;
                                        v293 = v289 < 2l;
                                        v294 = v293;
                                    } else {
                                        v294 = false;
                                    }
                                    bool v295;
                                    v295 = v294 == false;
                                    if (v295){
                                        assert("The read index needs to be in range." && v294);
                                    } else {
                                    }
                                    long v296;
                                    v296 = v271.v[v289];
                                    bool v297;
                                    v297 = v290 >= v296;
                                    long v298;
                                    if (v297){
                                        v298 = v290;
                                    } else {
                                        v298 = v296;
                                    }
                                    v290 = v298;
                                    v289 += 1l ;
                                }
                                static_array<long,2l> v299;
                                long v300;
                                v300 = 0l;
                                while (while_method_0(v300)){
                                    bool v302;
                                    v302 = 0l <= v300;
                                    bool v304;
                                    if (v302){
                                        bool v303;
                                        v303 = v300 < 2l;
                                        v304 = v303;
                                    } else {
                                        v304 = false;
                                    }
                                    bool v305;
                                    v305 = v304 == false;
                                    if (v305){
                                        assert("The read index needs to be in range." && v304);
                                    } else {
                                    }
                                    v299.v[v300] = v290;
                                    v300 += 1l ;
                                }
                                v397 = US5_4(v267, v268, v269, v270, v299, v272);
                            }
                            break;
                        }
                        case 1: { // Fold
                            v397 = US5_5(v267, v268, v269, v270, v271, v272);
                            break;
                        }
                        default: { // Raise
                            bool v308;
                            v308 = v272 > 0l;
                            if (v308){
                                bool v309;
                                v309 = v270 == 0l;
                                long v310;
                                if (v309){
                                    v310 = 1l;
                                } else {
                                    v310 = 0l;
                                }
                                long v311;
                                v311 = -1l + v272;
                                long v312; long v313;
                                Tuple1 tmp6 = Tuple1(0l, 0l);
                                v312 = tmp6.v0; v313 = tmp6.v1;
                                while (while_method_0(v312)){
                                    bool v315;
                                    v315 = 0l <= v312;
                                    bool v317;
                                    if (v315){
                                        bool v316;
                                        v316 = v312 < 2l;
                                        v317 = v316;
                                    } else {
                                        v317 = false;
                                    }
                                    bool v318;
                                    v318 = v317 == false;
                                    if (v318){
                                        assert("The read index needs to be in range." && v317);
                                    } else {
                                    }
                                    long v319;
                                    v319 = v271.v[v312];
                                    bool v320;
                                    v320 = v313 >= v319;
                                    long v321;
                                    if (v320){
                                        v321 = v313;
                                    } else {
                                        v321 = v319;
                                    }
                                    v313 = v321;
                                    v312 += 1l ;
                                }
                                static_array<long,2l> v322;
                                long v323;
                                v323 = 0l;
                                while (while_method_0(v323)){
                                    bool v325;
                                    v325 = 0l <= v323;
                                    bool v327;
                                    if (v325){
                                        bool v326;
                                        v326 = v323 < 2l;
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
                                    v322.v[v323] = v313;
                                    v323 += 1l ;
                                }
                                static_array<long,2l> v329;
                                long v330;
                                v330 = 0l;
                                while (while_method_0(v330)){
                                    bool v332;
                                    v332 = 0l <= v330;
                                    bool v334;
                                    if (v332){
                                        bool v333;
                                        v333 = v330 < 2l;
                                        v334 = v333;
                                    } else {
                                        v334 = false;
                                    }
                                    bool v335;
                                    v335 = v334 == false;
                                    if (v335){
                                        assert("The read index needs to be in range." && v334);
                                    } else {
                                    }
                                    long v336;
                                    v336 = v322.v[v330];
                                    bool v337;
                                    v337 = v330 == v270;
                                    long v339;
                                    if (v337){
                                        long v338;
                                        v338 = v336 + 4l;
                                        v339 = v338;
                                    } else {
                                        v339 = v336;
                                    }
                                    bool v341;
                                    if (v332){
                                        bool v340;
                                        v340 = v330 < 2l;
                                        v341 = v340;
                                    } else {
                                        v341 = false;
                                    }
                                    bool v342;
                                    v342 = v341 == false;
                                    if (v342){
                                        assert("The read index needs to be in range." && v341);
                                    } else {
                                    }
                                    v329.v[v330] = v339;
                                    v330 += 1l ;
                                }
                                v397 = US5_2(v267, false, v269, v310, v329, v311);
                            } else {
                                printf("%s\n", "Invalid action. The number of raises left is not positive.");
                                asm("exit;");
                            }
                        }
                    }
                }
            }
            return play_loop_inner_1(v0, v1, v2, v397);
            break;
        }
        case 4: { // TerminalCall
            US6 v30 = v3.v.case4.v0; bool v31 = v3.v.case4.v1; static_array<US4,2l> v32 = v3.v.case4.v2; long v33 = v3.v.case4.v3; static_array<long,2l> v34 = v3.v.case4.v4; long v35 = v3.v.case4.v5;
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
            long v48;
            v48 = v6.length;
            bool v49;
            v49 = v48 < 32l;
            bool v50;
            v50 = v49 == false;
            if (v50){
                assert("The length has to be less than the maximum length of the array." && v49);
            } else {
            }
            long v51;
            v51 = v48 + 1l;
            v6.length = v51;
            bool v52;
            v52 = 0l <= v48;
            bool v55;
            if (v52){
                long v53;
                v53 = v6.length;
                bool v54;
                v54 = v48 < v53;
                v55 = v54;
            } else {
                v55 = false;
            }
            bool v56;
            v56 = v55 == false;
            if (v56){
                assert("The set index needs to be in range." && v55);
            } else {
            }
            US7 v57;
            v57 = US7_3(v32, v46, v47);
            v6.v[v48] = v57;
            return v3;
            break;
        }
        default: { // TerminalFold
            US6 v7 = v3.v.case5.v0; bool v8 = v3.v.case5.v1; static_array<US4,2l> v9 = v3.v.case5.v2; long v10 = v3.v.case5.v3; static_array<long,2l> v11 = v3.v.case5.v4; long v12 = v3.v.case5.v5;
            bool v13;
            v13 = 0l <= v10;
            bool v15;
            if (v13){
                bool v14;
                v14 = v10 < 2l;
                v15 = v14;
            } else {
                v15 = false;
            }
            bool v16;
            v16 = v15 == false;
            if (v16){
                assert("The read index needs to be in range." && v15);
            } else {
            }
            long v17;
            v17 = v11.v[v10];
            bool v18;
            v18 = v10 == 0l;
            long v19;
            if (v18){
                v19 = 1l;
            } else {
                v19 = 0l;
            }
            long v20;
            v20 = v6.length;
            bool v21;
            v21 = v20 < 32l;
            bool v22;
            v22 = v21 == false;
            if (v22){
                assert("The length has to be less than the maximum length of the array." && v21);
            } else {
            }
            long v23;
            v23 = v20 + 1l;
            v6.length = v23;
            bool v24;
            v24 = 0l <= v20;
            bool v27;
            if (v24){
                long v25;
                v25 = v6.length;
                bool v26;
                v26 = v20 < v25;
                v27 = v26;
            } else {
                v27 = false;
            }
            bool v28;
            v28 = v27 == false;
            if (v28){
                assert("The set index needs to be in range." && v27);
            } else {
            }
            US7 v29;
            v29 = US7_3(v9, v17, v19);
            v6.v[v20] = v29;
            return v3;
        }
    }
}
__device__ Tuple0 play_loop_0(US3 v0, static_array<US2,2l> v1, US8 v2, static_array_list<US7,32l,long> & v3, static_array_list<US4,6l,long> & v4, US5 v5){
    const char * v6;
    v6 = "%s";
    const char * v7;
    v7 = "in play_loop";
    printf(v6,v7);
    printf("\n");
    const char * v8;
    v8 = "before calling play_loop_inner";
    printf(v6,v8);
    printf("\n");
    US5 v9;
    v9 = play_loop_inner_1(v4, v3, v1, v5);
    const char * v10;
    v10 = "after calling play_loop_inner";
    printf(v6,v10);
    printf("\n");
    switch (v9.tag) {
        case 2: { // Round
            US6 v11 = v9.v.case2.v0; bool v12 = v9.v.case2.v1; static_array<US4,2l> v13 = v9.v.case2.v2; long v14 = v9.v.case2.v3; static_array<long,2l> v15 = v9.v.case2.v4; long v16 = v9.v.case2.v5;
            static_array_list<US4,6l,long> & v17 = v4;
            US3 v18;
            v18 = US3_1(v17, v9);
            US8 v19;
            v19 = US8_2(v11, v12, v13, v14, v15, v16);
            return Tuple0(v18, v1, v19);
            break;
        }
        case 4: { // TerminalCall
            US6 v20 = v9.v.case4.v0; bool v21 = v9.v.case4.v1; static_array<US4,2l> v22 = v9.v.case4.v2; long v23 = v9.v.case4.v3; static_array<long,2l> v24 = v9.v.case4.v4; long v25 = v9.v.case4.v5;
            US3 v26;
            v26 = US3_0();
            US8 v27;
            v27 = US8_1(v20, v21, v22, v23, v24, v25);
            return Tuple0(v26, v1, v27);
            break;
        }
        case 5: { // TerminalFold
            US6 v28 = v9.v.case5.v0; bool v29 = v9.v.case5.v1; static_array<US4,2l> v30 = v9.v.case5.v2; long v31 = v9.v.case5.v3; static_array<long,2l> v32 = v9.v.case5.v4; long v33 = v9.v.case5.v5;
            US3 v34;
            v34 = US3_0();
            US8 v35;
            v35 = US8_1(v28, v29, v30, v31, v32, v33);
            return Tuple0(v34, v1, v35);
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
    v4 = v2 + v3;
    bool v5;
    v5 = v4 == 0l;
    if (v5){
        long * v6;
        v6 = (long *)(v1+0ull);
        long v7;
        v7 = v6[0l];
        US0 v36;
        switch (v7) {
            case 0: {
                long * v9;
                v9 = (long *)(v1+4ull);
                long v10;
                v10 = v9[0l];
                US1 v15;
                switch (v10) {
                    case 0: {
                        v15 = US1_0();
                        break;
                    }
                    case 1: {
                        v15 = US1_1();
                        break;
                    }
                    case 2: {
                        v15 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v36 = US0_0(v15);
                break;
            }
            case 1: {
                static_array<US2,2l> v17;
                long v18;
                v18 = 0l;
                while (while_method_0(v18)){
                    unsigned long long v20;
                    v20 = (unsigned long long)v18;
                    unsigned long long v21;
                    v21 = v20 * 4ull;
                    unsigned long long v22;
                    v22 = 4ull + v21;
                    unsigned char * v23;
                    v23 = (unsigned char *)(v1+v22);
                    long * v24;
                    v24 = (long *)(v23+0ull);
                    long v25;
                    v25 = v24[0l];
                    US2 v29;
                    switch (v25) {
                        case 0: {
                            v29 = US2_0();
                            break;
                        }
                        case 1: {
                            v29 = US2_1();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v30;
                    v30 = 0l <= v18;
                    bool v32;
                    if (v30){
                        bool v31;
                        v31 = v18 < 2l;
                        v32 = v31;
                    } else {
                        v32 = false;
                    }
                    bool v33;
                    v33 = v32 == false;
                    if (v33){
                        assert("The read index needs to be in range." && v32);
                    } else {
                    }
                    v17.v[v18] = v29;
                    v18 += 1l ;
                }
                v36 = US0_1(v17);
                break;
            }
            case 2: {
                v36 = US0_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        long * v37;
        v37 = (long *)(v0+0ull);
        long v38;
        v38 = v37[0l];
        US3 v331;
        switch (v38) {
            case 0: {
                v331 = US3_0();
                break;
            }
            case 1: {
                static_array_list<US4,6l,long> v41;
                v41.length = 0;
                long * v42;
                v42 = (long *)(v0+4ull);
                long v43;
                v43 = v42[0l];
                v41.length = v43;
                long v44;
                v44 = v41.length;
                long v45;
                v45 = 0l;
                while (while_method_1(v44, v45)){
                    unsigned long long v47;
                    v47 = (unsigned long long)v45;
                    unsigned long long v48;
                    v48 = v47 * 4ull;
                    unsigned long long v49;
                    v49 = 8ull + v48;
                    unsigned char * v50;
                    v50 = (unsigned char *)(v0+v49);
                    long * v51;
                    v51 = (long *)(v50+0ull);
                    long v52;
                    v52 = v51[0l];
                    US4 v57;
                    switch (v52) {
                        case 0: {
                            v57 = US4_0();
                            break;
                        }
                        case 1: {
                            v57 = US4_1();
                            break;
                        }
                        case 2: {
                            v57 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v58;
                    v58 = 0l <= v45;
                    bool v61;
                    if (v58){
                        long v59;
                        v59 = v41.length;
                        bool v60;
                        v60 = v45 < v59;
                        v61 = v60;
                    } else {
                        v61 = false;
                    }
                    bool v62;
                    v62 = v61 == false;
                    if (v62){
                        assert("The set index needs to be in range." && v61);
                    } else {
                    }
                    v41.v[v45] = v57;
                    v45 += 1l ;
                }
                long * v63;
                v63 = (long *)(v0+32ull);
                long v64;
                v64 = v63[0l];
                US5 v329;
                switch (v64) {
                    case 0: {
                        long * v66;
                        v66 = (long *)(v0+36ull);
                        long v67;
                        v67 = v66[0l];
                        US6 v78;
                        switch (v67) {
                            case 0: {
                                v78 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v70;
                                v70 = (long *)(v0+40ull);
                                long v71;
                                v71 = v70[0l];
                                US4 v76;
                                switch (v71) {
                                    case 0: {
                                        v76 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v76 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v76 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v78 = US6_1(v76);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v79;
                        v79 = (bool *)(v0+44ull);
                        bool v80;
                        v80 = v79[0l];
                        static_array<US4,2l> v81;
                        long v82;
                        v82 = 0l;
                        while (while_method_0(v82)){
                            unsigned long long v84;
                            v84 = (unsigned long long)v82;
                            unsigned long long v85;
                            v85 = v84 * 4ull;
                            unsigned long long v86;
                            v86 = 48ull + v85;
                            unsigned char * v87;
                            v87 = (unsigned char *)(v0+v86);
                            long * v88;
                            v88 = (long *)(v87+0ull);
                            long v89;
                            v89 = v88[0l];
                            US4 v94;
                            switch (v89) {
                                case 0: {
                                    v94 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v94 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v94 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v95;
                            v95 = 0l <= v82;
                            bool v97;
                            if (v95){
                                bool v96;
                                v96 = v82 < 2l;
                                v97 = v96;
                            } else {
                                v97 = false;
                            }
                            bool v98;
                            v98 = v97 == false;
                            if (v98){
                                assert("The read index needs to be in range." && v97);
                            } else {
                            }
                            v81.v[v82] = v94;
                            v82 += 1l ;
                        }
                        long * v99;
                        v99 = (long *)(v0+56ull);
                        long v100;
                        v100 = v99[0l];
                        static_array<long,2l> v101;
                        long v102;
                        v102 = 0l;
                        while (while_method_0(v102)){
                            unsigned long long v104;
                            v104 = (unsigned long long)v102;
                            unsigned long long v105;
                            v105 = v104 * 4ull;
                            unsigned long long v106;
                            v106 = 60ull + v105;
                            unsigned char * v107;
                            v107 = (unsigned char *)(v0+v106);
                            long * v108;
                            v108 = (long *)(v107+0ull);
                            long v109;
                            v109 = v108[0l];
                            bool v110;
                            v110 = 0l <= v102;
                            bool v112;
                            if (v110){
                                bool v111;
                                v111 = v102 < 2l;
                                v112 = v111;
                            } else {
                                v112 = false;
                            }
                            bool v113;
                            v113 = v112 == false;
                            if (v113){
                                assert("The read index needs to be in range." && v112);
                            } else {
                            }
                            v101.v[v102] = v109;
                            v102 += 1l ;
                        }
                        long * v114;
                        v114 = (long *)(v0+68ull);
                        long v115;
                        v115 = v114[0l];
                        v329 = US5_0(v78, v80, v81, v100, v101, v115);
                        break;
                    }
                    case 1: {
                        v329 = US5_1();
                        break;
                    }
                    case 2: {
                        long * v118;
                        v118 = (long *)(v0+36ull);
                        long v119;
                        v119 = v118[0l];
                        US6 v130;
                        switch (v119) {
                            case 0: {
                                v130 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v122;
                                v122 = (long *)(v0+40ull);
                                long v123;
                                v123 = v122[0l];
                                US4 v128;
                                switch (v123) {
                                    case 0: {
                                        v128 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v128 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v128 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v130 = US6_1(v128);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v131;
                        v131 = (bool *)(v0+44ull);
                        bool v132;
                        v132 = v131[0l];
                        static_array<US4,2l> v133;
                        long v134;
                        v134 = 0l;
                        while (while_method_0(v134)){
                            unsigned long long v136;
                            v136 = (unsigned long long)v134;
                            unsigned long long v137;
                            v137 = v136 * 4ull;
                            unsigned long long v138;
                            v138 = 48ull + v137;
                            unsigned char * v139;
                            v139 = (unsigned char *)(v0+v138);
                            long * v140;
                            v140 = (long *)(v139+0ull);
                            long v141;
                            v141 = v140[0l];
                            US4 v146;
                            switch (v141) {
                                case 0: {
                                    v146 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v146 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v146 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v147;
                            v147 = 0l <= v134;
                            bool v149;
                            if (v147){
                                bool v148;
                                v148 = v134 < 2l;
                                v149 = v148;
                            } else {
                                v149 = false;
                            }
                            bool v150;
                            v150 = v149 == false;
                            if (v150){
                                assert("The read index needs to be in range." && v149);
                            } else {
                            }
                            v133.v[v134] = v146;
                            v134 += 1l ;
                        }
                        long * v151;
                        v151 = (long *)(v0+56ull);
                        long v152;
                        v152 = v151[0l];
                        static_array<long,2l> v153;
                        long v154;
                        v154 = 0l;
                        while (while_method_0(v154)){
                            unsigned long long v156;
                            v156 = (unsigned long long)v154;
                            unsigned long long v157;
                            v157 = v156 * 4ull;
                            unsigned long long v158;
                            v158 = 60ull + v157;
                            unsigned char * v159;
                            v159 = (unsigned char *)(v0+v158);
                            long * v160;
                            v160 = (long *)(v159+0ull);
                            long v161;
                            v161 = v160[0l];
                            bool v162;
                            v162 = 0l <= v154;
                            bool v164;
                            if (v162){
                                bool v163;
                                v163 = v154 < 2l;
                                v164 = v163;
                            } else {
                                v164 = false;
                            }
                            bool v165;
                            v165 = v164 == false;
                            if (v165){
                                assert("The read index needs to be in range." && v164);
                            } else {
                            }
                            v153.v[v154] = v161;
                            v154 += 1l ;
                        }
                        long * v166;
                        v166 = (long *)(v0+68ull);
                        long v167;
                        v167 = v166[0l];
                        v329 = US5_2(v130, v132, v133, v152, v153, v167);
                        break;
                    }
                    case 3: {
                        long * v169;
                        v169 = (long *)(v0+36ull);
                        long v170;
                        v170 = v169[0l];
                        US6 v181;
                        switch (v170) {
                            case 0: {
                                v181 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v173;
                                v173 = (long *)(v0+40ull);
                                long v174;
                                v174 = v173[0l];
                                US4 v179;
                                switch (v174) {
                                    case 0: {
                                        v179 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v179 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v179 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v181 = US6_1(v179);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v182;
                        v182 = (bool *)(v0+44ull);
                        bool v183;
                        v183 = v182[0l];
                        static_array<US4,2l> v184;
                        long v185;
                        v185 = 0l;
                        while (while_method_0(v185)){
                            unsigned long long v187;
                            v187 = (unsigned long long)v185;
                            unsigned long long v188;
                            v188 = v187 * 4ull;
                            unsigned long long v189;
                            v189 = 48ull + v188;
                            unsigned char * v190;
                            v190 = (unsigned char *)(v0+v189);
                            long * v191;
                            v191 = (long *)(v190+0ull);
                            long v192;
                            v192 = v191[0l];
                            US4 v197;
                            switch (v192) {
                                case 0: {
                                    v197 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v197 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v197 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v198;
                            v198 = 0l <= v185;
                            bool v200;
                            if (v198){
                                bool v199;
                                v199 = v185 < 2l;
                                v200 = v199;
                            } else {
                                v200 = false;
                            }
                            bool v201;
                            v201 = v200 == false;
                            if (v201){
                                assert("The read index needs to be in range." && v200);
                            } else {
                            }
                            v184.v[v185] = v197;
                            v185 += 1l ;
                        }
                        long * v202;
                        v202 = (long *)(v0+56ull);
                        long v203;
                        v203 = v202[0l];
                        static_array<long,2l> v204;
                        long v205;
                        v205 = 0l;
                        while (while_method_0(v205)){
                            unsigned long long v207;
                            v207 = (unsigned long long)v205;
                            unsigned long long v208;
                            v208 = v207 * 4ull;
                            unsigned long long v209;
                            v209 = 60ull + v208;
                            unsigned char * v210;
                            v210 = (unsigned char *)(v0+v209);
                            long * v211;
                            v211 = (long *)(v210+0ull);
                            long v212;
                            v212 = v211[0l];
                            bool v213;
                            v213 = 0l <= v205;
                            bool v215;
                            if (v213){
                                bool v214;
                                v214 = v205 < 2l;
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
                            v204.v[v205] = v212;
                            v205 += 1l ;
                        }
                        long * v217;
                        v217 = (long *)(v0+68ull);
                        long v218;
                        v218 = v217[0l];
                        long * v219;
                        v219 = (long *)(v0+72ull);
                        long v220;
                        v220 = v219[0l];
                        US1 v225;
                        switch (v220) {
                            case 0: {
                                v225 = US1_0();
                                break;
                            }
                            case 1: {
                                v225 = US1_1();
                                break;
                            }
                            case 2: {
                                v225 = US1_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v329 = US5_3(v181, v183, v184, v203, v204, v218, v225);
                        break;
                    }
                    case 4: {
                        long * v227;
                        v227 = (long *)(v0+36ull);
                        long v228;
                        v228 = v227[0l];
                        US6 v239;
                        switch (v228) {
                            case 0: {
                                v239 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v231;
                                v231 = (long *)(v0+40ull);
                                long v232;
                                v232 = v231[0l];
                                US4 v237;
                                switch (v232) {
                                    case 0: {
                                        v237 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v237 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v237 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v239 = US6_1(v237);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v240;
                        v240 = (bool *)(v0+44ull);
                        bool v241;
                        v241 = v240[0l];
                        static_array<US4,2l> v242;
                        long v243;
                        v243 = 0l;
                        while (while_method_0(v243)){
                            unsigned long long v245;
                            v245 = (unsigned long long)v243;
                            unsigned long long v246;
                            v246 = v245 * 4ull;
                            unsigned long long v247;
                            v247 = 48ull + v246;
                            unsigned char * v248;
                            v248 = (unsigned char *)(v0+v247);
                            long * v249;
                            v249 = (long *)(v248+0ull);
                            long v250;
                            v250 = v249[0l];
                            US4 v255;
                            switch (v250) {
                                case 0: {
                                    v255 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v255 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v255 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v256;
                            v256 = 0l <= v243;
                            bool v258;
                            if (v256){
                                bool v257;
                                v257 = v243 < 2l;
                                v258 = v257;
                            } else {
                                v258 = false;
                            }
                            bool v259;
                            v259 = v258 == false;
                            if (v259){
                                assert("The read index needs to be in range." && v258);
                            } else {
                            }
                            v242.v[v243] = v255;
                            v243 += 1l ;
                        }
                        long * v260;
                        v260 = (long *)(v0+56ull);
                        long v261;
                        v261 = v260[0l];
                        static_array<long,2l> v262;
                        long v263;
                        v263 = 0l;
                        while (while_method_0(v263)){
                            unsigned long long v265;
                            v265 = (unsigned long long)v263;
                            unsigned long long v266;
                            v266 = v265 * 4ull;
                            unsigned long long v267;
                            v267 = 60ull + v266;
                            unsigned char * v268;
                            v268 = (unsigned char *)(v0+v267);
                            long * v269;
                            v269 = (long *)(v268+0ull);
                            long v270;
                            v270 = v269[0l];
                            bool v271;
                            v271 = 0l <= v263;
                            bool v273;
                            if (v271){
                                bool v272;
                                v272 = v263 < 2l;
                                v273 = v272;
                            } else {
                                v273 = false;
                            }
                            bool v274;
                            v274 = v273 == false;
                            if (v274){
                                assert("The read index needs to be in range." && v273);
                            } else {
                            }
                            v262.v[v263] = v270;
                            v263 += 1l ;
                        }
                        long * v275;
                        v275 = (long *)(v0+68ull);
                        long v276;
                        v276 = v275[0l];
                        v329 = US5_4(v239, v241, v242, v261, v262, v276);
                        break;
                    }
                    case 5: {
                        long * v278;
                        v278 = (long *)(v0+36ull);
                        long v279;
                        v279 = v278[0l];
                        US6 v290;
                        switch (v279) {
                            case 0: {
                                v290 = US6_0();
                                break;
                            }
                            case 1: {
                                long * v282;
                                v282 = (long *)(v0+40ull);
                                long v283;
                                v283 = v282[0l];
                                US4 v288;
                                switch (v283) {
                                    case 0: {
                                        v288 = US4_0();
                                        break;
                                    }
                                    case 1: {
                                        v288 = US4_1();
                                        break;
                                    }
                                    case 2: {
                                        v288 = US4_2();
                                        break;
                                    }
                                    default: {
                                        printf("%s\n", "Invalid tag.");
                                        asm("exit;");
                                    }
                                }
                                v290 = US6_1(v288);
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool * v291;
                        v291 = (bool *)(v0+44ull);
                        bool v292;
                        v292 = v291[0l];
                        static_array<US4,2l> v293;
                        long v294;
                        v294 = 0l;
                        while (while_method_0(v294)){
                            unsigned long long v296;
                            v296 = (unsigned long long)v294;
                            unsigned long long v297;
                            v297 = v296 * 4ull;
                            unsigned long long v298;
                            v298 = 48ull + v297;
                            unsigned char * v299;
                            v299 = (unsigned char *)(v0+v298);
                            long * v300;
                            v300 = (long *)(v299+0ull);
                            long v301;
                            v301 = v300[0l];
                            US4 v306;
                            switch (v301) {
                                case 0: {
                                    v306 = US4_0();
                                    break;
                                }
                                case 1: {
                                    v306 = US4_1();
                                    break;
                                }
                                case 2: {
                                    v306 = US4_2();
                                    break;
                                }
                                default: {
                                    printf("%s\n", "Invalid tag.");
                                    asm("exit;");
                                }
                            }
                            bool v307;
                            v307 = 0l <= v294;
                            bool v309;
                            if (v307){
                                bool v308;
                                v308 = v294 < 2l;
                                v309 = v308;
                            } else {
                                v309 = false;
                            }
                            bool v310;
                            v310 = v309 == false;
                            if (v310){
                                assert("The read index needs to be in range." && v309);
                            } else {
                            }
                            v293.v[v294] = v306;
                            v294 += 1l ;
                        }
                        long * v311;
                        v311 = (long *)(v0+56ull);
                        long v312;
                        v312 = v311[0l];
                        static_array<long,2l> v313;
                        long v314;
                        v314 = 0l;
                        while (while_method_0(v314)){
                            unsigned long long v316;
                            v316 = (unsigned long long)v314;
                            unsigned long long v317;
                            v317 = v316 * 4ull;
                            unsigned long long v318;
                            v318 = 60ull + v317;
                            unsigned char * v319;
                            v319 = (unsigned char *)(v0+v318);
                            long * v320;
                            v320 = (long *)(v319+0ull);
                            long v321;
                            v321 = v320[0l];
                            bool v322;
                            v322 = 0l <= v314;
                            bool v324;
                            if (v322){
                                bool v323;
                                v323 = v314 < 2l;
                                v324 = v323;
                            } else {
                                v324 = false;
                            }
                            bool v325;
                            v325 = v324 == false;
                            if (v325){
                                assert("The read index needs to be in range." && v324);
                            } else {
                            }
                            v313.v[v314] = v321;
                            v314 += 1l ;
                        }
                        long * v326;
                        v326 = (long *)(v0+68ull);
                        long v327;
                        v327 = v326[0l];
                        v329 = US5_5(v290, v292, v293, v312, v313, v327);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v331 = US3_1(v41, v329);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US7,32l,long> v332;
        v332.length = 0;
        long * v333;
        v333 = (long *)(v0+76ull);
        long v334;
        v334 = v333[0l];
        v332.length = v334;
        long v335;
        v335 = v332.length;
        long v336;
        v336 = 0l;
        while (while_method_1(v335, v336)){
            unsigned long long v338;
            v338 = (unsigned long long)v336;
            unsigned long long v339;
            v339 = v338 * 32ull;
            unsigned long long v340;
            v340 = 80ull + v339;
            unsigned char * v341;
            v341 = (unsigned char *)(v0+v340);
            long * v342;
            v342 = (long *)(v341+0ull);
            long v343;
            v343 = v342[0l];
            US7 v396;
            switch (v343) {
                case 0: {
                    long * v345;
                    v345 = (long *)(v341+4ull);
                    long v346;
                    v346 = v345[0l];
                    US4 v351;
                    switch (v346) {
                        case 0: {
                            v351 = US4_0();
                            break;
                        }
                        case 1: {
                            v351 = US4_1();
                            break;
                        }
                        case 2: {
                            v351 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v396 = US7_0(v351);
                    break;
                }
                case 1: {
                    long * v353;
                    v353 = (long *)(v341+4ull);
                    long v354;
                    v354 = v353[0l];
                    long * v355;
                    v355 = (long *)(v341+8ull);
                    long v356;
                    v356 = v355[0l];
                    US1 v361;
                    switch (v356) {
                        case 0: {
                            v361 = US1_0();
                            break;
                        }
                        case 1: {
                            v361 = US1_1();
                            break;
                        }
                        case 2: {
                            v361 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v396 = US7_1(v354, v361);
                    break;
                }
                case 2: {
                    long * v363;
                    v363 = (long *)(v341+4ull);
                    long v364;
                    v364 = v363[0l];
                    long * v365;
                    v365 = (long *)(v341+8ull);
                    long v366;
                    v366 = v365[0l];
                    US4 v371;
                    switch (v366) {
                        case 0: {
                            v371 = US4_0();
                            break;
                        }
                        case 1: {
                            v371 = US4_1();
                            break;
                        }
                        case 2: {
                            v371 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v396 = US7_2(v364, v371);
                    break;
                }
                case 3: {
                    static_array<US4,2l> v373;
                    long v374;
                    v374 = 0l;
                    while (while_method_0(v374)){
                        unsigned long long v376;
                        v376 = (unsigned long long)v374;
                        unsigned long long v377;
                        v377 = v376 * 4ull;
                        unsigned long long v378;
                        v378 = 4ull + v377;
                        unsigned char * v379;
                        v379 = (unsigned char *)(v341+v378);
                        long * v380;
                        v380 = (long *)(v379+0ull);
                        long v381;
                        v381 = v380[0l];
                        US4 v386;
                        switch (v381) {
                            case 0: {
                                v386 = US4_0();
                                break;
                            }
                            case 1: {
                                v386 = US4_1();
                                break;
                            }
                            case 2: {
                                v386 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        bool v387;
                        v387 = 0l <= v374;
                        bool v389;
                        if (v387){
                            bool v388;
                            v388 = v374 < 2l;
                            v389 = v388;
                        } else {
                            v389 = false;
                        }
                        bool v390;
                        v390 = v389 == false;
                        if (v390){
                            assert("The read index needs to be in range." && v389);
                        } else {
                        }
                        v373.v[v374] = v386;
                        v374 += 1l ;
                    }
                    long * v391;
                    v391 = (long *)(v341+12ull);
                    long v392;
                    v392 = v391[0l];
                    long * v393;
                    v393 = (long *)(v341+16ull);
                    long v394;
                    v394 = v393[0l];
                    v396 = US7_3(v373, v392, v394);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v397;
            v397 = 0l <= v336;
            bool v400;
            if (v397){
                long v398;
                v398 = v332.length;
                bool v399;
                v399 = v336 < v398;
                v400 = v399;
            } else {
                v400 = false;
            }
            bool v401;
            v401 = v400 == false;
            if (v401){
                assert("The set index needs to be in range." && v400);
            } else {
            }
            v332.v[v336] = v396;
            v336 += 1l ;
        }
        static_array<US2,2l> v402;
        long v403;
        v403 = 0l;
        while (while_method_0(v403)){
            unsigned long long v405;
            v405 = (unsigned long long)v403;
            unsigned long long v406;
            v406 = v405 * 4ull;
            unsigned long long v407;
            v407 = 1104ull + v406;
            unsigned char * v408;
            v408 = (unsigned char *)(v0+v407);
            long * v409;
            v409 = (long *)(v408+0ull);
            long v410;
            v410 = v409[0l];
            US2 v414;
            switch (v410) {
                case 0: {
                    v414 = US2_0();
                    break;
                }
                case 1: {
                    v414 = US2_1();
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v415;
            v415 = 0l <= v403;
            bool v417;
            if (v415){
                bool v416;
                v416 = v403 < 2l;
                v417 = v416;
            } else {
                v417 = false;
            }
            bool v418;
            v418 = v417 == false;
            if (v418){
                assert("The read index needs to be in range." && v417);
            } else {
            }
            v402.v[v403] = v414;
            v403 += 1l ;
        }
        long * v419;
        v419 = (long *)(v0+1112ull);
        long v420;
        v420 = v419[0l];
        US8 v525;
        switch (v420) {
            case 0: {
                v525 = US8_0();
                break;
            }
            case 1: {
                long * v423;
                v423 = (long *)(v0+1116ull);
                long v424;
                v424 = v423[0l];
                US6 v435;
                switch (v424) {
                    case 0: {
                        v435 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v427;
                        v427 = (long *)(v0+1120ull);
                        long v428;
                        v428 = v427[0l];
                        US4 v433;
                        switch (v428) {
                            case 0: {
                                v433 = US4_0();
                                break;
                            }
                            case 1: {
                                v433 = US4_1();
                                break;
                            }
                            case 2: {
                                v433 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v435 = US6_1(v433);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v436;
                v436 = (bool *)(v0+1124ull);
                bool v437;
                v437 = v436[0l];
                static_array<US4,2l> v438;
                long v439;
                v439 = 0l;
                while (while_method_0(v439)){
                    unsigned long long v441;
                    v441 = (unsigned long long)v439;
                    unsigned long long v442;
                    v442 = v441 * 4ull;
                    unsigned long long v443;
                    v443 = 1128ull + v442;
                    unsigned char * v444;
                    v444 = (unsigned char *)(v0+v443);
                    long * v445;
                    v445 = (long *)(v444+0ull);
                    long v446;
                    v446 = v445[0l];
                    US4 v451;
                    switch (v446) {
                        case 0: {
                            v451 = US4_0();
                            break;
                        }
                        case 1: {
                            v451 = US4_1();
                            break;
                        }
                        case 2: {
                            v451 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v452;
                    v452 = 0l <= v439;
                    bool v454;
                    if (v452){
                        bool v453;
                        v453 = v439 < 2l;
                        v454 = v453;
                    } else {
                        v454 = false;
                    }
                    bool v455;
                    v455 = v454 == false;
                    if (v455){
                        assert("The read index needs to be in range." && v454);
                    } else {
                    }
                    v438.v[v439] = v451;
                    v439 += 1l ;
                }
                long * v456;
                v456 = (long *)(v0+1136ull);
                long v457;
                v457 = v456[0l];
                static_array<long,2l> v458;
                long v459;
                v459 = 0l;
                while (while_method_0(v459)){
                    unsigned long long v461;
                    v461 = (unsigned long long)v459;
                    unsigned long long v462;
                    v462 = v461 * 4ull;
                    unsigned long long v463;
                    v463 = 1140ull + v462;
                    unsigned char * v464;
                    v464 = (unsigned char *)(v0+v463);
                    long * v465;
                    v465 = (long *)(v464+0ull);
                    long v466;
                    v466 = v465[0l];
                    bool v467;
                    v467 = 0l <= v459;
                    bool v469;
                    if (v467){
                        bool v468;
                        v468 = v459 < 2l;
                        v469 = v468;
                    } else {
                        v469 = false;
                    }
                    bool v470;
                    v470 = v469 == false;
                    if (v470){
                        assert("The read index needs to be in range." && v469);
                    } else {
                    }
                    v458.v[v459] = v466;
                    v459 += 1l ;
                }
                long * v471;
                v471 = (long *)(v0+1148ull);
                long v472;
                v472 = v471[0l];
                v525 = US8_1(v435, v437, v438, v457, v458, v472);
                break;
            }
            case 2: {
                long * v474;
                v474 = (long *)(v0+1116ull);
                long v475;
                v475 = v474[0l];
                US6 v486;
                switch (v475) {
                    case 0: {
                        v486 = US6_0();
                        break;
                    }
                    case 1: {
                        long * v478;
                        v478 = (long *)(v0+1120ull);
                        long v479;
                        v479 = v478[0l];
                        US4 v484;
                        switch (v479) {
                            case 0: {
                                v484 = US4_0();
                                break;
                            }
                            case 1: {
                                v484 = US4_1();
                                break;
                            }
                            case 2: {
                                v484 = US4_2();
                                break;
                            }
                            default: {
                                printf("%s\n", "Invalid tag.");
                                asm("exit;");
                            }
                        }
                        v486 = US6_1(v484);
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                bool * v487;
                v487 = (bool *)(v0+1124ull);
                bool v488;
                v488 = v487[0l];
                static_array<US4,2l> v489;
                long v490;
                v490 = 0l;
                while (while_method_0(v490)){
                    unsigned long long v492;
                    v492 = (unsigned long long)v490;
                    unsigned long long v493;
                    v493 = v492 * 4ull;
                    unsigned long long v494;
                    v494 = 1128ull + v493;
                    unsigned char * v495;
                    v495 = (unsigned char *)(v0+v494);
                    long * v496;
                    v496 = (long *)(v495+0ull);
                    long v497;
                    v497 = v496[0l];
                    US4 v502;
                    switch (v497) {
                        case 0: {
                            v502 = US4_0();
                            break;
                        }
                        case 1: {
                            v502 = US4_1();
                            break;
                        }
                        case 2: {
                            v502 = US4_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    bool v503;
                    v503 = 0l <= v490;
                    bool v505;
                    if (v503){
                        bool v504;
                        v504 = v490 < 2l;
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
                    v489.v[v490] = v502;
                    v490 += 1l ;
                }
                long * v507;
                v507 = (long *)(v0+1136ull);
                long v508;
                v508 = v507[0l];
                static_array<long,2l> v509;
                long v510;
                v510 = 0l;
                while (while_method_0(v510)){
                    unsigned long long v512;
                    v512 = (unsigned long long)v510;
                    unsigned long long v513;
                    v513 = v512 * 4ull;
                    unsigned long long v514;
                    v514 = 1140ull + v513;
                    unsigned char * v515;
                    v515 = (unsigned char *)(v0+v514);
                    long * v516;
                    v516 = (long *)(v515+0ull);
                    long v517;
                    v517 = v516[0l];
                    bool v518;
                    v518 = 0l <= v510;
                    bool v520;
                    if (v518){
                        bool v519;
                        v519 = v510 < 2l;
                        v520 = v519;
                    } else {
                        v520 = false;
                    }
                    bool v521;
                    v521 = v520 == false;
                    if (v521){
                        assert("The read index needs to be in range." && v520);
                    } else {
                    }
                    v509.v[v510] = v517;
                    v510 += 1l ;
                }
                long * v522;
                v522 = (long *)(v0+1148ull);
                long v523;
                v523 = v522[0l];
                v525 = US8_2(v486, v488, v489, v508, v509, v523);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        static_array_list<US7,32l,long> & v526 = v332;
        US3 v636; static_array_list<US7,32l,long> v637; static_array<US2,2l> v638; US8 v639;
        switch (v36.tag) {
            case 0: { // ActionSelected
                US1 v598 = v36.v.case0.v0;
                switch (v331.tag) {
                    case 0: { // None
                        v636 = v331; v637 = v332; v638 = v402; v639 = v525;
                        break;
                    }
                    default: { // Some
                        static_array_list<US4,6l,long> v599 = v331.v.case1.v0; US5 v600 = v331.v.case1.v1;
                        switch (v600.tag) {
                            case 2: { // Round
                                US6 v601 = v600.v.case2.v0; bool v602 = v600.v.case2.v1; static_array<US4,2l> v603 = v600.v.case2.v2; long v604 = v600.v.case2.v3; static_array<long,2l> v605 = v600.v.case2.v4; long v606 = v600.v.case2.v5;
                                static_array_list<US4,6l,long> & v607 = v599;
                                US5 v608;
                                v608 = US5_3(v601, v602, v603, v604, v605, v606, v598);
                                US3 v609; static_array<US2,2l> v610; US8 v611;
                                Tuple0 tmp9 = play_loop_0(v331, v402, v525, v526, v607, v608);
                                v609 = tmp9.v0; v610 = tmp9.v1; v611 = tmp9.v2;
                                v636 = v609; v637 = v332; v638 = v610; v639 = v611;
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
                static_array<US2,2l> v597 = v36.v.case1.v0;
                v636 = v331; v637 = v332; v638 = v597; v639 = v525;
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
                static_array_list<US4,6l,long> v531;
                v531.length = 0;
                v531.length = 6l;
                long v532;
                v532 = v531.length;
                bool v533;
                v533 = 0l < v532;
                bool v534;
                v534 = v533 == false;
                if (v534){
                    assert("The set index needs to be in range." && v533);
                } else {
                }
                US4 v535;
                v535 = US4_1();
                v531.v[0l] = v535;
                long v536;
                v536 = v531.length;
                bool v537;
                v537 = 1l < v536;
                bool v538;
                v538 = v537 == false;
                if (v538){
                    assert("The set index needs to be in range." && v537);
                } else {
                }
                US4 v539;
                v539 = US4_1();
                v531.v[1l] = v539;
                long v540;
                v540 = v531.length;
                bool v541;
                v541 = 2l < v540;
                bool v542;
                v542 = v541 == false;
                if (v542){
                    assert("The set index needs to be in range." && v541);
                } else {
                }
                US4 v543;
                v543 = US4_2();
                v531.v[2l] = v543;
                long v544;
                v544 = v531.length;
                bool v545;
                v545 = 3l < v544;
                bool v546;
                v546 = v545 == false;
                if (v546){
                    assert("The set index needs to be in range." && v545);
                } else {
                }
                US4 v547;
                v547 = US4_2();
                v531.v[3l] = v547;
                long v548;
                v548 = v531.length;
                bool v549;
                v549 = 4l < v548;
                bool v550;
                v550 = v549 == false;
                if (v550){
                    assert("The set index needs to be in range." && v549);
                } else {
                }
                US4 v551;
                v551 = US4_0();
                v531.v[4l] = v551;
                long v552;
                v552 = v531.length;
                bool v553;
                v553 = 5l < v552;
                bool v554;
                v554 = v553 == false;
                if (v554){
                    assert("The set index needs to be in range." && v553);
                } else {
                }
                US4 v555;
                v555 = US4_0();
                v531.v[5l] = v555;
                unsigned long long v556;
                v556 = clock64();
                curandStatePhilox4_32_10_t v557;
                curandStatePhilox4_32_10_t * v558 = &v557;
                curand_init(v556,0ull,0ull,v558);
                long v559;
                v559 = v531.length;
                long v560;
                v560 = v559 - 1l;
                long v561;
                v561 = 0l;
                while (while_method_1(v560, v561)){
                    long v563;
                    v563 = v531.length;
                    long v564;
                    v564 = v563 - v561;
                    unsigned long v565;
                    v565 = (unsigned long)v564;
                    unsigned long v566;
                    v566 = loop_2(v565, v558);
                    unsigned long v567;
                    v567 = (unsigned long)v561;
                    unsigned long v568;
                    v568 = v566 - v567;
                    long v569;
                    v569 = (long)v568;
                    bool v570;
                    v570 = 0l <= v561;
                    bool v573;
                    if (v570){
                        long v571;
                        v571 = v531.length;
                        bool v572;
                        v572 = v561 < v571;
                        v573 = v572;
                    } else {
                        v573 = false;
                    }
                    bool v574;
                    v574 = v573 == false;
                    if (v574){
                        assert("The read index needs to be in range." && v573);
                    } else {
                    }
                    US4 v575;
                    v575 = v531.v[v561];
                    bool v576;
                    v576 = 0l <= v569;
                    bool v579;
                    if (v576){
                        long v577;
                        v577 = v531.length;
                        bool v578;
                        v578 = v569 < v577;
                        v579 = v578;
                    } else {
                        v579 = false;
                    }
                    bool v580;
                    v580 = v579 == false;
                    if (v580){
                        assert("The read index needs to be in range." && v579);
                    } else {
                    }
                    US4 v581;
                    v581 = v531.v[v569];
                    bool v584;
                    if (v570){
                        long v582;
                        v582 = v531.length;
                        bool v583;
                        v583 = v561 < v582;
                        v584 = v583;
                    } else {
                        v584 = false;
                    }
                    bool v585;
                    v585 = v584 == false;
                    if (v585){
                        assert("The set index needs to be in range." && v584);
                    } else {
                    }
                    v531.v[v561] = v581;
                    bool v588;
                    if (v576){
                        long v586;
                        v586 = v531.length;
                        bool v587;
                        v587 = v569 < v586;
                        v588 = v587;
                    } else {
                        v588 = false;
                    }
                    bool v589;
                    v589 = v588 == false;
                    if (v589){
                        assert("The set index needs to be in range." && v588);
                    } else {
                    }
                    v531.v[v569] = v575;
                    v561 += 1l ;
                }
                US3 v590;
                v590 = US3_0();
                US8 v591;
                v591 = US8_0();
                static_array_list<US4,6l,long> & v592 = v531;
                US5 v593;
                v593 = US5_1();
                US3 v594; static_array<US2,2l> v595; US8 v596;
                Tuple0 tmp10 = play_loop_0(v590, v527, v591, v526, v592, v593);
                v594 = tmp10.v0; v595 = tmp10.v1; v596 = tmp10.v2;
                v636 = v594; v637 = v530; v638 = v595; v639 = v596;
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

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--ptxas-options=-v')
raw_module = cp.RawModule(code=kernel, backend='nvcc', enable_cooperative_groups=True, options=tuple(options))
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
def Closure0():
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
                while method12(v15):
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
                        while method12(v65):
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
                        while method12(v80):
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
                        while method12(v106):
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
                        while method12(v121):
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
                        while method12(v148):
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
                        while method12(v163):
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
                        while method12(v191):
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
                        while method12(v206):
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
                        while method12(v232):
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
                        while method12(v247):
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
                    while method12(v295):
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
        while method12(v311):
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
                while method12(v339):
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
                while method12(v354):
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
                while method12(v380):
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
                while method12(v395):
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
        v410((1,),(1,),(v3, v2),shared_mem=0)
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
                while method12(v457):
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
                while method12(v478):
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
                while method12(v511):
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
                while method12(v532):
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
                while method12(v564):
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
                while method12(v585):
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
                while method12(v624):
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
                while method12(v645):
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
                while method12(v677):
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
                while method12(v698):
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
                while method12(v759):
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
        while method12(v790):
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
            while method12(v827):
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
            while method12(v848):
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
            while method12(v880):
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
            while method12(v901):
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
        return method13(v716, v717, v789, v917)
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
        v3 = static_array_list(32)
        v4 = US3_0()
        v5 = US7_0()
        return method13(v4, v3, v0, v5)
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
def method12(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method15(v0 : US6) -> object:
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
def method17(v0 : US5) -> object:
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
            v5 = method15(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method18(v0 : US1) -> object:
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
def method16(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method17(v1)
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
                    v16 = "The read index needs to be in range."
                    assert v14, v16
                    del v16
                else:
                    pass
                del v14, v15
                v17 = v3[v10]
                v18 = method15(v17)
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
            v43 = method17(v37)
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
                    v52 = "The read index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = v39[v46]
                v54 = method15(v53)
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
            v78 = method17(v70)
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
                    v87 = "The read index needs to be in range."
                    assert v85, v87
                    del v87
                else:
                    pass
                del v85, v86
                v88 = v72[v81]
                v89 = method15(v88)
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
            v103 = method18(v76)
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
            v113 = method17(v107)
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
                    v122 = "The read index needs to be in range."
                    assert v120, v122
                    del v122
                else:
                    pass
                del v120, v121
                v123 = v109[v116]
                v124 = method15(v123)
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
            v146 = method17(v140)
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
                    v155 = "The read index needs to be in range."
                    assert v153, v155
                    del v155
                else:
                    pass
                del v153, v154
                v156 = v142[v149]
                v157 = method15(v156)
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
def method14(v0 : US3) -> object:
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
                v17 = method15(v16)
                del v16
                v6.append(v17)
                del v17
                v8 += 1 
            del v4, v7, v8
            v18 = method16(v5)
            del v5
            v19 = {'deck': v6, 'game': v18}
            del v6, v18
            v20 = "Some"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method19(v0 : US8) -> object:
    match v0:
        case US8_0(v1): # CommunityCardIs
            del v0
            v2 = method15(v1)
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
            v9 = method18(v6)
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
            v17 = method15(v14)
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
                    v31 = "The read index needs to be in range."
                    assert v29, v31
                    del v31
                else:
                    pass
                del v29, v30
                v32 = v21[v25]
                v33 = method15(v32)
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
            v10 = method17(v4)
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
                    v19 = "The read index needs to be in range."
                    assert v17, v19
                    del v19
                else:
                    pass
                del v17, v18
                v20 = v6[v13]
                v21 = method15(v20)
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
            v43 = method17(v37)
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
                    v52 = "The read index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = v39[v46]
                v54 = method15(v53)
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
def method13(v0 : US3, v1 : static_array_list, v2 : static_array, v3 : US7) -> object:
    v4 = method14(v0)
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
        v16 = method19(v15)
        del v15
        v5.append(v16)
        del v16
        v7 += 1 
    del v1, v6, v7
    v17 = []
    v18 = 0
    while method12(v18):
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
        v26 = method20(v25)
        del v25
        v17.append(v26)
        del v26
        v18 += 1 
    del v2, v18
    v27 = method21(v3)
    del v3
    v28 = {'messages': v5, 'pl_type': v17, 'ui_game_state': v27}
    del v5, v17, v27
    v29 = {'game_state': v4, 'ui_state': v28}
    del v4, v28
    return v29
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("Leduc_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
