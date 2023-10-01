#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <cstring>
struct Tuple0;
struct Tuple1;
struct Tuple2;
Tuple1 random_ap_1(ap_uint<128l> v0);
struct Tuple3;
struct Tuple4;
struct Tuple5;
struct Tuple6;
struct Tuple7;
struct Tuple8;
Tuple8 random_ap_6(ap_uint<128l> v0);
Tuple7 random_ap_in_range_5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2);
struct Tuple9;
Tuple5 sample_without_4(ap_uint<52l> v0, ap_uint<128l> v1);
Tuple4 draw_card_3(ap_uint<52l> v0, ap_uint<128l> v1);
struct US0;
struct US1;
struct Tuple10;
struct US2;
struct Tuple11;
struct Tuple12;
struct Tuple13;
struct Tuple14;
struct Tuple15;
Tuple15 random_ap_10(ap_uint<128l> v0);
struct Tuple16;
Tuple16 random_ap_11(ap_uint<128l> v0);
Tuple14 random_f32_template_9(bool v0, ap_uint<128l> v1);
struct US3;
struct Tuple17;
Tuple2 sample_discrete__8(std::array<float,8l> v0, ap_uint<128l> v1);
Tuple12 sample_discrete_7(std::array<Tuple11,8l> v0, ap_uint<128l> v1);
struct Tuple18;
struct Tuple19;
struct Tuple20;
struct Tuple21;
struct US4;
struct Tuple22;
struct US5;
struct US6;
struct US7;
struct US8;
struct Tuple23;
struct Tuple24;
struct Tuple25;
struct US9;
struct US10;
struct US11;
Tuple19 score_13(std::array<Tuple18,7l> v0);
Tuple19 score_12(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<4l> v2, ap_uint<2l> v3, ap_uint<4l> v4, ap_uint<2l> v5, ap_uint<4l> v6, ap_uint<2l> v7, ap_uint<4l> v8, ap_uint<2l> v9, ap_uint<4l> v10, ap_uint<2l> v11, ap_uint<4l> v12, ap_uint<2l> v13);
struct Tuple26;
Tuple3 game_2(ap_uint<52l> v0, ap_uint<128l> v1);
int16_t game_loop_0(ap_uint<128l> v0);
int32_t entry();
#endif
