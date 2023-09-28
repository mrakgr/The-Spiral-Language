#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
#include <bitset>
struct Tuple0;
bool method0(int32_t v0);
struct Tuple1;
bool method1(int32_t v0);
struct Tuple2;
struct Tuple3;
struct Tuple4;
bool method4(int32_t v0);
struct Tuple5;
struct Tuple6;
bool method7(int32_t v0);
Tuple6 random_ap6(ap_uint<128l> v0);
Tuple5 random_ap_in_range5(ap_uint<6l> v0, ap_uint<6l> v1, ap_uint<128l> v2);
struct Tuple7;
Tuple3 sample3(ap_uint<52l> v0, ap_uint<128l> v1);
Tuple2 draw_card2(ap_uint<52l> v0, ap_uint<128l> v1);
int32_t entry();
#endif
